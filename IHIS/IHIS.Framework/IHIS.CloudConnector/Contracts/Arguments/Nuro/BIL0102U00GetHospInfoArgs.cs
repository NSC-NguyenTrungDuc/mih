using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    public class BIL0102U00GetHospInfoArgs : IContractArgs
    {
        private String _hospCode;
        private String _startDate;

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

        public BIL0102U00GetHospInfoArgs() { }

        public BIL0102U00GetHospInfoArgs(String hospCode, String startDate)
        {
            this._hospCode = hospCode;
            this._startDate = startDate;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.BIL0102U00GetHospInfoRequest();
        }
    }
}