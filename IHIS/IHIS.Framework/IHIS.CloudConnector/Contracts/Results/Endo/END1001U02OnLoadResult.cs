using System;
using IHIS.CloudConnector.Contracts.Models.Endo;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Endo
{
    [Serializable]
    public class END1001U02OnLoadResult : AbstractContractResult
    {
        private List<END1001U02DsvDwInfo> _onloadDsvdwItem = new List<END1001U02DsvDwInfo>();
        private List<END1001U02StrInfo> _onloadDsvgumsanameItem = new List<END1001U02StrInfo>();
        private List<END1001U02GrdPurposeInfo> _onloadGrdpurposeItem = new List<END1001U02GrdPurposeInfo>();
        private List<END1001U02DsvLDOCS0801Info> _onloadDsvldocs0801Item = new List<END1001U02DsvLDOCS0801Info>();
        private List<END1001U02GrdPaStatusInfo> _onloadGrdpastatusItem = new List<END1001U02GrdPaStatusInfo>();

        public List<END1001U02DsvDwInfo> OnloadDsvdwItem
        {
            get { return this._onloadDsvdwItem; }
            set { this._onloadDsvdwItem = value; }
        }

        public List<END1001U02StrInfo> OnloadDsvgumsanameItem
        {
            get { return this._onloadDsvgumsanameItem; }
            set { this._onloadDsvgumsanameItem = value; }
        }

        public List<END1001U02GrdPurposeInfo> OnloadGrdpurposeItem
        {
            get { return this._onloadGrdpurposeItem; }
            set { this._onloadGrdpurposeItem = value; }
        }

        public List<END1001U02DsvLDOCS0801Info> OnloadDsvldocs0801Item
        {
            get { return this._onloadDsvldocs0801Item; }
            set { this._onloadDsvldocs0801Item = value; }
        }

        public List<END1001U02GrdPaStatusInfo> OnloadGrdpastatusItem
        {
            get { return this._onloadGrdpastatusItem; }
            set { this._onloadGrdpastatusItem = value; }
        }

        public END1001U02OnLoadResult() { }

    }
}