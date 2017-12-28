using System;

namespace IHIS.CloudConnector.Contracts.Models.System
{
    [Serializable]
    public class DrugInteractionInfo
    {
        private String _drugId;
        private String _branchNumber;
        private String _yj9Code;
        private String _describedClssification;
        private String _a5;
        private String _a6;
        private String _a7;
        private String _a8;
        private String _a9;
        private String _orderNote;
        private String _a11;
        private String _comment;

        public String DrugId
        {
            get { return this._drugId; }
            set { this._drugId = value; }
        }

        public String BranchNumber
        {
            get { return this._branchNumber; }
            set { this._branchNumber = value; }
        }

        public String Yj9Code
        {
            get { return this._yj9Code; }
            set { this._yj9Code = value; }
        }

        public String DescribedClssification
        {
            get { return this._describedClssification; }
            set { this._describedClssification = value; }
        }

        public String A5
        {
            get { return this._a5; }
            set { this._a5 = value; }
        }

        public String A6
        {
            get { return this._a6; }
            set { this._a6 = value; }
        }

        public String A7
        {
            get { return this._a7; }
            set { this._a7 = value; }
        }

        public String A8
        {
            get { return this._a8; }
            set { this._a8 = value; }
        }

        public String A9
        {
            get { return this._a9; }
            set { this._a9 = value; }
        }

        public String OrderNote
        {
            get { return this._orderNote; }
            set { this._orderNote = value; }
        }

        public String A11
        {
            get { return this._a11; }
            set { this._a11 = value; }
        }

        public String Comment
        {
            get { return this._comment; }
            set { this._comment = value; }
        }

        public DrugInteractionInfo() { }

        public DrugInteractionInfo(String drugId, String branchNumber, String yj9Code, String describedClssification, String a5, String a6, String a7, String a8, String a9, String orderNote, String a11, String comment)
        {
            this._drugId = drugId;
            this._branchNumber = branchNumber;
            this._yj9Code = yj9Code;
            this._describedClssification = describedClssification;
            this._a5 = a5;
            this._a6 = a6;
            this._a7 = a7;
            this._a8 = a8;
            this._a9 = a9;
            this._orderNote = orderNote;
            this._a11 = a11;
            this._comment = comment;
        }

    }
}