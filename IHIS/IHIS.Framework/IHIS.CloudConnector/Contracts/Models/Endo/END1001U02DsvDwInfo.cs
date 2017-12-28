using System;

namespace IHIS.CloudConnector.Contracts.Models.Endo
{
    [Serializable]
    public class END1001U02DsvDwInfo
    {
        private String _pkpfe1000;
        private String _c3;
        private String _fkocs;
        private String _bunho;
        private String _hangmogCode;
        private String _hangmogName;
        private String _residentYn;

        public String Pkpfe1000
        {
            get { return this._pkpfe1000; }
            set { this._pkpfe1000 = value; }
        }

        public String C3
        {
            get { return this._c3; }
            set { this._c3 = value; }
        }

        public String Fkocs
        {
            get { return this._fkocs; }
            set { this._fkocs = value; }
        }

        public String Bunho
        {
            get { return this._bunho; }
            set { this._bunho = value; }
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

        public String ResidentYn
        {
            get { return this._residentYn; }
            set { this._residentYn = value; }
        }

        public END1001U02DsvDwInfo() { }

        public END1001U02DsvDwInfo(String pkpfe1000, String c3, String fkocs, String bunho, String hangmogCode, String hangmogName, String residentYn)
        {
            this._pkpfe1000 = pkpfe1000;
            this._c3 = c3;
            this._fkocs = fkocs;
            this._bunho = bunho;
            this._hangmogCode = hangmogCode;
            this._hangmogName = hangmogName;
            this._residentYn = residentYn;
        }

    }
}