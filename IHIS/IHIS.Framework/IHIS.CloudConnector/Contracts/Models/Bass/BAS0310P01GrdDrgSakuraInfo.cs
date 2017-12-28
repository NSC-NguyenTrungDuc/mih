using System;

namespace IHIS.CloudConnector.Contracts.Models.Bass
{
    [Serializable]
    public class BAS0310P01GrdDrgSakuraInfo
    {
        private String _a1;
        private String _a2;
        private String _a3;
        private String _a4;
        private String _a5;
        private String _a6;
        private String _a7;
        private String _a8;
        private String _a9;

        public String A1
        {
            get { return this._a1; }
            set { this._a1 = value; }
        }

        public String A2
        {
            get { return this._a2; }
            set { this._a2 = value; }
        }

        public String A3
        {
            get { return this._a3; }
            set { this._a3 = value; }
        }

        public String A4
        {
            get { return this._a4; }
            set { this._a4 = value; }
        }

        public String A5
        {
            get { return this._a5; }
            set { this._a5 = value; }
        }

        public String A6
        {
            get { return this._a6; }
            set { this._a6 = value; }
        }

        public String A7
        {
            get { return this._a7; }
            set { this._a7 = value; }
        }

        public String A8
        {
            get { return this._a8; }
            set { this._a8 = value; }
        }

        public String A9
        {
            get { return this._a9; }
            set { this._a9 = value; }
        }

        public BAS0310P01GrdDrgSakuraInfo() { }

        public BAS0310P01GrdDrgSakuraInfo(String a1, String a2, String a3, String a4, String a5, String a6, String a7, String a8, String a9)
        {
            this._a1 = a1;
            this._a2 = a2;
            this._a3 = a3;
            this._a4 = a4;
            this._a5 = a5;
            this._a6 = a6;
            this._a7 = a7;
            this._a8 = a8;
            this._a9 = a9;
        }

    }
}