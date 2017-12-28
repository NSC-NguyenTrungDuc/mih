using System;
using IHIS.CloudConnector.Contracts.Models.System;
using System.Collections.Generic;
using IHIS.CloudConnector.Messaging;

namespace IHIS.CloudConnector.Contracts.Results.System
{
    [Serializable]
    public class SyncKinkiCacheResult : AbstractContractResult
    {
        private KinkiType _kinkiType;
        private List<byte[]> _data = new List<byte[]>();

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

        public SyncKinkiCacheResult() { }

    }
}