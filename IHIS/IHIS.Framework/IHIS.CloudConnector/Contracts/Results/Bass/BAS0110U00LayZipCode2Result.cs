using System;

namespace IHIS.CloudConnector.Contracts.Results.Bass
{
    [Serializable]
    public class BAS0110U00LayZipCode2Result : AbstractContractResult
    {
        private String _zipName;

        public String ZipName
        {
            get { return this._zipName; }
            set { this._zipName = value; }
        }

        public BAS0110U00LayZipCode2Result() { }

    }
}