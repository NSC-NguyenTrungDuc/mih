using System;
using IHIS.CloudConnector.Contracts.Models.Cpls;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Cpls
{
    public class CPLMASTERUPLOADERProcessUploadIFArgs : IContractArgs
    {
        private byte[] _data;

        public byte[] Data
        {
            get { return this._data; }
            set { this._data = value; }
        }

        public CPLMASTERUPLOADERProcessUploadIFArgs() { }

        public CPLMASTERUPLOADERProcessUploadIFArgs(byte[] data)
        {
            this._data = data;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.CPLMASTERUPLOADERProcessUploadIFRequest();
        }
    }
}