using System;
using IHIS.CloudConnector.Contracts.Models.Ocso;
using System.Collections.Generic;
using ProtoBuf;
using IHIS.CloudConnector.Contracts.Arguments.Outs;
using IHIS.CloudConnector.Contracts.Arguments.OcsEmr;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocso
{
    public class OCSACT2GetPatientExpandArgs : IContractArgs
    {
        private OUT0106U00GridListArgs _gridListItem;
        private OCS2015U06EmrRecordArgs _emrRecordItem;
        private OcsoOCS1003P01GridOutSangArgs _gridOutsangItem;

        public OUT0106U00GridListArgs GridListItem
        {
            get { return this._gridListItem; }
            set { this._gridListItem = value; }
        }

        public OCS2015U06EmrRecordArgs EmrRecordItem
        {
            get { return this._emrRecordItem; }
            set { this._emrRecordItem = value; }
        }

        public OcsoOCS1003P01GridOutSangArgs GridOutsangItem
        {
            get { return this._gridOutsangItem; }
            set { this._gridOutsangItem = value; }
        }

        public OCSACT2GetPatientExpandArgs() { }

        public OCSACT2GetPatientExpandArgs(OUT0106U00GridListArgs gridListItem, OCS2015U06EmrRecordArgs emrRecordItem, OcsoOCS1003P01GridOutSangArgs gridOutsangItem)
        {
            this._gridListItem = gridListItem;
            this._emrRecordItem = emrRecordItem;
            this._gridOutsangItem = gridOutsangItem;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OCSACT2GetPatientExpandRequest();
        }
    }
}