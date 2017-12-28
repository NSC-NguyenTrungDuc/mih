using System;

namespace IHIS.CloudConnector.Contracts.Models.Cpls
{
    [Serializable]
    public class CPL0106U00GrdListItemInfo
    {
        private String _groupGubunA;
        private String _hangmogCode;
        private String _specimenCode;
        private String _emergency;
        private String _subHangmogCode;
        private String _subSpecimenCode;
        private String _specimenName;
        private String _subEmergency;
        private String _gumsaName;
        private String _continueYn;
        private String _groupGubunB;
        private String _sgCode;
        private String _rowState;

        public String GroupGubunA
        {
            get { return this._groupGubunA; }
            set { this._groupGubunA = value; }
        }

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

        public String SubHangmogCode
        {
            get { return this._subHangmogCode; }
            set { this._subHangmogCode = value; }
        }

        public String SubSpecimenCode
        {
            get { return this._subSpecimenCode; }
            set { this._subSpecimenCode = value; }
        }

        public String SpecimenName
        {
            get { return this._specimenName; }
            set { this._specimenName = value; }
        }

        public String SubEmergency
        {
            get { return this._subEmergency; }
            set { this._subEmergency = value; }
        }

        public String GumsaName
        {
            get { return this._gumsaName; }
            set { this._gumsaName = value; }
        }

        public String ContinueYn
        {
            get { return this._continueYn; }
            set { this._continueYn = value; }
        }

        public String GroupGubunB
        {
            get { return this._groupGubunB; }
            set { this._groupGubunB = value; }
        }

        public String SgCode
        {
            get { return this._sgCode; }
            set { this._sgCode = value; }
        }

        public String RowState
        {
            get { return this._rowState; }
            set { this._rowState = value; }
        }

        public CPL0106U00GrdListItemInfo() { }

        public CPL0106U00GrdListItemInfo(String groupGubunA, String hangmogCode, String specimenCode, String emergency, String subHangmogCode, String subSpecimenCode, String specimenName, String subEmergency, String gumsaName, String continueYn, String groupGubunB, String sgCode, String rowState)
        {
            this._groupGubunA = groupGubunA;
            this._hangmogCode = hangmogCode;
            this._specimenCode = specimenCode;
            this._emergency = emergency;
            this._subHangmogCode = subHangmogCode;
            this._subSpecimenCode = subSpecimenCode;
            this._specimenName = specimenName;
            this._subEmergency = subEmergency;
            this._gumsaName = gumsaName;
            this._continueYn = continueYn;
            this._groupGubunB = groupGubunB;
            this._sgCode = sgCode;
            this._rowState = rowState;
        }

    }
}