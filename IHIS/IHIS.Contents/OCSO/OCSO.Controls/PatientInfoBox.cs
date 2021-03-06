using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using IHIS.Framework;
using IHIS.CloudConnector.Contracts.Arguments.OcsEmr;
using IHIS.CloudConnector.Contracts.Results.OcsEmr;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Arguments.Nuri;
using IHIS.CloudConnector.Contracts.Results.Nuri;
using IHIS.CloudConnector.Contracts.Models.Nuri;
using IHIS.CloudConnector.Contracts.Arguments.Outs;
using IHIS.CloudConnector.Contracts.Results.Outs;
using IHIS.CloudConnector.Contracts.Models.Outs;
using IHIS.OCSO.Properties;

namespace IHIS.OCSO
{
    public partial class PatientInfoBox : UserControl
    {
        #region Fields

        private string _bunho = "";
        private string _naewonDate = "";
        ToolTip toolTip = null;
        #endregion

        #region Constructor

        public PatientInfoBox()
        {
            InitializeComponent();

            this.signalPictureBox.Image = Properties.Resources.btnCurrentAllagent;
            this.signalPictureBox2.Image = Properties.Resources.Untitled_1;
            this.signalPictureBox3.Image = Properties.Resources.Untitled_2;
            SetTooltipForControls();
        }

        //MED-10092
        private void SetTooltipForControls()
        {
            toolTip = new ToolTip();
            toolTip.ShowAlways = true;
            toolTip.SetToolTip(signalPictureBox, Resources.signalPictureBox_Name);
            toolTip.SetToolTip(signalPictureBox2, Resources.signalPictureBox2_Name);
            toolTip.SetToolTip(signalPictureBox3, Resources.signalPictureBox3_Name);
        }

        #endregion

        #region Events

        public event EventHandler PatientInfoChanged;

        private void signalPictureBox_Click(object sender, EventArgs e)
        {
            if (TypeCheck.IsNull(this._bunho)) return;

            this.OpenScreen_NUR1016U00(this._bunho);
            ResetSignalPicture();
            this.CheckButtonAllergy();
        }

        private void signalPictureBox2_Click(object sender, EventArgs e)
        {
            if (TypeCheck.IsNull(this._bunho)) return;

            CommonItemCollection allergyOpen = new CommonItemCollection();
            allergyOpen.Add("bunho", this._bunho);
            XScreen.OpenScreenWithParam(this, "NURO", "NUR1017U00", ScreenOpenStyle.ResponseFixed, allergyOpen);

            ResetSignalPicture2();
            CheckButtonAllergy2();
            if (this.PatientInfoChanged != null)
            {
                this.PatientInfoChanged(this, new EventArgs());
            }
        }

        private void signalPictureBox3_Click(object sender, EventArgs e)
        {
            if (TypeCheck.IsNull(this._bunho)) return;

            CommonItemCollection prams = new CommonItemCollection();
            prams.Add("bunho", this._bunho);
            XScreen.OpenScreenWithParam(this, "NURO", "OUT0106U00", ScreenOpenStyle.ResponseFixed, prams);
            //this.GetSpecialNoteList(this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString(), this.mSelectedPatientInfo.GetPatientInfo["naewon_date"].ToString());

            ResetSignalPicture3();
            CheckButtonAllergy3();
            if (this.PatientInfoChanged != null)
            {
                this.PatientInfoChanged(this, new EventArgs());
            }
        }

        #endregion

        #region Methods

        public void SetPatientInfo(string bunho, string naewonDate)
        {
            if (TypeCheck.IsNull(bunho))
            {
                Reset();
                return;
            }

            try
            {
                OCS2015U00GetPatientInfoArgs args = new OCS2015U00GetPatientInfoArgs();
                args.Bunho = bunho;
                OCS2015U00GetPatientInfoResult res = CloudService.Instance.Submit<OCS2015U00GetPatientInfoResult, OCS2015U00GetPatientInfoArgs>(args);

                if (res.ExecutionStatus == ExecutionStatus.Success)
                {
                    if (res.ManagePatInfo.Count > 0)
                    {
                        // Basic info
                        this.lbSuName.Text = res.ManagePatInfo[0].PatientName1;
                        this.lbSuName2.Text = res.ManagePatInfo[0].PatientName2;

                        if (!String.IsNullOrEmpty(res.ManagePatInfo[0].Birth.ToString()))
                        {
                            if (String.IsNullOrEmpty(res.ManagePatInfo[0].Sex.ToString()))
                            {
                                this.lbBirthDay.Text = res.ManagePatInfo[0].Birth.ToString().Substring(0, 10).Trim().Replace("-", "/");
                            }
                            else
                            {
                                this.lbBirthDay.Text = res.ManagePatInfo[0].Sex.ToString() + new string(' ', 3) +
                                    res.ManagePatInfo[0].Birth.ToString().Substring(0, 10).Trim().Replace("-", "/");
                            }
                        }
                    }

                    if (res.PhyInfoItem.Count > 0)
                    {
                        this.lbHeightWeight.Text = string.Format("{0}kg{1}{2}cm", res.PhyInfoItem[0].Weight, new string(' ', 3), res.PhyInfoItem[0].Height);
                        this.lbPulse.Text = string.Format("{0}{1}{2}{3}{4}{5}{6}{7}",
                            res.PhyInfoItem[0].Pulse,
                            Properties.Resources.LB_PULSE,
                            new string(' ', 3),
                            res.PhyInfoItem[0].BodyHeat,
                            Properties.Resources.LB_BODYHEAT,
                            new string(' ', 3),
                            res.PhyInfoItem[0].Breath,
                            Properties.Resources.LB_PULSE);
                        this.lbPressure.Text = string.Format("{0}{1}{2}{3}{4}{5}{6}{7}{8}",
                            Properties.Resources.LB_BLOOD_PRESSURE,
                            new string(' ', 3),
                            res.PhyInfoItem[0].BpFrom,
                            "/",
                            res.PhyInfoItem[0].BpTo,
                            new string(' ', 3),
                            "spO2",
                            new string(' ', 1),
                            res.PhyInfoItem[0].Spo2 + "%");
                    }
                }
            }
            catch (Exception ex)
            {
                Service.StartWriteLog();
                Service.WriteLog("SetPatientInfo failed. Message: " + ex.Message);
                Service.WriteLog("SetPatientInfo failed. At: " + ex.StackTrace);
                Service.EndWriteLog();
            }
            finally
            {
                this._bunho = bunho;
                this._naewonDate = naewonDate;
                ResetSignalPicture();
                CheckButtonAllergy();
                ResetSignalPicture2();
                CheckButtonAllergy2();
                ResetSignalPicture3();
                CheckButtonAllergy3();
            }
        }

        public void Reset()
        {
            this.lbSuName.Text = "";
            this.lbSuName2.Text = "";
            this.lbBirthDay.Text = "";
            this.lbHeightWeight.Text = "";
            this.lbPulse.Text = "";
            this.lbPressure.Text = "";
        }

        private void ResetSignalPicture()
        {
            this.signalPictureBox.Image = Properties.Resources.btnCurrentAllagent;
            //this.signalPictureBox.Location = new System.Drawing.Point(234, 1);
            this.signalPictureBox.Size = new System.Drawing.Size(18, 18);
        }

        private void ResetSignalPicture2()
        {
            this.signalPictureBox2.Image = Properties.Resources.Untitled_1;
            //this.signalPictureBox2.Location = new System.Drawing.Point(257, 1);
            this.signalPictureBox2.Size = new System.Drawing.Size(18, 18);
        }

        private void ResetSignalPicture3()
        {
            this.signalPictureBox3.Image = Properties.Resources.Untitled_2;
            //this.signalPictureBox3.Location = new System.Drawing.Point(280, 1);
            this.signalPictureBox3.Size = new System.Drawing.Size(18, 18);
        }

        private void OpenScreen_NUR1016U00(string aBunho)
        {
            CommonItemCollection openParams = new CommonItemCollection();

            openParams.Add("bunho", aBunho);

            XScreen.OpenScreenWithParam(this, "NURO", "NUR1016U00", ScreenOpenStyle.ResponseFixed, openParams);
        }

        private void CheckButtonAllergy()
        {
            if (TypeCheck.IsNull(this._bunho)) return;

            NUR1016U00GrdNUR1016Args args = new NUR1016U00GrdNUR1016Args();
            args.Bunho = this._bunho;
            NUR1016U00GrdNUR1016Result result = CloudService.Instance.Submit<NUR1016U00GrdNUR1016Result, NUR1016U00GrdNUR1016Args>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (NUR1016U00GrdNUR1016ListItemInfo info in result.GrdNUR1016List)
                {
                    //this.btnAllergy.ImageIndex = 36;
                    this.signalPictureBox.Image = Properties.Resources.btnCurrentAllagent;
                    if (!string.IsNullOrEmpty(info.AllergyGubun))
                    {
                        //this.signalPictureBox.Location = new System.Drawing.Point(235, 1);
                        this.signalPictureBox.Size = new System.Drawing.Size(16, 16);
                        this.signalPictureBox.Image = Properties.Resources.grnpuls_blue;
                        break;
                    }
                }
            }
        }

        private void CheckButtonAllergy2()
        {
            if (TypeCheck.IsNull(this._bunho)) return;

            NUR1017U00GrdNUR1017Args args = new NUR1017U00GrdNUR1017Args();
            args.Bunho = this._bunho;
            NUR1017U00GrdNUR1017Result result = CloudService.Instance.Submit<NUR1017U00GrdNUR1017Result, NUR1017U00GrdNUR1017Args>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (NUR1017U00GrdNUR1017ListItemInfo info in result.GrdNUR1017List)
                {
                    //this.btnAllergy.ImageIndex = 36;
                    this.signalPictureBox2.Image = Properties.Resources.grnpuls_red;
                    //this.signalPictureBox2.Location = new System.Drawing.Point(260, 1);
                    this.signalPictureBox2.Size = new System.Drawing.Size(16, 16);
                    this.signalPictureBox2.Image = Properties.Resources.grnpuls_red;
                    break;
                }
            }
        }

        private void CheckButtonAllergy3()
        {
            if (TypeCheck.IsNull(this._bunho)) return;

            OUT0106U00GridListArgs args = new OUT0106U00GridListArgs();
            args.Bunho = this._bunho;
            args.NaewonDate = this._naewonDate;
            OUT0106U00GridListResult result = CloudService.Instance.Submit<OUT0106U00GridListResult, OUT0106U00GridListArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (OUT0106U00GridItemInfo info in result.GridItemInfo)
                {
                    //this.btnAllergy.ImageIndex = 36;
                    this.signalPictureBox3.Image = global::IHIS.OCSO.Properties.Resources.grnpuls_green;
                    //this.signalPictureBox3.Location = new System.Drawing.Point(285, 1);
                    this.signalPictureBox3.Size = new System.Drawing.Size(16, 16);
                    this.signalPictureBox3.Image = Properties.Resources.grnpuls_green;
                    break;
                }
            }
        }

        #endregion
    }
}
