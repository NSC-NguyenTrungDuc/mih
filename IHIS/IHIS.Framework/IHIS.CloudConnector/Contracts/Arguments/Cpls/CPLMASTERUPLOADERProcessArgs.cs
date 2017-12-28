using System;
using IHIS.CloudConnector.Contracts.Models.Cpls;
using System.Collections.Generic;
using ProtoBuf;
using IHIS.CloudConnector.Messaging;

namespace IHIS.CloudConnector.Contracts.Arguments.Cpls
{
    public class CPLMASTERUPLOADERProcessArgs : IContractArgs
    {
        private byte[] _data;
        private DataType _type;

        public byte[] Data
        {
            get { return this._data; }
            set { this._data = value; }
        }

        public DataType Type
        {
            get { return this._type; }
            set { this._type = value; }
        }

        public CPLMASTERUPLOADERProcessArgs() { }

        public CPLMASTERUPLOADERProcessArgs(byte[] data, DataType type)
        {
            this._data = data;
            this._type = type;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.CPLMASTERUPLOADERProcessRequest();
        }
    }
}