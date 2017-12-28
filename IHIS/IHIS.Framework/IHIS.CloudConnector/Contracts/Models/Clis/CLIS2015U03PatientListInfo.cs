using System;

namespace IHIS.CloudConnector.Contracts.Models.Clis
{
    [Serializable]
    public class CLIS2015U03PatientListInfo
    {
        private String _bunho;
        private String _surname;
        private String _surname2;
        private String _fullName;
        private String _sex;
        private String _birth;
        private String _clisProtocolId;
        private String _rowState;

        public String Bunho
        {
            get { return this._bunho; }
            set { this._bunho = value; }
        }

        public String Surname
        {
            get { return this._surname; }
            set { this._surname = value; }
        }

        public String Surname2
        {
            get { return this._surname2; }
            set { this._surname2 = value; }
        }

        public String FullName
        {
            get { return this._fullName; }
            set { this._fullName = value; }
        }

        public String Sex
        {
            get { return this._sex; }
            set { this._sex = value; }
        }

        public String Birth
        {
            get { return this._birth; }
            set { this._birth = value; }
        }

        public String ClisProtocolId
        {
            get { return this._clisProtocolId; }
            set { this._clisProtocolId = value; }
        }

        public String RowState
        {
            get { return this._rowState; }
            set { this._rowState = value; }
        }

        public CLIS2015U03PatientListInfo() { }

        public CLIS2015U03PatientListInfo(String bunho, String surname, String surname2, String fullName, String sex, String birth, String clisProtocolId, String rowState)
        {
            this._bunho = bunho;
            this._surname = surname;
            this._surname2 = surname2;
            this._fullName = fullName;
            this._sex = sex;
            this._birth = birth;
            this._clisProtocolId = clisProtocolId;
            this._rowState = rowState;
        }

    }
}