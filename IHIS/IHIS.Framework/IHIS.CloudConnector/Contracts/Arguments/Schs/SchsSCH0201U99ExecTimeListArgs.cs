using System;
using IHIS.CloudConnector.Contracts.Models.Schs;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Schs
{[Serializable]
    public class SchsSCH0201U99ExecTimeListArgs : IContractArgs
    {
    protected bool Equals(SchsSCH0201U99ExecTimeListArgs other)
    {
        return string.Equals(_iIpAddress, other._iIpAddress) && string.Equals(_iJundalTable, other._iJundalTable) && string.Equals(_iJundalPart, other._iJundalPart) && string.Equals(_iGumsaja, other._iGumsaja) && string.Equals(_iReserDate, other._iReserDate) && string.Equals(_hospCodeLink, other._hospCodeLink);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((SchsSCH0201U99ExecTimeListArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_iIpAddress != null ? _iIpAddress.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_iJundalTable != null ? _iJundalTable.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_iJundalPart != null ? _iJundalPart.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_iGumsaja != null ? _iGumsaja.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_iReserDate != null ? _iReserDate.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_hospCodeLink != null ? _hospCodeLink.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _iIpAddress;
        private String _iJundalTable;
        private String _iJundalPart;
        private String _iGumsaja;
        private String _iReserDate;
        private String _hospCodeLink;

        public String IIpAddress
        {
            get { return this._iIpAddress; }
            set { this._iIpAddress = value; }
        }

        public String IJundalTable
        {
            get { return this._iJundalTable; }
            set { this._iJundalTable = value; }
        }

        public String IJundalPart
        {
            get { return this._iJundalPart; }
            set { this._iJundalPart = value; }
        }

        public String IGumsaja
        {
            get { return this._iGumsaja; }
            set { this._iGumsaja = value; }
        }

        public String IReserDate
        {
            get { return this._iReserDate; }
            set { this._iReserDate = value; }
        }

        public String HospCodeLink
        {
            get { return this._hospCodeLink; }
            set { this._hospCodeLink = value; }
        }

        public SchsSCH0201U99ExecTimeListArgs() { }

        public SchsSCH0201U99ExecTimeListArgs(String iIpAddress, String iJundalTable, String iJundalPart, String iGumsaja, String iReserDate, String hospCodeLink)
        {
            this._iIpAddress = iIpAddress;
            this._iJundalTable = iJundalTable;
            this._iJundalPart = iJundalPart;
            this._iGumsaja = iGumsaja;
            this._iReserDate = iReserDate;
            this._hospCodeLink = hospCodeLink;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.SchsSCH0201U99ExecTimeListRequest();
        }
    }
}