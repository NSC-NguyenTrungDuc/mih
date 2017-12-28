using System;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    public class OCS0103U00CheckAdminUserResult : AbstractContractResult
    {
        private String _masterGroupHosp;

        public String MasterGroupHosp
        {
            get { return this._masterGroupHosp; }
            set { this._masterGroupHosp = value; }
        }

        public OCS0103U00CheckAdminUserResult() { }

    }
}