using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Injs
{
    [Serializable]
	public class InjsINJ1001U01ScheduleArgs : IContractArgs
	{
        protected bool Equals(InjsINJ1001U01ScheduleArgs other)
        {
            return string.Equals(_bunho, other._bunho) && string.Equals(_orderDate, other._orderDate) && string.Equals(_postOrderYn, other._postOrderYn) && string.Equals(_preOrderYn, other._preOrderYn) && string.Equals(_reserDate, other._reserDate) && string.Equals(_actingFlag, other._actingFlag);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((InjsINJ1001U01ScheduleArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_bunho != null ? _bunho.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_orderDate != null ? _orderDate.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_postOrderYn != null ? _postOrderYn.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_preOrderYn != null ? _preOrderYn.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_reserDate != null ? _reserDate.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_actingFlag != null ? _actingFlag.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _bunho;
		private String _orderDate;
		private String _postOrderYn;
		private String _preOrderYn;
		private String _reserDate;
		private String _actingFlag;

		public String Bunho
		{
			get { return this._bunho; }
			set { this._bunho = value; }
		}

		public String OrderDate
		{
			get { return this._orderDate; }
			set { this._orderDate = value; }
		}

		public String PostOrderYn
		{
			get { return this._postOrderYn; }
			set { this._postOrderYn = value; }
		}

		public String PreOrderYn
		{
			get { return this._preOrderYn; }
			set { this._preOrderYn = value; }
		}

		public String ReserDate
		{
			get { return this._reserDate; }
			set { this._reserDate = value; }
		}

		public String ActingFlag
		{
			get { return this._actingFlag; }
			set { this._actingFlag = value; }
		}

		public InjsINJ1001U01ScheduleArgs() { }

		public InjsINJ1001U01ScheduleArgs(String bunho, String orderDate, String postOrderYn, String preOrderYn, String reserDate, String actingFlag)
		{
			this._bunho = bunho;
			this._orderDate = orderDate;
			this._postOrderYn = postOrderYn;
			this._preOrderYn = preOrderYn;
			this._reserDate = reserDate;
			this._actingFlag = actingFlag;
		}

		public IExtensible GetRequestInstance()
		{
			return new InjsINJ1001U01ScheduleRequest();
		}
	}
}