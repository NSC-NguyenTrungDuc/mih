using System;

namespace IHIS.CloudConnector.Contracts.Models.Bill
{
    public class BIL2016R01GrdReportInfo
    {
        private String _serviceId;
        private String _serviceName;
        private String _executeDept;
        private String _executeDoctor;
        private String _assignDept;
        private String _assignDoctor;
        private String _actingDate;
        private String _quantity;
        private String _sum;
        private String _discount;
        private String _amountPaid;

        public String ServiceId
        {
            get { return this._serviceId; }
            set { this._serviceId = value; }
        }

        public String ServiceName
        {
            get { return this._serviceName; }
            set { this._serviceName = value; }
        }

        public String ExecuteDept
        {
            get { return this._executeDept; }
            set { this._executeDept = value; }
        }

        public String ExecuteDoctor
        {
            get { return this._executeDoctor; }
            set { this._executeDoctor = value; }
        }

        public String AssignDept
        {
            get { return this._assignDept; }
            set { this._assignDept = value; }
        }

        public String AssignDoctor
        {
            get { return this._assignDoctor; }
            set { this._assignDoctor = value; }
        }

        public String ActingDate
        {
            get { return this._actingDate; }
            set { this._actingDate = value; }
        }

        public String Quantity
        {
            get { return this._quantity; }
            set { this._quantity = value; }
        }

        public String Sum
        {
            get { return this._sum; }
            set { this._sum = value; }
        }

        public String Discount
        {
            get { return this._discount; }
            set { this._discount = value; }
        }

        public String AmountPaid
        {
            get { return this._amountPaid; }
            set { this._amountPaid = value; }
        }

        public BIL2016R01GrdReportInfo() { }

        public BIL2016R01GrdReportInfo(String serviceId, String serviceName, String executeDept, String executeDoctor, String assignDept, String assignDoctor, String actingDate, String quantity, String sum, String discount, String amountPaid)
        {
            this._serviceId = serviceId;
            this._serviceName = serviceName;
            this._executeDept = executeDept;
            this._executeDoctor = executeDoctor;
            this._assignDept = assignDept;
            this._assignDoctor = assignDoctor;
            this._actingDate = actingDate;
            this._quantity = quantity;
            this._sum = sum;
            this._discount = discount;
            this._amountPaid = amountPaid;
        }

    }
}