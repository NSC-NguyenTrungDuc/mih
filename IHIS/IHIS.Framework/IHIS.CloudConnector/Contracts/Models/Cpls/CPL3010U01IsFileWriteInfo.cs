using System;

namespace IHIS.CloudConnector.Contracts.Models.Cpls
{
    [Serializable]
    public class CPL3010U01IsFileWriteInfo
    {
        private String _requestKey;
        private String _bunho;
        private String _jubsuDate;
        private String _jubsuTime;
        private String _hangmogCnt;
        private String _urine;
        private String _sendYn;

        public String RequestKey
        {
            get { return this._requestKey; }
            set { this._requestKey = value; }
        }

        public String Bunho
        {
            get { return this._bunho; }
            set { this._bunho = value; }
        }

        public String JubsuDate
        {
            get { return this._jubsuDate; }
            set { this._jubsuDate = value; }
        }

        public String JubsuTime
        {
            get { return this._jubsuTime; }
            set { this._jubsuTime = value; }
        }

        public String HangmogCnt
        {
            get { return this._hangmogCnt; }
            set { this._hangmogCnt = value; }
        }

        public String Urine
        {
            get { return this._urine; }
            set { this._urine = value; }
        }

        public String SendYn
        {
            get { return this._sendYn; }
            set { this._sendYn = value; }
        }

        public CPL3010U01IsFileWriteInfo() { }

        public CPL3010U01IsFileWriteInfo(String requestKey, String bunho, String jubsuDate, String jubsuTime, String hangmogCnt, String urine, String sendYn)
        {
            this._requestKey = requestKey;
            this._bunho = bunho;
            this._jubsuDate = jubsuDate;
            this._jubsuTime = jubsuTime;
            this._hangmogCnt = hangmogCnt;
            this._urine = urine;
            this._sendYn = sendYn;
        }

    }
}