using System;
using System.Collections.Generic;
using System.Text;

namespace ORCA
{
    public class HomeAddressInfo
    {
        private string zipCode;
        private string wholeAddress1;
        private string wholeAddress2;
        private string phoneNumber1;
        private string phoneNumber2;

        public string ZipCode
        {
            get { return zipCode; }
            set { zipCode = value; }
        }

        public string WholeAddress1
        {
            get { return wholeAddress1; }
            set { wholeAddress1 = value; }
        }

        public string WholeAddress2
        {
            get { return wholeAddress2; }
            set { wholeAddress2 = value; }
        }

        public string PhoneNumber1
        {
            get { return phoneNumber1; }
            set { phoneNumber1 = value; }
        }

        public string PhoneNumber2
        {
            get { return phoneNumber2; }
            set { phoneNumber2 = value; }
        }

        public HomeAddressInfo(string zipCode, string wholeAddress1, string wholeAddress2, string phoneNumber1, string phoneNumber2)
        {
            this.zipCode = zipCode;
            this.wholeAddress1 = wholeAddress1;
            this.wholeAddress2 = wholeAddress2;
            this.phoneNumber1 = phoneNumber1;
            this.phoneNumber2 = phoneNumber2;
        }

        public HomeAddressInfo()
        {
        }
    }
}
