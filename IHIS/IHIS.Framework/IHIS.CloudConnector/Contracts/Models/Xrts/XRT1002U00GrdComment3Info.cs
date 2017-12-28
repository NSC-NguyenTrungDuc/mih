using System;

namespace IHIS.CloudConnector.Contracts.Models.Xrts
{
    [Serializable]
    public class XRT1002U00GrdComment3Info
    {
        private String _comments;
        private String _numb;
        private String _ser;

        public String Comments
        {
            get { return this._comments; }
            set { this._comments = value; }
        }

        public String Numb
        {
            get { return this._numb; }
            set { this._numb = value; }
        }

        public String Ser
        {
            get { return this._ser; }
            set { this._ser = value; }
        }

        public XRT1002U00GrdComment3Info() { }

        public XRT1002U00GrdComment3Info(String comments, String numb, String ser)
        {
            this._comments = comments;
            this._numb = numb;
            this._ser = ser;
        }

    }
}