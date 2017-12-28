using System;
using IHIS.CloudConnector.Contracts.Models.Bill;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Bill
{
    public class BIL2016U00GrdMasterArgs : IContractArgs
    {
        private String _hangmogNameInx;
        private String _orderGubun;
        private String _hospCode;
        private String _codeType;
        private String _language;
        private String _pageNumber;
        private String _offset;

        public String HangmogNameInx
        {
            get { return this._hangmogNameInx; }
            set { this._hangmogNameInx = value; }
        }

        public String OrderGubun
        {
            get { return this._orderGubun; }
            set { this._orderGubun = value; }
        }

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public String CodeType
        {
            get { return this._codeType; }
            set { this._codeType = value; }
        }

        public String Language
        {
            get { return this._language; }
            set { this._language = value; }
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

        public BIL2016U00GrdMasterArgs() { }

        public BIL2016U00GrdMasterArgs(String hangmogNameInx, String orderGubun, String hospCode, String codeType, String language, String pageNumber, String offset)
        {
            this._hangmogNameInx = hangmogNameInx;
            this._orderGubun = orderGubun;
            this._hospCode = hospCode;
            this._codeType = codeType;
            this._language = language;
            this._pageNumber = pageNumber;
            this._offset = offset;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.BIL2016U00GrdMasterRequest();
        }
    }
}