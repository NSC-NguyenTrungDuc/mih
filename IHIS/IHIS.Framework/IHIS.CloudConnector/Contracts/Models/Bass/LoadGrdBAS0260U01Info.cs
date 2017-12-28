using System;

namespace IHIS.CloudConnector.Contracts.Models.Bass
{
    public class LoadGrdBAS0260U01Info
    {
        private String _id;
        private String _buseoCode;
        private String _buseoName;
        private String _buseoName2;
        private String _buseoGubun;
        private String _parentBuseo;
        private String _gwa;
        private String _gwaName;
        private String _gwaName2;
        private String _gwaGubun;
        private String _parentGwa;
        private String _note;
        private String _language;
        private String _activeFlg;
        private String _rowState;

        public String Id
        {
            get { return this._id; }
            set { this._id = value; }
        }

        public String BuseoCode
        {
            get { return this._buseoCode; }
            set { this._buseoCode = value; }
        }

        public String BuseoName
        {
            get { return this._buseoName; }
            set { this._buseoName = value; }
        }

        public String BuseoName2
        {
            get { return this._buseoName2; }
            set { this._buseoName2 = value; }
        }

        public String BuseoGubun
        {
            get { return this._buseoGubun; }
            set { this._buseoGubun = value; }
        }

        public String ParentBuseo
        {
            get { return this._parentBuseo; }
            set { this._parentBuseo = value; }
        }

        public String Gwa
        {
            get { return this._gwa; }
            set { this._gwa = value; }
        }

        public String GwaName
        {
            get { return this._gwaName; }
            set { this._gwaName = value; }
        }

        public String GwaName2
        {
            get { return this._gwaName2; }
            set { this._gwaName2 = value; }
        }

        public String GwaGubun
        {
            get { return this._gwaGubun; }
            set { this._gwaGubun = value; }
        }

        public String ParentGwa
        {
            get { return this._parentGwa; }
            set { this._parentGwa = value; }
        }

        public String Note
        {
            get { return this._note; }
            set { this._note = value; }
        }

        public String Language
        {
            get { return this._language; }
            set { this._language = value; }
        }

        public String ActiveFlg
        {
            get { return this._activeFlg; }
            set { this._activeFlg = value; }
        }

        public String RowState
        {
            get { return this._rowState; }
            set { this._rowState = value; }
        }

        public LoadGrdBAS0260U01Info() { }

        public LoadGrdBAS0260U01Info(String id, String buseoCode, String buseoName, String buseoName2, String buseoGubun, String parentBuseo, String gwa, String gwaName, String gwaName2, String gwaGubun, String parentGwa, String note, String language, String activeFlg, String rowState)
        {
            this._id = id;
            this._buseoCode = buseoCode;
            this._buseoName = buseoName;
            this._buseoName2 = buseoName2;
            this._buseoGubun = buseoGubun;
            this._parentBuseo = parentBuseo;
            this._gwa = gwa;
            this._gwaName = gwaName;
            this._gwaName2 = gwaName2;
            this._gwaGubun = gwaGubun;
            this._parentGwa = parentGwa;
            this._note = note;
            this._language = language;
            this._activeFlg = activeFlg;
            this._rowState = rowState;
        }

    }
}