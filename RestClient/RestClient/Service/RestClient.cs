using csharpRestClient.Service;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace csharpRestClient
{
    public enum HttpVerb
    {
        GET,
        POST,
        PUT,
        DELETE
    }

    public class RestClient : IRest
    {
        public string EndPoint { get; set; }
        public HttpVerb HttpMethod { get; set; }
        public RestClient()
        {
            EndPoint = string.Empty;
        }

        public string MakeRequest()
        {
            string stringResponseValue = string.Empty;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(EndPoint);
            HttpMethod = HttpVerb.GET;
            request.Method = HttpMethod.ToString();
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new ApplicationException($"Error code: {response.StatusCode}");
                }
                //Precess the response stream
                using (Stream responseStream = response.GetResponseStream())
                {
                    if (responseStream != null)
                    {
                        using (StreamReader reader = new StreamReader(responseStream))
                        {
                            stringResponseValue = reader.ReadToEnd();
                        }//End of StreamReader
                    }
                }//End of using ResponseStream
            }//End of using Response
            return stringResponseValue;
        }
    }
}
