using System;
using IHIS.CloudConnector.Contracts.Models.Adma;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Adma
{
    public class ADM108USaveLayoutArgs : IContractArgs
    {
        private String _userId;
        private String _hospCode;
        private List<ADM108UGrdListItemInfo> _grdListItemInfo = new List<ADM108UGrdListItemInfo>();

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

        public List<ADM108UGrdListItemInfo> GrdListItemInfo
        {
            get { return this._grdListItemInfo; }
            set { this._grdListItemInfo = value; }
        }

        public ADM108USaveLayoutArgs() { }

        public ADM108USaveLayoutArgs(String userId, String hospCode, List<ADM108UGrdListItemInfo> grdListItemInfo)
        {
            this._userId = userId;
            this._hospCode = hospCode;
            this._grdListItemInfo = grdListItemInfo;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.ADM108USaveLayoutRequest();
        }
    }
}