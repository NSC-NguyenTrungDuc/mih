using System;

namespace IHIS.CloudConnector.Contracts.Models.Nuro
{
    [Serializable]
    public class ORDERTRANSSangSendAllInfo
    {
        private String _ifsKey;

        public String IfsKey
        {
            get { return this._ifsKey; }
            set { this._ifsKey = value; }
        }

        public ORDERTRANSSangSendAllInfo() { }

        public ORDERTRANSSangSendAllInfo(String ifsKey)
        {
            this._ifsKey = ifsKey;
        }

    }
}