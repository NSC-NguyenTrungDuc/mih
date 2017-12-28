using System;

namespace IHIS.CloudConnector.Contracts.Models.Ocsa
{
    [Serializable]
    public class OCS0103U11LoadSlipHangmogInfo
    {
        private String _hangmogCode;
        private String _hangmogName;
        private String _orderGubun;
        private String _orderGubunName;
        private String _specificComment;
        private String _trialFlag;

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

        public String OrderGubun
        {
            get { return this._orderGubun; }
            set { this._orderGubun = value; }
        }

        public String OrderGubunName
        {
            get { return this._orderGubunName; }
            set { this._orderGubunName = value; }
        }

        public String SpecificComment
        {
            get { return this._specificComment; }
            set { this._specificComment = value; }
        }

        public String TrialFlag
        {
            get { return this._trialFlag; }
            set { this._trialFlag = value; }
        }

        public OCS0103U11LoadSlipHangmogInfo() { }

        public OCS0103U11LoadSlipHangmogInfo(String hangmogCode, String hangmogName, String orderGubun, String orderGubunName, String specificComment, String trialFlag)
        {
            this._hangmogCode = hangmogCode;
            this._hangmogName = hangmogName;
            this._orderGubun = orderGubun;
            this._orderGubunName = orderGubunName;
            this._specificComment = specificComment;
            this._trialFlag = trialFlag;
        }

    }
}