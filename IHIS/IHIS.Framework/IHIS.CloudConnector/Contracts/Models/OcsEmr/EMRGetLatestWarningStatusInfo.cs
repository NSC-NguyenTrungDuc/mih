using System;

namespace IHIS.CloudConnector.Contracts.Models.OcsEmr
{
    [Serializable]
    public class EMRGetLatestWarningStatusInfo
    {
        private String _clisProtocolId;
        private String _statusId;
        private String _codeName;
        private String _updated;
        private String _displayFlg;

        public String ClisProtocolId
        {
            get { return this._clisProtocolId; }
            set { this._clisProtocolId = value; }
        }

        public String StatusId
        {
            get { return this._statusId; }
            set { this._statusId = value; }
        }

        public String CodeName
        {
            get { return this._codeName; }
            set { this._codeName = value; }
        }

        public String Updated
        {
            get { return this._updated; }
            set { this._updated = value; }
        }

        public String DisplayFlg
        {
            get { return this._displayFlg; }
            set { this._displayFlg = value; }
        }

        public EMRGetLatestWarningStatusInfo() { }

        public EMRGetLatestWarningStatusInfo(String clisProtocolId, String statusId, String codeName, String updated, String displayFlg)
        {
            this._clisProtocolId = clisProtocolId;
            this._statusId = statusId;
            this._codeName = codeName;
            this._updated = updated;
            this._displayFlg = displayFlg;
        }

    }
}