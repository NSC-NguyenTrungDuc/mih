using System;

namespace IHIS.CloudConnector.Contracts.Models.Xrts
{
    [Serializable]
    public class XRT1002U00LayXRT0123Info
    {
        private String _valtage;
        private String _curElectric;
        private String _time;
        private String _distance;
        private String _grid;
        private String _note;
        private String _masVal;

        public String Valtage
        {
            get { return this._valtage; }
            set { this._valtage = value; }
        }

        public String CurElectric
        {
            get { return this._curElectric; }
            set { this._curElectric = value; }
        }

        public String Time
        {
            get { return this._time; }
            set { this._time = value; }
        }

        public String Distance
        {
            get { return this._distance; }
            set { this._distance = value; }
        }

        public String Grid
        {
            get { return this._grid; }
            set { this._grid = value; }
        }

        public String Note
        {
            get { return this._note; }
            set { this._note = value; }
        }

        public String MasVal
        {
            get { return this._masVal; }
            set { this._masVal = value; }
        }

        public XRT1002U00LayXRT0123Info() { }

        public XRT1002U00LayXRT0123Info(String valtage, String curElectric, String time, String distance, String grid, String note, String masVal)
        {
            this._valtage = valtage;
            this._curElectric = curElectric;
            this._time = time;
            this._distance = distance;
            this._grid = grid;
            this._note = note;
            this._masVal = masVal;
        }

    }
}