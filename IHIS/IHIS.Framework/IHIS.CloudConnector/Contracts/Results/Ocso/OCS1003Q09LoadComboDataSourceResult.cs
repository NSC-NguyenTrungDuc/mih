using System;
using IHIS.CloudConnector.Contracts.Models.Ocso;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.System;

namespace IHIS.CloudConnector.Contracts.Results.Ocso
{
    [Serializable]
    public class OCS1003Q09LoadComboDataSourceResult : AbstractContractResult
    {
        private List<ComboListItemInfo> _dataForColPay = new List<ComboListItemInfo>();
        private List<ComboListItemInfo> _dataForPortableYn = new List<ComboListItemInfo>();
        private List<ComboListItemInfo> _dataForJusaSpdGubun = new List<ComboListItemInfo>();
        private List<ComboListItemInfo> _dataForNalsu = new List<ComboListItemInfo>();
        private List<ComboListItemInfo> _dataForSuryang = new List<ComboListItemInfo>();
        private List<ComboListItemInfo> _dataForDv = new List<ComboListItemInfo>();

        public List<ComboListItemInfo> DataForColPay
        {
            get { return this._dataForColPay; }
            set { this._dataForColPay = value; }
        }

        public List<ComboListItemInfo> DataForPortableYn
        {
            get { return this._dataForPortableYn; }
            set { this._dataForPortableYn = value; }
        }

        public List<ComboListItemInfo> DataForJusaSpdGubun
        {
            get { return this._dataForJusaSpdGubun; }
            set { this._dataForJusaSpdGubun = value; }
        }

        public List<ComboListItemInfo> DataForNalsu
        {
            get { return this._dataForNalsu; }
            set { this._dataForNalsu = value; }
        }

        public List<ComboListItemInfo> DataForSuryang
        {
            get { return this._dataForSuryang; }
            set { this._dataForSuryang = value; }
        }

        public List<ComboListItemInfo> DataForDv
        {
            get { return this._dataForDv; }
            set { this._dataForDv = value; }
        }

        public OCS1003Q09LoadComboDataSourceResult() { }

    }
}