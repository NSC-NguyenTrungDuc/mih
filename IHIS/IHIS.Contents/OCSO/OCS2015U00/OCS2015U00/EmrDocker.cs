using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace IHIS.OCSO
{
    using DevExpress.XtraBars.Docking;

    public partial class EmrDocker : UserControl
    {
        public EmrDocker()
        {
            InitializeComponent();
            panelContainer1.Dock = DockingStyle.Fill;
        }

        private void EmrDocker_Resize(object sender, EventArgs e)
        {
            dockPanel1_Container.Size = this.Size;
            dockPanel1.Size = this.Size;
        }

        public EmrViewer Viewer
        {
            get
            {
                return emrViewer1;
            }
        }

        public EmrEditor Editor
        {
            get
            {
                return emrEditor1;
            }
        }
    }
}
