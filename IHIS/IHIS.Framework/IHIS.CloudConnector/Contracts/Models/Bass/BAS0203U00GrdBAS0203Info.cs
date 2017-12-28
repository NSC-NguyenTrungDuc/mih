using System;

namespace IHIS.CloudConnector.Contracts.Models.Bass
{
    [Serializable]
    public class BAS0203U00GrdBAS0203Info
    {
        private String _jyDate;
        private String _symyaGubun;
        private String _symyaGubunName;
        private String _bunCode;
        private String _bunName;
        private String _sgCode;
        private String _sgName;
        private String _fromTime;
        private String _toTime;
        private String _yoilGubun;
        private String _fromMonth;
        private String _toMonth;
        private String _oldJyDate;
        private String _oldSymyaGubun;
        private String _oldBunCode;
        private String _oldSgCode;
        private String _oldFromTime;
        private String _oldToTime;
        private String _oldYoilGubun;
        private String _oldFromMonth;
        private String _oldToMonth;
        private String _contKey;
        private String _rowState;

        public String JyDate
        {
            get { return this._jyDate; }
            set { this._jyDate = value; }
        }

        public String SymyaGubun
        {
            get { return this._symyaGubun; }
            set { this._symyaGubun = value; }
        }

        public String SymyaGubunName
        {
            get { return this._symyaGubunName; }
            set { this._symyaGubunName = value; }
        }

        public String BunCode
        {
            get { return this._bunCode; }
            set { this._bunCode = value; }
        }

        public String BunName
        {
            get { return this._bunName; }
            set { this._bunName = value; }
        }

        public String SgCode
        {
            get { return this._sgCode; }
            set { this._sgCode = value; }
        }

        public String SgName
        {
            get { return this._sgName; }
            set { this._sgName = value; }
        }

        public String FromTime
        {
            get { return this._fromTime; }
            set { this._fromTime = value; }
        }

        public String ToTime
        {
            get { return this._toTime; }
            set { this._toTime = value; }
        }

        public String YoilGubun
        {
            get { return this._yoilGubun; }
            set { this._yoilGubun = value; }
        }

        public String FromMonth
        {
            get { return this._fromMonth; }
            set { this._fromMonth = value; }
        }

        public String ToMonth
        {
            get { return this._toMonth; }
            set { this._toMonth = value; }
        }

        public String OldJyDate
        {
            get { return this._oldJyDate; }
            set { this._oldJyDate = value; }
        }

        public String OldSymyaGubun
        {
            get { return this._oldSymyaGubun; }
            set { this._oldSymyaGubun = value; }
        }

        public String OldBunCode
        {
            get { return this._oldBunCode; }
            set { this._oldBunCode = value; }
        }

        public String OldSgCode
        {
            get { return this._oldSgCode; }
            set { this._oldSgCode = value; }
        }

        public String OldFromTime
        {
            get { return this._oldFromTime; }
            set { this._oldFromTime = value; }
        }

        public String OldToTime
        {
            get { return this._oldToTime; }
            set { this._oldToTime = value; }
        }

        public String OldYoilGubun
        {
            get { return this._oldYoilGubun; }
            set { this._oldYoilGubun = value; }
        }

        public String OldFromMonth
        {
            get { return this._oldFromMonth; }
            set { this._oldFromMonth = value; }
        }

        public String OldToMonth
        {
            get { return this._oldToMonth; }
            set { this._oldToMonth = value; }
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

        public BAS0203U00GrdBAS0203Info() { }

        public BAS0203U00GrdBAS0203Info(String jyDate, String symyaGubun, String symyaGubunName, String bunCode, String bunName, String sgCode, String sgName, String fromTime, String toTime, String yoilGubun, String fromMonth, String toMonth, String oldJyDate, String oldSymyaGubun, String oldBunCode, String oldSgCode, String oldFromTime, String oldToTime, String oldYoilGubun, String oldFromMonth, String oldToMonth, String contKey, String rowState)
        {
            this._jyDate = jyDate;
            this._symyaGubun = symyaGubun;
            this._symyaGubunName = symyaGubunName;
            this._bunCode = bunCode;
            this._bunName = bunName;
            this._sgCode = sgCode;
            this._sgName = sgName;
            this._fromTime = fromTime;
            this._toTime = toTime;
            this._yoilGubun = yoilGubun;
            this._fromMonth = fromMonth;
            this._toMonth = toMonth;
            this._oldJyDate = oldJyDate;
            this._oldSymyaGubun = oldSymyaGubun;
            this._oldBunCode = oldBunCode;
            this._oldSgCode = oldSgCode;
            this._oldFromTime = oldFromTime;
            this._oldToTime = oldToTime;
            this._oldYoilGubun = oldYoilGubun;
            this._oldFromMonth = oldFromMonth;
            this._oldToMonth = oldToMonth;
            this._contKey = contKey;
            this._rowState = rowState;
        }

    }
}