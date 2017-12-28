using System;

namespace IHIS.CloudConnector.Contracts.Models.Ocso
{
    public class OCS4001U00ListItemInfo
    {
        private String _id;
        private String _createDate;
        private String _inputContent;
        private String _formName;
        private String _inputValue;
        private String _formatType;
        private String _printContent;
        private String _formCode;
        private String _prescriptionDate;

        public String Id
        {
            get { return this._id; }
            set { this._id = value; }
        }

        public String CreateDate
        {
            get { return this._createDate; }
            set { this._createDate = value; }
        }

        public String InputContent
        {
            get { return this._inputContent; }
            set { this._inputContent = value; }
        }

        public String FormName
        {
            get { return this._formName; }
            set { this._formName = value; }
        }

        public String InputValue
        {
            get { return this._inputValue; }
            set { this._inputValue = value; }
        }

        public String FormatType
        {
            get { return this._formatType; }
            set { this._formatType = value; }
        }

        public String PrintContent
        {
            get { return this._printContent; }
            set { this._printContent = value; }
        }

        public String FormCode
        {
            get { return this._formCode; }
            set { this._formCode = value; }
        }

        public String PrescriptionDate
        {
            get { return this._prescriptionDate; }
            set { this._prescriptionDate = value; }
        }

        public OCS4001U00ListItemInfo() { }

        public OCS4001U00ListItemInfo(String id, String createDate, String inputContent, String formName, String inputValue, String formatType, String printContent, String formCode, String prescriptionDate)
        {
            this._id = id;
            this._createDate = createDate;
            this._inputContent = inputContent;
            this._formName = formName;
            this._inputValue = inputValue;
            this._formatType = formatType;
            this._printContent = printContent;
            this._formCode = formCode;
            this._prescriptionDate = prescriptionDate;
        }

    }
}