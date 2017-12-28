using System;
using IHIS.CloudConnector.Contracts.Models.Invs;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Invs
{
    public class INV6000U00LaySummaryDetailArgs : IContractArgs
    {
        private String _hospCode;
        private String _magamMonth;

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public String MagamMonth
        {
            get { return this._magamMonth; }
            set { this._magamMonth = value; }
        }

        public INV6000U00LaySummaryDetailArgs() { }

        public INV6000U00LaySummaryDetailArgs(String hospCode, String magamMonth)
        {
            this._hospCode = hospCode;
            this._magamMonth = magamMonth;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.INV6000U00LaySummaryDetailRequest();
        }
    }
}