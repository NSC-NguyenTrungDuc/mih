using System;
using IHIS.CloudConnector.Contracts.Models.Invs;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Invs
{
    public class INV6002U00GrdINV6002Args : IContractArgs
    {
        private String _gubun;
        private String _hospCode;
        private String _month;
        private String _jaeryoGubun;
        private String _magamMonth;
        private String _pageNumber;
        private String _offset;
        private String _jaeryoCode;

        public String Gubun
        {
            get { return this._gubun; }
            set { this._gubun = value; }
        }

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

        public String MagamMonth
        {
            get { return this._magamMonth; }
            set { this._magamMonth = value; }
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

        public String JaeryoCode
        {
            get { return this._jaeryoCode; }
            set { this._jaeryoCode = value; }
        }

        public INV6002U00GrdINV6002Args() { }

        public INV6002U00GrdINV6002Args(String gubun, String hospCode, String month, String jaeryoGubun, String magamMonth, String pageNumber, String offset, String jaeryoCode)
        {
            this._gubun = gubun;
            this._hospCode = hospCode;
            this._month = month;
            this._jaeryoGubun = jaeryoGubun;
            this._magamMonth = magamMonth;
            this._pageNumber = pageNumber;
            this._offset = offset;
            this._jaeryoCode = jaeryoCode;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.INV6002U00GrdINV6002Request();
        }
    }
}