using System;

namespace IHIS.CloudConnector.Contracts.Models.Ocsa
{
    public class OCS0150Q00GridOCS0150Info
    {
        private String _doctor;
        private String _doctorName;
        private String _gwa;
        private String _gwaName;
        private String _ioGubun;
        private String _hospCode;
        private String _drgPrtYn;
        private String _xrtPrtYn;
        private String _reserPrtYn;
        private String _vitalsignsPopYn;
        private String _allergyPopYn;
        private String _specialwritePopYn;
        private String _emrPopYn;
        private String _doOrderPopYn;
        private String _sentouSearchYn;
        private String _orderLabelPrtYn;
        private String _generalDispYn;
        private String _sameNameCheckYn;
        private String _checkingDrugYn;
        private String _dataRowState;
        private String _potionDrugOrder;
        private String _diseaseNameUnregistered;
        private String _infection;
        private String _emrBakRemindRule;
        private String _emrBakRemindTime;

        public String Doctor
        {
            get { return this._doctor; }
            set { this._doctor = value; }
        }

        public String DoctorName
        {
            get { return this._doctorName; }
            set { this._doctorName = value; }
        }

        public String Gwa
        {
            get { return this._gwa; }
            set { this._gwa = value; }
        }

        public String GwaName
        {
            get { return this._gwaName; }
            set { this._gwaName = value; }
        }

        public String IoGubun
        {
            get { return this._ioGubun; }
            set { this._ioGubun = value; }
        }

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public String DrgPrtYn
        {
            get { return this._drgPrtYn; }
            set { this._drgPrtYn = value; }
        }

        public String XrtPrtYn
        {
            get { return this._xrtPrtYn; }
            set { this._xrtPrtYn = value; }
        }

        public String ReserPrtYn
        {
            get { return this._reserPrtYn; }
            set { this._reserPrtYn = value; }
        }

        public String VitalsignsPopYn
        {
            get { return this._vitalsignsPopYn; }
            set { this._vitalsignsPopYn = value; }
        }

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

        public String EmrPopYn
        {
            get { return this._emrPopYn; }
            set { this._emrPopYn = value; }
        }

        public String DoOrderPopYn
        {
            get { return this._doOrderPopYn; }
            set { this._doOrderPopYn = value; }
        }

        public String SentouSearchYn
        {
            get { return this._sentouSearchYn; }
            set { this._sentouSearchYn = value; }
        }

        public String OrderLabelPrtYn
        {
            get { return this._orderLabelPrtYn; }
            set { this._orderLabelPrtYn = value; }
        }

        public String GeneralDispYn
        {
            get { return this._generalDispYn; }
            set { this._generalDispYn = value; }
        }

        public String SameNameCheckYn
        {
            get { return this._sameNameCheckYn; }
            set { this._sameNameCheckYn = value; }
        }

        public String CheckingDrugYn
        {
            get { return this._checkingDrugYn; }
            set { this._checkingDrugYn = value; }
        }

        public String DataRowState
        {
            get { return this._dataRowState; }
            set { this._dataRowState = value; }
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

        public String EmrBakRemindRule
        {
            get { return this._emrBakRemindRule; }
            set { this._emrBakRemindRule = value; }
        }

        public String EmrBakRemindTime
        {
            get { return this._emrBakRemindTime; }
            set { this._emrBakRemindTime = value; }
        }

        public OCS0150Q00GridOCS0150Info() { }

        public OCS0150Q00GridOCS0150Info(String doctor, String doctorName, String gwa, String gwaName, String ioGubun, String hospCode, String drgPrtYn, String xrtPrtYn, String reserPrtYn, String vitalsignsPopYn, String allergyPopYn, String specialwritePopYn, String emrPopYn, String doOrderPopYn, String sentouSearchYn, String orderLabelPrtYn, String generalDispYn, String sameNameCheckYn, String checkingDrugYn, String dataRowState, String potionDrugOrder, String diseaseNameUnregistered, String infection, String emrBakRemindRule, String emrBakRemindTime)
        {
            this._doctor = doctor;
            this._doctorName = doctorName;
            this._gwa = gwa;
            this._gwaName = gwaName;
            this._ioGubun = ioGubun;
            this._hospCode = hospCode;
            this._drgPrtYn = drgPrtYn;
            this._xrtPrtYn = xrtPrtYn;
            this._reserPrtYn = reserPrtYn;
            this._vitalsignsPopYn = vitalsignsPopYn;
            this._allergyPopYn = allergyPopYn;
            this._specialwritePopYn = specialwritePopYn;
            this._emrPopYn = emrPopYn;
            this._doOrderPopYn = doOrderPopYn;
            this._sentouSearchYn = sentouSearchYn;
            this._orderLabelPrtYn = orderLabelPrtYn;
            this._generalDispYn = generalDispYn;
            this._sameNameCheckYn = sameNameCheckYn;
            this._checkingDrugYn = checkingDrugYn;
            this._dataRowState = dataRowState;
            this._potionDrugOrder = potionDrugOrder;
            this._diseaseNameUnregistered = diseaseNameUnregistered;
            this._infection = infection;
            this._emrBakRemindRule = emrBakRemindRule;
            this._emrBakRemindTime = emrBakRemindTime;
        }

    }
}