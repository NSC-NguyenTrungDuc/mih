using System;
using IHIS.CloudConnector.Contracts.Models.Invs;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Invs
{
    public class SaveLayoutINV0101Args : IContractArgs
    {
        private List<LoadGrdMasterINV0101Info> _listMaster = new List<LoadGrdMasterINV0101Info>();
        private List<LoadGrdDetailINV0101Info> _listDetail = new List<LoadGrdDetailINV0101Info>();
        private String _userId;

        public List<LoadGrdMasterINV0101Info> ListMaster
        {
            get { return this._listMaster; }
            set { this._listMaster = value; }
        }

        public List<LoadGrdDetailINV0101Info> ListDetail
        {
            get { return this._listDetail; }
            set { this._listDetail = value; }
        }

        public String UserId
        {
            get { return this._userId; }
            set { this._userId = value; }
        }

        public SaveLayoutINV0101Args() { }

        public SaveLayoutINV0101Args(List<LoadGrdMasterINV0101Info> listMaster, List<LoadGrdDetailINV0101Info> listDetail, String userId)
        {
            this._listMaster = listMaster;
            this._listDetail = listDetail;
            this._userId = userId;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.SaveLayoutINV0101Request();
        }
    }
}