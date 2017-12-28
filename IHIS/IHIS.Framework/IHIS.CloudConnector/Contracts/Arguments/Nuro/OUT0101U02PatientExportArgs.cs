using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    public class OUT0101U02PatientExportArgs : IContractArgs
    {
        private String _startDate;
        private String _endDate;
        private OUT0101U02PatientExportInfo _headerItem;

        public String StartDate
        {
            get { return this._startDate; }
            set { this._startDate = value; }
        }

        public String EndDate
        {
            get { return this._endDate; }
            set { this._endDate = value; }
        }

        public OUT0101U02PatientExportInfo HeaderItem
        {
            get { return this._headerItem; }
            set { this._headerItem = value; }
        }

        public OUT0101U02PatientExportArgs() { }

        public OUT0101U02PatientExportArgs(String startDate, String endDate, OUT0101U02PatientExportInfo headerItem)
        {
            this._startDate = startDate;
            this._endDate = endDate;
            this._headerItem = headerItem;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OUT0101U02PatientExportRequest();
        }
    }
}