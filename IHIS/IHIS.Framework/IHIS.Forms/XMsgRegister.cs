using System;
using System.IO;
using Microsoft.Win32;

namespace IHIS.Framework
{
	/// <summary>
	/// XMsgRegister에 대한 요약 설명입니다.
	/// </summary>
	public class XMsgRegister
	{
		private static string regCmdText = "";  //Msg 등록 실행 Text
		private static string unRegCmdText = ""; //Msg 등록해제 실행 Text
		static XMsgRegister()
		{
			regCmdText
				= "BEGIN"
				+ "  INSERT INTO ADM0600 (MSG_ID, IP_ADDR, MSG_TYPE, SYS_ID, PGM_ID, MSG_REG_ARG, REGI_TIME)"
				+ "  VALUES(:f_msg_id, :f_ip_addr, :f_msg_type, :f_sys_id, :f_pgm_id, :f_msg_reg_arg, SYSDATE);"
				+ "  EXCEPTION WHEN DUP_VAL_ON_INDEX THEN"
				+ "    UPDATE ADM0600"
				+ "       SET SYS_ID      = :f_sys_id"
				+ "          ,PGM_ID      = :f_pgm_id"
				+ "          ,MSG_REG_ARG = :f_msg_reg_arg"
				+ "          ,REGI_TIME   = SYSDATE"
				+ "     WHERE MSG_ID      = :f_msg_id"
				+ "       AND IP_ADDR     = :f_ip_addr;"
				+ "END";

			unRegCmdText
				= "DELETE ADM0600"
				+ " WHERE IP_ADDR   = :f_ip_addr"
				+ "   AND MSG_TYPE  = :f_msg_type"
				+ "   AND SYS_ID    = :f_sys_id"
				+ "   AND PGM_ID    = :f_pgm_id";
		}

		public static void RegisterScreenMsgID(XScreen screen, string msgID)
		{
			RegisterScreenMsgID(screen, msgID, "");
		}
		/// <summary>
		/// Screen이 열릴때 해당 Screen에서 받을 MsgID를 등록합니다.
		/// </summary>
		/// <param name="screen"> Open하는 AScreen 객체 </param>
		/// <param name="msgID"> 등록할 Msg ID </param>
		public static void RegisterScreenMsgID(XScreen screen, string msgID, string msgArg)
		{
			if (screen == null) return;
			if (msgID == "") return;

			try
			{
				//BindVar를 이용하여 SQL 분석의 효율성을 높인다.
				//BindVar Set
				BindVarCollection bindVars = new BindVarCollection();
				bindVars.Add("f_msg_id", msgID);
				bindVars.Add("f_ip_addr", Service.ClientIP);
				bindVars.Add("f_msg_type", "SCM");
				bindVars.Add("f_sys_id", EnvironInfo.CurrSystemID);
				bindVars.Add("f_pgm_id", screen.ScreenID);
				bindVars.Add("f_msg_reg_arg", msgArg);
				Service.ExecuteNonQuery(regCmdText, bindVars);
			}
			catch{}
		}

		public static void RegisterSystemMsgID(string msgID)
		{
			RegisterSystemMsgID(EnvironInfo.CurrSystemID, msgID,"");
		}
		public static void RegisterSystemMsgID(string systemID, string msgID)
		{
			RegisterSystemMsgID(systemID, msgID, "");
		}

		public static void RegisterSystemMsgID(string systemID, string msgID, string msgArg)
		{
			if (msgID == "") return;
			if (systemID == "") return;

			try
			{
				//BindVar를 이용하여 SQL 분석의 효율성을 높인다.
				//BindVar Set
				BindVarCollection bindVars = new BindVarCollection();
				bindVars.Add("f_msg_id", msgID);
				bindVars.Add("f_ip_addr", Service.ClientIP);
				bindVars.Add("f_msg_type", "SMG");
				bindVars.Add("f_sys_id", systemID);
				bindVars.Add("f_pgm_id", "");
				bindVars.Add("f_msg_reg_arg", msgArg);
				Service.ExecuteNonQuery(regCmdText, bindVars);
			}
			catch{}
		}

		/// <summary>
		/// Screen이 닫힐때 해당 IP, ScreenID로 등록된 MsgID를 삭제합니다.
		/// </summary>
		/// <param name="screen"></param>
		public static void UnRegisterScreenMsgID(XScreen screen)
		{
			//Screen이 닫힐때 해당 IP, ScreenID로 등록된 SCM Msg 삭제
			if (screen == null) return;
			try
			{
				//BindVar Set
				BindVarCollection bindVars = new BindVarCollection();
				bindVars.Add("f_ip_addr", Service.ClientIP);
				bindVars.Add("f_msg_type", "SCM");
				bindVars.Add("f_sys_id", EnvironInfo.CurrSystemID);
				bindVars.Add("f_pgm_id", screen.ScreenID);
				Service.ExecuteNonQuery(unRegCmdText, bindVars);
			}
			catch{}
		}

		public static void UnRegisterSystemMsgID()
		{
			UnRegisterSystemMsgID(EnvironInfo.CurrSystemID);
		}

		public static void UnRegisterSystemMsgID(string systemID)
		{
			if (systemID == "") return;
			try
			{
				//BindVar Set
				BindVarCollection bindVars = new BindVarCollection();
				bindVars.Add("f_ip_addr", Service.ClientIP);
				bindVars.Add("f_msg_type", "SMG");
				bindVars.Add("f_sys_id", systemID);
				bindVars.Add("f_pgm_id", "");
				Service.ExecuteNonQuery(unRegCmdText, bindVars);
			}
			catch{}
		}
	}
}
