using System;

namespace IHIS.CloudConnector.Contracts.Models.Drgs
{
    [Serializable]
    public class DRG0201U00GrdPaidInfo
    {
        private String _drgBunho;
        private String _bunho;
        private String _orderDate;
        private String _jojeYn;
        private String _suname;
        private String _orderRemark;
        private String _drgRemark;
        private String _trialYn;

        public String DrgBunho
        {
            get { return this._drgBunho; }
            set { this._drgBunho = value; }
        }

        public String Bunho
        {
            get { return this._bunho; }
            set { this._bunho = value; }
        }

        public String OrderDate
        {
            get { return this._orderDate; }
            set { this._orderDate = value; }
        }

        public String JojeYn
        {
            get { return this._jojeYn; }
            set { this._jojeYn = value; }
        }

        public String Suname
        {
            get { return this._suname; }
            set { this._suname = value; }
        }

        public String OrderRemark
        {
            get { return this._orderRemark; }
            set { this._orderRemark = value; }
        }

        public String DrgRemark
        {
            get { return this._drgRemark; }
            set { this._drgRemark = value; }
        }

        public String TrialYn
        {
            get { return this._trialYn; }
            set { this._trialYn = value; }
        }

        public DRG0201U00GrdPaidInfo() { }

        public DRG0201U00GrdPaidInfo(String drgBunho, String bunho, String orderDate, String jojeYn, String suname, String orderRemark, String drgRemark, String trialYn)
        {
            this._drgBunho = drgBunho;
            this._bunho = bunho;
            this._orderDate = orderDate;
            this._jojeYn = jojeYn;
            this._suname = suname;
            this._orderRemark = orderRemark;
            this._drgRemark = drgRemark;
            this._trialYn = trialYn;
        }

    }
}