using System;

namespace IHIS.CloudConnector.Contracts.Models.Xrts
{
    [Serializable]
    public class XRT0122U00GrdMcodeInfo
    {
        private String _buwiBunryu;
        private String _buwiBunryuName;

        public String BuwiBunryu
        {
            get { return this._buwiBunryu; }
            set { this._buwiBunryu = value; }
        }

        public String BuwiBunryuName
        {
            get { return this._buwiBunryuName; }
            set { this._buwiBunryuName = value; }
        }

        public XRT0122U00GrdMcodeInfo() { }

        public XRT0122U00GrdMcodeInfo(String buwiBunryu, String buwiBunryuName)
        {
            this._buwiBunryu = buwiBunryu;
            this._buwiBunryuName = buwiBunryuName;
        }

    }
}