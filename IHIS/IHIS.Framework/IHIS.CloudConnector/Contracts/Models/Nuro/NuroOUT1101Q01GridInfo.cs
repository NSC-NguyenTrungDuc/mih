using System;

namespace IHIS.CloudConnector.Contracts.Models.Nuro
{
    [Serializable]
    public class NuroOUT1101Q01GridInfo
    {
        private string _birth = "";
        private string _bunho = "";
        private string _doctor = "";
        private string _doctorName = "";
        private string _gubunName = "";
        private string _gwa = "";
        private string _gwaName = "";
        private string _jubsuGubun = "";
        private string _jubsuNo = "";
        private string _jubsuTime = "";
        private string _naewonDate = "";
        private string _naewonDateJp = "";
        private string _sujinNo = "";
        private string _suname = "";
        private string _suname2 = "";
        private string _yoyangName = "";

        public NuroOUT1101Q01GridInfo()
        {
        }

        public string Bunho
        {
            get { return _bunho; }
            set { _bunho = value; }
        }

        public string Suname
        {
            get { return _suname; }
            set { _suname = value; }
        }

        public string Suname2
        {
            get { return _suname2; }
            set { _suname2 = value; }
        }

        public string Birth
        {
            get { return _birth; }
            set { _birth = value; }
        }

        public string NaewonDateJp
        {
            get { return _naewonDateJp; }
            set { _naewonDateJp = value; }
        }

        public string NaewonDate
        {
            get { return _naewonDate; }
            set { _naewonDate = value; }
        }

        public string SujinNo
        {
            get { return _sujinNo; }
            set { _sujinNo = value; }
        }

        public string JubsuNo
        {
            get { return _jubsuNo; }
            set { _jubsuNo = value; }
        }

        public string Gwa
        {
            get { return _gwa; }
            set { _gwa = value; }
        }

        public string GwaName
        {
            get { return _gwaName; }
            set { _gwaName = value; }
        }

        public string Doctor
        {
            get { return _doctor; }
            set { _doctor = value; }
        }

        public string DoctorName
        {
            get { return _doctorName; }
            set { _doctorName = value; }
        }

        public string JubsuGubun
        {
            get { return _jubsuGubun; }
            set { _jubsuGubun = value; }
        }

        public string GubunName
        {
            get { return _gubunName; }
            set { _gubunName = value; }
        }

        public string JubsuTime
        {
            get { return _jubsuTime; }
            set { _jubsuTime = value; }
        }

        public string YoyangName
        {
            get { return _yoyangName; }
            set { _yoyangName = value; }
        }
    }
}