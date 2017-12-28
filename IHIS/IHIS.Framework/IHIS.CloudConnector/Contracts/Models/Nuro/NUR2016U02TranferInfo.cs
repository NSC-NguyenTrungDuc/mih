using System;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Models.Nuro
{
    public class NUR2016U02TranferInfo
    {
        private String _bunho;
        private String _pkout1001;
        private List<NUR2016U02ListPkocsInfo> _listItem = new List<NUR2016U02ListPkocsInfo>();

        public String Bunho
        {
            get { return this._bunho; }
            set { this._bunho = value; }
        }

        public String Pkout1001
        {
            get { return this._pkout1001; }
            set { this._pkout1001 = value; }
        }

        public List<NUR2016U02ListPkocsInfo> ListItem
        {
            get { return this._listItem; }
            set { this._listItem = value; }
        }

        public NUR2016U02TranferInfo() { }

        public NUR2016U02TranferInfo(String bunho, String pkout1001, List<NUR2016U02ListPkocsInfo> listItem)
        {
            this._bunho = bunho;
            this._pkout1001 = pkout1001;
            this._listItem = listItem;
        }

    }
}