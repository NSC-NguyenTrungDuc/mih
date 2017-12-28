using System;
using IHIS.CloudConnector.Contracts.Models.Ocso;
using System.Collections.Generic;
using ProtoBuf;
using IHIS.CloudConnector.Contracts.Arguments.OcsEmr;
using IHIS.CloudConnector.Contracts.Arguments.Nuri;
using IHIS.CloudConnector.Contracts.Arguments.Outs;
using IHIS.CloudConnector.Contracts.Arguments.System;
using IHIS.CloudConnector.Contracts.Arguments.Nuro;
using IHIS.CloudConnector.Contracts.Arguments.Injs;
using IHIS.CloudConnector.Contracts.Arguments.Cpls;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocso
{
    public class OCSACT2CompositeSecondArgs : IContractArgs
    {
        private OCS2015U00GetPatientInfoArgs _getPatientInfo;
        private NUR1016U00GrdNUR1016Args _grdNur1016;
        private NUR1017U00GrdNUR1017Args _grdNur1017;
        private OUT0106U00GridListArgs _grdListOut0106u00;
        private GetPatientByCodeArgs _getPatientBycode;
        private OcsLoadInputAndVisibleControlArgs _inputVisible;
        private OcsLoadInputTabArgs _inputTab;
        private InjsINJ1001U01DetailListArgs _detailList;
        private CPL2010U00CheckInjCplOrderArgs _checkInj;

        public OCS2015U00GetPatientInfoArgs GetPatientInfo
        {
            get { return this._getPatientInfo; }
            set { this._getPatientInfo = value; }
        }

        public NUR1016U00GrdNUR1016Args GrdNur1016
        {
            get { return this._grdNur1016; }
            set { this._grdNur1016 = value; }
        }

        public NUR1017U00GrdNUR1017Args GrdNur1017
        {
            get { return this._grdNur1017; }
            set { this._grdNur1017 = value; }
        }

        public OUT0106U00GridListArgs GrdListOut0106u00
        {
            get { return this._grdListOut0106u00; }
            set { this._grdListOut0106u00 = value; }
        }

        public GetPatientByCodeArgs GetPatientBycode
        {
            get { return this._getPatientBycode; }
            set { this._getPatientBycode = value; }
        }

        public OcsLoadInputAndVisibleControlArgs InputVisible
        {
            get { return this._inputVisible; }
            set { this._inputVisible = value; }
        }

        public OcsLoadInputTabArgs InputTab
        {
            get { return this._inputTab; }
            set { this._inputTab = value; }
        }

        public InjsINJ1001U01DetailListArgs DetailList
        {
            get { return this._detailList; }
            set { this._detailList = value; }
        }

        public CPL2010U00CheckInjCplOrderArgs CheckInj
        {
            get { return this._checkInj; }
            set { this._checkInj = value; }
        }

        public OCSACT2CompositeSecondArgs() { }

        public OCSACT2CompositeSecondArgs(OCS2015U00GetPatientInfoArgs getPatientInfo, NUR1016U00GrdNUR1016Args grdNur1016, NUR1017U00GrdNUR1017Args grdNur1017, OUT0106U00GridListArgs grdListOut0106u00, GetPatientByCodeArgs getPatientBycode, OcsLoadInputAndVisibleControlArgs inputVisible, OcsLoadInputTabArgs inputTab, InjsINJ1001U01DetailListArgs detailList, CPL2010U00CheckInjCplOrderArgs checkInj)
        {
            this._getPatientInfo = getPatientInfo;
            this._grdNur1016 = grdNur1016;
            this._grdNur1017 = grdNur1017;
            this._grdListOut0106u00 = grdListOut0106u00;
            this._getPatientBycode = getPatientBycode;
            this._inputVisible = inputVisible;
            this._inputTab = inputTab;
            this._detailList = detailList;
            this._checkInj = checkInj;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OCSACT2CompositeSecondRequest();
        }
    }
}