using System;
using System.Drawing;
using System.Windows.Forms;

namespace IHIS.OCSO
{
    using DevExpress.XtraBars.Docking;
    using global::EmrDocker;
    using System.ComponentModel;

    [ToolboxItem(false)]
    [Serializable]
    public partial class EmrDocket : UserControl
    {

        //private EmrViewer ucView;
        //private EmrEditor ucEditor;

        private UcView ucView;
        private UcEditor ucEditor;
        private IMainScreen _mainScreen;
        public EmrDocket(IMainScreen mainScreen)
        {
            InitializeComponent();
            //panelContainer1.Dock = DockingStyle.Fill;
            ucView = new UcView(mainScreen);
            ucEditor = new UcEditor(mainScreen);
            //dockPanel1.Text = "EMR履歴ビューア";
            //dockPanel2.Text = "EMRエディタ";
            //dockPanel3.Text = "オーダーリスト";

            dockPanel1_Container.Controls.Add(ucView);
            ucView.Dock = DockStyle.Fill;
            ucView.Location = new Point(0, 0);
            ucView.Name = "ucView";
            ucView.Size = new Size(742, 300);
            dockPanel2_Container.Controls.Add(ucEditor);
            ucEditor.Dock = DockStyle.Fill;
            ucEditor.Location = new Point(0, 0);
            ucEditor.Name = "ucEditor";
            ucEditor.Size = new Size(742, 300);
            //dockPanel1.Width = 300;
            //dockPanel2.Width = 300;
            //dockPanel3.Width = 600;
            //dockPanel1.Dock = DockingStyle.Left;
            //dockPanel2.Dock = DockingStyle.Left;
            //dockPanel3.Dock = DockingStyle.Right;
            _mainScreen = mainScreen;
            //this.Editor.Viewer = this.Viewer;
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

        public UcView Viewer
        {
            get
            {
                return ucView;
            }
        }

        public UcEditor Editor
        {
            get
            {
                return ucEditor;
            }
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
