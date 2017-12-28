using System;
using System.Collections.Generic;
using System.Text;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    [Serializable]
    public class NuroNUR2001U04ForeignKeyArgs : IContractArgs
    {
        protected bool Equals(NuroNUR2001U04ForeignKeyArgs other)
        {
            return string.Equals(_comingDate, other._comingDate) && string.Equals(_patientCode, other._patientCode) && string.Equals(_departmentCode, other._departmentCode) && string.Equals(_doctorCode, other._doctorCode) && string.Equals(_comingType, other._comingType) && string.Equals(_receptionNo, other._receptionNo);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((NuroNUR2001U04ForeignKeyArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_comingDate != null ? _comingDate.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_patientCode != null ? _patientCode.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_departmentCode != null ? _departmentCode.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_doctorCode != null ? _doctorCode.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_comingType != null ? _comingType.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_receptionNo != null ? _receptionNo.GetHashCode() : 0);
                return hashCode;
            }
        }

        private string _comingDate;
        private string _patientCode;
        private string _departmentCode;
        private string _doctorCode;
        private string _comingType;
        private string _receptionNo;

        public string ComingDate
        {
            get { return _comingDate; }
            set { _comingDate = value; }
        }

        public string PatientCode
        {
            get { return _patientCode; }
            set { _patientCode = value; }
        }

        public string DepartmentCode
        {
            get { return _departmentCode; }
            set { _departmentCode = value; }
        }

        public string DoctorCode
        {
            get { return _doctorCode; }
            set { _doctorCode = value; }
        }

        public string ComingType
        {
            get { return _comingType; }
            set { _comingType = value; }
        }

        public string ReceptionNo
        {
            get { return _receptionNo; }
            set { _receptionNo = value; }
        }

        public NuroNUR2001U04ForeignKeyArgs(string comingDate, string patientCode, string departmentCode, string doctorCode, string comingType, string receptionNo)
        {
            _comingDate = comingDate;
            _patientCode = patientCode;
            _departmentCode = departmentCode;
            _doctorCode = doctorCode;
            _comingType = comingType;
            _receptionNo = receptionNo;
        }

        public NuroNUR2001U04ForeignKeyArgs()
        {
        }

        public IExtensible GetRequestInstance()
        {
            return new NuroNUR2001U04ForeignKeyRequest();
        }
    }
}
