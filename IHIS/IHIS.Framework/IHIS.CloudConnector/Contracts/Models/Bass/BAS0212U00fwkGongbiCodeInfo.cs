using System;

namespace IHIS.CloudConnector.Contracts.Models.Bass
{
    [Serializable]
    public class BAS0212U00fwkGongbiCodeInfo
    {
        private String _gongbiCode;
        private String _gongbiName;

        public String GongbiCode
        {
            get { return this._gongbiCode; }
            set { this._gongbiCode = value; }
        }

        public String GongbiName
        {
            get { return this._gongbiName; }
            set { this._gongbiName = value; }
        }

        public BAS0212U00fwkGongbiCodeInfo() { }

        public BAS0212U00fwkGongbiCodeInfo(String gongbiCode, String gongbiName)
        {
            this._gongbiCode = gongbiCode;
            this._gongbiName = gongbiName;
        }

    }
}