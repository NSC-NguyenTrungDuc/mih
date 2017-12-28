using System;
using IHIS.CloudConnector.Contracts.Models.Endo;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Endo
{
    [Serializable]
    public class END1001U02LoadCommentsResult : AbstractContractResult
    {
        private List<END1001U02StrInfo> _grdcomment1Item = new List<END1001U02StrInfo>();
        private List<END1001U02StrInfo> _grdcomment2Item = new List<END1001U02StrInfo>();
        private List<END1001U02LayOrderDateInfo> _layorderdateItem = new List<END1001U02LayOrderDateInfo>();

        public List<END1001U02StrInfo> Grdcomment1Item
        {
            get { return this._grdcomment1Item; }
            set { this._grdcomment1Item = value; }
        }

        public List<END1001U02StrInfo> Grdcomment2Item
        {
            get { return this._grdcomment2Item; }
            set { this._grdcomment2Item = value; }
        }

        public List<END1001U02LayOrderDateInfo> LayorderdateItem
        {
            get { return this._layorderdateItem; }
            set { this._layorderdateItem = value; }
        }

        public END1001U02LoadCommentsResult() { }

    }
}