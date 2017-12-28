using System;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{
    public class OCS0301U00MembCRUDArgs : IContractArgs
    {
        private List<OCS0301U00MembGrdInfo> _grdOCS0300Info = new List<OCS0301U00MembGrdInfo>();
        private List<OCS0301U00MembGrdInfo> _grdOCS0301Info = new List<OCS0301U00MembGrdInfo>();
        private List<OCS0301U00SaveLayoutInfo> _deleteLayoutInfo = new List<OCS0301U00SaveLayoutInfo>();
        private List<OCS0301U00SaveLayoutInfo> _saveLayoutInfo = new List<OCS0301U00SaveLayoutInfo>();
        private String _userId;
        private String _hospCode;
        private List<OCS0301U00Membgrd307Info> _grdOCS0307Info = new List<OCS0301U00Membgrd307Info>();

        public List<OCS0301U00MembGrdInfo> GrdOCS0300Info
        {
            get { return this._grdOCS0300Info; }
            set { this._grdOCS0300Info = value; }
        }

        public List<OCS0301U00MembGrdInfo> GrdOCS0301Info
        {
            get { return this._grdOCS0301Info; }
            set { this._grdOCS0301Info = value; }
        }

        public List<OCS0301U00SaveLayoutInfo> DeleteLayoutInfo
        {
            get { return this._deleteLayoutInfo; }
            set { this._deleteLayoutInfo = value; }
        }

        public List<OCS0301U00SaveLayoutInfo> SaveLayoutInfo
        {
            get { return this._saveLayoutInfo; }
            set { this._saveLayoutInfo = value; }
        }

        public String UserId
        {
            get { return this._userId; }
            set { this._userId = value; }
        }

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public List<OCS0301U00Membgrd307Info> GrdOCS0307Info
        {
            get { return this._grdOCS0307Info; }
            set { this._grdOCS0307Info = value; }
        }

        public OCS0301U00MembCRUDArgs() { }

        public OCS0301U00MembCRUDArgs(List<OCS0301U00MembGrdInfo> grdOCS0300Info, List<OCS0301U00MembGrdInfo> grdOCS0301Info, List<OCS0301U00SaveLayoutInfo> deleteLayoutInfo, List<OCS0301U00SaveLayoutInfo> saveLayoutInfo, String userId, String hospCode, List<OCS0301U00Membgrd307Info> grdOCS0307Info)
        {
            this._grdOCS0300Info = grdOCS0300Info;
            this._grdOCS0301Info = grdOCS0301Info;
            this._deleteLayoutInfo = deleteLayoutInfo;
            this._saveLayoutInfo = saveLayoutInfo;
            this._userId = userId;
            this._hospCode = hospCode;
            this._grdOCS0307Info = grdOCS0307Info;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OCS0301U00MembCRUDRequest();
        }
    }
}