using System;

namespace IHIS.CloudConnector.Contracts.Models.Bill
{
    public class BIL2016U00DetailServiceInfo
    {
        private String _insurancePrice;
        private String _servicePrice;
        private String _foreignerPrice;
        private String _hangmogCode;
        private String _rowState;

        public String InsurancePrice
        {
            get { return this._insurancePrice; }
            set { this._insurancePrice = value; }
        }

        public String ServicePrice
        {
            get { return this._servicePrice; }
            set { this._servicePrice = value; }
        }

        public String ForeignerPrice
        {
            get { return this._foreignerPrice; }
            set { this._foreignerPrice = value; }
        }

        public String HangmogCode
        {
            get { return this._hangmogCode; }
            set { this._hangmogCode = value; }
        }

        public String RowState
        {
            get { return this._rowState; }
            set { this._rowState = value; }
        }

        public BIL2016U00DetailServiceInfo() { }

        public BIL2016U00DetailServiceInfo(String insurancePrice, String servicePrice, String foreignerPrice, String hangmogCode, String rowState)
        {
            this._insurancePrice = insurancePrice;
            this._servicePrice = servicePrice;
            this._foreignerPrice = foreignerPrice;
            this._hangmogCode = hangmogCode;
            this._rowState = rowState;
        }

    }
}