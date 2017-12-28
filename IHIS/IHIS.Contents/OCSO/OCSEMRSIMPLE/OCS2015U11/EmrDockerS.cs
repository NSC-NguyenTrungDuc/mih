using System;
using System.Drawing;
using System.Windows.Forms;

namespace IHIS.OCSO
{
    using DevExpress.XtraBars.Docking;
    using global::EmrDocker;

    public partial class EmrDocketS : UserControl
    {

        //private EmrViewer ucView;
        //private EmrEditor ucEditor;

        private UcViewS ucView;
        private UcEditorS ucEditor;
        private GroupExpandForm groupExpandForm;
        private IMainScreen _mainScreen;
        public EmrDocketS(IMainScreen mainScreen)
        {
            InitializeComponent();
            //panelContainer1.Dock = DockingStyle.Fill;
            ucView = new UcViewS(mainScreen);
            ucEditor = new UcEditorS(mainScreen);
            groupExpandForm = new GroupExpandForm();
            //dockPanel1.Text = "EMR履歴ビューア";
            //dockPanel2.Text = "EMRエディタ";
            //dockPanel3.Text = "オーダーリスト";

            dockPanel1_Container.Controls.Add(ucView);
            ucView.Dock = DockStyle.Fill;
            ucView.Location = new Point(0, 0);
            ucView.Name = "ucView";
            //ucView.Size = new Size(752, 300);
            ucView.Size = new Size(762,280);

            /*dockPanel2_Container.Controls.Add(ucEditor);
            /*ucEditor.Dock = DockStyle.Fill;#1#
            ucEditor.Dock = DockStyle.Bottom;
            ucEditor.Location = new Point(0, 212);
            ucEditor.Name = "ucEditor";
            ucEditor.Size = new Size(742, 270);

            dockPanel2_Container.Controls.Add(groupExpandForm);
            /*ucEditor.Dock = DockStyle.Fill;#1#
            groupExpandForm.Dock = DockStyle.Top;
            groupExpandForm.Location = new Point(0, 0);
            groupExpandForm.Name = "groupExpandForm";
            groupExpandForm.Size = new Size(742, 210);*/

            /*this.splitContainerControl1.Panel2.Controls.Add(this.ucEditor);
            ucEditor.Location = new Point(0, 0);
            groupExpandForm.Dock = DockStyle.Bottom;

            this.splitContainerControl1.Panel1.Controls.Add(this.groupExpandForm);
            groupExpandForm.Location = new Point(0, 0);
            //groupExpandForm.Size = new Size(742, 210);
            groupExpandForm.Dock = DockStyle.Fill;*/

            pnlGroupExpand.Controls.Add(this.groupExpandForm);
            groupExpandForm.Dock = DockStyle.Fill;

            /*pnlUcEditor.Controls.Add(this.ucEditor);*/
            pnlUcEditorContent.Controls.Add(this.ucEditor);
            ucEditor.Dock = DockStyle.Fill;

            //dockPanel1.Width = 300;
            //dockPanel2.Width = 300;
            //dockPanel3.Width = 600;
            //dockPanel1.Dock = DockingStyle.Left;
            //dockPanel2.Dock = DockingStyle.Left;
            //dockPanel3.Dock = DockingStyle.Right;
            _mainScreen = mainScreen;
            //this.Editor.Viewer = this.Viewer;

            dockPanel1.Appearance.BorderColor = ColorTranslator.FromHtml("#BFDBFF");
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            int width = Size.Width / 2;
            dockPanel1.Size = dockPanel2.Size = new Size(width, Size.Height / 2);
            //dockPanel3.Size
        }

        private void EmrDocker_Resize(object sender, EventArgs e)
        {
            //dockPanel1_Container.Size = this.Size;
            //dockPanel1.Size = this.Size;
        }

        public UcViewS Viewer
        {
            get
            {
                return ucView;
            }
        }


        public UcEditorS Editor
        {
            get
            {
                return ucEditor;
            }
        }

        public GroupExpandForm GroupExpandForm
        {
            get { return groupExpandForm; }
        }

        public ControlContainer DockPanel3Container
        {
            get
            {
                return dockPanel3_Container;
            }
        }

        public void ActiveChildControl(string index)
        {
            switch (index)
            {
                case "1":
                    //this.panelContainer1.ActiveChild = this.dockPanel1;
                    break;
                case "2":
                    //this.panelContainer1.ActiveChild = this.dockPanel2;
                    break;
                case "3":
                    //this.panelContainer1.ActiveChild = this.dockPanel3;
                    break;
                default:
                    //this.panelContainer1.ActiveChild = this.dockPanel2;
                    break;
            }
        }

        //public RichEditControl RichEditControl
        //{
        //    get
        //    {
        //        return this.ucEditor.RichEditControl;
        //    }
        //}

    }
}
