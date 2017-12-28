using System;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{
    public class OCS0103U14FirstOpenScreenArgs : IContractArgs
    {
        private OCS0103U14FormLoadArgs _formLoadRq = new OCS0103U14FormLoadArgs();
        private OCS0103U13GrdSangyongOrderListArgs _sangyongRq = new OCS0103U13GrdSangyongOrderListArgs();
        private OCS0103U14LaySlipCodeTreeArgs _laySlipcodeRq = new OCS0103U14LaySlipCodeTreeArgs();
        private OCS0103U14GrdSlipHangmogArgs _grdSliphangmogRq = new OCS0103U14GrdSlipHangmogArgs();

        public OCS0103U14FormLoadArgs FormLoadRq
        {
            get { return this._formLoadRq; }
            set { this._formLoadRq = value; }
        }

        public OCS0103U13GrdSangyongOrderListArgs SangyongRq
        {
            get { return this._sangyongRq; }
            set { this._sangyongRq = value; }
        }

        public OCS0103U14LaySlipCodeTreeArgs LaySlipcodeRq
        {
            get { return this._laySlipcodeRq; }
            set { this._laySlipcodeRq = value; }
        }

        public OCS0103U14GrdSlipHangmogArgs GrdSliphangmogRq
        {
            get { return this._grdSliphangmogRq; }
            set { this._grdSliphangmogRq = value; }
        }

        public OCS0103U14FirstOpenScreenArgs() { }

        public OCS0103U14FirstOpenScreenArgs(OCS0103U14FormLoadArgs formLoadRq, OCS0103U13GrdSangyongOrderListArgs sangyongRq, OCS0103U14LaySlipCodeTreeArgs laySlipcodeRq, OCS0103U14GrdSlipHangmogArgs grdSliphangmogRq)
        {
            this._formLoadRq = formLoadRq;
            this._sangyongRq = sangyongRq;
            this._laySlipcodeRq = laySlipcodeRq;
            this._grdSliphangmogRq = grdSliphangmogRq;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OCS0103U14FirstOpenScreenRequest();
        }
    }
}