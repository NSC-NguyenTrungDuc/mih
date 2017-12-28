using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    public class BIL0102U00GetMailTemplateResult : AbstractContractResult
    {
        private String _mailTemplateId;
        private String _subject;
        private String _content;
        private String _gmoLink;
        private String _invoiceNo;

        public String MailTemplateId
        {
            get { return this._mailTemplateId; }
            set { this._mailTemplateId = value; }
        }

        public String Subject
        {
            get { return this._subject; }
            set { this._subject = value; }
        }

        public String Content
        {
            get { return this._content; }
            set { this._content = value; }
        }

        public String GmoLink
        {
            get { return this._gmoLink; }
            set { this._gmoLink = value; }
        }

        public String InvoiceNo
        {
            get { return this._invoiceNo; }
            set { this._invoiceNo = value; }
        }

        public BIL0102U00GetMailTemplateResult() { }

    }
}