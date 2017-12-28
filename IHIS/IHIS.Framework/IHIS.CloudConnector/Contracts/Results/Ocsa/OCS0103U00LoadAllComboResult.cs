using System;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.System;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
    public class OCS0103U00LoadAllComboResult : AbstractContractResult
    {
        private List<ComboListItemInfo> _orderDanuiItem = new List<ComboListItemInfo>();
        private List<ComboListItemInfo> _slipGubunItem = new List<ComboListItemInfo>();
        private List<ComboListItemInfo> _resultGubunItem = new List<ComboListItemInfo>();
        private List<ComboListItemInfo> _ifInputControlItem = new List<ComboListItemInfo>();
        private List<ComboListItemInfo> _emergencyItem = new List<ComboListItemInfo>();
        private List<ComboListItemInfo> _subunConvertGubunItem = new List<ComboListItemInfo>();
        private List<ComboListItemInfo> _wonyoiOrderYnItem = new List<ComboListItemInfo>();
        private List<ComboListItemInfo> _dvTimeItem = new List<ComboListItemInfo>();
        private List<ComboListItemInfo> _inputControlItem = new List<ComboListItemInfo>();
        private List<ComboListItemInfo> _orderGubunItem = new List<ComboListItemInfo>();

        public List<ComboListItemInfo> OrderDanuiItem
        {
            get { return this._orderDanuiItem; }
            set { this._orderDanuiItem = value; }
        }

        public List<ComboListItemInfo> SlipGubunItem
        {
            get { return this._slipGubunItem; }
            set { this._slipGubunItem = value; }
        }

        public List<ComboListItemInfo> ResultGubunItem
        {
            get { return this._resultGubunItem; }
            set { this._resultGubunItem = value; }
        }

        public List<ComboListItemInfo> IfInputControlItem
        {
            get { return this._ifInputControlItem; }
            set { this._ifInputControlItem = value; }
        }

        public List<ComboListItemInfo> EmergencyItem
        {
            get { return this._emergencyItem; }
            set { this._emergencyItem = value; }
        }

        public List<ComboListItemInfo> SubunConvertGubunItem
        {
            get { return this._subunConvertGubunItem; }
            set { this._subunConvertGubunItem = value; }
        }

        public List<ComboListItemInfo> WonyoiOrderYnItem
        {
            get { return this._wonyoiOrderYnItem; }
            set { this._wonyoiOrderYnItem = value; }
        }

        public List<ComboListItemInfo> DvTimeItem
        {
            get { return this._dvTimeItem; }
            set { this._dvTimeItem = value; }
        }

        public List<ComboListItemInfo> InputControlItem
        {
            get { return this._inputControlItem; }
            set { this._inputControlItem = value; }
        }

        public List<ComboListItemInfo> OrderGubunItem
        {
            get { return this._orderGubunItem; }
            set { this._orderGubunItem = value; }
        }

        public OCS0103U00LoadAllComboResult() { }

    }
}