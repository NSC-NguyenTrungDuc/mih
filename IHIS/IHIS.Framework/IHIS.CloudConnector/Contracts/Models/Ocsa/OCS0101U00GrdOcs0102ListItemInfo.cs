using System;

namespace IHIS.CloudConnector.Contracts.Models.Ocsa
{
    [Serializable]
    public class OCS0101U00GrdOcs0102ListItemInfo
    {
        private String _slipGubun;
        private String _slipCode;
        private String _slipName;
        private String _specimenText;
        private String _rowState;

        public String SlipGubun
        {
            get { return this._slipGubun; }
            set { this._slipGubun = value; }
        }

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

        public String SpecimenText
        {
            get { return this._specimenText; }
            set { this._specimenText = value; }
        }

        public String RowState
        {
            get { return this._rowState; }
            set { this._rowState = value; }
        }

        public OCS0101U00GrdOcs0102ListItemInfo() { }

        public OCS0101U00GrdOcs0102ListItemInfo(String slipGubun, String slipCode, String slipName, String specimenText, String rowState)
        {
            this._slipGubun = slipGubun;
            this._slipCode = slipCode;
            this._slipName = slipName;
            this._specimenText = specimenText;
            this._rowState = rowState;
        }

    }
}