using System;
using IHIS.CloudConnector.Contracts.Models.Invs;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Invs
{
    public class INV4001U00DrugUserResult : AbstractContractResult
    {
        private List<INV4001U00DrugUserInfo> _lst = new List<INV4001U00DrugUserInfo>();

        public List<INV4001U00DrugUserInfo> Lst
        {
            get { return this._lst; }
            set { this._lst = value; }
        }

        public INV4001U00DrugUserResult() { }

    }
}