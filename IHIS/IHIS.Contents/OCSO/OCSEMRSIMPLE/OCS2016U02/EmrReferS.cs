using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EmrDocker.Glossary;
using IHIS.Framework;
using IHIS.CloudConnector.Contracts.Results.OcsEmr;
using IHIS.CloudConnector.Contracts.Arguments.OcsEmr;
using IHIS.CloudConnector;
using EmrDocker.Models;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Models.OcsEmr;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList;
using Newtonsoft.Json;
using IHIS.OCSO.Properties;

namespace IHIS.OCSO
{
    public partial class EmrReferS : XForm
    {
        private string _bunho = "";
        private string _hospCode = "";
        private string _naewonKey = "";
        private string _gwa = "";
        private PatientModelInfo _patientInfo;
        private DateTime _sysDate = EnvironInfo.GetSysDate();
        private string oldMmlContent = "";

        public EmrReferS()
        {
            InitializeComponent();
            
        }

        public EmrReferS(string hospCode,string gwa, string bunho, string naewonKey, PatientModelInfo patientInfo)
        {
            InitializeComponent();
            this._hospCode = hospCode;
            this._bunho = bunho;
            this._naewonKey = naewonKey;
            this._patientInfo = patientInfo;
            this._patientInfo.PatientId = bunho;
            this._gwa = gwa;
            
            emrHis.TvHisExam.MouseDoubleClick += new MouseEventHandler(TvBunho_NodeMouseDoubleClick);
            emrHis.SetDataForTvExamHist(bunho, hospCode, gwa, false);
            bookMark.TvBunho.DoubleClick += TvBunho_DoubleClick;
            ucView2.ucGrid1.IsEnableBtnDo = false;
            ucView2.ucGrid1.SetActiveGridView(false);
            ucView2.IsEnableBtnEdit = false;
            ucView2.SetActiveEditEmrBtn();
            ucView2.ViewLoadFunc();
            DataProvider.Instance.ReloadLatestTagsClinicRefer(_hospCode);
            LoadEmrHistory();

        }
        private void LoadEmrHistory()
        {
            OCS2015U06EmrRecordResult result = GetCurrentEmrRecord();
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success && result.EmrRecordList.Count > 0)
            {
                List<CommentInfo> listBookmark = new List<CommentInfo>();
                foreach (OCS2015U06EmrRecordInfo info in result.EmrRecordList)
                {
                    ucView2.Record_id = info.RecordId;
                    ucView2.ucGrid1.LoadGrid(info.Content, _patientInfo, _naewonKey, info.Metadata, true, false, _hospCode, ScreenEnum.Other);
                    if (!string.IsNullOrEmpty(info.Metadata))
                    {
                        listBookmark = JsonConvert.DeserializeObject<List<CommentInfo>>(info.Metadata);
                    }
                }

                bookMark.IsEnableRightClick = false;
                bookMark.DisplayBookmarkHistory(result.EmrRecordList[0].RecordId, _bunho, listBookmark, _gwa, null, _hospCode);
            }
            this.ucView2.SetActiveEditEmrBtn();

        }

        private OCS2015U06EmrRecordResult GetCurrentEmrRecord()
        {
            OCS2015U06EmrRecordArgs args = new OCS2015U06EmrRecordArgs();
            args.Bunho = _bunho;
            args.HospCode = _hospCode;
            if (CloudService.Instance.Connect())
            {
                return CloudService.Instance.Submit<OCS2015U06EmrRecordResult, OCS2015U06EmrRecordArgs>(args);
            }
            return null;
        }

        private void TvBunho_DoubleClick(object sender, EventArgs e)
        {
            TreeNode treeNode = bookMark.TvBunho.SelectedNode;
            if (treeNode.Level == 1)
            {
                ucView2.ucGrid1.ScrollToDate(treeNode.Text.Trim(), "");
            }
            else if (treeNode.Level == 2)
            {
                CommentInfo info = (CommentInfo)treeNode.Tag;
                string bookmarkId = info == null ? "" : info.TagId;
                if (!string.IsNullOrEmpty(bookmarkId)) ucView2.ucGrid1.ScrollToTagId(bookmarkId);
            }
        }
        private void TvBunho_NodeMouseDoubleClick(object sender, MouseEventArgs e)
        {      
            TreeList tree = sender as TreeList;
            TreeListNode node = tree.FocusedNode;
            //Fix bug MED-10306
            OCS2015U06EmrRecordResult result = GetCurrentEmrRecord();            
            if (node != null && node.GetValue("IntruduceLetter") != null)
            {
                if (result != null && result.ExecutionStatus == ExecutionStatus.Success && result.EmrRecordList.Count > 0)
                {
                    foreach (OCS2015U06EmrRecordInfo info in result.EmrRecordList)
                    {
                        this.oldMmlContent = info.Content;
                    }
                }
                List<EmrRecordInfo> refRecordInfos;
                if(string.IsNullOrEmpty(oldMmlContent))
                {
                    refRecordInfos = new List<EmrRecordInfo>();
                }
                else
                {
                    EmrDocker.Types.Triple<List<EmrRecordInfo>,PatientModelInfo,HospitalModelInfo> returnValue 
                        = MedicalInterfaceTest.MmlParserIntruduceLetter.Instance.ToModel(oldMmlContent);
                    refRecordInfos = returnValue.V1;
                }
                if(refRecordInfos != null && refRecordInfos.Count > 0)
                {
                    string bunho = node.GetValue("Bunho").ToString().Trim();
                    CommonItemCollection letterOpen = new CommonItemCollection();
                    letterOpen.Add("f_bunho",_bunho) ;
                    letterOpen.Add("f_hosp_code",_hospCode);
                    letterOpen.Add("f_user_id",UserInfo.UserID);
                    letterOpen.Add("mOpener","");
                    XScreen.OpenScreenWithParam(this,"OCSO","NUR2015U01",ScreenOpenStyle.ResponseFixed,letterOpen);
                }
                else
                {
                    XMessageBox.Show(Resources.INTRODUCE_MSG_1, Resources.INTRODUCE_CAP_1, MessageBoxIcon.Warning);                    
                }
            }

            if (node != null && node.GetValue("NaewonDate") != null)
            {
                string naewonDate = node.GetValue("NaewonDate").ToString().Trim();
                DateTime sysDate = _sysDate;
                try
                {
                    emrHis.TvHisExam.BeginUpdate();
                    if (node.Level == 1)
                    {
                        string pkOut1001 = Convert.ToInt32(Double.Parse(node.GetValue("PkOut1001").ToString().Trim())).ToString();
                        DateTime calendarDate = DateTime.Parse(naewonDate.Substring(0, 10));
                        ucView2.ucGrid1.ScrollToDate(naewonDate, pkOut1001);

                        #region for tvExamHist

                        if (pkOut1001.Contains("."))
                        {
                            string[] pkOut1001Arr = pkOut1001.Split(new char[] { '.' });
                            ucView2.ucGrid1.ScrollToPkOut(pkOut1001Arr[0]);
                        }
                        else if (pkOut1001.Contains(","))
                        {
                            string[] pkOut1001Arr = pkOut1001.Split(new char[] { ',' });
                            ucView2.ucGrid1.ScrollToPkOut(pkOut1001Arr[0]);
                        }
                        else
                        {
                            ucView2.ucGrid1.ScrollToPkOut(pkOut1001);
                        }

                        #endregion

                        this.ucView2.Pkout1001 = pkOut1001;

                        this.ucView2.Bunho = _bunho;
                        this.ucView2.NaewonDate = naewonDate;
                        this.ucView2.NaewonKey = pkOut1001;
                    }
                }
                finally
                {
                    emrHis.TvHisExam.EndUpdate();
                }
            }
        }
    }
}