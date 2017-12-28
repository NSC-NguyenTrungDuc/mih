using System;
using IHIS.CloudConnector.Contracts.Models.Drgs;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Results.System;

namespace IHIS.CloudConnector.Contracts.Results.Drgs
{
    public class OpenScreenDRG5100P01CompositeResult : AbstractContractResult
    {
        private List<DRG5100P01CheckActResult> _checkAct = new List<DRG5100P01CheckActResult>();
        private List<StringResult> _sysDate = new List<StringResult>();
        private List<DrgsDRG5100P01GridPaidListResult> _paidList = new List<DrgsDRG5100P01GridPaidListResult>();
        private List<GetPatientByCodeResult> _patientBycode = new List<GetPatientByCodeResult>();

        public List<DRG5100P01CheckActResult> CheckAct
        {
            get { return this._checkAct; }
            set { this._checkAct = value; }
        }

        public List<StringResult> SysDate
        {
            get { return this._sysDate; }
            set { this._sysDate = value; }
        }

        public List<DrgsDRG5100P01GridPaidListResult> PaidList
        {
            get { return this._paidList; }
            set { this._paidList = value; }
        }

        public List<GetPatientByCodeResult> PatientBycode
        {
            get { return this._patientBycode; }
            set { this._patientBycode = value; }
        }

        public OpenScreenDRG5100P01CompositeResult() { }

    }
}