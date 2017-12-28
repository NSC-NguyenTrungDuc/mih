using System;

namespace IHIS.CloudConnector.Contracts.Models.Invs
{
    public class LoadGrdMasterINV0101Info
    {
        private String _codeType;
        private String _codeName;
        private String _rowState;

        public String CodeType
        {
            get { return this._codeType; }
            set { this._codeType = value; }
        }

        public String CodeName
        {
            get { return this._codeName; }
            set { this._codeName = value; }
        }

        public String RowState
        {
            get { return this._rowState; }
            set { this._rowState = value; }
        }

        public LoadGrdMasterINV0101Info() { }

        public LoadGrdMasterINV0101Info(String codeType, String codeName, String rowState)
        {
            this._codeType = codeType;
            this._codeName = codeName;
            this._rowState = rowState;
        }

    }
}