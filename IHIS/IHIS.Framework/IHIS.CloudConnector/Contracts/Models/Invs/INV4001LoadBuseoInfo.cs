using System;

namespace IHIS.CloudConnector.Contracts.Models.Invs
{
    public class INV4001LoadBuseoInfo
    {
        private String _buseoCode;
        private String _buseoName;

        public String BuseoCode
        {
            get { return this._buseoCode; }
            set { this._buseoCode = value; }
        }

        public String BuseoName
        {
            get { return this._buseoName; }
            set { this._buseoName = value; }
        }

        public INV4001LoadBuseoInfo() { }

        public INV4001LoadBuseoInfo(String buseoCode, String buseoName)
        {
            this._buseoCode = buseoCode;
            this._buseoName = buseoName;
        }

    }
}