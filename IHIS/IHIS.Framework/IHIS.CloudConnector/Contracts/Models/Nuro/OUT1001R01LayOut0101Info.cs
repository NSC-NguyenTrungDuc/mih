using System;

namespace IHIS.CloudConnector.Contracts.Models.Nuro
{
    [Serializable]
    public class OUT1001R01LayOut0101Info
    {
        private String _suName;
        private String _suName2;
        private String _birth;

        public String SuName
        {
            get { return this._suName; }
            set { this._suName = value; }
        }

        public String SuName2
        {
            get { return this._suName2; }
            set { this._suName2 = value; }
        }

        public String Birth
        {
            get { return this._birth; }
            set { this._birth = value; }
        }

        public OUT1001R01LayOut0101Info() { }

        public OUT1001R01LayOut0101Info(String suName, String suName2, String birth)
        {
            this._suName = suName;
            this._suName2 = suName2;
            this._birth = birth;
        }

    }
}