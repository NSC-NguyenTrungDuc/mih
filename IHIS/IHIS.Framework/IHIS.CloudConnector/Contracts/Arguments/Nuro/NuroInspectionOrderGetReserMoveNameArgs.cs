using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    [Serializable]
    public class NuroInspectionOrderGetReserMoveNameArgs : IContractArgs
    {
        protected bool Equals(NuroInspectionOrderGetReserMoveNameArgs other)
        {
            return string.Equals(_patientCode, other._patientCode) && string.Equals(_reserDate, other._reserDate) && string.Equals(_departmentCode, other._departmentCode) && string.Equals(_reserYn, other._reserYn) && string.Equals(_rowNum, other._rowNum);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((NuroInspectionOrderGetReserMoveNameArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_patientCode != null ? _patientCode.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_reserDate != null ? _reserDate.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_departmentCode != null ? _departmentCode.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_reserYn != null ? _reserYn.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_rowNum != null ? _rowNum.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _patientCode;
        private String _reserDate;
        private String _departmentCode;
        private String _reserYn;
        private String _rowNum;

        public String PatientCode
        {
            get { return this._patientCode; }
            set { this._patientCode = value; }
        }

        public String ReserDate
        {
            get { return this._reserDate; }
            set { this._reserDate = value; }
        }

        public String DepartmentCode
        {
            get { return this._departmentCode; }
            set { this._departmentCode = value; }
        }

        public String ReserYn
        {
            get { return this._reserYn; }
            set { this._reserYn = value; }
        }

        public String RowNum
        {
            get { return this._rowNum; }
            set { this._rowNum = value; }
        }

        public NuroInspectionOrderGetReserMoveNameArgs() { }

        public NuroInspectionOrderGetReserMoveNameArgs(String patientCode, String reserDate, String departmentCode, String reserYn, String rowNum)
        {
            this._patientCode = patientCode;
            this._reserDate = reserDate;
            this._departmentCode = departmentCode;
            this._reserYn = reserYn;
            this._rowNum = rowNum;
        }

        public IExtensible GetRequestInstance()
        {
            return new NuroInspectionOrderGetReserMoveNameRequest();
        }
    }
}