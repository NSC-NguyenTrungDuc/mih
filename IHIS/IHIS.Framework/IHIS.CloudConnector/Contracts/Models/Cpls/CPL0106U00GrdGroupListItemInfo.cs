using System;

namespace IHIS.CloudConnector.Contracts.Models.Cpls
{
    [Serializable]
    public class CPL0106U00GrdGroupListItemInfo
    {
        private String _groupGubun;
        private String _hangmogCode;
        private String _specimenCode;
        private String _emergency;
        private String _gumsaName;
        private String _jundalGubun;
        private String _specimenName;
        private String _jundalName;

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

        public String GumsaName
        {
            get { return this._gumsaName; }
            set { this._gumsaName = value; }
        }

        public String JundalGubun
        {
            get { return this._jundalGubun; }
            set { this._jundalGubun = value; }
        }

        public String SpecimenName
        {
            get { return this._specimenName; }
            set { this._specimenName = value; }
        }

        public String JundalName
        {
            get { return this._jundalName; }
            set { this._jundalName = value; }
        }

        public CPL0106U00GrdGroupListItemInfo() { }

        public CPL0106U00GrdGroupListItemInfo(String groupGubun, String hangmogCode, String specimenCode, String emergency, String gumsaName, String jundalGubun, String specimenName, String jundalName)
        {
            this._groupGubun = groupGubun;
            this._hangmogCode = hangmogCode;
            this._specimenCode = specimenCode;
            this._emergency = emergency;
            this._gumsaName = gumsaName;
            this._jundalGubun = jundalGubun;
            this._specimenName = specimenName;
            this._jundalName = jundalName;
        }

    }
}