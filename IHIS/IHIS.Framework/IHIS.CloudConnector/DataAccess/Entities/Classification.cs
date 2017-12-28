using System;
using System.Collections.Generic;
using System.Text;

namespace IHIS.CloudConnector.DataAccess.Entities
{
    public class Classification
    {
        private string describedClassification;

        public string DescribedClassification
        {
            get { return describedClassification; }
            set { describedClassification = value; }
        }

        private string describedClassificationNote;

        public string DescribedClassificationNote
        {
            get { return describedClassificationNote; }
            set { describedClassificationNote = value; }
        }

        

    }
}
