using System;
using IHIS.CloudConnector.Contracts.Models.Phys;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Phys
{
    [Serializable]
    public class PHY8002U01SaveLayoutResult : AbstractContractResult
    {
        private Boolean _result8002;
        private Boolean _result8003;
        private Boolean _result8004;
        private String _pkPhy8002;
        private String _msgCase3;
        private List<PHY8002U01GrdPHY8002LisItemInfo> _setPHY8002Info = new List<PHY8002U01GrdPHY8002LisItemInfo>();

        public Boolean Result8002
        {
            get { return this._result8002; }
            set { this._result8002 = value; }
        }

        public Boolean Result8003
        {
            get { return this._result8003; }
            set { this._result8003 = value; }
        }

        public Boolean Result8004
        {
            get { return this._result8004; }
            set { this._result8004 = value; }
        }

        public String PkPhy8002
        {
            get { return this._pkPhy8002; }
            set { this._pkPhy8002 = value; }
        }

        public String MsgCase3
        {
            get { return this._msgCase3; }
            set { this._msgCase3 = value; }
        }

        public List<PHY8002U01GrdPHY8002LisItemInfo> SetPHY8002Info
        {
            get { return this._setPHY8002Info; }
            set { this._setPHY8002Info = value; }
        }

        public PHY8002U01SaveLayoutResult() { }

    }
}