using System;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{
    public class Ocs0103Q00LoadOcs0103Args : IContractArgs
    {
        private String _queryCode;
        private String _orderGubun;
        private String _childYn;
        private String _inputTab;
        private String _pageNumber;
        private String _offSet;

        public String QueryCode
        {
            get { return this._queryCode; }
            set { this._queryCode = value; }
        }

        public String OrderGubun
        {
            get { return this._orderGubun; }
            set { this._orderGubun = value; }
        }

        public String ChildYn
        {
            get { return this._childYn; }
            set { this._childYn = value; }
        }

        public String InputTab
        {
            get { return this._inputTab; }
            set { this._inputTab = value; }
        }

        public String PageNumber
        {
            get { return this._pageNumber; }
            set { this._pageNumber = value; }
        }

        public String OffSet
        {
            get { return this._offSet; }
            set { this._offSet = value; }
        }

        public Ocs0103Q00LoadOcs0103Args() { }

        public Ocs0103Q00LoadOcs0103Args(String queryCode, String orderGubun, String childYn, String inputTab, String pageNumber, String offSet)
        {
            this._queryCode = queryCode;
            this._orderGubun = orderGubun;
            this._childYn = childYn;
            this._inputTab = inputTab;
            this._pageNumber = pageNumber;
            this._offSet = offSet;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.Ocs0103Q00LoadOcs0103Request();
        }
    }
}