using System;

namespace IHIS.CloudConnector.Contracts.Models.Ocsa
{
    [Serializable]
    public class OCS0203U00LayOCS0212Info
    {
        private String _hangmogCode;
        private String _oftenUse;
        private String _memb;
        private String _membGubun;
        private String _hospCode;

        public String HangmogCode
        {
            get { return this._hangmogCode; }
            set { this._hangmogCode = value; }
        }

        public String OftenUse
        {
            get { return this._oftenUse; }
            set { this._oftenUse = value; }
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

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public OCS0203U00LayOCS0212Info() { }

        public OCS0203U00LayOCS0212Info(String hangmogCode, String oftenUse, String memb, String membGubun, String hospCode)
        {
            this._hangmogCode = hangmogCode;
            this._oftenUse = oftenUse;
            this._memb = memb;
            this._membGubun = membGubun;
            this._hospCode = hospCode;
        }

    }
}