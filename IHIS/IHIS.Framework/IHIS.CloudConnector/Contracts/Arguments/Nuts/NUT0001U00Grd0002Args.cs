using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuts
{
    [Serializable]
	public class NUT0001U00Grd0002Args : IContractArgs
	{
        protected bool Equals(NUT0001U00Grd0002Args other)
        {
            return string.Equals(_fknut0001, other._fknut0001);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((NUT0001U00Grd0002Args) obj);
        }

        public override int GetHashCode()
        {
            return (_fknut0001 != null ? _fknut0001.GetHashCode() : 0);
        }

        private String _fknut0001;

		public String Fknut0001
		{
			get { return this._fknut0001; }
			set { this._fknut0001 = value; }
		}

		public NUT0001U00Grd0002Args() { }

		public NUT0001U00Grd0002Args(String fknut0001)
		{
			this._fknut0001 = fknut0001;
		}

		public IExtensible GetRequestInstance()
		{
			return new NUT0001U00Grd0002Request();
		}
	}
}