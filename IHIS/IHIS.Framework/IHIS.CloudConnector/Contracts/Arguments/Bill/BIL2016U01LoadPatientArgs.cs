using System;
using IHIS.CloudConnector.Contracts.Models.Bill;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Bill
{
    public class BIL2016U01LoadPatientArgs : IContractArgs
    {
        private String _commingDate;
        private String _bunho;
        private String _suname;
        private String _billNumber;
        private String _tab;
        private String _toDate;

        public String CommingDate
        {
            get { return this._commingDate; }
            set { this._commingDate = value; }
        }

        public String Bunho
        {
            get { return this._bunho; }
            set { this._bunho = value; }
        }

        public String Suname
        {
            get { return this._suname; }
            set { this._suname = value; }
        }

        public String BillNumber
        {
            get { return this._billNumber; }
            set { this._billNumber = value; }
        }

        public String Tab
        {
            get { return this._tab; }
            set { this._tab = value; }
        }

        public String ToDate
        {
            get { return this._toDate; }
            set { this._toDate = value; }
        }

        public BIL2016U01LoadPatientArgs() { }

        public BIL2016U01LoadPatientArgs(String commingDate, String bunho, String suname, String billNumber, String tab, String toDate)
        {
            this._commingDate = commingDate;
            this._bunho = bunho;
            this._suname = suname;
            this._billNumber = billNumber;
            this._tab = tab;
            this._toDate = toDate;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.BIL2016U01LoadPatientRequest();
        }
    }
}