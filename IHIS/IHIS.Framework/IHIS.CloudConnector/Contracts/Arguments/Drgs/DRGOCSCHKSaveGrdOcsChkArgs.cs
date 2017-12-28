using System;
using IHIS.CloudConnector.Contracts.Models.Drgs;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Drgs
{
    public class DRGOCSCHKSaveGrdOcsChkArgs : IContractArgs
    {
        private String _hangmogCode;
        private List<DRGOCSCHKGrdOcsChkFullInfo> _listInfo = new List<DRGOCSCHKGrdOcsChkFullInfo>();

        public String HangmogCode
        {
            get { return this._hangmogCode; }
            set { this._hangmogCode = value; }
        }

        public List<DRGOCSCHKGrdOcsChkFullInfo> ListInfo
        {
            get { return this._listInfo; }
            set { this._listInfo = value; }
        }

        public DRGOCSCHKSaveGrdOcsChkArgs() { }

        public DRGOCSCHKSaveGrdOcsChkArgs(String hangmogCode, List<DRGOCSCHKGrdOcsChkFullInfo> listInfo)
        {
            this._hangmogCode = hangmogCode;
            this._listInfo = listInfo;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.DRGOCSCHKSaveGrdOcsChkRequest();
        }
    }
}