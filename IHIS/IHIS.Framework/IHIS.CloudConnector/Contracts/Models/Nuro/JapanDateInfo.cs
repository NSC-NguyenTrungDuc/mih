using System;

namespace IHIS.CloudConnector.Contracts.Models.Nuro
{
    [Serializable]
    public class JapanDateInfo
    {
        public JapanDateInfo() {}
    
        private string _naewonDateJp = "";
        public string NaewonDateJp
        {
            get { return _naewonDateJp; }
            set { _naewonDateJp = value; }
        }
    }
}