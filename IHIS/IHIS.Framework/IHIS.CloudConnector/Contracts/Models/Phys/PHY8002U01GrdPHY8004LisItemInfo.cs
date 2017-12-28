using System;

namespace IHIS.CloudConnector.Contracts.Models.Phys
{
    [Serializable]
    public class PHY8002U01GrdPHY8004LisItemInfo
    {
        private String _sysDate;
        private String _userId;
        private String _updDate;
        private String _hospCode;
        private String _pkPhySyougai;
        private String _dataKubun;
        private String _fkOcsIrai;
        private String _syougaiId;
        private String _syougaimei;
        private String _kanjaNo;
        private String _fkcht0113;
        private String _rowState;

        public String SysDate
        {
            get { return this._sysDate; }
            set { this._sysDate = value; }
        }

        public String UserId
        {
            get { return this._userId; }
            set { this._userId = value; }
        }

        public String UpdDate
        {
            get { return this._updDate; }
            set { this._updDate = value; }
        }

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public String PkPhySyougai
        {
            get { return this._pkPhySyougai; }
            set { this._pkPhySyougai = value; }
        }

        public String DataKubun
        {
            get { return this._dataKubun; }
            set { this._dataKubun = value; }
        }

        public String FkOcsIrai
        {
            get { return this._fkOcsIrai; }
            set { this._fkOcsIrai = value; }
        }

        public String SyougaiId
        {
            get { return this._syougaiId; }
            set { this._syougaiId = value; }
        }

        public String Syougaimei
        {
            get { return this._syougaimei; }
            set { this._syougaimei = value; }
        }

        public String KanjaNo
        {
            get { return this._kanjaNo; }
            set { this._kanjaNo = value; }
        }

        public String Fkcht0113
        {
            get { return this._fkcht0113; }
            set { this._fkcht0113 = value; }
        }

        public String RowState
        {
            get { return this._rowState; }
            set { this._rowState = value; }
        }

        public PHY8002U01GrdPHY8004LisItemInfo() { }

        public PHY8002U01GrdPHY8004LisItemInfo(String sysDate, String userId, String updDate, String hospCode, String pkPhySyougai, String dataKubun, String fkOcsIrai, String syougaiId, String syougaimei, String kanjaNo, String fkcht0113, String rowState)
        {
            this._sysDate = sysDate;
            this._userId = userId;
            this._updDate = updDate;
            this._hospCode = hospCode;
            this._pkPhySyougai = pkPhySyougai;
            this._dataKubun = dataKubun;
            this._fkOcsIrai = fkOcsIrai;
            this._syougaiId = syougaiId;
            this._syougaimei = syougaimei;
            this._kanjaNo = kanjaNo;
            this._fkcht0113 = fkcht0113;
            this._rowState = rowState;
        }

    }
}