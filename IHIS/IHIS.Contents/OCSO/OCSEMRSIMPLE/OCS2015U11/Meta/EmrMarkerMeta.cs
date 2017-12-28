using IHIS.OCSO.Meta;

namespace EmrDocker.Meta
{
    public abstract class EmrMarkerMeta : UserData
    {
        private string _hospital_name;
        private string _department_name;
        private string _doctor_name;
        private string _examination_date;
        private string _reservation_code;
        public EmrMarkerMeta(CustomMarkType type, string checksum) : base(type, checksum)
        {
        }

        public string HospitalName
        {
            get { return _hospital_name; }
            set { _hospital_name = value; }
        }

        public string DepartmentName
        {
            get { return _department_name; }
            set { _department_name = value; }
        }

        public string ExaminationDate
        {
            get { return _examination_date; }
            set { _examination_date = value; }
        }

        public string ReservationCode
        {
            get { return _reservation_code; }
            set { _reservation_code = value; }
        }

        public string DoctorName
        {
            get { return _doctor_name; }
            set { _doctor_name = value; }
        }
    }

    public class EmrStartMarkerMeta : EmrMarkerMeta
    {
        public EmrStartMarkerMeta(string checksum)
            : base(CustomMarkType.EmrStartMarker, checksum)
        {
        }
    }

    public class EmrEndMarkerMeta : EmrMarkerMeta
    {
        public EmrEndMarkerMeta(string checksum)
            : base(CustomMarkType.EmrEndMarker, checksum)
        {
        }
    }

    public class DoStartMarkerMeta : EmrMarkerMeta
    {
        public DoStartMarkerMeta(string checksum)
            : base(CustomMarkType.EmrStartMarker, checksum)
        {
        }
    }

    public class DoEndMarkerMeta : EmrMarkerMeta
    {
        public DoEndMarkerMeta(string checksum)
            : base(CustomMarkType.EmrEndMarker, checksum)
        {
        }
    }
}
