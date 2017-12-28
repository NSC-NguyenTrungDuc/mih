using System;
using System.Collections.Generic;
using System.Text;

namespace IHIS.CloudConnector.Contracts.Models.System
{
    [Serializable]
    public class XPaInfoBoxInfo
    {
		private String patientName;
		private String patientName2;
		private String sex;
		private String yearAge;
		private String monthAge;
		private String departmentCode;
		private String departmentName;
		private String birth;
		private String tel;
		private String tel1;
		private String telHp;
		private String email;
		private String zipCode1;
		private String zipCode2;
		private String address1;
		private String address2;

        public XPaInfoBoxInfo()
        {
        }

        public XPaInfoBoxInfo(string patientName, string patientName2, string sex, string yearAge, string monthAge, string departmentCode, string departmentName, string birth, string tel, string tel1, string telHp, string email, string zipCode1, string zipCode2, string address1, string address2)
        {
            this.patientName = patientName;
            this.patientName2 = patientName2;
            this.sex = sex;
            this.yearAge = yearAge;
            this.monthAge = monthAge;
            this.departmentCode = departmentCode;
            this.departmentName = departmentName;
            this.birth = birth;
            this.tel = tel;
            this.tel1 = tel1;
            this.telHp = telHp;
            this.email = email;
            this.zipCode1 = zipCode1;
            this.zipCode2 = zipCode2;
            this.address1 = address1;
            this.address2 = address2;
        }

        public string PatientName
        {
            get { return patientName; }
            set { patientName = value; }
        }

        public string PatientName2
        {
            get { return patientName2; }
            set { patientName2 = value; }
        }

        public string Sex
        {
            get { return sex; }
            set { sex = value; }
        }

        public string YearAge
        {
            get { return yearAge; }
            set { yearAge = value; }
        }

        public string MonthAge
        {
            get { return monthAge; }
            set { monthAge = value; }
        }

        public string DepartmentCode
        {
            get { return departmentCode; }
            set { departmentCode = value; }
        }

        public string DepartmentName
        {
            get { return departmentName; }
            set { departmentName = value; }
        }

        public string Birth
        {
            get { return birth; }
            set { birth = value; }
        }

        public string Tel
        {
            get { return tel; }
            set { tel = value; }
        }

        public string Tel1
        {
            get { return tel1; }
            set { tel1 = value; }
        }

        public string TelHp
        {
            get { return telHp; }
            set { telHp = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string ZipCode1
        {
            get { return zipCode1; }
            set { zipCode1 = value; }
        }

        public string ZipCode2
        {
            get { return zipCode2; }
            set { zipCode2 = value; }
        }

        public string Address1
        {
            get { return address1; }
            set { address1 = value; }
        }

        public string Address2
        {
            get { return address2; }
            set { address2 = value; }
        }
    }

}
