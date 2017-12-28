using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    public class NUR2016CheckExitsEMRLinkResult : AbstractContractResult
    {
        private String _result;
        private List<LinkEMRPatientInfo> _linkEmrPatientItem = new List<LinkEMRPatientInfo>();

        public String Result
        {
            get { return this._result; }
            set { this._result = value; }
        }

        public List<LinkEMRPatientInfo> LinkEmrPatientItem
        {
            get { return this._linkEmrPatientItem; }
            set { this._linkEmrPatientItem = value; }
        }

        public NUR2016CheckExitsEMRLinkResult() { }

    }
}