using System;

namespace IHIS.CloudConnector.Contracts.Models.Nuro
{
    [Serializable]
    public class NuroOUT1101Q01PrintNameInfo
    {
        public NuroOUT1101Q01PrintNameInfo() {}
    
        private string _codeName = "";
        public string CodeName
        {
            get { return _codeName; }
            set { _codeName = value; }
        }
        private string _sortKey = "";
        public string SortKey
        {
            get { return _sortKey; }
            set { _sortKey = value; }
        }
    }
}