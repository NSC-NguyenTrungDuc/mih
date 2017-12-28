using System;
using IHIS.CloudConnector.Contracts.Models.OcsEmr;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.OcsEmr
{
    public class OCS2015U31LoadComboDoctorArgs : IContractArgs
    {
        private String _departCode;

        public String DepartCode
        {
            get { return this._departCode; }
            set { this._departCode = value; }
        }

        public OCS2015U31LoadComboDoctorArgs() { }

        public OCS2015U31LoadComboDoctorArgs(String departCode)
        {
            this._departCode = departCode;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OCS2015U31LoadComboDoctorRequest();
        }
    }
}