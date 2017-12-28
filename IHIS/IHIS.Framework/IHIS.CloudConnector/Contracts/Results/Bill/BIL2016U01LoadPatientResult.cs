using System;
using IHIS.CloudConnector.Contracts.Models.Bill;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Bill
{
    public class BIL2016U01LoadPatientResult : AbstractContractResult
    {
        private List<BIL2016U01LoadPatientInfo> _lst = new List<BIL2016U01LoadPatientInfo>();
        private String _totalPatient;
        private String _revenue;

        public List<BIL2016U01LoadPatientInfo> Lst
        {
            get { return this._lst; }
            set { this._lst = value; }
        }

        public String TotalPatient
        {
            get { return this._totalPatient; }
            set { this._totalPatient = value; }
        }

        public String Revenue
        {
            get { return this._revenue; }
            set { this._revenue = value; }
        }

        public BIL2016U01LoadPatientResult() { }

    }
}