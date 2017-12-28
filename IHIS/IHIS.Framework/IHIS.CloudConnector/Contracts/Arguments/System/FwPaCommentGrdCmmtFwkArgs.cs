using System;
using IHIS.CloudConnector.Contracts.Models.System;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.System
{[Serializable]
    public class FwPaCommentGrdCmmtFwkArgs : IContractArgs
    {
    protected bool Equals(FwPaCommentGrdCmmtFwkArgs other)
    {
        return string.Equals(_bunho, other._bunho) && string.Equals(_cmmtGubun, other._cmmtGubun) && string.Equals(_jundalTable, other._jundalTable) && string.Equals(_jundalPart, other._jundalPart) && string.Equals(_fkocs, other._fkocs);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((FwPaCommentGrdCmmtFwkArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_bunho != null ? _bunho.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_cmmtGubun != null ? _cmmtGubun.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_jundalTable != null ? _jundalTable.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_jundalPart != null ? _jundalPart.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_fkocs != null ? _fkocs.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _bunho;
        private String _cmmtGubun;
        private String _jundalTable;
        private String _jundalPart;
        private String _fkocs;

        public String Bunho
        {
            get { return this._bunho; }
            set { this._bunho = value; }
        }

        public String CmmtGubun
        {
            get { return this._cmmtGubun; }
            set { this._cmmtGubun = value; }
        }

        public String JundalTable
        {
            get { return this._jundalTable; }
            set { this._jundalTable = value; }
        }

        public String JundalPart
        {
            get { return this._jundalPart; }
            set { this._jundalPart = value; }
        }

        public String Fkocs
        {
            get { return this._fkocs; }
            set { this._fkocs = value; }
        }

        public FwPaCommentGrdCmmtFwkArgs() { }

        public FwPaCommentGrdCmmtFwkArgs(String bunho, String cmmtGubun, String jundalTable, String jundalPart, String fkocs)
        {
            this._bunho = bunho;
            this._cmmtGubun = cmmtGubun;
            this._jundalTable = jundalTable;
            this._jundalPart = jundalPart;
            this._fkocs = fkocs;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.FwPaCommentGrdCmmtFwkRequest();
        }
    }
}