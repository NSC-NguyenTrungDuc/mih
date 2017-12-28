using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Nuro;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable]
    public class NuroOut1101Q01PrintNameInfoResult: AbstractContractResult
    {
        private List<NuroOUT1101Q01PrintNameInfo> _print_name_info_list = new List<NuroOUT1101Q01PrintNameInfo>();

        public NuroOut1101Q01PrintNameInfoResult()
        {
        }

        public List<NuroOUT1101Q01PrintNameInfo> PrintNameInfoList
        {
            get { return _print_name_info_list; }
        }
    }
}