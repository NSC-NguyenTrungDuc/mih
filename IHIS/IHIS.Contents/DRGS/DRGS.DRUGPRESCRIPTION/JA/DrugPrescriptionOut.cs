using System;
using System.Collections.Generic;
using System.Text;

namespace IHIS.DRGS
{
    public class DrugPrescriptionOut : DrugPrescriptionBase
    {
        private string _examinationDate = "";
        private string _gigamDate = "";

        public string GigamDate
        {
            get { return _gigamDate; }
            set { _gigamDate = value; }
        }


        public string ExaminationDate
        {
            get { return _examinationDate; }
            set { _examinationDate = value; }
        }
        public DrugPrescriptionOut()
        {

        }
    }
}
