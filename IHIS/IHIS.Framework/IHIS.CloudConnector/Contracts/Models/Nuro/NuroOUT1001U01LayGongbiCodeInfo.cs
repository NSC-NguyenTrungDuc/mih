using System;

namespace IHIS.CloudConnector.Contracts.Models.Nuro
{
    [Serializable]
    public class NuroOUT1001U01LayGongbiCodeInfo
    {
        private String _gongbiCode1;
        private String _gongbiCode2;
        private String _gongbiCode3;
        private String _gongbiCode4;

        public String GongbiCode1
        {
            get { return this._gongbiCode1; }
            set { this._gongbiCode1 = value; }
        }

        public String GongbiCode2
        {
            get { return this._gongbiCode2; }
            set { this._gongbiCode2 = value; }
        }

        public String GongbiCode3
        {
            get { return this._gongbiCode3; }
            set { this._gongbiCode3 = value; }
        }

        public String GongbiCode4
        {
            get { return this._gongbiCode4; }
            set { this._gongbiCode4 = value; }
        }

        public NuroOUT1001U01LayGongbiCodeInfo() { }

        public NuroOUT1001U01LayGongbiCodeInfo(String gongbiCode1, String gongbiCode2, String gongbiCode3, String gongbiCode4)
        {
            this._gongbiCode1 = gongbiCode1;
            this._gongbiCode2 = gongbiCode2;
            this._gongbiCode3 = gongbiCode3;
            this._gongbiCode4 = gongbiCode4;
        }

    }
}
