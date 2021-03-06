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
 * Date: 2016-2-27
 */

namespace PatientGenerator.Core.Validation
{
	/// <summary>
	/// Represents a result detail type.
	/// </summary>
	public enum ResultDetailType
	{
		/// <summary>
		/// Represents an error result.
		/// </summary>
		Error = 0,

		/// <summary>
		/// Represents a warning result.
		/// </summary>
		Warning = 1,

		/// <summary>
		/// Represents an informational result.
		/// </summary>
		Information = 2
	}
}