using System;

namespace IHIS.CloudConnector.Contracts.Models.Cpls
{
    [Serializable]
    public class CPL0001U00GrdSlipInfo
    {
        private String _slipCode;
        private String _slipName;
        private String _slipNameRe;
        private String _jundalGubun;
        private String _rowState;

        public String SlipCode
        {
            get { return this._slipCode; }
            set { this._slipCode = value; }
        }

        public String SlipName
        {
            get { return this._slipName; }
            set { this._slipName = value; }
        }

        public String SlipNameRe
        {
            get { return this._slipNameRe; }
            set { this._slipNameRe = value; }
        }

        public String JundalGubun
        {
            get { return this._jundalGubun; }
            set { this._jundalGubun = value; }
        }

        public String RowState
        {
            get { return this._rowState; }
            set { this._rowState = value; }
        }

        public CPL0001U00GrdSlipInfo() { }

        public CPL0001U00GrdSlipInfo(String slipCode, String slipName, String slipNameRe, String jundalGubun, String rowState)
        {
            this._slipCode = slipCode;
            this._slipName = slipName;
            this._slipNameRe = slipNameRe;
            this._jundalGubun = jundalGubun;
            this._rowState = rowState;
        }

    }
}