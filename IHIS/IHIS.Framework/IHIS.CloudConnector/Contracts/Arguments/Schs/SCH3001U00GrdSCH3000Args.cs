using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Schs
{[Serializable]
	public class SCH3001U00GrdSCH3000Args : IContractArgs
	{
    protected bool Equals(SCH3001U00GrdSCH3000Args other)
    {
        return string.Equals(_jukyongDate, other._jukyongDate) && string.Equals(_jundalTable, other._jundalTable) && string.Equals(_jundalPart, other._jundalPart) && string.Equals(_gumsaja, other._gumsaja) && string.Equals(_yoilGubun, other._yoilGubun);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((SCH3001U00GrdSCH3000Args) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_jukyongDate != null ? _jukyongDate.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_jundalTable != null ? _jundalTable.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_jundalPart != null ? _jundalPart.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_gumsaja != null ? _gumsaja.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_yoilGubun != null ? _yoilGubun.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _jukyongDate;
		private String _jundalTable;
		private String _jundalPart;
		private String _gumsaja;
		private String _yoilGubun;

		public String JukyongDate
		{
			get { return this._jukyongDate; }
			set { this._jukyongDate = value; }
		}

		public String JundalTable
		{
			get { return this._jundalTable; }
			set { this._jundalTable = value; }
		}

		public String JundalPart
		{
			get { return this._jundalPart; }
			set { this._jundalPart = value; }
		}

		public String Gumsaja
		{
			get { return this._gumsaja; }
			set { this._gumsaja = value; }
		}

		public String YoilGubun
		{
			get { return this._yoilGubun; }
			set { this._yoilGubun = value; }
		}

		public SCH3001U00GrdSCH3000Args() { }

		public SCH3001U00GrdSCH3000Args(String jukyongDate, String jundalTable, String jundalPart, String gumsaja, String yoilGubun)
		{
			this._jukyongDate = jukyongDate;
			this._jundalTable = jundalTable;
			this._jundalPart = jundalPart;
			this._gumsaja = gumsaja;
			this._yoilGubun = yoilGubun;
		}

		public IExtensible GetRequestInstance()
		{
			return new SCH3001U00GrdSCH3000Request();
		}
	}
}