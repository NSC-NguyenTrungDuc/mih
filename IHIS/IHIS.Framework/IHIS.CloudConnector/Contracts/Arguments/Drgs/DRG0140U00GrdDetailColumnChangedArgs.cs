using System;
using ProtoBuf;
using IHIS.CloudConnector.Contracts.Models.Drgs;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Arguments.Drgs
{
    [Serializable]
	public class DRG0140U00GrdDetailColumnChangedArgs : IContractArgs
	{
        protected bool Equals(DRG0140U00GrdDetailColumnChangedArgs other)
        {
            return string.Equals(_changedValue, other._changedValue) && Equals(_gdcItem, other._gdcItem);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((DRG0140U00GrdDetailColumnChangedArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_changedValue != null ? _changedValue.GetHashCode() : 0)*397) ^ (_gdcItem != null ? _gdcItem.GetHashCode() : 0);
            }
        }

        private String _changedValue;
		private List<DRG0140U00GrdColumnChangedInfo> _gdcItem = new List<DRG0140U00GrdColumnChangedInfo>();

		public String ChangedValue
		{
			get { return this._changedValue; }
			set { this._changedValue = value; }
		}

		public List<DRG0140U00GrdColumnChangedInfo> GdcItem
		{
			get { return this._gdcItem; }
			set { this._gdcItem = value; }
		}

		public DRG0140U00GrdDetailColumnChangedArgs() { }

		public DRG0140U00GrdDetailColumnChangedArgs(String changedValue, List<DRG0140U00GrdColumnChangedInfo> gdcItem)
		{
			this._changedValue = changedValue;
			this._gdcItem = gdcItem;
		}

		public IExtensible GetRequestInstance()
		{
			return new IHIS.CloudConnector.Messaging.DRG0140U00GrdDetailColumnChangedRequest();
		}
	}
}