﻿/*
 * Copyright 2016-2017 Mohawk College of Applied Arts and Technology
 *
 * Licensed under the Apache License, Version 2.0 (the "License"); you
 * may not use this file except in compliance with the License. You may
 * obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS, WITHOUT
 * WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the
 * License for the specific language governing permissions and limitations under
 * the License.
 *
 * User: Nityan
 * Date: 2016-2-15
 */

using MARC.HI.EHRS.SVC.Core;
using PatientGenerator.Core;
using PatientGenerator.Core.Model.Common;
using PatientGenerator.Core.Model.ComponentModel;
using PatientGenerator.Core.Validation;
using PatientGenerator.Messaging.Model;
using PatientGenerator.Messaging.Services;
using PatientGenerator.Messaging.Validation;
using System.Collections.Generic;
using System.Linq;

namespace PatientGenerator.Messaging.MessageReceiver
{
	/// <summary>
	/// Provides operations to generate patients.
	/// </summary>
	public class GenerationService : IGenerationService
	{
		private readonly IFhirSenderService fhirSenderService;
		private readonly IHL7v2SenderService hl7v2SenderService;
		private readonly IHL7v3SenderService hl7v3SenderService;
		private readonly IPersistenceService persistenceService;
		private readonly IRandomizerService randomizerService;

		/// <summary>
		/// Initializes a new instance of the GenerationService class.
		/// </summary>
		public GenerationService()
		{
			fhirSenderService = ApplicationContext.Current.GetService<IFhirSenderService>();
			hl7v2SenderService = ApplicationContext.Current.GetService<IHL7v2SenderService>();
			hl7v3SenderService = ApplicationContext.Current.GetService<IHL7v3SenderService>();
			persistenceService = ApplicationContext.Current.GetService<IPersistenceService>();
			randomizerService = ApplicationContext.Current.GetService<IRandomizerService>();
		}

		#region IGenerationService Members

		/// <summary>
		/// Generates patients using a randomized dataset.
		/// </summary>
		/// <param name="count">The number of patients to generate.</param>
		/// <returns>Returns a GenerationResponse.</returns>
		public GenerationResponse GeneratePatients(int count)
		{
			GenerationResponse response = new GenerationResponse();

			List<Patient> patients = new List<Patient>();

			for (int i = 0; i < count; i++)
			{
				patients.Add(randomizerService.GetRandomPatient());
			}

			foreach (Patient patient in patients)
			{
				// send to fhir endpoints
				fhirSenderService?.Send(patient);

				// send to hl7v2 endpoints
				hl7v2SenderService?.Send(patient);

				// send to hl7v3 endpoints
				hl7v3SenderService?.Send(patient);
			}

			return response;
		}

		/// <summary>
		/// Generates patients using the provided options.
		/// </summary>
		/// <param name="options">The options to use to generate patients.</param>
		/// <returns>Returns a GenerationResponse.</returns>
		public GenerationResponse GeneratePatients(Demographic options)
		{
			GenerationResponse response = new GenerationResponse();

			IEnumerable<IResultDetail> details = ValidationUtil.ValidateMessage(options);

			if (details.Count(x => x.Type == ResultDetailType.Error) > 0)
			{
				response.Messages.AddRange(details.Select(x => x.Message));
				response.HasErrors = true;
			}
			else
			{
				// no validation errors, save the options
				persistenceService?.Save(options);

				// send to fhir endpoints
				fhirSenderService?.Send(options);

				// send to hl7v2 endpoints
				hl7v2SenderService?.Send(options);

				// send to hl7v3 endpoints
				hl7v3SenderService?.Send(options);
			}

			return response;
		}

		#endregion IGenerationService Members
	}
}