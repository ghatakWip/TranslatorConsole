using System;
using System.IO;
using System.Net;
using System.Web;
using System.Runtime.Serialization;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Text;
using System.Runtime.Serialization.Json;
using System.Collections.Generic;

namespace Wipro.CRM.Translator
{
    class Program
    {
        static void Main(string[] args)
        {
            string Subscriptionkey = "6b65b44bcd934164b66e58742b26a497";// Get the Key from Mapper          

            string text = "Hallo"; // From the Form
            string from = "en"; // From the form
            string to = "hi"; // From Form                        
            string uri = "https://api.microsofttranslator.com/v2/Http.svc/Translate?text=" + HttpUtility.UrlEncode(text) + "&from=" + from + "&to=" + to;


            #region Google Translator
            string apiKey = "AIzaSyBmdxU-y-3KenW-rdRqNEF8w--0txQtv1Q";
            string baseUri = "https://translation.googleapis.com/language/translate/v2?key=" + apiKey;
            string requestBody = string.Empty;
            #endregion

            string value = string.Empty;
            JObject requestBody = null;
            using (HttpClient aClient = new HttpClient())
            using (var request = new HttpRequestMessage())
            {
                try
                {
                    int options = 2;
                    HttpResponseMessage response = null;

                    switch (options)
                    {

                        case 1: // HttpGet
                            {
                                request.Method = HttpMethod.Get;
                                aClient.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", Subscriptionkey);

                                response = aClient.GetAsync(new Uri(uri)).Result;

                                break;

                            };
                        case 2: // HttpPost
                            {

                                //string ParameterFromLanguageKey = "source",
                                //ParameterToLanguageKey = "target",
                                //ParameterTextKey = "q";
                                request.Method = HttpMethod.Post;
                                request.RequestUri = new Uri(baseUri);

                                requestBody = new JObject();
                                requestBody.Add("q", text);
                                requestBody.Add("source", from);
                                requestBody.Add("target", to);

                                request.Content = new StringContent(requestBody.ToString(), Encoding.UTF8, "application/json");
                                request.Headers.TryAddWithoutValidation("Content-Type", "application/json");

                                //aClient.Timeout = TimeSpan.FromSeconds(2);
                                response = aClient.SendAsync(request).Result;

                                break;
                            };

                    }

                    if (response != null)
                    {
                        response.EnsureSuccessStatusCode();
                        value = response.Content.ReadAsStringAsync().Result;
                    }                    
                     
                }
                catch (Exception ex)
                {                    
                    throw ex;
                }
            }

        }
    }
}

//string translatedText = "";

//HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(uri);
//httpWebRequest.Headers.Add("Ocp-Apim-Subscription-Key", Subscriptionkey);// From Mapper

//using (WebResponse response = httpWebRequest.GetResponse())
//using (Stream stream = response.GetResponseStream())
//{
//    DataContractSerializer dcs = new DataContractSerializer(Type.GetType("System.String"));
//    translatedText = (string)dcs.ReadObject(stream);
//}