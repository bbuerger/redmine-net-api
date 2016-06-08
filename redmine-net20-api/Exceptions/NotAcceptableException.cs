﻿/*
   Copyright 2011 - 2016 Adrian Popescu.

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
*/

using System;
using System.Runtime.Serialization;

namespace Redmine.Net.Api.Exceptions
{
	public class NotAcceptableException : RedmineException
	{
		public NotAcceptableException()
			: base() { }

		public NotAcceptableException(string message)
			: base(message) { }

		public NotAcceptableException(string format, params object[] args)
			: base(string.Format(format, args)) { }

		public NotAcceptableException(string message, Exception innerException)
			: base(message, innerException) { }

		public NotAcceptableException(string format, Exception innerException, params object[] args)
			: base(string.Format(format, args), innerException) { }

		protected NotAcceptableException(SerializationInfo info, StreamingContext context)
			: base(info, context) { }
	}
}

