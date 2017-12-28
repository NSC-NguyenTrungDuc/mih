using System;

namespace IHIS.CloudConnector.Contracts.Models.System
{
    [Serializable]
    public class FwPaCommentGrdCmmtFwkInfo
    {
        private String _comments;
        private String _displayYn;
        private String _bunho;
        private String _cmmtGubun;
        private String _jundalTable;
        private String _jundalPart;
        private String _inOutGubun;
        private String _fkocs;
        private String _hangmogCode;
        private String _ser;

        public String Comments
        {
            get { return this._comments; }
            set { this._comments = value; }
        }

        public String DisplayYn
        {
            get { return this._displayYn; }
            set { this._displayYn = value; }
        }

        public String Bunho
        {
            get { return this._bunho; }
            set { this._bunho = value; }
        }

        public String CmmtGubun
        {
            get { return this._cmmtGubun; }
            set { this._cmmtGubun = value; }
        }

        public String JundalTable
        {
            get { return this._jundalTable; }
            set { this._jundalTable = value; }
        }

        public String JundalPart
        {
            get { return this._jundalPart; }
            set { this._jundalPart = value; }
        }

        public String InOutGubun
        {
            get { return this._inOutGubun; }
            set { this._inOutGubun = value; }
        }

        public String Fkocs
        {
            get { return this._fkocs; }
            set { this._fkocs = value; }
        }

        public String HangmogCode
        {
            get { return this._hangmogCode; }
            set { this._hangmogCode = value; }
        }

        public String Ser
        {
            get { return this._ser; }
            set { this._ser = value; }
        }

        public FwPaCommentGrdCmmtFwkInfo() { }

        public FwPaCommentGrdCmmtFwkInfo(String comments, String displayYn, String bunho, String cmmtGubun, String jundalTable, String jundalPart, String inOutGubun, String fkocs, String hangmogCode, String ser)
        {
            this._comments = comments;
            this._displayYn = displayYn;
            this._bunho = bunho;
            this._cmmtGubun = cmmtGubun;
            this._jundalTable = jundalTable;
            this._jundalPart = jundalPart;
            this._inOutGubun = inOutGubun;
            this._fkocs = fkocs;
            this._hangmogCode = hangmogCode;
            this._ser = ser;
        }

    }
}