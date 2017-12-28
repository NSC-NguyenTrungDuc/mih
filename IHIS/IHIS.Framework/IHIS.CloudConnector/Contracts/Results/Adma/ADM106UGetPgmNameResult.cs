using System;

namespace IHIS.CloudConnector.Contracts.Results.Adma
{
    [Serializable]
    public class ADM106UGetPgmNameResult : AbstractContractResult
    {
        private String _pgmNm;

        public String PgmNm
        {
            get { return this._pgmNm; }
            set { this._pgmNm = value; }
        }

        public ADM106UGetPgmNameResult() { }

    }
}