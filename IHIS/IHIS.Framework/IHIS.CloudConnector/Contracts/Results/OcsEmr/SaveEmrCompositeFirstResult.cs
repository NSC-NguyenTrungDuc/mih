using System;
using IHIS.CloudConnector.Contracts.Models.OcsEmr;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Results.Ocso;
using IHIS.CloudConnector.Contracts.Results.Ocs.Lib;

namespace IHIS.CloudConnector.Contracts.Results.OcsEmr
{
    public class SaveEmrCompositeFirstResult : AbstractContractResult
    {
        private OcsoOCS1003P01CheckXResult _ocs1003p01Checkx;
        private List<CheckPatientStatusResult> _checkPatientStatus = new List<CheckPatientStatusResult>();
        private List<OcsoOCS1003P01GetChuciResult> _ocs1003p01GetChuci = new List<OcsoOCS1003P01GetChuciResult>();
        private List<DupCheckInputOutOrderResult> _dupCheckInputOutOrder = new List<DupCheckInputOutOrderResult>();

        public OcsoOCS1003P01CheckXResult Ocs1003p01Checkx
        {
            get { return this._ocs1003p01Checkx; }
            set { this._ocs1003p01Checkx = value; }
        }

        public List<CheckPatientStatusResult> CheckPatientStatus
        {
            get { return this._checkPatientStatus; }
            set { this._checkPatientStatus = value; }
        }

        public List<OcsoOCS1003P01GetChuciResult> Ocs1003p01GetChuci
        {
            get { return this._ocs1003p01GetChuci; }
            set { this._ocs1003p01GetChuci = value; }
        }

        public List<DupCheckInputOutOrderResult> DupCheckInputOutOrder
        {
            get { return this._dupCheckInputOutOrder; }
            set { this._dupCheckInputOutOrder = value; }
        }

        public SaveEmrCompositeFirstResult() { }

    }
}