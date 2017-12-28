using System;
using IHIS.CloudConnector.Contracts.Models.Phys;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Phys
{[Serializable]
    public class PHY2001U04CreateAutoJubsuArgs : IContractArgs
    {
    protected bool Equals(PHY2001U04CreateAutoJubsuArgs other)
    {
        return string.Equals(_pkout1001, other._pkout1001) && string.Equals(_gwa, other._gwa) && string.Equals(_doctor, other._doctor) && string.Equals(_jubsuGubun, other._jubsuGubun) && string.Equals(_bunho, other._bunho) && string.Equals(_naewonDate, other._naewonDate) && string.Equals(_orderDate, other._orderDate) && string.Equals(_fkout1001, other._fkout1001) && string.Equals(_sinryouryouGubun, other._sinryouryouGubun) && string.Equals(_inputId, other._inputId) && string.Equals(_inputTab, other._inputTab) && string.Equals(_iudGubun, other._iudGubun) && _cbxSinryouryou.Equals(other._cbxSinryouryou) && string.Equals(_userId, other._userId);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((PHY2001U04CreateAutoJubsuArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_pkout1001 != null ? _pkout1001.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_gwa != null ? _gwa.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_doctor != null ? _doctor.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_jubsuGubun != null ? _jubsuGubun.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_bunho != null ? _bunho.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_naewonDate != null ? _naewonDate.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_orderDate != null ? _orderDate.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_fkout1001 != null ? _fkout1001.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_sinryouryouGubun != null ? _sinryouryouGubun.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_inputId != null ? _inputId.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_inputTab != null ? _inputTab.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_iudGubun != null ? _iudGubun.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ _cbxSinryouryou.GetHashCode();
            hashCode = (hashCode*397) ^ (_userId != null ? _userId.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _pkout1001;
        private String _gwa;
        private String _doctor;
        private String _jubsuGubun;
        private String _userId;
        private String _bunho;
        private String _naewonDate;
        private String _orderDate;
        private String _fkout1001;
        private String _sinryouryouGubun;
        private String _inputId;
        private String _inputTab;
        private String _iudGubun;
        private Boolean _cbxSinryouryou;

        public String Pkout1001
        {
            get { return this._pkout1001; }
            set { this._pkout1001 = value; }
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

        public String JubsuGubun
        {
            get { return this._jubsuGubun; }
            set { this._jubsuGubun = value; }
        }

        public String UserId
        {
            get { return this._userId; }
            set { this._userId = value; }
        }

        public String Bunho
        {
            get { return this._bunho; }
            set { this._bunho = value; }
        }

        public String NaewonDate
        {
            get { return this._naewonDate; }
            set { this._naewonDate = value; }
        }

        public String OrderDate
        {
            get { return this._orderDate; }
            set { this._orderDate = value; }
        }

        public String Fkout1001
        {
            get { return this._fkout1001; }
            set { this._fkout1001 = value; }
        }

        public String SinryouryouGubun
        {
            get { return this._sinryouryouGubun; }
            set { this._sinryouryouGubun = value; }
        }

        public String InputId
        {
            get { return this._inputId; }
            set { this._inputId = value; }
        }

        public String InputTab
        {
            get { return this._inputTab; }
            set { this._inputTab = value; }
        }

        public String IudGubun
        {
            get { return this._iudGubun; }
            set { this._iudGubun = value; }
        }

        public Boolean CbxSinryouryou
        {
            get { return this._cbxSinryouryou; }
            set { this._cbxSinryouryou = value; }
        }

        public PHY2001U04CreateAutoJubsuArgs() { }

        public PHY2001U04CreateAutoJubsuArgs(String pkout1001, String gwa, String doctor, String jubsuGubun, String userId, String bunho, String naewonDate, String orderDate, String fkout1001, String sinryouryouGubun, String inputId, String inputTab, String iudGubun, Boolean cbxSinryouryou)
        {
            this._pkout1001 = pkout1001;
            this._gwa = gwa;
            this._doctor = doctor;
            this._jubsuGubun = jubsuGubun;
            this._userId = userId;
            this._bunho = bunho;
            this._naewonDate = naewonDate;
            this._orderDate = orderDate;
            this._fkout1001 = fkout1001;
            this._sinryouryouGubun = sinryouryouGubun;
            this._inputId = inputId;
            this._inputTab = inputTab;
            this._iudGubun = iudGubun;
            this._cbxSinryouryou = cbxSinryouryou;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.PHY2001U04CreateAutoJubsuRequest();
        }
    }
}