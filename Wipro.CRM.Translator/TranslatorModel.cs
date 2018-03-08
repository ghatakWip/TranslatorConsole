using System;
using System.Runtime.Serialization;

namespace Wipro.CRM.Translator
{
    [DataContract]
    internal class TranslatorModel
    {
        public TranslatorModel(string parameterFromLanguageKey, string parameterToLanguageKey, string parameterTextKey)
        {
            SetVariableValues(parameterFromLanguageKey, parameterToLanguageKey, ParameterTextKey);
        }

        private void SetVariableValues(string parameterFromLanguageKey, string parameterToLanguageKey, object parameterTextKey)
        {
            this.ParameterFromLanguageKey = parameterFromLanguageKey;
            this.ParameterToLanguageKey = parameterToLanguageKey;
            this.ParameterTextKey = ParameterTextKey;
            //this.fromLanguage.GetType().Name
        }
        

        [DataMember( Name = "source")]
        public string fromLanguage
        {
            get;
            set;
        }

        [DataMember( Name = "q")]
        public string text
        {
            get;
            set;
        }

        [DataMember( Name = "target")]
        public string toLanguage
        {
            get;
            set;
        }
        private string ParameterTextKey
        {
            get;
            set;
        }


        private string ParameterToLanguageKey
        {
            get;
            set;
        }

        private string ParameterFromLanguageKey
        {
            get;
            set;
        }
    }
}