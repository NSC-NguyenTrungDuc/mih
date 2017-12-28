using System;

namespace IHIS.CloudConnector.Contracts.Models.Nuri
{
    [Serializable]
    public class NuriNUR7001U00MeasurePhysicalConditionListItemInfo
    {
        private String _bunho;
        private String _measureDate;
        private String _seq;
        private String _height;
        private String _weight;
        private String _bpFrom;
        private String _bpTo;
        private String _bodyHeat;
        private String _pulse;
        private String _suname;
        private String _spo2;
        private String _measureTime;
        private String _breath;
        private String _updId;
        private String _rowState;

        public String Bunho
        {
            get { return this._bunho; }
            set { this._bunho = value; }
        }

        public String MeasureDate
        {
            get { return this._measureDate; }
            set { this._measureDate = value; }
        }

        public String Seq
        {
            get { return this._seq; }
            set { this._seq = value; }
        }

        public String Height
        {
            get { return this._height; }
            set { this._height = value; }
        }

        public String Weight
        {
            get { return this._weight; }
            set { this._weight = value; }
        }

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

        public String BodyHeat
        {
            get { return this._bodyHeat; }
            set { this._bodyHeat = value; }
        }

        public String Pulse
        {
            get { return this._pulse; }
            set { this._pulse = value; }
        }

        public String Suname
        {
            get { return this._suname; }
            set { this._suname = value; }
        }

        public String Spo2
        {
            get { return this._spo2; }
            set { this._spo2 = value; }
        }

        public String MeasureTime
        {
            get { return this._measureTime; }
            set { this._measureTime = value; }
        }

        public String Breath
        {
            get { return this._breath; }
            set { this._breath = value; }
        }

        public String UpdId
        {
            get { return this._updId; }
            set { this._updId = value; }
        }

        public String RowState
        {
            get { return this._rowState; }
            set { this._rowState = value; }
        }

        public NuriNUR7001U00MeasurePhysicalConditionListItemInfo() { }

        public NuriNUR7001U00MeasurePhysicalConditionListItemInfo(String bunho, String measureDate, String seq, String height, String weight, String bpFrom, String bpTo, String bodyHeat, String pulse, String suname, String spo2, String measureTime, String breath, String updId, String rowState)
        {
            this._bunho = bunho;
            this._measureDate = measureDate;
            this._seq = seq;
            this._height = height;
            this._weight = weight;
            this._bpFrom = bpFrom;
            this._bpTo = bpTo;
            this._bodyHeat = bodyHeat;
            this._pulse = pulse;
            this._suname = suname;
            this._spo2 = spo2;
            this._measureTime = measureTime;
            this._breath = breath;
            this._updId = updId;
            this._rowState = rowState;
        }

    }
}