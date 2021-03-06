using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Design;
using System.Reflection;
using System.Windows.Forms;

namespace IHIS.Framework
{
	/// <summary>
	/// SQL 구문을 분석하는 Helper입니다.
	/// </summary>
	public class SQLHelper
	{
		private static ArrayList bindVarNameList = new ArrayList();

		#region InitBindVarList
		/// <summary>
		/// SQL문에서 Bind Variables Collection 초기화
		/// </summary>
		/// <param name="sqlText"> SQL 문장 </param>
		/// <param name="bindVarList"> binding 정보 Collection </param>
		[Description("SQL문에서 Bind Variables를 Return합니다.")]
		public static void InitBindVarList(string sqlText, BindVarCollection bindVarList)
		{
			//기존 Data Clear
			bindVarList.Clear();

			//BindVariableName List SET
			SetBindVarNameList(sqlText);

			// 이름으로 Unique하게 List작성
			foreach (string varName in bindVarNameList)
			{
				if (!bindVarList.Contains(varName))
					bindVarList.Add(varName);
			}
		}

        [Description("Bind Variables From Parameters List")]
        public static void InitBindVarListFromParamList(List<String> paramList, BindVarCollection bindVarList)
        {
            //Data Clear
            bindVarList.Clear();

            //BindVariableName List SET
            bindVarNameList.Clear();
            foreach (string varName in paramList)
            {
                string paramName = varName;
                if (paramName == "")
                    paramName = "Var" + (bindVarNameList.Count + 1).ToString();
                bindVarNameList.Add(paramName);
            }

            //Unique List of bind var name
            foreach (string varName in bindVarNameList)
            {
                if (!bindVarList.Contains(varName))
                    bindVarList.Add(varName);
            }
        }
		#endregion

		#region SetBindVarNameList
		private static void SetBindVarNameList(string sqlText)
		{
			int pos = -1;
			int	startIndex = 0;
			int	index = startIndex;
			int cmtPos;
			bool loopExit = false;

			bindVarNameList.Clear();
			//2006.07.11 Bind 변수의 판단을 BindSymbol로 통일 (Oracle -> :, SqlServer -> @)
			while (((pos = sqlText.IndexOf(Service.BindSymbol, index)) >= 0) && !loopExit)
			{
				index = pos + 1;
				// 앞의 Character가 separator인지 여부 확인
				if (pos > 0)
				{
					if (!IsDelimiter(sqlText[pos-1])) continue;
					//2007.11.06 PL/SQL Block에서 쓴 변수 T_V VARCHAR2(10) := '';에서 := 형태의 SQL문은 BIND변수로 인식하지 않는다.
					if ((index < sqlText.Length) && (sqlText[index] == '='))
					{
						index++; //다음 위치로 이동
						continue; //다음 위치의 BIND 변수 Search
					}
				}
				// Comment인지 여부 확인
				string chkStmt = sqlText.Substring(startIndex, pos - startIndex);
				if ((cmtPos = chkStmt.LastIndexOf("/*")) >= 0)
					if (chkStmt.IndexOf("*/", cmtPos + 2) < 0) continue;
				if ((cmtPos = chkStmt.LastIndexOf("--")) >= 0)
					if (chkStmt.IndexOf("\n", cmtPos + 2) < 0) continue;
				if ((StrContains(chkStmt, "\'", 0) % 2) >= 1) continue;
				loopExit = true;
				for (int i = pos+1; i <= sqlText.Length; i++)
				{
					if (i == sqlText.Length)
					{
						string varName = sqlText.Substring(pos+1);
						if (varName == "")
							varName = "Var" + (bindVarNameList.Count + 1).ToString();
						bindVarNameList.Add(varName);
						loopExit = true;
						break;
					}
					else if (IsDelimiter(sqlText[i]))
					{
						string varName = sqlText.Substring(pos+1, i - pos - 1);
						if (varName == "")
							varName = "Var" + (bindVarNameList.Count + 1).ToString();
						bindVarNameList.Add(varName);
						startIndex = i;
						index = startIndex;
						loopExit = false;
						break;
					}
				}
			}
		}
		#endregion

		#region StrContains 
		/// <summary>
		///  String에서 targer문자열이 포함된 회수를 Return한다.
		/// </summary>
		/// <param name="source"></param>
		/// <param name="target"></param>
		/// <param name="startIndex"></param>
		/// <returns></returns>
		private static int StrContains(string source, string target, int startIndex)
		{
			int count = 0, pos;
			int	index = startIndex;
			while ((pos = source.IndexOf(target, index)) >= 0)
			{
				index = pos + target.Length;
				count++;
			}
			return count;
		}
		#endregion

		#region IsDelimiter
		[Description("문자가 Delimiter인지 여부를 Return합니다.")]
		private static bool IsDelimiter(char ch)
		{
			return !( (char.IsLetterOrDigit(ch)) || (ch == '_') );
		}
		#endregion
	}
}
