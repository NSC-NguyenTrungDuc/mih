using System;

namespace IHIS.Framework
{
	/// <summary>
	/// OpenCommand에 대한 요약 설명입니다.
	/// 화면 Open시 전달되는 OpenCommand를 관리하는 class
	/// </summary>
	public class OpenCommand
	{
		private string command = "";
		private CommonItemCollection items = new CommonItemCollection();
		public string Command
		{
			get { return command;}
		}
		public CommonItemCollection Items
		{
			get { return items;}
		}
		public OpenCommand(string command)
		{
			this.command = command;
		}
	}
}
