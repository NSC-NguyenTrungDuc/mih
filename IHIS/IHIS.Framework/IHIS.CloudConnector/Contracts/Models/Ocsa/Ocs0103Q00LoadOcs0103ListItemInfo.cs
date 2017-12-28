using System;

namespace IHIS.CloudConnector.Contracts.Models.Ocsa
{
    [Serializable]
    public class Ocs0103Q00LoadOcs0103ListItemInfo
    {
        private String _orderGubun;
        private String _slipCode;
        private String _slipName;
        private String _hangmogCode;
        private String _hangmogName;
        private String _sgCode;
        private String _bulyongCheck;
        private String _wonnaeDrgYn;
        private String _selectYn;
        private String _inputControl;
        private String _bunCode;
        private String _seq;

        public String OrderGubun
        {
            get { return this._orderGubun; }
            set { this._orderGubun = value; }
        }

        public String SlipCode
        {
            get { return this._slipCode; }
            set { this._slipCode = value; }
        }

        public String SlipName
        {
            get { return this._slipName; }
            set { this._slipName = value; }
        }

        public String HangmogCode
        {
            get { return this._hangmogCode; }
            set { this._hangmogCode = value; }
        }

        public String HangmogName
        {
            get { return this._hangmogName; }
            set { this._hangmogName = value; }
        }

        public String SgCode
        {
            get { return this._sgCode; }
            set { this._sgCode = value; }
        }

        public String BulyongCheck
        {
            get { return this._bulyongCheck; }
            set { this._bulyongCheck = value; }
        }

        public String WonnaeDrgYn
        {
            get { return this._wonnaeDrgYn; }
            set { this._wonnaeDrgYn = value; }
        }

        public String SelectYn
        {
            get { return this._selectYn; }
            set { this._selectYn = value; }
        }

        public String InputControl
        {
            get { return this._inputControl; }
            set { this._inputControl = value; }
        }

        public String BunCode
        {
            get { return this._bunCode; }
            set { this._bunCode = value; }
        }

        public String Seq
        {
            get { return this._seq; }
            set { this._seq = value; }
        }

        public Ocs0103Q00LoadOcs0103ListItemInfo() { }

        public Ocs0103Q00LoadOcs0103ListItemInfo(String orderGubun, String slipCode, String slipName, String hangmogCode, String hangmogName, String sgCode, String bulyongCheck, String wonnaeDrgYn, String selectYn, String inputControl, String bunCode, String seq)
        {
            this._orderGubun = orderGubun;
            this._slipCode = slipCode;
            this._slipName = slipName;
            this._hangmogCode = hangmogCode;
            this._hangmogName = hangmogName;
            this._sgCode = sgCode;
            this._bulyongCheck = bulyongCheck;
            this._wonnaeDrgYn = wonnaeDrgYn;
            this._selectYn = selectYn;
            this._inputControl = inputControl;
            this._bunCode = bunCode;
            this._seq = seq;
        }

    }
}