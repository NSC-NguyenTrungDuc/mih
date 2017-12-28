using System;

namespace EmrDocker.Models
{
    public class VnDiseasePrintInfo
    {
        private String _diseaseCode;
        private String _diseaseName;

        public string DiseaseCode
        {
            get { return _diseaseCode; }
            set { _diseaseCode = value; }
        }

        public string DiseaseName
        {
            get { return _diseaseName; }
            set { _diseaseName = value; }
        }

        public VnDiseasePrintInfo()
        {
        }

        public VnDiseasePrintInfo(string diseaseCode, string diseaseName)
        {
            _diseaseCode = diseaseCode;
            _diseaseName = diseaseName;
        }
    }
}