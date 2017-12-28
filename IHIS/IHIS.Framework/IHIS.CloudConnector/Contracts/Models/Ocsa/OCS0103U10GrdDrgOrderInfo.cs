using System;

namespace IHIS.CloudConnector.Contracts.Models.Ocsa
{
    [Serializable]
    public class OCS0103U10GrdDrgOrderInfo
    {
        private String _hangmogCode;
        private String _hangmogName;
        private String _wonyoiOrderCrYn;
        private String _defaultWonyoiOrderYn;
        private String _code1;
        private String _drgInfo;
        private String _orderGubun;
        private String _orderGubunName;
        private String _wonnaeDrgYn;
        private String _trialFlg;

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

        public String WonyoiOrderCrYn
        {
            get { return this._wonyoiOrderCrYn; }
            set { this._wonyoiOrderCrYn = value; }
        }

        public String DefaultWonyoiOrderYn
        {
            get { return this._defaultWonyoiOrderYn; }
            set { this._defaultWonyoiOrderYn = value; }
        }

        public String Code1
        {
            get { return this._code1; }
            set { this._code1 = value; }
        }

        public String DrgInfo
        {
            get { return this._drgInfo; }
            set { this._drgInfo = value; }
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

        public String WonnaeDrgYn
        {
            get { return this._wonnaeDrgYn; }
            set { this._wonnaeDrgYn = value; }
        }

        public String TrialFlg
        {
            get { return this._trialFlg; }
            set { this._trialFlg = value; }
        }

        public OCS0103U10GrdDrgOrderInfo() { }

        public OCS0103U10GrdDrgOrderInfo(String hangmogCode, String hangmogName, String wonyoiOrderCrYn, String defaultWonyoiOrderYn, String code1, String drgInfo, String orderGubun, String orderGubunName, String wonnaeDrgYn, String trialFlg)
        {
            this._hangmogCode = hangmogCode;
            this._hangmogName = hangmogName;
            this._wonyoiOrderCrYn = wonyoiOrderCrYn;
            this._defaultWonyoiOrderYn = defaultWonyoiOrderYn;
            this._code1 = code1;
            this._drgInfo = drgInfo;
            this._orderGubun = orderGubun;
            this._orderGubunName = orderGubunName;
            this._wonnaeDrgYn = wonnaeDrgYn;
            this._trialFlg = trialFlg;
        }

    }
}