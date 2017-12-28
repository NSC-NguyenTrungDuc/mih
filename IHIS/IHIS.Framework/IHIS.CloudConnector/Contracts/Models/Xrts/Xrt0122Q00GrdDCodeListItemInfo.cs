using System;

namespace IHIS.CloudConnector.Contracts.Models.Xrts
{
    [Serializable]
    public class Xrt0122Q00GrdDCodeListItemInfo
    {
        private String _bunryu;
        private String _code;
        private String _name;
        private String _seq;
        private String _key;

        public String Bunryu
        {
            get { return this._bunryu; }
            set { this._bunryu = value; }
        }

        public String Code
        {
            get { return this._code; }
            set { this._code = value; }
        }

        public String Name
        {
            get { return this._name; }
            set { this._name = value; }
        }

        public String Seq
        {
            get { return this._seq; }
            set { this._seq = value; }
        }

        public String Key
        {
            get { return this._key; }
            set { this._key = value; }
        }

        public Xrt0122Q00GrdDCodeListItemInfo() { }

        public Xrt0122Q00GrdDCodeListItemInfo(String bunryu, String code, String name, String seq, String key)
        {
            this._bunryu = bunryu;
            this._code = code;
            this._name = name;
            this._seq = seq;
            this._key = key;
        }

    }
}