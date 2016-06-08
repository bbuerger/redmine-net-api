/*
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

using System.Collections.Specialized;
using System.Net;
using System.Text;
using Redmine.Net.Api.Extensions;
using Redmine.Net.Api.Types;

namespace Redmine.Net.Api.Internals
{
    internal static class WebApiHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="redmineManager"></param>
        /// <param name="address"></param>
        /// <param name="actionType"></param>
        /// <param name="data"></param>
        /// <param name="methodName"></param>
        public static void ExecuteUpload(RedmineManager redmineManager, string address, string actionType, string data,
            string methodName)
        {
            using (var wc = redmineManager.CreateWebClient(null))
            {
                try
                {
                    if (actionType == HttpVerbs.POST || actionType == HttpVerbs.DELETE || actionType == HttpVerbs.PUT ||
                        actionType == HttpVerbs.PATCH)
                    {
                        wc.UploadString(address, actionType, data);
                    }
                }
                catch (WebException webException)
                {
                    webException.HandleWebException(methodName, redmineManager.MimeFormat);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="redmineManager"></param>
        /// <param name="address"></param>
        /// <param name="actionType"></param>
        /// <param name="data"></param>
        /// <param name="methodName"></param>
        /// <returns></returns>
        public static T ExecuteUpload<T>(RedmineManager redmineManager, string address, string actionType, string data,
            string methodName)
            where T : class, new()
        {
            using (var wc = redmineManager.CreateWebClient(null))
            {
                try
                {
                    if (actionType == HttpVerbs.POST || actionType == HttpVerbs.DELETE || actionType == HttpVerbs.PUT ||
                        actionType == HttpVerbs.PATCH)
                    {
                        var response = wc.UploadString(address, actionType, data);
                        return RedmineSerializer.Deserialize<T>(response, redmineManager.MimeFormat);
                    }
                }
                catch (WebException webException)
                {
                    webException.HandleWebException(methodName, redmineManager.MimeFormat);
                }
                return default(T);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="redmineManager"></param>
        /// <param name="address"></param>
        /// <param name="methodName"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static T ExecuteDownload<T>(RedmineManager redmineManager, string address, string methodName,
            NameValueCollection parameters = null)
            where T : class, new()
        {
            using (var wc = redmineManager.CreateWebClient(parameters))
            {
                try
                {
                    var response = wc.DownloadString(address);
                    if (!string.IsNullOrEmpty(response))
                        return RedmineSerializer.Deserialize<T>(response, redmineManager.MimeFormat);
                }
                catch (WebException webException)
                {
                    webException.HandleWebException(methodName, redmineManager.MimeFormat);
                }
                return default(T);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="redmineManager"></param>
        /// <param name="address"></param>
        /// <param name="methodName"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static PaginatedObjects<T> ExecuteDownloadList<T>(RedmineManager redmineManager, string address,
            string methodName,
            NameValueCollection parameters = null) where T : class, new()
        {
            using (var wc = redmineManager.CreateWebClient(parameters))
            {
                try
                {
                    var response = wc.DownloadString(address);
                    return RedmineSerializer.DeserializeList<T>(response, redmineManager.MimeFormat);
                }
                catch (WebException webException)
                {
                    webException.HandleWebException(methodName, redmineManager.MimeFormat);
                }
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="redmineManager"></param>
        /// <param name="address"></param>
        /// <param name="methodName"></param>
        /// <returns></returns>
        public static byte[] ExecuteDownloadFile(RedmineManager redmineManager, string address, string methodName)
        {
            using (var wc = redmineManager.CreateWebClient(null, true))
            {
                try
                {
                    return wc.DownloadData(address);
                }
                catch (WebException webException)
                {
                    webException.HandleWebException(methodName, redmineManager.MimeFormat);
                }
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="redmineManager"></param>
        /// <param name="address"></param>
        /// <param name="data"></param>
        /// <param name="methodName"></param>
        /// <returns></returns>
        public static Upload ExecuteUploadFile(RedmineManager redmineManager, string address, byte[] data, string methodName)
        {
            using (var wc = redmineManager.CreateWebClient(null, true))
            {
                try
                {
                    var response = wc.UploadData(address, data);
                    var responseString = Encoding.ASCII.GetString(response);
                    return RedmineSerializer.Deserialize<Upload>(responseString, redmineManager.MimeFormat);
                }
                catch (WebException webException)
                {
                    webException.HandleWebException(methodName, redmineManager.MimeFormat);
                }
                return null;
            }
        }
    }
}