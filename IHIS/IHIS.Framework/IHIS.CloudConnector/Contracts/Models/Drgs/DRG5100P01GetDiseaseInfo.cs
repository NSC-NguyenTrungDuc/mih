using System;

namespace IHIS.CloudConnector.Contracts.Models.Drgs
{
    public class DRG5100P01GetDiseaseInfo
    {
        private String _jusangYn;
        private String _mainDisease;
        private String _extraDisease;

        public String JusangYn
        {
            get { return this._jusangYn; }
            set { this._jusangYn = value; }
        }

        public String MainDisease
        {
            get { return this._mainDisease; }
            set { this._mainDisease = value; }
        }

        public String ExtraDisease
        {
            get { return this._extraDisease; }
            set { this._extraDisease = value; }
        }

        public DRG5100P01GetDiseaseInfo() { }

        public DRG5100P01GetDiseaseInfo(String jusangYn, String mainDisease, String extraDisease)
        {
            this._jusangYn = jusangYn;
            this._mainDisease = mainDisease;
            this._extraDisease = extraDisease;
        }

    }
}