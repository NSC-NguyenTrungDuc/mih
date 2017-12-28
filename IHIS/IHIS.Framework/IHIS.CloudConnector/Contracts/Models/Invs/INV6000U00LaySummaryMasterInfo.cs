using System;

namespace IHIS.CloudConnector.Contracts.Models.Invs
{
    public class INV6000U00LaySummaryMasterInfo
    {
        private String _slipCode;
        private String _slipName;
        private String _drgCount;
        private String _sougaku;
        private String _magamDate;
        private String _magamMonthJp;

        public String SlipCode
        {
            get { return this._slipCode; }
            set { this._slipCode = value; }
        }

        public String SlipName
        {
            get { return this._slipName; }
            set { this._slipName = value; }
        }

        public String DrgCount
        {
            get { return this._drgCount; }
            set { this._drgCount = value; }
        }

        public String Sougaku
        {
            get { return this._sougaku; }
            set { this._sougaku = value; }
        }

        public String MagamDate
        {
            get { return this._magamDate; }
            set { this._magamDate = value; }
        }

        public String MagamMonthJp
        {
            get { return this._magamMonthJp; }
            set { this._magamMonthJp = value; }
        }

        public INV6000U00LaySummaryMasterInfo() { }

        public INV6000U00LaySummaryMasterInfo(String slipCode, String slipName, String drgCount, String sougaku, String magamDate, String magamMonthJp)
        {
            this._slipCode = slipCode;
            this._slipName = slipName;
            this._drgCount = drgCount;
            this._sougaku = sougaku;
            this._magamDate = magamDate;
            this._magamMonthJp = magamMonthJp;
        }

    }
}