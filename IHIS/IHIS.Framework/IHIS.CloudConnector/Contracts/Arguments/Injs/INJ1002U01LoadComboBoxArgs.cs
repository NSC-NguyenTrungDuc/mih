using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Injs
{
    [Serializable]
	public class INJ1002U01LoadComboBoxArgs : IContractArgs
	{
        protected bool Equals(INJ1002U01LoadComboBoxArgs other)
        {
            return true;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((INJ1002U01LoadComboBoxArgs) obj);
        }

        public override int GetHashCode()
        {
            return 0;
        }

        public INJ1002U01LoadComboBoxArgs() { }

		public IExtensible GetRequestInstance()
		{
			return new INJ1002U01LoadComboBoxRequest();
		}
	}
}