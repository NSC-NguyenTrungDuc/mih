using System;
using System.Collections.Generic;
using System.Text;

namespace IHIS.CloudConnector.Contracts.Models.System
{
    [Serializable]
    public class DetailPaInfoFormGridInsureInfo
    {
        private String _startDate;
        private String _typeName;
        private String _endDate;
        private String _johapName;
        private String _percentage;
        private String _percentageNo;
        private String _lastCheckDate;

        public String StartDate
        {
            get { return this._startDate; }
            set { this._startDate = value; }
        }

        public String TypeName
        {
            get { return this._typeName; }
            set { this._typeName = value; }
        }

        public String EndDate
        {
            get { return this._endDate; }
            set { this._endDate = value; }
        }

        public String JohapName
        {
            get { return this._johapName; }
            set { this._johapName = value; }
        }

        public String Percentage
        {
            get { return this._percentage; }
            set { this._percentage = value; }
        }

        public String PercentageNo
        {
            get { return this._percentageNo; }
            set { this._percentageNo = value; }
        }

        public String LastCheckDate
        {
            get { return this._lastCheckDate; }
            set { this._lastCheckDate = value; }
        }

        public DetailPaInfoFormGridInsureInfo() { }

        public DetailPaInfoFormGridInsureInfo(String startDate, String typeName, String endDate, String johapName, String percentage, String percentageNo, String lastCheckDate)
        {
            this._startDate = startDate;
            this._typeName = typeName;
            this._endDate = endDate;
            this._johapName = johapName;
            this._percentage = percentage;
            this._percentageNo = percentageNo;
            this._lastCheckDate = lastCheckDate;
        }
    }

}
