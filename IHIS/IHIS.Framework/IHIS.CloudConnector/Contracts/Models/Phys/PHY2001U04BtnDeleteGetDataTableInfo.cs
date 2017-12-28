using System;

namespace IHIS.CloudConnector.Contracts.Models.Phys
{
    [Serializable]
    public class PHY2001U04BtnDeleteGetDataTableInfo
    {
        private String _pkout1001;
        private String _pkocs1003;
        private String _hangmogCode;
        private String _sinryouryouGubun;
        private String _sunabDate;

        public String Pkout1001
        {
            get { return this._pkout1001; }
            set { this._pkout1001 = value; }
        }

        public String Pkocs1003
        {
            get { return this._pkocs1003; }
            set { this._pkocs1003 = value; }
        }

        public String HangmogCode
        {
            get { return this._hangmogCode; }
            set { this._hangmogCode = value; }
        }

        public String SinryouryouGubun
        {
            get { return this._sinryouryouGubun; }
            set { this._sinryouryouGubun = value; }
        }

        public String SunabDate
        {
            get { return this._sunabDate; }
            set { this._sunabDate = value; }
        }

        public PHY2001U04BtnDeleteGetDataTableInfo() { }

        public PHY2001U04BtnDeleteGetDataTableInfo(String pkout1001, String pkocs1003, String hangmogCode, String sinryouryouGubun, String sunabDate)
        {
            this._pkout1001 = pkout1001;
            this._pkocs1003 = pkocs1003;
            this._hangmogCode = hangmogCode;
            this._sinryouryouGubun = sinryouryouGubun;
            this._sunabDate = sunabDate;
        }

    }
}