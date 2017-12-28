using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;
using ProtoBuf;
using IHIS.CloudConnector.Contracts.Models.System;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    [Serializable]
    public class NUR1001R98LayReserInfoQueryEndArgs : IContractArgs
    {
        protected bool Equals(NUR1001R98LayReserInfoQueryEndArgs other)
        {
            return string.Equals(_patientCode, other._patientCode) && string.Equals(_reserDate, other._reserDate) && Equals(_departmentCode, other._departmentCode) && string.Equals(_reserYn, other._reserYn) && string.Equals(_rowNum, other._rowNum) && string.Equals(_codeType, other._codeType) && Equals(_reserPart, other._reserPart) && string.Equals(_codeTypeGetInfoText, other._codeTypeGetInfoText);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((NUR1001R98LayReserInfoQueryEndArgs) obj);
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
                hashCode = (hashCode*397) ^ (_codeType != null ? _codeType.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_reserPart != null ? _reserPart.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_codeTypeGetInfoText != null ? _codeTypeGetInfoText.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _patientCode;
        private String _reserDate;
        private List<DataStringListItemInfo> _departmentCode = new List<DataStringListItemInfo>();
        private String _reserYn;
        private String _rowNum;
        private String _codeType;
        private List<DataStringListItemInfo> _reserPart = new List<DataStringListItemInfo>();
        private String _codeTypeGetInfoText;

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

        public List<DataStringListItemInfo> DepartmentCode
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

        public String CodeType
        {
            get { return this._codeType; }
            set { this._codeType = value; }
        }

        public List<DataStringListItemInfo> ReserPart
        {
            get { return this._reserPart; }
            set { this._reserPart = value; }
        }

        public String CodeTypeGetInfoText
        {
            get { return this._codeTypeGetInfoText; }
            set { this._codeTypeGetInfoText = value; }
        }

        public NUR1001R98LayReserInfoQueryEndArgs() { }

        public NUR1001R98LayReserInfoQueryEndArgs(String patientCode, String reserDate, List<DataStringListItemInfo> departmentCode, String reserYn, String rowNum, String codeType, List<DataStringListItemInfo> reserPart, String codeTypeGetInfoText)
        {
            this._patientCode = patientCode;
            this._reserDate = reserDate;
            this._departmentCode = departmentCode;
            this._reserYn = reserYn;
            this._rowNum = rowNum;
            this._codeType = codeType;
            this._reserPart = reserPart;
            this._codeTypeGetInfoText = codeTypeGetInfoText;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.NUR1001R98LayReserInfoQueryEndRequest();
        }
    }
}