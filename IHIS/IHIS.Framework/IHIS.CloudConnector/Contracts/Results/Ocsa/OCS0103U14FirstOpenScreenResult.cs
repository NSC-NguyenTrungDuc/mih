using System;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    public class OCS0103U14FirstOpenScreenResult : AbstractContractResult
    {
        private OCS0103U14FormLoadResult _formLoadRes;
        private OCS0103U13GrdSangyongOrderListResult _sangyongRes;
        private OCS0103U14LaySlipCodeTreeResult _laySlipcodeRes;
        private OCS0103U14GrdSlipHangmogResult _grdSliphangmogRes;

        public OCS0103U14FormLoadResult FormLoadRes
        {
            get { return this._formLoadRes; }
            set { this._formLoadRes = value; }
        }

        public OCS0103U13GrdSangyongOrderListResult SangyongRes
        {
            get { return this._sangyongRes; }
            set { this._sangyongRes = value; }
        }

        public OCS0103U14LaySlipCodeTreeResult LaySlipcodeRes
        {
            get { return this._laySlipcodeRes; }
            set { this._laySlipcodeRes = value; }
        }

        public OCS0103U14GrdSlipHangmogResult GrdSliphangmogRes
        {
            get { return this._grdSliphangmogRes; }
            set { this._grdSliphangmogRes = value; }
        }

        public OCS0103U14FirstOpenScreenResult() { }

    }
}