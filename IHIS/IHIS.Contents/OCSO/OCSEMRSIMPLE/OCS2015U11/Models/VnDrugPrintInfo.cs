using System;

namespace EmrDocker.Models
{
    public class VnDrugPrintInfo
    {
        private String _stt;
        private String _drugName;
        private String _drugUnit;
        private String _quantity;
        private String _method;

        public string Stt
        {
            get { return _stt; }
            set { _stt = value; }
        }

        public string DrugName
        {
            get { return _drugName; }
            set { _drugName = value; }
        }

        public string DrugUnit
        {
            get { return _drugUnit; }
            set { _drugUnit = value; }
        }

        public string Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }

        public string Method
        {
            get { return _method; }
            set { _method = value; }
        }

        public VnDrugPrintInfo()
        {
        }

        public VnDrugPrintInfo(string stt, string drugName, string drugUnit, string quantity, string method)
        {
            _stt = stt;
            _drugName = drugName;
            _drugUnit = drugUnit;
            _quantity = quantity;
            _method = method;
        }
    }
}