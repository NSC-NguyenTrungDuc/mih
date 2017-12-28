using System;

namespace IHIS.CloudConnector.Contracts.Models.Bill
{
    public class LoadGridBIL2016U02Info
    {
        private String _hangmogCode;
        private String _hangmogName;
        private String _unit;
        private String _price;
        private String _quantity;
        private String _amount;
        private String _insurancePay;
        private String _patientPay;
        private String _discount;
        private String _deptReqCd;
        private String _deptReqNm;
        private String _doctorReqCd;
        private String _doctorReqNm;
        private String _deptExcCd;
        private String _deptExcNm;
        private String _doctorExcCd;
        private String _doctorExcNm;
        private String _orderGroupCd;
        private String _orderGroupNm;
        private String _orderDate;
        private String _actingDate;
        private String _discountReason;
        private String _checkYn;
        private String _fkocs1003;
        private String _amountPaid;
        private String _amountDebt;
        private String _fkout1001;
        private String _patientAddress;

        public String HangmogCode
        {
            get { return this._hangmogCode; }
            set { this._hangmogCode = value; }
        }

        public String HangmogName
        {
            get { return this._hangmogName; }
            set { this._hangmogName = value; }
        }

        public String Unit
        {
            get { return this._unit; }
            set { this._unit = value; }
        }

        public String Price
        {
            get { return this._price; }
            set { this._price = value; }
        }

        public String Quantity
        {
            get { return this._quantity; }
            set { this._quantity = value; }
        }

        public String Amount
        {
            get { return this._amount; }
            set { this._amount = value; }
        }

        public String InsurancePay
        {
            get { return this._insurancePay; }
            set { this._insurancePay = value; }
        }

        public String PatientPay
        {
            get { return this._patientPay; }
            set { this._patientPay = value; }
        }

        public String Discount
        {
            get { return this._discount; }
            set { this._discount = value; }
        }

        public String DeptReqCd
        {
            get { return this._deptReqCd; }
            set { this._deptReqCd = value; }
        }

        public String DeptReqNm
        {
            get { return this._deptReqNm; }
            set { this._deptReqNm = value; }
        }

        public String DoctorReqCd
        {
            get { return this._doctorReqCd; }
            set { this._doctorReqCd = value; }
        }

        public String DoctorReqNm
        {
            get { return this._doctorReqNm; }
            set { this._doctorReqNm = value; }
        }

        public String DeptExcCd
        {
            get { return this._deptExcCd; }
            set { this._deptExcCd = value; }
        }

        public String DeptExcNm
        {
            get { return this._deptExcNm; }
            set { this._deptExcNm = value; }
        }

        public String DoctorExcCd
        {
            get { return this._doctorExcCd; }
            set { this._doctorExcCd = value; }
        }

        public String DoctorExcNm
        {
            get { return this._doctorExcNm; }
            set { this._doctorExcNm = value; }
        }

        public String OrderGroupCd
        {
            get { return this._orderGroupCd; }
            set { this._orderGroupCd = value; }
        }

        public String OrderGroupNm
        {
            get { return this._orderGroupNm; }
            set { this._orderGroupNm = value; }
        }

        public String OrderDate
        {
            get { return this._orderDate; }
            set { this._orderDate = value; }
        }

        public String ActingDate
        {
            get { return this._actingDate; }
            set { this._actingDate = value; }
        }

        public String DiscountReason
        {
            get { return this._discountReason; }
            set { this._discountReason = value; }
        }

        public String CheckYn
        {
            get { return this._checkYn; }
            set { this._checkYn = value; }
        }

        public String Fkocs1003
        {
            get { return this._fkocs1003; }
            set { this._fkocs1003 = value; }
        }

        public String AmountPaid
        {
            get { return this._amountPaid; }
            set { this._amountPaid = value; }
        }

        public String AmountDebt
        {
            get { return this._amountDebt; }
            set { this._amountDebt = value; }
        }

        public String Fkout1001
        {
            get { return this._fkout1001; }
            set { this._fkout1001 = value; }
        }

        public String PatientAddress
        {
            get { return this._patientAddress; }
            set { this._patientAddress = value; }
        }

        public LoadGridBIL2016U02Info() { }

        public LoadGridBIL2016U02Info(String hangmogCode, String hangmogName, String unit, String price, String quantity, String amount, String insurancePay, String patientPay, String discount, String deptReqCd, String deptReqNm, String doctorReqCd, String doctorReqNm, String deptExcCd, String deptExcNm, String doctorExcCd, String doctorExcNm, String orderGroupCd, String orderGroupNm, String orderDate, String actingDate, String discountReason, String checkYn, String fkocs1003, String amountPaid, String amountDebt, String fkout1001, String patientAddress)
        {
            this._hangmogCode = hangmogCode;
            this._hangmogName = hangmogName;
            this._unit = unit;
            this._price = price;
            this._quantity = quantity;
            this._amount = amount;
            this._insurancePay = insurancePay;
            this._patientPay = patientPay;
            this._discount = discount;
            this._deptReqCd = deptReqCd;
            this._deptReqNm = deptReqNm;
            this._doctorReqCd = doctorReqCd;
            this._doctorReqNm = doctorReqNm;
            this._deptExcCd = deptExcCd;
            this._deptExcNm = deptExcNm;
            this._doctorExcCd = doctorExcCd;
            this._doctorExcNm = doctorExcNm;
            this._orderGroupCd = orderGroupCd;
            this._orderGroupNm = orderGroupNm;
            this._orderDate = orderDate;
            this._actingDate = actingDate;
            this._discountReason = discountReason;
            this._checkYn = checkYn;
            this._fkocs1003 = fkocs1003;
            this._amountPaid = amountPaid;
            this._amountDebt = amountDebt;
            this._fkout1001 = fkout1001;
            this._patientAddress = patientAddress;
        }

    }
}