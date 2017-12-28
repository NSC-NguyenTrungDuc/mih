using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    public class BIL0102U00GetExaminationInfoArgs : IContractArgs
    {
        private String _hospCode;
        private String _pkout1001;

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public String Pkout1001
        {
            get { return this._pkout1001; }
            set { this._pkout1001 = value; }
        }

        public BIL0102U00GetExaminationInfoArgs() { }

        public BIL0102U00GetExaminationInfoArgs(String hospCode, String pkout1001)
        {
            this._hospCode = hospCode;
            this._pkout1001 = pkout1001;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.BIL0102U00GetExaminationInfoRequest();
        }
    }
}