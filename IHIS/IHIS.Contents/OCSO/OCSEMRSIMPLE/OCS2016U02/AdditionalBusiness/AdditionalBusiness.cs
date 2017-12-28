using System;
using System.Collections.Generic;
using DevExpress.XtraBars.Docking;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Arguments.OcsEmr;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.OcsEmr;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.Framework;

namespace IHIS.OCSO.AdditionalBusiness
{
    using DevExpress.XtraTreeList.Nodes;

    /// <summary>
    /// This class handling requirement updates mentioned in BD 20150520
    /// </summary>
    internal static class AdditionalBusiness
    {
        #region OCS2015U02
        /// <summary>
        /// Re-enable Editor and Order each time reload data
        /// </summary>
        /// <param name="editorPanel"></param>
        /// <param name="orderPanel"></param>
        public static void ReEnableEditorAndOrder(DockPanel editorPanel, DockPanel orderPanel)
        {
            editorPanel.Enabled = true;
            orderPanel.Enabled = true;
        }

        /// <summary>
        /// OCS2015U02 behaviors when double click to a date
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="ctlEmrDocker">OCS2015U00.ctlEmrDocker</param>
        /// <param name="tvExamHist">OCS2015U00.tvExamHist</param>
        /// <param name="cldExamDates">OCS2015U00.cldExamDates</param>
        public static void CalendarBehavior(object sender, XCalendarDayClickEventArgs e, EmrDocketS ctlEmrDocker, OCS2015U03C tvExamHist, OCS2015U02S cldExamDates)
        {
            List<NuroPatientReceptionHistoryListItemInfo> examList;
            int numOfExams = CheckNumberOfRequestInSelectedDate(e.DateItem.Date, out examList, cldExamDates);
            //TODO: so request kham = 1
            if (numOfExams == 1)
            {
                DateTime sysDate = EnvironInfo.GetSysDate();
                DateTime calendarDate = e.DateItem.Date;
                if ((calendarDate - new DateTime(1970, 1, 1).ToLocalTime()).TotalSeconds <
                    (sysDate - new DateTime(1970, 1, 1).ToLocalTime()).TotalSeconds)
                {
                    ctlEmrDocker.ActiveChildControl("1");
                    ctlEmrDocker.dockPanel2.Enabled = false;
                    ctlEmrDocker.dockPanel3.Enabled = false;
                }
                else
                {
                    //TODO: check doctor who created this record, if yes enable EmrEditor and Orders tab, if no disable both
                    if (examList[0].Doctor.Equals(UserInfo.UserName))
                    {
                        ctlEmrDocker.ActiveChildControl("2");
                        ctlEmrDocker.dockPanel2.Enabled = true;
                        ctlEmrDocker.dockPanel3.Enabled = true;
                    }
                    else
                    {
                        ctlEmrDocker.ActiveChildControl("1");
                        ctlEmrDocker.dockPanel2.Enabled = false;
                        ctlEmrDocker.dockPanel3.Enabled = false;
                    }
                }

                //string examDate = e.DateItem.Date.ToString("yyyy/MM/dd").Trim();
                //ctlEmrDocker.Viewer.GotoRecord(examDate, "");
                //ctlEmrDocker.Viewer.ucGrid1.ScrollToDate(examDate, "");
            }
            string examDate = e.DateItem.Date.ToString("yyyy/MM/dd").Trim();
            ctlEmrDocker.Viewer.ucGrid1.ScrollToDate(examDate, "");

            //TODO: so request kham > 1, uu tien focus vao ngay kham cua department cua user
            if (numOfExams > 1)
            {
                foreach (TreeListNode dateNode in tvExamHist.TvHisExam.Nodes)
                {
                    if (dateNode.GetValue("NaewonDate") != null && dateNode.GetValue("NaewonDate").Equals(e.DateItem.Date.ToString("yyyy/MM/dd")))
                    {
                        tvExamHist.TvHisExam.FocusedNode = dateNode;
                    }
                }
            }
        }

        /// <summary>
        /// Return number of exam requests at specific date
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        private static int CheckNumberOfRequestInSelectedDate(DateTime dateTime, out List<NuroPatientReceptionHistoryListItemInfo> examList, OCS2015U02S cldExamDates)
        {
            int res = 0;
            examList = new List<NuroPatientReceptionHistoryListItemInfo>();

            foreach (NuroPatientReceptionHistoryListItemInfo emrRecordInfo in cldExamDates.ReceptHisList)
            {
                if (emrRecordInfo.ExamDate.Substring(0, 10) == dateTime.ToString("yyyy-MM-dd"))
                {
                    res += 1;
                    examList.Add(emrRecordInfo);
                }
            }

            return res;
        }
        #endregion

        #region OCS2015U44
        /// <summary>
        /// Implement business logic when click button Save in OCS2015U00 screen
        /// </summary>
        /// <param name="ctlU44">Reference to OCS2015U44 control</param>
        /// <param name="reason">Reason why it returns false</param>
        /// <param name="metadata">Document metadata</param>
        /// <param name="updId">User ID who made changes</param>
        /// <returns>Save success or not</returns>
        /*public static bool Save(OCS2015U44 ctlU44, string emrRecordId, out string reason, OCS2015U42 ctlU42, string metadata, string updId)
        {
            bool success = false;
            reason = "ERROR";
            //TODO: Show OCS2015U42 popup
            System.Windows.Forms.DialogResult dialogResult = ctlU42.ShowDialog();
            string emailFlg = ctlU42.EmailCheckBox.Checked ? "1" : "0";
            //If user click Yes
            if (dialogResult == DialogResult.OK)
            {
                //Implement save logic here
                //return SaveHistoricRecord(ctlU44.Editor, emrRecordId, out reason, ctlU42.TxtRecordLog.Text, metadata, updId, emailFlg);
            }
            // user click No
            else if (dialogResult == DialogResult.Cancel)
            {
                CancelSaving(emrRecordId, updId);
                reason = "USER CANCELLED";
                success = false;
            }
            return success;
        }*/

        /// <summary>
        /// Cancel EMR record saving and unlock the record
        /// </summary>
        /// <param name="emrRecordId">EMR record ID</param>
        public static void CancelSaving(string emrRecordId, string updId)
        {
            //TODO: unlock record, need proto here
            if (CloudService.Instance.Connect())
            {
                OCS2015U00EmrRecordUnlockArgs args = new OCS2015U00EmrRecordUnlockArgs();
                args.RecordId = emrRecordId;
                args.UpdId = updId;
                args.ScreenId = "OCS2015U06";
                UpdateResult res =
                    CloudService.Instance.Submit<UpdateResult, OCS2015U00EmrRecordUnlockArgs>(args);
                if (res.ExecutionStatus == ExecutionStatus.Success)
                {
                    if (res.Result)
                    {
                    }
                    else
                    {
                    }
                }
            }

            //Case 1: Valid current user = UPD_ID, timeout in-range
            //Case 2: Valid current user = UPD_ID, timeout out-range

            //Case 3,4 occur when another user successfully grab lock because of current user has timed out
            //Case 3: Invalid current user != UPD_ID, timeout in-range
            //Case 4: Invalid current user != UPD_ID, timeout out-range
        }
        #endregion

        #region OCS2015U42

        #endregion

        #region Common
        /// <summary>
        /// Lock the record for edit action
        /// </summary>
        /// <param name="emrRecordId">EMR record ID</param>
        /// <param name="reason">Reason why it fails to grab lock</param>
        /// <param name="startTime">Moment when grab lock successfully</param>
        /// <returns>Success or not</returns>
        public static bool BeginEditing(string emrRecordId, out string reason, ref DateTime startTime)
        {
            bool success = false;
            reason = "ERROR";
            if (CloudService.Instance.Connect())
            {
                OCS2015U00EmrRecordLockArgs args = new OCS2015U00EmrRecordLockArgs();
                UpdateResult res =
                    CloudService.Instance.Submit<UpdateResult, OCS2015U00EmrRecordLockArgs>(args);
                if (res.ExecutionStatus == ExecutionStatus.Success)
                {
                    if (res.Result)
                    {
                        reason = "SUCCESS";
                        success = true;
                    }
                    else
                    {
                        reason = "SERVER FAILED";
                        success = false;
                    }
                }
            }
            //Grab lock successfully
            if (success)
            {
                startTime = DateTime.Now;
            }
            else
            {
                startTime = DateTime.Now;
            }

            return success;
        }

        /// <summary>
        /// Check timeout
        /// </summary>
        /// <param name="startTime">Start time</param>
        /// <param name="timeoutSpan">Timeout range</param>
        /// <returns>Current time valid or not</returns>
        public static bool CheckTimeout(DateTime startTime, TimeSpan timeoutSpan, DateTime currentTime)
        {
            bool valid = false;
            valid = currentTime >= (startTime + timeoutSpan) ? false : true;
            return valid;
        }

        /// <summary>
        /// Get timeout span from server
        /// </summary>
        /// <returns>timeout span</returns>
        public static TimeSpan GetTimeoutSpan()
        {
            TimeSpan ts = TimeSpan.FromMinutes(0);
            if (CloudService.Instance.Connect())
            {
                OCS2015U00EmrGetTimeoutSpanArgs args = new OCS2015U00EmrGetTimeoutSpanArgs();
                OCS2015U00EmrGetTimeoutSpanResult res =
                    CloudService.Instance.Submit<OCS2015U00EmrGetTimeoutSpanResult, OCS2015U00EmrGetTimeoutSpanArgs>(args);
                if (res.ExecutionStatus == ExecutionStatus.Success)
                {
                    try
                    {
                        ts = TimeSpan.FromMinutes(double.Parse(res.Timespan));
                    }
                    catch (Exception)
                    {
                        ts = TimeSpan.FromMinutes(0);
                    }
                }
            }
            return ts;
        }


        #endregion

    }
}
