using System;

namespace IHIS.CloudConnector.Contracts.Models.Schs
{
    [Serializable]
    public class SCH3001U00GrdSCH3000Info
    {
        private String _jukyongDate;
        private String _jundalTable;
        private String _jundalPart;
        private String _gumsaja;
        private String _yoilGubun;
        private String _startTime;
        private String _endTime;
        private String _iwon;
        private String _addIwon;
        private String _outHospSlot;
        private String _dataRowState;

        public String JukyongDate
        {
            get { return this._jukyongDate; }
            set { this._jukyongDate = value; }
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

        public String Gumsaja
        {
            get { return this._gumsaja; }
            set { this._gumsaja = value; }
        }

        public String YoilGubun
        {
            get { return this._yoilGubun; }
            set { this._yoilGubun = value; }
        }

        public String StartTime
        {
            get { return this._startTime; }
            set { this._startTime = value; }
        }

        public String EndTime
        {
            get { return this._endTime; }
            set { this._endTime = value; }
        }

        public String Iwon
        {
            get { return this._iwon; }
            set { this._iwon = value; }
        }

        public String AddIwon
        {
            get { return this._addIwon; }
            set { this._addIwon = value; }
        }

        public String OutHospSlot
        {
            get { return this._outHospSlot; }
            set { this._outHospSlot = value; }
        }

        public String DataRowState
        {
            get { return this._dataRowState; }
            set { this._dataRowState = value; }
        }

        public SCH3001U00GrdSCH3000Info() { }

        public SCH3001U00GrdSCH3000Info(String jukyongDate, String jundalTable, String jundalPart, String gumsaja, String yoilGubun, String startTime, String endTime, String iwon, String addIwon, String outHospSlot, String dataRowState)
        {
            this._jukyongDate = jukyongDate;
            this._jundalTable = jundalTable;
            this._jundalPart = jundalPart;
            this._gumsaja = gumsaja;
            this._yoilGubun = yoilGubun;
            this._startTime = startTime;
            this._endTime = endTime;
            this._iwon = iwon;
            this._addIwon = addIwon;
            this._outHospSlot = outHospSlot;
            this._dataRowState = dataRowState;
        }

    }
}