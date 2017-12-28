using System;
using IHIS.CloudConnector.Contracts.Models.Phys;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Phys
{[Serializable]
    public class PHY2001U04GrdPatientListItemValueChangingArgs : IContractArgs
    {
    protected bool Equals(PHY2001U04GrdPatientListItemValueChangingArgs other)
    {
        return string.Equals(_orderDate, other._orderDate) && string.Equals(_bunho, other._bunho) && string.Equals(_fkout1001, other._fkout1001) && string.Equals(_doctor, other._doctor) && string.Equals(_sinryouryouGubun, other._sinryouryouGubun) && string.Equals(_inputId, other._inputId) && string.Equals(_inputTab, other._inputTab) && string.Equals(_iudGubun, other._iudGubun) && string.Equals(_naewonYn, other._naewonYn) && string.Equals(_arriveTime, other._arriveTime) && string.Equals(_jubsuGubun, other._jubsuGubun) && string.Equals(_previousValue, other._previousValue) && string.Equals(_changedValue, other._changedValue) && string.Equals(_userId, other._userId) && _cbxSinryouryou.Equals(other._cbxSinryouryou);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((PHY2001U04GrdPatientListItemValueChangingArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_orderDate != null ? _orderDate.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_bunho != null ? _bunho.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_fkout1001 != null ? _fkout1001.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_doctor != null ? _doctor.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_sinryouryouGubun != null ? _sinryouryouGubun.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_inputId != null ? _inputId.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_inputTab != null ? _inputTab.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_iudGubun != null ? _iudGubun.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_naewonYn != null ? _naewonYn.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_arriveTime != null ? _arriveTime.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_jubsuGubun != null ? _jubsuGubun.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_previousValue != null ? _previousValue.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_changedValue != null ? _changedValue.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_userId != null ? _userId.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ _cbxSinryouryou.GetHashCode();
            return hashCode;
        }
    }

    private String _orderDate;
        private String _bunho;
        private String _fkout1001;
        private String _doctor;
        private String _sinryouryouGubun;
        private String _inputId;
        private String _inputTab;
        private String _iudGubun;
        private String _naewonYn;
        private String _arriveTime;
        private String _jubsuGubun;
        private String _previousValue;
        private String _changedValue;
        private String _userId;
        private Boolean _cbxSinryouryou;

        public String OrderDate
        {
            get { return this._orderDate; }
            set { this._orderDate = value; }
        }

        public String Bunho
        {
            get { return this._bunho; }
            set { this._bunho = value; }
        }

        public String Fkout1001
        {
            get { return this._fkout1001; }
            set { this._fkout1001 = value; }
        }

        public String Doctor
        {
            get { return this._doctor; }
            set { this._doctor = value; }
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

        public String NaewonYn
        {
            get { return this._naewonYn; }
            set { this._naewonYn = value; }
        }

        public String ArriveTime
        {
            get { return this._arriveTime; }
            set { this._arriveTime = value; }
        }

        public String JubsuGubun
        {
            get { return this._jubsuGubun; }
            set { this._jubsuGubun = value; }
        }

        public String PreviousValue
        {
            get { return this._previousValue; }
            set { this._previousValue = value; }
        }

        public String ChangedValue
        {
            get { return this._changedValue; }
            set { this._changedValue = value; }
        }

        public String UserId
        {
            get { return this._userId; }
            set { this._userId = value; }
        }

        public Boolean CbxSinryouryou
        {
            get { return this._cbxSinryouryou; }
            set { this._cbxSinryouryou = value; }
        }

        public PHY2001U04GrdPatientListItemValueChangingArgs() { }

        public PHY2001U04GrdPatientListItemValueChangingArgs(String orderDate, String bunho, String fkout1001, String doctor, String sinryouryouGubun, String inputId, String inputTab, String iudGubun, String naewonYn, String arriveTime, String jubsuGubun, String previousValue, String changedValue, String userId, Boolean cbxSinryouryou)
        {
            this._orderDate = orderDate;
            this._bunho = bunho;
            this._fkout1001 = fkout1001;
            this._doctor = doctor;
            this._sinryouryouGubun = sinryouryouGubun;
            this._inputId = inputId;
            this._inputTab = inputTab;
            this._iudGubun = iudGubun;
            this._naewonYn = naewonYn;
            this._arriveTime = arriveTime;
            this._jubsuGubun = jubsuGubun;
            this._previousValue = previousValue;
            this._changedValue = changedValue;
            this._userId = userId;
            this._cbxSinryouryou = cbxSinryouryou;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.PHY2001U04GrdPatientListItemValueChangingRequest();
        }
    }
}