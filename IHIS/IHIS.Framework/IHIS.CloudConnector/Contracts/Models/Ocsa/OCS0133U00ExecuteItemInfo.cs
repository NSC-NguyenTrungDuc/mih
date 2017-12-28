using System;

namespace IHIS.CloudConnector.Contracts.Models.Ocsa
{
    [Serializable]
    public class OCS0133U00ExecuteItemInfo
    {
        private String _userId;
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
        private String _wonyoiOrderCrYn;
        private String _powderCrYn;
        private String _rowState;

        public String UserId
        {
            get { return this._userId; }
            set { this._userId = value; }
        }

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

        public String WonyoiOrderCrYn
        {
            get { return this._wonyoiOrderCrYn; }
            set { this._wonyoiOrderCrYn = value; }
        }

        public String PowderCrYn
        {
            get { return this._powderCrYn; }
            set { this._powderCrYn = value; }
        }

        public String RowState
        {
            get { return this._rowState; }
            set { this._rowState = value; }
        }

        public OCS0133U00ExecuteItemInfo() { }

        public OCS0133U00ExecuteItemInfo(String userId, String inputControl, String inputControlName, String specimenCrYn, String suryangCrYn, String ordDanuiCrYn, String dvCrYn, String nalsuCrYn, String jusaCrYn, String bogyongCodeCrYn, String toiwonDrgCrYn, String portableCrYn, String amtCrYn, String wonyoiOrderCrYn, String powderCrYn, String rowState)
        {
            this._userId = userId;
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
            this._wonyoiOrderCrYn = wonyoiOrderCrYn;
            this._powderCrYn = powderCrYn;
            this._rowState = rowState;
        }

    }
}