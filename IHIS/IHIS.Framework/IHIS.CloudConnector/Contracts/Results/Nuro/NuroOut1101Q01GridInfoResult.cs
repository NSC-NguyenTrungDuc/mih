using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Nuro;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable]
    public class NuroOut1101Q01GridInfoResult : AbstractContractResult
    {
        private List<NuroOUT1101Q01GridInfo> _grid_info_list = new List<NuroOUT1101Q01GridInfo>();
        public NuroOut1101Q01GridInfoResult() { }
    
        public List<NuroOUT1101Q01GridInfo> GridInfoList
        {
            get { return _grid_info_list; }
        }

    }
}