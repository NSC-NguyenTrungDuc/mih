using System;

namespace IHIS.CloudConnector.Contracts.Models.Xrts
{
    [Serializable]
    public class XRT0001U00GrdXRTInfo
    {
        private String _xrayCode;
        private String _xrayName;
        private String _xrayGubun;
        private String _xrayRoom;
        private String _xrayBuwi;
        private String _xrayBuwiKaikei;
        private String _xrayBuwiTong;
        private String _xrayCnt;
        private String _namePrintYn;
        private String _sugaCode;
        private String _specialYn;
        private String _xrayRealCnt;
        private String _slipCode;
        private String _reserType;
        private String _gubunName;
        private String _roomName;
        private String _buwiName;
        private String _buwiKaikeiName;
        private String _buwiTongName;
        private String _reserTypeName;
        private String _jaeryoYn;
        private String _sort;
        private String _xrayWay;
        private String _frequentUseYn;
        private String _modality;
        private String _modalityName;
        private String _lpad;
        private String _xrayName2;
        private String _tongGubun;
        private String _requestYn;

        public String XrayCode
        {
            get { return this._xrayCode; }
            set { this._xrayCode = value; }
        }

        public String XrayName
        {
            get { return this._xrayName; }
            set { this._xrayName = value; }
        }

        public String XrayGubun
        {
            get { return this._xrayGubun; }
            set { this._xrayGubun = value; }
        }

        public String XrayRoom
        {
            get { return this._xrayRoom; }
            set { this._xrayRoom = value; }
        }

        public String XrayBuwi
        {
            get { return this._xrayBuwi; }
            set { this._xrayBuwi = value; }
        }

        public String XrayBuwiKaikei
        {
            get { return this._xrayBuwiKaikei; }
            set { this._xrayBuwiKaikei = value; }
        }

        public String XrayBuwiTong
        {
            get { return this._xrayBuwiTong; }
            set { this._xrayBuwiTong = value; }
        }

        public String XrayCnt
        {
            get { return this._xrayCnt; }
            set { this._xrayCnt = value; }
        }

        public String NamePrintYn
        {
            get { return this._namePrintYn; }
            set { this._namePrintYn = value; }
        }

        public String SugaCode
        {
            get { return this._sugaCode; }
            set { this._sugaCode = value; }
        }

        public String SpecialYn
        {
            get { return this._specialYn; }
            set { this._specialYn = value; }
        }

        public String XrayRealCnt
        {
            get { return this._xrayRealCnt; }
            set { this._xrayRealCnt = value; }
        }

        public String SlipCode
        {
            get { return this._slipCode; }
            set { this._slipCode = value; }
        }

        public String ReserType
        {
            get { return this._reserType; }
            set { this._reserType = value; }
        }

        public String GubunName
        {
            get { return this._gubunName; }
            set { this._gubunName = value; }
        }

        public String RoomName
        {
            get { return this._roomName; }
            set { this._roomName = value; }
        }

        public String BuwiName
        {
            get { return this._buwiName; }
            set { this._buwiName = value; }
        }

        public String BuwiKaikeiName
        {
            get { return this._buwiKaikeiName; }
            set { this._buwiKaikeiName = value; }
        }

        public String BuwiTongName
        {
            get { return this._buwiTongName; }
            set { this._buwiTongName = value; }
        }

        public String ReserTypeName
        {
            get { return this._reserTypeName; }
            set { this._reserTypeName = value; }
        }

        public String JaeryoYn
        {
            get { return this._jaeryoYn; }
            set { this._jaeryoYn = value; }
        }

        public String Sort
        {
            get { return this._sort; }
            set { this._sort = value; }
        }

        public String XrayWay
        {
            get { return this._xrayWay; }
            set { this._xrayWay = value; }
        }

        public String FrequentUseYn
        {
            get { return this._frequentUseYn; }
            set { this._frequentUseYn = value; }
        }

        public String Modality
        {
            get { return this._modality; }
            set { this._modality = value; }
        }

        public String ModalityName
        {
            get { return this._modalityName; }
            set { this._modalityName = value; }
        }

        public String Lpad
        {
            get { return this._lpad; }
            set { this._lpad = value; }
        }

        public String XrayName2
        {
            get { return this._xrayName2; }
            set { this._xrayName2 = value; }
        }

        public String TongGubun
        {
            get { return this._tongGubun; }
            set { this._tongGubun = value; }
        }

        public String RequestYn
        {
            get { return this._requestYn; }
            set { this._requestYn = value; }
        }

        public XRT0001U00GrdXRTInfo() { }

        public XRT0001U00GrdXRTInfo(String xrayCode, String xrayName, String xrayGubun, String xrayRoom, String xrayBuwi, String xrayBuwiKaikei, String xrayBuwiTong, String xrayCnt, String namePrintYn, String sugaCode, String specialYn, String xrayRealCnt, String slipCode, String reserType, String gubunName, String roomName, String buwiName, String buwiKaikeiName, String buwiTongName, String reserTypeName, String jaeryoYn, String sort, String xrayWay, String frequentUseYn, String modality, String modalityName, String lpad, String xrayName2, String tongGubun, String requestYn)
        {
            this._xrayCode = xrayCode;
            this._xrayName = xrayName;
            this._xrayGubun = xrayGubun;
            this._xrayRoom = xrayRoom;
            this._xrayBuwi = xrayBuwi;
            this._xrayBuwiKaikei = xrayBuwiKaikei;
            this._xrayBuwiTong = xrayBuwiTong;
            this._xrayCnt = xrayCnt;
            this._namePrintYn = namePrintYn;
            this._sugaCode = sugaCode;
            this._specialYn = specialYn;
            this._xrayRealCnt = xrayRealCnt;
            this._slipCode = slipCode;
            this._reserType = reserType;
            this._gubunName = gubunName;
            this._roomName = roomName;
            this._buwiName = buwiName;
            this._buwiKaikeiName = buwiKaikeiName;
            this._buwiTongName = buwiTongName;
            this._reserTypeName = reserTypeName;
            this._jaeryoYn = jaeryoYn;
            this._sort = sort;
            this._xrayWay = xrayWay;
            this._frequentUseYn = frequentUseYn;
            this._modality = modality;
            this._modalityName = modalityName;
            this._lpad = lpad;
            this._xrayName2 = xrayName2;
            this._tongGubun = tongGubun;
            this._requestYn = requestYn;
        }

    }
}