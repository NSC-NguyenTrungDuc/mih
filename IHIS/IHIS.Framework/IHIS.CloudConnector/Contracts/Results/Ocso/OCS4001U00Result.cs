using System;
using IHIS.CloudConnector.Contracts.Models.Ocso;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Ocso
{
    public class OCS4001U00Result : AbstractContractResult
    {
        private String _inputContent;
        private String _printContent;
        private String _formatType;
        private String _tplName;
        private List<OCS4001U00SangNameInfo> _sangNameList = new List<OCS4001U00SangNameInfo>();
        private List<OCS4001U00ListItemInfo> _items = new List<OCS4001U00ListItemInfo>();
        private List<OCS4001U00HospitalInfo> _hospitals = new List<OCS4001U00HospitalInfo>();
        private List<OCS4001U00PrescriptionInfo> _prescriptions = new List<OCS4001U00PrescriptionInfo>();

        public String InputContent
        {
            get { return this._inputContent; }
            set { this._inputContent = value; }
        }

        public String PrintContent
        {
            get { return this._printContent; }
            set { this._printContent = value; }
        }

        public String FormatType
        {
            get { return this._formatType; }
            set { this._formatType = value; }
        }

        public String TplName
        {
            get { return this._tplName; }
            set { this._tplName = value; }
        }

        public List<OCS4001U00SangNameInfo> SangNameList
        {
            get { return this._sangNameList; }
            set { this._sangNameList = value; }
        }

        public List<OCS4001U00ListItemInfo> Items
        {
            get { return this._items; }
            set { this._items = value; }
        }

        public List<OCS4001U00HospitalInfo> Hospitals
        {
            get { return this._hospitals; }
            set { this._hospitals = value; }
        }

        public List<OCS4001U00PrescriptionInfo> Prescriptions
        {
            get { return this._prescriptions; }
            set { this._prescriptions = value; }
        }

        public OCS4001U00Result() { }

    }
}