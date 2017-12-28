using System;
using IHIS.CloudConnector.Contracts.Models.Invs;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Invs
{
    public class INV2003U00ExportCSVArgs : IContractArgs
    {
        private String _hospCode;
        private String _startDate;
        private String _endDate;

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

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

        public INV2003U00ExportCSVArgs() { }

        public INV2003U00ExportCSVArgs(String hospCode, String startDate, String endDate)
        {
            this._hospCode = hospCode;
            this._startDate = startDate;
            this._endDate = endDate;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.INV2003U00ExportCSVRequest();
        }
    }
}