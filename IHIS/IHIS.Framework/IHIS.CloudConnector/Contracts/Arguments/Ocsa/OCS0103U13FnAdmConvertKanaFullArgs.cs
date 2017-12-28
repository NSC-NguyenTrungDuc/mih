using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
	public class OCS0103U13FnAdmConvertKanaFullArgs : IContractArgs
	{
    protected bool Equals(OCS0103U13FnAdmConvertKanaFullArgs other)
    {
        return string.Equals(_searchWord, other._searchWord);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS0103U13FnAdmConvertKanaFullArgs) obj);
    }

    public override int GetHashCode()
    {
        return (_searchWord != null ? _searchWord.GetHashCode() : 0);
    }

    private String _searchWord;

		public String SearchWord
		{
			get { return this._searchWord; }
			set { this._searchWord = value; }
		}

		public OCS0103U13FnAdmConvertKanaFullArgs() { }

		public OCS0103U13FnAdmConvertKanaFullArgs(String searchWord)
		{
			this._searchWord = searchWord;
		}

		public IExtensible GetRequestInstance()
		{
			return new OCS0103U13FnAdmConvertKanaFullRequest();
		}
	}
}