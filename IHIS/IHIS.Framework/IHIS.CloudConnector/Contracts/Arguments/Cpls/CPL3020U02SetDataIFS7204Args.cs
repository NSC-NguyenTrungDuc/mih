using System;
using IHIS.CloudConnector.Contracts.Models.Cpls;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Cpls
{
    [Serializable]
    public class CPL3020U02SetDataIFS7204Args : IContractArgs
    {
        protected bool Equals(CPL3020U02SetDataIFS7204Args other)
        {
            return string.Equals(_fk, other._fk) && string.Equals(_recordGubun, other._recordGubun) && string.Equals(_sentaCode, other._sentaCode) && string.Equals(_iraiKey, other._iraiKey) && string.Equals(_hangmogCode, other._hangmogCode) && string.Equals(_resultCode, other._resultCode) && string.Equals(_specimenSer, other._specimenSer) && string.Equals(_resultVal, other._resultVal) && string.Equals(_danui, other._danui) && string.Equals(_fromStandard, other._fromStandard) && string.Equals(_toStandard, other._toStandard) && string.Equals(_emergency, other._emergency) && string.Equals(_yobi1, other._yobi1);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CPL3020U02SetDataIFS7204Args) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_fk != null ? _fk.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_recordGubun != null ? _recordGubun.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_sentaCode != null ? _sentaCode.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_iraiKey != null ? _iraiKey.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_hangmogCode != null ? _hangmogCode.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_resultCode != null ? _resultCode.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_specimenSer != null ? _specimenSer.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_resultVal != null ? _resultVal.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_danui != null ? _danui.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_fromStandard != null ? _fromStandard.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_toStandard != null ? _toStandard.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_emergency != null ? _emergency.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_yobi1 != null ? _yobi1.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _fk;
        private String _recordGubun;
        private String _sentaCode;
        private String _iraiKey;
        private String _hangmogCode;
        private String _resultCode;
        private String _specimenSer;
        private String _resultVal;
        private String _danui;
        private String _fromStandard;
        private String _toStandard;
        private String _emergency;
        private String _yobi1;

        public String Fk
        {
            get { return this._fk; }
            set { this._fk = value; }
        }

        public String RecordGubun
        {
            get { return this._recordGubun; }
            set { this._recordGubun = value; }
        }

        public String SentaCode
        {
            get { return this._sentaCode; }
            set { this._sentaCode = value; }
        }

        public String IraiKey
        {
            get { return this._iraiKey; }
            set { this._iraiKey = value; }
        }

        public String HangmogCode
        {
            get { return this._hangmogCode; }
            set { this._hangmogCode = value; }
        }

        public String ResultCode
        {
            get { return this._resultCode; }
            set { this._resultCode = value; }
        }

        public String SpecimenSer
        {
            get { return this._specimenSer; }
            set { this._specimenSer = value; }
        }

        public String ResultVal
        {
            get { return this._resultVal; }
            set { this._resultVal = value; }
        }

        public String Danui
        {
            get { return this._danui; }
            set { this._danui = value; }
        }

        public String FromStandard
        {
            get { return this._fromStandard; }
            set { this._fromStandard = value; }
        }

        public String ToStandard
        {
            get { return this._toStandard; }
            set { this._toStandard = value; }
        }

        public String Emergency
        {
            get { return this._emergency; }
            set { this._emergency = value; }
        }

        public String Yobi1
        {
            get { return this._yobi1; }
            set { this._yobi1 = value; }
        }

        public CPL3020U02SetDataIFS7204Args() { }

        public CPL3020U02SetDataIFS7204Args(String fk, String recordGubun, String sentaCode, String iraiKey, String hangmogCode, String resultCode, String specimenSer, String resultVal, String danui, String fromStandard, String toStandard, String emergency, String yobi1)
        {
            this._fk = fk;
            this._recordGubun = recordGubun;
            this._sentaCode = sentaCode;
            this._iraiKey = iraiKey;
            this._hangmogCode = hangmogCode;
            this._resultCode = resultCode;
            this._specimenSer = specimenSer;
            this._resultVal = resultVal;
            this._danui = danui;
            this._fromStandard = fromStandard;
            this._toStandard = toStandard;
            this._emergency = emergency;
            this._yobi1 = yobi1;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.CPL3020U02SetDataIFS7204Request();
        }
    }
}