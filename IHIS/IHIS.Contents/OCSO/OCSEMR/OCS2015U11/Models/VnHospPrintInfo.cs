using System;

namespace EmrDocker.Models
{
    public class VnHospPrintInfo
    {
        private String _hospName;
        private String _hospAddress;
        private String _hospPhone;
        private String _hospFax;
        private String _hospWebsite;
        private String _hospLogo;

        public string HospName
        {
            get { return _hospName; }
            set { _hospName = value; }
        }

        public string HospAddress
        {
            get { return _hospAddress; }
            set { _hospAddress = value; }
        }

        public string HospPhone
        {
            get { return _hospPhone; }
            set { _hospPhone = value; }
        }

        public string HospFax
        {
            get { return _hospFax; }
            set { _hospFax = value; }
        }

        public string HospWebsite
        {
            get { return _hospWebsite; }
            set { _hospWebsite = value; }
        }

        public string HospLogo
        {
            get { return _hospLogo; }
            set { _hospLogo = value; }
        }

        public VnHospPrintInfo()
        {
        }

        public VnHospPrintInfo(string hospName, string hospAddress, string hospPhone, string hospFax, string hospWebsite, string hospLogo)
        {
            _hospName = hospName;
            _hospAddress = hospAddress;
            _hospPhone = hospPhone;
            _hospFax = hospFax;
            _hospWebsite = hospWebsite;
            _hospLogo = hospLogo;
        }
    }
}