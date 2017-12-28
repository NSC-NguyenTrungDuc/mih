using System;

namespace IHIS.CloudConnector.Contracts.Models.Drgs
{
    public class DRG0201U00InventoryInfo
    {
        private String _jaeryoCode;
        private String _ordSuryang;
        private String _dvTime;
        private String _dv;
        private String _nalsu;
        private String _fkocs1003;

        public String JaeryoCode
        {
            get { return this._jaeryoCode; }
            set { this._jaeryoCode = value; }
        }

        public String OrdSuryang
        {
            get { return this._ordSuryang; }
            set { this._ordSuryang = value; }
        }

        public String DvTime
        {
            get { return this._dvTime; }
            set { this._dvTime = value; }
        }

        public String Dv
        {
            get { return this._dv; }
            set { this._dv = value; }
        }

        public String Nalsu
        {
            get { return this._nalsu; }
            set { this._nalsu = value; }
        }

        public String Fkocs1003
        {
            get { return this._fkocs1003; }
            set { this._fkocs1003 = value; }
        }

        public DRG0201U00InventoryInfo() { }

        public DRG0201U00InventoryInfo(String jaeryoCode, String ordSuryang, String dvTime, String dv, String nalsu, String fkocs1003)
        {
            this._jaeryoCode = jaeryoCode;
            this._ordSuryang = ordSuryang;
            this._dvTime = dvTime;
            this._dv = dv;
            this._nalsu = nalsu;
            this._fkocs1003 = fkocs1003;
        }

    }
}