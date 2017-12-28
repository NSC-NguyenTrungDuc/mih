using System;
using IHIS.CloudConnector.Contracts.Models.Drgs;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Drgs
{
    public class DRG0201U00PrDrgUpdateChulgoArgs : IContractArgs
    {
        private String _jubsuDate;
        private String _drgBunho;
        private String _chulgoDate;
        private String _actUser;
        private String _chulgoBuseo;
        private String _wonyoiOrderYn;
        private String _actYn;
        private List<DRG0201U00InventoryInfo> _lst = new List<DRG0201U00InventoryInfo>();

        public String JubsuDate
        {
            get { return this._jubsuDate; }
            set { this._jubsuDate = value; }
        }

        public String DrgBunho
        {
            get { return this._drgBunho; }
            set { this._drgBunho = value; }
        }

        public String ChulgoDate
        {
            get { return this._chulgoDate; }
            set { this._chulgoDate = value; }
        }

        public String ActUser
        {
            get { return this._actUser; }
            set { this._actUser = value; }
        }

        public String ChulgoBuseo
        {
            get { return this._chulgoBuseo; }
            set { this._chulgoBuseo = value; }
        }

        public String WonyoiOrderYn
        {
            get { return this._wonyoiOrderYn; }
            set { this._wonyoiOrderYn = value; }
        }

        public String ActYn
        {
            get { return this._actYn; }
            set { this._actYn = value; }
        }

        public List<DRG0201U00InventoryInfo> Lst
        {
            get { return this._lst; }
            set { this._lst = value; }
        }

        public DRG0201U00PrDrgUpdateChulgoArgs() { }

        public DRG0201U00PrDrgUpdateChulgoArgs(String jubsuDate, String drgBunho, String chulgoDate, String actUser, String chulgoBuseo, String wonyoiOrderYn, String actYn, List<DRG0201U00InventoryInfo> lst)
        {
            this._jubsuDate = jubsuDate;
            this._drgBunho = drgBunho;
            this._chulgoDate = chulgoDate;
            this._actUser = actUser;
            this._chulgoBuseo = chulgoBuseo;
            this._wonyoiOrderYn = wonyoiOrderYn;
            this._actYn = actYn;
            this._lst = lst;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.DRG0201U00PrDrgUpdateChulgoRequest();
        }
    }
}