using System;
using ProtoBuf;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Drgs;

namespace IHIS.CloudConnector.Contracts.Arguments.Drgs
{
    [Serializable]
	public class DRG0140U00GrdMasterColumnChangedArgs : IContractArgs
	{
        protected bool Equals(DRG0140U00GrdMasterColumnChangedArgs other)
        {
            return string.Equals(_changedValue, other._changedValue) && Equals(_gmcItem, other._gmcItem);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((DRG0140U00GrdMasterColumnChangedArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_changedValue != null ? _changedValue.GetHashCode() : 0)*397) ^ (_gmcItem != null ? _gmcItem.GetHashCode() : 0);
            }
        }

        private String _changedValue;
		private List<DRG0140U00GrdColumnChangedInfo> _gmcItem = new List<DRG0140U00GrdColumnChangedInfo>();

		public String ChangedValue
		{
			get { return this._changedValue; }
			set { this._changedValue = value; }
		}

		public List<DRG0140U00GrdColumnChangedInfo> GmcItem
		{
			get { return this._gmcItem; }
			set { this._gmcItem = value; }
		}

		public DRG0140U00GrdMasterColumnChangedArgs() { }

		public DRG0140U00GrdMasterColumnChangedArgs(String changedValue, List<DRG0140U00GrdColumnChangedInfo> gmcItem)
		{
			this._changedValue = changedValue;
			this._gmcItem = gmcItem;
		}

		public IExtensible GetRequestInstance()
		{
			return new IHIS.CloudConnector.Messaging.DRG0140U00GrdMasterColumnChangedRequest();
		}
	}
}