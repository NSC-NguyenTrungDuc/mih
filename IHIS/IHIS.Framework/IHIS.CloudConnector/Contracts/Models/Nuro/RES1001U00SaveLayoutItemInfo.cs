using System;

namespace IHIS.CloudConnector.Contracts.Models.Nuro
{
    [Serializable]
    public class RES1001U00SaveLayoutItemInfo
    {
        private String _bunho;
        private String _gwa;
        private String _jinryoPreDate;
        private String _jinryoPreTime;
        private String _doctor;
        private String _inputGubun;
        private String _pkout1001;
        private String _reserComment;
        private String _reserGubun;
        private String _gubun;
        private String _jubsuNo;
        private String _chojae;
        private String _changgu;
        private String _resGubun;
        private String _newrow;
        private String _rowState;

        public String Bunho
        {
            get { return this._bunho; }
            set { this._bunho = value; }
        }

        public String Gwa
        {
            get { return this._gwa; }
            set { this._gwa = value; }
        }

        public String JinryoPreDate
        {
            get { return this._jinryoPreDate; }
            set { this._jinryoPreDate = value; }
        }

        public String JinryoPreTime
        {
            get { return this._jinryoPreTime; }
            set { this._jinryoPreTime = value; }
        }

        public String Doctor
        {
            get { return this._doctor; }
            set { this._doctor = value; }
        }

        public String InputGubun
        {
            get { return this._inputGubun; }
            set { this._inputGubun = value; }
        }

        public String Pkout1001
        {
            get { return this._pkout1001; }
            set { this._pkout1001 = value; }
        }

        public String ReserComment
        {
            get { return this._reserComment; }
            set { this._reserComment = value; }
        }

        public String ReserGubun
        {
            get { return this._reserGubun; }
            set { this._reserGubun = value; }
        }

        public String Gubun
        {
            get { return this._gubun; }
            set { this._gubun = value; }
        }

        public String JubsuNo
        {
            get { return this._jubsuNo; }
            set { this._jubsuNo = value; }
        }

        public String Chojae
        {
            get { return this._chojae; }
            set { this._chojae = value; }
        }

        public String Changgu
        {
            get { return this._changgu; }
            set { this._changgu = value; }
        }

        public String ResGubun
        {
            get { return this._resGubun; }
            set { this._resGubun = value; }
        }

        public String Newrow
        {
            get { return this._newrow; }
            set { this._newrow = value; }
        }

        public String RowState
        {
            get { return this._rowState; }
            set { this._rowState = value; }
        }

        public RES1001U00SaveLayoutItemInfo() { }

        public RES1001U00SaveLayoutItemInfo(String bunho, String gwa, String jinryoPreDate, String jinryoPreTime, String doctor, String inputGubun, String pkout1001, String reserComment, String reserGubun, String gubun, String jubsuNo, String chojae, String changgu, String resGubun, String newrow, String rowState)
        {
            this._bunho = bunho;
            this._gwa = gwa;
            this._jinryoPreDate = jinryoPreDate;
            this._jinryoPreTime = jinryoPreTime;
            this._doctor = doctor;
            this._inputGubun = inputGubun;
            this._pkout1001 = pkout1001;
            this._reserComment = reserComment;
            this._reserGubun = reserGubun;
            this._gubun = gubun;
            this._jubsuNo = jubsuNo;
            this._chojae = chojae;
            this._changgu = changgu;
            this._resGubun = resGubun;
            this._newrow = newrow;
            this._rowState = rowState;
        }

    }
}