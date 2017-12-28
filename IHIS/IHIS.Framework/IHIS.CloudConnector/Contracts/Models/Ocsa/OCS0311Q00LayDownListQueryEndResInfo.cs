using System;

namespace IHIS.CloudConnector.Contracts.Models.Ocsa
{
    [Serializable]
    public class OCS0311Q00LayDownListQueryEndResInfo
    {
        private String _hangmogName;
        private String _ordDanui;
        private String _ordDanuiName;
        private String _slipName;
        private String _bulyongYn;
        private String _rowIdx;

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

        public String OrdDanuiName
        {
            get { return this._ordDanuiName; }
            set { this._ordDanuiName = value; }
        }

        public String SlipName
        {
            get { return this._slipName; }
            set { this._slipName = value; }
        }

        public String BulyongYn
        {
            get { return this._bulyongYn; }
            set { this._bulyongYn = value; }
        }

        public String RowIdx
        {
            get { return this._rowIdx; }
            set { this._rowIdx = value; }
        }

        public OCS0311Q00LayDownListQueryEndResInfo() { }

        public OCS0311Q00LayDownListQueryEndResInfo(String hangmogName, String ordDanui, String ordDanuiName, String slipName, String bulyongYn, String rowIdx)
        {
            this._hangmogName = hangmogName;
            this._ordDanui = ordDanui;
            this._ordDanuiName = ordDanuiName;
            this._slipName = slipName;
            this._bulyongYn = bulyongYn;
            this._rowIdx = rowIdx;
        }

    }
}