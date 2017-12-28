using System;
using IHIS.CloudConnector.Contracts.Models.Ocso;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Ocso
{
    [Serializable]
    public class OCS1003R02LayR03QueryStartingResult : AbstractContractResult
    {
        private List<OCS1003R02LayR03ListItemInfo> _layr03List = new List<OCS1003R02LayR03ListItemInfo>();

        public List<OCS1003R02LayR03ListItemInfo> Layr03List
        {
            get { return this._layr03List; }
            set { this._layr03List = value; }
        }

        public OCS1003R02LayR03QueryStartingResult() { }

    }
}