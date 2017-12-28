using System;

namespace IHIS.CloudConnector.Contracts.Models.Phys
{
    [Serializable]
    public class PHY2001U04CboJubsuGubunInfo
    {
        private String _code;
        private String _codeName;
        private String _sortKey;

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

        public String SortKey
        {
            get { return this._sortKey; }
            set { this._sortKey = value; }
        }

        public PHY2001U04CboJubsuGubunInfo() { }

        public PHY2001U04CboJubsuGubunInfo(String code, String codeName, String sortKey)
        {
            this._code = code;
            this._codeName = codeName;
            this._sortKey = sortKey;
        }

    }
}