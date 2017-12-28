using System;
using IHIS.CloudConnector.Contracts.Models.Invs;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Invs
{
    public class SaveLayoutINV0101U01Args : IContractArgs
    {
        private List<INV0101U01GridMasterInfo> _listMaster = new List<INV0101U01GridMasterInfo>();
        private List<INV0101U01GridDetailInfo> _listDetail = new List<INV0101U01GridDetailInfo>();
        private String _userId;

        public List<INV0101U01GridMasterInfo> ListMaster
        {
            get { return this._listMaster; }
            set { this._listMaster = value; }
        }

        public List<INV0101U01GridDetailInfo> ListDetail
        {
            get { return this._listDetail; }
            set { this._listDetail = value; }
        }

        public String UserId
        {
            get { return this._userId; }
            set { this._userId = value; }
        }

        public SaveLayoutINV0101U01Args() { }

        public SaveLayoutINV0101U01Args(List<INV0101U01GridMasterInfo> listMaster, List<INV0101U01GridDetailInfo> listDetail, String userId)
        {
            this._listMaster = listMaster;
            this._listDetail = listDetail;
            this._userId = userId;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.SaveLayoutINV0101U01Request();
        }
    }
}