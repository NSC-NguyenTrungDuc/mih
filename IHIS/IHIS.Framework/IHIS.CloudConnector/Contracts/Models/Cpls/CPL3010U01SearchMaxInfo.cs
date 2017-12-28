using System;

namespace IHIS.CloudConnector.Contracts.Models.Cpls
{
    [Serializable]
    public class CPL3010U01SearchMaxInfo
    {
        private String _specimenSer;
        private String _partJubsuDate;
        private String _partJubsuTime;

        public String SpecimenSer
        {
            get { return this._specimenSer; }
            set { this._specimenSer = value; }
        }

        public String PartJubsuDate
        {
            get { return this._partJubsuDate; }
            set { this._partJubsuDate = value; }
        }

        public String PartJubsuTime
        {
            get { return this._partJubsuTime; }
            set { this._partJubsuTime = value; }
        }

        public CPL3010U01SearchMaxInfo() { }

        public CPL3010U01SearchMaxInfo(String specimenSer, String partJubsuDate, String partJubsuTime)
        {
            this._specimenSer = specimenSer;
            this._partJubsuDate = partJubsuDate;
            this._partJubsuTime = partJubsuTime;
        }

    }
}