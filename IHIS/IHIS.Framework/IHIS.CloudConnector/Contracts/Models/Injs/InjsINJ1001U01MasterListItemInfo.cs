using System;

namespace IHIS.CloudConnector.Contracts.Models.Injs
{
    [Serializable]
    public class InjsINJ1001U01MasterListItemInfo
    {
        private String _reserGubun;
        private String _bunho;
        private String _suname;
        private String _orderDate;
        private String _reserDate;
        private String _trialYn;

        public String ReserGubun
        {
            get { return this._reserGubun; }
            set { this._reserGubun = value; }
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

        public String TrialYn
        {
            get { return this._trialYn; }
            set { this._trialYn = value; }
        }

        public InjsINJ1001U01MasterListItemInfo() { }

        public InjsINJ1001U01MasterListItemInfo(String reserGubun, String bunho, String suname, String orderDate, String reserDate, String trialYn)
        {
            this._reserGubun = reserGubun;
            this._bunho = bunho;
            this._suname = suname;
            this._orderDate = orderDate;
            this._reserDate = reserDate;
            this._trialYn = trialYn;
        }

    }
}