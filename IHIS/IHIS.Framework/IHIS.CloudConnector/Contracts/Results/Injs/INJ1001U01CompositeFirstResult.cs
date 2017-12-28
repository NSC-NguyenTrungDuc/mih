using System;
using IHIS.CloudConnector.Contracts.Models.Injs;
using System.Collections.Generic;
using IHIS.CloudConnector.Messaging;
using IHIS.CloudConnector.Contracts.Results.System;

namespace IHIS.CloudConnector.Contracts.Results.Injs
{
    public class INJ1001U01CompositeFirstResult : AbstractContractResult
    {
        private INJ1001U01CboTimeResult _cboTimeList;
        private InjsINJ1001U01MasterListResult _grdMasterList;
        private GetPatientByCodeResult _patientInfo;
        private InjsINJ1001U01CplOrderStatusResult _orderStatusRes;
        private INJ1001U01MlayConstantInfoResult _constantInfoRes;
        private InjsINJ1001U01ScheduleResult _scheduleRes;
        private InjsINJ1001U01DetailListResult _detailtListRes;

        public INJ1001U01CboTimeResult CboTimeList
        {
            get { return this._cboTimeList; }
            set { this._cboTimeList = value; }
        }

        public InjsINJ1001U01MasterListResult GrdMasterList
        {
            get { return this._grdMasterList; }
            set { this._grdMasterList = value; }
        }

        public GetPatientByCodeResult PatientInfo
        {
            get { return this._patientInfo; }
            set { this._patientInfo = value; }
        }

        public InjsINJ1001U01CplOrderStatusResult OrderStatusRes
        {
            get { return this._orderStatusRes; }
            set { this._orderStatusRes = value; }
        }

        public INJ1001U01MlayConstantInfoResult ConstantInfoRes
        {
            get { return this._constantInfoRes; }
            set { this._constantInfoRes = value; }
        }

        public InjsINJ1001U01ScheduleResult ScheduleRes
        {
            get { return this._scheduleRes; }
            set { this._scheduleRes = value; }
        }

        public InjsINJ1001U01DetailListResult DetailtListRes
        {
            get { return this._detailtListRes; }
            set { this._detailtListRes = value; }
        }

        public INJ1001U01CompositeFirstResult() { }

    }
}