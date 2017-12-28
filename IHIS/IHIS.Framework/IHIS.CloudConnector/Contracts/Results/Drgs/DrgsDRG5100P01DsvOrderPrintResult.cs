using System;
using IHIS.CloudConnector.Contracts.Models.Drgs;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Drgs
{
    public class DrgsDRG5100P01DsvOrderPrintResult : AbstractContractResult
    {
        private String _retVal;
        private DrgsDRG5100P01LoadChebangPrintInfo _chebangPrintItem;
        private DrgsDRG5100P01LoadMakayJungboInfo _makayJungbo;
        private List<DrgsDRG5100P01DrgwonneaOWnCurListInfo> _drgwonneaOwnCur = new List<DrgsDRG5100P01DrgwonneaOWnCurListInfo>();
        private List<DrgsDRG5100P01WnSerialQryListItemInfo> _wnSerialItem = new List<DrgsDRG5100P01WnSerialQryListItemInfo>();
        private String _hospName;
        private String _jaedanName;
        private String _hospAddress1;

        public String RetVal
        {
            get { return this._retVal; }
            set { this._retVal = value; }
        }

        public DrgsDRG5100P01LoadChebangPrintInfo ChebangPrintItem
        {
            get { return this._chebangPrintItem; }
            set { this._chebangPrintItem = value; }
        }

        public DrgsDRG5100P01LoadMakayJungboInfo MakayJungbo
        {
            get { return this._makayJungbo; }
            set { this._makayJungbo = value; }
        }

        public List<DrgsDRG5100P01DrgwonneaOWnCurListInfo> DrgwonneaOwnCur
        {
            get { return this._drgwonneaOwnCur; }
            set { this._drgwonneaOwnCur = value; }
        }

        public List<DrgsDRG5100P01WnSerialQryListItemInfo> WnSerialItem
        {
            get { return this._wnSerialItem; }
            set { this._wnSerialItem = value; }
        }

        public String HospName
        {
            get { return this._hospName; }
            set { this._hospName = value; }
        }

        public String JaedanName
        {
            get { return this._jaedanName; }
            set { this._jaedanName = value; }
        }

        public String HospAddress1
        {
            get { return this._hospAddress1; }
            set { this._hospAddress1 = value; }
        }

        public DrgsDRG5100P01DsvOrderPrintResult() { }

    }
}