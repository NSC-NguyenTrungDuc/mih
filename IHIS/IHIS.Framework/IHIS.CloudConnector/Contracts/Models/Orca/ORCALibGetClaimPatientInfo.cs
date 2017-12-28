using System;

namespace IHIS.CloudConnector.Contracts.Models.Orca
{
    [Serializable]
    public class ORCALibGetClaimPatientInfo
    {
        private String _updDate;
        private String _updId;
        private String _hospCode;
        private String _pkoif1101;
        private String _docUid;
        private String _cmId;
        private String _license;
        private String _bunho;
        private String _suname1;
        private String _suname2;
        private String _suname3;
        private String _degree;
        private String _sex;
        private String _birth;
        private String _nationality;
        private String _marital;
        private String _accntNum;
        private String _socialid;
        private String _email;
        private String _death;
        private String _deathDate;
        private String _endFlag;
        private String _pkoif1102;
        private String _addrCode;
        private String _addrFull;
        private String _prefecture;
        private String _cityB;
        private String _town;
        private String _homeNum;
        private String _zip;
        private String _countryB;
        private String _pkoif1103;
        private String _telCode;
        private String _area;
        private String _cityC;
        private String _num;
        private String _extension;
        private String _countryC;
        private String _memo;

        public String UpdDate
        {
            get { return this._updDate; }
            set { this._updDate = value; }
        }

        public String UpdId
        {
            get { return this._updId; }
            set { this._updId = value; }
        }

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public String Pkoif1101
        {
            get { return this._pkoif1101; }
            set { this._pkoif1101 = value; }
        }

        public String DocUid
        {
            get { return this._docUid; }
            set { this._docUid = value; }
        }

        public String CmId
        {
            get { return this._cmId; }
            set { this._cmId = value; }
        }

        public String License
        {
            get { return this._license; }
            set { this._license = value; }
        }

        public String Bunho
        {
            get { return this._bunho; }
            set { this._bunho = value; }
        }

        public String Suname1
        {
            get { return this._suname1; }
            set { this._suname1 = value; }
        }

        public String Suname2
        {
            get { return this._suname2; }
            set { this._suname2 = value; }
        }

        public String Suname3
        {
            get { return this._suname3; }
            set { this._suname3 = value; }
        }

        public String Degree
        {
            get { return this._degree; }
            set { this._degree = value; }
        }

        public String Sex
        {
            get { return this._sex; }
            set { this._sex = value; }
        }

        public String Birth
        {
            get { return this._birth; }
            set { this._birth = value; }
        }

        public String Nationality
        {
            get { return this._nationality; }
            set { this._nationality = value; }
        }

        public String Marital
        {
            get { return this._marital; }
            set { this._marital = value; }
        }

        public String AccntNum
        {
            get { return this._accntNum; }
            set { this._accntNum = value; }
        }

        public String Socialid
        {
            get { return this._socialid; }
            set { this._socialid = value; }
        }

        public String Email
        {
            get { return this._email; }
            set { this._email = value; }
        }

        public String Death
        {
            get { return this._death; }
            set { this._death = value; }
        }

        public String DeathDate
        {
            get { return this._deathDate; }
            set { this._deathDate = value; }
        }

        public String EndFlag
        {
            get { return this._endFlag; }
            set { this._endFlag = value; }
        }

        public String Pkoif1102
        {
            get { return this._pkoif1102; }
            set { this._pkoif1102 = value; }
        }

        public String AddrCode
        {
            get { return this._addrCode; }
            set { this._addrCode = value; }
        }

        public String AddrFull
        {
            get { return this._addrFull; }
            set { this._addrFull = value; }
        }

        public String Prefecture
        {
            get { return this._prefecture; }
            set { this._prefecture = value; }
        }

        public String CityB
        {
            get { return this._cityB; }
            set { this._cityB = value; }
        }

        public String Town
        {
            get { return this._town; }
            set { this._town = value; }
        }

        public String HomeNum
        {
            get { return this._homeNum; }
            set { this._homeNum = value; }
        }

        public String Zip
        {
            get { return this._zip; }
            set { this._zip = value; }
        }

        public String CountryB
        {
            get { return this._countryB; }
            set { this._countryB = value; }
        }

        public String Pkoif1103
        {
            get { return this._pkoif1103; }
            set { this._pkoif1103 = value; }
        }

        public String TelCode
        {
            get { return this._telCode; }
            set { this._telCode = value; }
        }

        public String Area
        {
            get { return this._area; }
            set { this._area = value; }
        }

        public String CityC
        {
            get { return this._cityC; }
            set { this._cityC = value; }
        }

        public String Num
        {
            get { return this._num; }
            set { this._num = value; }
        }

        public String Extension
        {
            get { return this._extension; }
            set { this._extension = value; }
        }

        public String CountryC
        {
            get { return this._countryC; }
            set { this._countryC = value; }
        }

        public String Memo
        {
            get { return this._memo; }
            set { this._memo = value; }
        }

        public ORCALibGetClaimPatientInfo() { }

        public ORCALibGetClaimPatientInfo(String updDate, String updId, String hospCode, String pkoif1101, String docUid, String cmId, String license, String bunho, String suname1, String suname2, String suname3, String degree, String sex, String birth, String nationality, String marital, String accntNum, String socialid, String email, String death, String deathDate, String endFlag, String pkoif1102, String addrCode, String addrFull, String prefecture, String cityB, String town, String homeNum, String zip, String countryB, String pkoif1103, String telCode, String area, String cityC, String num, String extension, String countryC, String memo)
        {
            this._updDate = updDate;
            this._updId = updId;
            this._hospCode = hospCode;
            this._pkoif1101 = pkoif1101;
            this._docUid = docUid;
            this._cmId = cmId;
            this._license = license;
            this._bunho = bunho;
            this._suname1 = suname1;
            this._suname2 = suname2;
            this._suname3 = suname3;
            this._degree = degree;
            this._sex = sex;
            this._birth = birth;
            this._nationality = nationality;
            this._marital = marital;
            this._accntNum = accntNum;
            this._socialid = socialid;
            this._email = email;
            this._death = death;
            this._deathDate = deathDate;
            this._endFlag = endFlag;
            this._pkoif1102 = pkoif1102;
            this._addrCode = addrCode;
            this._addrFull = addrFull;
            this._prefecture = prefecture;
            this._cityB = cityB;
            this._town = town;
            this._homeNum = homeNum;
            this._zip = zip;
            this._countryB = countryB;
            this._pkoif1103 = pkoif1103;
            this._telCode = telCode;
            this._area = area;
            this._cityC = cityC;
            this._num = num;
            this._extension = extension;
            this._countryC = countryC;
            this._memo = memo;
        }

    }
}