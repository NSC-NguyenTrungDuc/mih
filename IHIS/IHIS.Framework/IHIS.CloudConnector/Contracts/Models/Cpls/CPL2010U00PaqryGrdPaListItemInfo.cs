using System;

namespace IHIS.CloudConnector.Contracts.Models.Cpls
{
    [Serializable]
    public class CPL2010U00PaqryGrdPaListItemInfo
    {
        private String _bunho;
        private String _suname;
        private String _inOutGubun;
        private String _gwaName;
        private String _orderTime;
        private String _todayYn;
        private String _reserYn;
        private String _doctorName;

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

        public String InOutGubun
        {
            get { return this._inOutGubun; }
            set { this._inOutGubun = value; }
        }

        public String GwaName
        {
            get { return this._gwaName; }
            set { this._gwaName = value; }
        }

        public String OrderTime
        {
            get { return this._orderTime; }
            set { this._orderTime = value; }
        }

        public String TodayYn
        {
            get { return this._todayYn; }
            set { this._todayYn = value; }
        }

        public String ReserYn
        {
            get { return this._reserYn; }
            set { this._reserYn = value; }
        }

        public String DoctorName
        {
            get { return this._doctorName; }
            set { this._doctorName = value; }
        }

        public CPL2010U00PaqryGrdPaListItemInfo() { }

        public CPL2010U00PaqryGrdPaListItemInfo(String bunho, String suname, String inOutGubun, String gwaName, String orderTime, String todayYn, String reserYn, String doctorName)
        {
            this._bunho = bunho;
            this._suname = suname;
            this._inOutGubun = inOutGubun;
            this._gwaName = gwaName;
            this._orderTime = orderTime;
            this._todayYn = todayYn;
            this._reserYn = reserYn;
            this._doctorName = doctorName;
        }

    }
}