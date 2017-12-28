using System;

namespace IHIS.CloudConnector.Contracts.Models.Ocso
{
    public class OCS4001U00SaveInfo
    {
        private String _id;
        private String _tplCode;
        private String _formatType;
        private String _formCode;
        private String _formName;
        private String _inputContent;
        private String _inputValue;
        private String _printContent;
        private String _bunho;
        private String _hospCode;
        private String _createDate;
        private String _printDatetime;
        private String _sysId;
        private String _sysDate;
        private String _updId;
        private String _updDate;
        private String _activeFlg;
        private String _prescriptionDate;
        private String _rowState;

        public String Id
        {
            get { return this._id; }
            set { this._id = value; }
        }

        public String TplCode
        {
            get { return this._tplCode; }
            set { this._tplCode = value; }
        }

        public String FormatType
        {
            get { return this._formatType; }
            set { this._formatType = value; }
        }

        public String FormCode
        {
            get { return this._formCode; }
            set { this._formCode = value; }
        }

        public String FormName
        {
            get { return this._formName; }
            set { this._formName = value; }
        }

        public String InputContent
        {
            get { return this._inputContent; }
            set { this._inputContent = value; }
        }

        public String InputValue
        {
            get { return this._inputValue; }
            set { this._inputValue = value; }
        }

        public String PrintContent
        {
            get { return this._printContent; }
            set { this._printContent = value; }
        }

        public String Bunho
        {
            get { return this._bunho; }
            set { this._bunho = value; }
        }

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public String CreateDate
        {
            get { return this._createDate; }
            set { this._createDate = value; }
        }

        public String PrintDatetime
        {
            get { return this._printDatetime; }
            set { this._printDatetime = value; }
        }

        public String SysId
        {
            get { return this._sysId; }
            set { this._sysId = value; }
        }

        public String SysDate
        {
            get { return this._sysDate; }
            set { this._sysDate = value; }
        }

        public String UpdId
        {
            get { return this._updId; }
            set { this._updId = value; }
        }

        public String UpdDate
        {
            get { return this._updDate; }
            set { this._updDate = value; }
        }

        public String ActiveFlg
        {
            get { return this._activeFlg; }
            set { this._activeFlg = value; }
        }

        public String PrescriptionDate
        {
            get { return this._prescriptionDate; }
            set { this._prescriptionDate = value; }
        }

        public String RowState
        {
            get { return this._rowState; }
            set { this._rowState = value; }
        }

        public OCS4001U00SaveInfo() { }

        public OCS4001U00SaveInfo(String id, String tplCode, String formatType, String formCode, String formName, String inputContent, String inputValue, String printContent, String bunho, String hospCode, String createDate, String printDatetime, String sysId, String sysDate, String updId, String updDate, String activeFlg, String prescriptionDate, String rowState)
        {
            this._id = id;
            this._tplCode = tplCode;
            this._formatType = formatType;
            this._formCode = formCode;
            this._formName = formName;
            this._inputContent = inputContent;
            this._inputValue = inputValue;
            this._printContent = printContent;
            this._bunho = bunho;
            this._hospCode = hospCode;
            this._createDate = createDate;
            this._printDatetime = printDatetime;
            this._sysId = sysId;
            this._sysDate = sysDate;
            this._updId = updId;
            this._updDate = updDate;
            this._activeFlg = activeFlg;
            this._prescriptionDate = prescriptionDate;
            this._rowState = rowState;
        }

    }
}