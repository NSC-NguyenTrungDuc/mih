using System;
using IHIS.CloudConnector.Contracts.Models.OcsEmr;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.CloudConnector.Contracts.Results.Ocsa;

namespace IHIS.CloudConnector.Contracts.Results.OcsEmr
{
    public class SaveEmrCompositeThirdResult : AbstractContractResult
    {
        private UpdateResult _emrRecordUpdate;
        private OCS2015U06EmrRecordResult _emrRecord;
        private OCS0103U12GrdSangyongOrderResult _grdSangyongOrder;
        private OCS0103U10FormLoadResult _u10FormLoad;

        public UpdateResult EmrRecordUpdate
        {
            get { return this._emrRecordUpdate; }
            set { this._emrRecordUpdate = value; }
        }

        public OCS2015U06EmrRecordResult EmrRecord
        {
            get { return this._emrRecord; }
            set { this._emrRecord = value; }
        }

        public OCS0103U12GrdSangyongOrderResult GrdSangyongOrder
        {
            get { return this._grdSangyongOrder; }
            set { this._grdSangyongOrder = value; }
        }

        public OCS0103U10FormLoadResult U10FormLoad
        {
            get { return this._u10FormLoad; }
            set { this._u10FormLoad = value; }
        }

        public SaveEmrCompositeThirdResult() { }

    }
}