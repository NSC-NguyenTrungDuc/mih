using System;

namespace IHIS.CloudConnector.Contracts.Models.Cpls
{
    [Serializable]
    public class CPL0104U00GrdMasterListItemInfo
    {
        private String _hangmogCode;
        private String _specimenCode;
        private String _codeName;
        private String _emergency;
        private String _gumsaName;

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

        public String CodeName
        {
            get { return this._codeName; }
            set { this._codeName = value; }
        }

        public String Emergency
        {
            get { return this._emergency; }
            set { this._emergency = value; }
        }

        public String GumsaName
        {
            get { return this._gumsaName; }
            set { this._gumsaName = value; }
        }

        public CPL0104U00GrdMasterListItemInfo() { }

        public CPL0104U00GrdMasterListItemInfo(String hangmogCode, String specimenCode, String codeName, String emergency, String gumsaName)
        {
            this._hangmogCode = hangmogCode;
            this._specimenCode = specimenCode;
            this._codeName = codeName;
            this._emergency = emergency;
            this._gumsaName = gumsaName;
        }

    }
}