using System;

namespace IHIS.CloudConnector.Contracts.Models.Phys
{
    [Serializable]
    public class PHY2001U04LayNUR7001Info
    {
        private String _bpFrom;
        private String _bpTo;
        private String _pulse;
        private String _bodyHeat;

        public String BpFrom
        {
            get { return this._bpFrom; }
            set { this._bpFrom = value; }
        }

        public String BpTo
        {
            get { return this._bpTo; }
            set { this._bpTo = value; }
        }

        public String Pulse
        {
            get { return this._pulse; }
            set { this._pulse = value; }
        }

        public String BodyHeat
        {
            get { return this._bodyHeat; }
            set { this._bodyHeat = value; }
        }

        public PHY2001U04LayNUR7001Info() { }

        public PHY2001U04LayNUR7001Info(String bpFrom, String bpTo, String pulse, String bodyHeat)
        {
            this._bpFrom = bpFrom;
            this._bpTo = bpTo;
            this._pulse = pulse;
            this._bodyHeat = bodyHeat;
        }

    }
}