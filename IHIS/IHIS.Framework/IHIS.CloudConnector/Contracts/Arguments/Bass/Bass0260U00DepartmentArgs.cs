using System;
using IHIS.CloudConnector.Contracts.Models.Bass;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Bass
{
    public class Bass0260U00DepartmentArgs : IContractArgs
    {
        private String _gwaName;
        private String _buseoGubun;

        public String GwaName
        {
            get { return this._gwaName; }
            set { this._gwaName = value; }
        }

        public String BuseoGubun
        {
            get { return this._buseoGubun; }
            set { this._buseoGubun = value; }
        }

        public Bass0260U00DepartmentArgs() { }

        public Bass0260U00DepartmentArgs(String gwaName, String buseoGubun)
        {
            this._gwaName = gwaName;
            this._buseoGubun = buseoGubun;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.Bass0260U00DepartmentRequest();
        }
    }
}