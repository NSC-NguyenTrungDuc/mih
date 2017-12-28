using System;

namespace IHIS.CloudConnector.Contracts.Models.Nuro
{
    [Serializable]
    public class ORDERTRANSGrdCommentsInfo
    {
        private String _bunho;
        private String _ser;
        private String _comments;

        public String Bunho
        {
            get { return this._bunho; }
            set { this._bunho = value; }
        }

        public String Ser
        {
            get { return this._ser; }
            set { this._ser = value; }
        }

        public String Comments
        {
            get { return this._comments; }
            set { this._comments = value; }
        }

        public ORDERTRANSGrdCommentsInfo() { }

        public ORDERTRANSGrdCommentsInfo(String bunho, String ser, String comments)
        {
            this._bunho = bunho;
            this._ser = ser;
            this._comments = comments;
        }

    }
}