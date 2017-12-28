using System;
using IHIS.CloudConnector.Contracts.Models.Drgs;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.System;

namespace IHIS.CloudConnector.Contracts.Results.Drgs
{
    public class DRG0120U00ComboListResult : AbstractContractResult
    {
        private List<ComboListItemInfo> _cboList32 = new List<ComboListItemInfo>();
        private List<ComboListItemInfo> _cboList33 = new List<ComboListItemInfo>();
        private List<ComboListItemInfo> _cboList34 = new List<ComboListItemInfo>();
        private List<ComboListItemInfo> _cboList35 = new List<ComboListItemInfo>();
        private List<ComboListItemInfo> _cboListUA = new List<ComboListItemInfo>();

        public List<ComboListItemInfo> CboList32
        {
            get { return this._cboList32; }
            set { this._cboList32 = value; }
        }

        public List<ComboListItemInfo> CboList33
        {
            get { return this._cboList33; }
            set { this._cboList33 = value; }
        }

        public List<ComboListItemInfo> CboList34
        {
            get { return this._cboList34; }
            set { this._cboList34 = value; }
        }

        public List<ComboListItemInfo> CboList35
        {
            get { return this._cboList35; }
            set { this._cboList35 = value; }
        }

        public List<ComboListItemInfo> CboListUA
        {
            get { return this._cboListUA; }
            set { this._cboListUA = value; }
        }

        public DRG0120U00ComboListResult() { }

    }
}