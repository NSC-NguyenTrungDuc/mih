using System;
using IHIS.CloudConnector.Contracts.Models.Bill;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Bill
{
    public class BIL2016R01FbxExeDoctorArgs : IContractArgs
    {
        private String _gwa;

        public String Gwa
        {
            get { return this._gwa; }
            set { this._gwa = value; }
        }

        public BIL2016R01FbxExeDoctorArgs() { }

        public BIL2016R01FbxExeDoctorArgs(String gwa)
        {
            this._gwa = gwa;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.BIL2016R01FbxExeDoctorRequest();
        }
    }
}