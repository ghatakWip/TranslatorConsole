using System.Runtime.Serialization;

namespace Wipro.CRM.Translator
{
    [DataContract]
    internal class SerializableClass
    {

        public string key
        {
            get; set;
        }

        public string value
        {
            get; set;
        }
    }
}