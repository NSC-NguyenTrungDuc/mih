using System;

namespace IHIS.CloudConnector.Contracts.Models.Ocsa
{
    [Serializable]
    public class OCS0311U00laySetHangmogListInfo
    {
        private String _hangmogName;
        private String _ordDanui;
        private String _codeName;

        public String HangmogName
        {
            get { return this._hangmogName; }
            set { this._hangmogName = value; }
        }

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

        public OCS0311U00laySetHangmogListInfo() { }

        public OCS0311U00laySetHangmogListInfo(String hangmogName, String ordDanui, String codeName)
        {
            this._hangmogName = hangmogName;
            this._ordDanui = ordDanui;
            this._codeName = codeName;
        }

    }
}