using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.System
{[Serializable]
	public class AdmMessageCallArgs : IContractArgs
	{
    protected bool Equals(AdmMessageCallArgs other)
    {
        return string.Equals(_senderId, other._senderId) && string.Equals(_recieverGubun, other._recieverGubun) && string.Equals(_recieverId, other._recieverId) && string.Equals(_title, other._title) && string.Equals(_data, other._data) && string.Equals(_userId, other._userId);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((AdmMessageCallArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_senderId != null ? _senderId.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_recieverGubun != null ? _recieverGubun.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_recieverId != null ? _recieverId.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_title != null ? _title.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_data != null ? _data.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_userId != null ? _userId.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _senderId;
		private String _recieverGubun;
		private String _recieverId;
		private String _title;
		private String _data;
		private String _userId;

		public String SenderId
		{
			get { return this._senderId; }
			set { this._senderId = value; }
		}

		public String RecieverGubun
		{
			get { return this._recieverGubun; }
			set { this._recieverGubun = value; }
		}

		public String RecieverId
		{
			get { return this._recieverId; }
			set { this._recieverId = value; }
		}

		public String Title
		{
			get { return this._title; }
			set { this._title = value; }
		}

		public String Data
		{
			get { return this._data; }
			set { this._data = value; }
		}

		public String UserId
		{
			get { return this._userId; }
			set { this._userId = value; }
		}

		public AdmMessageCallArgs() { }

		public AdmMessageCallArgs(String senderId, String recieverGubun, String recieverId, String title, String data, String userId)
		{
			this._senderId = senderId;
			this._recieverGubun = recieverGubun;
			this._recieverId = recieverId;
			this._title = title;
			this._data = data;
			this._userId = userId;
		}

		public IExtensible GetRequestInstance()
		{
			return new AdmMessageCallRequest();
		}
	}
}