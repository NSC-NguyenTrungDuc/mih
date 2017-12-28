using System;
using IHIS.CloudConnector.Contracts.Models.Invs;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Invs
{
    public class LoadINV0110Q00Args : IContractArgs
    {
        private String _jaeryoNameInx;
        private String _pageNumber;
        private String _offSet;

        public String JaeryoNameInx
        {
            get { return this._jaeryoNameInx; }
            set { this._jaeryoNameInx = value; }
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

        public LoadINV0110Q00Args() { }

        public LoadINV0110Q00Args(String jaeryoNameInx, String pageNumber, String offSet)
        {
            this._jaeryoNameInx = jaeryoNameInx;
            this._pageNumber = pageNumber;
            this._offSet = offSet;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.LoadINV0110Q00Request();
        }
    }
}