using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuts
{
    [Serializable]
	public class NUT0001U00LoadDoctorNameArgs : IContractArgs
	{
        protected bool Equals(NUT0001U00LoadDoctorNameArgs other)
        {
            return string.Equals(_param, other._param);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((NUT0001U00LoadDoctorNameArgs) obj);
        }

        public override int GetHashCode()
        {
            return (_param != null ? _param.GetHashCode() : 0);
        }

        private String _param;

		public String Param
		{
			get { return this._param; }
			set { this._param = value; }
		}

		public NUT0001U00LoadDoctorNameArgs() { }

		public NUT0001U00LoadDoctorNameArgs(String param)
		{
			this._param = param;
		}

		public IExtensible GetRequestInstance()
		{
			return new NUT0001U00LoadDoctorNameRequest();
		}
	}
}