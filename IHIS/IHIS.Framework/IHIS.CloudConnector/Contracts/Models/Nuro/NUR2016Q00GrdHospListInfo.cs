using System;

namespace IHIS.CloudConnector.Contracts.Models.Nuro
{
    public class NUR2016Q00GrdHospListInfo
    {
        private String _hospCode;
        private String _yoyangName;
        private String _kanaName;
        private String _address;
        private String _tel;

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public String YoyangName
        {
            get { return this._yoyangName; }
            set { this._yoyangName = value; }
        }

        public String KanaName
        {
            get { return this._kanaName; }
            set { this._kanaName = value; }
        }

        public String Address
        {
            get { return this._address; }
            set { this._address = value; }
        }

        public String Tel
        {
            get { return this._tel; }
            set { this._tel = value; }
        }

        public NUR2016Q00GrdHospListInfo() { }

        public NUR2016Q00GrdHospListInfo(String hospCode, String yoyangName, String kanaName, String address, String tel)
        {
            this._hospCode = hospCode;
            this._yoyangName = yoyangName;
            this._kanaName = kanaName;
            this._address = address;
            this._tel = tel;
        }

    }
}