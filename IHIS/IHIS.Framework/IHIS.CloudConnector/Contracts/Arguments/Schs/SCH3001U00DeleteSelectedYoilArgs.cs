using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;
using DataStringListItemInfo = IHIS.CloudConnector.Contracts.Models.System.DataStringListItemInfo;

namespace IHIS.CloudConnector.Contracts.Arguments.Schs
{[Serializable]
	public class SCH3001U00DeleteSelectedYoilArgs : IContractArgs
	{
    protected bool Equals(SCH3001U00DeleteSelectedYoilArgs other)
    {
        return string.Equals(_jukyongDate, other._jukyongDate) && string.Equals(_jundalTable, other._jundalTable) && string.Equals(_jundalPart, other._jundalPart) && Equals(_selectedYoil, other._selectedYoil) && string.Equals(_gumsaja, other._gumsaja);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((SCH3001U00DeleteSelectedYoilArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_jukyongDate != null ? _jukyongDate.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_jundalTable != null ? _jundalTable.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_jundalPart != null ? _jundalPart.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_selectedYoil != null ? _selectedYoil.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_gumsaja != null ? _gumsaja.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _jukyongDate;
		private String _jundalTable;
		private String _jundalPart;
		private List<DataStringListItemInfo> _selectedYoil = new List<DataStringListItemInfo>();
		private String _gumsaja;

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

		public List<DataStringListItemInfo> SelectedYoil
		{
			get { return this._selectedYoil; }
			set { this._selectedYoil = value; }
		}

		public String Gumsaja
		{
			get { return this._gumsaja; }
			set { this._gumsaja = value; }
		}

		public SCH3001U00DeleteSelectedYoilArgs() { }

		public SCH3001U00DeleteSelectedYoilArgs(String jukyongDate, String jundalTable, String jundalPart, List<DataStringListItemInfo> selectedYoil, String gumsaja)
		{
			this._jukyongDate = jukyongDate;
			this._jundalTable = jundalTable;
			this._jundalPart = jundalPart;
			this._selectedYoil = selectedYoil;
			this._gumsaja = gumsaja;
		}

		public IExtensible GetRequestInstance()
		{
			return new SCH3001U00DeleteSelectedYoilRequest();
		}
	}
}