using System;

namespace IHIS.CloudConnector.Contracts.Models.Schs
{
    [Serializable]
    public class SCH0201U10LayReserInfo
    {
        private String _gwa;
        private String _gwaName;
        private String _bunho;
        private String _suname;
        private String _reserDate;
        private String _hangmogName;
        private String _reserTime;
        private String _moveName;
        private String _reserDay;
        private String _age;
        private String _birth;
        private String _suname2;
        private String _jundalPart;
        private String _reserMoveName;
        private String _hangmogCode;
        private String _jundalTable;
        private String _hopeDate;
        private String _seq;
        private String _sort;

        public String Gwa
        {
            get { return this._gwa; }
            set { this._gwa = value; }
        }

        public String GwaName
        {
            get { return this._gwaName; }
            set { this._gwaName = value; }
        }

        public String Bunho
        {
            get { return this._bunho; }
            set { this._bunho = value; }
        }

        public String Suname
        {
            get { return this._suname; }
            set { this._suname = value; }
        }

        public String ReserDate
        {
            get { return this._reserDate; }
            set { this._reserDate = value; }
        }

        public String HangmogName
        {
            get { return this._hangmogName; }
            set { this._hangmogName = value; }
        }

        public String ReserTime
        {
            get { return this._reserTime; }
            set { this._reserTime = value; }
        }

        public String MoveName
        {
            get { return this._moveName; }
            set { this._moveName = value; }
        }

        public String ReserDay
        {
            get { return this._reserDay; }
            set { this._reserDay = value; }
        }

        public String Age
        {
            get { return this._age; }
            set { this._age = value; }
        }

        public String Birth
        {
            get { return this._birth; }
            set { this._birth = value; }
        }

        public String Suname2
        {
            get { return this._suname2; }
            set { this._suname2 = value; }
        }

        public String JundalPart
        {
            get { return this._jundalPart; }
            set { this._jundalPart = value; }
        }

        public String ReserMoveName
        {
            get { return this._reserMoveName; }
            set { this._reserMoveName = value; }
        }

        public String HangmogCode
        {
            get { return this._hangmogCode; }
            set { this._hangmogCode = value; }
        }

        public String JundalTable
        {
            get { return this._jundalTable; }
            set { this._jundalTable = value; }
        }

        public String HopeDate
        {
            get { return this._hopeDate; }
            set { this._hopeDate = value; }
        }

        public String Seq
        {
            get { return this._seq; }
            set { this._seq = value; }
        }

        public String Sort
        {
            get { return this._sort; }
            set { this._sort = value; }
        }

        public SCH0201U10LayReserInfo() { }

        public SCH0201U10LayReserInfo(String gwa, String gwaName, String bunho, String suname, String reserDate, String hangmogName, String reserTime, String moveName, String reserDay, String age, String birth, String suname2, String jundalPart, String reserMoveName, String hangmogCode, String jundalTable, String hopeDate, String seq, String sort)
        {
            this._gwa = gwa;
            this._gwaName = gwaName;
            this._bunho = bunho;
            this._suname = suname;
            this._reserDate = reserDate;
            this._hangmogName = hangmogName;
            this._reserTime = reserTime;
            this._moveName = moveName;
            this._reserDay = reserDay;
            this._age = age;
            this._birth = birth;
            this._suname2 = suname2;
            this._jundalPart = jundalPart;
            this._reserMoveName = reserMoveName;
            this._hangmogCode = hangmogCode;
            this._jundalTable = jundalTable;
            this._hopeDate = hopeDate;
            this._seq = seq;
            this._sort = sort;
        }

    }
}