using System;

namespace IHIS.CloudConnector.Contracts.Models.Nuro
{
    [Serializable]
    public class ORDERTRANSLayCommonInfo
    {
        private String _gubunName;
        private String _ifValidYn;
        private String _gongbiYn;

        public String GubunName
        {
            get { return this._gubunName; }
            set { this._gubunName = value; }
        }

        public String IfValidYn
        {
            get { return this._ifValidYn; }
            set { this._ifValidYn = value; }
        }

        public String GongbiYn
        {
            get { return this._gongbiYn; }
            set { this._gongbiYn = value; }
        }

        public ORDERTRANSLayCommonInfo() { }

        public ORDERTRANSLayCommonInfo(String gubunName, String ifValidYn, String gongbiYn)
        {
            this._gubunName = gubunName;
            this._ifValidYn = ifValidYn;
            this._gongbiYn = gongbiYn;
        }

    }
}