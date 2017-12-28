using System;

namespace IHIS.CloudConnector.Contracts.Models.Ocsa
{
    [Serializable]
    public class OCS0103U15GrdSlipHangmogInfo
    {
        private String _slipCode;
        private String _position;
        private String _seq;
        private String _hangmogCode;
        private String _hangmogName;
        private String _specimenCode;
        private String _groupYn;
        private String _bulyongCheck;
        private String _wonnaeDrgYn;
        private String _trialFlg;

        public String SlipCode
        {
            get { return this._slipCode; }
            set { this._slipCode = value; }
        }

        public String Position
        {
            get { return this._position; }
            set { this._position = value; }
        }

        public String Seq
        {
            get { return this._seq; }
            set { this._seq = value; }
        }

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

        public String SpecimenCode
        {
            get { return this._specimenCode; }
            set { this._specimenCode = value; }
        }

        public String GroupYn
        {
            get { return this._groupYn; }
            set { this._groupYn = value; }
        }

        public String BulyongCheck
        {
            get { return this._bulyongCheck; }
            set { this._bulyongCheck = value; }
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

        public OCS0103U15GrdSlipHangmogInfo() { }

        public OCS0103U15GrdSlipHangmogInfo(String slipCode, String position, String seq, String hangmogCode, String hangmogName, String specimenCode, String groupYn, String bulyongCheck, String wonnaeDrgYn, String trialFlg)
        {
            this._slipCode = slipCode;
            this._position = position;
            this._seq = seq;
            this._hangmogCode = hangmogCode;
            this._hangmogName = hangmogName;
            this._specimenCode = specimenCode;
            this._groupYn = groupYn;
            this._bulyongCheck = bulyongCheck;
            this._wonnaeDrgYn = wonnaeDrgYn;
            this._trialFlg = trialFlg;
        }

    }
}