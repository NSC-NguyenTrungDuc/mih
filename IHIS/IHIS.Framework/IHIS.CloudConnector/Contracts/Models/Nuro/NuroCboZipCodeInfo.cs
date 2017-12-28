using System;
using System.Collections.Generic;
using System.Text;

namespace IHIS.CloudConnector.Contracts.Models.Nuro
{
    [Serializable]
    public class NuroCboZipCodeInfo
    {
        private string _zipName;

        public NuroCboZipCodeInfo()
        {
        }

        public NuroCboZipCodeInfo(string zipName)
        {
            _zipName = zipName;
        }

        public string ZipName
        {
            get { return _zipName; }
            set { _zipName = value; }
        }
    }
}
