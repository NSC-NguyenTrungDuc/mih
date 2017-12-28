using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Arguments.Ocs.Lib;
using IHIS.CloudConnector.Contracts.Arguments.OcsEmr;
using IHIS.CloudConnector.Contracts.Arguments.Ocso;
using IHIS.CloudConnector.Contracts.Arguments.System;
using IHIS.CloudConnector.Contracts.Models.Ocso;
using IHIS.CloudConnector.Contracts.Results.OcsEmr;
using IHIS.Framework;
using IHIS.OCSO.Properties;

namespace IHIS.OCSO
{
    public partial class OCS2016U22 : Form
    {
        #region Field & Properties
        private readonly OCS2015U00 mainScreen;
        private List<OCS1003P01GrdPatientListItemInfo> grdPatient = new List<OCS1003P01GrdPatientListItemInfo>();
        #endregion

        #region Contructor
        public OCS2016U22(OCS2015U00 aMainScreen, List<OCS1003P01GrdPatientListItemInfo> grdPatientResult)
        {
            InitializeComponent();

            mainScreen = aMainScreen;
            grdPatient.Clear();
            grdPatient = grdPatientResult;
            grdPatientList.ExecuteQuery = grdPatientList_CreateData;
            grdPatientList.QueryLayout(false);
        }
        #endregion

        #region Event
        private void grdPatientList_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdPatientList.SetBindVarValue("f_hosp_code", UserInfo.HospCode);
        }

        private void grdPatientList_MouseDown(object sender, MouseEventArgs e)
        {
            int rowNumber = -1;
            XEditGrid grd = sender as XEditGrid;

            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                rowNumber = this.grdPatientList.GetHitRowNumber(e.Y);
                // 현재 선택된 로우의 환자번호 적용
                if (rowNumber >= 0)
                {
                    // 현재 파인드 박스의 환자번호와 선택된 번호가 
                    // 동일한경우는 스킵
                    try
                    {
                        this.Cursor = System.Windows.Forms.Cursors.WaitCursor;

                        ProcessMouseClick(rowNumber);
                    }
                    finally
                    {
                        this.Cursor = System.Windows.Forms.Cursors.Default;
                        //MED-9995 have to close after using, otherwise it will cause exeception
                        //this.Dispose(false);
                        this.Close();
                    }
                }
            }
        }
        #endregion

        #region Method
        internal IList<object[]> grdPatientList_CreateData(BindVarCollection varCollection)
        {
            return LoadDataGrdPatientList(grdPatient);
        }

        /// <summary>
        /// Convert to List<object[]>s
        /// </summary>
        /// <param name="grdList"></param>
        /// <returns></returns>
        private List<object[]> LoadDataGrdPatientList(List<OCS1003P01GrdPatientListItemInfo> grdList)
        {
            List<object[]> dataList = new List<object[]>();
            if (grdList != null && grdList.Count > 0)
            {
                foreach (OCS1003P01GrdPatientListItemInfo info in grdList)
                {
                    dataList.Add(new object[]
                    {
                        info.Bunho,
                        info.NaewonDate,
                        info.Gwa,
                        info.Doctor,
                        info.NaewonType,
                        info.ReserYn,
                        info.JubsuTime,
                        info.ArriveTime,
                        info.Suname,
                        info.Suname2,
                        info.Sex,
                        info.Age,
                        info.GubunName,
                        info.GwaName,
                        info.DoctorName,
                        info.ChojaeName,
                        info.JinryoEndYn,
                        info.PkNaewon,
                        info.NaewonYn,
                        info.SunnabYn,
                        info.JubsuGubun1,
                        info.OtherGwa,
                        info.ConsultYn,
                        info.JubsuGubun2,
                        info.CommonDoctorYn,
                        info.Gubun,
                        info.GroupKey,
                        info.KensaYn,
                        info.UnapproveYn
                    });
                }
            }
            return dataList;
        }

        private void ProcessMouseClick(int rowNumber)
        {
            try
            {
                //mainScreen.MParamNaewonKey = this.grdPatientList.GetItemString(rowNumber, "pk_naewon");
                mainScreen.MClickedNaewonKey = this.grdPatientList.GetItemString(rowNumber, "pk_naewon");
                //insert by jc [選択された患者の保険を取得]
                mainScreen.MClickedGubun = this.grdPatientList.GetItemString(rowNumber, "gubun");

                string bunho = this.grdPatientList.GetItemString(rowNumber, "bunho");

                /*//Todo: Re-Check here
                LoadEmrCompositeFirst(bunho, rowNumber, true);*/

                //同名二人CHECK2013/01/05

                // TODO: No need to check for DEMO
                /*if (mainScreen.IsSameNameCHK() == true)
                {
                    if (MessageBox.Show("同じ名前の患者さんが受付されています。\n[漢字名: " + this.grdPatientList.GetItemString(rowNumber, "suname") + "], \n[カナ名: "
                                                                                    + this.grdPatientList.GetItemString(rowNumber, "suname2") + "], \n[年齢: "
                                                                                    + this.grdPatientList.GetItemString(rowNumber, "age") + "]\nこの患者さんでよろしいでしょうか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                        return;
                }*/

                //insert by jc [共通医を選択すると診療を進めるかを聞くメッセージを表示する。] 2012/03/12
                if (mainScreen.IsCommonDoctorJubsu(this.grdPatientList.GetItemString(rowNumber, "pk_naewon")) == true)
                {
                    if (MessageBox.Show(Resources.OCS2016U22_ProcessMouseClick_StrMessageWarning, Resources.OCS2016U22_ProcessMouseClick_Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) ==
                        DialogResult.No)
                        return;
                    else
                    {
                        if (mainScreen.MDoctorLogin)
                            mainScreen.ProcessCommonDoctor(this.grdPatientList.GetItemString(rowNumber, "pk_naewon"));
                    }
                }
                mainScreen.MPatientDoubleClick = true;
                mainScreen.FbxBunho.SetEditValue(this.grdPatientList.GetItemString(rowNumber, "bunho"));

                mainScreen.FbxBunho.AcceptData();

                mainScreen.SetDefaultTemplate = true;
            }
            catch (Exception ex)
            {
                Service.WriteLog("Error in the method ProcessMouseClick() " + ex.StackTrace);
            }
        }


        /*private void LoadEmrCompositeFirst(string bunho, int rowNumber, bool selectFromU21)
        {
            LoadEmrCompositeFirstArgs compositeFirstArgs = new LoadEmrCompositeFirstArgs();
            if (selectFromU21)
            {
                OcsoOCS1003P01CheckYArgs checkYArgs = new OcsoOCS1003P01CheckYArgs();
                checkYArgs.NaewonKey = this.grdPatientList.GetItemString(rowNumber, "pk_naewon");
                compositeFirstArgs.Ocs1003p01CheckY = checkYArgs;
            }

            OCS2015U00GetMaxSizeArgs maxSizeArgs = new OCS2015U00GetMaxSizeArgs();
            compositeFirstArgs.Ocs2015u00GetMaxSize = maxSizeArgs;

            OCS2015U06EmrTagArgs emrTagargs = new OCS2015U06EmrTagArgs();
            compositeFirstArgs.Ocs2015u06EmrTag = emrTagargs;

            OcsoOCS1003P01LayPatArgs layPatArgs = new OcsoOCS1003P01LayPatArgs();
            layPatArgs.FDoctor = this.cboQryDoctor.GetDataValue();
            layPatArgs.FBunho = bunho;
            layPatArgs.FNaewonDate = this.dtpNaewonDate.GetDataValue();
            layPatArgs.FLoginDoctorYn = mainScreen.MDoctorLogin ? "Y" : "N";
            compositeFirstArgs.Ocs1003p01LayPat = layPatArgs;

            PatientInfoLoadPatientNaewonListArgs patientNaewonListArgs = new PatientInfoLoadPatientNaewonListArgs();
            patientNaewonListArgs.Bunho = bunho;
            patientNaewonListArgs.NaewonDateBase = "";
            patientNaewonListArgs.ApproveDoctor = this.cboQryDoctor.GetDataValue();
            patientNaewonListArgs.DoctorModeYn = UserInfo.UserGubun == UserType.Doctor ? "Y" : "N";
            patientNaewonListArgs.IoGubun = "O";
            patientNaewonListArgs.PkKeyOut = TypeCheck.NVL(mainScreen.MClickedNaewonKey, mainScreen.MParamNaewonKey).ToString();
            patientNaewonListArgs.NaewonDate = this.dtpNaewonDate.GetDataValue();
            patientNaewonListArgs.Gwa = this.cboQryGwa.GetDataValue();
            patientNaewonListArgs.Doctor = this.cboQryDoctor.GetDataValue();
            patientNaewonListArgs.JaewonFlag = TypeCheck.NVL(mainScreen.MPatientInfoParam.JaewonFlag, "Y").ToString();
            string inp = TypeCheck.NVL(mainScreen.MClickedNaewonKey, mainScreen.MParamNaewonKey).ToString();
            if (!TypeCheck.IsInt(inp)) inp = "";
            patientNaewonListArgs.PkKeyInp = inp;
            patientNaewonListArgs.IsEnableIpwonReser = "Y";
            compositeFirstArgs.PatientInfoNaewonLst = patientNaewonListArgs;

            FormEnvironInfoSysDateArgs sysDateArgs = new FormEnvironInfoSysDateArgs();
            compositeFirstArgs.EnvironInfoSysDate = sysDateArgs;

            PrOcsLoadNaewonInfoArgs niArgs = new PrOcsLoadNaewonInfoArgs();
            niArgs.NaewonKey = TypeCheck.NVL(mainScreen.MClickedNaewonKey, mainScreen.MParamNaewonKey).ToString();
            int index = niArgs.NaewonKey.IndexOf('.');
            if (index >= 0)
            {
                niArgs.NaewonKey = niArgs.NaewonKey.Substring(0, index);
            }
            compositeFirstArgs.OcsLoadNaewonInfo = niArgs;
            OCS2015U00GetPatientInfoArgs getPatientInfoArgs = new OCS2015U00GetPatientInfoArgs();
            getPatientInfoArgs.Bunho = bunho;
            compositeFirstArgs.Ocs2015u00GetPatientInfo = getPatientInfoArgs;

            LoadEmrCompositeFirstResult res = CloudService.Instance.Submit<LoadEmrCompositeFirstResult, LoadEmrCompositeFirstArgs>(compositeFirstArgs, false, CallbackCompositeFist);

        }*/

        #endregion
    }
}
