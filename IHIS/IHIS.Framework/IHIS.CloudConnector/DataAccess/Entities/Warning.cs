using System;
using System.Collections.Generic;
using System.Text;

namespace IHIS.CloudConnector.DataAccess.Entities
{
    public class Warning
    {
        private string warningLevel;

        public string WarningLevel
        {
            get { return warningLevel; }
            set { warningLevel = value; }
        }

        private string messageLevel;

        public string MessageLevel
        {
            get { return messageLevel; }
            set { messageLevel = value; }
        }

        

    }
}
