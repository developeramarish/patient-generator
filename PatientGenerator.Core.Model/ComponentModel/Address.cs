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

namespace PatientGenerator.Core.Model.ComponentModel
{
	/// <summary>
	/// Represents address options for a patient.
	/// </summary>
	public class Address
	{
		/// <summary>
		/// Initializes a new instance of the AddressOptions class.
		/// </summary>
		public Address()
		{
		}

		/// <summary>
		/// The city of the patient's address.
		/// </summary>
		public string City { get; set; }

		/// <summary>
		/// The country of the patient's address.
		/// </summary>
		public string Country { get; set; }

		/// <summary>
		/// The State/Province of the patient's address.
		/// </summary>
		public string StateProvince { get; set; }

		/// <summary>
		/// The street address of the patient.
		/// </summary>
		public string StreetAddress { get; set; }

		/// <summary>
		/// The Zip/Postal Code of the patient's address.
		/// </summary>
		public string ZipPostalCode { get; set; }
	}
}