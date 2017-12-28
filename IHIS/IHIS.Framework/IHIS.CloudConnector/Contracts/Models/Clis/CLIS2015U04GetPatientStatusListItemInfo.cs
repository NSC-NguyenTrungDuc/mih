using System;

namespace IHIS.CloudConnector.Contracts.Models.Clis
{
    [Serializable]
    public class CLIS2015U04GetPatientStatusListItemInfo
    {
        private String _patientStatusId;
        private String _description;
        private String _updated;
        private String _codeName;
        private String _sortNo;
        private String _sysId;
        private String _updateDate;
        private String _code;
        private String _protocolPatientId;
        private String _rowState;

        public String PatientStatusId
        {
            get { return this._patientStatusId; }
            set { this._patientStatusId = value; }
        }

        public String Description
        {
            get { return this._description; }
            set { this._description = value; }
        }

        public String Updated
        {
            get { return this._updated; }
            set { this._updated = value; }
        }

        public String CodeName
        {
            get { return this._codeName; }
            set { this._codeName = value; }
        }

        public String SortNo
        {
            get { return this._sortNo; }
            set { this._sortNo = value; }
        }

        public String SysId
        {
            get { return this._sysId; }
            set { this._sysId = value; }
        }

        public String UpdateDate
        {
            get { return this._updateDate; }
            set { this._updateDate = value; }
        }

        public String Code
        {
            get { return this._code; }
            set { this._code = value; }
        }

        public String ProtocolPatientId
        {
            get { return this._protocolPatientId; }
            set { this._protocolPatientId = value; }
        }

        public String RowState
        {
            get { return this._rowState; }
            set { this._rowState = value; }
        }

        public CLIS2015U04GetPatientStatusListItemInfo() { }

        public CLIS2015U04GetPatientStatusListItemInfo(String patientStatusId, String description, String updated, String codeName, String sortNo, String sysId, String updateDate, String code, String protocolPatientId, String rowState)
        {
            this._patientStatusId = patientStatusId;
            this._description = description;
            this._updated = updated;
            this._codeName = codeName;
            this._sortNo = sortNo;
            this._sysId = sysId;
            this._updateDate = updateDate;
            this._code = code;
            this._protocolPatientId = protocolPatientId;
            this._rowState = rowState;
        }

    }
}