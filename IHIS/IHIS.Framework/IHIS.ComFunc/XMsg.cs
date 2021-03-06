using System;
using System.IO;
using System.Collections;
using System.Text;
using System.Reflection;
using System.Windows.Forms;
using System.Xml;
using System.Diagnostics;

namespace IHIS.Framework
{
	public class XMsg
	{
		/* 각 어셈블리에 MSG, Field를 관리하는 MSG.xml을 포함리소스로 관리 
		 * 형식은 아래와 같고, msg ID는 M001 형식으로, field ID = F001 형식으로 관리, K.한글, J.일본어, E.영어, CID.ClassID (어느 Class에서 쓰는지에 대한 정보)
		 * <config>
		 * <msgs>
		 *   <msg ID="M001" K="" J="" E="" CID=""/>
		 *   <msg ID="M002" K="" J="" E="" CID=""/>
		 * </msgs>
		 * <fids>
		 *   <fid ID="F001" K="" J="" E="" CID=""/>
		 *   <fid ID="F002" K="" J="" E="" CID=""/>
		 * </fids>
		 * </config>
		 * 
		 */
		private class MsgClass
		{
			public string KoMsg = "";   //한글 Msg
			public string JpMsg = "";   //일본어 MSG
			public string EnMsg = "";   //영어 MSG
		    public string VnMsg = "";
		}

		private static Hashtable msgList = new Hashtable(); //Msg List 관리 Key.어셈블리명, Value= Hashtable(Key.msgID, Value:MsgClass) 
		private static Hashtable fidList = new Hashtable(); //Field List 관리 Key.어셈블리명, Value= Hashtable(Key.msgID, Value:MsgClass)
		public static string GetMsg(string msgID)
		{
			/*GetMsg(msgID, null)을 Call하면 GetCallingAssembly()가 IHIS.StartModules가 되므로 Call하지 않고 직접 구현함.
			return GetMsg(msgID, null);
			 */

			Assembly asm = Assembly.GetCallingAssembly();
			string asmName = asm.GetName().Name;
			string msg = "";
			MsgClass msgC = null;
			if (msgList.Contains(asmName))
			{
				Hashtable subList = msgList[asmName] as Hashtable;
				if (subList.Contains(msgID))  //해당 ID의 MSG가 있으면
				{
					msgC = subList[msgID] as MsgClass;
					msg = GetMsgSub(msgC);
				}
			}
			else
			{
				/*각 Calling Assembly에서 MSG.xml 리소스를 가져와서 msgList 구성
				  리소스명 = NameSpace + MSG.xml 
				 * Namespace Rule은 Framework은 IHIS.Framework, 각 시스템은 IHIS.시스템ID
				 * Assembly에서 NameSpace를 가져오는 방법이 없고, Type에서 NameSpace를 가져와야함.
				 * GetExportedTypes()에서 types[0]의 NameSpace를 가져오고, 
				 * 없으면 Framework은 어셈블리명으로 IHIS.이면 IHIS.Framework, 시스템은 OCS.XXX이므로 OCS를 잘라 IHIS.OCS로 설정
				 */
				Type[] types = asm.GetExportedTypes();
				string nameSpace = "";
				if (types.Length > 0)
					nameSpace = types[0].Namespace;
				else  //else인 경우는 발생하지 않을 것임
				{
					if (asmName.IndexOf("IHIS.") >= 0)
						nameSpace = "IHIS.Framework";
					else
					{
						int index = asmName.IndexOf('.');
						if (index > 0)
							nameSpace = "IHIS." + asmName.Substring(0, index);
					}
				}
				string rexName = nameSpace + ".MSG.xml";
				Stream stream = asm.GetManifestResourceStream(rexName);
                XmlAttribute idAttr = null, koAttr = null, jpAttr = null, enAttr = null, viAttr = null;
				if (stream != null)  //XML Load
				{
					Hashtable msgListSub = new Hashtable();
					XmlDocument xmlDoc = new XmlDocument();
					try
					{
						xmlDoc.Load(stream);
					}
					catch(Exception xe)
					{
						Debug.WriteLine(xe.Message + "," + xe.StackTrace);
						return "";
					}
					foreach (XmlNode node in xmlDoc.DocumentElement)
					{
						//msg Load
						if (node.Name == "msgs")
						{
							foreach (XmlNode sNode in node.ChildNodes)
							{
								idAttr = sNode.Attributes["ID"];  //ID
								koAttr = sNode.Attributes["K"];  //한글
								jpAttr = sNode.Attributes["J"];  //일본어
								enAttr = sNode.Attributes["E"];  //영문
                                viAttr = sNode.Attributes["V"];

                                if ((idAttr == null) || (koAttr == null) || (jpAttr == null) || (enAttr == null))  //유효한 데이타 아님
                                    continue;

                                msgC = new MsgClass();
                                msgC.KoMsg = koAttr.Value;
                                msgC.JpMsg = jpAttr.Value;
                                msgC.EnMsg = enAttr.Value;
                                msgC.VnMsg = viAttr == null ? "" : viAttr.Value;
                                if (string.IsNullOrEmpty(msgC.EnMsg)) msgC.EnMsg = jpAttr.Value;
                                if (string.IsNullOrEmpty(msgC.VnMsg)) msgC.VnMsg = jpAttr.Value;

								//msgListSub에 Add Key는 ID
								if (!msgListSub.Contains(idAttr.Value))
									msgListSub.Add(idAttr.Value, msgC);

								//동일한 ID이면 msg SET
								if (idAttr.Value == msgID)
									msg = GetMsgSub(msgC);
							}
						}
					}
					//msgList에 HashTable Add
					msgList.Add(asmName, msgListSub);
				}
			}
			return msg;
		}
		//Calling하는 Asm을 넘겨서 메세지 GET
		public static string GetMsg(Assembly callAsm, string msgID)
		{
			if (callAsm == null) return "";
			string asmName = callAsm.GetName().Name;
			string msg = "";
			MsgClass msgC = null;
			if (msgList.Contains(asmName))
			{
				Hashtable subList = msgList[asmName] as Hashtable;
				if (subList.Contains(msgID))  //해당 ID의 MSG가 있으면
				{
					msgC = subList[msgID] as MsgClass;
					msg = GetMsgSub(msgC);
				}
			}
			else
			{
				/*각 Calling Assembly에서 MSG.xml 리소스를 가져와서 msgList 구성
				  리소스명 = NameSpace + MSG.xml 
				 * Namespace Rule은 Framework은 IHIS.Framework, 각 시스템은 IHIS.시스템ID
				 * Assembly에서 NameSpace를 가져오는 방법이 없고, Type에서 NameSpace를 가져와야함.
				 * GetExportedTypes()에서 types[0]의 NameSpace를 가져오고, 
				 * 없으면 Framework은 어셈블리명으로 IHIS.이면 IHIS.Framework, 시스템은 OCS.XXX이므로 OCS를 잘라 IHIS.OCS로 설정
				 */
				Type[] types = callAsm.GetExportedTypes();
				string nameSpace = "";
				if (types.Length > 0)
					nameSpace = types[0].Namespace;
				else  //else인 경우는 발생하지 않을 것임
				{
					if (asmName.IndexOf("IHIS.") >= 0)
						nameSpace = "IHIS.Framework";
					else
					{
						int index = asmName.IndexOf('.');
						if (index > 0)
							nameSpace = "IHIS." + asmName.Substring(0, index);
					}
				}
				string rexName = nameSpace + ".MSG.xml";
				Stream stream = callAsm.GetManifestResourceStream(rexName);
                XmlAttribute idAttr = null, koAttr = null, jpAttr = null, enAttr = null, viAttr = null;
				if (stream != null)  //XML Load
				{
					Hashtable msgListSub = new Hashtable();
					XmlDocument xmlDoc = new XmlDocument();
					try
					{
						xmlDoc.Load(stream);
					}
					catch(Exception xe)
					{
						Debug.WriteLine(xe.Message + "," + xe.StackTrace);
						return "";
					}
					foreach (XmlNode node in xmlDoc.DocumentElement)
					{
						//msg Load
						if (node.Name == "msgs")
						{
							foreach (XmlNode sNode in node.ChildNodes)
							{
								idAttr = sNode.Attributes["ID"];  //ID
								koAttr = sNode.Attributes["K"];  //한글
								jpAttr = sNode.Attributes["J"];  //일본어
								enAttr = sNode.Attributes["E"];  //영문
                                viAttr = sNode.Attributes["V"];

                                if ((idAttr == null) || (koAttr == null) || (jpAttr == null) || (enAttr == null))  //유효한 데이타 아님
                                    continue;

                                msgC = new MsgClass();
                                msgC.KoMsg = koAttr.Value;
                                msgC.JpMsg = jpAttr.Value;
                                msgC.EnMsg = enAttr.Value;
                                msgC.VnMsg = viAttr == null ? "" : viAttr.Value;
                                if (string.IsNullOrEmpty(msgC.EnMsg)) msgC.EnMsg = jpAttr.Value;
                                if (string.IsNullOrEmpty(msgC.VnMsg)) msgC.VnMsg = jpAttr.Value;

								//msgListSub에 Add Key는 ID
								if (!msgListSub.Contains(idAttr.Value))
									msgListSub.Add(idAttr.Value, msgC);

								//동일한 ID이면 msg SET
								if (idAttr.Value == msgID)
									msg = GetMsgSub(msgC);
							}
						}
					}
					//msgList에 HashTable Add
					msgList.Add(asmName, msgListSub);
				}
			}
			return msg;
		}
		public static string GetMsg(string msgID1, string midText, string msgID2)
		{
			/*GetMsg(msgID, null)을 Call하면 GetCallingAssembly()가 IHIS.DBService가 되므로 Call하지 않고 직접 구현함.
			string msg1 = GetMsg(msgID1, null);
			string msg2 = GetMsg(msgID2, null);
			return msg1 + midText + msg2;
			 */

			Assembly asm = Assembly.GetCallingAssembly();
			string asmName = asm.GetName().Name;
			string msg1 = "", msg2 = "";
			MsgClass msgC = null;
			if (msgList.Contains(asmName))
			{
				Hashtable subList = msgList[asmName] as Hashtable;
				if (subList.Contains(msgID1))  //해당 ID의 MSG가 있으면
				{
					msgC = subList[msgID1] as MsgClass;
					msg1 = GetMsgSub(msgC);
				}
				if (subList.Contains(msgID2))  //해당 ID의 MSG가 있으면
				{
					msgC = subList[msgID2] as MsgClass;
					msg2 = GetMsgSub(msgC);
				}
			}
			else
			{
				/*각 Calling Assembly에서 MSG.xml 리소스를 가져와서 msgList 구성
				  리소스명 = NameSpace + MSG.xml 
				 * Namespace Rule은 Framework은 IHIS.Framework, 각 시스템은 IHIS.시스템ID
				 * Assembly에서 NameSpace를 가져오는 방법이 없고, Type에서 NameSpace를 가져와야함.
				 * GetExportedTypes()에서 types[0]의 NameSpace를 가져오고, 
				 * 없으면 Framework은 어셈블리명으로 IHIS.이면 IHIS.Framework, 시스템은 OCS.XXX이므로 OCS를 잘라 IHIS.OCS로 설정
				 */
				Type[] types = asm.GetExportedTypes();
				string nameSpace = "";
				if (types.Length > 0)
					nameSpace = types[0].Namespace;
				else  //else인 경우는 발생하지 않을 것임
				{
					if (asmName.IndexOf("IHIS.") >= 0)
						nameSpace = "IHIS.Framework";
					else
					{
						int index = asmName.IndexOf('.');
						if (index > 0)
							nameSpace = "IHIS." + asmName.Substring(0, index);
					}
				}
				string rexName = nameSpace + ".MSG.xml";
				Stream stream = asm.GetManifestResourceStream(rexName);
                XmlAttribute idAttr = null, koAttr = null, jpAttr = null, enAttr = null, viAttr = null;
				if (stream != null)  //XML Load
				{
					Hashtable msgListSub = new Hashtable();
					XmlDocument xmlDoc = new XmlDocument();
					try
					{
						xmlDoc.Load(stream);
					}
					catch(Exception xe)
					{
						Debug.WriteLine(xe.Message + "," + xe.StackTrace);
						return "";
					}
					foreach (XmlNode node in xmlDoc.DocumentElement)
					{
						//msg Load
						if (node.Name == "msgs")
						{
							foreach (XmlNode sNode in node.ChildNodes)
							{
								idAttr = sNode.Attributes["ID"];  //ID
								koAttr = sNode.Attributes["K"];  //한글
								jpAttr = sNode.Attributes["J"];  //일본어
								enAttr = sNode.Attributes["E"];  //영문
                                viAttr = sNode.Attributes["V"];

                                if ((idAttr == null) || (koAttr == null) || (jpAttr == null) || (enAttr == null))  //유효한 데이타 아님
                                    continue;

                                msgC = new MsgClass();
                                msgC.KoMsg = koAttr.Value;
                                msgC.JpMsg = jpAttr.Value;
                                msgC.EnMsg = enAttr.Value;
                                msgC.VnMsg = viAttr == null ? "" : viAttr.Value;
                                if (string.IsNullOrEmpty(msgC.EnMsg)) msgC.EnMsg = jpAttr.Value;
                                if (string.IsNullOrEmpty(msgC.VnMsg)) msgC.VnMsg = jpAttr.Value;

								//msgListSub에 Add Key는 ID
								if (!msgListSub.Contains(idAttr.Value))
									msgListSub.Add(idAttr.Value, msgC);

								//동일한 ID이면 msg SET
								if (idAttr.Value == msgID1)
									msg1 = GetMsgSub(msgC);
								if (idAttr.Value == msgID2)
									msg2 = GetMsgSub(msgC);
							}
						}
					}
					//msgList에 HashTable Add
					msgList.Add(asmName, msgListSub);
				}
			}
			return msg1 + midText + msg2;
		}
		public static string GetMsg(string msgID, Exception xe)
		{
			Assembly asm = Assembly.GetCallingAssembly();
			string asmName = asm.GetName().Name;
			string msg = "";
			MsgClass msgC = null;
			if (msgList.Contains(asmName))
			{
				Hashtable subList = msgList[asmName] as Hashtable;
				if (subList.Contains(msgID))  //해당 ID의 MSG가 있으면
				{
					msgC = subList[msgID] as MsgClass;
					msg = GetMsgSub(msgC);
					//Exception이 있으면 xe.Message를 SET
					if (xe != null)
						msg += "[" + xe.Message + "]";
				}
			}
			else  
			{
				/*각 Calling Assembly에서 MSG.xml 리소스를 가져와서 msgList 구성
				  리소스명 = NameSpace + MSG.xml 
				 * Namespace Rule은 Framework은 IHIS.Framework, 각 시스템은 IHIS.시스템ID
				 * Assembly에서 NameSpace를 가져오는 방법이 없고, Type에서 NameSpace를 가져와야함.
				 * GetExportedTypes()에서 types[0]의 NameSpace를 가져오고, 
				 * 없으면 Framework은 어셈블리명으로 IHIS.이면 IHIS.Framework, 시스템은 OCS.XXX이므로 OCS를 잘라 IHIS.OCS로 설정
				 */
				Type[] types = asm.GetExportedTypes();
				string nameSpace = "";
				if (types.Length > 0)
					nameSpace = types[0].Namespace;
				else  //else인 경우는 발생하지 않을 것임
				{
					if (asmName.IndexOf("IHIS.") >= 0)
						nameSpace = "IHIS.Framework";
					else
					{
						int index = asmName.IndexOf('.');
						if (index > 0)
							nameSpace = "IHIS." + asmName.Substring(0, index);
					}
				}
				string rexName = nameSpace + ".MSG.xml";
				Stream stream = asm.GetManifestResourceStream(rexName);
                XmlAttribute idAttr = null, koAttr = null, jpAttr = null, enAttr = null, viAttr = null;
				if (stream != null)  //XML Load
				{
					Hashtable msgListSub = new Hashtable();
					XmlDocument xmlDoc = new XmlDocument();
					try
					{
						xmlDoc.Load(stream);
					}
					catch(Exception ex)
					{
						Debug.WriteLine(ex.Message + "," + ex.StackTrace);
						return "";
					}
					foreach (XmlNode node in xmlDoc.DocumentElement)
					{
						//msg Load
						if (node.Name == "msgs")
						{
							foreach (XmlNode sNode in node.ChildNodes)
							{
								idAttr = sNode.Attributes["ID"];  //ID
								koAttr = sNode.Attributes["K"];  //한글
								jpAttr = sNode.Attributes["J"];  //일본어
								enAttr = sNode.Attributes["E"];  //영문
                                viAttr = sNode.Attributes["V"];

                                if ((idAttr == null) || (koAttr == null) || (jpAttr == null) || (enAttr == null))  //유효한 데이타 아님
                                    continue;

                                msgC = new MsgClass();
                                msgC.KoMsg = koAttr.Value;
                                msgC.JpMsg = jpAttr.Value;
                                msgC.EnMsg = enAttr.Value;
                                msgC.VnMsg = viAttr == null ? "" : viAttr.Value;
                                if (string.IsNullOrEmpty(msgC.EnMsg)) msgC.EnMsg = jpAttr.Value;
                                if (string.IsNullOrEmpty(msgC.VnMsg)) msgC.VnMsg = jpAttr.Value;
                                
								//msgListSub에 Add Key는 ID
								if (!msgListSub.Contains(idAttr.Value))
									msgListSub.Add(idAttr.Value, msgC);

								//동일한 ID이면 msg SET
								if (idAttr.Value == msgID)
								{
									msg = GetMsgSub(msgC);
									if (xe != null)
										msg += "[" + xe.Message + "]";
								}
							}
						}
					}
					//msgList에 HashTable Add
					msgList.Add(asmName, msgListSub);
				}
			}
			return msg;
		}
		
		//Calling하는 어셈블리를 넘겨서 처리함.
		public static string GetField(Assembly callAsm, string fieldID)
		{
			if (callAsm == null) return "";
			string asmName = callAsm.GetName().Name;
			string msg = "";
			MsgClass msgC = null;
			if (fidList.Contains(asmName))
			{
				Hashtable subList = fidList[asmName] as Hashtable;
				if (subList.Contains(fieldID))  //해당 ID의 MSG가 있으면
				{
					msgC = subList[fieldID] as MsgClass;
					msg = GetMsgSub(msgC);
				}
			}
			else
			{
				/*각 Calling Assembly에서 MSG.xml 리소스를 가져와서 msgList 구성
				  리소스명 = NameSpace + MSG.xml 
				 * Namespace Rule은 Framework은 IHIS.Framework, 각 시스템은 IHIS.시스템ID
				 * Assembly에서 NameSpace를 가져오는 방법이 없고, Type에서 NameSpace를 가져와야함.
				 * GetExportedTypes()에서 types[0]의 NameSpace를 가져오고, 
				 * 없으면 Framework은 어셈블리명으로 IHIS.이면 IHIS.Framework, 시스템은 OCS.XXX이므로 OCS를 잘라 IHIS.OCS로 설정
				 */
				Type[] types = callAsm.GetExportedTypes();
				string nameSpace = "";
				if (types.Length > 0)
					nameSpace = types[0].Namespace;
				else  //else인 경우는 발생하지 않을 것임
				{
					if (asmName.IndexOf("IHIS.") >= 0)
						nameSpace = "IHIS.Framework";
					else
					{
						int index = asmName.IndexOf('.');
						if (index > 0)
							nameSpace = "IHIS." + asmName.Substring(0, index);
					}
				}
				string rexName = nameSpace + ".MSG.xml";
				Stream stream = callAsm.GetManifestResourceStream(rexName);
                XmlAttribute idAttr = null, koAttr = null, jpAttr = null, enAttr = null, viAttr = null;
				if (stream != null)  //XML Load
				{
					Hashtable fidListSub = new Hashtable();
					XmlDocument xmlDoc = new XmlDocument();
					try
					{
						xmlDoc.Load(stream);
					}
					catch(Exception xe)
					{
						Debug.WriteLine(xe.Message + "," + xe.StackTrace);
						return "";
					}
					foreach (XmlNode node in xmlDoc.DocumentElement)
					{
						//field Load
						if (node.Name == "fids")  //Field Load
						{
							foreach (XmlNode sNode in node.ChildNodes)
							{
								idAttr = sNode.Attributes["ID"];  //ID
								koAttr = sNode.Attributes["K"];  //한글
								jpAttr = sNode.Attributes["J"];  //일본어
								enAttr = sNode.Attributes["E"];  //영문
								viAttr = sNode.Attributes["V"];

								if ((idAttr == null) || (koAttr == null) || (jpAttr == null) || (enAttr == null))  //유효한 데이타 아님
									continue;

								msgC = new MsgClass();
								msgC.KoMsg = koAttr.Value;
								msgC.JpMsg = jpAttr.Value;
								msgC.EnMsg = enAttr.Value;
							    msgC.VnMsg = viAttr == null ? "" : viAttr.Value;
                                if (string.IsNullOrEmpty(msgC.EnMsg)) msgC.EnMsg = jpAttr.Value;
                                if (string.IsNullOrEmpty(msgC.VnMsg)) msgC.VnMsg = jpAttr.Value;

								//fidListSub에 Add Key는 ID
								if (!fidListSub.Contains(idAttr.Value))
									fidListSub.Add(idAttr.Value, msgC);

								//동일한 ID의 값이면 msg SET
								if (idAttr.Value == fieldID)
									msg = GetMsgSub(msgC);
							}
						}
					}

					//fidList에 HashTable Add
					fidList.Add(asmName, fidListSub);
				}
			}
			return msg;

		}

		public static string GetField(string fieldID)
		{
			Assembly asm = Assembly.GetCallingAssembly();
			string asmName = asm.GetName().Name;
			string msg = "";
			MsgClass msgC = null;
			if (fidList.Contains(asmName))
			{
				Hashtable subList = fidList[asmName] as Hashtable;
				if (subList.Contains(fieldID))  //해당 ID의 MSG가 있으면
				{
					msgC = subList[fieldID] as MsgClass;
					msg = GetMsgSub(msgC);
				}
			}
			else
			{
				/*각 Calling Assembly에서 MSG.xml 리소스를 가져와서 msgList 구성
				  리소스명 = NameSpace + MSG.xml 
				 * Namespace Rule은 Framework은 IHIS.Framework, 각 시스템은 IHIS.시스템ID
				 * Assembly에서 NameSpace를 가져오는 방법이 없고, Type에서 NameSpace를 가져와야함.
				 * GetExportedTypes()에서 types[0]의 NameSpace를 가져오고, 
				 * 없으면 Framework은 어셈블리명으로 IHIS.이면 IHIS.Framework, 시스템은 OCS.XXX이므로 OCS를 잘라 IHIS.OCS로 설정
				 */
				Type[] types = asm.GetExportedTypes();
				string nameSpace = "";
				if (types.Length > 0)
					nameSpace = types[0].Namespace;
				else  //else인 경우는 발생하지 않을 것임
				{
					if (asmName.IndexOf("IHIS.") >= 0)
						nameSpace = "IHIS.Framework";
					else
					{
						int index = asmName.IndexOf('.');
						if (index > 0)
							nameSpace = "IHIS." + asmName.Substring(0, index);
					}
				}
				string rexName = nameSpace + ".MSG.xml";
				Stream stream = asm.GetManifestResourceStream(rexName);
				XmlAttribute idAttr = null, koAttr = null, jpAttr = null, enAttr = null, viAttr = null;
				if (stream != null)  //XML Load
				{
					Hashtable fidListSub = new Hashtable();
					XmlDocument xmlDoc = new XmlDocument();
					try
					{
						xmlDoc.Load(stream);
					}
					catch(Exception xe)
					{
						Debug.WriteLine(xe.Message + "," + xe.StackTrace);
						return "";
					}
					foreach (XmlNode node in xmlDoc.DocumentElement)
					{
						//field Load
						if (node.Name == "fids")  //Field Load
						{
							foreach (XmlNode sNode in node.ChildNodes)
							{
								idAttr = sNode.Attributes["ID"];  //ID
								koAttr = sNode.Attributes["K"];  //한글
								jpAttr = sNode.Attributes["J"];  //일본어
								enAttr = sNode.Attributes["E"];  //영문
							    viAttr = sNode.Attributes["V"];

								if ((idAttr == null) || (koAttr == null) || (jpAttr == null) || (enAttr == null))  //유효한 데이타 아님
									continue;

								msgC = new MsgClass();
								msgC.KoMsg = koAttr.Value;
								msgC.JpMsg = jpAttr.Value;
								msgC.EnMsg = enAttr.Value;
							    msgC.VnMsg = viAttr == null ? "" : viAttr.Value;
                                if (string.IsNullOrEmpty(msgC.EnMsg)) msgC.EnMsg = jpAttr.Value;
                                if (string.IsNullOrEmpty(msgC.VnMsg)) msgC.VnMsg = jpAttr.Value;
								//fidListSub에 Add Key는 ID
								if (!fidListSub.Contains(idAttr.Value))
									fidListSub.Add(idAttr.Value, msgC);

								//동일한 ID의 값이면 msg SET
								if (idAttr.Value == fieldID)
									msg = GetMsgSub(msgC);
							}
						}
					}

					//fidList에 HashTable Add
					fidList.Add(asmName, fidListSub);
				}
			}
			return msg;
		}

		private static string GetMsgSub(MsgClass msgC)
		{
			if (msgC == null) return "";

            switch (NetInfo.Language)
		    {
		        case   LangMode.Ko:
		            return msgC.KoMsg;
                case LangMode.Jr:
		            return msgC.JpMsg;
                case LangMode.Vi:
		            return msgC.VnMsg;
                case LangMode.En:
		            return msgC.EnMsg;
                default:
		            return msgC.JpMsg;

		    }
		}

    }
}
