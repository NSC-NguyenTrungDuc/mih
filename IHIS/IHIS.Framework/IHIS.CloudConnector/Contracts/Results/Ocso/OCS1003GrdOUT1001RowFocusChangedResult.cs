using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Ocso;

namespace IHIS.CloudConnector.Contracts.Results.Ocso
{
    [Serializable]
    public class OCS1003GrdOUT1001RowFocusChangedResult : AbstractContractResult
    {
        private List<OCS1003Q02grdOCS1001Info> _grdOcs1001Info = new List<OCS1003Q02grdOCS1001Info>();
        private List<OCS1003Q02LayQueryLayoutInfo> _layQueryLayoutInfo = new List<OCS1003Q02LayQueryLayoutInfo>();

        public List<OCS1003Q02grdOCS1001Info> GrdOcs1001Info
        {
            get { return this._grdOcs1001Info; }
            set { this._grdOcs1001Info = value; }
        }

        public List<OCS1003Q02LayQueryLayoutInfo> LayQueryLayoutInfo
        {
            get { return this._layQueryLayoutInfo; }
            set { this._layQueryLayoutInfo = value; }
        }

        public OCS1003GrdOUT1001RowFocusChangedResult() { }

    }
}