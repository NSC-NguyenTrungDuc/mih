using System;

namespace IHIS.CloudConnector.Contracts.Models.Ocso
{
    [Serializable]
    public class OCS2016GetUserDepartmentInfo
    {
        private String _departmentCode;
        private String _departmentName;

        public String DepartmentCode
        {
            get { return this._departmentCode; }
            set { this._departmentCode = value; }
        }

        public String DepartmentName
        {
            get { return this._departmentName; }
            set { this._departmentName = value; }
        }

        public OCS2016GetUserDepartmentInfo() { }

        public OCS2016GetUserDepartmentInfo(String departmentCode, String departmentName)
        {
            this._departmentCode = departmentCode;
            this._departmentName = departmentName;
        }

    }
}