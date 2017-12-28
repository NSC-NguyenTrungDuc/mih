using System;

namespace IHIS.CloudConnector.Contracts.Models.Xrts
{
    [Serializable]
    public class XRT0123U00GrdDCodeItemInfo
    {
        private String _xrayGubun;
        private String _buwiCode;
        private String _buwiName;
        private String _valtage;
        private String _curElectric;
        private String _time;
        private String _distance;
        private String _grid;
        private String _note;
        private String _xrayGubunName;
        private String _fromAge;
        private String _toAge;
        private String _masVal;
        private String _contKey;
        private String _rowState;

        public String XrayGubun
        {
            get { return this._xrayGubun; }
            set { this._xrayGubun = value; }
        }

        public String BuwiCode
        {
            get { return this._buwiCode; }
            set { this._buwiCode = value; }
        }

        public String BuwiName
        {
            get { return this._buwiName; }
            set { this._buwiName = value; }
        }

        public String Valtage
        {
            get { return this._valtage; }
            set { this._valtage = value; }
        }

        public String CurElectric
        {
            get { return this._curElectric; }
            set { this._curElectric = value; }
        }

        public String Time
        {
            get { return this._time; }
            set { this._time = value; }
        }

        public String Distance
        {
            get { return this._distance; }
            set { this._distance = value; }
        }

        public String Grid
        {
            get { return this._grid; }
            set { this._grid = value; }
        }

        public String Note
        {
            get { return this._note; }
            set { this._note = value; }
        }

        public String XrayGubunName
        {
            get { return this._xrayGubunName; }
            set { this._xrayGubunName = value; }
        }

        public String FromAge
        {
            get { return this._fromAge; }
            set { this._fromAge = value; }
        }

        public String ToAge
        {
            get { return this._toAge; }
            set { this._toAge = value; }
        }

        public String MasVal
        {
            get { return this._masVal; }
            set { this._masVal = value; }
        }

        public String ContKey
        {
            get { return this._contKey; }
            set { this._contKey = value; }
        }

        public String RowState
        {
            get { return this._rowState; }
            set { this._rowState = value; }
        }

        public XRT0123U00GrdDCodeItemInfo() { }

        public XRT0123U00GrdDCodeItemInfo(String xrayGubun, String buwiCode, String buwiName, String valtage, String curElectric, String time, String distance, String grid, String note, String xrayGubunName, String fromAge, String toAge, String masVal, String contKey, String rowState)
        {
            this._xrayGubun = xrayGubun;
            this._buwiCode = buwiCode;
            this._buwiName = buwiName;
            this._valtage = valtage;
            this._curElectric = curElectric;
            this._time = time;
            this._distance = distance;
            this._grid = grid;
            this._note = note;
            this._xrayGubunName = xrayGubunName;
            this._fromAge = fromAge;
            this._toAge = toAge;
            this._masVal = masVal;
            this._contKey = contKey;
            this._rowState = rowState;
        }

    }
}