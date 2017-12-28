using System;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable]
    public class NuroNUR1001R98PageCountResult : AbstractContractResult
    {
        private String _count;

        public String Count
        {
            get { return this._count; }
            set { this._count = value; }
        }

        public NuroNUR1001R98PageCountResult() { }

    }
}