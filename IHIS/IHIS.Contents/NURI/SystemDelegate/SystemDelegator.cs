using System;
using System.IO;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using IHIS.Framework;

namespace IHIS.NURI
{
	/// <summary>
	/// SystemDelegator에 대한 요약 설명입니다.
	/// </summary>
	public class SystemDelegator
	{
		//		private static FormMessage MsgForm = null;

		static SystemDelegator()
		{	
			//
			// TODO: 여기에 생성자 논리를 추가합니다.
			//
		}

		public static void OnReceiveMessage(string command, string msg)
		{

			try { IHIS.Framework.Kernel32.Nofify(); }
			catch{};

			string returnCode = msg.Split('.')[0];
			string returnMsg  = msg.Split('.')[1];
			string screenCommand = "";
			IXScreen screen = null;

			screen = ((IXScreen)XScreen.FindScreen("NURI", command));

			screenCommand = command;
	
			if (screen == null)
			{
				return ;
			}
			else
			{
				CommonItemCollection param = new CommonItemCollection();

				param.Add("return_code", returnCode);
				param.Add("return_msg", returnMsg);

				screen.Activate();

				screen.Command(screenCommand, param);
			}
			
			
		}
		
		public static void OnSystemOpen()
		{
			
			SOCKET_REGTABLE("I", "CPLMSG");
			//			MsgForm = new FormMessage();
			//			MsgForm.TopMost = true;
			//			MsgForm.Show();
		}
		public static void OnSystemInit(bool isMySystem)
		{
			//string userID = UserInfo.Items["사번"].ToString();
		}
		public static void OnSystemClose()
		{
            SOCKET_REGTABLE("D", "CPLMSG");
			SOCKET_REGTABLE("D", "간호메인");

			//			MsgForm.Close();
		}


		public static void OnSystemUserLogOn(string userID, bool isMySystem, bool isFirst)
		{
			//MessageBox.Show("OnSystemUserLogOn");
			if (isFirst == false && isMySystem == true)
			{
				//삭제후 Insert
                SOCKET_REGTABLE("D", "CPLMSG");

                SOCKET_REGTABLE("I", "CPLMSG");

			}
		}

		private static void SOCKET_REGTABLE(string agubn, string apgnm)
		{
			string gubn = agubn.Trim().ToString();
			string pgnm = apgnm.Trim().ToString();
			
			/*
			AMCData amcData = new AMCData(AMIS.Framework.EnvironInfo.CurrMdiForm.Name, AMIS.Framework.EnvironInfo.CurrMdiForm);
			AMCPreData amcPreData = amcData.CreatePreData("IP_SET_SOCKET_REGTABLE");
			amcPreData.SetItem("gubn", gubn);
			amcPreData.SetItem("pgnm", pgnm);
			amcPreData.SetItem("usid", UserInfo.Items["사번"].ToString());
			amcPreData.SetItem("ipad", AMIS.Framework.NetInfo.ClientIP.ToString());
			amcPreData.SetItem("port", "7415");
			
			if(AMIS.Framework.UserInfo.Groups.Contains("N"))
			{
				if (AMIS.Framework.UserInfo.Groups["N"].Items["nryn"].ToString() == "Y")
				{					
					amcPreData.SetItem("dept", AMIS.Framework.UserInfo.Groups["N"].Items["dept"].ToString());
					amcPreData.SetItem("inf1", AMIS.Framework.UserInfo.Groups["N"].Items["dept"].ToString()); // 받는곳
				}
				else
				{
					amcPreData.SetItem("dept"," ");
					amcPreData.SetItem("inf1"," ");
				}
			}
			else
			{
				amcPreData.SetItem("dept"," ");
				amcPreData.SetItem("inf1"," ");
			}

			amcPreData.SetItem("inf2", ""); // 의사2 
			amcPreData.SetItem("inf3", ""); // 의사3 

			if (amcData.TpCall("NOUTSOCST01", "0") == TPResult.OK)
			{
				if(amcData.UserReturn == 0)
				{
				}
			}
			*/
		}

		//타시스템에서 사용자정보를 요청시
		public static object OnCommand(string command, CommonItemCollection commandParam)
		{	

			/*
			if(AMIS.Framework.UserInfo.Groups.Contains("N"))
			{

				//간호사용자 병동을 원할대
				if(command.Equals("GetUserWard"))
				{
					if (AMIS.Framework.UserInfo.Groups["N"].Items["nryn"].ToString() == "Y")
					{
						string ward = string.Empty;
						ward = AMIS.Framework.UserInfo.Groups["N"].Items["ward"].ToString();
						return ward;
					}
				}

				//간호사용자 진료과를 원할대
				if(command.Equals("GetUserDept"))
				{				
					if (AMIS.Framework.UserInfo.Groups["N"].Items["nryn"].ToString() == "Y")
					{
						string dept = string.Empty;
						dept = AMIS.Framework.UserInfo.Groups["N"].Items["dept"].ToString();
						return dept;
					}
				}

				//간호사용자 장소를 원할대
				if(command.Equals("GetUserLocd"))
				{

					if (AMIS.Framework.UserInfo.Groups["N"].Items["nryn"].ToString() == "Y")
					{	

						string pilo = string.Empty;
						pilo= AMIS.Framework.UserInfo.Groups["N"].Items["pilo"].ToString();
						return pilo;
					}				
				}
			}
			*/
			return null;
		}
		   
	}
}
