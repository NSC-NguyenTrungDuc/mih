using System;
using IHIS.CloudConnector.Contracts.Models.Injs;
using System.Collections.Generic;
using ProtoBuf;
using IHIS.CloudConnector.Contracts.Arguments.System;

namespace IHIS.CloudConnector.Contracts.Arguments.Injs
{
    public class INJ1001U01CompositeLoadDataArgs : IContractArgs
    {
        private BuseoListArgs _buseo;
        private INJ1001U01XEditGridCell88Args _grdCell88;
        private INJ1001U01XEditGridCell89Args _grdCell89;
        private FormEnvironInfoSysDateArgs _infoSysDate;

        public BuseoListArgs Buseo
        {
            get { return this._buseo; }
            set { this._buseo = value; }
        }

        public INJ1001U01XEditGridCell88Args GrdCell88
        {
            get { return this._grdCell88; }
            set { this._grdCell88 = value; }
        }

        public INJ1001U01XEditGridCell89Args GrdCell89
        {
            get { return this._grdCell89; }
            set { this._grdCell89 = value; }
        }

        public FormEnvironInfoSysDateArgs InfoSysDate
        {
            get { return this._infoSysDate; }
            set { this._infoSysDate = value; }
        }

        public INJ1001U01CompositeLoadDataArgs() { }

        public INJ1001U01CompositeLoadDataArgs(BuseoListArgs buseo, INJ1001U01XEditGridCell88Args grdCell88, INJ1001U01XEditGridCell89Args grdCell89, FormEnvironInfoSysDateArgs infoSysDate)
        {
            this._buseo = buseo;
            this._grdCell88 = grdCell88;
            this._grdCell89 = grdCell89;
            this._infoSysDate = infoSysDate;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.INJ1001U01CompositeLoadDataRequest();
        }
    }
}