using System;
using IHIS.CloudConnector.Contracts.Models.Bill;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Bill
{
    public class BIL2016R01GrdReportArgs : IContractArgs
    {
        private String _fromMonth;
        private String _toMonth;
        private String _fromDate;
        private String _toDate;
        private String _assignDept;
        private String _assignDoctor;
        private String _exeDept;
        private String _exeDoctor;
        private String _serviceId;
        private String _personId;
        private String _pageNumber;
        private String _offset;

        public String FromMonth
        {
            get { return this._fromMonth; }
            set { this._fromMonth = value; }
        }

        public String ToMonth
        {
            get { return this._toMonth; }
            set { this._toMonth = value; }
        }

        public String FromDate
        {
            get { return this._fromDate; }
            set { this._fromDate = value; }
        }

        public String ToDate
        {
            get { return this._toDate; }
            set { this._toDate = value; }
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

        public String ExeDept
        {
            get { return this._exeDept; }
            set { this._exeDept = value; }
        }

        public String ExeDoctor
        {
            get { return this._exeDoctor; }
            set { this._exeDoctor = value; }
        }

        public String ServiceId
        {
            get { return this._serviceId; }
            set { this._serviceId = value; }
        }

        public String PersonId
        {
            get { return this._personId; }
            set { this._personId = value; }
        }

        public String PageNumber
        {
            get { return this._pageNumber; }
            set { this._pageNumber = value; }
        }

        public String Offset
        {
            get { return this._offset; }
            set { this._offset = value; }
        }

        public BIL2016R01GrdReportArgs() { }

        public BIL2016R01GrdReportArgs(String fromMonth, String toMonth, String fromDate, String toDate, String assignDept, String assignDoctor, String exeDept, String exeDoctor, String serviceId, String personId, String pageNumber, String offset)
        {
            this._fromMonth = fromMonth;
            this._toMonth = toMonth;
            this._fromDate = fromDate;
            this._toDate = toDate;
            this._assignDept = assignDept;
            this._assignDoctor = assignDoctor;
            this._exeDept = exeDept;
            this._exeDoctor = exeDoctor;
            this._serviceId = serviceId;
            this._personId = personId;
            this._pageNumber = pageNumber;
            this._offset = offset;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.BIL2016R01GrdReportRequest();
        }
    }
}