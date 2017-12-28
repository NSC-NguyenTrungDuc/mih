using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using IHIS.Framework;

namespace IHIS.OCSO
{
    public enum ShowMode
    {
        Injs,
        Cpls,
    }

    public partial class UCBtnList : UserControl
    {
        // CPL
        public event EventHandler BtnChangeTimeCPLClick;
        public event EventHandler BtnPrintSetupCPLClick;
        public event EventHandler BtnBarcodeCPLClick;
        public event EventHandler BtnOrderCancelCPLClick;
        public event EventHandler BtnChkAllJubsuCPLClick;
        public event EventHandler BtnOrderPrintCPLClick;
        public event ButtonClickEventHandler BtnListCPLClick;
        // INJ
        public event EventHandler BtnReserClick;
        public event EventHandler BtnPrintSetupClick;
        public event EventHandler BtnReInjActScripClick;
        public event EventHandler BtnLabelClick;
        public event EventHandler BtnReLabelClick;
        public event EventHandler BtnChkAllJubsuClick;
        public event ButtonClickEventHandler BtnListINJButtonClick;

        #region Constructors

        public UCBtnList()
        {
            InitializeComponent();
        }

        public UCBtnList(ShowMode mode)
        {
            InitializeComponent();

            this.Size = new Size(1426, 38);
            if (mode == ShowMode.Cpls)
            {
                // CPLS
                this.panelBtnCPL.Visible = true;
                this.panelBtnCPL.Dock = DockStyle.Fill;
                this.panelBtnINJ.Visible = false;
            }
            else
            {
                // INJS
                this.panelBtnINJ.Visible = true;
                this.panelBtnINJ.Dock = DockStyle.Fill;
                this.panelBtnCPL.Visible = false;
            }
        }

        #endregion

        #region CPL Buttons click

        private void btnChangeTime_Click(object sender, EventArgs e)
        {
            if (this.BtnChangeTimeCPLClick != null)
            {
                this.BtnChangeTimeCPLClick(this, e);
            }
        }

        private void btnPrintSetupCPL_Click(object sender, EventArgs e)
        {
            if (this.BtnPrintSetupCPLClick != null)
            {
                this.BtnPrintSetupCPLClick(this, e);
            }
        }

        private void btnBarcode_Click(object sender, EventArgs e)
        {
            if (this.BtnBarcodeCPLClick != null)
            {
                this.BtnBarcodeCPLClick(this, e);
            }
        }

        private void btnOrderCancel_Click(object sender, EventArgs e)
        {
            if (this.BtnOrderCancelCPLClick != null)
            {
                this.BtnOrderCancelCPLClick(this, e);
            }
        }

        private void btnChkAllJubsuCPL_Click(object sender, EventArgs e)
        {
            if (this.BtnChkAllJubsuCPLClick != null)
            {
                this.BtnChkAllJubsuCPLClick(this, e);
            }
        }

        private void btnOrderPrint_Click(object sender, EventArgs e)
        {
            if (this.BtnOrderPrintCPLClick != null)
            {
                this.BtnOrderPrintCPLClick(this, e);
            }
        }

        private void btnListCPL_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
        {
            if (this.BtnListCPLClick != null)
            {
                this.BtnListCPLClick(this, e);
            }
        }

        #endregion

        #region INJ Buttons click

        private void btnReser_Click(object sender, EventArgs e)
        {
            if (this.BtnReserClick != null)
            {
                this.BtnReserClick(this, e);
            }
        }

        private void btnPrintSetup_Click(object sender, EventArgs e)
        {
            if (this.BtnPrintSetupClick != null)
            {
                this.BtnPrintSetupClick(this, e);
            }
        }

        private void btnReInjActScrip_Click(object sender, EventArgs e)
        {
            if (this.BtnReInjActScripClick != null)
            {
                this.BtnReInjActScripClick(this, e);
            }
        }

        private void btnLabel_Click(object sender, EventArgs e)
        {
            if (this.BtnLabelClick != null)
            {
                this.BtnLabelClick(this, e);
            }
        }

        private void btnReLabel_Click(object sender, EventArgs e)
        {
            if (this.BtnReLabelClick != null)
            {
                this.BtnReLabelClick(this, e);
            }
        }

        private void btnChkAllJubsu_Click(object sender, EventArgs e)
        {
            if (this.BtnChkAllJubsuClick != null)
            {
                this.BtnChkAllJubsuClick(this, e);
            }
        }

        private void btnListINJ_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
        {
            if (this.BtnListINJButtonClick != null)
            {
                this.BtnListINJButtonClick(this, e);
            }
        }

        #endregion

        #region Methods
        public void SetVisibleBtnBarcode(bool visible)
        {
            this.btnBarcode.Visible = visible;
        }
        #endregion
    }
}
