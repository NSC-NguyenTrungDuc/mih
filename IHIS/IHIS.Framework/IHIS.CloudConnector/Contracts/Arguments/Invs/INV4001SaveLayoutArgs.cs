using System;
using IHIS.CloudConnector.Contracts.Models.Invs;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Invs
{
    public class INV4001SaveLayoutArgs : IContractArgs
    {
        private List<INV4001U00Grd4001Info> _inv4001 = new List<INV4001U00Grd4001Info>();
        private List<INV4001U00Grd4002Info> _inv4002 = new List<INV4001U00Grd4002Info>();

        public List<INV4001U00Grd4001Info> Inv4001
        {
            get { return this._inv4001; }
            set { this._inv4001 = value; }
        }

        public List<INV4001U00Grd4002Info> Inv4002
        {
            get { return this._inv4002; }
            set { this._inv4002 = value; }
        }

        public INV4001SaveLayoutArgs() { }

        public INV4001SaveLayoutArgs(List<INV4001U00Grd4001Info> inv4001, List<INV4001U00Grd4002Info> inv4002)
        {
            this._inv4001 = inv4001;
            this._inv4002 = inv4002;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.INV4001SaveLayoutRequest();
        }
    }
}