using System;

namespace IHIS.CloudConnector.Contracts.Models.Invs
{
    public class INV6000U00LayINV6000Info
    {
        private String _pkinv6001;
        private String _magamMonth;
        private String _inputDate;
        private String _userName;
        private String _remark;
        private String _processTime;

        public String Pkinv6001
        {
            get { return this._pkinv6001; }
            set { this._pkinv6001 = value; }
        }

        public String MagamMonth
        {
            get { return this._magamMonth; }
            set { this._magamMonth = value; }
        }

        public String InputDate
        {
            get { return this._inputDate; }
            set { this._inputDate = value; }
        }

        public String UserName
        {
            get { return this._userName; }
            set { this._userName = value; }
        }

        public String Remark
        {
            get { return this._remark; }
            set { this._remark = value; }
        }

        public String ProcessTime
        {
            get { return this._processTime; }
            set { this._processTime = value; }
        }

        public INV6000U00LayINV6000Info() { }

        public INV6000U00LayINV6000Info(String pkinv6001, String magamMonth, String inputDate, String userName, String remark, String processTime)
        {
            this._pkinv6001 = pkinv6001;
            this._magamMonth = magamMonth;
            this._inputDate = inputDate;
            this._userName = userName;
            this._remark = remark;
            this._processTime = processTime;
        }

    }
}