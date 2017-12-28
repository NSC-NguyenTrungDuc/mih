using System;
using System.Collections.Generic;
using System.Text;
using IHIS.CloudConnector.Contracts.Models.System;

namespace IHIS.CloudConnector.Contracts.Results.System
{
    [Serializable]
    public class XPaInfoBoxResult : AbstractContractResult
    {
        private List<XPaInfoBoxInfo> _patientInfoItem = new List<XPaInfoBoxInfo>();

        public XPaInfoBoxResult()
        {
        }

        public List<XPaInfoBoxInfo> PatientInfoItem
        {
            get { return this._patientInfoItem; }
            set { this._patientInfoItem = value; }
        }
    }
}
