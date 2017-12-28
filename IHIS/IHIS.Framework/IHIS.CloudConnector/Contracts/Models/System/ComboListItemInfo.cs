using System;
using System.Collections.Generic;
using System.Text;

namespace IHIS.CloudConnector.Contracts.Models.System
{
    [Serializable]
    public class ComboListItemInfo
    {
        private string _code;
        private string _codeName;

        public ComboListItemInfo(string code, string codeName)
        {
            _code = code;
            _codeName = codeName;
        }

        public string Code
        {
            get { return _code; }
            set { _code = value; }
        }

        public string CodeName
        {
            get { return _codeName; }
            set { _codeName = value; }
        }

        public ComboListItemInfo()
        {
        }
    }
}
