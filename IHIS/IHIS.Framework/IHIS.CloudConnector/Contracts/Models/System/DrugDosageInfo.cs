using System;

namespace IHIS.CloudConnector.Contracts.Models.System
{
    [Serializable]
    public class DrugDosageInfo
    {
        private String _drugId;
        private String _branchNumber;
        private String _dosageBranchNumber;
        private String _a4;
        private String _a5;
        private String _adaptation;
        private String _adaptationRelated;
        private String _a8;
        private String _ageClssification;
        private String _appropriate;
        private String _appropriateCondition;
        private String _a12;
        private String _a13;
        private String _oneDose;

        public String DrugId
        {
            get { return this._drugId; }
            set { this._drugId = value; }
        }

        public String BranchNumber
        {
            get { return this._branchNumber; }
            set { this._branchNumber = value; }
        }

        public String DosageBranchNumber
        {
            get { return this._dosageBranchNumber; }
            set { this._dosageBranchNumber = value; }
        }

        public String A4
        {
            get { return this._a4; }
            set { this._a4 = value; }
        }

        public String A5
        {
            get { return this._a5; }
            set { this._a5 = value; }
        }

        public String Adaptation
        {
            get { return this._adaptation; }
            set { this._adaptation = value; }
        }

        public String AdaptationRelated
        {
            get { return this._adaptationRelated; }
            set { this._adaptationRelated = value; }
        }

        public String A8
        {
            get { return this._a8; }
            set { this._a8 = value; }
        }

        public String AgeClssification
        {
            get { return this._ageClssification; }
            set { this._ageClssification = value; }
        }

        public String Appropriate
        {
            get { return this._appropriate; }
            set { this._appropriate = value; }
        }

        public String AppropriateCondition
        {
            get { return this._appropriateCondition; }
            set { this._appropriateCondition = value; }
        }

        public String A12
        {
            get { return this._a12; }
            set { this._a12 = value; }
        }

        public String A13
        {
            get { return this._a13; }
            set { this._a13 = value; }
        }

        public String OneDose
        {
            get { return this._oneDose; }
            set { this._oneDose = value; }
        }

        public DrugDosageInfo() { }

        public DrugDosageInfo(String drugId, String branchNumber, String dosageBranchNumber, String a4, String a5, String adaptation, String adaptationRelated, String a8, String ageClssification, String appropriate, String appropriateCondition, String a12, String a13, String oneDose)
        {
            this._drugId = drugId;
            this._branchNumber = branchNumber;
            this._dosageBranchNumber = dosageBranchNumber;
            this._a4 = a4;
            this._a5 = a5;
            this._adaptation = adaptation;
            this._adaptationRelated = adaptationRelated;
            this._a8 = a8;
            this._ageClssification = ageClssification;
            this._appropriate = appropriate;
            this._appropriateCondition = appropriateCondition;
            this._a12 = a12;
            this._a13 = a13;
            this._oneDose = oneDose;
        }

    }
}