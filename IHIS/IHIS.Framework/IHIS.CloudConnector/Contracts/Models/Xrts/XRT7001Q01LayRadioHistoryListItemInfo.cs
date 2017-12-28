using System;

namespace IHIS.CloudConnector.Contracts.Models.Xrts
{
    [Serializable]
    public class XRT7001Q01LayRadioHistoryListItemInfo
    {
        private String _bunho;
        private String _suname;
        private String _gwa;
        private String _doctor;
        private String _orderDate;
        private String _jundalPart;
        private String _xrayCode;
        private String _xrayName;
        private String _xrayCodeIdx;
        private String _xrayCodeIdxNm;
        private String _tubeVol;
        private String _tubeCur;
        private String _xrayTime;
        private String _tubeCurTime;
        private String _irradiationTime;
        private String _xrayDistance;

        public String Bunho
        {
            get { return this._bunho; }
            set { this._bunho = value; }
        }

        public String Suname
        {
            get { return this._suname; }
            set { this._suname = value; }
        }

        public String Gwa
        {
            get { return this._gwa; }
            set { this._gwa = value; }
        }

        public String Doctor
        {
            get { return this._doctor; }
            set { this._doctor = value; }
        }

        public String OrderDate
        {
            get { return this._orderDate; }
            set { this._orderDate = value; }
        }

        public String JundalPart
        {
            get { return this._jundalPart; }
            set { this._jundalPart = value; }
        }

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

        public String TubeVol
        {
            get { return this._tubeVol; }
            set { this._tubeVol = value; }
        }

        public String TubeCur
        {
            get { return this._tubeCur; }
            set { this._tubeCur = value; }
        }

        public String XrayTime
        {
            get { return this._xrayTime; }
            set { this._xrayTime = value; }
        }

        public String TubeCurTime
        {
            get { return this._tubeCurTime; }
            set { this._tubeCurTime = value; }
        }

        public String IrradiationTime
        {
            get { return this._irradiationTime; }
            set { this._irradiationTime = value; }
        }

        public String XrayDistance
        {
            get { return this._xrayDistance; }
            set { this._xrayDistance = value; }
        }

        public XRT7001Q01LayRadioHistoryListItemInfo() { }

        public XRT7001Q01LayRadioHistoryListItemInfo(String bunho, String suname, String gwa, String doctor, String orderDate, String jundalPart, String xrayCode, String xrayName, String xrayCodeIdx, String xrayCodeIdxNm, String tubeVol, String tubeCur, String xrayTime, String tubeCurTime, String irradiationTime, String xrayDistance)
        {
            this._bunho = bunho;
            this._suname = suname;
            this._gwa = gwa;
            this._doctor = doctor;
            this._orderDate = orderDate;
            this._jundalPart = jundalPart;
            this._xrayCode = xrayCode;
            this._xrayName = xrayName;
            this._xrayCodeIdx = xrayCodeIdx;
            this._xrayCodeIdxNm = xrayCodeIdxNm;
            this._tubeVol = tubeVol;
            this._tubeCur = tubeCur;
            this._xrayTime = xrayTime;
            this._tubeCurTime = tubeCurTime;
            this._irradiationTime = irradiationTime;
            this._xrayDistance = xrayDistance;
        }

    }
}