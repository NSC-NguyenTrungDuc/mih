using System;

namespace IHIS.CloudConnector.Contracts.Models.Nuro
{
    [Serializable]
    public class NuroOUT1001U01GetTypeInfo
    {
        private String _gubun;
        private String _gubunName;
        private String _lastCheckDate;
        private String _gongbiYn;

        public String Gubun
        {
            get { return this._gubun; }
            set { this._gubun = value; }
        }

        public String GubunName
        {
            get { return this._gubunName; }
            set { this._gubunName = value; }
        }

        public String LastCheckDate
        {
            get { return this._lastCheckDate; }
            set { this._lastCheckDate = value; }
        }

        public String GongbiYn
        {
            get { return this._gongbiYn; }
            set { this._gongbiYn = value; }
        }

        public NuroOUT1001U01GetTypeInfo() { }

        public NuroOUT1001U01GetTypeInfo(String gubun, String gubunName, String lastCheckDate, String gongbiYn)
        {
            this._gubun = gubun;
            this._gubunName = gubunName;
            this._lastCheckDate = lastCheckDate;
            this._gongbiYn = gongbiYn;
        }

    }
}