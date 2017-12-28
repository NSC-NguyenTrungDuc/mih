using System;
using IHIS.CloudConnector.Contracts.Models.Phys;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Phys
{
    [Serializable]
    public class PHY8002U01SaveLayoutArgs : IContractArgs
    {
        protected bool Equals(PHY8002U01SaveLayoutArgs other)
        {
            return string.Equals(_userId, other._userId) && string.Equals(_fkOcs, other._fkOcs) && string.Equals(_ioKubun, other._ioKubun) && Equals(_input8002, other._input8002) && Equals(_input8003, other._input8003) && Equals(_input8004, other._input8004) && string.Equals(_approveDoctorGwa, other._approveDoctorGwa) && string.Equals(_approveDoctorId, other._approveDoctorId) && string.Equals(_pkScan001, other._pkScan001) && string.Equals(_bunho, other._bunho) && string.Equals(_copyPkocskey, other._copyPkocskey) && string.Equals(_userGubun, other._userGubun) && string.Equals(_leaveCnt, other._leaveCnt);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((PHY8002U01SaveLayoutArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_userId != null ? _userId.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_fkOcs != null ? _fkOcs.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_ioKubun != null ? _ioKubun.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_input8002 != null ? _input8002.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_input8003 != null ? _input8003.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_input8004 != null ? _input8004.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_approveDoctorGwa != null ? _approveDoctorGwa.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_approveDoctorId != null ? _approveDoctorId.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_pkScan001 != null ? _pkScan001.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_bunho != null ? _bunho.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_copyPkocskey != null ? _copyPkocskey.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_userGubun != null ? _userGubun.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_leaveCnt != null ? _leaveCnt.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _userId;
        private String _fkOcs;
        private String _ioKubun;
        private List<PHY8002U01GrdPHY8002LisItemInfo> _input8002 = new List<PHY8002U01GrdPHY8002LisItemInfo>();
        private List<PHY8002U01GrdPHY8003LisItemInfo> _input8003 = new List<PHY8002U01GrdPHY8003LisItemInfo>();
        private List<PHY8002U01GrdPHY8004LisItemInfo> _input8004 = new List<PHY8002U01GrdPHY8004LisItemInfo>();
        private String _approveDoctorGwa;
        private String _approveDoctorId;
        private String _pkScan001;
        private String _bunho;
        private String _copyPkocskey;
        private String _userGubun;
        private String _leaveCnt;

        public String UserId
        {
            get { return this._userId; }
            set { this._userId = value; }
        }

        public String FkOcs
        {
            get { return this._fkOcs; }
            set { this._fkOcs = value; }
        }

        public String IoKubun
        {
            get { return this._ioKubun; }
            set { this._ioKubun = value; }
        }

        public List<PHY8002U01GrdPHY8002LisItemInfo> Input8002
        {
            get { return this._input8002; }
            set { this._input8002 = value; }
        }

        public List<PHY8002U01GrdPHY8003LisItemInfo> Input8003
        {
            get { return this._input8003; }
            set { this._input8003 = value; }
        }

        public List<PHY8002U01GrdPHY8004LisItemInfo> Input8004
        {
            get { return this._input8004; }
            set { this._input8004 = value; }
        }

        public String ApproveDoctorGwa
        {
            get { return this._approveDoctorGwa; }
            set { this._approveDoctorGwa = value; }
        }

        public String ApproveDoctorId
        {
            get { return this._approveDoctorId; }
            set { this._approveDoctorId = value; }
        }

        public String PkScan001
        {
            get { return this._pkScan001; }
            set { this._pkScan001 = value; }
        }

        public String Bunho
        {
            get { return this._bunho; }
            set { this._bunho = value; }
        }

        public String CopyPkocskey
        {
            get { return this._copyPkocskey; }
            set { this._copyPkocskey = value; }
        }

        public String UserGubun
        {
            get { return this._userGubun; }
            set { this._userGubun = value; }
        }

        public String LeaveCnt
        {
            get { return this._leaveCnt; }
            set { this._leaveCnt = value; }
        }

        public PHY8002U01SaveLayoutArgs() { }

        public PHY8002U01SaveLayoutArgs(String userId, String fkOcs, String ioKubun, List<PHY8002U01GrdPHY8002LisItemInfo> input8002, List<PHY8002U01GrdPHY8003LisItemInfo> input8003, List<PHY8002U01GrdPHY8004LisItemInfo> input8004, String approveDoctorGwa, String approveDoctorId, String pkScan001, String bunho, String copyPkocskey, String userGubun, String leaveCnt)
        {
            this._userId = userId;
            this._fkOcs = fkOcs;
            this._ioKubun = ioKubun;
            this._input8002 = input8002;
            this._input8003 = input8003;
            this._input8004 = input8004;
            this._approveDoctorGwa = approveDoctorGwa;
            this._approveDoctorId = approveDoctorId;
            this._pkScan001 = pkScan001;
            this._bunho = bunho;
            this._copyPkocskey = copyPkocskey;
            this._userGubun = userGubun;
            this._leaveCnt = leaveCnt;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.PHY8002U01SaveLayoutRequest();
        }
    }
}