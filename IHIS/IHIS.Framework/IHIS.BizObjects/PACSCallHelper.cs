using System;
using System.Reflection;
using System.Data;
using System.Collections;
using System.Drawing;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Globalization;
using System.Runtime.InteropServices;

namespace IHIS.Framework
{
	/// <summary>
	/// PACSCallHelper에 대한 요약 설명입니다.
	/// </summary>
	public class PACSCallHelper
	{
		#region DllImport (CallDDE.dll)
		[DllImport("CallDDE.dll")]
		private static extern int ConNetDrive(string userID, string password, string remoteDir, string localDir);

		[DllImport("CallDDE.dll")]
		private static extern int DisConNetDrive(string localDir);

		[DllImport("CallDDE.dll")]
		private static extern long DDELoadImage(string bunho, string suName, string ocsKey, string fileNames);
		#endregion

		#region Fields
		const string SECTION_NAME = "PACS";
		const string AET_KEY_NAME = "SERVERAET";
		const string IP_KEY_NAME  = "SERVERIP";
		const string DEFAULT_AET_NAME = "ICMDEV";
		const string DEFAULT_IP   = "222.106.127.66";
		const string DELIMETER = "!";   //PACS 전문의 Delimeter

		//AET, IP, Port는 차후 PACS 와 협의하여 동적으로 할당해야 하면 변경(일단 고정처리함)
		private static string serverAET = "";
		private static string serverIP = "";
		private static string serverPort = "4006"; //일단 고정
		#endregion

		static PACSCallHelper()
		{
			//IHIS.config에 [PACS]Node에 있는 정보로
			serverAET = Service.GetConfigString(SECTION_NAME, AET_KEY_NAME, "");
			if (serverAET == "")  //기본값이 없으면 SET
			{
				Service.SetConfigString(SECTION_NAME, AET_KEY_NAME, DEFAULT_AET_NAME);
				serverAET = DEFAULT_AET_NAME;
			}
			serverIP = Service.GetConfigString(SECTION_NAME, IP_KEY_NAME, "");
			if (serverIP == "")  //기본값이 없으면 SET
			{
				Service.SetConfigString(SECTION_NAME, IP_KEY_NAME, DEFAULT_IP);
				serverIP = DEFAULT_IP;
			}
		}
		/// <summary>
		/// 환자번호, 환자명 OcsKeyList를 전달하여 PACSViewer를 Call합니다.
		/// 모니터는 2개이상일 경우 1번 모니터를 씁니다.
		/// </summary>
		/// <param name="bunho"> 환자번호 </param>
		/// <param name="suName"> 환자명 </param>
		/// <param name="ocsKeyList"> ocsKey(string) LIST </param>
	
		public static void CallViewer(string bunho, string suName, ArrayList ocsKeyList)
		{
			CallViewer(bunho, suName, ocsKeyList, 1);
		}
		/// <summary>
		/// 환자번호, 환자명 OcsKeyList, MoniterIndex(1,2)를 전달하여 PACSViewer를 Call합니다.
		/// </summary>
		/// <param name="bunho"> 환자번호 </param>
		/// <param name="suName"> 환자명 </param>
		/// <param name="ocsKeyList"> ocsKey(string) LIST </param>
		/// <param name="moniterIndex"> 모니터 Index (1,2) </param>
		public static void CallViewer(string bunho, string suName, ArrayList ocsKeyList, int moniterIndex)
		{
			if (ocsKeyList.Count < 1) return;  //Key가 없으면 Return
			//Key값이 String이 아니면 Return
			if (!(ocsKeyList[0] is string)) return;

			//SERVER와 연결하여 ocsKey를 전달하여 Image Call하기
			//HEADER GET
//			string header = GetHeader(moniterIndex);
//			string order = "";
//			//여러건을 각각 1건의 전문형태로 Concat함
//			foreach (string ocsKey in ocsKeyList)
//			{
//				//order += serverAET + DELIMETER + serverIP + DELIMETER + serverPort + DELIMETER + 
//				//		 bunho + DELIMETER + suName + DELIMETER + ocsKey + DELIMETER;
//				//studyinstanceuid로 가져오기
//				order += serverAET + DELIMETER + serverIP + DELIMETER + serverPort + DELIMETER + ocsKey + DELIMETER;
//			}
//			
//			/*CallDDE.dll Method Call
//			 * 원래 DDELoadImage의 3번째 Arg ocsKey가 ocsKey를 관리하였으나(한건만), 여러건의 처리를 위해
//			 * PACS팀에서 4번째 arg에 여러개의 데이타를 처리할 수 있도록 변경함. 자세한 사항은 PACS팀의 문의 
//			 */
//			DDELoadImage(bunho, suName, "", header + order);

			
			//LOCAL에 있는 Images를 StudyInstanceUID를 전달하여 가져오기
			//한건씩 DDELoadImage를 호출
			string header = GetHeader(moniterIndex);
			string order = "";
			//한 건씩 전문을 만들어서 보냄
			foreach (string ocsKey in ocsKeyList)
			{
				//order += serverAET + DELIMETER + serverIP + DELIMETER + serverPort + DELIMETER + 
				//		 bunho + DELIMETER + suName + DELIMETER + ocsKey + DELIMETER;
				//studyinstanceuid로 가져오기
				order = "localhost" + DELIMETER + serverIP + DELIMETER + serverPort + DELIMETER + DELIMETER + ocsKey + DELIMETER;
				DDELoadImage(bunho, suName, "", header + order);
			}
			
		}
		private static string GetHeader(int monitorIndex)
		{
			//MoniterIndex로 Header 정보 Get
			/* PACS Header 구조(10자리) : ls_display + is_part + is_sort + ls_cnt + ls_monitor + 
				ls_key_image + ls_gubun7 + ls_gubun8 + ls_gubun9 + ls_gubun10 
				Sample : CEA110NNYN 
				ls_display : 
				// 화면지우기 (windows clear 값) 
				// "C" 는 모든 child window를 close한다.(All Window Clear) 
				// "G" 는 필름리스트 화면을 겹쳐서 생성한다. 
				is_part : E 
				is_sort : A 
				ls_cnt : 1 
				ls_monitor : 1... 
				// 띄우고자 하는 모니터 Index 
				// EX) 1번 모니터 : 1, 2번 모니터 : 2 

				ls_key_image : 0 
				// Key Image를 우선 띄울경우 1 
				// 정상 상태 : 0 

				ls_gubun7 : N 
				ls_gubun8 : M, N 
				// n개의 검사를 Merge해서 같은 화면에 띄울경우 : M 
				// n개의 검사를 각각 분리해서 다른 화면 또는 다른 검사 Tab으로 띄울경우 : N 
				ls_gubun9 : Y, N 둘다 가능 
				ls_gubun10 : N
			*/
			//IFC에서는 MoniterIndex만 변경(그외 추가적인 요청사항이 있으면 추가)
			int index = Math.Max(1, Math.Min(monitorIndex, SystemInformation.MonitorCount));
			//return "CEA1" + index.ToString() + "0NNYN";
			//TEST 용 (Local에서 이미지 가져오기, 10자리중에서 ls_key_image자리가 빠짐)
			return "CE341NNNN";
		}
		/// <summary>
		/// PACS관리 Server를 PC의 네트워크 Dir로 설정시 사용합(현재 사용안함)
		/// (ex) ConNetDrive(pacs, pacs, \\222.106.127.202\ICM, X:);
		/// </summary>
		/// <param name="userID"> PACS서버의 UserID </param>
		/// <param name="passWord"> PACS서버의 Pswd </param>
		/// <param name="remoteDir"> 원격 Dir </param>
		/// <param name="localDir"></param>
		/// <returns> 성공시 true, 실패시 false  </returns>
		public static bool Connect(string userID, string passWord, string remoteDir, string localDir)
		{
			int ret = ConNetDrive(userID, passWord, remoteDir, localDir);
			return (ret == -1 ? false : true);
		}
		/// <summary>
		/// 설정한 원격 Driver를 해제함(현재사용안함)
		/// ex > DisConNetDrive(X:);
		/// </summary>
		/// <param name="localDir"></param>
		/// <returns>성공시 true, 실패시 false </returns>
		public static bool DisConnect(string localDir)
		{
			int ret = DisConNetDrive(localDir);
			return (ret == -1 ? false : true);
		}

	}
}
