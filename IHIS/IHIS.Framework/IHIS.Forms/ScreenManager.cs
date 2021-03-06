using System;
using System.Data;
using System.Collections;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Arguments.System;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.CloudConnector.Contracts.Results.System;

namespace IHIS.Framework
{
	/// <summary>
	/// Screen 관리 Class
	/// </summary>
	internal class ScreenManager
	{
		private static ArrayList screenList = new ArrayList();
		public static XScreen[] OpenScreenList
		{
			get { return (XScreen[])screenList.ToArray(typeof(XScreen)); }
		}

		/// <summary>
		/// 열려있는 화면List에 추가
		/// </summary>
		/// <param name="screen"></param>
		public static void AddScreenList(XScreen screen)
		{
			screenList.Add(screen);
		}

		/// <summary>
		/// 열려있는 화면List에서 제거
		/// </summary>
		/// <param name="screen"></param>
		public static void RemoveScreenList(XScreen screen)
		{
			screenList.Remove(screen);
		}
		/// <summary>
		/// 프로그램 ID로 Open된 화면을 찾습니다.
		/// </summary>
		/// <param name="pgmID"> 프로그램 ID(화면 ID) </param>
		/// <returns></returns>
		public static IXScreen FindScreen(string pgmID)
		{
			foreach (XScreen screen in screenList)
			{
				if (screen.ScreenInfo.PgmID == pgmID)
					return (IXScreen) screen;
			}
			return null;
		}
		//메인화면을 Open합니다.
		public static IXScreen OpenMainScreen(object opener, string systemID, string screenID)
		{
			ScreenInfo screenInfo = null;
			IXScreen screen = null;
			//시스템ID, 화면 ID로 화면정보 GET
			try
			{
				screenInfo = GetScreenInfo(screenID);
			}
			catch
			{
				screenInfo = null;
			}
			if (screenInfo != null)
			{
				if (EnvironInfo.MdiForm != null)
				{
					//Main화면여부 Set
					screenInfo.IsMainScreen = true;
					//현재 MDI의 OpenNewScreen Call
					screen = EnvironInfo.MdiForm.OpenNewScreen(opener,screenInfo, (OpenCommand) null);	
				}
			}
			return screen;	
		}
		/// <summary>
		/// 지정한 시스템ID, 화면 ID, OpenStyle에 따라 화면을 Open합니다.
		/// </summary>
		/// <param name="opener"> 화면을 Open하는 객체 </param>
		/// <param name="screenID"> 화면 ID </param>
		/// <param name="openStyle"> 오픈 Sytle </param>
		public static IXScreen OpenScreen(object opener, string screenID, ScreenOpenStyle openStyle, ScreenAlignment screenAlign)
		{
			ScreenInfo screenInfo = null;
			IXScreen screen = null;
			//시스템ID, 화면 ID로 화면정보 GET
			try
			{
				screenInfo = GetScreenInfo(screenID);
			}
			catch
			{
				screenInfo = null;
			}
			if (screenInfo != null)
			{
				if (EnvironInfo.MdiForm != null)
				{
					//지정한 OpenStyle Set
					screenInfo.OpenStyle = openStyle;
					//지정한 ScreenAlignment Set
					screenInfo.ScreenAlign = screenAlign;

					//현재 MDI의 OpenNewScreen Call
					screen = EnvironInfo.MdiForm.OpenNewScreen(opener,screenInfo, (OpenCommand) null);	
				}
			}
			return screen;
		}
		/// <summary>
		/// 지정한 시스템ID, 화면 ID, OpenStyle에 따라 화면을 Open합니다.
		/// </summary>
		/// <param name="opener"> 화면을 Open하는 객체 </param>
		/// <param name="systemID"> 시스템 ID </param>
		/// <param name="screenID"> 화면 ID </param>
		/// <param name="openStyle"> 오픈 Sytle </param>
		/// <param name="openParam"> CommonItemCollection (Argument) </param>
		public static IXScreen OpenScreenWithParam(object opener, string systemID, string screenID, ScreenOpenStyle openStyle, ScreenAlignment screenAlign, CommonItemCollection openParam)
		{
			ScreenInfo screenInfo = null;
			IXScreen screen = null;
			//시스템ID, 화면 ID로 화면정보 GET
			try
			{
				screenInfo = GetScreenInfo(screenID);
			}
			catch
			{
				screenInfo = null;
			}
			if (screenInfo != null)
			{
				if (EnvironInfo.MdiForm != null)
				{
					//지정한 OpenStyle Set
					screenInfo.OpenStyle = openStyle;
					//지정한 ScreenAlignment Set
					screenInfo.ScreenAlign = screenAlign;
					//현재 MDI의 OpenNewScreen Call
					screen = EnvironInfo.MdiForm.OpenNewScreen(opener,screenInfo, openParam);	
				}
			}
			return screen;
		}
		//지정한 Command로 Screen Open
		public static IXScreen OpenScreenWithCommand(object opener, string screenID, ScreenOpenStyle openStyle, ScreenAlignment screenAlign, OpenCommand openCommand)
		{
			ScreenInfo screenInfo = null;
			IXScreen screen = null;
			//시스템ID, 화면 ID로 화면정보 GET
			try
			{
				screenInfo = GetScreenInfo(screenID);
			}
			catch(Exception xe)
			{
				Debug.WriteLine(xe.Message + "," + xe.StackTrace);
				screenInfo = null;
			}
			if (screenInfo != null)
			{
				if (EnvironInfo.MdiForm != null)
				{
					//지정한 OpenStyle Set
					screenInfo.OpenStyle = openStyle;
					//지정한 ScreenAlignment Set
					screenInfo.ScreenAlign = screenAlign;
					//현재 MDI의 OpenNewScreen Call
					screen = EnvironInfo.MdiForm.OpenNewScreen(opener,screenInfo, openCommand);	
				}
			}
			return screen;
		}

		/// <summary>
		/// 시스템ID와 화면ID로 화면정보를 가져옵니다.
		/// </summary>
		/// <param name="systemId"></param>
		/// <param name="screenId"></param>
		/// <returns> 일치하는 화면정보가 있으면 ScreenInfo 개체 Return, 없으면 null </returns>
		internal static ScreenInfo GetScreenInfo(string screenID)
		{
			//ADM0300(프로그램정보), ADM0400(어셈블리 정보)를 조회하여 화면 정보 조회
			//OUTPUT은 총 8
			//2006.07.11 DB종류에 따라 SQL문 변경
			/*string cmdText 
				= "SELECT A.SYS_ID, A.PGM_NM, A.PGM_ENT_GRAD, A.PGM_UPD_GRAD, A.PGM_SCRT, NVL(A.PGM_DUP_YN,'N'), A.ASM_NAME, B.ASM_PATH, B.ASM_VER, C.GRP_ID"
				+ "  FROM ADM0300 A"   //프로그램
				+ "      ,ADM0400 B"   //어셈블리
				+ "      ,ADM0200 C"   //시스템
				+ " WHERE A.PGM_TP = 'P'" // 프로그램만 가능(메뉴 프로그램을 불가)
				+ "   AND A.ASM_NAME = B.ASM_NAME"
				+ "   AND A.SYS_ID   = C.SYS_ID "
				+ "   AND A.PGM_ID  = '" + screenID + "'";
			if (Service.CurrentDBKind == DataBaseKind.SqlServer)
			{
				cmdText 
					= "SELECT A.SYS_ID, A.PGM_NM, A.PGM_ENT_GRAD, A.PGM_UPD_GRAD, A.PGM_SCRT, ISNULL(A.PGM_DUP_YN,'N'), A.ASM_NAME, B.ASM_PATH, B.ASM_VER, C.GRP_ID"
					+ "  FROM ADM0300 A"   //프로그램
					+ "      ,ADM0400 B"   //어셈블리
					+ "      ,ADM0200 C"   //시스템
					+ " WHERE A.PGM_TP = 'P'" // 프로그램만 가능(메뉴 프로그램을 불가)
					+ "   AND A.ASM_NAME = B.ASM_NAME"
					+ "   AND A.SYS_ID   = C.SYS_ID "
					+ "   AND A.PGM_ID  = '" + screenID + "'";
			}
			DataTable table = Service.ExecuteDataTable(cmdText);
			if ((table == null) || (table.Rows.Count < 1)) //조회 실패
			{
				EnvironInfo.MdiForm.SetMsg(Service.ErrMsg, MsgType.Error);
				return null;
			}
			DataRow dtRow = table.Rows[0]; //한건이므로
			ScreenInfo screenInfo = new ScreenInfo();
			screenInfo.PgmID = screenID;
			screenInfo.PgmSystemID = dtRow[0].ToString();
			screenInfo.Title = dtRow[1].ToString();
			screenInfo.EntryPrivilege  = (dtRow[2].ToString() == string.Empty ? 0 : int.Parse(dtRow[2].ToString()));
			screenInfo.UpdatePrivilege = (dtRow[3].ToString() == string.Empty ? 0 : int.Parse(dtRow[3].ToString()));
			screenInfo.Password = dtRow[4].ToString();
			screenInfo.AlowDupl = (dtRow[5].ToString() == "Y");
			screenInfo.AsmName = dtRow[6].ToString();
			screenInfo.AsmPath = dtRow[7].ToString();
			screenInfo.Version = dtRow[8].ToString();
			screenInfo.PgmGroupID = dtRow[9].ToString();*/

            // Cloud service

            FormScreenListArgs vFormScreenListArgs = new FormScreenListArgs();
            vFormScreenListArgs.ScreenId = screenID;
            FormScreenListResult result = CloudService.Instance.Submit<FormScreenListResult, FormScreenListArgs>(vFormScreenListArgs, true);
            if (result == null || result.FormScreenInfo.Count < 1)
            {
                //Modified on 2015-07-30: refer to MED-1958, Service.ErrMsg is belonged to Oracle, not MySql, so this line should be disabled.
                //EnvironInfo.MdiForm.SetMsg(Service.ErrMsg, MsgType.Error);
                return null;
            }
            FormScreenInfo item = result.FormScreenInfo[0];

            ScreenInfo screenInfo = new ScreenInfo();
            screenInfo.PgmID = screenID;
            screenInfo.PgmSystemID = item.SysId;
            screenInfo.Title = item.PgmNm;
            screenInfo.EntryPrivilege = (item.PgmEntGrad == string.Empty ? 0 : int.Parse(item.PgmEntGrad));
            screenInfo.UpdatePrivilege = (item.PgmUpdGrad == string.Empty ? 0 : int.Parse(item.PgmUpdGrad));
            screenInfo.Password = item.PgmScrt;
            screenInfo.AlowDupl = (item.PgmDupYn == "Y");
            screenInfo.AsmName = item.AsmName;
            screenInfo.AsmPath = item.AsmPath;
            screenInfo.Version = item.AsmVer;
            screenInfo.PgmGroupID = item.GrpId;

			return screenInfo;
		}
		/// <summary>
		/// DB에 저장된 화면Type의 Name으로 ScreenOpenStyle Enum을 가져옵니다.
		/// </summary>
		/// <param name="openStyleName"> DB에 저장된 Type명(PPS,PPF,RSS,RSF,DOC 등) </param>
		/// <returns> ScreenOpenStyle Enum </returns>
		public static ScreenOpenStyle GetOpenStyle(string openStyleName)
		{
			//DB에 저장된 화면표시를 Enum으로 변환
			ScreenOpenStyle openStyle = ScreenOpenStyle.PopUpSizable;
			switch (openStyleName)
			{
				case "PPS":
					openStyle = ScreenOpenStyle.PopUpSizable;
					break;
				case "PPF":
					openStyle = ScreenOpenStyle.PopUpFixed;
					break;
				case "RSS":
					openStyle = ScreenOpenStyle.ResponseSizable;
					break;
				case "RSF":
					openStyle = ScreenOpenStyle.ResponseFixed;
					break;
				case "DOC":
					openStyle = ScreenOpenStyle.Docking;
					break;
				case "PSF": //PopupSingleFixed
					openStyle = ScreenOpenStyle.PopupSingleFixed;
					break;
				case "PSS": //PopupSingleSizable
					openStyle = ScreenOpenStyle.PopupSingleSizable;
					break;
			}
			return openStyle;
		}
	}
}
