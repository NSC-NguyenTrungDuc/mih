using System;
using System.Collections.Generic;
using System.Text;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    [Serializable]
    public class NuroProcOcsoDoctorChange2Args : IContractArgs
    {
        protected bool Equals(NuroProcOcsoDoctorChange2Args other)
        {
            return string.Equals(_pkout1001, other._pkout1001) && string.Equals(_toDoctor, other._toDoctor) && string.Equals(_toClinicCode, other._toClinicCode);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((NuroProcOcsoDoctorChange2Args) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_pkout1001 != null ? _pkout1001.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_toDoctor != null ? _toDoctor.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_toClinicCode != null ? _toClinicCode.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _pkout1001;
        private String _toDoctor;
        private String _toClinicCode;

        public String Pkout1001
        {
            get { return this._pkout1001; }
            set { this._pkout1001 = value; }
        }

        public String ToDoctor
        {
            get { return this._toDoctor; }
            set { this._toDoctor = value; }
        }

        public String ToClinicCode
        {
            get { return this._toClinicCode; }
            set { this._toClinicCode = value; }
        }

        public NuroProcOcsoDoctorChange2Args() { }

        public NuroProcOcsoDoctorChange2Args(String pkout1001, String toDoctor, String toClinicCode)
        {
            this._pkout1001 = pkout1001;
            this._toDoctor = toDoctor;
            this._toClinicCode = toClinicCode;
        }

        public IExtensible GetRequestInstance()
        {
            return new NuroProcOcsoDoctorChange2Request();
        }
    }

}
