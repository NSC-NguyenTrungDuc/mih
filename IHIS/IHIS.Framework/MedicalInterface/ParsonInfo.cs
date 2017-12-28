using System;
using System.Collections.Generic;

using System.Text;

namespace MedicalInterface {
    public class ParsonInfo {
        private string _parsonalId;
        private string _kanjiFamilyName;
        private string _kanjiGivenName;
        private string _kanaFamilyName;
        private string _kanaGivenName;
        private string _departmentCode;
        private string _professionCode;
        private string _fullName;

        public string FullName
        {
            get { return _fullName; }
            set { _fullName = value; }
        }

        public string ParsonalId
        {
            get { return _parsonalId; }
            set { _parsonalId = value; }
        }

        public string KanjiFamilyName
        {
            get { return _kanjiFamilyName; }
            set { _kanjiFamilyName = value; }
        }

        public string KanjiGivenName
        {
            get { return _kanjiGivenName; }
            set { _kanjiGivenName = value; }
        }

        public string KanaFamilyName
        {
            get { return _kanaFamilyName; }
            set { _kanaFamilyName = value; }
        }

        public string KanaGivenName
        {
            get { return _kanaGivenName; }
            set { _kanaGivenName = value; }
        }

        public string DepartmentCode
        {
            get { return _departmentCode; }
            set { _departmentCode = value; }
        }

        public string ProfessionCode
        {
            get { return _professionCode; }
            set { _professionCode = value; }
        }
    }
}
