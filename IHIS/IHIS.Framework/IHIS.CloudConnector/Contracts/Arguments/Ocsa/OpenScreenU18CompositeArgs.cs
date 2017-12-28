using System;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using System.Collections.Generic;
using ProtoBuf;
using IHIS.CloudConnector.Contracts.Arguments.Ocs.Lib;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{
    public class OpenScreenU18CompositeArgs : IContractArgs
    {
        private List<LoadComboDataSourceArgs> _loadComboData = new List<LoadComboDataSourceArgs>();
        private List<OCS0103U18InitializeScreenArgs> _initializeScreen = new List<OCS0103U18InitializeScreenArgs>();
        private List<OCS0103U12MakeSangyongTabArgs> _sangyongTab = new List<OCS0103U12MakeSangyongTabArgs>();
        private List<OCS0103U12GrdSangyongOrderArgs> _sangyongOrder = new List<OCS0103U12GrdSangyongOrderArgs>();
        private List<GetNextGroupSerArgs> _nextGroupSer = new List<GetNextGroupSerArgs>();
        private List<OcsOrderBizGetUserOptionArgs> _userOption = new List<OcsOrderBizGetUserOptionArgs>();

        public List<LoadComboDataSourceArgs> LoadComboData
        {
            get { return this._loadComboData; }
            set { this._loadComboData = value; }
        }

        public List<OCS0103U18InitializeScreenArgs> InitializeScreen
        {
            get { return this._initializeScreen; }
            set { this._initializeScreen = value; }
        }

        public List<OCS0103U12MakeSangyongTabArgs> SangyongTab
        {
            get { return this._sangyongTab; }
            set { this._sangyongTab = value; }
        }

        public List<OCS0103U12GrdSangyongOrderArgs> SangyongOrder
        {
            get { return this._sangyongOrder; }
            set { this._sangyongOrder = value; }
        }

        public List<GetNextGroupSerArgs> NextGroupSer
        {
            get { return this._nextGroupSer; }
            set { this._nextGroupSer = value; }
        }

        public List<OcsOrderBizGetUserOptionArgs> UserOption
        {
            get { return this._userOption; }
            set { this._userOption = value; }
        }

        public OpenScreenU18CompositeArgs() { }

        public OpenScreenU18CompositeArgs(List<LoadComboDataSourceArgs> loadComboData, List<OCS0103U18InitializeScreenArgs> initializeScreen, List<OCS0103U12MakeSangyongTabArgs> sangyongTab, List<OCS0103U12GrdSangyongOrderArgs> sangyongOrder, List<GetNextGroupSerArgs> nextGroupSer, List<OcsOrderBizGetUserOptionArgs> userOption)
        {
            this._loadComboData = loadComboData;
            this._initializeScreen = initializeScreen;
            this._sangyongTab = sangyongTab;
            this._sangyongOrder = sangyongOrder;
            this._nextGroupSer = nextGroupSer;
            this._userOption = userOption;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OpenScreenU18CompositeRequest();
        }
    }
}