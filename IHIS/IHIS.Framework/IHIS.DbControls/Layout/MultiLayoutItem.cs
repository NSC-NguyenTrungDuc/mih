using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing.Design;
using System.Globalization;
using System.Windows.Forms;
using System.Text;
using System.ComponentModel.Design.Serialization;

namespace IHIS.Framework
{
    #region Enum DataType
    /// <summary>
    /// Data Type Enumeration
    /// </summary>
    public enum DataType
    {
        /// <summary>
        /// 데이타의 형식이 String입니다.
        /// </summary>
        String,
        /// <summary>
        /// 데이타의 형식이 Number입니다.
        /// </summary>
        Number,
        /// <summary>
        /// 데이타의 형식이 Date(yyyymmdd)입니다.
        /// </summary>
        Date,
        /// <summary>
        /// 데이타의 형식이 DateTime(yyyymmddhhmiss)입니다.
        /// </summary>
        DateTime
    }
    #endregion

    [Serializable,
    ToolboxItem(false),
    DesignTimeVisible(false)]
    public class MultiLayoutItem : System.ComponentModel.Component
    {
        #region Fields
        private string dataName = "";
        private DataType dataType = DataType.String;
        private bool isNotNull = false;
        private bool isUpdItem = false; //DB로 전송시 전송해야할 Item인지 여부
        #endregion

        #region Properties
        [Browsable(true),
        Category("Data"),
        DefaultValue("")]
        public string DataName
        {
            get { return dataName; }
            set { dataName = value; }
        }
        [Browsable(true),
        Category("Data"),
        DefaultValue(DataType.String)]
        public DataType DataType
        {
            get { return dataType; }
            set { dataType = value; }
        }
        [Browsable(true),
        Category("Data"),
        DefaultValue(false)]
        public bool IsNotNull
        {
            get { return isNotNull; }
            set { isNotNull = value; }
        }
        [Browsable(true),
        Category("Data"),
        DefaultValue(false)]
        public bool IsUpdItem
        {
            get { return isUpdItem; }
            set { isUpdItem = value; }
        }
        #endregion

        #region 생성자
        public MultiLayoutItem()
        {
        }
		//2007.11.08 Argument가 있는 생성자 추가(애니택 요청)
		public MultiLayoutItem(string dataName, DataType dataType)
			:this(dataName, dataType, false, false)
		{
		}
		public MultiLayoutItem(string dataName, DataType dataType, bool isNotNull, bool isUpdItem)
		{
			this.dataName = dataName;
			this.dataType = dataType;
			this.isNotNull = isNotNull;
			this.isUpdItem = isUpdItem;
		}
        #endregion
    }

    #region MultiLayout Item Collection
    /// <summary>
    /// MultiLayoutItem Collection
    /// </summary>
    [Serializable]
    [Editor(typeof(MultiLayoutItemsEditor), typeof(UITypeEditor))]
    public class MultiLayoutItemCollection : System.Collections.CollectionBase
    {
        public MultiLayoutItemCollection()
        {
        }

        public MultiLayoutItem this[int index]
        {
            get
            {
                if ((index < 0) || (index >= List.Count)) return null;

                return (MultiLayoutItem)List[index];
            }
        }

        public MultiLayoutItem this[string key]
        {
            get
            {
                if (key == "") return null;

                foreach (MultiLayoutItem item in this)
                {
                    if (item.DataName == key) return item;
                }
                return null;
            }
        }

        public void Add(MultiLayoutItem item)
        {
            //InitializeComponents에서 Serialize되는 순서가 AddRange -> Add가 먼저 발생하고,
            //다음에 XComboItem의 ValueItem과 DisplayItem이 설정되므로 ValueItem이 ""인 상태에서
            //Add가 발생하여 Exception이 발생함. 따라서, 동일한 값 확인여부를 Check하지 않음
            //foreach (MultiLayoutItem si in List)
            //{
            //    if (si.DataName == item.DataName)
            //        throw (new Exception("이미 등록된 항목명[" + si.DataName + "]과 동일합니다.[MultiLayoutItemCollection::Add]"));
            //}
            List.Add(item);
        }
		//2007.11.08 dataName, dataType을 바로 지정하는 Add하는 Add Method 추가
		public void Add(string dataName, DataType dataType)
		{
			MultiLayoutItem item = new MultiLayoutItem(dataName, dataType);
			List.Add(item);
		}
		public void Add(string dataName, DataType dataType, bool isNotNull, bool isUpdItem)
		{
			MultiLayoutItem item = new MultiLayoutItem(dataName, dataType, isNotNull, isUpdItem);
			List.Add(item);
		}

        public void AddRange(MultiLayoutItem[] items)
        {
            List.Clear();
            foreach (MultiLayoutItem Item in items)
            {
                Add(Item);
            }
        }
        public void Remove(string dataName)
        {
            int index = -1;
            foreach (MultiLayoutItem item in List)
            {
                index++;
                if (item.DataName == dataName)
                    break;
            }
            if (index >= 0)
                List.RemoveAt(index);
        }
        public void Remove(MultiLayoutItem item)
        {
            List.Remove(item);
        }
        public bool Contains(string dataName)
        {
            foreach (MultiLayoutItem item in List)
                if (item.DataName == dataName)
                    return true;
            return false;
        }
        public bool Contains(MultiLayoutItem item)
        {
            return List.Contains(item);
        }
        /// <summary>
        /// 컬렉션에 속하는 MultiLayoutItem을 MultiLayoutItem[]에 복사하여 반환합니다.
        /// </summary>
        /// <returns> SingleLayoutItem[] </returns>
        public MultiLayoutItem[] ToArray()
        {
            MultiLayoutItem[] itemArray = new MultiLayoutItem[List.Count];
            for (int i = 0; i < List.Count; i++)
                itemArray[i] = (MultiLayoutItem)List[i];
            return itemArray;
        }
    }
    #endregion
}
