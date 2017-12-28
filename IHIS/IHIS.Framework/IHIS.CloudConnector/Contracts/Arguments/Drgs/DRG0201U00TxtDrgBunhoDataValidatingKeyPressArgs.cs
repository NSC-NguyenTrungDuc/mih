using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Drgs
{
    [Serializable]
	public class DRG0201U00TxtDrgBunhoDataValidatingKeyPressArgs : IContractArgs
	{
        protected bool Equals(DRG0201U00TxtDrgBunhoDataValidatingKeyPressArgs other)
        {
            return string.Equals(_jubsuDate, other._jubsuDate) && string.Equals(_bunho, other._bunho);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((DRG0201U00TxtDrgBunhoDataValidatingKeyPressArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_jubsuDate != null ? _jubsuDate.GetHashCode() : 0)*397) ^ (_bunho != null ? _bunho.GetHashCode() : 0);
            }
        }

        private String _jubsuDate;
		private String _bunho;

		public String JubsuDate
		{
			get { return this._jubsuDate; }
			set { this._jubsuDate = value; }
		}

		public String Bunho
		{
			get { return this._bunho; }
			set { this._bunho = value; }
		}

		public DRG0201U00TxtDrgBunhoDataValidatingKeyPressArgs() { }

		public DRG0201U00TxtDrgBunhoDataValidatingKeyPressArgs(String jubsuDate, String bunho)
		{
			this._jubsuDate = jubsuDate;
			this._bunho = bunho;
		}

		public IExtensible GetRequestInstance()
		{
			return new DRG0201U00TxtDrgBunhoDataValidatingKeyPressRequest();
		}
	}
}