using System;
using IHIS.CloudConnector.Contracts.Models.Drgs;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Drgs
{
    public class DRGOCSCHKSaveGrdOcs0108Args : IContractArgs
    {
        private String _hangmogCode;
        private List<DRGOCSCHKgrdOCS0108Info> _listInfo = new List<DRGOCSCHKgrdOCS0108Info>();

        public String HangmogCode
        {
            get { return this._hangmogCode; }
            set { this._hangmogCode = value; }
        }

        public List<DRGOCSCHKgrdOCS0108Info> ListInfo
        {
            get { return this._listInfo; }
            set { this._listInfo = value; }
        }

        public DRGOCSCHKSaveGrdOcs0108Args() { }

        public DRGOCSCHKSaveGrdOcs0108Args(String hangmogCode, List<DRGOCSCHKgrdOCS0108Info> listInfo)
        {
            this._hangmogCode = hangmogCode;
            this._listInfo = listInfo;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.DRGOCSCHKSaveGrdOcs0108Request();
        }
    }
}