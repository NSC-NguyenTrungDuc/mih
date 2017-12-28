using System;

namespace IHIS.CloudConnector.Contracts.Models.Bill
{
    public class AbleInsteadOrderInfo
    {
        private String _bunho;
        private String _pkout1001;
        private String _naewonDate;

        public String Bunho
        {
            get { return this._bunho; }
            set { this._bunho = value; }
        }

        public String Pkout1001
        {
            get { return this._pkout1001; }
            set { this._pkout1001 = value; }
        }

        public String NaewonDate
        {
            get { return this._naewonDate; }
            set { this._naewonDate = value; }
        }

        public AbleInsteadOrderInfo() { }

        public AbleInsteadOrderInfo(String bunho, String pkout1001, String naewonDate)
        {
            this._bunho = bunho;
            this._pkout1001 = pkout1001;
            this._naewonDate = naewonDate;
        }

    }
}