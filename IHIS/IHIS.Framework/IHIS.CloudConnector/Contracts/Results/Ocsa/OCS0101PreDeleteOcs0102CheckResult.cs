using System;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
    public class OCS0101PreDeleteOcs0102CheckResult : AbstractContractResult
    {
        private String _ocs0103Result;
        private String _ocs0106Result;

        public String Ocs0103Result
        {
            get { return this._ocs0103Result; }
            set { this._ocs0103Result = value; }
        }

        public String Ocs0106Result
        {
            get { return this._ocs0106Result; }
            set { this._ocs0106Result = value; }
        }

        public OCS0101PreDeleteOcs0102CheckResult() { }

    }
}