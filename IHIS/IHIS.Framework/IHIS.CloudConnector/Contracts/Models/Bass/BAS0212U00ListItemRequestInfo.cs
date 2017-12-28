using System;

namespace IHIS.CloudConnector.Contracts.Models.Bass
{
    [Serializable]
    public class BAS0212U00ListItemRequestInfo
    {
        private String _gongbiName;

        public String GongbiName
        {
            get { return this._gongbiName; }
            set { this._gongbiName = value; }
        }

        public BAS0212U00ListItemRequestInfo() { }

        public BAS0212U00ListItemRequestInfo(String gongbiName)
        {
            this._gongbiName = gongbiName;
        }

    }
}