using System;

namespace IHIS.CloudConnector.Contracts.Models.Drgs
{
    [Serializable]
    public class DrgsDRG5100P01GridPaidListItemInfo
    {
        private String _bunho;
        private String _orderDate;
        private String _drgBunho;
        private String _suname;
        private String _boryuYn;
        private String _orderRemark;
        private String _drgRemark;
        private String _trialYn;

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

        public String DrgBunho
        {
            get { return this._drgBunho; }
            set { this._drgBunho = value; }
        }

        public String Suname
        {
            get { return this._suname; }
            set { this._suname = value; }
        }

        public String BoryuYn
        {
            get { return this._boryuYn; }
            set { this._boryuYn = value; }
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

        public DrgsDRG5100P01GridPaidListItemInfo() { }

        public DrgsDRG5100P01GridPaidListItemInfo(String bunho, String orderDate, String drgBunho, String suname, String boryuYn, String orderRemark, String drgRemark, String trialYn)
        {
            this._bunho = bunho;
            this._orderDate = orderDate;
            this._drgBunho = drgBunho;
            this._suname = suname;
            this._boryuYn = boryuYn;
            this._orderRemark = orderRemark;
            this._drgRemark = drgRemark;
            this._trialYn = trialYn;
        }

    }
}