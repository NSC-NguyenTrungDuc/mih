using System;
using IHIS.CloudConnector.Contracts.Models.Schs;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Schs
{[Serializable]
    public class SchsSCH0201U99GrdOrderListArgs : IContractArgs
    {
    protected bool Equals(SchsSCH0201U99GrdOrderListArgs other)
    {
        return string.Equals(_fBunho, other._fBunho) && string.Equals(_fFkocs, other._fFkocs) && string.Equals(_fReserStatus, other._fReserStatus) && string.Equals(_fFlag, other._fFlag) && string.Equals(_fReserGubun, other._fReserGubun) && string.Equals(_fReserPart, other._fReserPart) && string.Equals(_isMyClinnic, other._isMyClinnic);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((SchsSCH0201U99GrdOrderListArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_fBunho != null ? _fBunho.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_fFkocs != null ? _fFkocs.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_fReserStatus != null ? _fReserStatus.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_fFlag != null ? _fFlag.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_fReserGubun != null ? _fReserGubun.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_fReserPart != null ? _fReserPart.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_isMyClinnic != null ? _isMyClinnic.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _fBunho;
        private String _fFkocs;
        private String _fReserStatus;
        private String _fFlag;
        private String _fReserGubun;
        private String _fReserPart;
        private String _isMyClinnic;

        public String FBunho
        {
            get { return this._fBunho; }
            set { this._fBunho = value; }
        }

        public String FFkocs
        {
            get { return this._fFkocs; }
            set { this._fFkocs = value; }
        }

        public String FReserStatus
        {
            get { return this._fReserStatus; }
            set { this._fReserStatus = value; }
        }

        public String FFlag
        {
            get { return this._fFlag; }
            set { this._fFlag = value; }
        }

        public String FReserGubun
        {
            get { return this._fReserGubun; }
            set { this._fReserGubun = value; }
        }

        public String FReserPart
        {
            get { return this._fReserPart; }
            set { this._fReserPart = value; }
        }

        public String IsMyClinnic
        {
            get { return this._isMyClinnic; }
            set { this._isMyClinnic = value; }
        }

        public SchsSCH0201U99GrdOrderListArgs() { }

        public SchsSCH0201U99GrdOrderListArgs(String fBunho, String fFkocs, String fReserStatus, String fFlag, String fReserGubun, String fReserPart, String isMyClinnic)
        {
            this._fBunho = fBunho;
            this._fFkocs = fFkocs;
            this._fReserStatus = fReserStatus;
            this._fFlag = fFlag;
            this._fReserGubun = fReserGubun;
            this._fReserPart = fReserPart;
            this._isMyClinnic = isMyClinnic;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.SchsSCH0201U99GrdOrderListRequest();
        }
    }
}