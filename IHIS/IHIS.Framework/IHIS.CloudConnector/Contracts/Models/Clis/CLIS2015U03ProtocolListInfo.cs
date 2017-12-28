using System;

namespace IHIS.CloudConnector.Contracts.Models.Clis
{
    [Serializable]
    public class CLIS2015U03ProtocolListInfo
    {
        private String _clisProtocolId;
        private String _protocolCode;
        private String _protocolName;

        public String ClisProtocolId
        {
            get { return this._clisProtocolId; }
            set { this._clisProtocolId = value; }
        }

        public String ProtocolCode
        {
            get { return this._protocolCode; }
            set { this._protocolCode = value; }
        }

        public String ProtocolName
        {
            get { return this._protocolName; }
            set { this._protocolName = value; }
        }

        public CLIS2015U03ProtocolListInfo() { }

        public CLIS2015U03ProtocolListInfo(String clisProtocolId, String protocolCode, String protocolName)
        {
            this._clisProtocolId = clisProtocolId;
            this._protocolCode = protocolCode;
            this._protocolName = protocolName;
        }

    }
}