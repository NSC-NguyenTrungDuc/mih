using System;

namespace IHIS.CloudConnector.Contracts.Models.Bass
{
    [Serializable]
    public class BAS0101U00PrBasGridColumnChangedItemInfo
    {
        private String _dupYn;
        private String _error;

        public String DupYn
        {
            get { return this._dupYn; }
            set { this._dupYn = value; }
        }

        public String Error
        {
            get { return this._error; }
            set { this._error = value; }
        }

        public BAS0101U00PrBasGridColumnChangedItemInfo() { }

        public BAS0101U00PrBasGridColumnChangedItemInfo(String dupYn, String error)
        {
            this._dupYn = dupYn;
            this._error = error;
        }

    }
}