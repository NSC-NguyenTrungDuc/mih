using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    public class NUR2001U04SavebtnActionArgs : IContractArgs
    {
        private String _userId;
        private String _hospCode;
        private List<NUR2001U04SaveLayoutInfo> _saveLayoutItem = new List<NUR2001U04SaveLayoutInfo>();

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

        public List<NUR2001U04SaveLayoutInfo> SaveLayoutItem
        {
            get { return this._saveLayoutItem; }
            set { this._saveLayoutItem = value; }
        }

        public NUR2001U04SavebtnActionArgs() { }

        public NUR2001U04SavebtnActionArgs(String userId, String hospCode, List<NUR2001U04SaveLayoutInfo> saveLayoutItem)
        {
            this._userId = userId;
            this._hospCode = hospCode;
            this._saveLayoutItem = saveLayoutItem;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.NUR2001U04SavebtnActionRequest();
        }
    }
}