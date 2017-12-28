using System;

namespace IHIS.CloudConnector.Contracts.Models.Nuro
{
    [Serializable]
    public class ORDERTRANInsertOcsTempInfo
    {
        private String _pkOcs;
        private String _bunho;
        private String _ioGubun;
        private String _userId;
        private String _junsongDate;
        private String _fbxBunho;
        private String _doctor;

        public String PkOcs
        {
            get { return this._pkOcs; }
            set { this._pkOcs = value; }
        }

        public String Bunho
        {
            get { return this._bunho; }
            set { this._bunho = value; }
        }

        public String IoGubun
        {
            get { return this._ioGubun; }
            set { this._ioGubun = value; }
        }

        public String UserId
        {
            get { return this._userId; }
            set { this._userId = value; }
        }

        public String JunsongDate
        {
            get { return this._junsongDate; }
            set { this._junsongDate = value; }
        }

        public String FbxBunho
        {
            get { return this._fbxBunho; }
            set { this._fbxBunho = value; }
        }

        public String Doctor
        {
            get { return this._doctor; }
            set { this._doctor = value; }
        }

        public ORDERTRANInsertOcsTempInfo() { }

        public ORDERTRANInsertOcsTempInfo(String pkOcs, String bunho, String ioGubun, String userId, String junsongDate, String fbxBunho, String doctor)
        {
            this._pkOcs = pkOcs;
            this._bunho = bunho;
            this._ioGubun = ioGubun;
            this._userId = userId;
            this._junsongDate = junsongDate;
            this._fbxBunho = fbxBunho;
            this._doctor = doctor;
        }

    }
}