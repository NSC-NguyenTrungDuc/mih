using System;
using IHIS.CloudConnector.Contracts.Models.Cpls;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Results.System;
namespace IHIS.CloudConnector.Contracts.Results.Cpls
{
    public class CPL2010U00OpenScreenCompositeResult : AbstractContractResult
    {
        private CheckUserLoginResult _checkUser;
        private MdiFormMainMenuResult _mdiFrom;
        private MdiFormOpenMainScreenResult _mdiScreen;
        private FormScreenListResult _fromScreen;
        private ComboResult _cbxActor;
        private List<StringResult> _infoSysDate = new List<StringResult>();
        private CPL2010U00GrdPaListResult _paList;
        private CPL2010U00VsvPaResult _vsvPa;
        private XPaInfoBoxResult _infoBox;
        private CPL2010U00LayChkNamesResult _layChkName;
        private CPL2010U00GrdOrderResult _grdOrder;
        private CPL2010U00GrdSpecimenResult _grdSpecimen;
        private CPL2010U00GrdTubeQueryStartingResult _grdTube;
        private List<StringResult> _infoSysDateTime = new List<StringResult>();
        private List<CPL2010U00MlayConstantInfoResult> _constantInfo = new List<CPL2010U00MlayConstantInfoResult>();
        private CPL2010U00CheckInjCplOrderResult _injCplOrder;

        public CheckUserLoginResult CheckUser
        {
            get { return this._checkUser; }
            set { this._checkUser = value; }
        }

        public MdiFormMainMenuResult MdiFrom
        {
            get { return this._mdiFrom; }
            set { this._mdiFrom = value; }
        }

        public MdiFormOpenMainScreenResult MdiScreen
        {
            get { return this._mdiScreen; }
            set { this._mdiScreen = value; }
        }

        public FormScreenListResult FromScreen
        {
            get { return this._fromScreen; }
            set { this._fromScreen = value; }
        }

        public ComboResult CbxActor
        {
            get { return this._cbxActor; }
            set { this._cbxActor = value; }
        }

        public List<StringResult> InfoSysDate
        {
            get { return this._infoSysDate; }
            set { this._infoSysDate = value; }
        }

        public CPL2010U00GrdPaListResult PaList
        {
            get { return this._paList; }
            set { this._paList = value; }
        }

        public CPL2010U00VsvPaResult VsvPa
        {
            get { return this._vsvPa; }
            set { this._vsvPa = value; }
        }

        public XPaInfoBoxResult InfoBox
        {
            get { return this._infoBox; }
            set { this._infoBox = value; }
        }

        public CPL2010U00LayChkNamesResult LayChkName
        {
            get { return this._layChkName; }
            set { this._layChkName = value; }
        }

        public CPL2010U00GrdOrderResult GrdOrder
        {
            get { return this._grdOrder; }
            set { this._grdOrder = value; }
        }

        public CPL2010U00GrdSpecimenResult GrdSpecimen
        {
            get { return this._grdSpecimen; }
            set { this._grdSpecimen = value; }
        }

        public CPL2010U00GrdTubeQueryStartingResult GrdTube
        {
            get { return this._grdTube; }
            set { this._grdTube = value; }
        }

        public List<StringResult> InfoSysDateTime
        {
            get { return this._infoSysDateTime; }
            set { this._infoSysDateTime = value; }
        }

        public List<CPL2010U00MlayConstantInfoResult> ConstantInfo
        {
            get { return this._constantInfo; }
            set { this._constantInfo = value; }
        }

        public CPL2010U00CheckInjCplOrderResult InjCplOrder
        {
            get { return this._injCplOrder; }
            set { this._injCplOrder = value; }
        }

        public CPL2010U00OpenScreenCompositeResult() { }

    }
}