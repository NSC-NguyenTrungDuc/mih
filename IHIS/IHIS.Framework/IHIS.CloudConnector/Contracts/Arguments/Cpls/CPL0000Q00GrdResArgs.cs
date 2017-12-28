using System;
using IHIS.CloudConnector.Contracts.Models.Cpls;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Cpls
{
    public class CPL0000Q00GrdResArgs : IContractArgs
    {
        private String _hospCode;
        private String _bunho;
        private String _orderDate;
        private String _gwa;
        private String _jundalGubun;

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public String Bunho
        {
            get { return this._bunho; }
            set { this._bunho = value; }
        }

        public String OrderDate
        {
            get { return this._orderDate; }
            set { this._orderDate = value; }
        }

        public String Gwa
        {
            get { return this._gwa; }
            set { this._gwa = value; }
        }

        public String JundalGubun
        {
            get { return this._jundalGubun; }
            set { this._jundalGubun = value; }
        }

        public CPL0000Q00GrdResArgs() { }

        public CPL0000Q00GrdResArgs(String hospCode, String bunho, String orderDate, String gwa, String jundalGubun)
        {
            this._hospCode = hospCode;
            this._bunho = bunho;
            this._orderDate = orderDate;
            this._gwa = gwa;
            this._jundalGubun = jundalGubun;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.CPL0000Q00GrdResRequest();
        }
    }
}