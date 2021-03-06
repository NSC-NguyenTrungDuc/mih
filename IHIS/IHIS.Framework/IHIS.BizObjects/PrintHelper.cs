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
	/// PrintHelper에 대한 요약 설명입니다.
	/// </summary>
	public class PrintHelper
	{
		#region DllImport (기본 프린터 설정 API)
		[DllImport("winspool.drv",EntryPoint="SetDefaultPrinter")]
		private static extern bool SetDefaultPrint(string printerName); 
		#endregion

		/// <summary>
		/// 기본 프린터를 설정합니다.
		/// </summary>
		/// <param name="printerName"> 프린터 명</param>
		/// <returns> true(성공), false(실패)</returns>
		public static bool SetDefaultPrinter(string printerName)
		{
			string msg = "";
			try
			{
				//지정한 Printer명 검색 (PC에 등록된 Printer명이 아닐경우 Return)
				bool isFound = false;
				foreach (string printer in PrinterSettings.InstalledPrinters)
				{
					if (printer == printerName)
					{
						isFound = true;
						break;
					}
				}
				if (!isFound)
				{
					msg = XMsg.GetMsg("M001") + "[" + printerName + "]" + XMsg.GetMsg("M002") + "\n" + XMsg.GetMsg("M003"); //프린터명[" + printerName + "]을 잘못 지정하셨습니다.\n" + "PC에 설치된 프린터가 아닙니다."
					XMessageBox.Show(msg, "Printer Setting");
					return false;
				}
				//API 호출실패처리
				if (!SetDefaultPrint(printerName))
				{
					msg = XMsg.GetMsg("M004"); // 기본프린터를 설정하지 못했습니다.
					XMessageBox.Show(msg, "Printer Setting");
					return false;
				}

				return true;

			}
			catch(Exception xe)
			{
				msg = XMsg.GetMsg("M005", xe); // 기본프린터 설정실패[" + xe.Message + "]"
				XMessageBox.Show(msg, "Printer Setting");
				return false;
			}
		}

		/// <summary>
		/// 현재 PC의 기본 프린터의 이름을 가져옵니다.
		/// </summary>
		/// <returns></returns>
		public static string GetDefaultPrinterName()
		{
			PrintDocument pd = new PrintDocument();
			try
			{
				//PrintDoc 생성후 PrinterName를 가져오면 그 이름이 기본 Printer 임
				return pd.PrinterSettings.PrinterName;

			}
			catch
			{
				return "";
			}
			finally
			{
				pd.Dispose();
			}
		}

	}
}
