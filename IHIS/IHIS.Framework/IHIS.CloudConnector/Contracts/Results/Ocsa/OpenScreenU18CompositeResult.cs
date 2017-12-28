using System;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Results.Ocs.Lib;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    public class OpenScreenU18CompositeResult : AbstractContractResult
    {
        private List<LoadComboDataSourceResult> _loadComboData = new List<LoadComboDataSourceResult>();
        private List<OCS0103U18InitializeScreenResult> _initializeScreen = new List<OCS0103U18InitializeScreenResult>();
        private List<OCS0103U12MakeSangyongTabResult> _sangyongTab = new List<OCS0103U12MakeSangyongTabResult>();
        private List<OCS0103U12GrdSangyongOrderResult> _sangyongOrder = new List<OCS0103U12GrdSangyongOrderResult>();
        private List<GetNextGroupSerResult> _nextGroupSer = new List<GetNextGroupSerResult>();
        private List<OcsOrderBizGetUserOptionResult> _userOption = new List<OcsOrderBizGetUserOptionResult>();

        public List<LoadComboDataSourceResult> LoadComboData
        {
            get { return this._loadComboData; }
            set { this._loadComboData = value; }
        }

        public List<OCS0103U18InitializeScreenResult> InitializeScreen
        {
            get { return this._initializeScreen; }
            set { this._initializeScreen = value; }
        }

        public List<OCS0103U12MakeSangyongTabResult> SangyongTab
        {
            get { return this._sangyongTab; }
            set { this._sangyongTab = value; }
        }

        public List<OCS0103U12GrdSangyongOrderResult> SangyongOrder
        {
            get { return this._sangyongOrder; }
            set { this._sangyongOrder = value; }
        }

        public List<GetNextGroupSerResult> NextGroupSer
        {
            get { return this._nextGroupSer; }
            set { this._nextGroupSer = value; }
        }

        public List<OcsOrderBizGetUserOptionResult> UserOption
        {
            get { return this._userOption; }
            set { this._userOption = value; }
        }

        public OpenScreenU18CompositeResult() { }

    }
}