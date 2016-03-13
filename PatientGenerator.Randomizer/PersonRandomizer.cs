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
 * Date: 2016-3-12
 */
using PatientGenerator.Randomizer.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientGenerator.Randomizer
{
	public class PersonRandomizer : RandomizerBase<CommonData>
	{
		private Random random = new Random();
		private CommonData commonData;

		public PersonRandomizer()
		{
			commonData = LoadData(ConfigurationManager.AppSettings["CommonFile"]);
		}

		public object GetRandomPatient()
		{
			GivenNameGenderPair nameGenderPair = commonData.GivenNames[random.Next(commonData.GivenNames.Count)];

			string firstName = nameGenderPair.Name;
			string middleName = commonData.GivenNames[random.Next(commonData.GivenNames.Count)].Name;
			string lastName = commonData.FamilyNames[random.Next(commonData.FamilyNames.Count - random.Next(1, commonData.FamilyNames.Count))];

			string postal = null;

			for (int i = 0; i < 6; i++)
			{
				if (i % 2 == 0)
					postal += (char)((byte)'A' + random.Next(20));
				else
					postal += random.Next(10).ToString();
				if (i == 2)
					postal += '-';
			}

			//Patient patient = new Patient
			//{
			//	AddressLine = random.Next(400).ToString("##0") + " " + commonData.StreetNames[random.Next(commonData.StreetNames.Count)],
			//	City = commonData.Cities[random.Next(commonData.Cities.Count)],
			//	DateOfBirth = new DateTime(random.Next(1930, 2014), random.Next(1, 11), random.Next(1, 28)),
			//	Email = (firstName + "." + lastName + random.Next(1000) + "@example.com").ToLower(),
			//	FirstName = firstName,
			//	Gender = nameGenderPair.GenderCode,
			//	HealthCardNo = OHIPUtilities.OHIPUtil.GenerateHealthNumber(random),
			//	Language = "eng",
			//	LastName = lastName,
			//	MiddleName = middleName,
			//	PhoneNo = "905575" + random.Next(1000, 9999),
			//	PostalCode = postal,
			//	Province = "Ontario"
			//};

#if DEBUG
			//Trace.TraceInformation(patient.FirstName + " " + patient.LastName + " " + patient.DateOfBirth.ToString("yyyy-MM-dd") + " " + patient.HealthCardNo);
#endif

			return null;
		}
	}
}
