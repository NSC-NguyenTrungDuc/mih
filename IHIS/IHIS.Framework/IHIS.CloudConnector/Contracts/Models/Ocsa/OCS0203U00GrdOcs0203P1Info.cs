using System;

namespace IHIS.CloudConnector.Contracts.Models.Ocsa
{
    [Serializable]
    public class OCS0203U00GrdOcs0203P1Info
    {
        private String _memb;
        private String _slipCode;
        private String _value999;
        private String _nValue;
        private String _hangmogCode;
        private String _hangmogName;
        private String _bulyongYn;
        private String _newFlag;
        private String _seq;
        private String _oftenUsed;

        public String Memb
        {
            get { return this._memb; }
            set { this._memb = value; }
        }

        public String SlipCode
        {
            get { return this._slipCode; }
            set { this._slipCode = value; }
        }

        public String Value999
        {
            get { return this._value999; }
            set { this._value999 = value; }
        }

        public String NValue
        {
            get { return this._nValue; }
            set { this._nValue = value; }
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

        public String BulyongYn
        {
            get { return this._bulyongYn; }
            set { this._bulyongYn = value; }
        }

        public String NewFlag
        {
            get { return this._newFlag; }
            set { this._newFlag = value; }
        }

        public String Seq
        {
            get { return this._seq; }
            set { this._seq = value; }
        }

        public String OftenUsed
        {
            get { return this._oftenUsed; }
            set { this._oftenUsed = value; }
        }

        public OCS0203U00GrdOcs0203P1Info() { }

        public OCS0203U00GrdOcs0203P1Info(String memb, String slipCode, String value999, String nValue, String hangmogCode, String hangmogName, String bulyongYn, String newFlag, String seq, String oftenUsed)
        {
            this._memb = memb;
            this._slipCode = slipCode;
            this._value999 = value999;
            this._nValue = nValue;
            this._hangmogCode = hangmogCode;
            this._hangmogName = hangmogName;
            this._bulyongYn = bulyongYn;
            this._newFlag = newFlag;
            this._seq = seq;
            this._oftenUsed = oftenUsed;
        }

    }
}