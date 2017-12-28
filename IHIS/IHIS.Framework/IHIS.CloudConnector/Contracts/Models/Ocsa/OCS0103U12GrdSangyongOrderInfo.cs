using System;

namespace IHIS.CloudConnector.Contracts.Models.Ocsa
{
    [Serializable]
    public class OCS0103U12GrdSangyongOrderInfo
    {
        private String _slipCode;
        private String _slipName;
        private String _hangmogCode;
        private String _hangmogName;
        private String _seq;
        private String _hospCode;
        private String _memb;
        private String _membGubun;
        private String _wonnaeDrgYn;
        private String _rownum;
        private String _trialFlag;

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

        public String Seq
        {
            get { return this._seq; }
            set { this._seq = value; }
        }

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public String Memb
        {
            get { return this._memb; }
            set { this._memb = value; }
        }

        public String MembGubun
        {
            get { return this._membGubun; }
            set { this._membGubun = value; }
        }

        public String WonnaeDrgYn
        {
            get { return this._wonnaeDrgYn; }
            set { this._wonnaeDrgYn = value; }
        }

        public String Rownum
        {
            get { return this._rownum; }
            set { this._rownum = value; }
        }

        public String TrialFlag
        {
            get { return this._trialFlag; }
            set { this._trialFlag = value; }
        }

        public OCS0103U12GrdSangyongOrderInfo() { }

        public OCS0103U12GrdSangyongOrderInfo(String slipCode, String slipName, String hangmogCode, String hangmogName, String seq, String hospCode, String memb, String membGubun, String wonnaeDrgYn, String rownum, String trialFlag)
        {
            this._slipCode = slipCode;
            this._slipName = slipName;
            this._hangmogCode = hangmogCode;
            this._hangmogName = hangmogName;
            this._seq = seq;
            this._hospCode = hospCode;
            this._memb = memb;
            this._membGubun = membGubun;
            this._wonnaeDrgYn = wonnaeDrgYn;
            this._rownum = rownum;
            this._trialFlag = trialFlag;
        }

    }
}