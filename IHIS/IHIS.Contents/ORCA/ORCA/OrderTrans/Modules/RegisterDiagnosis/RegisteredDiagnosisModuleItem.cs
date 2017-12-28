using System;
using System.Collections.Generic;
using System.Text;

namespace ORCA
{
    public class RegisteredDiagnosisModuleItem
    {
        private string _diagnosisCode = "";
        private string _diagnosisSystem = "";
        private DateTime? _diagnosisStartDate;
        private DateTime? _diagnosisEndDate;
        private DateTime? _encounterDate;
        private string _diagnosisCategory = "";
        private string _mmlTableId = "";
        private string _jusangYn = "";

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

        public DateTime? EncounterDate
        {
            get { return _encounterDate; }
            set { _encounterDate = value; }
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

        public string JusangYn
        {
            get { return _jusangYn; }
            set { _jusangYn = value; }
        }

        public RegisteredDiagnosisModuleItem()
        {
        }
    }
}
