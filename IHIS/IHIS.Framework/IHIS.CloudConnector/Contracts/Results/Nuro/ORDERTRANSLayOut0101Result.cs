using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable]
    public class ORDERTRANSLayOut0101Result : AbstractContractResult
    {
        private List<ORDERTRANSLayOut0101Info> _layOut0101Item = new List<ORDERTRANSLayOut0101Info>();

        public List<ORDERTRANSLayOut0101Info> LayOut0101Item
        {
            get { return this._layOut0101Item; }
            set { this._layOut0101Item = value; }
        }

        public ORDERTRANSLayOut0101Result() { }

    }
}