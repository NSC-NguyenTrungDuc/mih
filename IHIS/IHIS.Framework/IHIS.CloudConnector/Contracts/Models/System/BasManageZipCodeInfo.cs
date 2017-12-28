using System;
using System.Collections.Generic;
using System.Text;

namespace IHIS.CloudConnector.Contracts.Models.System
{
    [Serializable]
    public class BasManageZipCodeInfo
    {
        private String zipCode;
        private String zipName1;
        private String zipName2;
        private String zipName3;
        private String zipNameGaga1;
        private String zipNameGaga2;
        private String zipNameGaga3;
        private String zipCode1;
        private String zipCode2;

        public BasManageZipCodeInfo()
        {
        }

        public BasManageZipCodeInfo(string zipCode, string zipName1, string zipName2, string zipName3, string zipNameGaga1, string zipNameGaga2, string zipNameGaga3, string zipCode1, string zipCode2)
        {
            this.zipCode = zipCode;
            this.zipName1 = zipName1;
            this.zipName2 = zipName2;
            this.zipName3 = zipName3;
            this.zipNameGaga1 = zipNameGaga1;
            this.zipNameGaga2 = zipNameGaga2;
            this.zipNameGaga3 = zipNameGaga3;
            this.zipCode1 = zipCode1;
            this.zipCode2 = zipCode2;
        }

        public string ZipCode
        {
            get { return zipCode; }
            set { zipCode = value; }
        }

        public string ZipName1
        {
            get { return zipName1; }
            set { zipName1 = value; }
        }

        public string ZipName2
        {
            get { return zipName2; }
            set { zipName2 = value; }
        }

        public string ZipName3
        {
            get { return zipName3; }
            set { zipName3 = value; }
        }

        public string ZipNameGaga1
        {
            get { return zipNameGaga1; }
            set { zipNameGaga1 = value; }
        }

        public string ZipNameGaga2
        {
            get { return zipNameGaga2; }
            set { zipNameGaga2 = value; }
        }

        public string ZipNameGaga3
        {
            get { return zipNameGaga3; }
            set { zipNameGaga3 = value; }
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
    }
}
