using System;
using IHIS.CloudConnector.Contracts.Models.Invs;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Invs
{
    public class INV6002U00GrdINV6002BeforeArgs : IContractArgs
    {
        private String _hospCode;
        private String _month;
        private String _jaeryoGubun;
        private String _pageNumber;
        private String _offset;

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public String Month
        {
            get { return this._month; }
            set { this._month = value; }
        }

        public String JaeryoGubun
        {
            get { return this._jaeryoGubun; }
            set { this._jaeryoGubun = value; }
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

        public INV6002U00GrdINV6002BeforeArgs() { }

        public INV6002U00GrdINV6002BeforeArgs(String hospCode, String month, String jaeryoGubun, String pageNumber, String offset)
        {
            this._hospCode = hospCode;
            this._month = month;
            this._jaeryoGubun = jaeryoGubun;
            this._pageNumber = pageNumber;
            this._offset = offset;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.INV6002U00GrdINV6002BeforeRequest();
        }
    }
}