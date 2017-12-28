using System;

namespace IHIS.CloudConnector.Contracts.Models.Phys
{
    [Serializable]
    public class PHY2001U04PrRehAddRehasinryouryouInfo
    {
        private String _sinryouryouGubun;

        public String SinryouryouGubun
        {
            get { return this._sinryouryouGubun; }
            set { this._sinryouryouGubun = value; }
        }

        public PHY2001U04PrRehAddRehasinryouryouInfo() { }

        public PHY2001U04PrRehAddRehasinryouryouInfo(String sinryouryouGubun)
        {
            this._sinryouryouGubun = sinryouryouGubun;
        }

    }
}