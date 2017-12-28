using System;

namespace IHIS.CloudConnector.Contracts.Models.Nuro
{
    public class NUR2016U02ListPkocsInfo
    {
        private String _pkocs;

        public String Pkocs
        {
            get { return this._pkocs; }
            set { this._pkocs = value; }
        }

        public NUR2016U02ListPkocsInfo() { }

        public NUR2016U02ListPkocsInfo(String pkocs)
        {
            this._pkocs = pkocs;
        }

    }
}