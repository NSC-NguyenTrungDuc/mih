using System;
using IHIS.CloudConnector.Contracts.Models.Ocso;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Ocso
{
    [Serializable]
    public class OCSACTGrdJaeryoGridColumnChangedResult : AbstractContractResult
    {
        private List<OCSACTGrdJaeryoGridColumnChangedInfo> _dt1Item = new List<OCSACTGrdJaeryoGridColumnChangedInfo>();
        private List<OCSACTGrdJaeryoGridColumnChangedInfo> _dt2Item = new List<OCSACTGrdJaeryoGridColumnChangedInfo>();

        public List<OCSACTGrdJaeryoGridColumnChangedInfo> Dt1Item
        {
            get { return this._dt1Item; }
            set { this._dt1Item = value; }
        }

        public List<OCSACTGrdJaeryoGridColumnChangedInfo> Dt2Item
        {
            get { return this._dt2Item; }
            set { this._dt2Item = value; }
        }

        public OCSACTGrdJaeryoGridColumnChangedResult() { }

    }
}