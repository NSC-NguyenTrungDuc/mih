using System;
using IHIS.CloudConnector.Contracts.Models.Invs;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Invs
{
    public class INV6000U00GrdINV6001Args : IContractArgs
    {
        private String _hospCode;
        private String _fkinv6000;
        private String _jaeryoCode;
        private String _pageNumber;
        private String _offset;
        private String _difference;

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public String Fkinv6000
        {
            get { return this._fkinv6000; }
            set { this._fkinv6000 = value; }
        }

        public String JaeryoCode
        {
            get { return this._jaeryoCode; }
            set { this._jaeryoCode = value; }
        }

        public String PageNumber
        {
            get { return this._pageNumber; }
            set { this._pageNumber = value; }
        }

        public String Offset
        {
            get { return this._offset; }
            set { this._offset = value; }
        }

        public String Difference
        {
            get { return this._difference; }
            set { this._difference = value; }
        }

        public INV6000U00GrdINV6001Args() { }

        public INV6000U00GrdINV6001Args(String hospCode, String fkinv6000, String jaeryoCode, String pageNumber, String offset, String difference)
        {
            this._hospCode = hospCode;
            this._fkinv6000 = fkinv6000;
            this._jaeryoCode = jaeryoCode;
            this._pageNumber = pageNumber;
            this._offset = offset;
            this._difference = difference;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.INV6000U00GrdINV6001Request();
        }
    }
}