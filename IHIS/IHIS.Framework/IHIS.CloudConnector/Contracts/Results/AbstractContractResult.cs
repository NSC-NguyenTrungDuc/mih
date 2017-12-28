using System;

namespace IHIS.CloudConnector.Contracts.Results
{
    [Serializable]
    public abstract class AbstractContractResult : IContractResult
    {
        private ExecutionStatus _executionStatus = ExecutionStatus.Timeout;

        public ExecutionStatus ExecutionStatus
        {
            get
            {
                return _executionStatus;
            }
            set
            {
                _executionStatus = value;
            }
        }
    }
}