using System;
using System.Collections.Generic;
using System.Text;
using IHIS.CloudConnector.Contracts.Models.Nuro;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable]
    public class NuroCboZipCodeResult : AbstractContractResult
    {
        IList<NuroCboZipCodeInfo> _lstCboZipCodeInfos = new List<NuroCboZipCodeInfo>();

        public NuroCboZipCodeResult()
        {
        }

        public IList<NuroCboZipCodeInfo> LstCboZipCodeInfos
        {
            get { return _lstCboZipCodeInfos; }
            set { _lstCboZipCodeInfos = value; }
        }
    }
}
