using System;

namespace IHIS.CloudConnector.Contracts.Models.Phys
{
    [Serializable]
    public class PHY2001U04BtnJinryouEndClickUpdateMultipleOut1001Info
    {
        private String _pkout1001;
        private String _orderEndYn;

        public String Pkout1001
        {
            get { return this._pkout1001; }
            set { this._pkout1001 = value; }
        }

        public String OrderEndYn
        {
            get { return this._orderEndYn; }
            set { this._orderEndYn = value; }
        }

        public PHY2001U04BtnJinryouEndClickUpdateMultipleOut1001Info() { }

        public PHY2001U04BtnJinryouEndClickUpdateMultipleOut1001Info(String pkout1001, String orderEndYn)
        {
            this._pkout1001 = pkout1001;
            this._orderEndYn = orderEndYn;
        }

    }
}