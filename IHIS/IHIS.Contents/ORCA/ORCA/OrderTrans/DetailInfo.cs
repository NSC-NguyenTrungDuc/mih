using System;
using System.Collections.Generic;
using System.Text;

namespace ORCA
{
    public class DetailInfo
    {
        private ClaimModuleItem _claimModuleItem;
        private HealthInsuranceModuleItem _hiModuleItem;
        private List<RegisteredDiagnosisModuleItem> _rdModuleItem;

        public ClaimModuleItem ClaimModuleItem
        {
            get { return _claimModuleItem; }
            set { _claimModuleItem = value; }
        }

        public HealthInsuranceModuleItem HiModuleItem
        {
            get { return _hiModuleItem; }
            set { _hiModuleItem = value; }
        }

        public List<RegisteredDiagnosisModuleItem> RdModuleItem
        {
            get { return _rdModuleItem; }
            set { _rdModuleItem = value; }
        }

        // ================================================================
        // TODO other modules
        // ================================================================

        public DetailInfo()
        { }
    }
}
