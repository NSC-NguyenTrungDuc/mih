using System;

namespace IHIS.CloudConnector.Contracts.Models.Ocso
{
    [Serializable]
    public class OCSACTGrdSangByungInfo
    {
        private String _sangName;

        public String SangName
        {
            get { return this._sangName; }
            set { this._sangName = value; }
        }

        public OCSACTGrdSangByungInfo() { }

        public OCSACTGrdSangByungInfo(String sangName)
        {
            this._sangName = sangName;
        }

    }
}