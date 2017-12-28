using System;
using IHIS.CloudConnector.Contracts.Models.Ocso;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocso
{
    public class OCSACT2GetGrdPaListArgs : IContractArgs
    {
        protected bool Equals(OCSACT2GetGrdPaListArgs other)
        {
            return string.Equals(_jundalTable, other._jundalTable) && string.Equals(_gwa, other._gwa) && string.Equals(_orderDateFrom, other._orderDateFrom) && string.Equals(_orderDateTo, other._orderDateTo) && string.Equals(_bunho, other._bunho) && string.Equals(_hospCode, other._hospCode) && string.Equals(_actingFlg, other._actingFlg);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((OCSACT2GetGrdPaListArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_jundalTable != null ? _jundalTable.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_gwa != null ? _gwa.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_orderDateFrom != null ? _orderDateFrom.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_orderDateTo != null ? _orderDateTo.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_bunho != null ? _bunho.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_hospCode != null ? _hospCode.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_actingFlg != null ? _actingFlg.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _jundalTable;
        private String _gwa;
        private String _orderDateFrom;
        private String _orderDateTo;
        private String _bunho;
        private String _hospCode;
        private String _actingFlg;

        public String JundalTable
        {
            get { return this._jundalTable; }
            set { this._jundalTable = value; }
        }

        public String Gwa
        {
            get { return this._gwa; }
            set { this._gwa = value; }
        }

        public String OrderDateFrom
        {
            get { return this._orderDateFrom; }
            set { this._orderDateFrom = value; }
        }

        public String OrderDateTo
        {
            get { return this._orderDateTo; }
            set { this._orderDateTo = value; }
        }

        public String Bunho
        {
            get { return this._bunho; }
            set { this._bunho = value; }
        }

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public String ActingFlg
        {
            get { return this._actingFlg; }
            set { this._actingFlg = value; }
        }

        public OCSACT2GetGrdPaListArgs() { }

        public OCSACT2GetGrdPaListArgs(String jundalTable, String gwa, String orderDateFrom, String orderDateTo, String bunho, String hospCode, String actingFlg)
        {
            this._jundalTable = jundalTable;
            this._gwa = gwa;
            this._orderDateFrom = orderDateFrom;
            this._orderDateTo = orderDateTo;
            this._bunho = bunho;
            this._hospCode = hospCode;
            this._actingFlg = actingFlg;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OCSACT2GetGrdPaListRequest();
        }
    }
}