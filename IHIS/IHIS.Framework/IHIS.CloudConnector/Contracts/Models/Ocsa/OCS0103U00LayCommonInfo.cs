using System;

namespace IHIS.CloudConnector.Contracts.Models.Ocsa
{
    [Serializable]
    public class OCS0103U00LayCommonInfo
    {
        private String _name;
        private String _bulyong;
        private String _drgYn;

        public String Name
        {
            get { return this._name; }
            set { this._name = value; }
        }

        public String Bulyong
        {
            get { return this._bulyong; }
            set { this._bulyong = value; }
        }

        public String DrgYn
        {
            get { return this._drgYn; }
            set { this._drgYn = value; }
        }

        public OCS0103U00LayCommonInfo() { }

        public OCS0103U00LayCommonInfo(String name, String bulyong, String drgYn)
        {
            this._name = name;
            this._bulyong = bulyong;
            this._drgYn = drgYn;
        }

    }
}