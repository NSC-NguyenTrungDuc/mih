using System;
using System.Collections.Generic;
using System.Text;

namespace IHIS.CloudConnector.DataAccess.Entities
{
    public class OrderTemp
    {
        private string yjCode;

        public string YJCode
        {
            get { return yjCode; }
            set { yjCode = value; }
        }

        private string yjName;

        public string YJName
        {
            get { return yjName; }
            set { yjName = value; }
        }

        

    }
}
