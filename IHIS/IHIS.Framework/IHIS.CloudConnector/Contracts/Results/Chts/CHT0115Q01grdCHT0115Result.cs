using System;
using IHIS.CloudConnector.Contracts.Models.Chts;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Chts
{
    [Serializable]
    public class CHT0115Q01grdCHT0115Result : AbstractContractResult
    {
        private List<CHT0115Q01grdCHT0115Info> _listGrdInfo = new List<CHT0115Q01grdCHT0115Info>();

        public List<CHT0115Q01grdCHT0115Info> ListGrdInfo
        {
            get { return this._listGrdInfo; }
            set { this._listGrdInfo = value; }
        }

        public CHT0115Q01grdCHT0115Result() { }

    }
}