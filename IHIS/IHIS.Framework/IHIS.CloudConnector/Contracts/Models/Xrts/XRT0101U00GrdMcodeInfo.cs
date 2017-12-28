using System;

namespace IHIS.CloudConnector.Contracts.Models.Xrts
{
    [Serializable]
    public class XRT0101U00GrdMcodeInfo
    {
        private String _codeType;
        private String _codeTypeName;

        public String CodeType
        {
            get { return this._codeType; }
            set { this._codeType = value; }
        }

        public String CodeTypeName
        {
            get { return this._codeTypeName; }
            set { this._codeTypeName = value; }
        }

        public XRT0101U00GrdMcodeInfo() { }

        public XRT0101U00GrdMcodeInfo(String codeType, String codeTypeName)
        {
            this._codeType = codeType;
            this._codeTypeName = codeTypeName;
        }

    }
}