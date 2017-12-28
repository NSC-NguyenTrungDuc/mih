using System;
using IHIS.CloudConnector.Contracts.Models.OcsEmr;
using System.Collections.Generic;
using ProtoBuf;
using IHIS.CloudConnector.Contracts.Arguments.Ocsa;

namespace IHIS.CloudConnector.Contracts.Arguments.OcsEmr
{
    public class SaveEmrCompositeThirdArgs : IContractArgs
    {
        private OCS2015U09EmrRecordUpdateArgs _emrRecordUpdate;
        private OCS2015U06EmrRecordArgs _emrRecord;
        private OCS0103U12GrdSangyongOrderArgs _grdSangyongOrder;
        private OCS0103U10FormLoadArgs _u10FormLoad;

        public OCS2015U09EmrRecordUpdateArgs EmrRecordUpdate
        {
            get { return this._emrRecordUpdate; }
            set { this._emrRecordUpdate = value; }
        }

        public OCS2015U06EmrRecordArgs EmrRecord
        {
            get { return this._emrRecord; }
            set { this._emrRecord = value; }
        }

        public OCS0103U12GrdSangyongOrderArgs GrdSangyongOrder
        {
            get { return this._grdSangyongOrder; }
            set { this._grdSangyongOrder = value; }
        }

        public OCS0103U10FormLoadArgs U10FormLoad
        {
            get { return this._u10FormLoad; }
            set { this._u10FormLoad = value; }
        }

        public SaveEmrCompositeThirdArgs() { }

        public SaveEmrCompositeThirdArgs(OCS2015U09EmrRecordUpdateArgs emrRecordUpdate, OCS2015U06EmrRecordArgs emrRecord, OCS0103U12GrdSangyongOrderArgs grdSangyongOrder, OCS0103U10FormLoadArgs u10FormLoad)
        {
            this._emrRecordUpdate = emrRecordUpdate;
            this._emrRecord = emrRecord;
            this._grdSangyongOrder = grdSangyongOrder;
            this._u10FormLoad = u10FormLoad;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.SaveEmrCompositeThirdRequest();
        }
    }
}