using System;

namespace IHIS.CloudConnector.Contracts.Models.OcsEmr
{
    public class OCS2015U00GetDataInsPersonInfo
    {
        private String _insPersonNo;
        private String _recipientNo;

        public String InsPersonNo
        {
            get { return this._insPersonNo; }
            set { this._insPersonNo = value; }
        }

        public String RecipientNo
        {
            get { return this._recipientNo; }
            set { this._recipientNo = value; }
        }

        public OCS2015U00GetDataInsPersonInfo() { }

        public OCS2015U00GetDataInsPersonInfo(String insPersonNo, String recipientNo)
        {
            this._insPersonNo = insPersonNo;
            this._recipientNo = recipientNo;
        }

    }
}