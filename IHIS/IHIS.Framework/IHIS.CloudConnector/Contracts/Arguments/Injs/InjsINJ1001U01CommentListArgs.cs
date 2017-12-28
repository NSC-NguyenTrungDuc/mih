using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Injs
{
    [Serializable]
	public class InjsINJ1001U01CommentListArgs : IContractArgs
	{
        protected bool Equals(InjsINJ1001U01CommentListArgs other)
        {
            return string.Equals(_bunho, other._bunho) && string.Equals(_commtGubun, other._commtGubun);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((InjsINJ1001U01CommentListArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_bunho != null ? _bunho.GetHashCode() : 0)*397) ^ (_commtGubun != null ? _commtGubun.GetHashCode() : 0);
            }
        }

        private String _bunho;
		private String _commtGubun;

		public String Bunho
		{
			get { return this._bunho; }
			set { this._bunho = value; }
		}

		public String CommtGubun
		{
			get { return this._commtGubun; }
			set { this._commtGubun = value; }
		}

		public InjsINJ1001U01CommentListArgs() { }

		public InjsINJ1001U01CommentListArgs(String bunho, String commtGubun)
		{
			this._bunho = bunho;
			this._commtGubun = commtGubun;
		}

		public IExtensible GetRequestInstance()
		{
			return new InjsINJ1001U01CommentListRequest();
		}
	}
}