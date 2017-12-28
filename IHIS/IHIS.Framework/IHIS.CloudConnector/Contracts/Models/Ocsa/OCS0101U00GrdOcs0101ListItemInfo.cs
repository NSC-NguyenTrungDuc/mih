using System;

namespace IHIS.CloudConnector.Contracts.Models.Ocsa
{
    [Serializable]
    public class OCS0101U00GrdOcs0101ListItemInfo
    {
        private String _slipGubun;
        private String _slipGubunName;
        private String _rowState;

        public String SlipGubun
        {
            get { return this._slipGubun; }
            set { this._slipGubun = value; }
        }

        public String SlipGubunName
        {
            get { return this._slipGubunName; }
            set { this._slipGubunName = value; }
        }

        public String RowState
        {
            get { return this._rowState; }
            set { this._rowState = value; }
        }

        public OCS0101U00GrdOcs0101ListItemInfo() { }

        public OCS0101U00GrdOcs0101ListItemInfo(String slipGubun, String slipGubunName, String rowState)
        {
            this._slipGubun = slipGubun;
            this._slipGubunName = slipGubunName;
            this._rowState = rowState;
        }

    }
}