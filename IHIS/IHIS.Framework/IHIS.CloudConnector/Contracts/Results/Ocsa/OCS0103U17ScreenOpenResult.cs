using System;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Results.Ocs.Lib;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    public class OCS0103U17ScreenOpenResult : AbstractContractResult
    {
        private OCS0103U12ScreenOpenResult _scrOpenResItem;
        private OCS0103U12InitializeScreenResult _initScreenResItem;
        private OCS0103U12MakeSangyongTabResult _sangyongTabResItem;
        private OCS0103U12GrdSangyongOrderResult _sangyongOrderResItem;
        private OCS0103U17LayHangwiGubunResult _hangwiGubunResItem;
        private OCS0103U17MakeJaeryoGubunTabResult _jaeryoGubunResItem;
        private GetNextGroupSerResult _groupserResItem;
        private OCS0103U17LoadHangwiOrder3Result _hangwiOrderResItem;

        public OCS0103U12ScreenOpenResult ScrOpenResItem
        {
            get { return this._scrOpenResItem; }
            set { this._scrOpenResItem = value; }
        }

        public OCS0103U12InitializeScreenResult InitScreenResItem
        {
            get { return this._initScreenResItem; }
            set { this._initScreenResItem = value; }
        }

        public OCS0103U12MakeSangyongTabResult SangyongTabResItem
        {
            get { return this._sangyongTabResItem; }
            set { this._sangyongTabResItem = value; }
        }

        public OCS0103U12GrdSangyongOrderResult SangyongOrderResItem
        {
            get { return this._sangyongOrderResItem; }
            set { this._sangyongOrderResItem = value; }
        }

        public OCS0103U17LayHangwiGubunResult HangwiGubunResItem
        {
            get { return this._hangwiGubunResItem; }
            set { this._hangwiGubunResItem = value; }
        }

        public OCS0103U17MakeJaeryoGubunTabResult JaeryoGubunResItem
        {
            get { return this._jaeryoGubunResItem; }
            set { this._jaeryoGubunResItem = value; }
        }

        public GetNextGroupSerResult GroupserResItem
        {
            get { return this._groupserResItem; }
            set { this._groupserResItem = value; }
        }

        public OCS0103U17LoadHangwiOrder3Result HangwiOrderResItem
        {
            get { return this._hangwiOrderResItem; }
            set { this._hangwiOrderResItem = value; }
        }

        public OCS0103U17ScreenOpenResult() { }

    }
}