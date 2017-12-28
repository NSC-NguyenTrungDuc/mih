using System;
using System.Collections.Generic;
using System.Text;

namespace IHIS.CloudConnector.DataAccess.Entities
{
    public class DrugKinkiDisease
    {
        private string kinkiId;

        public string KinkiId
        {
            get { return kinkiId; }
            set { kinkiId = value; }
        }

        private string diseaseName;

        public string DiseaseName
        {
            get { return diseaseName; }
            set { diseaseName = value; }
        }

        private string indexTerm;
        public string IndexTerm
        {
            get { return indexTerm; }
            set { indexTerm = value; }
        }

        private string standardDiseaseName;
        public string StandardDiseaseName
        {
            get { return standardDiseaseName; }
            set { standardDiseaseName = value; }
        }

        private string diseaseCode;
        public string DiseaseCode
        {
            get { return diseaseCode; }
            set { diseaseCode = value; }
        }

        private string icd10;
        public string Icd10
        {
            get { return icd10; }
            set { icd10 = value; }
        }

        private string dicisionFlag;
        public string DicisionFlag
        {
            get { return dicisionFlag; }
            set { dicisionFlag = value; }
        }

        private string comment;
        public string Comment
        {
            get { return comment; }
            set { comment = value; }
        }
    }
}
