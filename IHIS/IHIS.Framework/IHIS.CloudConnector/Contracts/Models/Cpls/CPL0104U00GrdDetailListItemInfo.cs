using System;

namespace IHIS.CloudConnector.Contracts.Models.Cpls
{
    [Serializable]
    public class CPL0104U00GrdDetailListItemInfo
    {
        private String _hangmogCode;
        private String _specimenCode;
        private String _emergency;
        private String _sex;
        private String _naiFrom;
        private String _naiTo;
        private String _fromAge;
        private String _toAge;
        private String _fromStandard;
        private String _toStandard;
        private String _rowState;

        public String HangmogCode
        {
            get { return this._hangmogCode; }
            set { this._hangmogCode = value; }
        }

        public String SpecimenCode
        {
            get { return this._specimenCode; }
            set { this._specimenCode = value; }
        }

        public String Emergency
        {
            get { return this._emergency; }
            set { this._emergency = value; }
        }

        public String Sex
        {
            get { return this._sex; }
            set { this._sex = value; }
        }

        public String NaiFrom
        {
            get { return this._naiFrom; }
            set { this._naiFrom = value; }
        }

        public String NaiTo
        {
            get { return this._naiTo; }
            set { this._naiTo = value; }
        }

        public String FromAge
        {
            get { return this._fromAge; }
            set { this._fromAge = value; }
        }

        public String ToAge
        {
            get { return this._toAge; }
            set { this._toAge = value; }
        }

        public String FromStandard
        {
            get { return this._fromStandard; }
            set { this._fromStandard = value; }
        }

        public String ToStandard
        {
            get { return this._toStandard; }
            set { this._toStandard = value; }
        }

        public String RowState
        {
            get { return this._rowState; }
            set { this._rowState = value; }
        }

        public CPL0104U00GrdDetailListItemInfo() { }

        public CPL0104U00GrdDetailListItemInfo(String hangmogCode, String specimenCode, String emergency, String sex, String naiFrom, String naiTo, String fromAge, String toAge, String fromStandard, String toStandard, String rowState)
        {
            this._hangmogCode = hangmogCode;
            this._specimenCode = specimenCode;
            this._emergency = emergency;
            this._sex = sex;
            this._naiFrom = naiFrom;
            this._naiTo = naiTo;
            this._fromAge = fromAge;
            this._toAge = toAge;
            this._fromStandard = fromStandard;
            this._toStandard = toStandard;
            this._rowState = rowState;
        }

    }
}