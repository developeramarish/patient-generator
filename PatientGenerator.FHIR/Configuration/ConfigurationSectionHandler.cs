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

using System.Configuration;
using System.Xml;

namespace PatientGenerator.FHIR.Configuration
{
	/// <summary>
	/// Represents the Fhir configuration section handler.
	/// </summary>
	public class ConfigurationSectionHandler : IConfigurationSectionHandler
	{
		public object Create(object parent, object configContext, XmlNode section)
		{
			XmlElement endpointsNode = section.SelectSingleNode("./*[local-name() = 'endpoints']") as XmlElement;

			XmlNodeList endpoints = endpointsNode.SelectNodes("./*[local-name() = 'endpoint']") as XmlNodeList;

			return null;
		}
	}
}