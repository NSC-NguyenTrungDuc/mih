using System;
using IHIS.CloudConnector.Contracts.Models.Bass;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Bass
{
    public class LoadGrdBAS0260U01Result : AbstractContractResult
    {
        private List<LoadGrdBAS0260U01Info> _listInfo = new List<LoadGrdBAS0260U01Info>();

        public List<LoadGrdBAS0260U01Info> ListInfo
        {
            get { return this._listInfo; }
            set { this._listInfo = value; }
        }

        public LoadGrdBAS0260U01Result() { }

    }
}