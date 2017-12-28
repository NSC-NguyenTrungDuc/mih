using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Arguments.Adma;
using IHIS.CloudConnector.Contracts.Results.Adma;
using IHIS.CloudConnector.Contracts.Results;

namespace IHIS.Framework
{
    /// <summary>
    /// XHospBox
    /// 2015.06.19 Added and assembled by AnhNV
    /// </summary>
    [DefaultProperty("BoxType")]
    public class XHospBox : UserControl
    {
        #region Auto generated code

        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XHospBox));
            this.lbHospCode = new System.Windows.Forms.Label();
            this.dbxHospName = new IHIS.Framework.XDisplayBox();
            this.xDisplayBox1 = new IHIS.Framework.XDisplayBox();
            this.txtHospCode = new IHIS.Framework.XTextBox();
            this.btnFind = new IHIS.Framework.XButton();
            this.SuspendLayout();
            // 
            // lbHospCode
            // 
            this.lbHospCode.AccessibleDescription = null;
            this.lbHospCode.AccessibleName = null;
            resources.ApplyResources(this.lbHospCode, "lbHospCode");
            this.lbHospCode.Font = null;
            this.lbHospCode.Name = "lbHospCode";
            // 
            // dbxHospName
            // 
            this.dbxHospName.AccessibleDescription = null;
            this.dbxHospName.AccessibleName = null;
            resources.ApplyResources(this.dbxHospName, "dbxHospName");
            this.dbxHospName.Font = null;
            this.dbxHospName.Image = null;
            this.dbxHospName.Name = "dbxHospName";
            // 
            // xDisplayBox1
            // 
            this.xDisplayBox1.AccessibleDescription = null;
            this.xDisplayBox1.AccessibleName = null;
            resources.ApplyResources(this.xDisplayBox1, "xDisplayBox1");
            this.xDisplayBox1.Image = null;
            this.xDisplayBox1.Name = "xDisplayBox1";
            // 
            // txtHospCode
            // 
            this.txtHospCode.AccessibleDescription = null;
            this.txtHospCode.AccessibleName = null;
            resources.ApplyResources(this.txtHospCode, "txtHospCode");
            this.txtHospCode.BackgroundImage = null;
            this.txtHospCode.Font = null;
            this.txtHospCode.Name = "txtHospCode";
            this.txtHospCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtHospCode_KeyDown);
            this.txtHospCode.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.txtHospCode_DataValidating);
            // 
            // btnFind
            // 
            this.btnFind.AccessibleDescription = null;
            this.btnFind.AccessibleName = null;
            resources.ApplyResources(this.btnFind, "btnFind");
            this.btnFind.BackgroundImage = null;
            this.btnFind.Font = null;
            this.btnFind.Image = ((System.Drawing.Image)(resources.GetObject("btnFind.Image")));
            this.btnFind.Name = "btnFind";
            this.btnFind.Scheme = IHIS.Framework.XButtonSchemes.SkyBlue;
            this.btnFind.TabStop = false;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // XHospBox
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Controls.Add(this.dbxHospName);
            this.Controls.Add(this.xDisplayBox1);
            this.Controls.Add(this.txtHospCode);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.lbHospCode);
            this.Name = "XHospBox";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private XTextBox txtHospCode;
        private XButton btnFind;
        private Label lbHospCode;
        private XDisplayBox xDisplayBox1;
        private XDisplayBox dbxHospName;

        #endregion

        #region Fields & Properties

        /// <summary>
        /// 病院コード
        /// </summary>
        private string hospCode = "";
        public string HospCode
        {
            get { return hospCode; }
            set { hospCode = value; }
        }

        /// <summary>
        /// 病院名
        /// </summary>
        private string yoyangName = "";
        public string YoyangName
        {
            get { return yoyangName; }
        }

        /// <summary>
        /// CharacterCasing, default uppercase
        /// </summary>
        private CharacterCasing characterCasing = CharacterCasing.Upper;
        public CharacterCasing CharacterCasing
        {
            get { return characterCasing; }
            set
            {
                if (characterCasing != value)
                {
                    characterCasing = value;
                    txtHospCode.CharacterCasing = characterCasing;
                }
            }
        }

        #endregion

        #region Event handler

        /// <summary>
        /// FindClick
        /// </summary>
        public event EventHandler FindClick;

        /// <summary>
        /// DataValidating
        /// </summary>
        public event DataValidatingEventHandler DataValidating;

        /// <summary>
        /// OnFindClick
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnFindClick(EventArgs e)
        {
            EventHandler handler = FindClick;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        /// <summary>
        /// OnDataValidating
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnDataValidating(DataValidatingEventArgs e)
        {
            if (DataValidating != null)
            {
                DataValidating(this, e);
            }
        }

        #endregion

        #region Constructor
        /// <summary>
        /// XHospBox
        /// </summary>
        public XHospBox()
        {
            InitializeComponent();
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
        }
        #endregion

        #region Events

        #region btnFind_Click
        /// <summary>
        /// btnFind_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFind_Click(object sender, EventArgs e)
        {
            FindHospitalForm fdl = new FindHospitalForm();
            if (fdl.ShowDialog() == DialogResult.OK)
            {
                txtHospCode.SetDataValue(fdl.HospCode);
                dbxHospName.SetDataValue(fdl.HospName);
                hospCode = fdl.HospCode;
                yoyangName = fdl.HospName;
            }

            OnFindClick(EventArgs.Empty);
        }
        #endregion

        #region txtHospCode_DataValidating
        /// <summary>
        /// txtHospCode_DataValidating
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtHospCode_DataValidating(object sender, DataValidatingEventArgs e)
        {
            // Empty check
            if (TypeCheck.IsNull(e.DataValue))
            {
                dbxHospName.SetDataValue("");
                e.Cancel = false;
                return;
            }

            Adm107UFbxHospCodeDataValidatingArgs args = new Adm107UFbxHospCodeDataValidatingArgs();
            args.HospCode = e.DataValue;
            Adm107UFbxHospCodeDataValidatingResult res = CloudService.Instance.Submit<Adm107UFbxHospCodeDataValidatingResult,
                Adm107UFbxHospCodeDataValidatingArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                if (TypeCheck.IsNull(res.YoyangName))
                {
                    dbxHospName.SetDataValue("");
                    e.Cancel = true;
                }
                else
                {
                    dbxHospName.SetDataValue(res.YoyangName);
                    hospCode = e.DataValue;
                    yoyangName = res.YoyangName;
                }
            }

            OnDataValidating(e);
        }
        #endregion

        #region txtHospCode_KeyDown
        /// <summary>
        /// txtHospCode_KeyDown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtHospCode_KeyDown(object sender, KeyEventArgs e)
        {

        }
        #endregion

        #endregion

        #region Methods(private)

        #endregion
    }
}
