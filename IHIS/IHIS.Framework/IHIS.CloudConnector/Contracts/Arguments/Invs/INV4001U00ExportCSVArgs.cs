using System;
using IHIS.CloudConnector.Contracts.Models.Invs;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Invs
{
    public class INV4001U00ExportCSVArgs : IContractArgs
    {
        private String _startDate;
        private String _endDate;

        public String StartDate
        {
            get { return this._startDate; }
            set { this._startDate = value; }
        }

        public String EndDate
        {
            get { return this._endDate; }
            set { this._endDate = value; }
        }

        public INV4001U00ExportCSVArgs() { }

        public INV4001U00ExportCSVArgs(String startDate, String endDate)
        {
            this._startDate = startDate;
            this._endDate = endDate;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.INV4001U00ExportCSVRequest();
        }
    }
}