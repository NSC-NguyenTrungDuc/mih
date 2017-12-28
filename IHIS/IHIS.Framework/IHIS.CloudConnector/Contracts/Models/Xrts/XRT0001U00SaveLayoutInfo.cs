using System;

namespace IHIS.CloudConnector.Contracts.Models.Xrts
{
    [Serializable]
    public class XRT0001U00SaveLayoutInfo
    {
        private String _xrayCode;
        private String _xrayRoom;
        private String _xrayBuwiTong;
        private String _sugaCode;
        private String _xrayRealCnt;
        private String _slipCode;
        private String _sort;
        private String _requestYn;
        private String _tubeVol;
        private String _tubeCurTime;
        private String _xrayName;
        private String _xrayBuwi;
        private String _xrayCnt;
        private String _specialYn;
        private String _reserType;
        private String _xrayWay;
        private String _modality;
        private String _tubeCur;
        private String _irradiationTime;
        private String _xrayGubun;
        private String _xrayBuwiKaikei;
        private String _namePrintYn;
        private String _xrayName2;
        private String _jaeryoYn;
        private String _tongGubun;
        private String _frequentUseYn;
        private String _xrayTime;
        private String _xrayDistance;
        private String _xrayCodeIdx;
        private String _xrayCodeIdxNm;
        private String _rowState;
        private String _callerId;

        public String XrayCode
        {
            get { return this._xrayCode; }
            set { this._xrayCode = value; }
        }

        public String XrayRoom
        {
            get { return this._xrayRoom; }
            set { this._xrayRoom = value; }
        }

        public String XrayBuwiTong
        {
            get { return this._xrayBuwiTong; }
            set { this._xrayBuwiTong = value; }
        }

        public String SugaCode
        {
            get { return this._sugaCode; }
            set { this._sugaCode = value; }
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

        public String Sort
        {
            get { return this._sort; }
            set { this._sort = value; }
        }

        public String RequestYn
        {
            get { return this._requestYn; }
            set { this._requestYn = value; }
        }

        public String TubeVol
        {
            get { return this._tubeVol; }
            set { this._tubeVol = value; }
        }

        public String TubeCurTime
        {
            get { return this._tubeCurTime; }
            set { this._tubeCurTime = value; }
        }

        public String XrayName
        {
            get { return this._xrayName; }
            set { this._xrayName = value; }
        }

        public String XrayBuwi
        {
            get { return this._xrayBuwi; }
            set { this._xrayBuwi = value; }
        }

        public String XrayCnt
        {
            get { return this._xrayCnt; }
            set { this._xrayCnt = value; }
        }

        public String SpecialYn
        {
            get { return this._specialYn; }
            set { this._specialYn = value; }
        }

        public String ReserType
        {
            get { return this._reserType; }
            set { this._reserType = value; }
        }

        public String XrayWay
        {
            get { return this._xrayWay; }
            set { this._xrayWay = value; }
        }

        public String Modality
        {
            get { return this._modality; }
            set { this._modality = value; }
        }

        public String TubeCur
        {
            get { return this._tubeCur; }
            set { this._tubeCur = value; }
        }

        public String IrradiationTime
        {
            get { return this._irradiationTime; }
            set { this._irradiationTime = value; }
        }

        public String XrayGubun
        {
            get { return this._xrayGubun; }
            set { this._xrayGubun = value; }
        }

        public String XrayBuwiKaikei
        {
            get { return this._xrayBuwiKaikei; }
            set { this._xrayBuwiKaikei = value; }
        }

        public String NamePrintYn
        {
            get { return this._namePrintYn; }
            set { this._namePrintYn = value; }
        }

        public String XrayName2
        {
            get { return this._xrayName2; }
            set { this._xrayName2 = value; }
        }

        public String JaeryoYn
        {
            get { return this._jaeryoYn; }
            set { this._jaeryoYn = value; }
        }

        public String TongGubun
        {
            get { return this._tongGubun; }
            set { this._tongGubun = value; }
        }

        public String FrequentUseYn
        {
            get { return this._frequentUseYn; }
            set { this._frequentUseYn = value; }
        }

        public String XrayTime
        {
            get { return this._xrayTime; }
            set { this._xrayTime = value; }
        }

        public String XrayDistance
        {
            get { return this._xrayDistance; }
            set { this._xrayDistance = value; }
        }

        public String XrayCodeIdx
        {
            get { return this._xrayCodeIdx; }
            set { this._xrayCodeIdx = value; }
        }

        public String XrayCodeIdxNm
        {
            get { return this._xrayCodeIdxNm; }
            set { this._xrayCodeIdxNm = value; }
        }

        public String RowState
        {
            get { return this._rowState; }
            set { this._rowState = value; }
        }

        public String CallerId
        {
            get { return this._callerId; }
            set { this._callerId = value; }
        }

        public XRT0001U00SaveLayoutInfo() { }

        public XRT0001U00SaveLayoutInfo(String xrayCode, String xrayRoom, String xrayBuwiTong, String sugaCode, String xrayRealCnt, String slipCode, String sort, String requestYn, String tubeVol, String tubeCurTime, String xrayName, String xrayBuwi, String xrayCnt, String specialYn, String reserType, String xrayWay, String modality, String tubeCur, String irradiationTime, String xrayGubun, String xrayBuwiKaikei, String namePrintYn, String xrayName2, String jaeryoYn, String tongGubun, String frequentUseYn, String xrayTime, String xrayDistance, String xrayCodeIdx, String xrayCodeIdxNm, String rowState, String callerId)
        {
            this._xrayCode = xrayCode;
            this._xrayRoom = xrayRoom;
            this._xrayBuwiTong = xrayBuwiTong;
            this._sugaCode = sugaCode;
            this._xrayRealCnt = xrayRealCnt;
            this._slipCode = slipCode;
            this._sort = sort;
            this._requestYn = requestYn;
            this._tubeVol = tubeVol;
            this._tubeCurTime = tubeCurTime;
            this._xrayName = xrayName;
            this._xrayBuwi = xrayBuwi;
            this._xrayCnt = xrayCnt;
            this._specialYn = specialYn;
            this._reserType = reserType;
            this._xrayWay = xrayWay;
            this._modality = modality;
            this._tubeCur = tubeCur;
            this._irradiationTime = irradiationTime;
            this._xrayGubun = xrayGubun;
            this._xrayBuwiKaikei = xrayBuwiKaikei;
            this._namePrintYn = namePrintYn;
            this._xrayName2 = xrayName2;
            this._jaeryoYn = jaeryoYn;
            this._tongGubun = tongGubun;
            this._frequentUseYn = frequentUseYn;
            this._xrayTime = xrayTime;
            this._xrayDistance = xrayDistance;
            this._xrayCodeIdx = xrayCodeIdx;
            this._xrayCodeIdxNm = xrayCodeIdxNm;
            this._rowState = rowState;
            this._callerId = callerId;
        }

    }
}