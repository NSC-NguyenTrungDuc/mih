using System;

namespace IHIS.CloudConnector.Contracts.Models.System
{
    [Serializable]
    public class DrugKinkiDiseaseInfo
    {
        private String _kinkiId;
        private String _diseaseName;
        private String _indexTerm;
        private String _standardDiseaseName;
        private String _diseaseCode;
        private String _icd10;
        private String _decisionFlg;
        private String _comment;

        public String KinkiId
        {
            get { return this._kinkiId; }
            set { this._kinkiId = value; }
        }

        public String DiseaseName
        {
            get { return this._diseaseName; }
            set { this._diseaseName = value; }
        }

        public String IndexTerm
        {
            get { return this._indexTerm; }
            set { this._indexTerm = value; }
        }

        public String StandardDiseaseName
        {
            get { return this._standardDiseaseName; }
            set { this._standardDiseaseName = value; }
        }

        public String DiseaseCode
        {
            get { return this._diseaseCode; }
            set { this._diseaseCode = value; }
        }

        public String Icd10
        {
            get { return this._icd10; }
            set { this._icd10 = value; }
        }

        public String DecisionFlg
        {
            get { return this._decisionFlg; }
            set { this._decisionFlg = value; }
        }

        public String Comment
        {
            get { return this._comment; }
            set { this._comment = value; }
        }

        public DrugKinkiDiseaseInfo() { }

        public DrugKinkiDiseaseInfo(String kinkiId, String diseaseName, String indexTerm, String standardDiseaseName, String diseaseCode, String icd10, String decisionFlg, String comment)
        {
            this._kinkiId = kinkiId;
            this._diseaseName = diseaseName;
            this._indexTerm = indexTerm;
            this._standardDiseaseName = standardDiseaseName;
            this._diseaseCode = diseaseCode;
            this._icd10 = icd10;
            this._decisionFlg = decisionFlg;
            this._comment = comment;
        }

    }
}