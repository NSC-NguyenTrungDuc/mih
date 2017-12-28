using System;
using System.Collections.Generic;
using System.Text;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable]
    public class NuroManagePatientUpdateResult : AbstractContractResult
    {
        private bool _resultUpdate = new bool();

        public NuroManagePatientUpdateResult()
        {
        }

        public bool ResultUpdate
        {
            get { return _resultUpdate; }
            set { _resultUpdate = value; }
        }
    }
}
