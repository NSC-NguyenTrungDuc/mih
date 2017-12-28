using System;
using IHIS.CloudConnector.Contracts.Models.Injs;
using System.Collections.Generic;
using ProtoBuf;
using IHIS.CloudConnector.Contracts.Arguments.System;

namespace IHIS.CloudConnector.Contracts.Arguments.Injs
{
    public class INJ1001U01CompositeSecondArgs : IContractArgs
    {
        private InjsINJ1001U01DetailListArgs _grdDetail;
        private INJ1001U01GrdSangArgs _grdSang;
        private InjsINJ1001U01CplOrderStatusArgs _cplOrder;
        private INJ1001U01Grouped2Args _grouped;
        private InjsINJ1001U01AllergyListArgs _allergy;
        private InjsINJ1001U01ReserDateListArgs _reserDate;
        private List<InjsINJ1001U01ChkbStateArgs> _chkbState = new List<InjsINJ1001U01ChkbStateArgs>();
        private GetPatientByCodeArgs _patientInfo;
        private InjsINJ1001U01ScheduleArgs _schedule;
        private INJ1001U01MlayConstantInfoArgs _consInfo;

        public InjsINJ1001U01DetailListArgs GrdDetail
        {
            get { return this._grdDetail; }
            set { this._grdDetail = value; }
        }

        public INJ1001U01GrdSangArgs GrdSang
        {
            get { return this._grdSang; }
            set { this._grdSang = value; }
        }

        public InjsINJ1001U01CplOrderStatusArgs CplOrder
        {
            get { return this._cplOrder; }
            set { this._cplOrder = value; }
        }

        public INJ1001U01Grouped2Args Grouped
        {
            get { return this._grouped; }
            set { this._grouped = value; }
        }

        public InjsINJ1001U01AllergyListArgs Allergy
        {
            get { return this._allergy; }
            set { this._allergy = value; }
        }

        public InjsINJ1001U01ReserDateListArgs ReserDate
        {
            get { return this._reserDate; }
            set { this._reserDate = value; }
        }

        public List<InjsINJ1001U01ChkbStateArgs> ChkbState
        {
            get { return this._chkbState; }
            set { this._chkbState = value; }
        }

        public GetPatientByCodeArgs PatientInfo
        {
            get { return this._patientInfo; }
            set { this._patientInfo = value; }
        }

        public InjsINJ1001U01ScheduleArgs Schedule
        {
            get { return this._schedule; }
            set { this._schedule = value; }
        }

        public INJ1001U01MlayConstantInfoArgs ConsInfo
        {
            get { return this._consInfo; }
            set { this._consInfo = value; }
        }

        public INJ1001U01CompositeSecondArgs() { }

        public INJ1001U01CompositeSecondArgs(InjsINJ1001U01DetailListArgs grdDetail, INJ1001U01GrdSangArgs grdSang, InjsINJ1001U01CplOrderStatusArgs cplOrder, INJ1001U01Grouped2Args grouped, InjsINJ1001U01AllergyListArgs allergy, InjsINJ1001U01ReserDateListArgs reserDate, List<InjsINJ1001U01ChkbStateArgs> chkbState, GetPatientByCodeArgs patientInfo, InjsINJ1001U01ScheduleArgs schedule, INJ1001U01MlayConstantInfoArgs consInfo)
        {
            this._grdDetail = grdDetail;
            this._grdSang = grdSang;
            this._cplOrder = cplOrder;
            this._grouped = grouped;
            this._allergy = allergy;
            this._reserDate = reserDate;
            this._chkbState = chkbState;
            this._patientInfo = patientInfo;
            this._schedule = schedule;
            this._consInfo = consInfo;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.INJ1001U01CompositeSecondRequest();
        }
    }
}