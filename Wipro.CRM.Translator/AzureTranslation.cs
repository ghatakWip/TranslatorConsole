using System;
using System.IO;
using System.Net;
using System.Web;
using System.Runtime.Serialization;

namespace Wipro.CRM.Translator
{
    internal class AzureTranslation
    {
        internal static string TranslateSingle(string authToken)
        {
            //throw new NotImplementedException();
            string text = "HP Service Center.";
            string from = "en";
            string to = "Hi";
            string uri = "https://api.microsofttranslator.com/v2/Http.svc/Translate?text=" + HttpUtility.UrlEncode(text) + "&from=" + from + "&to=" + to;
            string translatedText = "";
            try
            {
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(uri);
                httpWebRequest.Headers.Add("Ocp-Apim-Subscription-Key", authToken);

                using (WebResponse response = httpWebRequest.GetResponse())
                using (Stream stream = response.GetResponseStream())
                {
                    DataContractSerializer dcs = new DataContractSerializer(Type.GetType("System.String"));
                    translatedText = (string)dcs.ReadObject(stream);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return translatedText;
        }

        public static string Translate(string authToken)
        {
            string text = "Use pixels to express measurements for padding and margins.";
            string from = "en";
            string to = "de";
            //string uri = "http://api.microsofttranslator.com/v2/Http.svc/Translate?text=" + System.Web.HttpUtility.UrlEncode(text) + "&from=" + from + "&to=" + to;
            string uri = "https://api.microsofttranslator.com/v2/Http.svc/Translate?text=" + HttpUtility.UrlEncode(text) + "&from=" + from + "&to=" + to;
            string translation = "";

            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(uri);
            httpWebRequest.Headers.Add("Authorization", authToken);
            WebResponse response = null;
            try
            {
                response = httpWebRequest.GetResponse();
                using (Stream stream = response.GetResponseStream())
                {
                    DataContractSerializer dcs = new DataContractSerializer(Type.GetType("System.String"));
                    translation = (string)dcs.ReadObject(stream);
                    Console.WriteLine("Translation for source text '{0}' from {1} to {2} is", text, "en", "de");
                    Console.WriteLine(translation);
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey(true);
            }
            catch
            {
                throw;
            }
            finally
            {
                if (response != null)
                {
                    response.Close();
                    response = null;
                }
            }

            return translation;
        }

    }
}