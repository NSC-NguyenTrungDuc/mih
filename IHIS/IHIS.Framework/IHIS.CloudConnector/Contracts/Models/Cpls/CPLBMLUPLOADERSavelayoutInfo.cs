using System;

namespace IHIS.CloudConnector.Contracts.Models.Cpls
{
    [Serializable]
    public class CPLBMLUPLOADERSavelayoutInfo
    {
        private String _userId;
        private String _groupGubun;
        private String _hangmogCode;
        private String _specimenCode;
        private String _emergency;
        private String _subHangmogCode;
        private String _subSpecimenCode;
        private String _subEmergency;
        private String _continueYn;

        public String UserId
        {
            get { return this._userId; }
            set { this._userId = value; }
        }

        public String GroupGubun
        {
            get { return this._groupGubun; }
            set { this._groupGubun = value; }
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

        public String SubEmergency
        {
            get { return this._subEmergency; }
            set { this._subEmergency = value; }
        }

        public String ContinueYn
        {
            get { return this._continueYn; }
            set { this._continueYn = value; }
        }

        public CPLBMLUPLOADERSavelayoutInfo() { }

        public CPLBMLUPLOADERSavelayoutInfo(String userId, String groupGubun, String hangmogCode, String specimenCode, String emergency, String subHangmogCode, String subSpecimenCode, String subEmergency, String continueYn)
        {
            this._userId = userId;
            this._groupGubun = groupGubun;
            this._hangmogCode = hangmogCode;
            this._specimenCode = specimenCode;
            this._emergency = emergency;
            this._subHangmogCode = subHangmogCode;
            this._subSpecimenCode = subSpecimenCode;
            this._subEmergency = subEmergency;
            this._continueYn = continueYn;
        }

    }
}