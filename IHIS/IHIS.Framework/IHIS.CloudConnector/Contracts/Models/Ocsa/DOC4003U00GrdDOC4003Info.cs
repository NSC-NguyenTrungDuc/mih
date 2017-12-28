using System;

namespace IHIS.CloudConnector.Contracts.Models.Ocsa
{
    [Serializable]
    public class DOC4003U00GrdDOC4003Info
    {
        private String _sysDate;
        private String _sysId;
        private String _updDate;
        private String _updId;
        private String _hospCode;
        private String _pkdoc4003;
        private String _seq;
        private String _createDate;
        private String _toHospitalInfo;
        private String _toSinryouka;
        private String _toSinryouka2;
        private String _toDoctor;
        private String _toDoctor2;
        private String _doctor;
        private String _gwa;
        private String _suname;
        private String _sex;
        private String _zip;
        private String _aAddress;
        private String _tel;
        private String _birth;
        private String _job;
        private String _disease;
        private String _checkupOpinion;
        private String _prescription;
        private String _bunho;
        private String _zipCode;
        private String _bAddress;
        private String _fax;
        private String _yoyangName;
        private String _rowState;

        public String SysDate
        {
            get { return this._sysDate; }
            set { this._sysDate = value; }
        }

        public String SysId
        {
            get { return this._sysId; }
            set { this._sysId = value; }
        }

        public String UpdDate
        {
            get { return this._updDate; }
            set { this._updDate = value; }
        }

        public String UpdId
        {
            get { return this._updId; }
            set { this._updId = value; }
        }

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public String Pkdoc4003
        {
            get { return this._pkdoc4003; }
            set { this._pkdoc4003 = value; }
        }

        public String Seq
        {
            get { return this._seq; }
            set { this._seq = value; }
        }

        public String CreateDate
        {
            get { return this._createDate; }
            set { this._createDate = value; }
        }

        public String ToHospitalInfo
        {
            get { return this._toHospitalInfo; }
            set { this._toHospitalInfo = value; }
        }

        public String ToSinryouka
        {
            get { return this._toSinryouka; }
            set { this._toSinryouka = value; }
        }

        public String ToSinryouka2
        {
            get { return this._toSinryouka2; }
            set { this._toSinryouka2 = value; }
        }

        public String ToDoctor
        {
            get { return this._toDoctor; }
            set { this._toDoctor = value; }
        }

        public String ToDoctor2
        {
            get { return this._toDoctor2; }
            set { this._toDoctor2 = value; }
        }

        public String Doctor
        {
            get { return this._doctor; }
            set { this._doctor = value; }
        }

        public String Gwa
        {
            get { return this._gwa; }
            set { this._gwa = value; }
        }

        public String Suname
        {
            get { return this._suname; }
            set { this._suname = value; }
        }

        public String Sex
        {
            get { return this._sex; }
            set { this._sex = value; }
        }

        public String Zip
        {
            get { return this._zip; }
            set { this._zip = value; }
        }

        public String AAddress
        {
            get { return this._aAddress; }
            set { this._aAddress = value; }
        }

        public String Tel
        {
            get { return this._tel; }
            set { this._tel = value; }
        }

        public String Birth
        {
            get { return this._birth; }
            set { this._birth = value; }
        }

        public String Job
        {
            get { return this._job; }
            set { this._job = value; }
        }

        public String Disease
        {
            get { return this._disease; }
            set { this._disease = value; }
        }

        public String CheckupOpinion
        {
            get { return this._checkupOpinion; }
            set { this._checkupOpinion = value; }
        }

        public String Prescription
        {
            get { return this._prescription; }
            set { this._prescription = value; }
        }

        public String Bunho
        {
            get { return this._bunho; }
            set { this._bunho = value; }
        }

        public String ZipCode
        {
            get { return this._zipCode; }
            set { this._zipCode = value; }
        }

        public String BAddress
        {
            get { return this._bAddress; }
            set { this._bAddress = value; }
        }

        public String Fax
        {
            get { return this._fax; }
            set { this._fax = value; }
        }

        public String YoyangName
        {
            get { return this._yoyangName; }
            set { this._yoyangName = value; }
        }

        public String RowState
        {
            get { return this._rowState; }
            set { this._rowState = value; }
        }

        public DOC4003U00GrdDOC4003Info() { }

        public DOC4003U00GrdDOC4003Info(String sysDate, String sysId, String updDate, String updId, String hospCode, String pkdoc4003, String seq, String createDate, String toHospitalInfo, String toSinryouka, String toSinryouka2, String toDoctor, String toDoctor2, String doctor, String gwa, String suname, String sex, String zip, String aAddress, String tel, String birth, String job, String disease, String checkupOpinion, String prescription, String bunho, String zipCode, String bAddress, String fax, String yoyangName, String rowState)
        {
            this._sysDate = sysDate;
            this._sysId = sysId;
            this._updDate = updDate;
            this._updId = updId;
            this._hospCode = hospCode;
            this._pkdoc4003 = pkdoc4003;
            this._seq = seq;
            this._createDate = createDate;
            this._toHospitalInfo = toHospitalInfo;
            this._toSinryouka = toSinryouka;
            this._toSinryouka2 = toSinryouka2;
            this._toDoctor = toDoctor;
            this._toDoctor2 = toDoctor2;
            this._doctor = doctor;
            this._gwa = gwa;
            this._suname = suname;
            this._sex = sex;
            this._zip = zip;
            this._aAddress = aAddress;
            this._tel = tel;
            this._birth = birth;
            this._job = job;
            this._disease = disease;
            this._checkupOpinion = checkupOpinion;
            this._prescription = prescription;
            this._bunho = bunho;
            this._zipCode = zipCode;
            this._bAddress = bAddress;
            this._fax = fax;
            this._yoyangName = yoyangName;
            this._rowState = rowState;
        }

    }
}