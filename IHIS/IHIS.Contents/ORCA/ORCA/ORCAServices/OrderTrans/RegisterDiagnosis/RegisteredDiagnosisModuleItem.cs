using System;
using System.Collections.Generic;
using System.Text;

namespace IHIS.ORCA
{
    public class RegisteredDiagnosisModuleItem
    {
        private string _diagnosisCode = "";
        private string _diagnosisSystem = "";
        private DateTime? _diagnosisStartDate;
        private DateTime? _diagnosisEndDate;
        private string _diagnosisCategory = "";
        private string _mmlTableId = "";

        public string DiagnosisCode
        {
            get { return _diagnosisCode; }
            set { _diagnosisCode = value; }
        }

        public string DiagnosisSystem
        {
            get { return _diagnosisSystem; }
            set { _diagnosisSystem = value; }
        }

        public DateTime? DiagnosisStartDate
        {
            get { return _diagnosisStartDate; }
            set { _diagnosisStartDate = value; }
        }

        public DateTime? DiagnosisEndDate
        {
            get { return _diagnosisEndDate; }
            set { _diagnosisEndDate = value; }
        }

        public string DiagnosisCategory
        {
            get { return _diagnosisCategory; }
            set { _diagnosisCategory = value; }
        }

        public string MmlTableId
        {
            get { return _mmlTableId; }
            set { _mmlTableId = value; }
        }

        public RegisteredDiagnosisModuleItem()
        {
        }
    }
}
