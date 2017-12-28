using System;

namespace IHIS.CloudConnector.Contracts.Models.Ocsa
{
    [Serializable]
    public class OCS0311U00grdSetHangmogGridFindListInfo
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

        public OCS0311U00grdSetHangmogGridFindListInfo() { }

        public OCS0311U00grdSetHangmogGridFindListInfo(String ordDanui, String codeName, String seq)
        {
            this._ordDanui = ordDanui;
            this._codeName = codeName;
            this._seq = seq;
        }

    }
}