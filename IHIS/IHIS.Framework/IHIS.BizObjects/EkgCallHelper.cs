using System;
using System.Reflection;
using System.Data;
using System.Collections;
using System.Drawing;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing.Design;
using System.Drawing.Printing;
using System.Windows.Forms;
using System.Globalization;
using System.Runtime.InteropServices;

namespace IHIS.Framework
{
	/// <summary>
	/// EkgCallHelper에 대한 요약 설명입니다.
	/// </summary>
	public class EkgCallHelper
	{
		/// <summary>
		/// 환자번호를 전달하여 Ekg Viewer를 Call합니다.
		/// </summary>
		/// <param name="bunho"> 환자번호 </param>
		
		public static void CallViewer()
		{
            try
            {
                System.Diagnostics.Process program = System.Diagnostics.Process.Start(EnvironInfo.GetEkgViewerPath());
            }
            catch
            {
                XMessageBox.Show(XMsg.GetMsg("M040"),XMsg.GetField("F052"));
            }
		}

        public static void CallViewer(string bunho)
        {
            try
            {
                System.Diagnostics.Process program = System.Diagnostics.Process.Start(EnvironInfo.GetEkgViewerPath(), bunho);
            }
            catch
            {
                XMessageBox.Show(XMsg.GetMsg("M040"), XMsg.GetField("F052"));
            }
        }
	}
}
