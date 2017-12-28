using System;
using System.Collections.Generic;
using System.Text;

namespace IHIS.CloudConnector.Contracts.Models.System
{
    [Serializable]
    public class DetailPaInfoFormGridVisitListInfo
    {
        private String _comingDate;
        private String _departmentName;
        private String _typeName;
        private String _doctorName;
        private String _outDate;

        public String ComingDate
        {
            get { return this._comingDate; }
            set { this._comingDate = value; }
        }

        public String DepartmentName
        {
            get { return this._departmentName; }
            set { this._departmentName = value; }
        }

        public String TypeName
        {
            get { return this._typeName; }
            set { this._typeName = value; }
        }

        public String DoctorName
        {
            get { return this._doctorName; }
            set { this._doctorName = value; }
        }

        public String OutDate
        {
            get { return this._outDate; }
            set { this._outDate = value; }
        }

        public DetailPaInfoFormGridVisitListInfo() { }

        public DetailPaInfoFormGridVisitListInfo(String comingDate, String departmentName, String typeName, String doctorName, String outDate)
        {
            this._comingDate = comingDate;
            this._departmentName = departmentName;
            this._typeName = typeName;
            this._doctorName = doctorName;
            this._outDate = outDate;
        }

    }

}
