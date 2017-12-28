using System;
using IHIS.CloudConnector.Contracts.Models.Bass;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Bass
{
    public class LoadGrdBAS0260U01Args : IContractArgs
    {
        private String _language;
        private String _buseoName;
        private String _gwaName;
        private String _activeFlg;
        private String _buseoGubun;

        public String Language
        {
            get { return this._language; }
            set { this._language = value; }
        }

        public String BuseoName
        {
            get { return this._buseoName; }
            set { this._buseoName = value; }
        }

        public String GwaName
        {
            get { return this._gwaName; }
            set { this._gwaName = value; }
        }

        public String ActiveFlg
        {
            get { return this._activeFlg; }
            set { this._activeFlg = value; }
        }

        public String BuseoGubun
        {
            get { return this._buseoGubun; }
            set { this._buseoGubun = value; }
        }

        public LoadGrdBAS0260U01Args() { }

        public LoadGrdBAS0260U01Args(String language, String buseoName, String gwaName, String activeFlg, String buseoGubun)
        {
            this._language = language;
            this._buseoName = buseoName;
            this._gwaName = gwaName;
            this._activeFlg = activeFlg;
            this._buseoGubun = buseoGubun;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.LoadGrdBAS0260U01Request();
        }
    }
}