using System;

namespace IHIS.CloudConnector.Contracts.Models.Orca
{
    [Serializable]
    public class ORCATransferOrdersLstSgCodeInfo
    {
        private String _hangmogCode;
        private String _hangmogName;
        private String _sgCode;

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

        public String SgCode
        {
            get { return this._sgCode; }
            set { this._sgCode = value; }
        }

        public ORCATransferOrdersLstSgCodeInfo() { }

        public ORCATransferOrdersLstSgCodeInfo(String hangmogCode, String hangmogName, String sgCode)
        {
            this._hangmogCode = hangmogCode;
            this._hangmogName = hangmogName;
            this._sgCode = sgCode;
        }

    }
}