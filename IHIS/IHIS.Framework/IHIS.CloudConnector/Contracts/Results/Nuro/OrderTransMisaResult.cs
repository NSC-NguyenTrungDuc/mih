using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
	[Serializable]
    public class OrderTransMisaResult : AbstractContractResult
    {
        private String _suname;
        private String _zipCode1;
        private String _zipCode2;
        private String _address1;
        private String _hopsCodeExt;
        private String _johap;
        private String _pkout1001Ext;
        private String _refno;
        private String _receptRefId;

        public String Suname
        {
            get { return this._suname; }
            set { this._suname = value; }
        }

        public String ZipCode1
        {
            get { return this._zipCode1; }
            set { this._zipCode1 = value; }
        }

        public String ZipCode2
        {
            get { return this._zipCode2; }
            set { this._zipCode2 = value; }
        }

        public String Address1
        {
            get { return this._address1; }
            set { this._address1 = value; }
        }

        public String HopsCodeExt
        {
            get { return this._hopsCodeExt; }
            set { this._hopsCodeExt = value; }
        }

        public String Johap
        {
            get { return this._johap; }
            set { this._johap = value; }
        }

        public String Pkout1001Ext
        {
            get { return this._pkout1001Ext; }
            set { this._pkout1001Ext = value; }
        }

        public String Refno
        {
            get { return this._refno; }
            set { this._refno = value; }
        }

        public String ReceptRefId
        {
            get { return this._receptRefId; }
            set { this._receptRefId = value; }
        }

        public OrderTransMisaResult() { }

    }
}