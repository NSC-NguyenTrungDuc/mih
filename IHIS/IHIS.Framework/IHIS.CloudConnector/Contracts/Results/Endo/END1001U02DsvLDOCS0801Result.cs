using System;
using IHIS.CloudConnector.Contracts.Models.Endo;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Endo
{
    [Serializable]
    public class END1001U02DsvLDOCS0801Result : AbstractContractResult
    {
        private List<END1001U02DsvLDOCS0801Info> _dsvLdocs0801Item = new List<END1001U02DsvLDOCS0801Info>();

        public List<END1001U02DsvLDOCS0801Info> DsvLdocs0801Item
        {
            get { return this._dsvLdocs0801Item; }
            set { this._dsvLdocs0801Item = value; }
        }

        public END1001U02DsvLDOCS0801Result() { }

    }
}