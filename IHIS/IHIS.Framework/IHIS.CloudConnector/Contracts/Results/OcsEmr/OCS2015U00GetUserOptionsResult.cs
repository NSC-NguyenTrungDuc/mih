using System;
using IHIS.CloudConnector.Contracts.Models.OcsEmr;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.OcsEmr
{
    public class OCS2015U00GetUserOptionsResult : AbstractContractResult
    {
        private String _allergyPopYn;
        private String _specialwritePopYn;
        private String _sameNameCheckYn;
        private String _vitalsignsPopYn;
        private String _emrPopYn;
        private String _orderLabelPrtYn;
        private String _potionDrugOrder;
        private String _diseaseNameUnregistered;
        private String _infection;
        private String _reserPrtYn;
        private String _doOrderPopYn;
        private String _emrBackRule;
        private String _emrBackTime;

        public String AllergyPopYn
        {
            get { return this._allergyPopYn; }
            set { this._allergyPopYn = value; }
        }

        public String SpecialwritePopYn
        {
            get { return this._specialwritePopYn; }
            set { this._specialwritePopYn = value; }
        }

        public String SameNameCheckYn
        {
            get { return this._sameNameCheckYn; }
            set { this._sameNameCheckYn = value; }
        }

        public String VitalsignsPopYn
        {
            get { return this._vitalsignsPopYn; }
            set { this._vitalsignsPopYn = value; }
        }

        public String EmrPopYn
        {
            get { return this._emrPopYn; }
            set { this._emrPopYn = value; }
        }

        public String OrderLabelPrtYn
        {
            get { return this._orderLabelPrtYn; }
            set { this._orderLabelPrtYn = value; }
        }

        public String PotionDrugOrder
        {
            get { return this._potionDrugOrder; }
            set { this._potionDrugOrder = value; }
        }

        public String DiseaseNameUnregistered
        {
            get { return this._diseaseNameUnregistered; }
            set { this._diseaseNameUnregistered = value; }
        }

        public String Infection
        {
            get { return this._infection; }
            set { this._infection = value; }
        }

        public String ReserPrtYn
        {
            get { return this._reserPrtYn; }
            set { this._reserPrtYn = value; }
        }

        public String DoOrderPopYn
        {
            get { return this._doOrderPopYn; }
            set { this._doOrderPopYn = value; }
        }

        public String EmrBackRule
        {
            get { return this._emrBackRule; }
            set { this._emrBackRule = value; }
        }

        public String EmrBackTime
        {
            get { return this._emrBackTime; }
            set { this._emrBackTime = value; }
        }

        public OCS2015U00GetUserOptionsResult() { }

    }
}