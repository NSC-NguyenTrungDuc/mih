using System;
using IHIS.CloudConnector.Contracts.Models.Ocso;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocso
{[Serializable]
    public class OCSACTGrdPaListArgs : IContractArgs
    {
    protected bool Equals(OCSACTGrdPaListArgs other)
    {
        return string.Equals(_cboSystem, other._cboSystem) && string.Equals(_cboVal, other._cboVal) && string.Equals(_cboPart, other._cboPart) && string.Equals(_fromDate, other._fromDate) && string.Equals(_toDate, other._toDate) && string.Equals(_bunho, other._bunho) && string.Equals(_actGubun, other._actGubun) && string.Equals(_jundalTableCode, other._jundalTableCode) && string.Equals(_ioGubun, other._ioGubun) && string.Equals(_systemId, other._systemId);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCSACTGrdPaListArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_cboSystem != null ? _cboSystem.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_cboVal != null ? _cboVal.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_cboPart != null ? _cboPart.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_fromDate != null ? _fromDate.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_toDate != null ? _toDate.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_bunho != null ? _bunho.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_actGubun != null ? _actGubun.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_jundalTableCode != null ? _jundalTableCode.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_ioGubun != null ? _ioGubun.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_systemId != null ? _systemId.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _cboSystem;
        private String _cboVal;
        private String _cboPart;
        private String _fromDate;
        private String _toDate;
        private String _bunho;
        private String _actGubun;
        private String _jundalTableCode;
        private String _ioGubun;
        private String _systemId;

        public String CboSystem
        {
            get { return this._cboSystem; }
            set { this._cboSystem = value; }
        }

        public String CboVal
        {
            get { return this._cboVal; }
            set { this._cboVal = value; }
        }

        public String CboPart
        {
            get { return this._cboPart; }
            set { this._cboPart = value; }
        }

        public String FromDate
        {
            get { return this._fromDate; }
            set { this._fromDate = value; }
        }

        public String ToDate
        {
            get { return this._toDate; }
            set { this._toDate = value; }
        }

        public String Bunho
        {
            get { return this._bunho; }
            set { this._bunho = value; }
        }

        public String ActGubun
        {
            get { return this._actGubun; }
            set { this._actGubun = value; }
        }

        public String JundalTableCode
        {
            get { return this._jundalTableCode; }
            set { this._jundalTableCode = value; }
        }

        public String IoGubun
        {
            get { return this._ioGubun; }
            set { this._ioGubun = value; }
        }

        public String SystemId
        {
            get { return this._systemId; }
            set { this._systemId = value; }
        }

        public OCSACTGrdPaListArgs() { }

        public OCSACTGrdPaListArgs(String cboSystem, String cboVal, String cboPart, String fromDate, String toDate, String bunho, String actGubun, String jundalTableCode, String ioGubun, String systemId)
        {
            this._cboSystem = cboSystem;
            this._cboVal = cboVal;
            this._cboPart = cboPart;
            this._fromDate = fromDate;
            this._toDate = toDate;
            this._bunho = bunho;
            this._actGubun = actGubun;
            this._jundalTableCode = jundalTableCode;
            this._ioGubun = ioGubun;
            this._systemId = systemId;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OCSACTGrdPaListRequest();
        }
    }
}