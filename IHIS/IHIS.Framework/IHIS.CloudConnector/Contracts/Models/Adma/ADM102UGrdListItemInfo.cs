using System;

namespace IHIS.CloudConnector.Contracts.Models.Adma
{
   [Serializable]
    public class ADM102UGrdListItemInfo
    {
        private String _pgmId;
        private String _pgmNm;
        private String _pgmTp;
        private String _sysId;
        private String _prodId;
        private String _srvcId;
        private String _pgmEntGrad;
        private String _pgmUpdGrad;
        private String _pgmScrt;
        private String _pgmDupYn;
        private String _endYn;
        private String _pgmAcsYn;
        private String _mangMemb;
        private String _asmName;
        private String _rowState;

        public String PgmId
        {
            get { return this._pgmId; }
            set { this._pgmId = value; }
        }

        public String PgmNm
        {
            get { return this._pgmNm; }
            set { this._pgmNm = value; }
        }

        public String PgmTp
        {
            get { return this._pgmTp; }
            set { this._pgmTp = value; }
        }

        public String SysId
        {
            get { return this._sysId; }
            set { this._sysId = value; }
        }

        public String ProdId
        {
            get { return this._prodId; }
            set { this._prodId = value; }
        }

        public String SrvcId
        {
            get { return this._srvcId; }
            set { this._srvcId = value; }
        }

        public String PgmEntGrad
        {
            get { return this._pgmEntGrad; }
            set { this._pgmEntGrad = value; }
        }

        public String PgmUpdGrad
        {
            get { return this._pgmUpdGrad; }
            set { this._pgmUpdGrad = value; }
        }

        public String PgmScrt
        {
            get { return this._pgmScrt; }
            set { this._pgmScrt = value; }
        }

        public String PgmDupYn
        {
            get { return this._pgmDupYn; }
            set { this._pgmDupYn = value; }
        }

        public String EndYn
        {
            get { return this._endYn; }
            set { this._endYn = value; }
        }

        public String PgmAcsYn
        {
            get { return this._pgmAcsYn; }
            set { this._pgmAcsYn = value; }
        }

        public String MangMemb
        {
            get { return this._mangMemb; }
            set { this._mangMemb = value; }
        }

        public String AsmName
        {
            get { return this._asmName; }
            set { this._asmName = value; }
        }

        public String RowState
        {
            get { return this._rowState; }
            set { this._rowState = value; }
        }

        public ADM102UGrdListItemInfo() { }

        public ADM102UGrdListItemInfo(String pgmId, String pgmNm, String pgmTp, String sysId, String prodId, String srvcId, String pgmEntGrad, String pgmUpdGrad, String pgmScrt, String pgmDupYn, String endYn, String pgmAcsYn, String mangMemb, String asmName, String rowState)
        {
            this._pgmId = pgmId;
            this._pgmNm = pgmNm;
            this._pgmTp = pgmTp;
            this._sysId = sysId;
            this._prodId = prodId;
            this._srvcId = srvcId;
            this._pgmEntGrad = pgmEntGrad;
            this._pgmUpdGrad = pgmUpdGrad;
            this._pgmScrt = pgmScrt;
            this._pgmDupYn = pgmDupYn;
            this._endYn = endYn;
            this._pgmAcsYn = pgmAcsYn;
            this._mangMemb = mangMemb;
            this._asmName = asmName;
            this._rowState = rowState;
        }

    }
}