using System;

namespace IHIS.CloudConnector.Contracts.Models.Ocsa
{
    [Serializable]
    public class OCS0133U00grdOCS0133ItemInfo
    {
        private String _inputControl;
        private String _inputControlName;
        private String _specimenCrYn;
        private String _suryangCrYn;
        private String _ordDanuiCrYn;
        private String _dvCrYn;
        private String _nalsuCrYn;
        private String _jusaCrYn;
        private String _bogyongCodeCrYn;
        private String _toiwonDrgCrYn;
        private String _portableCrYn;
        private String _amtCrYn;
        private String _wonyoiOrderYnCrYn;
        private String _powderYnCrYn;

        public String InputControl
        {
            get { return this._inputControl; }
            set { this._inputControl = value; }
        }

        public String InputControlName
        {
            get { return this._inputControlName; }
            set { this._inputControlName = value; }
        }

        public String SpecimenCrYn
        {
            get { return this._specimenCrYn; }
            set { this._specimenCrYn = value; }
        }

        public String SuryangCrYn
        {
            get { return this._suryangCrYn; }
            set { this._suryangCrYn = value; }
        }

        public String OrdDanuiCrYn
        {
            get { return this._ordDanuiCrYn; }
            set { this._ordDanuiCrYn = value; }
        }

        public String DvCrYn
        {
            get { return this._dvCrYn; }
            set { this._dvCrYn = value; }
        }

        public String NalsuCrYn
        {
            get { return this._nalsuCrYn; }
            set { this._nalsuCrYn = value; }
        }

        public String JusaCrYn
        {
            get { return this._jusaCrYn; }
            set { this._jusaCrYn = value; }
        }

        public String BogyongCodeCrYn
        {
            get { return this._bogyongCodeCrYn; }
            set { this._bogyongCodeCrYn = value; }
        }

        public String ToiwonDrgCrYn
        {
            get { return this._toiwonDrgCrYn; }
            set { this._toiwonDrgCrYn = value; }
        }

        public String PortableCrYn
        {
            get { return this._portableCrYn; }
            set { this._portableCrYn = value; }
        }

        public String AmtCrYn
        {
            get { return this._amtCrYn; }
            set { this._amtCrYn = value; }
        }

        public String WonyoiOrderYnCrYn
        {
            get { return this._wonyoiOrderYnCrYn; }
            set { this._wonyoiOrderYnCrYn = value; }
        }

        public String PowderYnCrYn
        {
            get { return this._powderYnCrYn; }
            set { this._powderYnCrYn = value; }
        }

        public OCS0133U00grdOCS0133ItemInfo() { }

        public OCS0133U00grdOCS0133ItemInfo(String inputControl, String inputControlName, String specimenCrYn, String suryangCrYn, String ordDanuiCrYn, String dvCrYn, String nalsuCrYn, String jusaCrYn, String bogyongCodeCrYn, String toiwonDrgCrYn, String portableCrYn, String amtCrYn, String wonyoiOrderYnCrYn, String powderYnCrYn)
        {
            this._inputControl = inputControl;
            this._inputControlName = inputControlName;
            this._specimenCrYn = specimenCrYn;
            this._suryangCrYn = suryangCrYn;
            this._ordDanuiCrYn = ordDanuiCrYn;
            this._dvCrYn = dvCrYn;
            this._nalsuCrYn = nalsuCrYn;
            this._jusaCrYn = jusaCrYn;
            this._bogyongCodeCrYn = bogyongCodeCrYn;
            this._toiwonDrgCrYn = toiwonDrgCrYn;
            this._portableCrYn = portableCrYn;
            this._amtCrYn = amtCrYn;
            this._wonyoiOrderYnCrYn = wonyoiOrderYnCrYn;
            this._powderYnCrYn = powderYnCrYn;
        }

    }
}