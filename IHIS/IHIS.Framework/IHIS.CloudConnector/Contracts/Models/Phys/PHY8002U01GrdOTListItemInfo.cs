using System;

namespace IHIS.CloudConnector.Contracts.Models.Phys
{
    [Serializable]
    public class PHY8002U01GrdOTListItemInfo
    {
        private String _selected;
        private String _code;
        private String _codeName;

        public String Selected
        {
            get { return this._selected; }
            set { this._selected = value; }
        }

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

        public PHY8002U01GrdOTListItemInfo() { }

        public PHY8002U01GrdOTListItemInfo(String selected, String code, String codeName)
        {
            this._selected = selected;
            this._code = code;
            this._codeName = codeName;
        }

    }
}