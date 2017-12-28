using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocso
{[Serializable]
	public class OcsoOCS1003P01GetChuciArgs : IContractArgs
	{
    protected bool Equals(OcsoOCS1003P01GetChuciArgs other)
    {
        return string.Equals(_codeType, other._codeType) && string.Equals(_valuePoint, other._valuePoint);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OcsoOCS1003P01GetChuciArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return ((_codeType != null ? _codeType.GetHashCode() : 0)*397) ^ (_valuePoint != null ? _valuePoint.GetHashCode() : 0);
        }
    }

    private String _codeType;
		private String _valuePoint;

		public String CodeType
		{
			get { return this._codeType; }
			set { this._codeType = value; }
		}

		public String ValuePoint
		{
			get { return this._valuePoint; }
			set { this._valuePoint = value; }
		}

		public OcsoOCS1003P01GetChuciArgs() { }

		public OcsoOCS1003P01GetChuciArgs(String codeType, String valuePoint)
		{
			this._codeType = codeType;
			this._valuePoint = valuePoint;
		}

		public IExtensible GetRequestInstance()
		{
			return new OcsoOCS1003P01GetChuciRequest();
		}
	}
}