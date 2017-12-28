using System;

namespace IHIS.CloudConnector.Contracts.Models.OcsEmr
{
    public class OCS2015U00GetDataDoctorInfo
    {
        private String _doctorCode;
        private String _doctorName;

        public String DoctorCode
        {
            get { return this._doctorCode; }
            set { this._doctorCode = value; }
        }

        public String DoctorName
        {
            get { return this._doctorName; }
            set { this._doctorName = value; }
        }

        public OCS2015U00GetDataDoctorInfo() { }

        public OCS2015U00GetDataDoctorInfo(String doctorCode, String doctorName)
        {
            this._doctorCode = doctorCode;
            this._doctorName = doctorName;
        }

    }
}