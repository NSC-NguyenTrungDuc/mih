using System;
using IHIS.CloudConnector.Contracts.Models.Ocso;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Ocso
{
    [Serializable]
    public class OCS2016U00GrdQuestionResult : AbstractContractResult
    {
        private List<OCS2016U00GrdQuestionInfo> _listQuestionInfo = new List<OCS2016U00GrdQuestionInfo>();

        public List<OCS2016U00GrdQuestionInfo> ListQuestionInfo
        {
            get { return this._listQuestionInfo; }
            set { this._listQuestionInfo = value; }
        }

        public OCS2016U00GrdQuestionResult() { }

    }
}