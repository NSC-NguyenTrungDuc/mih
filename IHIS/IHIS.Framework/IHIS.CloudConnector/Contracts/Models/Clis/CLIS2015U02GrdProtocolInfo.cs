using System;

namespace IHIS.CloudConnector.Contracts.Models.Clis
{
    [Serializable]
    public class CLIS2015U02GrdProtocolInfo
    {
        private String _protocolId;
        private String _protocolCode;
        private String _protocolName;
        private String _fromDate;
        private String _toDate;
        private String _protocolStatus;
        private String _description;
        private String _resource;
        private String _rowState;

        public String ProtocolId
        {
            get { return this._protocolId; }
            set { this._protocolId = value; }
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

        public String FromDate
        {
            get { return this._fromDate; }
            set { this._fromDate = value; }
        }

        public String ToDate
        {
            get { return this._toDate; }
            set { this._toDate = value; }
        }

        public String ProtocolStatus
        {
            get { return this._protocolStatus; }
            set { this._protocolStatus = value; }
        }

        public String Description
        {
            get { return this._description; }
            set { this._description = value; }
        }

        public String Resource
        {
            get { return this._resource; }
            set { this._resource = value; }
        }

        public String RowState
        {
            get { return this._rowState; }
            set { this._rowState = value; }
        }

        public CLIS2015U02GrdProtocolInfo() { }

        public CLIS2015U02GrdProtocolInfo(String protocolId, String protocolCode, String protocolName, String fromDate, String toDate, String protocolStatus, String description, String resource, String rowState)
        {
            this._protocolId = protocolId;
            this._protocolCode = protocolCode;
            this._protocolName = protocolName;
            this._fromDate = fromDate;
            this._toDate = toDate;
            this._protocolStatus = protocolStatus;
            this._description = description;
            this._resource = resource;
            this._rowState = rowState;
        }

    }
}