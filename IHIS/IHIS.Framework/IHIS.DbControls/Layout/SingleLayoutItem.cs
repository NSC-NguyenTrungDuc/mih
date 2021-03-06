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
    #region SingleLayout Item
    /// <summary>
    /// SingleLayout Item
    /// </summary>
    [Serializable,
    ToolboxItem(false),
    DesignTimeVisible(false)]
    public class SingleLayoutItem : System.ComponentModel.Component
    {
        #region Fields
        private string dataName = "";
        private Control bindControl = null; //Binding된 IDataControl, IBizComponent
        private string bindVariable = "";  //Binding된 Property Name
        private object dataValue = "";
        private bool isUpdItem = false;
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
        DefaultValue(false)]
        public bool IsUpdItem
        {
            get { return isUpdItem; }
            set { isUpdItem = value; }
        }

        [Browsable(true),
        Category("Data"),
        DefaultValue(null)]
        public Control BindControl
        {
            get { return bindControl; }
            set { bindControl = value; }
        }

        [Browsable(true),
        Category("Data"),
        DefaultValue(""),
        NotifyParentProperty(true)]
        public string BindVariable
        {
            get { return bindVariable; }
            set { bindVariable = value; }
        }
        [Browsable(true),
        Category("Data"),
        DefaultValue(null),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object DataValue
        {
            get { return dataValue; }
            set { dataValue = value; }
        }
        #endregion

        #region 생성자
        public SingleLayoutItem()
        {
        }
		//2007.11.08 Argument가 있는 생성자 추가(애니택 요청)
		public SingleLayoutItem(string dataName)
		{
			this.dataName = dataName;
		}
		public SingleLayoutItem(string dataName, bool isUpdItem)
		{
			this.dataName = dataName;
			this.isUpdItem = isUpdItem;
		}
        #endregion
    }
    #endregion

    #region SingleLayout Item Collection
    /// <summary>
    /// DataLayout Item Collection
    /// </summary>
    [Serializable]
    [Editor(typeof(SingleLayoutItemsEditor), typeof(UITypeEditor))]
    public class SingleLayoutItemCollection : System.Collections.CollectionBase
    {
        public SingleLayoutItemCollection()
        {
        }

        public SingleLayoutItem this[int index]
        {
            get
            {
                if ((index < 0) || (index >= List.Count)) return null;

                return (SingleLayoutItem)List[index];
            }
        }

        public SingleLayoutItem this[string key]
        {
            get
            {
                if (key == "") return null;

                foreach (SingleLayoutItem item in this)
                {
                    if (item.DataName == key) return item;
                }
                return null;
            }
        }

        public void Add(SingleLayoutItem item)
        {
            //InitializeComponents에서 Serialize되는 순서가 AddRange -> Add가 먼저 발생하고,
            //다음에 XComboItem의 ValueItem과 DisplayItem이 설정되므로 ValueItem이 ""인 상태에서
            //Add가 발생하여 Exception이 발생함. 따라서, 동일한 값 확인여부를 Check하지 않음
            //foreach (SingleLayoutItem si in List)
            //{
            //    if (si.DataName == item.DataName)
            //        throw (new Exception("이미 등록된 항목명[" + si.DataName + "]과 동일합니다.[SingleLayoutItemCollection::Add]"));
            //}
            List.Add(item);
        }
		//2007.11.08 dataName, isUpdItem을 바로 지정하는 Add하는 Add Method 추가
		public void Add(string dataName)
		{
			SingleLayoutItem	item = new SingleLayoutItem(dataName);
			List.Add(item);
		}
		public void Add(string dataName, bool isUpdItem)
		{
			SingleLayoutItem	item = new SingleLayoutItem(dataName, isUpdItem);
			List.Add(item);
		}
        public void AddRange(SingleLayoutItem[] items)
        {
            List.Clear();
            foreach (SingleLayoutItem Item in items)
            {
                Add(Item);
            }
        }
        public void Remove(string dataName)
        {
            int index = -1;
            foreach (SingleLayoutItem si in List)
            {
                index++;
                if (si.DataName == dataName)
                    break;
            }
            if (index >= 0)
                List.RemoveAt(index);
        }
        public void Remove(SingleLayoutItem item)
        {
            List.Remove(item);
        }
        public bool Contains(string dataName)
        {
            foreach (SingleLayoutItem si in List)
                if (si.DataName == dataName)
                    return true;
            return false;
        }
        public bool Contains(SingleLayoutItem item)
        {
            return List.Contains(item);
        }
        /// <summary>
        /// 컬렉션에 속하는 SingleLayoutItem을 SingleLayoutItem[]에 복사하여 반환합니다.
        /// </summary>
        /// <returns> SingleLayoutItem[] </returns>
        public SingleLayoutItem[] ToArray()
        {
            SingleLayoutItem[] itemArray = new SingleLayoutItem[List.Count];
            for (int i = 0; i < List.Count; i++)
                itemArray[i] = (SingleLayoutItem)List[i];
            return itemArray;
        }

    }
    #endregion
}
