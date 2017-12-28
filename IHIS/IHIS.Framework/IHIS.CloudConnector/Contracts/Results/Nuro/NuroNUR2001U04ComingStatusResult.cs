using System;
using System.Collections.Generic;
using System.Text;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable]
    public class NuroNUR2001U04ComingStatusResult : AbstractContractResult
    {
        private string _result;

        public string Result
        {
            get { return _result; }
            set { _result = value; }
        }

        public NuroNUR2001U04ComingStatusResult(string result)
        {
            _result = result;
        }

        public NuroNUR2001U04ComingStatusResult()
        {
        }
    }
}
