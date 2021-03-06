using System;
using System.IO;
using System.Text;
using System.Drawing;
using System.Xml;
using System.Threading;
using System.Xml.XPath;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Configuration;

namespace IHIS.Framework
{
	/// <summary>
	/// SystemExceptionHandler에 대한 요약 설명입니다.
	/// </summary>
	public class SystemExceptionHandler
	{
        private string _errMsg = "";

		// Handles the exception event.
		public void OnThreadException(object sender, ThreadExceptionEventArgs e) 
		{
			DialogResult result = DialogResult.Cancel;
			try
			{
                // https://sofiamedix.atlassian.net/browse/MED-10333
                _errMsg = "";

                if (NetInfo.Language == LangMode.En)
                {
                    _errMsg += "You can either restart the application (recommended), " + Environment.NewLine;
                    _errMsg += "\t or ignore the error and continue in work (be aware, this might bring the application in an inconsistent state)." + Environment.NewLine;
                    _errMsg += "If this problem persists, please contact KCCK technical support at:" + Environment.NewLine;
                }
                else if (NetInfo.Language == LangMode.Jr)
                {
                    _errMsg += "処理を中断してシステムの再起動を行うか、";
                    _errMsg += "エラーを無視して処理を継続してください。";
                    _errMsg += "作業中のデータは保存されていない可能性があります。";
                    _errMsg += "このエラーが繰り返し表示される場合は、エラーの内容を";
                    _errMsg += "ハードコピーして、KCCKサポートセンタまでご連絡ください。";
                }
                else if (NetInfo.Language == LangMode.Vi)
                {
                    _errMsg += "Hãy khởi động lại hệ thống (được khuyến cáo),";
                    _errMsg += " \t hoặc có thể bỏ qua lỗi và tiếp tục (điều này có thể khiến dữ liệu của bạn bị mất trong một số trường hợp)." + Environment.NewLine;
                    _errMsg += "Nếu lỗi này xuất hiện liên tục, hãy liên hệ với trung tâm hỗ trợ KCCK tại: " + Environment.NewLine;
                }

				result = this.ShowThreadExceptionDialog(e.Exception);
			}
			catch (Exception ex)
			{
                // Description
                string description = SetErrDescription(ex);

				try
				{
					//MessageBox.Show("Fatal Error", "Fatal Error", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Stop);

                    // Force to exit application
                    ErrorLogForm dlg = new ErrorLogForm(_errMsg, description);
                    dlg.ShowDialog();
                    dlg.Dispose();

                    if (dlg.DialogResult == DialogResult.OK)
                    {
                        Application.Exit();
                    }
				}
				finally
				{
					//Application.Exit();
				}
			}

			// Exits the program when the user clicks 종료
			if (result == DialogResult.OK) 
				Application.Exit();
		}
 
		// Creates the error message and displays it.
		private DialogResult ShowThreadExceptionDialog(Exception e) 
		{
			try
			{
                //errMsg = XMsg.GetMsg("M039") + " : " + e.Message + "\n";  //"에러 : " + e.Message + "\n";
                //if (e.TargetSite != null)
                //{
                //    if (e.TargetSite.DeclaringType != null)
                //        errMsg += XMsg.GetMsg("M040") + " : " + e.TargetSite.DeclaringType.ToString() + "\n"; //에러 발생 객체 : " + e.TargetSite.DeclaringType.ToString() + "\n";
                //    errMsg += XMsg.GetMsg("M041") + " : " + e.TargetSite.Name + "\n"; //"에러 발생 메서드 : " + e.TargetSite.Name + "\n";
                //}
                //errMsg += XMsg.GetMsg("M039") + " Stack :" + e.StackTrace + "\n"; //"에러 Stack  :" + e.StackTrace + "\n";
                //errMsg += XMsg.GetMsg("M039") + " Source :" + e.Source; //"에러 Source : " + e.Source;

                // Writelog
                Logs.WriteLog("ThreadException message: " + e.Message);
                Logs.WriteLog("ThreadException stacktrace: " + e.StackTrace);

                // Description
                string description = SetErrDescription(e);

				//ErrorLogForm dlg = new ErrorLogForm(errMsg);
                ErrorLogForm dlg = new ErrorLogForm(_errMsg, description);
				DialogResult result = dlg.ShowDialog();
				dlg.Dispose();
				return result;
			}
			catch(Exception xe)
			{
				Logs.WriteLog("SystemExceptionHandler ShowThreadExceptionDialog 에러=" + xe.Message);
				Logs.WriteLog("SystemExceptionHandler ShowThreadExceptionDialog StackTrace=" + xe.StackTrace);
				string msg = XMsg.GetMsg("M042") + "\n" + XMsg.GetMsg("M039",xe);  // 업무시스템 실행간 에러가 발생했습니다.\n" + "에러[" + xe.Message + "]"
				string title = XMsg.GetMsg("M043"); // 업무시스템 에러
				//MessageBox.Show(msg, title);

                // Description
                string description = SetErrDescription(xe);
                // Force to exit application
                ErrorLogForm dlg = new ErrorLogForm(_errMsg, description);
                DialogResult result = dlg.ShowDialog();
                dlg.Dispose();
				//return DialogResult.OK;
                return result;
			}
		}

        private string SetErrDescription(Exception e)
        {
            // Description
            string description = "";

            if (e != null)
            {
                try
                {
                    description += "- Message: " + e.Message + Environment.NewLine;
                    //description += "- Help link: " + e.HelpLink + Environment.NewLine;
                    description += "- Target site: " + e.TargetSite + Environment.NewLine;
                    description += "- Source: " + e.Source + Environment.NewLine;
                    if (ConfigurationManager.AppSettings["BuildMode"] == "DEBUG")
                    {
                        description += "\t - at: " + e.StackTrace + Environment.NewLine;
                    }
                }
                catch (Exception ex)
                {
                    description = "FATAL ERROR!";
                    Logs.WriteLog(ex.Message);
                    Logs.WriteLog(ex.StackTrace);
                }
                finally { }
            }

            return description;
        }
	}
}
