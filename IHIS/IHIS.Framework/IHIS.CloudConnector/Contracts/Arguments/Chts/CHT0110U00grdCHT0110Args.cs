using System;
using IHIS.CloudConnector.Contracts.Models.Chts;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Chts
{
    public class CHT0110U00grdCHT0110Args : IContractArgs
    {
        private String _sangInx;
        private String _pageNumber;
        private String _offset;

        public String SangInx
        {
            get { return this._sangInx; }
            set { this._sangInx = value; }
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

        public CHT0110U00grdCHT0110Args() { }

        public CHT0110U00grdCHT0110Args(String sangInx, String pageNumber, String offset)
        {
            this._sangInx = sangInx;
            this._pageNumber = pageNumber;
            this._offset = offset;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.CHT0110U00grdCHT0110Request();
        }
    }
}