using System;

namespace IHIS.CloudConnector.Contracts.Models.Nuro
{
    [Serializable]
    public class NuroOUT1101Q01FwkDoctorInfo
    {
        public NuroOUT1101Q01FwkDoctorInfo() {}
    
        private string _sabun = "";
        public string Sabun
        {
            get { return _sabun; }
            set { _sabun = value; }
        }
        private string _doctorName = "";
        public string DoctorName
        {
            get { return _doctorName; }
            set { _doctorName = value; }
        }
    }
}