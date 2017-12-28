using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using IHIS.Framework;

namespace IHIS.TestControls
{
    public partial class TestXProgressBar : Form
    {
        public TestXProgressBar()
        {
            InitializeComponent();
        }

        private void xButton1_Click(object sender, EventArgs e)
        {
            // xProgressBar Init
            this.PgbBar.Visible = false;
            //
            this.PgbBar.Minimum = 0;
            this.PgbBar.Maximum = 0;
            this.PgbBar.Value = 0;
            //
            this.PgbBar.Text = "Init";
        }

        private void xButton2_Click(object sender, EventArgs e)
        {
            // xProgressBar Start
            this.PgbBar.Visible = true;
            //
            this.PgbBar.Minimum = Convert.ToInt32(this.MinPgbBar.Text.ToString());
            this.PgbBar.Maximum = Convert.ToInt32(this.MaxPgbBar.Text.ToString());
            //this.PgbBar.Value = 0;
            //
            this.PgbBar.Text = "Start";
        }

        private void xButton4_Click(object sender, EventArgs e)
        {
            // xProgressBar Add
            int pgbBarPer = 0;

            this.PgbBar.Visible = true;
            //
            //this.PgbBar.Minimum = Convert.ToInt32(this.MinPgbBar.Text.ToString());
            //this.PgbBar.Maximum = Convert.ToInt32(this.MaxPgbBar.Text.ToString());
            this.PgbBar.Value += Convert.ToInt32(this.AddPgbBar.Text.ToString());
            //
            //pgbBarPer = Convert.ToInt32(this.PgbBar.Value * 100 / this.PgbBar.Maximum);
            pgbBarPer = this.PgbBar.Value * 100 / this.PgbBar.Maximum;
            this.PgbBar.Text = this.MsgPgbBar.Text + pgbBarPer + "%";
        }

        private void xButton3_Click(object sender, EventArgs e)
        {
            // xProgressBar End
            this.PgbBar.Visible = false;
            //
            this.PgbBar.Minimum = 0;
            this.PgbBar.Maximum = 0;
            this.PgbBar.Value = 0;
            //
            this.PgbBar.Text = "End";
        }
    }
}