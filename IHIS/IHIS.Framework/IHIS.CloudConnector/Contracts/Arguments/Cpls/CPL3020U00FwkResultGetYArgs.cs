using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Cpls
{
    [Serializable]
	public class CPL3020U00FwkResultGetYArgs : IContractArgs
	{
        protected bool Equals(CPL3020U00FwkResultGetYArgs other)
        {
            return string.Equals(_resultForm, other._resultForm);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CPL3020U00FwkResultGetYArgs) obj);
        }

        public override int GetHashCode()
        {
            return (_resultForm != null ? _resultForm.GetHashCode() : 0);
        }

        private String _resultForm;

		public String ResultForm
		{
			get { return this._resultForm; }
			set { this._resultForm = value; }
		}

		public CPL3020U00FwkResultGetYArgs() { }

		public CPL3020U00FwkResultGetYArgs(String resultForm)
		{
			this._resultForm = resultForm;
		}

		public IExtensible GetRequestInstance()
		{
			return new CPL3020U00FwkResultGetYRequest();
		}
	}
}