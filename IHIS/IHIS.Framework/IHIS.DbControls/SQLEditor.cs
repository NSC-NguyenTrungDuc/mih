using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace IHIS.Framework
{
	/// <summary> 
	/// SQLEditor에 대한 요약 설명입니다. 
	/// </summary> 
	internal class SQLEditor : TextEditor 
	{
		protected override TextEditorForm CreateEditorForm(string text)
		{
			return new TextEditorForm("SQL Editor", text);  //SQL Editor
		}
	}
}