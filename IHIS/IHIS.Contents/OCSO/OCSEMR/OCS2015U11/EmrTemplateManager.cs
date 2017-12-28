using System;
using System.Collections.Generic;
using System.ComponentModel;
//using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using RtfManager;

namespace IHIS.OCSO
{
    public partial class EmrTemplateManager : UserControl
    {
        public EmrTemplateManager()
        {
            InitializeComponent();
            this.GenerateTemplate();
        }

        public void GenerateTemplate()
        {
            try
            {
                //Create document by specifying paper size and orientation, 
                // and default language.
                RtfDocument doc = new RtfDocument(RtfManager.PaperSize.A4, PaperOrientation.Portrait, Lcid.English);
                // Create fonts and colors for later use
                FontDescriptor times = doc.createFont("Times New Roman");
                FontDescriptor courier = doc.createFont("Courier New");
                ColorDescriptor red = doc.createColor(new Color("ff0000"));
                ColorDescriptor blue = doc.createColor(new Color(0, 0, 255));

                RtfTable table;
                RtfParagraph par;
                RtfImage img;
                RtfCharFormat fmt;

                par = doc.addParagraph();
                par.DefaultCharFormat.Font = times;
                par.setText("Demo2: Character Formatting");
                this.richEditControl.RtfText = doc.render();
            }
            catch (Exception ex)
            {
                
            }
        }
    }
}
