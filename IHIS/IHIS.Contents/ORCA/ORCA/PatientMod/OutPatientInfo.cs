using System;
using System.Collections.Generic;
using System.Text;

namespace ORCA
{
    /// <summary>
    /// OUTPUT patient info from ORCA
    /// </summary>
    public class OutPatientInfo
    {
        private string bunho = "";
        private string suname = "";
        private string suname2 = "";
        private string address1 = "";
        private string birth = "";
        private string sex = "";
        private string tel = "";

        public string Bunho
        {
            get { return bunho; }
            set { bunho = value; }
        }

        public string Suname
        {
            get { return suname; }
            set { suname = value; }
        }

        public string Suname2
        {
            get { return suname2; }
            set { suname2 = value; }
        }

        public string Address1
        {
            get { return address1; }
            set { address1 = value; }
        }

        public string Birth
        {
            get { return birth; }
            set { birth = value; }
        }

        public string Sex
        {
            get { return sex; }
            set { sex = value; }
        }

        public string Tel
        {
            get { return tel; }
            set { tel = value; }
        }

        public OutPatientInfo()
        { }
    }
}
