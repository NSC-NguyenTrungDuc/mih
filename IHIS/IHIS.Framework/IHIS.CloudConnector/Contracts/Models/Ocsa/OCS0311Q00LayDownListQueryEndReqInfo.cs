using System;

namespace IHIS.CloudConnector.Contracts.Models.Ocsa
{
    [Serializable]
    public class OCS0311Q00LayDownListQueryEndReqInfo
    {
        private String _bulyongYn;
        private String _setHangmogCode;

        public String BulyongYn
        {
            get { return this._bulyongYn; }
            set { this._bulyongYn = value; }
        }

        public String SetHangmogCode
        {
            get { return this._setHangmogCode; }
            set { this._setHangmogCode = value; }
        }

        public OCS0311Q00LayDownListQueryEndReqInfo() { }

        public OCS0311Q00LayDownListQueryEndReqInfo(String bulyongYn, String setHangmogCode)
        {
            this._bulyongYn = bulyongYn;
            this._setHangmogCode = setHangmogCode;
        }

    }
}