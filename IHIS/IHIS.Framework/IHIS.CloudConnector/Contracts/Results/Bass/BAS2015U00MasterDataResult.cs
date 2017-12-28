using System;
using IHIS.CloudConnector.Contracts.Models.Bass;
using System.Collections.Generic;
using IHIS.CloudConnector.Messaging;

namespace IHIS.CloudConnector.Contracts.Results.Bass
{
    [Serializable]
    public class BAS2015U00MasterDataResult : AbstractContractResult
    {
        private KinkiType _kinkiType;
        private List<byte[]>  _data = new List<byte[]>();
        private String _msg;
        private Boolean _result;

        public KinkiType KinkiType
        {
            get { return this._kinkiType; }
            set { this._kinkiType = value; }
        }

        public List<byte[]> Data
        {
            get { return this._data; }
            set { this._data = value; }
        }

        public String Msg
        {
            get { return this._msg; }
            set { this._msg = value; }
        }

        public Boolean Result
        {
            get { return this._result; }
            set { this._result = value; }
        }

        public BAS2015U00MasterDataResult() { }

    }
}