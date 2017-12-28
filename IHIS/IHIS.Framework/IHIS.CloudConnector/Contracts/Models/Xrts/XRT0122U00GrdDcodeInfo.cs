using System;

namespace IHIS.CloudConnector.Contracts.Models.Xrts
{
    [Serializable]
    public class XRT0122U00GrdDcodeInfo
    {
        private String _buwiBunryu;
        private String _buwiCode;
        private String _buwiName;
        private String _sortSeq;
        private String _key;

        public String BuwiBunryu
        {
            get { return this._buwiBunryu; }
            set { this._buwiBunryu = value; }
        }

        public String BuwiCode
        {
            get { return this._buwiCode; }
            set { this._buwiCode = value; }
        }

        public String BuwiName
        {
            get { return this._buwiName; }
            set { this._buwiName = value; }
        }

        public String SortSeq
        {
            get { return this._sortSeq; }
            set { this._sortSeq = value; }
        }

        public String Key
        {
            get { return this._key; }
            set { this._key = value; }
        }

        public XRT0122U00GrdDcodeInfo() { }

        public XRT0122U00GrdDcodeInfo(String buwiBunryu, String buwiCode, String buwiName, String sortSeq, String key)
        {
            this._buwiBunryu = buwiBunryu;
            this._buwiCode = buwiCode;
            this._buwiName = buwiName;
            this._sortSeq = sortSeq;
            this._key = key;
        }

    }
}