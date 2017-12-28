using System;
using IHIS.CloudConnector.Contracts.Models.Bass;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Bass
{
    public class SaveGrdBas0260U01Args : IContractArgs
    {
        private List<LoadGrdBAS0260U01Info> _listInfo = new List<LoadGrdBAS0260U01Info>();

        public List<LoadGrdBAS0260U01Info> ListInfo
        {
            get { return this._listInfo; }
            set { this._listInfo = value; }
        }

        public SaveGrdBas0260U01Args() { }

        public SaveGrdBas0260U01Args(List<LoadGrdBAS0260U01Info> listInfo)
        {
            this._listInfo = listInfo;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.SaveGrdBas0260U01Request();
        }
    }
}