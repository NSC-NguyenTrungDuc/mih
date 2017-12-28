using System;

namespace IHIS.CloudConnector.Contracts.Models.Ocsa
{
    [Serializable]
    public class OCS0103U00GrdOCS0108Info
    {
        private String _hangmogCode;
        private String _ordDanui;
        private String _seq;
        private String _sunabGijun;
        private String _subulGijun;
        private String _hospCode;
        private String _hangmogStartDate;
        private String _codeName1;
        private String _codeName2;
        private String _rowState;

        public String HangmogCode
        {
            get { return this._hangmogCode; }
            set { this._hangmogCode = value; }
        }

        public String OrdDanui
        {
            get { return this._ordDanui; }
            set { this._ordDanui = value; }
        }

        public String Seq
        {
            get { return this._seq; }
            set { this._seq = value; }
        }

        public String SunabGijun
        {
            get { return this._sunabGijun; }
            set { this._sunabGijun = value; }
        }

        public String SubulGijun
        {
            get { return this._subulGijun; }
            set { this._subulGijun = value; }
        }

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public String HangmogStartDate
        {
            get { return this._hangmogStartDate; }
            set { this._hangmogStartDate = value; }
        }

        public String CodeName1
        {
            get { return this._codeName1; }
            set { this._codeName1 = value; }
        }

        public String CodeName2
        {
            get { return this._codeName2; }
            set { this._codeName2 = value; }
        }

        public String RowState
        {
            get { return this._rowState; }
            set { this._rowState = value; }
        }

        public OCS0103U00GrdOCS0108Info() { }

        public OCS0103U00GrdOCS0108Info(String hangmogCode, String ordDanui, String seq, String sunabGijun, String subulGijun, String hospCode, String hangmogStartDate, String codeName1, String codeName2, String rowState)
        {
            this._hangmogCode = hangmogCode;
            this._ordDanui = ordDanui;
            this._seq = seq;
            this._sunabGijun = sunabGijun;
            this._subulGijun = subulGijun;
            this._hospCode = hospCode;
            this._hangmogStartDate = hangmogStartDate;
            this._codeName1 = codeName1;
            this._codeName2 = codeName2;
            this._rowState = rowState;
        }

    }
}