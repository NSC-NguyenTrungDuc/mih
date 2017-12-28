using System;
using IHIS.CloudConnector.Contracts.Models.Invs;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Invs
{
    public class INV4001U00Grd4001Result : AbstractContractResult
    {
        private List<INV4001U00Grd4001Info> _lst = new List<INV4001U00Grd4001Info>();

        public List<INV4001U00Grd4001Info> Lst
        {
            get { return this._lst; }
            set { this._lst = value; }
        }

        public INV4001U00Grd4001Result() { }

    }
}