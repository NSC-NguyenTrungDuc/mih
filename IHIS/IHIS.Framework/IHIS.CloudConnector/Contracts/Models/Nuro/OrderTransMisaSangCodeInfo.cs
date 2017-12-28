using System;

namespace IHIS.CloudConnector.Contracts.Models.NURO
{
    [Serializable]
    public class OrderTransMisaSangCodeInfo
    {
        private String _sangCode;
        private String _sangCodeExt;

        public String SangCode
        {
            get { return this._sangCode; }
            set { this._sangCode = value; }
        }

        public String SangCodeExt
        {
            get { return this._sangCodeExt; }
            set { this._sangCodeExt = value; }
        }

        public OrderTransMisaSangCodeInfo() { }

        public OrderTransMisaSangCodeInfo(String sangCode, String sangCodeExt)
        {
            this._sangCode = sangCode;
            this._sangCodeExt = sangCodeExt;
        }

    }
}