using System;

namespace IHIS.CloudConnector.Contracts.Models.Nuro
{
    [Serializable]
    public class NuroOUT1001U01LayoutBarCodeInfo
    {
        private String _bunho;
        private String _suname;
        private String _sex;
        private String _birth;
        private String _bunho2;

        public String Bunho
        {
            get { return this._bunho; }
            set { this._bunho = value; }
        }

        public String Suname
        {
            get { return this._suname; }
            set { this._suname = value; }
        }

        public String Sex
        {
            get { return this._sex; }
            set { this._sex = value; }
        }

        public String Birth
        {
            get { return this._birth; }
            set { this._birth = value; }
        }

        public String Bunho2
        {
            get { return this._bunho2; }
            set { this._bunho2 = value; }
        }

        public NuroOUT1001U01LayoutBarCodeInfo() { }

        public NuroOUT1001U01LayoutBarCodeInfo(String bunho, String suname, String sex, String birth, String bunho2)
        {
            this._bunho = bunho;
            this._suname = suname;
            this._sex = sex;
            this._birth = birth;
            this._bunho2 = bunho2;
        }

    }
}