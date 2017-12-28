using System;

namespace IHIS.CloudConnector.Contracts.Models.Schs
{
    [Serializable]
    public class SchsSCH0201U99GrdTimeListInfo
    {
        private String _fromTime;
        private String _bunho;
        private String _suname;
        private String _hangmogName;
        private String _doctorName;
        private String _inputDate;
        private String _orderDate;
        private String _reserDate;
        private String _pksch0201;
        private String _outHospCode;
        private String _yoyangName;

        public String FromTime
        {
            get { return this._fromTime; }
            set { this._fromTime = value; }
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

        public String HangmogName
        {
            get { return this._hangmogName; }
            set { this._hangmogName = value; }
        }

        public String DoctorName
        {
            get { return this._doctorName; }
            set { this._doctorName = value; }
        }

        public String InputDate
        {
            get { return this._inputDate; }
            set { this._inputDate = value; }
        }

        public String OrderDate
        {
            get { return this._orderDate; }
            set { this._orderDate = value; }
        }

        public String ReserDate
        {
            get { return this._reserDate; }
            set { this._reserDate = value; }
        }

        public String Pksch0201
        {
            get { return this._pksch0201; }
            set { this._pksch0201 = value; }
        }

        public String OutHospCode
        {
            get { return this._outHospCode; }
            set { this._outHospCode = value; }
        }

        public String YoyangName
        {
            get { return this._yoyangName; }
            set { this._yoyangName = value; }
        }

        public SchsSCH0201U99GrdTimeListInfo() { }

        public SchsSCH0201U99GrdTimeListInfo(String fromTime, String bunho, String suname, String hangmogName, String doctorName, String inputDate, String orderDate, String reserDate, String pksch0201, String outHospCode, String yoyangName)
        {
            this._fromTime = fromTime;
            this._bunho = bunho;
            this._suname = suname;
            this._hangmogName = hangmogName;
            this._doctorName = doctorName;
            this._inputDate = inputDate;
            this._orderDate = orderDate;
            this._reserDate = reserDate;
            this._pksch0201 = pksch0201;
            this._outHospCode = outHospCode;
            this._yoyangName = yoyangName;
        }

    }
}