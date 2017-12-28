using System;

namespace IHIS.CloudConnector.Contracts.Models.Orca
{
    public class ORCATransferOrdersHeaderInfo
    {
        private String _facilityId;
        private String _sysDate;
        private String _hospName;
        private String _hospAddress;
        private String _hospZipcode;
        private String _facilityCode;
        private String _creatorText;
        private String _countryType;
        private String _deparmentCode;

        public String FacilityId
        {
            get { return this._facilityId; }
            set { this._facilityId = value; }
        }

        public String SysDate
        {
            get { return this._sysDate; }
            set { this._sysDate = value; }
        }

        public String HospName
        {
            get { return this._hospName; }
            set { this._hospName = value; }
        }

        public String HospAddress
        {
            get { return this._hospAddress; }
            set { this._hospAddress = value; }
        }

        public String HospZipcode
        {
            get { return this._hospZipcode; }
            set { this._hospZipcode = value; }
        }

        public String FacilityCode
        {
            get { return this._facilityCode; }
            set { this._facilityCode = value; }
        }

        public String CreatorText
        {
            get { return this._creatorText; }
            set { this._creatorText = value; }
        }

        public String CountryType
        {
            get { return this._countryType; }
            set { this._countryType = value; }
        }

        public String DeparmentCode
        {
            get { return this._deparmentCode; }
            set { this._deparmentCode = value; }
        }

        public ORCATransferOrdersHeaderInfo() { }

        public ORCATransferOrdersHeaderInfo(String facilityId, String sysDate, String hospName, String hospAddress, String hospZipcode, String facilityCode, String creatorText, String countryType, String deparmentCode)
        {
            this._facilityId = facilityId;
            this._sysDate = sysDate;
            this._hospName = hospName;
            this._hospAddress = hospAddress;
            this._hospZipcode = hospZipcode;
            this._facilityCode = facilityCode;
            this._creatorText = creatorText;
            this._countryType = countryType;
            this._deparmentCode = deparmentCode;
        }

    }
}