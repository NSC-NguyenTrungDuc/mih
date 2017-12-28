using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    [Serializable]
	public class InitializeComboListItemArgs : IContractArgs
	{
	    protected bool Equals(InitializeComboListItemArgs other)
	    {
	        return string.Equals(_codeType, other._codeType) && string.Equals(_comboTimeType, other._comboTimeType) && string.Equals(_codeTypeCboTel, other._codeTypeCboTel) && string.Equals(_codeTypeChojae, other._codeTypeChojae);
	    }

	    public override bool Equals(object obj)
	    {
	        if (ReferenceEquals(null, obj)) return false;
	        if (ReferenceEquals(this, obj)) return true;
	        if (obj.GetType() != this.GetType()) return false;
	        return Equals((InitializeComboListItemArgs) obj);
	    }

	    public override int GetHashCode()
	    {
	        unchecked
	        {
	            int hashCode = (_codeType != null ? _codeType.GetHashCode() : 0);
	            hashCode = (hashCode*397) ^ (_comboTimeType != null ? _comboTimeType.GetHashCode() : 0);
	            hashCode = (hashCode*397) ^ (_codeTypeCboTel != null ? _codeTypeCboTel.GetHashCode() : 0);
	            hashCode = (hashCode*397) ^ (_codeTypeChojae != null ? _codeTypeChojae.GetHashCode() : 0);
	            return hashCode;
	        }
	    }

	    private String _codeType;
		private String _comboTimeType;
		private String _codeTypeCboTel;
		private String _codeTypeChojae;

		public String CodeType
		{
			get { return this._codeType; }
			set { this._codeType = value; }
		}

		public String ComboTimeType
		{
			get { return this._comboTimeType; }
			set { this._comboTimeType = value; }
		}

		public String CodeTypeCboTel
		{
			get { return this._codeTypeCboTel; }
			set { this._codeTypeCboTel = value; }
		}

		public String CodeTypeChojae
		{
			get { return this._codeTypeChojae; }
			set { this._codeTypeChojae = value; }
		}

		public InitializeComboListItemArgs() { }

		public InitializeComboListItemArgs(String codeType, String comboTimeType, String codeTypeCboTel, String codeTypeChojae)
		{
			this._codeType = codeType;
			this._comboTimeType = comboTimeType;
			this._codeTypeCboTel = codeTypeCboTel;
			this._codeTypeChojae = codeTypeChojae;
		}

		public IExtensible GetRequestInstance()
		{
			return new InitializeComboListItemRequest();
		}
	}
}