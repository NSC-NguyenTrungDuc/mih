using System;

namespace IHIS.CloudConnector.Contracts.Models.Ocso
{
    public class OCSACTUpdateGrdOrderInfo
    {
        private String _remark;
        private String _pkocs;
        private String _jubsuDate;
        private String _jubsuTime;
        private String _actDoctor;
        private String _inputControl;
        private String _suryang;
        private String _nalsu;
        private String _fkout1001;
        private String _inputGubun;
        private String _hangmogCode;
        private String _jundalPart;
        private String _grdOrderInOutGubun;
        private String _grdOrderActingDate;
        private String _grdOrderActingTime;
        private String _grdOrderSortFkocskey;
        private String _grdOrderActYn;
        private String _pkocs1003;

        public String Remark
        {
            get { return this._remark; }
            set { this._remark = value; }
        }

        public String Pkocs
        {
            get { return this._pkocs; }
            set { this._pkocs = value; }
        }

        public String JubsuDate
        {
            get { return this._jubsuDate; }
            set { this._jubsuDate = value; }
        }

        public String JubsuTime
        {
            get { return this._jubsuTime; }
            set { this._jubsuTime = value; }
        }

        public String ActDoctor
        {
            get { return this._actDoctor; }
            set { this._actDoctor = value; }
        }

        public String InputControl
        {
            get { return this._inputControl; }
            set { this._inputControl = value; }
        }

        public String Suryang
        {
            get { return this._suryang; }
            set { this._suryang = value; }
        }

        public String Nalsu
        {
            get { return this._nalsu; }
            set { this._nalsu = value; }
        }

        public String Fkout1001
        {
            get { return this._fkout1001; }
            set { this._fkout1001 = value; }
        }

        public String InputGubun
        {
            get { return this._inputGubun; }
            set { this._inputGubun = value; }
        }

        public String HangmogCode
        {
            get { return this._hangmogCode; }
            set { this._hangmogCode = value; }
        }

        public String JundalPart
        {
            get { return this._jundalPart; }
            set { this._jundalPart = value; }
        }

        public String GrdOrderInOutGubun
        {
            get { return this._grdOrderInOutGubun; }
            set { this._grdOrderInOutGubun = value; }
        }

        public String GrdOrderActingDate
        {
            get { return this._grdOrderActingDate; }
            set { this._grdOrderActingDate = value; }
        }

        public String GrdOrderActingTime
        {
            get { return this._grdOrderActingTime; }
            set { this._grdOrderActingTime = value; }
        }

        public String GrdOrderSortFkocskey
        {
            get { return this._grdOrderSortFkocskey; }
            set { this._grdOrderSortFkocskey = value; }
        }

        public String GrdOrderActYn
        {
            get { return this._grdOrderActYn; }
            set { this._grdOrderActYn = value; }
        }

        public String Pkocs1003
        {
            get { return this._pkocs1003; }
            set { this._pkocs1003 = value; }
        }

        public OCSACTUpdateGrdOrderInfo() { }

        public OCSACTUpdateGrdOrderInfo(String remark, String pkocs, String jubsuDate, String jubsuTime, String actDoctor, String inputControl, String suryang, String nalsu, String fkout1001, String inputGubun, String hangmogCode, String jundalPart, String grdOrderInOutGubun, String grdOrderActingDate, String grdOrderActingTime, String grdOrderSortFkocskey, String grdOrderActYn, String pkocs1003)
        {
            this._remark = remark;
            this._pkocs = pkocs;
            this._jubsuDate = jubsuDate;
            this._jubsuTime = jubsuTime;
            this._actDoctor = actDoctor;
            this._inputControl = inputControl;
            this._suryang = suryang;
            this._nalsu = nalsu;
            this._fkout1001 = fkout1001;
            this._inputGubun = inputGubun;
            this._hangmogCode = hangmogCode;
            this._jundalPart = jundalPart;
            this._grdOrderInOutGubun = grdOrderInOutGubun;
            this._grdOrderActingDate = grdOrderActingDate;
            this._grdOrderActingTime = grdOrderActingTime;
            this._grdOrderSortFkocskey = grdOrderSortFkocskey;
            this._grdOrderActYn = grdOrderActYn;
            this._pkocs1003 = pkocs1003;
        }

    }
}