using System;

namespace IHIS.CloudConnector.Contracts.Models.Invs
{
    public class INV2003U00GetCbxChulgoTypeInfo
    {
        private String _code;
        private String _codeName;

        public String Code
        {
            get { return this._code; }
            set { this._code = value; }
        }

        public String CodeName
        {
            get { return this._codeName; }
            set { this._codeName = value; }
        }

        public INV2003U00GetCbxChulgoTypeInfo() { }

        public INV2003U00GetCbxChulgoTypeInfo(String code, String codeName)
        {
            this._code = code;
            this._codeName = codeName;
        }

    }
}