using System;
using System.Collections.Generic;
using System.Text;

namespace IHIS.CloudConnector.DataAccess.Entities
{
    public class DrugKinkiMessage
    {
        private string drugId;

        public string DrugId
        {
            get { return drugId; }
            set { drugId = value; }
        }

        private string branchNumber;

        public string BranchNumber
        {
            get { return branchNumber; }
            set { branchNumber = value; }
        }

        private string warningLevel;
        public string WarningLevel
        {
            get { return warningLevel; }
            set { warningLevel = value; }
        }

        private string kinkiId;
        public string KinkiId
        {
            get { return kinkiId; }
            set { kinkiId = value; }
        }

        private string message;
        public string Message
        {
            get { return message; }
            set { message = value; }
        }

        private string category;
        public string Category
        {
            get { return category; }
            set { category = value; }
        }

    }
}
