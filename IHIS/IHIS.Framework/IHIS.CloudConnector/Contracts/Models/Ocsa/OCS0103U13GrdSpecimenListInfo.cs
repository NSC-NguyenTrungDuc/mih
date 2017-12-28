using System;

namespace IHIS.CloudConnector.Contracts.Models.Ocsa
{
    [Serializable]
    public class OCS0103U13GrdSpecimenListInfo
    {
        private String _slipCode;
        private String _position;
        private String _seq;
        private String _hangmogCode;
        private String _hangmogName1;
        private String _groupYn;
        private String _bulyongCheck;
        private String _wonnaeDrgYn;
        private String _selectYn;
        private String _hangmogName2;
        private String _trialFlag;

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

        public String HangmogName1
        {
            get { return this._hangmogName1; }
            set { this._hangmogName1 = value; }
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

        public String SelectYn
        {
            get { return this._selectYn; }
            set { this._selectYn = value; }
        }

        public String HangmogName2
        {
            get { return this._hangmogName2; }
            set { this._hangmogName2 = value; }
        }

        public String TrialFlag
        {
            get { return this._trialFlag; }
            set { this._trialFlag = value; }
        }

        public OCS0103U13GrdSpecimenListInfo() { }

        public OCS0103U13GrdSpecimenListInfo(String slipCode, String position, String seq, String hangmogCode, String hangmogName1, String groupYn, String bulyongCheck, String wonnaeDrgYn, String selectYn, String hangmogName2, String trialFlag)
        {
            this._slipCode = slipCode;
            this._position = position;
            this._seq = seq;
            this._hangmogCode = hangmogCode;
            this._hangmogName1 = hangmogName1;
            this._groupYn = groupYn;
            this._bulyongCheck = bulyongCheck;
            this._wonnaeDrgYn = wonnaeDrgYn;
            this._selectYn = selectYn;
            this._hangmogName2 = hangmogName2;
            this._trialFlag = trialFlag;
        }

    }
}