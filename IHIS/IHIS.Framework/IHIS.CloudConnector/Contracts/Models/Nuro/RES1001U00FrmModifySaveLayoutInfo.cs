using System;

namespace IHIS.CloudConnector.Contracts.Models.Nuro
{
    [Serializable]
    public class RES1001U00FrmModifySaveLayoutInfo
    {
        private String _bunho;
        private String _gwa;
        private String _gubun;
        private String _jinryoPreDate;
        private String _jinryoPreTime;
        private String _doctor;
        private String _inputGubun;
        private String _pkout1001;
        private String _changgu;
        private String _chojae;
        private String _resGubun;
        private String _jubsuNo;
        private String _newrow;
        private String _pkres1001;
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

        public String Gubun
        {
            get { return this._gubun; }
            set { this._gubun = value; }
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

        public String Changgu
        {
            get { return this._changgu; }
            set { this._changgu = value; }
        }

        public String Chojae
        {
            get { return this._chojae; }
            set { this._chojae = value; }
        }

        public String ResGubun
        {
            get { return this._resGubun; }
            set { this._resGubun = value; }
        }

        public String JubsuNo
        {
            get { return this._jubsuNo; }
            set { this._jubsuNo = value; }
        }

        public String Newrow
        {
            get { return this._newrow; }
            set { this._newrow = value; }
        }

        public String Pkres1001
        {
            get { return this._pkres1001; }
            set { this._pkres1001 = value; }
        }

        public String RowState
        {
            get { return this._rowState; }
            set { this._rowState = value; }
        }

        public RES1001U00FrmModifySaveLayoutInfo() { }

        public RES1001U00FrmModifySaveLayoutInfo(String bunho, String gwa, String gubun, String jinryoPreDate, String jinryoPreTime, String doctor, String inputGubun, String pkout1001, String changgu, String chojae, String resGubun, String jubsuNo, String newrow, String pkres1001, String rowState)
        {
            this._bunho = bunho;
            this._gwa = gwa;
            this._gubun = gubun;
            this._jinryoPreDate = jinryoPreDate;
            this._jinryoPreTime = jinryoPreTime;
            this._doctor = doctor;
            this._inputGubun = inputGubun;
            this._pkout1001 = pkout1001;
            this._changgu = changgu;
            this._chojae = chojae;
            this._resGubun = resGubun;
            this._jubsuNo = jubsuNo;
            this._newrow = newrow;
            this._pkres1001 = pkres1001;
            this._rowState = rowState;
        }

    }
}