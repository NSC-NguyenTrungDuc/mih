using System;
using IHIS.CloudConnector.Contracts.Models.System;

namespace IHIS.CloudConnector.Contracts.Models.OcsEmr
{
    public class OCS2015U31LoadGridDepartAndDoctorInfo
    {
        private ComboListItemInfo _departInfo;
        private ComboListItemInfo _doctorInfo;

        public ComboListItemInfo DepartInfo
        {
            get { return this._departInfo; }
            set { this._departInfo = value; }
        }

        public ComboListItemInfo DoctorInfo
        {
            get { return this._doctorInfo; }
            set { this._doctorInfo = value; }
        }

        public OCS2015U31LoadGridDepartAndDoctorInfo() { }

        public OCS2015U31LoadGridDepartAndDoctorInfo(ComboListItemInfo departInfo, ComboListItemInfo doctorInfo)
        {
            this._departInfo = departInfo;
            this._doctorInfo = doctorInfo;
        }

    }
}