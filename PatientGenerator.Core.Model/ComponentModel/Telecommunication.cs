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
 * Date: 2017-4-9
 */

using System.Collections.Generic;

namespace PatientGenerator.Core.Model.ComponentModel
{
	/// <summary>
	/// Represents telecom options for a patient.
	/// </summary>
	public class Telecommunication
	{
		/// <summary>
		/// Initializes a new instance of the TelecomOptions class.
		/// </summary>
		public Telecommunication()
		{
			this.EmailAddresses = new List<string>();
			this.PhoneNumbers = new List<string>();
		}

		/// <summary>
		/// The email addresses of the patient.
		/// </summary>
		public List<string> EmailAddresses { get; set; }

		/// <summary>
		/// The phone numbers of the patient.
		/// </summary>
		public List<string> PhoneNumbers { get; set; }
	}
}