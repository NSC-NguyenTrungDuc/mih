using System;
using IHIS.CloudConnector.Contracts.Models.Injs;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Results.System;

namespace IHIS.CloudConnector.Contracts.Results.Injs
{
    public class INJ1001U01CompositeLoadDataResult : AbstractContractResult
    {
        private BuseoListResult _buseo;
        private INJ1001U01XEditGridCell88Result _grdCell88;
        private INJ1001U01XEditGridCell89Result _grdCell89;
        private StringResult _result;

        public BuseoListResult Buseo
        {
            get { return this._buseo; }
            set { this._buseo = value; }
        }

        public INJ1001U01XEditGridCell88Result GrdCell88
        {
            get { return this._grdCell88; }
            set { this._grdCell88 = value; }
        }

        public INJ1001U01XEditGridCell89Result GrdCell89
        {
            get { return this._grdCell89; }
            set { this._grdCell89 = value; }
        }

        public StringResult Result
        {
            get { return this._result; }
            set { this._result = value; }
        }

        public INJ1001U01CompositeLoadDataResult() { }

    }
}