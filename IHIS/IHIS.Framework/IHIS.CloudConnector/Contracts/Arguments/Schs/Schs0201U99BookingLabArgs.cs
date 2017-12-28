using System;
using IHIS.CloudConnector.Contracts.Models.Schs;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Schs
{
    public class Schs0201U99BookingLabArgs : IContractArgs
    {
        private String _doctor;
        private String _gwa;
        private String _bunhoLink;
        private String _hospCode;
        private String _naewonDate;
        private List<SCH0201U99ListFkschInfo> _lstFksch = new List<SCH0201U99ListFkschInfo>();
        private String _pkout1001;
        private String _changu;
        private String _chojae;
        private String _gubun;
        private String _inputGubun;
        private String _reserComment;
        private String _outHospcode;
        private String _iudGubun;
        private String _resGubun;
        private String _reserDate;
        private String _reserTime;
        private String _inputId;
        private String _reserYn;
        private String _nameKana;
        private String _nameKanji;

        public String Doctor
        {
            get { return this._doctor; }
            set { this._doctor = value; }
        }

        public String Gwa
        {
            get { return this._gwa; }
            set { this._gwa = value; }
        }

        public String BunhoLink
        {
            get { return this._bunhoLink; }
            set { this._bunhoLink = value; }
        }

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public String NaewonDate
        {
            get { return this._naewonDate; }
            set { this._naewonDate = value; }
        }

        public List<SCH0201U99ListFkschInfo> LstFksch
        {
            get { return this._lstFksch; }
            set { this._lstFksch = value; }
        }

        public String Pkout1001
        {
            get { return this._pkout1001; }
            set { this._pkout1001 = value; }
        }

        public String Changu
        {
            get { return this._changu; }
            set { this._changu = value; }
        }

        public String Chojae
        {
            get { return this._chojae; }
            set { this._chojae = value; }
        }

        public String Gubun
        {
            get { return this._gubun; }
            set { this._gubun = value; }
        }

        public String InputGubun
        {
            get { return this._inputGubun; }
            set { this._inputGubun = value; }
        }

        public String ReserComment
        {
            get { return this._reserComment; }
            set { this._reserComment = value; }
        }

        public String OutHospcode
        {
            get { return this._outHospcode; }
            set { this._outHospcode = value; }
        }

        public String IudGubun
        {
            get { return this._iudGubun; }
            set { this._iudGubun = value; }
        }

        public String ResGubun
        {
            get { return this._resGubun; }
            set { this._resGubun = value; }
        }

        public String ReserDate
        {
            get { return this._reserDate; }
            set { this._reserDate = value; }
        }

        public String ReserTime
        {
            get { return this._reserTime; }
            set { this._reserTime = value; }
        }

        public String InputId
        {
            get { return this._inputId; }
            set { this._inputId = value; }
        }

        public String ReserYn
        {
            get { return this._reserYn; }
            set { this._reserYn = value; }
        }

        public String NameKana
        {
            get { return this._nameKana; }
            set { this._nameKana = value; }
        }

        public String NameKanji
        {
            get { return this._nameKanji; }
            set { this._nameKanji = value; }
        }

        public Schs0201U99BookingLabArgs() { }

        public Schs0201U99BookingLabArgs(String doctor, String gwa, String bunhoLink, String hospCode, String naewonDate, List<SCH0201U99ListFkschInfo> lstFksch, String pkout1001, String changu, String chojae, String gubun, String inputGubun, String reserComment, String outHospcode, String iudGubun, String resGubun, String reserDate, String reserTime, String inputId, String reserYn, String nameKana, String nameKanji)
        {
            this._doctor = doctor;
            this._gwa = gwa;
            this._bunhoLink = bunhoLink;
            this._hospCode = hospCode;
            this._naewonDate = naewonDate;
            this._lstFksch = lstFksch;
            this._pkout1001 = pkout1001;
            this._changu = changu;
            this._chojae = chojae;
            this._gubun = gubun;
            this._inputGubun = inputGubun;
            this._reserComment = reserComment;
            this._outHospcode = outHospcode;
            this._iudGubun = iudGubun;
            this._resGubun = resGubun;
            this._reserDate = reserDate;
            this._reserTime = reserTime;
            this._inputId = inputId;
            this._reserYn = reserYn;
            this._nameKana = nameKana;
            this._nameKanji = nameKanji;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.Schs0201U99BookingLabRequest();
        }
    }
}