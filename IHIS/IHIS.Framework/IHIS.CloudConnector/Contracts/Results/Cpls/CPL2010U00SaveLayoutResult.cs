using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Cpls;

namespace IHIS.CloudConnector.Contracts.Results.Cpls
{
    [Serializable]
    public class CPL2010U00SaveLayoutResult : AbstractContractResult
    {
        private Boolean _wholeResult;
        private String _ioFlagPr1;
        private String _printName;
        private List<CPL2010U00LayBarcodeTempListItemInfo> _layBarcodeTempList = new List<CPL2010U00LayBarcodeTempListItemInfo>();

        public Boolean WholeResult
        {
            get { return this._wholeResult; }
            set { this._wholeResult = value; }
        }

        public String IoFlagPr1
        {
            get { return this._ioFlagPr1; }
            set { this._ioFlagPr1 = value; }
        }

        public String PrintName
        {
            get { return this._printName; }
            set { this._printName = value; }
        }

        public List<CPL2010U00LayBarcodeTempListItemInfo> LayBarcodeTempList
        {
            get { return this._layBarcodeTempList; }
            set { this._layBarcodeTempList = value; }
        }

        public CPL2010U00SaveLayoutResult() { }

    }
}