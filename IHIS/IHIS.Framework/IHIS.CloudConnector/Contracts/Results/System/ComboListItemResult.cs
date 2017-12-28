using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.System;

namespace IHIS.CloudConnector.Contracts.Results.System
{
    [Serializable ]
    public class ComboListItemResult : AbstractContractResult
    {
        private List<ComboListItemInfo> _listItemInfos = new List<ComboListItemInfo>();

        public ComboListItemResult()
        {
            
        }

        public ComboListItemResult(List<ComboListItemInfo> listItemInfos)
        {
            this.ListItemInfos = listItemInfos;
        }

        public List<ComboListItemInfo> ListItemInfos
        {
            get { return _listItemInfos; }
            set { _listItemInfos = value; }
        }
    }
}
