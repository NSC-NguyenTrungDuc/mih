using System;
using IHIS.CloudConnector.Contracts.Models.Invs;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Invs
{
    public class LoadINV0110Q00Result : AbstractContractResult
    {
        private List<LoadINV0110Q00Info> _listItem = new List<LoadINV0110Q00Info>();

        public List<LoadINV0110Q00Info> ListItem
        {
            get { return this._listItem; }
            set { this._listItem = value; }
        }

        public LoadINV0110Q00Result() { }

    }
}