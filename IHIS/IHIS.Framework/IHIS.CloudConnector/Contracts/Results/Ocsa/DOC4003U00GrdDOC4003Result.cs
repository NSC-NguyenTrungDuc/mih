using System;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
    public class DOC4003U00GrdDOC4003Result : AbstractContractResult
    {
        private List<DOC4003U00GrdDOC4003Info> _doc4003Item = new List<DOC4003U00GrdDOC4003Info>();

        public List<DOC4003U00GrdDOC4003Info> Doc4003Item
        {
            get { return this._doc4003Item; }
            set { this._doc4003Item = value; }
        }

        public DOC4003U00GrdDOC4003Result() { }

    }
}