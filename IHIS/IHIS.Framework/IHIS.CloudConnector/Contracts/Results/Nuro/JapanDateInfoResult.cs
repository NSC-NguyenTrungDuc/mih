using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable]
    public class JapanDateInfoResult : AbstractContractResult
    {
        public JapanDateInfoResult() { }
    
        private JapanDateInfo _jp_date_info;
        public JapanDateInfo JpDateInfo
        {
            get { return _jp_date_info; }
            set { _jp_date_info = value; }
        }
    }
}