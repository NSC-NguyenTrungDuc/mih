using System;

namespace IHIS.CloudConnector.Contracts.Models.Nuro
{
    public class BIL0102OrderListInfo
    {
        private String _orderName;
        private String _unit;
        private String _price;
        private String _quantity;
        private String _amount;
        private String _insurancePay;
        private String _patientPay;
        private String _deptReqNm;
        private String _doctorReqNm;
        private String _doctorExcNm;
        private String _orderGrpNm;
        private String _discountReason;
        private String _orderCode;
        private String _fkocs1003;

        public String OrderName
        {
            get { return this._orderName; }
            set { this._orderName = value; }
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

        public String DeptReqNm
        {
            get { return this._deptReqNm; }
            set { this._deptReqNm = value; }
        }

        public String DoctorReqNm
        {
            get { return this._doctorReqNm; }
            set { this._doctorReqNm = value; }
        }

        public String DoctorExcNm
        {
            get { return this._doctorExcNm; }
            set { this._doctorExcNm = value; }
        }

        public String OrderGrpNm
        {
            get { return this._orderGrpNm; }
            set { this._orderGrpNm = value; }
        }

        public String DiscountReason
        {
            get { return this._discountReason; }
            set { this._discountReason = value; }
        }

        public String OrderCode
        {
            get { return this._orderCode; }
            set { this._orderCode = value; }
        }

        public String Fkocs1003
        {
            get { return this._fkocs1003; }
            set { this._fkocs1003 = value; }
        }

        public BIL0102OrderListInfo() { }

        public BIL0102OrderListInfo(String orderName, String unit, String price, String quantity, String amount, String insurancePay, String patientPay, String deptReqNm, String doctorReqNm, String doctorExcNm, String orderGrpNm, String discountReason, String orderCode, String fkocs1003)
        {
            this._orderName = orderName;
            this._unit = unit;
            this._price = price;
            this._quantity = quantity;
            this._amount = amount;
            this._insurancePay = insurancePay;
            this._patientPay = patientPay;
            this._deptReqNm = deptReqNm;
            this._doctorReqNm = doctorReqNm;
            this._doctorExcNm = doctorExcNm;
            this._orderGrpNm = orderGrpNm;
            this._discountReason = discountReason;
            this._orderCode = orderCode;
            this._fkocs1003 = fkocs1003;
        }

    }
}