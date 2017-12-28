using System;

namespace IHIS.CloudConnector.Contracts.Models.System
{
    public class PrivateInsInfo
    {
        private String _gubun;
        private String _johap;
        private String _piname;
        private String _gaein;
        private String _gaeinNo;
        private String _bonGaGubun;
        private String _startDate;
        private String _endDate;
        private String _chuiduckDate;

        public String Gubun
        {
            get { return this._gubun; }
            set { this._gubun = value; }
        }

        public String Johap
        {
            get { return this._johap; }
            set { this._johap = value; }
        }

        public String Piname
        {
            get { return this._piname; }
            set { this._piname = value; }
        }

        public String Gaein
        {
            get { return this._gaein; }
            set { this._gaein = value; }
        }

        public String GaeinNo
        {
            get { return this._gaeinNo; }
            set { this._gaeinNo = value; }
        }

        public String BonGaGubun
        {
            get { return this._bonGaGubun; }
            set { this._bonGaGubun = value; }
        }

        public String StartDate
        {
            get { return this._startDate; }
            set { this._startDate = value; }
        }

        public String EndDate
        {
            get { return this._endDate; }
            set { this._endDate = value; }
        }

        public String ChuiduckDate
        {
            get { return this._chuiduckDate; }
            set { this._chuiduckDate = value; }
        }

        public PrivateInsInfo() { }

        public PrivateInsInfo(String gubun, String johap, String piname, String gaein, String gaeinNo, String bonGaGubun, String startDate, String endDate, String chuiduckDate)
        {
            this._gubun = gubun;
            this._johap = johap;
            this._piname = piname;
            this._gaein = gaein;
            this._gaeinNo = gaeinNo;
            this._bonGaGubun = bonGaGubun;
            this._startDate = startDate;
            this._endDate = endDate;
            this._chuiduckDate = chuiduckDate;
        }

    }
}