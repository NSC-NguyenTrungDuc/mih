using System;

namespace IHIS.CloudConnector.Contracts.Models.Cpls
{
    [Serializable]
    public class CPL0108U00InitGrdMasterListItemInfo
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

        public CPL0108U00InitGrdMasterListItemInfo() { }

        public CPL0108U00InitGrdMasterListItemInfo(String codeType, String codeTypeName)
        {
            this._codeType = codeType;
            this._codeTypeName = codeTypeName;
        }

    }
}