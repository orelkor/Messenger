using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.Core.Concrete
{
   public static class HttpRequests
    {
        public static string GET_http(string url)
        {
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            WebRequest reqGET = WebRequest.Create(url);
            WebResponse resp = reqGET.GetResponse();
            Stream stream = resp.GetResponseStream();
            StreamReader sr = new StreamReader(stream);
            string html = sr.ReadToEnd();
            return html;
        }

        public static string POST_http(string url, string data)
        {
            var cookies = new CookieContainer();
            ServicePointManager.Expect100Continue = false;

            var request = (HttpWebRequest)WebRequest.Create(url);
            request.CookieContainer = cookies;
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            using (var requestStream = request.GetRequestStream())
            using (var writer = new StreamWriter(requestStream))
            {
                writer.Write(data);
            }

            using (var responseStream = request.GetResponse().GetResponseStream())
            using (var reader = new StreamReader(responseStream))
            {
                var result = reader.ReadToEnd();
                return result;
            }
        }
    }
}
