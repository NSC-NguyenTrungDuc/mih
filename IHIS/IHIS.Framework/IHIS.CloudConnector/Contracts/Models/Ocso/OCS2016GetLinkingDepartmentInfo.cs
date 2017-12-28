using System;

namespace IHIS.CloudConnector.Contracts.Models.Ocso
{
    [Serializable]
    public class OCS2016GetLinkingDepartmentInfo
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

        public OCS2016GetLinkingDepartmentInfo() { }

        public OCS2016GetLinkingDepartmentInfo(String departmentCode, String departmentName)
        {
            this._departmentCode = departmentCode;
            this._departmentName = departmentName;
        }

    }
}