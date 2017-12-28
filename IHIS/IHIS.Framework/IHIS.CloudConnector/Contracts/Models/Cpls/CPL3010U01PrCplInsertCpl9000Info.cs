using System;

namespace IHIS.CloudConnector.Contracts.Models.Cpls
{
    [Serializable]
    public class CPL3010U01PrCplInsertCpl9000Info
    {
        private String _iraiKey;
        private String _bunho;
        private String _partJubsuDate;
        private String _partJubsuTime;
        private String _gubun;
        private String _centerCode;

        public String IraiKey
        {
            get { return this._iraiKey; }
            set { this._iraiKey = value; }
        }

        public String Bunho
        {
            get { return this._bunho; }
            set { this._bunho = value; }
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

        public String Gubun
        {
            get { return this._gubun; }
            set { this._gubun = value; }
        }

        public String CenterCode
        {
            get { return this._centerCode; }
            set { this._centerCode = value; }
        }

        public CPL3010U01PrCplInsertCpl9000Info() { }

        public CPL3010U01PrCplInsertCpl9000Info(String iraiKey, String bunho, String partJubsuDate, String partJubsuTime, String gubun, String centerCode)
        {
            this._iraiKey = iraiKey;
            this._bunho = bunho;
            this._partJubsuDate = partJubsuDate;
            this._partJubsuTime = partJubsuTime;
            this._gubun = gubun;
            this._centerCode = centerCode;
        }

    }
}