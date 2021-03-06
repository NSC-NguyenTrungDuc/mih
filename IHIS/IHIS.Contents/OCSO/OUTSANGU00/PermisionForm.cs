using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using IHIS.OCSO;
using IHIS.OCSO.Properties;


namespace IHIS.OCSO
{
    public partial class PermisionForm : Form
    {
        private const int CP_NOCLOSE_BUTTON = 0x200;
        public delegate void PassControl(List<bool> sender);
        public PassControl passControl;
       
        public PermisionForm(bool doctor, bool other, bool related, bool patient)
        {
            InitializeComponent();
            SetTickForCheckBox(doctor, other, related, patient);
            Addmultilanguage();
            
        }

        private void Addmultilanguage()
        {
            //if ( IHIS.Framework.NetInfo.Language == IHIS.Framework.LangMode.Jr)
            //{
            //    lbxDoctor.Text = "医師";
            //    lbxOther.Text = "他医院の医師";
            //    lbxRelated.Text = "関係のある医療機関";
            //    lbxPatient.Text = "患者";
            //}
            //else if (IHIS.Framework.NetInfo.Language == IHIS.Framework.LangMode.Vi)
            //{
            //    lbxDoctor.Text = "Bác sĩ khác";
            //    lbxOther.Text = "Bác sĩ của bệnh viện khác";
            //    lbxRelated.Text = "Các tổ chức liên quan";
            //    lbxPatient.Text = "Bệnh nhân";
            //}
            lbxDoctor.Text = Resources.PERMISION_DOCTOR;
            lbxOther.Text = Resources.PERMISION_OTHERCLINIC;
            lbxRelated.Text = Resources.PERMISION_RELATED;
            lbxPatient.Text = Resources.PERMISION_PATIENT;
        }

        private void SetTickForCheckBox(bool doctor, bool other, bool related, bool patient)
        {
            if (doctor == true) cbxDoctor.Checked = true;
            if (other == true) cbxOther.Checked = true;
            if (related == true) cbxRelated.Checked = true;
            if (patient == true) cbxPatient.Checked = true;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            bool doctor = cbxDoctor.Checked;
            bool other = cbxOther.Checked;
            bool related = cbxRelated.Checked;
            bool patient = cbxPatient.Checked;
            
            if (passControl != null)
            {
                List<bool> item = new List<bool>();
                item.Add(doctor);
                item.Add(other);
                item.Add(related);
                item.Add(patient);

                passControl(item);
            }

            this.Close();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

            
    }
}