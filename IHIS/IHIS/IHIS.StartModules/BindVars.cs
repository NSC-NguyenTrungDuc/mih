using System;

namespace IHIS
{
	#region BindVar
	public class BindVar
	{
		private string	varName = string.Empty;
		private string	varValue = string.Empty;
		private int		valueLen = 100;      //Value일때의 Length를 지정합니다.(기본값 100, 더 크게 잡을시만 사용)
		public string VarName
		{
			get { return varName;}
		}
		public string VarValue
		{
			get { return varValue;}
			set { varValue = value;}
		}
		public int ValueLen
		{
			get { return valueLen;}
			set { valueLen = Math.Max(100, value);}
		}
		public BindVar(string varName)
			:this(varName, "", 100){}
		public BindVar(string varName, string varValue)
			: this(varName, varValue, 100){}
		public BindVar(string varName, string varValue, int valueLen)
		{
			this.varName = varName;
			this.varValue = varValue;
			this.valueLen = valueLen;
		}

	}
	#endregion

	#region BindVarCollection
	public class BindVarCollection : System.Collections.CollectionBase
	{
		public BindVar this[int index]
		{
			get
			{
				if ((index < 0) || (index >= List.Count)) return null;
				return (BindVar) List[index];
			}
		}
		public BindVar this[string key]
		{
			get 
			{
				if (key == "") return null;
				foreach (BindVar var in List)
					if (var.VarName == key)
						return var;
				return null;
			}
		}
		public void Add(string varName, string varValue, int valueLen)
		{
			bool isFound = false;
			//이미 있으면 Value만 다시 설정
			foreach (BindVar item in List)
			{
				if (item.VarName == varName)
				{
					isFound = true;
					item.VarValue = varValue;
					item.ValueLen = valueLen;
					break;
				}
			}
			if (!isFound)
			{
				BindVar var = new BindVar(varName, varValue, valueLen);
				List.Add(var);
			}
		}
		public void Add(string varName, string varValue)
		{
			Add(varName, varValue, 100);
		}
		public void Add(string varName)
		{
			Add(varName, string.Empty);
		}
		public void Remove(string varName)
		{
			int index = 0;
			bool isFound = false;
			foreach (BindVar item in List)
			{
				if (item.VarName == varName)
				{
					isFound = true;
					break;
				}
				index++;
			}
			if (isFound)
				this.RemoveAt(index);
		}
		public bool Contains(string varName)
		{
			foreach (BindVar item in List)
				if (item.VarName == varName)
					return true;
			return false;
		}
	}
	#endregion
}
