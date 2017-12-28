using System;

namespace IHIS.CloudConnector.Contracts.Models.NURO
{
    [Serializable]
    public class OrderTransMisaHangmogInfo
    {
        private String _hangmogCode;
        private String _hangmogCodeExt;

        public String HangmogCode
        {
            get { return this._hangmogCode; }
            set { this._hangmogCode = value; }
        }

        public String HangmogCodeExt
        {
            get { return this._hangmogCodeExt; }
            set { this._hangmogCodeExt = value; }
        }

        public OrderTransMisaHangmogInfo() { }

        public OrderTransMisaHangmogInfo(String hangmogCode, String hangmogCodeExt)
        {
            this._hangmogCode = hangmogCode;
            this._hangmogCodeExt = hangmogCodeExt;
        }

    }
}