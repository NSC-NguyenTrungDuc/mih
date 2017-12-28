using System;
using IHIS.CloudConnector.Contracts.Models.Injs;
using System.Collections.Generic;
using ProtoBuf;
using IHIS.CloudConnector.Contracts.Arguments.System;

namespace IHIS.CloudConnector.Contracts.Arguments.Injs
{
    public class INJ1001U01CompositeFirstArgs : IContractArgs
    {
        private INJ1001U01CboTimeArgs _cboTimeParam;
        private InjsINJ1001U01MasterListArgs _grdMasterParam;
        private GetPatientByCodeArgs _patientInfo;
        private InjsINJ1001U01CplOrderStatusArgs _orderStatus;
        private INJ1001U01MlayConstantInfoArgs _constantInfo;
        private InjsINJ1001U01ScheduleArgs _schedule;
        private InjsINJ1001U01DetailListArgs _detailtList;

        public INJ1001U01CboTimeArgs CboTimeParam
        {
            get { return this._cboTimeParam; }
            set { this._cboTimeParam = value; }
        }

        public InjsINJ1001U01MasterListArgs GrdMasterParam
        {
            get { return this._grdMasterParam; }
            set { this._grdMasterParam = value; }
        }

        public GetPatientByCodeArgs PatientInfo
        {
            get { return this._patientInfo; }
            set { this._patientInfo = value; }
        }

        public InjsINJ1001U01CplOrderStatusArgs OrderStatus
        {
            get { return this._orderStatus; }
            set { this._orderStatus = value; }
        }

        public INJ1001U01MlayConstantInfoArgs ConstantInfo
        {
            get { return this._constantInfo; }
            set { this._constantInfo = value; }
        }

        public InjsINJ1001U01ScheduleArgs Schedule
        {
            get { return this._schedule; }
            set { this._schedule = value; }
        }

        public InjsINJ1001U01DetailListArgs DetailtList
        {
            get { return this._detailtList; }
            set { this._detailtList = value; }
        }

        public INJ1001U01CompositeFirstArgs() { }

        public INJ1001U01CompositeFirstArgs(INJ1001U01CboTimeArgs cboTimeParam, InjsINJ1001U01MasterListArgs grdMasterParam, GetPatientByCodeArgs patientInfo, InjsINJ1001U01CplOrderStatusArgs orderStatus, INJ1001U01MlayConstantInfoArgs constantInfo, InjsINJ1001U01ScheduleArgs schedule, InjsINJ1001U01DetailListArgs detailtList)
        {
            this._cboTimeParam = cboTimeParam;
            this._grdMasterParam = grdMasterParam;
            this._patientInfo = patientInfo;
            this._orderStatus = orderStatus;
            this._constantInfo = constantInfo;
            this._schedule = schedule;
            this._detailtList = detailtList;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.INJ1001U01CompositeFirstRequest();
        }
    }
}