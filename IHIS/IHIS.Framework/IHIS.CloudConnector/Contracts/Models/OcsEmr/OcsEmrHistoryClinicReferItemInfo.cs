using System;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Models.OcsEmr
{
    [Serializable]
    public class OcsEmrHistoryClinicReferItemInfo
    {
        private String _hopsCode;
        private String _hopsName;
        private List<OcsEmrPatientReceptionHistoryListItemInfo> _lst = new List<OcsEmrPatientReceptionHistoryListItemInfo>();

        public String HopsCode
        {
            get { return this._hopsCode; }
            set { this._hopsCode = value; }
        }

        public String HopsName
        {
            get { return this._hopsName; }
            set { this._hopsName = value; }
        }

        public List<OcsEmrPatientReceptionHistoryListItemInfo> Lst
        {
            get { return this._lst; }
            set { this._lst = value; }
        }

        public OcsEmrHistoryClinicReferItemInfo() { }

        public OcsEmrHistoryClinicReferItemInfo(String hopsCode, String hopsName, List<OcsEmrPatientReceptionHistoryListItemInfo> lst)
        {
            this._hopsCode = hopsCode;
            this._hopsName = hopsName;
            this._lst = lst;
        }

    }
}