using System;
using IHIS.CloudConnector.Contracts.Models.Injs;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Results.System;

namespace IHIS.CloudConnector.Contracts.Results.Injs
{
    public class INJ1001U01CompositeSecondResult : AbstractContractResult
    {
        private InjsINJ1001U01DetailListResult _grdDetail;
        private INJ1001U01GrdSangResult _grdSang;
        private InjsINJ1001U01CplOrderStatusResult _cplOrder;
        private INJ1001U01Grouped2Result _grouped;
        private InjsINJ1001U01AllergyListResult _allergy;
        private InjsINJ1001U01ReserDateListResult _reserDate;
        private List<InjsINJ1001U01ChkbStateResult> _chkbState = new List<InjsINJ1001U01ChkbStateResult>();
        private GetPatientByCodeResult _patientInfo;
        private InjsINJ1001U01ScheduleResult _schedule;
        private INJ1001U01MlayConstantInfoResult _consInfo;

        public InjsINJ1001U01DetailListResult GrdDetail
        {
            get { return this._grdDetail; }
            set { this._grdDetail = value; }
        }

        public INJ1001U01GrdSangResult GrdSang
        {
            get { return this._grdSang; }
            set { this._grdSang = value; }
        }

        public InjsINJ1001U01CplOrderStatusResult CplOrder
        {
            get { return this._cplOrder; }
            set { this._cplOrder = value; }
        }

        public INJ1001U01Grouped2Result Grouped
        {
            get { return this._grouped; }
            set { this._grouped = value; }
        }

        public InjsINJ1001U01AllergyListResult Allergy
        {
            get { return this._allergy; }
            set { this._allergy = value; }
        }

        public InjsINJ1001U01ReserDateListResult ReserDate
        {
            get { return this._reserDate; }
            set { this._reserDate = value; }
        }

        public List<InjsINJ1001U01ChkbStateResult> ChkbState
        {
            get { return this._chkbState; }
            set { this._chkbState = value; }
        }

        public GetPatientByCodeResult PatientInfo
        {
            get { return this._patientInfo; }
            set { this._patientInfo = value; }
        }

        public InjsINJ1001U01ScheduleResult Schedule
        {
            get { return this._schedule; }
            set { this._schedule = value; }
        }

        public INJ1001U01MlayConstantInfoResult ConsInfo
        {
            get { return this._consInfo; }
            set { this._consInfo = value; }
        }

        public INJ1001U01CompositeSecondResult() { }

    }
}