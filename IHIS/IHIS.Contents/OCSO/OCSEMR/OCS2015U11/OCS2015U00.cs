using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace IHIS.OCSO
{
    using IHIS.Framework;
    using IHIS.OCSO.Meta;

    [ToolboxItem(false)]
    public partial class OCS2015U00 : XScreen
    {
        public OCS2015U00()
        {
            InitializeComponent();
            Size screenSize = this.Size;
            Size regionSize = ((MdiForm)this.Opener).ClientSize;
            int dWidth = regionSize.Width > (45 + screenSize.Width) ? regionSize.Width - (45 + screenSize.Width) : 0;
            int dHeight = regionSize.Height > (screenSize.Height + 120) ? regionSize.Height - (screenSize.Height + 120) : 0;
            this.Size += new Size(dWidth, dHeight);
        }

        private void OCS2015U00_Load(object sender, EventArgs e)
        {
            
        }

        private void btnENDOResult_Click(object sender, EventArgs e)
        {
            string emrXml;
            List<CustomMarkSchema> schema = emrDocker1.Editor.Save(out emrXml);
            emrDocker1.Viewer.LoadMeta(schema, emrXml);
        }
    }
}
