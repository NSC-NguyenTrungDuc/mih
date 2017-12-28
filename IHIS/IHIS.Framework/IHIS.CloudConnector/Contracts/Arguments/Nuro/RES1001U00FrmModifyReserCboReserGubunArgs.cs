using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    [Serializable]
	public class RES1001U00FrmModifyReserCboReserGubunArgs : IContractArgs
	{
        protected bool Equals(RES1001U00FrmModifyReserCboReserGubunArgs other)
        {
            return true;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((RES1001U00FrmModifyReserCboReserGubunArgs) obj);
        }

        public override int GetHashCode()
        {
            return 0;
        }

        public RES1001U00FrmModifyReserCboReserGubunArgs() { }

		public IExtensible GetRequestInstance()
		{
			return new RES1001U00FrmModifyReserCboReserGubunRequest();
		}
	}
}