using System;

namespace IHIS.CloudConnector.Contracts
{
    public class MenuItemInfo
    {
        private string _groupId;
        private string _groupName;
        private string _systemId;
        private string _systemName;
        private string _displayGroupId;
        private string _displayGroupName;
        private string _description;
        private int _groupImageIndex;
        private int _systemImageIndex;
        
        public string GroupId
        {
            get { return _groupId; }           
            set { _groupId = value; }
        }

        public string GroupName
        {
            get { return _groupName; }           
            set { _groupName = value; }
        }

        public string SystemId
        {
            get { return _systemId; }           
            set { _systemId = value; }
        }

        public string SystemName
        {
            get { return _systemName; }           
            set { _systemName = value; }
        }

        public string DisplayGroupId
        {
            get { return _displayGroupId; }           
            set { _displayGroupId = value; }
        }

        public string DisplayGroupName
        {
            get { return _displayGroupName; }           
            set { _displayGroupName = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public int GroupImageIndex
        {
            get { return _groupImageIndex; }
            set { _groupImageIndex = value; }
        }

        public int SystemImageIndex
        {
            get { return _systemImageIndex; }
            set { _systemImageIndex = value; }
        }

        public MenuItemInfo(String groupId, String groupName, String systemId, String systemName, String displayGroupId, String displayGroupName, String description, int groupImageIndex, int systemImageIndex)
        {
            GroupId = groupId;
            GroupName = groupName;
            SystemId = systemId;
            SystemName = systemName;
            DisplayGroupId = displayGroupId;
            DisplayGroupName = displayGroupName;
            Description = description;
            GroupImageIndex = groupImageIndex;
            SystemImageIndex = systemImageIndex;
        }

        public MenuItemInfo()
        {
        } 
    }
}