using System;
using IHIS.CloudConnector.Contracts.Models.Ocso;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Results.OcsEmr;
using IHIS.CloudConnector.Contracts.Results.Nuri;
using IHIS.CloudConnector.Contracts.Results.Outs;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.CloudConnector.Contracts.Results.Nuro;
using IHIS.CloudConnector.Contracts.Results.Injs;
using IHIS.CloudConnector.Contracts.Results.Cpls;

namespace IHIS.CloudConnector.Contracts.Results.Ocso
{
    public class OCSACT2CompositeSecondResult : AbstractContractResult
    {
        private OCS2015U00GetPatientInfoResult _getPatientInfoRes;
        private NUR1016U00GrdNUR1016Result _grdNur1016Res;
        private NUR1017U00GrdNUR1017Result _grdNur1017Res;
        private OUT0106U00GridListResult _grdListOut0106u00Res;
        private GetPatientByCodeResult _getPatientBycodeRes;
        private OcsLoadInputAndVisibleControlResult _inputVisibleRes;
        private OcsLoadInputTabResult _inputTabRes;
        private InjsINJ1001U01DetailListResult _detailListRes;
        private CPL2010U00CheckInjCplOrderResult _checkInjRes;

        public OCS2015U00GetPatientInfoResult GetPatientInfoRes
        {
            get { return this._getPatientInfoRes; }
            set { this._getPatientInfoRes = value; }
        }

        public NUR1016U00GrdNUR1016Result GrdNur1016Res
        {
            get { return this._grdNur1016Res; }
            set { this._grdNur1016Res = value; }
        }

        public NUR1017U00GrdNUR1017Result GrdNur1017Res
        {
            get { return this._grdNur1017Res; }
            set { this._grdNur1017Res = value; }
        }

        public OUT0106U00GridListResult GrdListOut0106u00Res
        {
            get { return this._grdListOut0106u00Res; }
            set { this._grdListOut0106u00Res = value; }
        }

        public GetPatientByCodeResult GetPatientBycodeRes
        {
            get { return this._getPatientBycodeRes; }
            set { this._getPatientBycodeRes = value; }
        }

        public OcsLoadInputAndVisibleControlResult InputVisibleRes
        {
            get { return this._inputVisibleRes; }
            set { this._inputVisibleRes = value; }
        }

        public OcsLoadInputTabResult InputTabRes
        {
            get { return this._inputTabRes; }
            set { this._inputTabRes = value; }
        }

        public InjsINJ1001U01DetailListResult DetailListRes
        {
            get { return this._detailListRes; }
            set { this._detailListRes = value; }
        }

        public CPL2010U00CheckInjCplOrderResult CheckInjRes
        {
            get { return this._checkInjRes; }
            set { this._checkInjRes = value; }
        }

        public OCSACT2CompositeSecondResult() { }

    }
}