using System;
using IHIS.CloudConnector.Contracts.Models.Schs;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Schs
{[Serializable]
    public class SchsSCH0201U99DateScheduleListArgs : IContractArgs
    {
    protected bool Equals(SchsSCH0201U99DateScheduleListArgs other)
    {
        return string.Equals(_fStartDate, other._fStartDate) && string.Equals(_fJundalTable, other._fJundalTable) && string.Equals(_fJundalPart, other._fJundalPart) && string.Equals(_fHangmogCode, other._fHangmogCode) && string.Equals(_outHospLink, other._outHospLink);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((SchsSCH0201U99DateScheduleListArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_fStartDate != null ? _fStartDate.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_fJundalTable != null ? _fJundalTable.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_fJundalPart != null ? _fJundalPart.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_fHangmogCode != null ? _fHangmogCode.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_outHospLink != null ? _outHospLink.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _fStartDate;
        private String _fJundalTable;
        private String _fJundalPart;
        private String _fHangmogCode;
        private String _outHospLink;

        public String FStartDate
        {
            get { return this._fStartDate; }
            set { this._fStartDate = value; }
        }

        public String FJundalTable
        {
            get { return this._fJundalTable; }
            set { this._fJundalTable = value; }
        }

        public String FJundalPart
        {
            get { return this._fJundalPart; }
            set { this._fJundalPart = value; }
        }

        public String FHangmogCode
        {
            get { return this._fHangmogCode; }
            set { this._fHangmogCode = value; }
        }

        public String OutHospLink
        {
            get { return this._outHospLink; }
            set { this._outHospLink = value; }
        }

        public SchsSCH0201U99DateScheduleListArgs() { }

        public SchsSCH0201U99DateScheduleListArgs(String fStartDate, String fJundalTable, String fJundalPart, String fHangmogCode, String outHospLink)
        {
            this._fStartDate = fStartDate;
            this._fJundalTable = fJundalTable;
            this._fJundalPart = fJundalPart;
            this._fHangmogCode = fHangmogCode;
            this._outHospLink = outHospLink;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.SchsSCH0201U99DateScheduleListRequest();
        }
    }
}