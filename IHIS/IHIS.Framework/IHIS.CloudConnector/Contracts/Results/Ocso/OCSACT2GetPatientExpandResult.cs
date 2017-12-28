using System;
using IHIS.CloudConnector.Contracts.Models.Ocso;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Results.Outs;
using IHIS.CloudConnector.Contracts.Results.OcsEmr;

namespace IHIS.CloudConnector.Contracts.Results.Ocso
{
    public class OCSACT2GetPatientExpandResult : AbstractContractResult
    {
        private OUT0106U00GridListResult _gridListItem;
        private OCS2015U06EmrRecordResult _emrRecordItem;
        private OcsoOCS1003P01GridOutSangResult _gridOutsangItem;

        public OUT0106U00GridListResult GridListItem
        {
            get { return this._gridListItem; }
            set { this._gridListItem = value; }
        }

        public OCS2015U06EmrRecordResult EmrRecordItem
        {
            get { return this._emrRecordItem; }
            set { this._emrRecordItem = value; }
        }

        public OcsoOCS1003P01GridOutSangResult GridOutsangItem
        {
            get { return this._gridOutsangItem; }
            set { this._gridOutsangItem = value; }
        }

        public OCSACT2GetPatientExpandResult() { }

    }
}