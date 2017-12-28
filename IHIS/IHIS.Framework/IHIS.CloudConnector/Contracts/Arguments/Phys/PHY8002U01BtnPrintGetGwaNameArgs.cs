using System;
using IHIS.CloudConnector.Contracts.Models.Phys;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Phys
{
    [Serializable]
    public class PHY8002U01BtnPrintGetGwaNameArgs : IContractArgs
    {
        protected bool Equals(PHY8002U01BtnPrintGetGwaNameArgs other)
        {
            return string.Equals(_colName, other._colName) && string.Equals(_startDate, other._startDate) && string.Equals(_endDate, other._endDate) && string.Equals(_gwa, other._gwa) && string.Equals(_iraiDate, other._iraiDate);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((PHY8002U01BtnPrintGetGwaNameArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_colName != null ? _colName.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_startDate != null ? _startDate.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_endDate != null ? _endDate.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_gwa != null ? _gwa.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_iraiDate != null ? _iraiDate.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _colName;
        private String _startDate;
        private String _endDate;
        private String _gwa;
        private String _iraiDate;

        public String ColName
        {
            get { return this._colName; }
            set { this._colName = value; }
        }

        public String StartDate
        {
            get { return this._startDate; }
            set { this._startDate = value; }
        }

        public String EndDate
        {
            get { return this._endDate; }
            set { this._endDate = value; }
        }

        public String Gwa
        {
            get { return this._gwa; }
            set { this._gwa = value; }
        }

        public String IraiDate
        {
            get { return this._iraiDate; }
            set { this._iraiDate = value; }
        }

        public PHY8002U01BtnPrintGetGwaNameArgs() { }

        public PHY8002U01BtnPrintGetGwaNameArgs(String colName, String startDate, String endDate, String gwa, String iraiDate)
        {
            this._colName = colName;
            this._startDate = startDate;
            this._endDate = endDate;
            this._gwa = gwa;
            this._iraiDate = iraiDate;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.PHY8002U01BtnPrintGetGwaNameRequest();
        }
    }
}