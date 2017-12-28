using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;
using DrgsDRG5100P01OrderListItemInfo = IHIS.CloudConnector.Contracts.Models.Drgs.DrgsDRG5100P01OrderListItemInfo;

namespace IHIS.CloudConnector.Contracts.Arguments.Drgs
{
    [Serializable]
	public class DrgsDRG5100P01LayBongtuArgs : IContractArgs
	{
        protected bool Equals(DrgsDRG5100P01LayBongtuArgs other)
        {
            return Equals(_gridOrderItem, other._gridOrderItem);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((DrgsDRG5100P01LayBongtuArgs) obj);
        }

        public override int GetHashCode()
        {
            return (_gridOrderItem != null ? _gridOrderItem.GetHashCode() : 0);
        }

        private List<DrgsDRG5100P01OrderListItemInfo> _gridOrderItem = new List<DrgsDRG5100P01OrderListItemInfo>();

		public List<DrgsDRG5100P01OrderListItemInfo> GridOrderItem
		{
			get { return this._gridOrderItem; }
			set { this._gridOrderItem = value; }
		}

		public DrgsDRG5100P01LayBongtuArgs() { }

		public DrgsDRG5100P01LayBongtuArgs(List<DrgsDRG5100P01OrderListItemInfo> gridOrderItem)
		{
			this._gridOrderItem = gridOrderItem;
		}

		public IExtensible GetRequestInstance()
		{
			return new DrgsDRG5100P01LayBongtuRequest();
		}
	}
}