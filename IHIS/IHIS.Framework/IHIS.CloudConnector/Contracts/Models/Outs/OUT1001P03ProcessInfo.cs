using System;

namespace IHIS.CloudConnector.Contracts.Models.Outs
{
    [Serializable]
    public class OUT1001P03ProcessInfo
    {
        private String _pkKey;
        private String _ioGubun;

        public String PkKey
        {
            get { return this._pkKey; }
            set { this._pkKey = value; }
        }

        public String IoGubun
        {
            get { return this._ioGubun; }
            set { this._ioGubun = value; }
        }

        public OUT1001P03ProcessInfo() { }

        public OUT1001P03ProcessInfo(String pkKey, String ioGubun)
        {
            this._pkKey = pkKey;
            this._ioGubun = ioGubun;
        }

    }
}