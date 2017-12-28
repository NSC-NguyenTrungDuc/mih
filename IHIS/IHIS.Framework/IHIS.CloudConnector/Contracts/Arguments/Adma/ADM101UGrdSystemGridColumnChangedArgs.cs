using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Adma
{
    [Serializable]
	public class ADM101UGrdSystemGridColumnChangedArgs : IContractArgs
	{
        protected bool Equals(ADM101UGrdSystemGridColumnChangedArgs other)
        {
            return string.Equals(_buseoCode, other._buseoCode);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ADM101UGrdSystemGridColumnChangedArgs) obj);
        }

        public override int GetHashCode()
        {
            return (_buseoCode != null ? _buseoCode.GetHashCode() : 0);
        }

        private String _buseoCode;

		public String BuseoCode
		{
			get { return this._buseoCode; }
			set { this._buseoCode = value; }
		}

		public ADM101UGrdSystemGridColumnChangedArgs() { }

		public ADM101UGrdSystemGridColumnChangedArgs(String buseoCode)
		{
			this._buseoCode = buseoCode;
		}

		public IExtensible GetRequestInstance()
		{
			return new ADM101UGrdSystemGridColumnChangedRequest();
		}
	}
}