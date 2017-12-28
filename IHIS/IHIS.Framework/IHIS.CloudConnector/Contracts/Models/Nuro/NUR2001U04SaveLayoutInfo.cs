using System;

namespace IHIS.CloudConnector.Contracts.Models.Nuro
{
    [Serializable]
    public class NUR2001U04SaveLayoutInfo
    {
        private String _naewonYn;
        private String _arriveTime;
        private String _jubsuGubun;
        private String _pkout1001;

        public String NaewonYn
        {
            get { return this._naewonYn; }
            set { this._naewonYn = value; }
        }

        public String ArriveTime
        {
            get { return this._arriveTime; }
            set { this._arriveTime = value; }
        }

        public String JubsuGubun
        {
            get { return this._jubsuGubun; }
            set { this._jubsuGubun = value; }
        }

        public String Pkout1001
        {
            get { return this._pkout1001; }
            set { this._pkout1001 = value; }
        }

        public NUR2001U04SaveLayoutInfo() { }

        public NUR2001U04SaveLayoutInfo(String naewonYn, String arriveTime, String jubsuGubun, String pkout1001)
        {
            this._naewonYn = naewonYn;
            this._arriveTime = arriveTime;
            this._jubsuGubun = jubsuGubun;
            this._pkout1001 = pkout1001;
        }

    }
}