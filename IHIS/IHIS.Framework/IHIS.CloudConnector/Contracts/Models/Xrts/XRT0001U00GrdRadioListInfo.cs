using System;

namespace IHIS.CloudConnector.Contracts.Models.Xrts
{
    [Serializable]
    public class XRT0001U00GrdRadioListInfo
    {
        private String _xrayCode;
        private String _xrayGubun;
        private String _xrayCodeIdx;
        private String _xrayCodeIdxNm;
        private String _tubeVol;
        private String _tubeCur;
        private String _xrayTime;
        private String _tubeCurTime;
        private String _irradiationTime;
        private String _xrayDistance;

        public String XrayCode
        {
            get { return this._xrayCode; }
            set { this._xrayCode = value; }
        }

        public String XrayGubun
        {
            get { return this._xrayGubun; }
            set { this._xrayGubun = value; }
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

        public XRT0001U00GrdRadioListInfo() { }

        public XRT0001U00GrdRadioListInfo(String xrayCode, String xrayGubun, String xrayCodeIdx, String xrayCodeIdxNm, String tubeVol, String tubeCur, String xrayTime, String tubeCurTime, String irradiationTime, String xrayDistance)
        {
            this._xrayCode = xrayCode;
            this._xrayGubun = xrayGubun;
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