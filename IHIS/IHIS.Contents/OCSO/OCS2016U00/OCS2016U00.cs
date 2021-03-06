using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using IHIS.Framework;
using IHIS.CloudConnector.Contracts.Results.Ocsa;
using IHIS.CloudConnector.Contracts.Arguments.Ocsa;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using IHIS.CloudConnector.Caching;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.CloudConnector.Contracts.Arguments.System;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.OCS;
using IHIS.CloudConnector.Contracts.Results.Nuro;
using IHIS.CloudConnector.Contracts.Arguments.Nuro;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using IHIS.CloudConnector.Contracts.Arguments.Ocso;
using IHIS.CloudConnector.Contracts.Results.Ocso;
using IHIS.CloudConnector.Contracts.Models.Ocso;
using EmrDocker.Models;
using IHIS.OCSO.Properties;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraEditors;

namespace IHIS.OCSO
{
    public partial class OCS2016U00 : XScreen
    {
        #region properties
        private int _tabIndex;
        private string _fbxType = string.Empty;
        private string _consultDepartment = string.Empty;
        private string _findMode = string.Empty;
        private string _bunho = string.Empty;
        private string _consultHospCode = string.Empty;
        private string _consultDoctor = string.Empty;
        private bool _isUpdateDiscussion;
        private int _discussIndexRow = 0;
        private XColor mSelectedForeColor = new XColor(Color.FromName("ActiveCaptionText"));
        private XColor mSelectedBackColor = new XColor(Color.FromName("ActiveCaption"));
        private XColor mUnSelectedForeColor = new XColor(Color.FromName("InactiveCaptionText"));
        private XColor mUnSelectedBackColor = new XColor(Color.FromName("InactiveCaption"));
        #endregion

        #region Constructor
        public OCS2016U00()
        {
            InitializeComponent();
            InitData();

        }
        public OCS2016U00(string bunho)
            : this()
        {
            _bunho = bunho;
        }
        #endregion

        #region Evetn handler
        private void rbnRequestType_CheckedChanged(object sender, EventArgs e)
        {
            XRadioButton button = sender as XRadioButton;
            ResetControlpanelData();
            if (button.Checked == true)
            {
                button.BackColor = this.mSelectedBackColor;
                button.ForeColor = this.mSelectedForeColor;

                btnEmrRefer.Visible = false;
                cbxFinishDiscuss.Visible = false;

                pnlTab1Info.Visible = false;


                if (button.Tag.ToString() == "SEND")
                {
                    _tabIndex = 0;
                    ControlPanelActive(true);
                    BtnListSetStatus(true);
                }
                else if (button.Tag.ToString() == "RECEIVED")
                {
                    _tabIndex = 1;
                    ControlPanelActive(false);
                    BtnListSetStatus(false);
                    grdViewDiscuss.RefreshData();
                }
                else
                {
                    _tabIndex = 2;
                    BtnListSetStatus(false);
                    ControlPanelActive(false);
                    grdReceivedRequest.Reset();
                    grdViewDiscuss.RefreshData();


                }

                if (_tabIndex == 0)
                {
                    pnlGrDiscussion.Location = new Point(1, 34);
                    pnlGrDiscussion.Height = 373;

                }
                else
                {
                    pnlGrDiscussion.Location = new Point(1, 0);
                    pnlGrDiscussion.Height = 407;
                }
            }
            else
            {
                button.BackColor = this.mUnSelectedBackColor;
                button.ForeColor = this.mUnSelectedForeColor;
            }
            btnList.PerformClick(FunctionType.Query);
        }

        private void fbxID_FindSelected(object sender, FindEventArgs e)
        {
            XFindBox control = (XFindBox)sender;
            switch (control.Name)
            {
                case "fbxHospital":
                    dbxHospital.SetEditValue(e.ReturnValues[1].ToString());
                    _consultHospCode = e.ReturnValues[0].ToString();
                    xdbTab3.SetEditValue(e.ReturnValues[1].ToString());
                    break;
                case "fbxConsult_gwa":
                    _consultDepartment = e.ReturnValues[0].ToString();
                    dbxConsult_gwa_name.SetEditValue(e.ReturnValues[1].ToString());
                    fbxConsult_doctor.Clear();
                    dbxConsult_doctor_name.Text = string.Empty;
                    break;
                case "fbxConsult_doctor":
                    dbxConsult_doctor_name.Text = e.ReturnValues[1].ToString();
                    _consultDoctor = e.ReturnValues[0].ToString();
                    break;
                case "xfbGwaTab3":
                    xdbTab3.SetEditValue(e.ReturnValues[1].ToString());
                    break;
                case "xfbgwa":
                    xdbgwa.SetEditValue(e.ReturnValues[1].ToString());
                    break;
                default:
                    break;
            }
            ControlPanelUpdateStatus();
        }

        private void fbx_FindClick(object sender, CancelEventArgs e)
        {
            _findMode = ((XFindBox)sender).Name.ToString();

            XFindWorker fdwCommon = new IHIS.Framework.XFindWorker();
            string naewon_date = TypeCheck.NVL(dpkReq_date.GetDataValue(), EnvironInfo.GetSysDate().ToString("yyyy/MM/dd")).ToString();

            switch (_findMode)
            {
                case "fbxHospital":
                    fdwCommon.AutoQuery = true;
                    fdwCommon.ServerFilter = false;

                    fdwCommon.FormText = Resources.fdwCommonFormText3;//"病院名称";
                    fdwCommon.ColInfos.Add("hosp_code",Resources.fdwCommonColInfosHospCode/* "病院コード"*/, FindColType.String, 100, 0, true, FilterType.Yes);
                    fdwCommon.ColInfos.Add("hosp_name", Resources.fdwCommonColInfosHospName /*"病院名称"*/, FindColType.String, 300, 0, true, FilterType.Yes);


                    break;

                case "fbxConsult_gwa":
                    fdwCommon.AutoQuery = true;
                    fdwCommon.ServerFilter = false;

                    fdwCommon.FormText = Resources.fdwCommonFormText1;//"部署名";
                    fdwCommon.ColInfos.Add("hangmog_code",Resources.fdwCommonColInfosHangmogCode/* "部署コード"*/, FindColType.String, 100, 0, true, FilterType.Yes);
                    fdwCommon.ColInfos.Add("hangmog_name",Resources.fdwCommonColInfosHangmogName/* "部署名"*/, FindColType.String, 300, 0, true, FilterType.Yes);


                    break;

                case "fbxConsult_doctor":
                    fdwCommon.AutoQuery = true;
                    fdwCommon.ServerFilter = false;

                    fdwCommon.FormText =Resources.fdwCommonFormText2;//"医師";
                    fdwCommon.ColInfos.Add("doctor",Resources.fdwCommonColInfosDoctor /*"医師"*/, FindColType.String, 100, 0, true, FilterType.Yes);
                    fdwCommon.ColInfos.Add("doctor_name", Resources.fdwCommonColInfosDoctorName /*"医師"*/, FindColType.String, 200, 0, true, FilterType.Yes);
                    break;
                case "xfbGwaTab3":
                    fdwCommon.AutoQuery = true;
                    fdwCommon.ServerFilter = false;

                    fdwCommon.FormText = Resources.fdwCommonFormText1;// "部署名";
                    fdwCommon.ColInfos.Add("hangmog_code",Resources.fdwCommonColInfosHangmogCode/* "部署コード"*/, FindColType.String, 100, 0, true, FilterType.Yes);
                    fdwCommon.ColInfos.Add("hangmog_name",Resources.fdwCommonColInfosHangmogName /* "部署名"*/, FindColType.String, 300, 0, true, FilterType.Yes);
                    break;

                case "xfbgwa":
                    fdwCommon.AutoQuery = true;
                    fdwCommon.ServerFilter = false;

                    fdwCommon.FormText = Resources.fdwCommonFormText1;//"部署名";
                    fdwCommon.ColInfos.Add("hangmog_code",Resources.fdwCommonColInfosHangmogCode /*"部署コード"*/, FindColType.String, 100, 0, true, FilterType.Yes);
                    fdwCommon.ColInfos.Add("hangmog_name",Resources.fdwCommonColInfosHangmogName/* "部署名"*/, FindColType.String, 300, 0, true, FilterType.Yes);

                    break;
                default:
                    break;
            }

            fdwCommon.ExecuteQuery = QueryFdwCommon;

            if (_findMode == "fbxHospital")
                fbxHospital.FindWorker = fdwCommon;
            else if (_findMode == "fbxConsult_gwa")
                fbxConsult_gwa.FindWorker = fdwCommon;
            else if (_findMode == "xfbGwaTab3")
                xfbGwaTab3.FindWorker = fdwCommon;
            else if (_findMode == "xfbgwa")
                xfbgwa.FindWorker = fdwCommon;
            else
                fbxConsult_doctor.FindWorker = fdwCommon;
        }

        private void btnList_ButtonClick(object sender, ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Query:
                    e.IsBaseCall = false;
                    ResetGridDiscussion();
                    _isUpdateDiscussion = false;
                    if (rbnDepartmentReq.Checked && xfbGwaTab3.GetDataValue().ToString().Trim() != "")
                    {
                        grdReceivedRequest.QueryLayout(true);
                    }
                    else
                    {
                        if (_tabIndex == 0)
                            grdSentRequest.QueryLayout(true);
                        else
                            grdReceivedRequest.QueryLayout(true);
                    }

                    break;
                case FunctionType.Insert:
                    
                    if (Find_AddedRowState() == "Y")
                        e.IsBaseCall = false;
                    else
                        CreatNewRow();
                    break;
                case FunctionType.Update:
                    DataSaveLayout();
                    break;
                case FunctionType.Delete:
                    break;
                default:
                    break;
            }
        }

        private void CreatNewRow()
        {
            string grpQuestionId = _tabIndex == 0 ? grdSentRequest.GetItemString(grdSentRequest.CurrentRowNumber, "grp_question_id") : grdReceivedRequest.GetItemString(grdReceivedRequest.CurrentRowNumber, "grp_question_id");

            grdViewDiscuss.AddNewRow();

            int rowHandle = grdViewDiscuss.GetRowHandle(grdViewDiscuss.DataRowCount);
            if (grdViewDiscuss.IsNewItemRow(rowHandle))
            {
                grdViewDiscuss.SetRowCellValue(rowHandle, grdViewDiscuss.Columns[0], UserInfo.UserID);
                grdViewDiscuss.SetRowCellValue(rowHandle, grdViewDiscuss.Columns[1], "");
                grdViewDiscuss.SetRowCellValue(rowHandle, grdViewDiscuss.Columns[2], DateTime.Now.ToString("yyyy/MM/dd"));
                grdViewDiscuss.SetRowCellValue(rowHandle, grdViewDiscuss.Columns[3], "N");
                grdViewDiscuss.SetRowCellValue(rowHandle, grdViewDiscuss.Columns[4], grpQuestionId);
                grdViewDiscuss.SetRowCellValue(rowHandle, grdViewDiscuss.Columns[5], UserInfo.UserID);
                grdViewDiscuss.SetRowCellValue(rowHandle, grdViewDiscuss.Columns[6], "Added");
                grdViewDiscuss.SetRowCellValue(rowHandle, grdViewDiscuss.Columns[7], "");
            }
        }

        private void DataSaveLayout()
        {
            if (string.IsNullOrEmpty(_tabIndex.ToString()))
                return;

            if (_tabIndex == 0)
                QuestionProcessing();
            else
                ReplyProcessing();
        }

        private void pbxRequest_bunho_Validating(object sender, CancelEventArgs e)
        {
            _bunho = pbxRequest_bunho.BunHo;
            ControlPanelUpdateStatus();
        }

        private void fbxDataFillter_Validating(object sender, CancelEventArgs e)
        {
            XFindBox control = (XFindBox)sender;
            if (!IsExistFwkData(control.Name.ToString(), control.Text))
            {
                control.ResetText();
                return;
            }
            ControlPanelUpdateStatus();
            if (rbnDepartmentReq.Checked)
                btnList.PerformClick(FunctionType.Query);
        }

        private void OCS2016U00_ScreenOpen(object sender, XScreenOpenEventArgs e)
        {
            if (e.OpenParam != null)
            {
                try
                {
                    if (OpenParam.Contains("bunho"))
                        _bunho = OpenParam["bunho"].ToString().Trim();
                }
                catch (Exception ex)
                {
                    this.Close();
                }
            }
        }

        private void grdSentRequest_RowFocusChanged(object sender, RowFocusChangedEventArgs e)
        {
            _bunho = grdSentRequest.GetItemString(grdSentRequest.CurrentRowNumber, "bunho");
            fbxHospital.Enabled = false;
            fbxConsult_gwa.Enabled = false;
            fbxConsult_doctor.Enabled = false;
            if (string.IsNullOrEmpty(grdSentRequest.GetItemString(grdSentRequest.CurrentRowNumber, "grp_question_id")))
            {// New row
                pbxRequest_bunho.Enabled = true;
                xfbgwa.Enabled = true;
            }
            else
            {
                pbxRequest_bunho.Enabled = false;
                xfbgwa.Enabled = false;
            }
            QuestionDataDetailBinData();
            cbxFinishDiscuss.Checked = grdSentRequest.GetItemString(grdSentRequest.CurrentRowNumber, "finish_discuss_yn").Equals("Y");
            if (grdSentRequest.GetRowState(grdSentRequest.CurrentRowNumber) == DataRowState.Added)
                CreatNewRow();
        }

        private void repositoryItemPictureEdit1_DoubleClick(object sender, EventArgs e)
        {
            GridView view = gridDiscussContent.FocusedView as GridView;
            if (view == null) return;
            DataRowView selRow = (DataRowView)(gridDiscussContent.MainView.GetRow(view.FocusedRowHandle));
            int indexRow = _discussIndexRow = view.FocusedRowHandle;
            string UserId = view.GetRowCellValue(indexRow, view.Columns["UserId"]).ToString();
            if (UserId == UserInfo.UserID)
            {
                string content = view.GetRowCellValue(indexRow, view.Columns["Content"]).ToString();
                string dataRowState = view.GetRowCellValue(indexRow, view.Columns["dataRowState"]).ToString();
                view.SetRowCellValue(indexRow, "dataRowState", "Modified");
                _isUpdateDiscussion = true;
            }
        }

        private void grdViewDiscuss_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            if (e.Column.FieldName == "EditedFlag")
            {
                e.RepositoryItem = repositoryItemPictureEdit1;
                repositoryItemPictureEdit1.Appearance.TextOptions.HAlignment = HorzAlignment.Near;
            }

            if (e.Column.FieldName == "Content")
            {
                e.RepositoryItem = repositoryItemMemoEdit1;
                repositoryItemMemoEdit1.Appearance.TextOptions.HAlignment = HorzAlignment.Near;
            }
        }

        private void btnEmrRefer_Click(object sender, EventArgs e)
        {
            int curRowNumber = grdReceivedRequest.CurrentRowNumber;
            string hospCode = grdReceivedRequest.GetItemValue(curRowNumber, "req_hospital").ToString().Trim();
            string gwa = grdReceivedRequest.GetItemValue(curRowNumber, "reg_gwa").ToString().Trim();
            string bunho = grdReceivedRequest.GetItemValue(curRowNumber, "bunho").ToString().Trim();
            if (!String.IsNullOrEmpty(hospCode) && !String.IsNullOrEmpty(bunho))
            {
                OCSO.EmrRefer emrRefer = new EmrRefer(hospCode, gwa, bunho, "", GetPatientModel(bunho));
                emrRefer.Text = String.Format(Resources.EMRREFER, hospCode);
                emrRefer.ShowDialog();
            }
        }

        private void dpkReq_date_DataValidating(object sender, DataValidatingEventArgs e)
        {
            btnList.PerformClick(FunctionType.Query);
        }

        #endregion

        #region Cloud service

        private IList<object[]> QueryFdwCommon(BindVarCollection bc)
        {
            IList<object[]> dataList = new List<object[]>();
            if (_findMode == "fbxHospital") //Load linking hospital of patient selected
            {
                OCS2016U00GetShardingHospitalArgs args = new OCS2016U00GetShardingHospitalArgs();
                args.HospCode = "%";

                ComboResult result = CloudService.Instance.Submit<ComboResult, OCS2016U00GetShardingHospitalArgs>(args);

                if (result.ExecutionStatus == ExecutionStatus.Success)
                {
                    IList<ComboListItemInfo> listItem = result.ComboItem;

                    foreach (ComboListItemInfo item in listItem)
                    {
                        object[] objects =
                            {
                            item.Code,
                            item.CodeName
                            };
                        dataList.Add(objects);
                    }
                }
            }
            else if (_findMode == "fbxConsult_gwa") //Load linking department of linking hospital selected
            {
                OCS2016GetLinkingDepartmentArgs args = new OCS2016GetLinkingDepartmentArgs();
                args.Find1 = "";
                args.HospCode = _consultHospCode;
                OCS2016GetLinkingDepartmentResult res = CloudService.Instance.Submit<OCS2016GetLinkingDepartmentResult, OCS2016GetLinkingDepartmentArgs>(args);
                if (res != null)
                {
                    List<OCS2016GetLinkingDepartmentInfo> departmentList = res.DepartmentInfo;
                    foreach (OCS2016GetLinkingDepartmentInfo info in departmentList)
                    {
                        dataList.Add(new object[]
                        {
                            info.DepartmentCode,
                            info.DepartmentName
                        });
                    }
                }
            }
            else if (_findMode == "xfbGwaTab3") //Load linking department of linking hospital selected
            {
                OCS2016GetUserDepartmentArgs args = new OCS2016GetUserDepartmentArgs();
                args.Find1 = "";
                args.HospCode = UserInfo.HospCode;
                OCS2016GetUserDepartmentResult res = CloudService.Instance.Submit<OCS2016GetUserDepartmentResult, OCS2016GetUserDepartmentArgs>(args);
                if (res != null)
                {
                    List<OCS2016GetUserDepartmentInfo> departmentList = res.DepartmentInfo;
                    foreach (OCS2016GetUserDepartmentInfo info in departmentList)
                    {
                        dataList.Add(new object[]
                        {
                            info.DepartmentCode,
                            info.DepartmentName
                        });
                    }
                }
            }

            else if (_findMode == "xfbgwa") //Load linking department of linking hospital selected
            {
                OCS2016GetUserDepartmentArgs args = new OCS2016GetUserDepartmentArgs();
                args.Find1 = "";
                args.HospCode = UserInfo.HospCode;
                OCS2016GetUserDepartmentResult res = CloudService.Instance.Submit<OCS2016GetUserDepartmentResult, OCS2016GetUserDepartmentArgs>(args);
                if (res != null)
                {
                    List<OCS2016GetUserDepartmentInfo> departmentList = res.DepartmentInfo;
                    foreach (OCS2016GetUserDepartmentInfo info in departmentList)
                    {
                        dataList.Add(new object[]
                        {
                            info.DepartmentCode,
                            info.DepartmentName
                        });
                    }
                }
            }
            else//Load requested doctor of department selected
            {
                if (string.IsNullOrEmpty(_consultDepartment))
                    return dataList;
                PatientLinkingFwkDoctorArgs args = new PatientLinkingFwkDoctorArgs();
                args.Gwa = fbxConsult_gwa.GetDataValue();
                args.HospCode = this._consultHospCode;

                PatientLinkingFwkDoctorResult result = CloudService.Instance.Submit<PatientLinkingFwkDoctorResult, PatientLinkingFwkDoctorArgs>(args);

                if (result != null)
                {
                    IList<PatientLinkingFwkDoctorInfo> listItem = result.DoctorList;

                    foreach (PatientLinkingFwkDoctorInfo item in listItem)
                    {

                        object[] objects =
                        {
                            item.DoctorCode, 
                            item.DoctorName 
                        };
                        dataList.Add(objects);
                    }
                }
            }
            return dataList;
        }

        private IList<object[]> GetQuestionData(BindVarCollection bc)
        {
            IList<object[]> dataList = new List<object[]>();
            OCS2016U00GrdQuestionArgs args = new OCS2016U00GrdQuestionArgs();
            args.QuestionType = GetQuestionType();
            args.HospCode = UserInfo.HospCode;
            args.Doctor = UserInfo.UserID;
            args.Datetime = TypeCheck.IsDateTime(dpkReq_date.GetDataValue()) ? dpkReq_date.GetDataValue().ToString() : DateTime.Now.ToString();
            if (rbnDepartmentReq.Checked) args.Gwa = xfbGwaTab3.GetDataValue().ToString().Trim();

            OCS2016U00GrdQuestionResult result = CloudService.Instance.Submit<OCS2016U00GrdQuestionResult, OCS2016U00GrdQuestionArgs>(args);

            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                IList<OCS2016U00GrdQuestionInfo> listItem = result.ListQuestionInfo;

                foreach (OCS2016U00GrdQuestionInfo item in listItem)
                {
                    if (_tabIndex == 0)
                    {
                        object[] objects =
                            {
                                item.Bunho,
                                item.ReqDate,
                                item.ConsultHospCode,
                                item.ConsultGwaName,
                                item.ConsultDoctor,
                                item.ConsultDate,
                                item.GrpQuestionId,
                                item.ConsultHospName,
                                item.ConsultDoctorName,
                                item.FinishYn,
                                "",
                                item.ReqGwa,
                                item.ReqGwaName,
                                item.ConsultGwa,
                                GetQuestionStatus(item.Status)
                            };
                        dataList.Add(objects);
                    }
                    else
                    {
                        object[] objects =
                            {
                                item.Bunho,
                                item.ConsultDate,
                                item.HospCode,
                                item.ReqGwaName,
                                item.ReqDoctor,
                                item.ReqDate,
                                item.GrpQuestionId,
                                item.ReqHospitalName,
                                item.ReqDoctorName,
                                item.FinishYn,
                                "",
                                item.ConsultGwa,
                                item.ConsultGwaName,
                                item.ReqGwa,
                                GetQuestionStatus(item.Status)
                            };
                        dataList.Add(objects);

                    }
                }
            }
            return dataList;
        }

        private List<OCS2016U00LoadDiscussionInfo> LoadDiscussionData()
        {
            OCS2016U00LoadDiscussionArgs args = new OCS2016U00LoadDiscussionArgs();
            args.GrpQuestionId = GetQuestionGrpId();
            OCS2016U00LoadDiscussionResult res = CloudService.Instance.Submit<OCS2016U00LoadDiscussionResult, OCS2016U00LoadDiscussionArgs>(args);
            if (res != null)
            {
                return res.ItemDiscussionInfo;
            }
            return new List<OCS2016U00LoadDiscussionInfo>();
        }

        #endregion

        #region SaveLayout

        private List<string> GetListDataForSaveLayout()
        {
            List<string> lstData = new List<string>();
            if (grdSentRequest.DeletedRowTable != null)
            {
                for (int i = 0; i < grdSentRequest.DeletedRowTable.Rows.Count; i++)
                {
                    lstData.Add(grdSentRequest.DeletedRowTable.Rows[i]["grp_question_id"].ToString());
                }
            }
            return lstData;
        }

        private List<OCS2016U00QuestionSaveLayoutInfo> GetQuestionDataForSaveLayout()
        {
            List<OCS2016U00QuestionSaveLayoutInfo> lstData = new List<OCS2016U00QuestionSaveLayoutInfo>();

            bool isAdded = false;
            for (int i = 0; i < this.grdSentRequest.RowCount; i++)
            {
                if (grdSentRequest.GetRowState(i) == DataRowState.Added || grdSentRequest.GetRowState(i) == DataRowState.Modified)
                {
                    isAdded = grdSentRequest.GetRowState(i) == DataRowState.Added;
                    OCS2016U00QuestionSaveLayoutInfo item = new OCS2016U00QuestionSaveLayoutInfo();
                    item.Bunho = isAdded ? pbxRequest_bunho.BunHo : grdSentRequest.GetItemString(i, "bunho");
                    item.ReqDate = string.IsNullOrEmpty(grdSentRequest.GetItemString(i, "req_date")) ? dpkReq_date.GetDataValue() : grdSentRequest.GetItemString(i, "req_date");
                    item.ConsultHospCode = grdSentRequest.GetItemString(i, "consult_clinic");
                    item.ConsultGwa = isAdded ? fbxConsult_gwa.GetDataValue() : grdSentRequest.GetItemString(i, "consult_gwa");
                    item.ConsultDoctor = isAdded ? fbxConsult_doctor.GetDataValue() : grdSentRequest.GetItemString(i, "consult_doctor");
                    item.GrpQuestionId = grdSentRequest.GetItemString(i, "grp_question_id");
                    item.FinishYn = cbxFinishDiscuss.Checked ? "Y" : "N";
                    item.Content = isAdded ? grdViewDiscuss.GetDataRow(0)["Content"].ToString() : grdSentRequest.GetItemString(i, "content");
                    item.ReqGwa = isAdded ? xfbgwa.GetDataValue().ToString().Trim() : grdSentRequest.GetItemString(i, "reg_gwa");
                    item.DataRowState = grdSentRequest.GetRowState(i).ToString();
                    if (TypeCheck.IsNull(item.ConsultHospCode) || TypeCheck.IsNull(item.ConsultGwa) || TypeCheck.IsNull(item.ConsultDoctor))
                        continue;
                    lstData.Add(item);
                }
            }

            if (grdSentRequest.DeletedRowTable != null && grdSentRequest.DeletedRowTable.Rows.Count > 0)
            {
                for (int i = 0; i < grdSentRequest.DeletedRowTable.Rows.Count; i++)
                {
                    OCS2016U00QuestionSaveLayoutInfo item = new OCS2016U00QuestionSaveLayoutInfo();
                    item.GrpQuestionId = Convert.ToString(grdSentRequest.DeletedRowTable.Rows[i]["grp_question_id"]);
                    item.DataRowState = DataRowState.Deleted.ToString();
                    lstData.Add(item);
                }
            }
            return lstData;
        }
        #endregion

        #region Common

        private void QuestionDataDetailBinData()
        {
            FbxPatientCodeSetData();
            List<OCS2016U00LoadDiscussionInfo> discussionData = LoadDiscussionData();

            DataTable dtDiscussionData = new DataTable();
            dtDiscussionData.Columns.Add("DoctorName", typeof(string));
            dtDiscussionData.Columns.Add("Content", typeof(string));
            dtDiscussionData.Columns.Add("Updated", typeof(string));
            dtDiscussionData.Columns.Add("EditedFlag", typeof(object));
            dtDiscussionData.Columns.Add("GrpQuestionID", typeof(string));
            dtDiscussionData.Columns.Add("UserId", typeof(string));
            dtDiscussionData.Columns.Add("dataRowState", typeof(string));
            dtDiscussionData.Columns.Add("DiscussionId", typeof(string));

            Image iconImg = Image.FromFile(Environment.CurrentDirectory + "\\Images\\edit.ico");

            foreach (OCS2016U00LoadDiscussionInfo item in discussionData)
            {
                dtDiscussionData.Rows.Add(item.DoctorName, item.Content, item.Updated, UserInfo.UserID == item.Doctor ? iconImg : null, item.GrpQuestionId, item.Doctor, "Unchanged", item.DiscussionId);
            }
            gridDiscussContent.DataSource = dtDiscussionData;
            gridDiscussContent.RefreshDataSource();
        }

        private void InitData()
        {
            btnEmrRefer.Visible = false;
            ControlPanelUpdateStatus();
            grdSentRequest.ExecuteQuery = GetQuestionData;
            grdReceivedRequest.ExecuteQuery = GetQuestionData;
            dpkReq_date.IsJapanYearType = NetInfo.Language == LangMode.Jr;
            xlbTab3.Visible = rbnDepartmentReq.Checked;
            xfbGwaTab3.Visible = rbnDepartmentReq.Checked;
            xdbTab3.Visible = rbnDepartmentReq.Checked;
            dpkReq_date.SetDataValue(DateTime.Now);
            grdSentRequest.Focus();
            btnList.PerformClick(FunctionType.Query);
        }

        private void QuestionProcessing()
        {
            OCS2016U00QuestionSaveLayoutArgs args = new OCS2016U00QuestionSaveLayoutArgs();
            args.QuestionType = GetQuestionType();
            args.QuestionList = GetQuestionDataForSaveLayout();
            args.DiscussionList = GetDiscussionList();

            if (args.QuestionList.Count <= 0 && args.DiscussionList.Count <= 0)
            {
                XMessageBox.Show("　左枠でマウスをクリックしてから、「入力」ボタンを押して入力行を追加してください。 ", "");
                return;
            }

            UpdateResult res = CloudService.Instance.Submit<UpdateResult, OCS2016U00QuestionSaveLayoutArgs>(args);
            if (res != null)
            {
                grdSentRequest.Focus();
                grdSentRequest.ResetUpdate();
                btnList.PerformClick(FunctionType.Query);
            }
            _isUpdateDiscussion = false;
        }

        private List<OCS2016U00LoadDiscussionInfo> GetDiscussionList()
        {
            List<OCS2016U00LoadDiscussionInfo> lstData = new List<OCS2016U00LoadDiscussionInfo>();

            
            for (int i = 0; i < this.grdViewDiscuss.RowCount; i++)
            {
                if (grdViewDiscuss.GetDataRow(i)["dataRowState"].Equals("Modified") || grdViewDiscuss.GetDataRow(i)["dataRowState"].Equals("Added"))
                {
                    OCS2016U00LoadDiscussionInfo item = new OCS2016U00LoadDiscussionInfo();
                    item.DataRowState = (grdViewDiscuss.GetDataRow(i)["dataRowState"]).ToString();
                    item.Content = grdViewDiscuss.GetDataRow(i)["Content"].ToString();
                    item.DiscussionId = grdViewDiscuss.GetDataRow(i)["DiscussionId"].ToString();
                    item.DoctorName = grdViewDiscuss.GetDataRow(i)["UserId"].ToString();
                    item.EditedFlg = grdViewDiscuss.GetDataRow(i)["EditedFlag"].ToString();
                    item.GrpQuestionId = grdViewDiscuss.GetDataRow(i)["GrpQuestionID"].ToString();
                    item.Updated = grdViewDiscuss.GetDataRow(i)["Updated"].ToString();
                    item.Doctor = UserInfo.UserID;
                    lstData.Add(item);
                }
            }

            //if (!string.IsNullOrEmpty(txtContent.Text) && !_isUpdateDiscussion)
            //{
            //    item.DataRowState = "Added";
            //    item.Content = txtContent.Text;
            //    item.DiscussionId = "";
            //    item.Doctor = UserInfo.UserID;
            //    item.DoctorName = UserInfo.UserName;
            //    item.EditedFlg = "N";
            //    item.GrpQuestionId = _tabIndex == 0 ? grdSentRequest.GetItemString(grdSentRequest.CurrentRowNumber, "grp_question_id") : grdReceivedRequest.GetItemString(grdReceivedRequest.CurrentRowNumber, "grp_question_id");
            //    item.Updated = DateTime.Now.ToString();
            //    lstData.Add(item);
            //}

            return lstData;
        }

        private void BtnListSetStatus(bool isActive)
        {
            btnList.SetEnabled(FunctionType.Insert, isActive);
            btnList.SetEnabled(FunctionType.Delete, isActive);
        }

        private void ControlPanelActive(bool isActive)
        {
            grdReceivedRequest.Visible = !isActive;
            grdSentRequest.Visible = isActive;
            cbxFinishDiscuss.Visible = isActive;
            pnlTab1Info.Visible = isActive;
            btnEmrRefer.Visible = !isActive;
            xlbTab3.Visible = rbnDepartmentReq.Checked;
            xfbGwaTab3.Visible = rbnDepartmentReq.Checked;
            xdbTab3.Visible = rbnDepartmentReq.Checked;
            pnlDiscussInfo.Visible = isActive;
        }

        private void ControlPanelUpdateStatus()
        {
            if (!string.IsNullOrEmpty(_bunho))
            {
                fbxHospital.Enabled = true;
                if (string.IsNullOrEmpty(fbxHospital.GetDataValue().ToString().Trim()))
                {
                    fbxConsult_gwa.Enabled = false;
                    fbxConsult_doctor.Enabled = false;
                }
                else
                {
                    fbxConsult_gwa.Enabled = true;
                    if (string.IsNullOrEmpty(fbxConsult_gwa.GetDataValue().ToString().Trim()))
                        fbxConsult_doctor.Enabled = false;
                    else
                        fbxConsult_doctor.Enabled = true;
                }
            }
            else
            {
                fbxHospital.Enabled = false;
                fbxConsult_gwa.Enabled = false;
                fbxConsult_doctor.Enabled = false;
                ResetControlpanelData();
            }
        }

        private void ResetControlpanelData()
        {
            dbxHospital.Text = string.Empty;
            fbxHospital.Clear();
            dbxConsult_gwa_name.Text = string.Empty;
            fbxConsult_gwa.Clear();
            dbxConsult_doctor_name.Text = string.Empty;
            fbxConsult_doctor.Clear();

            fbxHospital.Clear();
            dbxConsult_gwa_name.Text = string.Empty;
            dbxConsult_doctor_name.Text = string.Empty;
            dbxHospital.Text = string.Empty;
        }

        private void FbxPatientCodeSetData()
        {
            pbxRequest_bunho.SetPatientID(grdSentRequest.GetItemString(grdSentRequest.CurrentRowNumber, "bunho"));
        }

        private string Find_AddedRowState()
        {

            switch (_tabIndex)
            {
                case 0:
                    for (int i = 0; i < this.grdSentRequest.RowCount; i++)
                    {
                        if (this.grdSentRequest.LayoutTable.Rows[i].RowState == DataRowState.Added)
                            return "Y";
                    }
                    break;
                case 1:
                    for (int i = 0; i < this.grdReceivedRequest.RowCount; i++)
                    {
                        if (this.grdReceivedRequest.LayoutTable.Rows[i].RowState == DataRowState.Added)
                            return "Y";
                    }
                    break;
                case 2:

                    break;
            }
            return "N";
        }

        public PatientModelInfo GetPatientModel(string bunho)
        {
            PatientModelInfo patient = new PatientModelInfo();
            patient.PatientId = bunho;
            return patient;
        }

        #endregion

        #region Functions

        private void ReplyProcessing()
        {
            OCS2016U00UpdateReplyArgs args = new OCS2016U00UpdateReplyArgs();
            args.DiscussionList = GetDiscussionList();

            UpdateResult res = CloudService.Instance.Submit<UpdateResult, OCS2016U00UpdateReplyArgs>(args);
            if (res != null)
            {
                grdReceivedRequest.Focus();
                grdReceivedRequest.ResetUpdate();
                btnList.PerformClick(FunctionType.Query);
            }
        }

        private string GetQuestionType()
        {
            string ret = string.Empty;
            switch (_tabIndex)
            {
                case 0:
                    ret = "SENT";
                    break;
                case 1:
                    ret = "RECEIVED";
                    break;
                case 2:
                    ret = "DEPARMENT";
                    break;
            }
            return ret;
        }

        private string GetQuestionGrpId()
        {
            string grpQuestionId = string.Empty;
            if (_tabIndex == 0)
                grpQuestionId = grdSentRequest.GetItemString(grdSentRequest.CurrentRowNumber, "grp_question_id");
            else
                grpQuestionId = grdReceivedRequest.GetItemString(grdReceivedRequest.CurrentRowNumber, "grp_question_id");

            return grpQuestionId;
        }

        private string GetQuestionStatus(string status)
        {
            if (string.IsNullOrEmpty(status))
                return "";
            string ret = string.Empty;
            switch (status)
            {
                case "1":
                    ret = Resources.QuestionStatus1;//"新質問";
                    break;
                case "2":
                    ret = Resources.QuestionStatus2;//"回答済み";
                    break;
                case "3":
                    ret = Resources.QuestionStatus3;//"新返信";
                    break;
                default:
                    break;
            }
            return ret;
        }
        #endregion

        private void grdReceivedRequest_RowFocusChanged(object sender, RowFocusChangedEventArgs e)
        {
            QuestionDataDetailBinData();
        }

        private void ResetGridDiscussion()
        {
            gridDiscussContent.DataSource = null;
            gridDiscussContent.RefreshDataSource();
        }

        private void cbxFinishDiscuss_CheckedChanged(object sender, EventArgs e)
        {
            grdSentRequest.SetItemValue(grdSentRequest.CurrentRowNumber, "finish_discuss_yn", cbxFinishDiscuss.Checked ? "Y" : "N");
        }

        private void grdViewDiscuss_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            //GridView view = sender as GridView;
            //if (view != null)
            //{
            //    for (int i = 0; i < view.RowCount; i++)
            //    {
            //        if (i % 2 == 0)
            //            e.Appearance.BackColor = Color.SkyBlue;
            //    }
            //}
        }

        private void grdViewDiscuss_RowStyle(object sender, RowStyleEventArgs e)
        {
            //GridView view = sender as GridView;
            //if (view != null)
            //{
            //    for (int i = 0; i < view.RowCount; i++)
            //    {
            //        if (i % 2 == 0)
            //            e.Appearance.BackColor = Color.SkyBlue;
            //    }
            //}
        }

        private bool IsExistFwkData(string _findMode, string data)
        {
            if (TypeCheck.IsNull(data))
                return false;
            if (_findMode == "fbxHospital")
            {
                OCS2016U00GetShardingHospitalArgs args = new OCS2016U00GetShardingHospitalArgs();
                args.HospCode = "%";

                ComboResult result = CloudService.Instance.Submit<ComboResult, OCS2016U00GetShardingHospitalArgs>(args);

                if (result.ExecutionStatus == ExecutionStatus.Success)
                    foreach (ComboListItemInfo item in result.ComboItem)
                        if (item.Code.Equals(data)) return true;
            }
            else if (_findMode == "fbxConsult_gwa")
            {
                OCS2016GetLinkingDepartmentArgs args = new OCS2016GetLinkingDepartmentArgs();
                args.Find1 = "";
                args.HospCode = _consultHospCode;
                OCS2016GetLinkingDepartmentResult res = CloudService.Instance.Submit<OCS2016GetLinkingDepartmentResult, OCS2016GetLinkingDepartmentArgs>(args);
                if (res != null)
                {
                    foreach (OCS2016GetLinkingDepartmentInfo item in res.DepartmentInfo)
                        if (item.DepartmentCode.Equals(data)) return true;
                }
            }
            else if (_findMode == "xfbGwaTab3")
            {
                OCS2016GetUserDepartmentArgs args = new OCS2016GetUserDepartmentArgs();
                args.Find1 = "";
                args.HospCode = UserInfo.HospCode;
                OCS2016GetUserDepartmentResult res = CloudService.Instance.Submit<OCS2016GetUserDepartmentResult, OCS2016GetUserDepartmentArgs>(args);
                if (res != null)
                    foreach (OCS2016GetUserDepartmentInfo item in res.DepartmentInfo)
                    {
                        if (item.DepartmentCode.Equals(data)) return true;
                    }
            }

            else if (_findMode == "xfbgwa")
            {
                OCS2016GetUserDepartmentArgs args = new OCS2016GetUserDepartmentArgs();
                args.Find1 = "";
                args.HospCode = UserInfo.HospCode;
                OCS2016GetUserDepartmentResult res = CloudService.Instance.Submit<OCS2016GetUserDepartmentResult, OCS2016GetUserDepartmentArgs>(args);
                if (res != null)
                    foreach (OCS2016GetUserDepartmentInfo item in res.DepartmentInfo)
                    {
                        if (item.DepartmentCode.Equals(data)) return true;
                    }
            }
            else
            {
                PatientLinkingFwkDoctorArgs args = new PatientLinkingFwkDoctorArgs();
                args.Gwa = fbxConsult_gwa.GetDataValue();
                args.HospCode = this._consultHospCode;

                PatientLinkingFwkDoctorResult result = CloudService.Instance.Submit<PatientLinkingFwkDoctorResult, PatientLinkingFwkDoctorArgs>(args);

                if (result != null)
                    foreach (PatientLinkingFwkDoctorInfo item in result.DoctorList)
                    {
                        if (item.DoctorCode.Equals(data)) return true;
                    }
            }

            return false;
        }

        private void grdViewDiscuss_ShowingEditor(object sender, CancelEventArgs e)
        {
            int rowId= grdViewDiscuss.FocusedRowHandle;
            if (grdViewDiscuss.FocusedColumn.FieldName == "Content" && grdViewDiscuss.GetDataRow(rowId)["userId"].ToString() == UserInfo.UserID)
                {
                    if (grdViewDiscuss.GetDataRow(rowId)["dataRowState"].ToString() != "Added")
                        grdViewDiscuss.SetRowCellValue(rowId, "dataRowState", "Modified");
                }
                else
                    e.Cancel = true;
        }

        private void grdViewDiscuss_Click(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            for (int i = 0; i < this.grdViewDiscuss.RowCount; i++)
            {
                if (grdViewDiscuss.GetDataRow(i)["dataRowState"].Equals("Added"))
                {
                    return;
                }
            }


            Point pt = view.GridControl.PointToClient(Control.MousePosition);

            GridHitInfo info = view.CalcHitInfo(pt);
            if (!info.InRow && !info.InRowCell)
            {
                if ((_tabIndex == 0 || _tabIndex == 2) && grdSentRequest.RowCount > 0)
                {

                    CreatNewRow();
                }
                if (_tabIndex == 1 && grdReceivedRequest.RowCount > 0)
                {
                    CreatNewRow();
                }
            }
        }
        //MED-10593 -- add height when press enter
        private void gridDiscussContent_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                grdViewDiscuss.ShowEditor();
                e.Handled = true;
                MemoEdit editor = grdViewDiscuss.ActiveEditor as MemoEdit;
                if (editor != null)
                {
                    editor.SelectionStart = editor.Text.Length;
                    if (editor.Height < 80) editor.Height = ((editor.Lines.Length +1) * 24);
                }
            }
        }

    }
}
