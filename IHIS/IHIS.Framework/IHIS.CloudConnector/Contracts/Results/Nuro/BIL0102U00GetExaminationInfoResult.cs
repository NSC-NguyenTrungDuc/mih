using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;
using IHIS.CloudConnector.Messaging;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    public class BIL0102U00GetExaminationInfoResult : AbstractContractResult
    {
        private String _naewonDate;
        private String _jubsuTime;
        private IHIS.CloudConnector.Contracts.Models.Nuro.BIL0102U00GetbankInfo _bankInfo;

        public String NaewonDate
        {
            get { return this._naewonDate; }
            set { this._naewonDate = value; }
        }

        public String JubsuTime
        {
            get { return this._jubsuTime; }
            set { this._jubsuTime = value; }
        }

        public IHIS.CloudConnector.Contracts.Models.Nuro.BIL0102U00GetbankInfo BankInfo
        {
            get { return this._bankInfo; }
            set { this._bankInfo = value; }
        }

        public BIL0102U00GetExaminationInfoResult() { }

    }
}