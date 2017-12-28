using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Chts
{
    [Serializable]
	public class CHT0117grdCHT0117CheckArgs : IContractArgs
	{
        protected bool Equals(CHT0117grdCHT0117CheckArgs other)
        {
            return string.Equals(_buwi, other._buwi);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CHT0117grdCHT0117CheckArgs) obj);
        }

        public override int GetHashCode()
        {
            return (_buwi != null ? _buwi.GetHashCode() : 0);
        }

        private String _buwi;

		public String Buwi
		{
			get { return this._buwi; }
			set { this._buwi = value; }
		}

		public CHT0117grdCHT0117CheckArgs() { }

		public CHT0117grdCHT0117CheckArgs(String buwi)
		{
			this._buwi = buwi;
		}

		public IExtensible GetRequestInstance()
		{
			return new CHT0117grdCHT0117CheckRequest();
		}
	}
}