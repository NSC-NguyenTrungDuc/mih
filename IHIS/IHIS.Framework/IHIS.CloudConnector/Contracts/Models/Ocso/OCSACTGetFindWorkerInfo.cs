using System;

namespace IHIS.CloudConnector.Contracts.Models.Ocso
{
    [Serializable]
    public class OCSACTGetFindWorkerInfo
    {
        private String _ordDanui;
        private String _codeName;
        private String _seq;

        public String OrdDanui
        {
            get { return this._ordDanui; }
            set { this._ordDanui = value; }
        }

        public String CodeName
        {
            get { return this._codeName; }
            set { this._codeName = value; }
        }

        public String Seq
        {
            get { return this._seq; }
            set { this._seq = value; }
        }

        public OCSACTGetFindWorkerInfo() { }

        public OCSACTGetFindWorkerInfo(String ordDanui, String codeName, String seq)
        {
            this._ordDanui = ordDanui;
            this._codeName = codeName;
            this._seq = seq;
        }

    }
}