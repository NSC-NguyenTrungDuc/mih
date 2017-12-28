using System;
using System.Collections.Generic;
using System.Text;

namespace ORCA
{
    public class WorkPlaceInfo
    {
        private string wholeName = "";
        private string zipCode = "";
        private string wholeAddress1 = "";
        private string wholeAddress2 = "";
        private string phoneNumber = "";

        public string WholeName
        {
            get { return wholeName; }
            set { wholeName = value; }
        }

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

        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }

        public WorkPlaceInfo(string wholeName, string zipCode, string wholeAddress1, string wholeAddress2, string phoneNumber)
        {
            this.wholeName = wholeName;
            this.zipCode = zipCode;
            this.wholeAddress1 = wholeAddress1;
            this.wholeAddress2 = wholeAddress2;
            this.phoneNumber = phoneNumber;
        }

        public WorkPlaceInfo()
        { }
    }
}