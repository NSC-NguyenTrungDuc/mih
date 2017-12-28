using System;

namespace IHIS.CloudConnector.Contracts.Models.Xrts
{
    [Serializable]
    public class XRT0201U00ToolTipInfo
    {
        private String _numProtocol;

        public String NumProtocol
        {
            get { return this._numProtocol; }
            set { this._numProtocol = value; }
        }

        public XRT0201U00ToolTipInfo() { }

        public XRT0201U00ToolTipInfo(String numProtocol)
        {
            this._numProtocol = numProtocol;
        }

    }
}