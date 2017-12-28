using System;
using System.Collections.Generic;
using System.Text;

namespace ORCA
{
    public class HeaderInfo
    {
        private DateTime _createDate;
        private string _version = "";
        private string _facilityId = "";
        private string _facilityCode = "";
        private string _facilityName = "";
        private string _departmentCode = "";
        private string _hospCode = "";
        private string _hospName = "";
        private string _hospAddr = "";
        private string _hospZip = "";
        private string _creatorText = "";
        private string _bunho = "";

        public DateTime CreateDate
        {
            get { return _createDate; }
            set { _createDate = value; }
        }

        public string FacilityId
        {
            get { return _facilityId; }
            set { _facilityId = value; }
        }

        public string FacilityCode
        {
            get { return _facilityCode; }
            set { _facilityCode = value; }
        }

        public string FacilityName
        {
            get { return _facilityName; }
            set { _facilityName = value; }
        }

        public string CreatorText
        {
            get { return _creatorText; }
            set { _creatorText = value; }
        }

        public string Bunho
        {
            get { return _bunho; }
            set { _bunho = value; }
        }

        public string DepartmentCode
        {
            get { return _departmentCode; }
            set { _departmentCode = value; }
        }

        public string HospCode
        {
            get { return _hospCode; }
            set { _hospCode = value; }
        }

        public string HospName
        {
            get { return _hospName; }
            set { _hospName = value; }
        }

        public string HospAddress
        {
            get { return _hospAddr; }
            set { _hospAddr = value; }
        }

        public string HospZipCode
        {
            get { return _hospZip; }
            set { _hospZip = value; }
        }

        public string Version
        {
            get { return _version; }
            set { _version = value; }
        }

        public HeaderInfo()
        {
        }
    }
}
