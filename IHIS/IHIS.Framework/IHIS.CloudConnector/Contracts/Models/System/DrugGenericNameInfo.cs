using System;

namespace IHIS.CloudConnector.Contracts.Models.System
{
    [Serializable]
    public class DrugGenericNameInfo
    {
        private String _drugId;
        private String _branchNumber;
        private String _yj9Code;
        private String _describedClssification;
        private String _orderNote;
        private String _a6;
        private String _yj9CodeEffect;
        private String _a8;
        private String _comment1;
        private String _comment2;

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

        public String OrderNote
        {
            get { return this._orderNote; }
            set { this._orderNote = value; }
        }

        public String A6
        {
            get { return this._a6; }
            set { this._a6 = value; }
        }

        public String Yj9CodeEffect
        {
            get { return this._yj9CodeEffect; }
            set { this._yj9CodeEffect = value; }
        }

        public String A8
        {
            get { return this._a8; }
            set { this._a8 = value; }
        }

        public String Comment1
        {
            get { return this._comment1; }
            set { this._comment1 = value; }
        }

        public String Comment2
        {
            get { return this._comment2; }
            set { this._comment2 = value; }
        }

        public DrugGenericNameInfo() { }

        public DrugGenericNameInfo(String drugId, String branchNumber, String yj9Code, String describedClssification, String orderNote, String a6, String yj9CodeEffect, String a8, String comment1, String comment2)
        {
            this._drugId = drugId;
            this._branchNumber = branchNumber;
            this._yj9Code = yj9Code;
            this._describedClssification = describedClssification;
            this._orderNote = orderNote;
            this._a6 = a6;
            this._yj9CodeEffect = yj9CodeEffect;
            this._a8 = a8;
            this._comment1 = comment1;
            this._comment2 = comment2;
        }

    }
}