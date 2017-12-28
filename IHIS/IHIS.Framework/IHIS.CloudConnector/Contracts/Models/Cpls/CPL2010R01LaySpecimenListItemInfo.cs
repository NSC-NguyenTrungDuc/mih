using System;

namespace IHIS.CloudConnector.Contracts.Models.Cpls
{
    [Serializable]
    public class CPL2010R01LaySpecimenListItemInfo
    {
        private String _specimenSer;
        private String _bunho;
        private String _suname;
        private String _doctorName;
        private String _specimenNo;
        private String _specimenName;
        private String _tubeName;
        private String _tubeCount;
        private String _hoDongName;
        private String _reserDate;
        private String _contKey;

        public String SpecimenSer
        {
            get { return this._specimenSer; }
            set { this._specimenSer = value; }
        }

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

        public String DoctorName
        {
            get { return this._doctorName; }
            set { this._doctorName = value; }
        }

        public String SpecimenNo
        {
            get { return this._specimenNo; }
            set { this._specimenNo = value; }
        }

        public String SpecimenName
        {
            get { return this._specimenName; }
            set { this._specimenName = value; }
        }

        public String TubeName
        {
            get { return this._tubeName; }
            set { this._tubeName = value; }
        }

        public String TubeCount
        {
            get { return this._tubeCount; }
            set { this._tubeCount = value; }
        }

        public String HoDongName
        {
            get { return this._hoDongName; }
            set { this._hoDongName = value; }
        }

        public String ReserDate
        {
            get { return this._reserDate; }
            set { this._reserDate = value; }
        }

        public String ContKey
        {
            get { return this._contKey; }
            set { this._contKey = value; }
        }

        public CPL2010R01LaySpecimenListItemInfo() { }

        public CPL2010R01LaySpecimenListItemInfo(String specimenSer, String bunho, String suname, String doctorName, String specimenNo, String specimenName, String tubeName, String tubeCount, String hoDongName, String reserDate, String contKey)
        {
            this._specimenSer = specimenSer;
            this._bunho = bunho;
            this._suname = suname;
            this._doctorName = doctorName;
            this._specimenNo = specimenNo;
            this._specimenName = specimenName;
            this._tubeName = tubeName;
            this._tubeCount = tubeCount;
            this._hoDongName = hoDongName;
            this._reserDate = reserDate;
            this._contKey = contKey;
        }

    }
}