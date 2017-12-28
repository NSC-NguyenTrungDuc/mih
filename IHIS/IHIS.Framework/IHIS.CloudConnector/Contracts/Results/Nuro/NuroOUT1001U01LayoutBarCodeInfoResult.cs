using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Nuro;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable]
    public class NuroOUT1001U01LayoutBarCodeInfoResult : AbstractContractResult
    {
        private List<NuroOUT1001U01LayoutBarCodeInfo> _barCodeItem = new List<NuroOUT1001U01LayoutBarCodeInfo>();

        public List<NuroOUT1001U01LayoutBarCodeInfo> BarCodeItem
        {
            get { return this._barCodeItem; }
            set { this._barCodeItem = value; }
        }

        public NuroOUT1001U01LayoutBarCodeInfoResult() { }

    }
}
