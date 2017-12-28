using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    public class BIL0102U00PrintTemplateResult : AbstractContractResult
    {
        private String _template;

        public String Template
        {
            get { return this._template; }
            set { this._template = value; }
        }

        public BIL0102U00PrintTemplateResult() { }

    }
}