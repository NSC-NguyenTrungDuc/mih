using System;
using IHIS.CloudConnector.Contracts.Models.Ocso;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Ocso
{
    [Serializable]
    public class OCS1003R02LayR02QueryStartingResult : AbstractContractResult
    {
        private String _ioFlag;
        private List<OCS1003R02LayR02ListItemInfo> _layr02List = new List<OCS1003R02LayR02ListItemInfo>();

        public String IoFlag
        {
            get { return this._ioFlag; }
            set { this._ioFlag = value; }
        }

        public List<OCS1003R02LayR02ListItemInfo> Layr02List
        {
            get { return this._layr02List; }
            set { this._layr02List = value; }
        }

        public OCS1003R02LayR02QueryStartingResult() { }

    }
}