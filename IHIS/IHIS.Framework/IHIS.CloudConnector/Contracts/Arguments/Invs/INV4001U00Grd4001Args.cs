using System;
using IHIS.CloudConnector.Contracts.Models.Invs;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Invs
{
    public class INV4001U00Grd4001Args : IContractArgs
    {
        private String _fFromDate;
        private String _fToDate;
        private String _fIpgoType;

        public String FFromDate
        {
            get { return this._fFromDate; }
            set { this._fFromDate = value; }
        }

        public String FToDate
        {
            get { return this._fToDate; }
            set { this._fToDate = value; }
        }

        public String FIpgoType
        {
            get { return this._fIpgoType; }
            set { this._fIpgoType = value; }
        }

        public INV4001U00Grd4001Args() { }

        public INV4001U00Grd4001Args(String fFromDate, String fToDate, String fIpgoType)
        {
            this._fFromDate = fFromDate;
            this._fToDate = fToDate;
            this._fIpgoType = fIpgoType;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.INV4001U00Grd4001Request();
        }
    }
}