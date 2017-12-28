using System;
using IHIS.CloudConnector.Contracts.Models.Schs;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Schs
{
    [Serializable]
    public class Schs0201U99CheckORCAEnvInfoResult : AbstractContractResult
    {
        private List<Schs0201U99CheckORCAEnvInfoInfo> _lstData = new List<Schs0201U99CheckORCAEnvInfoInfo>();
        private String _errCode;

        public List<Schs0201U99CheckORCAEnvInfoInfo> LstData
        {
            get { return this._lstData; }
            set { this._lstData = value; }
        }

        public String ErrCode
        {
            get { return this._errCode; }
            set { this._errCode = value; }
        }

        public Schs0201U99CheckORCAEnvInfoResult() { }

    }
}