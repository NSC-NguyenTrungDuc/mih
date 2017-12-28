using System;
using IHIS.CloudConnector.Contracts.Models.Cpls;
using System.Collections.Generic;
using ProtoBuf;
using IHIS.CloudConnector.Contracts.Arguments.System;

namespace IHIS.CloudConnector.Contracts.Arguments.Cpls
{
    public class CPL2010U00OpenScreenCompositeArgs : IContractArgs
    {
        private CheckUserLoginArgs _checkUser;
        private MdiFormMainMenuArgs _mdiFrom;
        private MdiFormOpenMainScreenArgs _mdiScreen;
        private FormScreenListArgs _fromScreen;
        private ComboADM3200CbxActorArgs _cbxActor;
        private List<FormEnvironInfoSysDateArgs> _infoSysDate = new List<FormEnvironInfoSysDateArgs>();
        private CPL2010U00GrdPaListArgs _paList;
        private CPL2010U00VsvPaArgs _vsvPa;
        private XPaInfoBoxArgs _infoBox;
        private CPL2010U00LayChkNamesArgs _layChkName;
        private CPL2010U00GrdOrderArgs _grdOrder;
        private CPL2010U00GrdSpecimenArgs _grdSpecimen;
        private CPL2010U00GrdTubeQueryStartingArgs _grdTube;
        private List<FormEnvironInfoSysDateTimeArgs> _infoSysDateTime = new List<FormEnvironInfoSysDateTimeArgs>();
        private List<CPL2010U00MlayConstantInfoArgs> _constantInfo = new List<CPL2010U00MlayConstantInfoArgs>();
        private CPL2010U00CheckInjCplOrderArgs _injCplOrder;

        public CheckUserLoginArgs CheckUser
        {
            get { return this._checkUser; }
            set { this._checkUser = value; }
        }

        public MdiFormMainMenuArgs MdiFrom
        {
            get { return this._mdiFrom; }
            set { this._mdiFrom = value; }
        }

        public MdiFormOpenMainScreenArgs MdiScreen
        {
            get { return this._mdiScreen; }
            set { this._mdiScreen = value; }
        }

        public FormScreenListArgs FromScreen
        {
            get { return this._fromScreen; }
            set { this._fromScreen = value; }
        }

        public ComboADM3200CbxActorArgs CbxActor
        {
            get { return this._cbxActor; }
            set { this._cbxActor = value; }
        }

        public List<FormEnvironInfoSysDateArgs> InfoSysDate
        {
            get { return this._infoSysDate; }
            set { this._infoSysDate = value; }
        }

        public CPL2010U00GrdPaListArgs PaList
        {
            get { return this._paList; }
            set { this._paList = value; }
        }

        public CPL2010U00VsvPaArgs VsvPa
        {
            get { return this._vsvPa; }
            set { this._vsvPa = value; }
        }

        public XPaInfoBoxArgs InfoBox
        {
            get { return this._infoBox; }
            set { this._infoBox = value; }
        }

        public CPL2010U00LayChkNamesArgs LayChkName
        {
            get { return this._layChkName; }
            set { this._layChkName = value; }
        }

        public CPL2010U00GrdOrderArgs GrdOrder
        {
            get { return this._grdOrder; }
            set { this._grdOrder = value; }
        }

        public CPL2010U00GrdSpecimenArgs GrdSpecimen
        {
            get { return this._grdSpecimen; }
            set { this._grdSpecimen = value; }
        }

        public CPL2010U00GrdTubeQueryStartingArgs GrdTube
        {
            get { return this._grdTube; }
            set { this._grdTube = value; }
        }

        public List<FormEnvironInfoSysDateTimeArgs> InfoSysDateTime
        {
            get { return this._infoSysDateTime; }
            set { this._infoSysDateTime = value; }
        }

        public List<CPL2010U00MlayConstantInfoArgs> ConstantInfo
        {
            get { return this._constantInfo; }
            set { this._constantInfo = value; }
        }

        public CPL2010U00CheckInjCplOrderArgs InjCplOrder
        {
            get { return this._injCplOrder; }
            set { this._injCplOrder = value; }
        }

        public CPL2010U00OpenScreenCompositeArgs() { }

        public CPL2010U00OpenScreenCompositeArgs(CheckUserLoginArgs checkUser, MdiFormMainMenuArgs mdiFrom, MdiFormOpenMainScreenArgs mdiScreen, FormScreenListArgs fromScreen, ComboADM3200CbxActorArgs cbxActor, List<FormEnvironInfoSysDateArgs> infoSysDate, CPL2010U00GrdPaListArgs paList, CPL2010U00VsvPaArgs vsvPa, XPaInfoBoxArgs infoBox, CPL2010U00LayChkNamesArgs layChkName, CPL2010U00GrdOrderArgs grdOrder, CPL2010U00GrdSpecimenArgs grdSpecimen, CPL2010U00GrdTubeQueryStartingArgs grdTube, List<FormEnvironInfoSysDateTimeArgs> infoSysDateTime, List<CPL2010U00MlayConstantInfoArgs> constantInfo, CPL2010U00CheckInjCplOrderArgs injCplOrder)
        {
            this._checkUser = checkUser;
            this._mdiFrom = mdiFrom;
            this._mdiScreen = mdiScreen;
            this._fromScreen = fromScreen;
            this._cbxActor = cbxActor;
            this._infoSysDate = infoSysDate;
            this._paList = paList;
            this._vsvPa = vsvPa;
            this._infoBox = infoBox;
            this._layChkName = layChkName;
            this._grdOrder = grdOrder;
            this._grdSpecimen = grdSpecimen;
            this._grdTube = grdTube;
            this._infoSysDateTime = infoSysDateTime;
            this._constantInfo = constantInfo;
            this._injCplOrder = injCplOrder;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.CPL2010U00OpenScreenCompositeRequest();
        }
    }
}