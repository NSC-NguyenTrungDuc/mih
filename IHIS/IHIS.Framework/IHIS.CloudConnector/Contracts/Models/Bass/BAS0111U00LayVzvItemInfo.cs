using System;

namespace IHIS.CloudConnector.Contracts.Models.Bass
{
    [Serializable]
    public class BAS0111U00LayVzvItemInfo
    {
        private String _name;

        public String Name
        {
            get { return this._name; }
            set { this._name = value; }
        }

        public BAS0111U00LayVzvItemInfo() { }

        public BAS0111U00LayVzvItemInfo(String name)
        {
            this._name = name;
        }

    }
}