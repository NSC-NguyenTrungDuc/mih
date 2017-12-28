using System;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    public class OCS0301U00LayQueryLayoutResult : AbstractContractResult
    {
        private List<OCS0301U00LayoutInfo> _layoutInfo = new List<OCS0301U00LayoutInfo>();
        private List<OCS0301U00Membgrd307Info> _listInfo = new List<OCS0301U00Membgrd307Info>();

        public List<OCS0301U00LayoutInfo> LayoutInfo
        {
            get { return this._layoutInfo; }
            set { this._layoutInfo = value; }
        }

        public List<OCS0301U00Membgrd307Info> ListInfo
        {
            get { return this._listInfo; }
            set { this._listInfo = value; }
        }

        public OCS0301U00LayQueryLayoutResult() { }

    }
}