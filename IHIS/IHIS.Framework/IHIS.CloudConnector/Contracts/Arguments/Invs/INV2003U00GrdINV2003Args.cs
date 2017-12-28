using System;
using IHIS.CloudConnector.Contracts.Models.Invs;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Invs
{
    public class INV2003U00GrdINV2003Args : IContractArgs
    {
        private String _hospCode;
        private String _fromDate;
        private String _toDate;
        private String _chulgoType;

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
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

        public String ChulgoType
        {
            get { return this._chulgoType; }
            set { this._chulgoType = value; }
        }

        public INV2003U00GrdINV2003Args() { }

        public INV2003U00GrdINV2003Args(String hospCode, String fromDate, String toDate, String chulgoType)
        {
            this._hospCode = hospCode;
            this._fromDate = fromDate;
            this._toDate = toDate;
            this._chulgoType = chulgoType;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.INV2003U00GrdINV2003Request();
        }
    }
}