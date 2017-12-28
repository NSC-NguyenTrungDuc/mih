using System;
using IHIS.CloudConnector.Contracts.Models.Ocso;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocso
{[Serializable]
    public class OCSACTGrdOrderArgs : IContractArgs
    {
    protected bool Equals(OCSACTGrdOrderArgs other)
    {
        return _rbxNonAct.Equals(other._rbxNonAct) && _rbxAct.Equals(other._rbxAct) && string.Equals(_cboSystem, other._cboSystem) && string.Equals(_cboVal, other._cboVal) && string.Equals(_ioGubun, other._ioGubun) && string.Equals(_actGubun, other._actGubun) && string.Equals(_fromDate, other._fromDate) && string.Equals(_toDate, other._toDate) && string.Equals(_jundalTableCode, other._jundalTableCode) && string.Equals(_jundalPart, other._jundalPart) && string.Equals(_bunho, other._bunho) && string.Equals(_gwa, other._gwa) && string.Equals(_doctor, other._doctor) && string.Equals(_systemId, other._systemId) && string.Equals(_cboPart, other._cboPart);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCSACTGrdOrderArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = _rbxNonAct.GetHashCode();
            hashCode = (hashCode*397) ^ _rbxAct.GetHashCode();
            hashCode = (hashCode*397) ^ (_cboSystem != null ? _cboSystem.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_cboVal != null ? _cboVal.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_ioGubun != null ? _ioGubun.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_actGubun != null ? _actGubun.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_fromDate != null ? _fromDate.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_toDate != null ? _toDate.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_jundalTableCode != null ? _jundalTableCode.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_jundalPart != null ? _jundalPart.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_bunho != null ? _bunho.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_gwa != null ? _gwa.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_doctor != null ? _doctor.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_systemId != null ? _systemId.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_cboPart != null ? _cboPart.GetHashCode() : 0);
            return hashCode;
        }
    }

    private Boolean _rbxNonAct;
        private Boolean _rbxAct;
        private String _cboSystem;
        private String _cboVal;
        private String _ioGubun;
        private String _actGubun;
        private String _fromDate;
        private String _toDate;
        private String _jundalTableCode;
        private String _jundalPart;
        private String _bunho;
        private String _gwa;
        private String _doctor;
        private String _systemId;
        private String _cboPart;

        public Boolean RbxNonAct
        {
            get { return this._rbxNonAct; }
            set { this._rbxNonAct = value; }
        }

        public Boolean RbxAct
        {
            get { return this._rbxAct; }
            set { this._rbxAct = value; }
        }

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

        public String IoGubun
        {
            get { return this._ioGubun; }
            set { this._ioGubun = value; }
        }

        public String ActGubun
        {
            get { return this._actGubun; }
            set { this._actGubun = value; }
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

        public String JundalTableCode
        {
            get { return this._jundalTableCode; }
            set { this._jundalTableCode = value; }
        }

        public String JundalPart
        {
            get { return this._jundalPart; }
            set { this._jundalPart = value; }
        }

        public String Bunho
        {
            get { return this._bunho; }
            set { this._bunho = value; }
        }

        public String Gwa
        {
            get { return this._gwa; }
            set { this._gwa = value; }
        }

        public String Doctor
        {
            get { return this._doctor; }
            set { this._doctor = value; }
        }

        public String SystemId
        {
            get { return this._systemId; }
            set { this._systemId = value; }
        }

        public String CboPart
        {
            get { return this._cboPart; }
            set { this._cboPart = value; }
        }

        public OCSACTGrdOrderArgs() { }

        public OCSACTGrdOrderArgs(Boolean rbxNonAct, Boolean rbxAct, String cboSystem, String cboVal, String ioGubun, String actGubun, String fromDate, String toDate, String jundalTableCode, String jundalPart, String bunho, String gwa, String doctor, String systemId, String cboPart)
        {
            this._rbxNonAct = rbxNonAct;
            this._rbxAct = rbxAct;
            this._cboSystem = cboSystem;
            this._cboVal = cboVal;
            this._ioGubun = ioGubun;
            this._actGubun = actGubun;
            this._fromDate = fromDate;
            this._toDate = toDate;
            this._jundalTableCode = jundalTableCode;
            this._jundalPart = jundalPart;
            this._bunho = bunho;
            this._gwa = gwa;
            this._doctor = doctor;
            this._systemId = systemId;
            this._cboPart = cboPart;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OCSACTGrdOrderRequest();
        }
    }
}