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
	public class NameResolutionFailureException : RedmineException
	{
		public NameResolutionFailureException()
			: base() { }

		public NameResolutionFailureException(string message)
			: base(message) { }

		public NameResolutionFailureException(string format, params object[] args)
			: base(string.Format(format, args)) { }

		public NameResolutionFailureException(string message, Exception innerException)
			: base(message, innerException) { }

		public NameResolutionFailureException(string format, Exception innerException, params object[] args)
			: base(string.Format(format, args), innerException) { }

		protected NameResolutionFailureException(SerializationInfo info, StreamingContext context)
			: base(info, context) { }
	}
}

