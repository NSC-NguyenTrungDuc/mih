using System;

namespace IHIS.CloudConnector.Contracts.Models.Xrts
{
    [Serializable]
    public class XRT9001R03Lay9003RListItemInfo
    {
        private String _actingMonth;
        private String _crCntN;
        private String _crCntY;
        private String _drCntN;
        private String _drCntY;
        private String _ctCntN;
        private String _ctCntY;
        private String _mriCntN;
        private String _mriCntY;
        private String _totalCnt;
        private String _zeroValue;

        public String ActingMonth
        {
            get { return this._actingMonth; }
            set { this._actingMonth = value; }
        }

        public String CrCntN
        {
            get { return this._crCntN; }
            set { this._crCntN = value; }
        }

        public String CrCntY
        {
            get { return this._crCntY; }
            set { this._crCntY = value; }
        }

        public String DrCntN
        {
            get { return this._drCntN; }
            set { this._drCntN = value; }
        }

        public String DrCntY
        {
            get { return this._drCntY; }
            set { this._drCntY = value; }
        }

        public String CtCntN
        {
            get { return this._ctCntN; }
            set { this._ctCntN = value; }
        }

        public String CtCntY
        {
            get { return this._ctCntY; }
            set { this._ctCntY = value; }
        }

        public String MriCntN
        {
            get { return this._mriCntN; }
            set { this._mriCntN = value; }
        }

        public String MriCntY
        {
            get { return this._mriCntY; }
            set { this._mriCntY = value; }
        }

        public String TotalCnt
        {
            get { return this._totalCnt; }
            set { this._totalCnt = value; }
        }

        public String ZeroValue
        {
            get { return this._zeroValue; }
            set { this._zeroValue = value; }
        }

        public XRT9001R03Lay9003RListItemInfo() { }

        public XRT9001R03Lay9003RListItemInfo(String actingMonth, String crCntN, String crCntY, String drCntN, String drCntY, String ctCntN, String ctCntY, String mriCntN, String mriCntY, String totalCnt, String zeroValue)
        {
            this._actingMonth = actingMonth;
            this._crCntN = crCntN;
            this._crCntY = crCntY;
            this._drCntN = drCntN;
            this._drCntY = drCntY;
            this._ctCntN = ctCntN;
            this._ctCntY = ctCntY;
            this._mriCntN = mriCntN;
            this._mriCntY = mriCntY;
            this._totalCnt = totalCnt;
            this._zeroValue = zeroValue;
        }

    }
}