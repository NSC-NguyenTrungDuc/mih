using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    public class RES1001U00SaveLayoutArgs : IContractArgs
    {
        private String _userId;
        private List<RES1001U00SaveLayoutItemInfo> _layoutItem = new List<RES1001U00SaveLayoutItemInfo>();
        private String _hospCodeLink;
        private String _bookingType;
        private String _bunhoLink;

        public String UserId
        {
            get { return this._userId; }
            set { this._userId = value; }
        }

        public List<RES1001U00SaveLayoutItemInfo> LayoutItem
        {
            get { return this._layoutItem; }
            set { this._layoutItem = value; }
        }

        public String HospCodeLink
        {
            get { return this._hospCodeLink; }
            set { this._hospCodeLink = value; }
        }

        public String BookingType
        {
            get { return this._bookingType; }
            set { this._bookingType = value; }
        }

        public String BunhoLink
        {
            get { return this._bunhoLink; }
            set { this._bunhoLink = value; }
        }

        public RES1001U00SaveLayoutArgs() { }

        public RES1001U00SaveLayoutArgs(String userId, List<RES1001U00SaveLayoutItemInfo> layoutItem, String hospCodeLink, String bookingType, String bunhoLink)
        {
            this._userId = userId;
            this._layoutItem = layoutItem;
            this._hospCodeLink = hospCodeLink;
            this._bookingType = bookingType;
            this._bunhoLink = bunhoLink;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.RES1001U00SaveLayoutRequest();
        }
    }
}