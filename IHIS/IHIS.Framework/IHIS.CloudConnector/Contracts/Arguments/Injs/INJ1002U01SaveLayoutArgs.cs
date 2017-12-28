using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;
using INJ1002U01GrdOrderListItemInfo = IHIS.CloudConnector.Contracts.Models.Injs.INJ1002U01GrdOrderListItemInfo;

namespace IHIS.CloudConnector.Contracts.Arguments.Injs
{
    [Serializable]
	public class INJ1002U01SaveLayoutArgs : IContractArgs
	{
        protected bool Equals(INJ1002U01SaveLayoutArgs other)
        {
            return Equals(_grdOrderInfo, other._grdOrderInfo);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((INJ1002U01SaveLayoutArgs) obj);
        }

        public override int GetHashCode()
        {
            return (_grdOrderInfo != null ? _grdOrderInfo.GetHashCode() : 0);
        }

        private List<INJ1002U01GrdOrderListItemInfo> _grdOrderInfo = new List<INJ1002U01GrdOrderListItemInfo>();

		public List<INJ1002U01GrdOrderListItemInfo> GrdOrderInfo
		{
			get { return this._grdOrderInfo; }
			set { this._grdOrderInfo = value; }
		}

		public INJ1002U01SaveLayoutArgs() { }

		public INJ1002U01SaveLayoutArgs(List<INJ1002U01GrdOrderListItemInfo> grdOrderInfo)
		{
			this._grdOrderInfo = grdOrderInfo;
		}

		public IExtensible GetRequestInstance()
		{
			return new INJ1002U01SaveLayoutRequest();
		}
	}
}