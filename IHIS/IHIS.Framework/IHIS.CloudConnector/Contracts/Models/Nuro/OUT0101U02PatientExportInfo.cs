using System;

namespace IHIS.CloudConnector.Contracts.Models.Nuro
{
    public class OUT0101U02PatientExportInfo
    {
        private String _systemId;
        private String _createdDate;
        private String _createdAdmin;
        private String _updateDate;
        private String _updateAdmin;
        private String _hospitalCode;
        private String _patientCode;
        private String _suname;
        private String _suname2;
        private String _sex;
        private String _birthday;
        private String _postalCode;
        private String _address1;
        private String _address2;
        private String _phoneNumber;
        private String _phoneNumber2;
        private String _phoneNumber3;
        private String _phoneType1;
        private String _phoneType2;
        private String _phoneType3;
        private String _insuranceType;
        private String _interuptedReception;
        private String _interuptedReceptionReason;
        private String _detete;
        private String _patientNote;
        private String _emailAddress;
        private String _paceMakerYn;
        private String _selfPaceMaker;
        private String _password;
        private String _patientType;

        public String SystemId
        {
            get { return this._systemId; }
            set { this._systemId = value; }
        }

        public String CreatedDate
        {
            get { return this._createdDate; }
            set { this._createdDate = value; }
        }

        public String CreatedAdmin
        {
            get { return this._createdAdmin; }
            set { this._createdAdmin = value; }
        }

        public String UpdateDate
        {
            get { return this._updateDate; }
            set { this._updateDate = value; }
        }

        public String UpdateAdmin
        {
            get { return this._updateAdmin; }
            set { this._updateAdmin = value; }
        }

        public String HospitalCode
        {
            get { return this._hospitalCode; }
            set { this._hospitalCode = value; }
        }

        public String PatientCode
        {
            get { return this._patientCode; }
            set { this._patientCode = value; }
        }

        public String Suname
        {
            get { return this._suname; }
            set { this._suname = value; }
        }

        public String Suname2
        {
            get { return this._suname2; }
            set { this._suname2 = value; }
        }

        public String Sex
        {
            get { return this._sex; }
            set { this._sex = value; }
        }

        public String Birthday
        {
            get { return this._birthday; }
            set { this._birthday = value; }
        }

        public String PostalCode
        {
            get { return this._postalCode; }
            set { this._postalCode = value; }
        }

        public String Address1
        {
            get { return this._address1; }
            set { this._address1 = value; }
        }

        public String Address2
        {
            get { return this._address2; }
            set { this._address2 = value; }
        }

        public String PhoneNumber
        {
            get { return this._phoneNumber; }
            set { this._phoneNumber = value; }
        }

        public String PhoneNumber2
        {
            get { return this._phoneNumber2; }
            set { this._phoneNumber2 = value; }
        }

        public String PhoneNumber3
        {
            get { return this._phoneNumber3; }
            set { this._phoneNumber3 = value; }
        }

        public String PhoneType1
        {
            get { return this._phoneType1; }
            set { this._phoneType1 = value; }
        }

        public String PhoneType2
        {
            get { return this._phoneType2; }
            set { this._phoneType2 = value; }
        }

        public String PhoneType3
        {
            get { return this._phoneType3; }
            set { this._phoneType3 = value; }
        }

        public String InsuranceType
        {
            get { return this._insuranceType; }
            set { this._insuranceType = value; }
        }

        public String InteruptedReception
        {
            get { return this._interuptedReception; }
            set { this._interuptedReception = value; }
        }

        public String InteruptedReceptionReason
        {
            get { return this._interuptedReceptionReason; }
            set { this._interuptedReceptionReason = value; }
        }

        public String Detete
        {
            get { return this._detete; }
            set { this._detete = value; }
        }

        public String PatientNote
        {
            get { return this._patientNote; }
            set { this._patientNote = value; }
        }

        public String EmailAddress
        {
            get { return this._emailAddress; }
            set { this._emailAddress = value; }
        }

        public String PaceMakerYn
        {
            get { return this._paceMakerYn; }
            set { this._paceMakerYn = value; }
        }

        public String SelfPaceMaker
        {
            get { return this._selfPaceMaker; }
            set { this._selfPaceMaker = value; }
        }

        public String Password
        {
            get { return this._password; }
            set { this._password = value; }
        }

        public String PatientType
        {
            get { return this._patientType; }
            set { this._patientType = value; }
        }

        public OUT0101U02PatientExportInfo() { }

        public OUT0101U02PatientExportInfo(String systemId, String createdDate, String createdAdmin, String updateDate, String updateAdmin, String hospitalCode, String patientCode, String suname, String suname2, String sex, String birthday, String postalCode, String address1, String address2, String phoneNumber, String phoneNumber2, String phoneNumber3, String phoneType1, String phoneType2, String phoneType3, String insuranceType, String interuptedReception, String interuptedReceptionReason, String detete, String patientNote, String emailAddress, String paceMakerYn, String selfPaceMaker, String password, String patientType)
        {
            this._systemId = systemId;
            this._createdDate = createdDate;
            this._createdAdmin = createdAdmin;
            this._updateDate = updateDate;
            this._updateAdmin = updateAdmin;
            this._hospitalCode = hospitalCode;
            this._patientCode = patientCode;
            this._suname = suname;
            this._suname2 = suname2;
            this._sex = sex;
            this._birthday = birthday;
            this._postalCode = postalCode;
            this._address1 = address1;
            this._address2 = address2;
            this._phoneNumber = phoneNumber;
            this._phoneNumber2 = phoneNumber2;
            this._phoneNumber3 = phoneNumber3;
            this._phoneType1 = phoneType1;
            this._phoneType2 = phoneType2;
            this._phoneType3 = phoneType3;
            this._insuranceType = insuranceType;
            this._interuptedReception = interuptedReception;
            this._interuptedReceptionReason = interuptedReceptionReason;
            this._detete = detete;
            this._patientNote = patientNote;
            this._emailAddress = emailAddress;
            this._paceMakerYn = paceMakerYn;
            this._selfPaceMaker = selfPaceMaker;
            this._password = password;
            this._patientType = patientType;
        }

    }
}