using System;

namespace IHIS.CloudConnector.Contracts.Results.Bass
{
    [Serializable]
	public class BAS0101U04GrdMasterGridColumnChangedResult : AbstractContractResult
	{
        private String _ioError;
        private String _dupYn;

        public String IoError
        {
            get { return this._ioError; }
            set { this._ioError = value; }
        }

        public String DupYn
        {
            get { return this._dupYn; }
            set { this._dupYn = value; }
        }

        public BAS0101U04GrdMasterGridColumnChangedResult() { }

	}
}