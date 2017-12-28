using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Cpls
{
    [Serializable]
	public class AbleInsteadOrderArgs : IContractArgs
	{
        protected bool Equals(AbleInsteadOrderArgs other)
        {
            return Equals(_info1, other._info1);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((AbleInsteadOrderArgs) obj);
        }

        public override int GetHashCode()
        {
            return (_info1 != null ? _info1.GetHashCode() : 0);
        }

        private AbleInsteadOrderInfo _info1;

		public AbleInsteadOrderInfo Info1
		{
			get { return this._info1; }
			set { this._info1 = value; }
		}

		public AbleInsteadOrderArgs() { }

		public AbleInsteadOrderArgs(AbleInsteadOrderInfo info1)
		{
			this._info1 = info1;
		}

		public IExtensible GetRequestInstance()
		{
			return new AbleInsteadOrderRequest();
		}
	}
}