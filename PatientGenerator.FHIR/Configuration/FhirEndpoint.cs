﻿/*
 * Copyright 2016-2016 Mohawk College of Applied Arts and Technology
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
 * Date: 2016-2-21
 */

using System.Xml.Serialization;

namespace PatientGenerator.FHIR.Configuration
{
	/// <summary>
	/// Represents a Fhir endpoint.
	/// </summary>
	[XmlRoot("endpoint")]
	public class FhirEndpoint
	{
		/// <summary>
		/// Initializes a new instance of the FhirEndpoint class.
		/// </summary>
		public FhirEndpoint()
		{
		}

		/// <summary>
		/// The address of the endpoint.
		/// </summary>
		[XmlAttribute("address")]
		public string Address { get; set; }

		/// <summary>
		/// The name of the endpoint.
		/// </summary>
		[XmlAttribute("name")]
		public string Name { get; set; }

		public override string ToString()
		{
			return Name + " " + Address;
		}
	}
}