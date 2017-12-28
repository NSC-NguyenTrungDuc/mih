using System;
using IHIS.CloudConnector.Contracts.Models.OcsEmr;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.System;

namespace IHIS.CloudConnector.Contracts.Results.OcsEmr
{
    public class OCS2015U31LoadComboDoctorResult : AbstractContractResult
    {
        private List<ComboListItemInfo> _doctorInfo = new List<ComboListItemInfo>();

        public List<ComboListItemInfo> DoctorInfo
        {
            get { return this._doctorInfo; }
            set { this._doctorInfo = value; }
        }

        public OCS2015U31LoadComboDoctorResult() { }

    }
}