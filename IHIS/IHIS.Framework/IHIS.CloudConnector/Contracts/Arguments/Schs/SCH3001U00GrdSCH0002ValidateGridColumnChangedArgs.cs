using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Schs
{[Serializable]
	public class SCH3001U00GrdSCH0002ValidateGridColumnChangedArgs : IContractArgs
	{
    protected bool Equals(SCH3001U00GrdSCH0002ValidateGridColumnChangedArgs other)
    {
        return string.Equals(_hangmogCode, other._hangmogCode);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((SCH3001U00GrdSCH0002ValidateGridColumnChangedArgs) obj);
    }

    public override int GetHashCode()
    {
        return (_hangmogCode != null ? _hangmogCode.GetHashCode() : 0);
    }

    private String _hangmogCode;

		public String HangmogCode
		{
			get { return this._hangmogCode; }
			set { this._hangmogCode = value; }
		}

		public SCH3001U00GrdSCH0002ValidateGridColumnChangedArgs() { }

		public SCH3001U00GrdSCH0002ValidateGridColumnChangedArgs(String hangmogCode)
		{
			this._hangmogCode = hangmogCode;
		}

		public IExtensible GetRequestInstance()
		{
			return new SCH3001U00GrdSCH0002ValidateGridColumnChangedRequest();
		}
	}
}