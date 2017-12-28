using System;

namespace IHIS.CloudConnector.Contracts.Models.Orca
{
    [Serializable]
    public class ORCATransferOrdersErrMsgInfo
    {
        private String _hangmogCode;
        private String _hangmogName;
        private String _errCode;

        public String HangmogCode
        {
            get { return this._hangmogCode; }
            set { this._hangmogCode = value; }
        }

        public String HangmogName
        {
            get { return this._hangmogName; }
            set { this._hangmogName = value; }
        }

        public String ErrCode
        {
            get { return this._errCode; }
            set { this._errCode = value; }
        }

        public ORCATransferOrdersErrMsgInfo() { }

        public ORCATransferOrdersErrMsgInfo(String hangmogCode, String hangmogName, String errCode)
        {
            this._hangmogCode = hangmogCode;
            this._hangmogName = hangmogName;
            this._errCode = errCode;
        }

    }
}