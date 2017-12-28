using System;

namespace IHIS.CloudConnector.Contracts.Models.Cpls
{
    [Serializable]
    public class CPL2010U00GrdTubeListItemInfo
    {
        private String _tubeCode;
        private String _tubeName;
        private String _cnt;

        public String TubeCode
        {
            get { return this._tubeCode; }
            set { this._tubeCode = value; }
        }

        public String TubeName
        {
            get { return this._tubeName; }
            set { this._tubeName = value; }
        }

        public String Cnt
        {
            get { return this._cnt; }
            set { this._cnt = value; }
        }

        public CPL2010U00GrdTubeListItemInfo() { }

        public CPL2010U00GrdTubeListItemInfo(String tubeCode, String tubeName, String cnt)
        {
            this._tubeCode = tubeCode;
            this._tubeName = tubeName;
            this._cnt = cnt;
        }

    }
}