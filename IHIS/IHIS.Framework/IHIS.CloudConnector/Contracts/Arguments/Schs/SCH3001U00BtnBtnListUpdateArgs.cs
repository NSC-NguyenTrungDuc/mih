using System;
using IHIS.CloudConnector.Contracts.Models.Schs;
using System.Collections.Generic;
using ProtoBuf;
using IHIS.CloudConnector.Contracts.Models.System;

namespace IHIS.CloudConnector.Contracts.Arguments.Schs
{[Serializable]
    public class SCH3001U00BtnBtnListUpdateArgs : IContractArgs
    {
    protected bool Equals(SCH3001U00BtnBtnListUpdateArgs other)
    {
        return Equals(_grdSch0001Info, other._grdSch0001Info) && Equals(_grdSch0002Info, other._grdSch0002Info) && Equals(_grdJukyongDateInfo, other._grdJukyongDateInfo) && Equals(_grdSch3000Info, other._grdSch3000Info) && Equals(_grdSch3100Info, other._grdSch3100Info) && Equals(_grdSch3101Info, other._grdSch3101Info) && string.Equals(_userId, other._userId) && Equals(_selectedYoil, other._selectedYoil) && string.Equals(_outHospCodeSlot, other._outHospCodeSlot);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((SCH3001U00BtnBtnListUpdateArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_grdSch0001Info != null ? _grdSch0001Info.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_grdSch0002Info != null ? _grdSch0002Info.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_grdJukyongDateInfo != null ? _grdJukyongDateInfo.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_grdSch3000Info != null ? _grdSch3000Info.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_grdSch3100Info != null ? _grdSch3100Info.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_grdSch3101Info != null ? _grdSch3101Info.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_userId != null ? _userId.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_selectedYoil != null ? _selectedYoil.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_outHospCodeSlot != null ? _outHospCodeSlot.GetHashCode() : 0);
            return hashCode;
        }
    }

    private List<SCH3001U00GrdSCH0001Info> _grdSch0001Info = new List<SCH3001U00GrdSCH0001Info>();
        private List<SCH3001U00GrdSCH0002Info> _grdSch0002Info = new List<SCH3001U00GrdSCH0002Info>();
        private List<SCH3001U00GrdJukyongDateInfo> _grdJukyongDateInfo = new List<SCH3001U00GrdJukyongDateInfo>();
        private List<SCH3001U00GrdSCH3000Info> _grdSch3000Info = new List<SCH3001U00GrdSCH3000Info>();
        private List<SCH3001U00GrdSCH3100Info> _grdSch3100Info = new List<SCH3001U00GrdSCH3100Info>();
        private List<SCH3001U00GrdSCH3101Info> _grdSch3101Info = new List<SCH3001U00GrdSCH3101Info>();
        private String _userId;
        private List<DataStringListItemInfo> _selectedYoil = new List<DataStringListItemInfo>();
        private String _outHospCodeSlot;

        public List<SCH3001U00GrdSCH0001Info> GrdSch0001Info
        {
            get { return this._grdSch0001Info; }
            set { this._grdSch0001Info = value; }
        }

        public List<SCH3001U00GrdSCH0002Info> GrdSch0002Info
        {
            get { return this._grdSch0002Info; }
            set { this._grdSch0002Info = value; }
        }

        public List<SCH3001U00GrdJukyongDateInfo> GrdJukyongDateInfo
        {
            get { return this._grdJukyongDateInfo; }
            set { this._grdJukyongDateInfo = value; }
        }

        public List<SCH3001U00GrdSCH3000Info> GrdSch3000Info
        {
            get { return this._grdSch3000Info; }
            set { this._grdSch3000Info = value; }
        }

        public List<SCH3001U00GrdSCH3100Info> GrdSch3100Info
        {
            get { return this._grdSch3100Info; }
            set { this._grdSch3100Info = value; }
        }

        public List<SCH3001U00GrdSCH3101Info> GrdSch3101Info
        {
            get { return this._grdSch3101Info; }
            set { this._grdSch3101Info = value; }
        }

        public String UserId
        {
            get { return this._userId; }
            set { this._userId = value; }
        }

        public List<DataStringListItemInfo> SelectedYoil
        {
            get { return this._selectedYoil; }
            set { this._selectedYoil = value; }
        }

        public String OutHospCodeSlot
        {
            get { return this._outHospCodeSlot; }
            set { this._outHospCodeSlot = value; }
        }

        public SCH3001U00BtnBtnListUpdateArgs() { }

        public SCH3001U00BtnBtnListUpdateArgs(List<SCH3001U00GrdSCH0001Info> grdSch0001Info, List<SCH3001U00GrdSCH0002Info> grdSch0002Info, List<SCH3001U00GrdJukyongDateInfo> grdJukyongDateInfo, List<SCH3001U00GrdSCH3000Info> grdSch3000Info, List<SCH3001U00GrdSCH3100Info> grdSch3100Info, List<SCH3001U00GrdSCH3101Info> grdSch3101Info, String userId, List<DataStringListItemInfo> selectedYoil, String outHospCodeSlot)
        {
            this._grdSch0001Info = grdSch0001Info;
            this._grdSch0002Info = grdSch0002Info;
            this._grdJukyongDateInfo = grdJukyongDateInfo;
            this._grdSch3000Info = grdSch3000Info;
            this._grdSch3100Info = grdSch3100Info;
            this._grdSch3101Info = grdSch3101Info;
            this._userId = userId;
            this._selectedYoil = selectedYoil;
            this._outHospCodeSlot = outHospCodeSlot;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.SCH3001U00BtnBtnListUpdateRequest();
        }
    }
}