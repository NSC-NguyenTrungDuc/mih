using System;
using System.Collections.Generic;

using System.Text;
using MedicalInterface.Mml23.MmlAd;
using MedicalInterface.Mml23.MmlDp;

namespace MedicalInterface {
    public class FacilityInfo {
        private string _facilityId;
        private string _facilityName;
        private string _postNumber;
        private string _addressText;
        private string _type;
        private string _text;
        private string _tableId;
        private Address _address;
        private Department _department;

        public string FacilityId
        {
            get { return _facilityId; }
            set { _facilityId = value; }
        }

        public string FacilityName
        {
            get { return _facilityName; }
            set { _facilityName = value; }
        }

        public string PostNumber
        {
            get { return _postNumber; }
            set { _postNumber = value; }
        }

        public string AddressText
        {
            get { return _addressText; }
            set { _addressText = value; }
        }

        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }

        public string TableId
        {
            get { return _tableId; }
            set { _tableId = value; }
        }

        public Address Address
        {
            get { return _address; }
            set { _address = value; }
        }

        public Department Department
        {
            get { return _department; }
            set { _department = value; }
        }
    }
}
