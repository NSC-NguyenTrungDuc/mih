using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

//namespace OCS2015U30
namespace IHIS.OCSO
{
    public partial class ChoseTagParent : Form
    {
        private OCS2015U30 _mOCS2015U30;
        private int _currentRowNumber = 0;
        private string _colName = string.Empty;
        private string _currentValue = string.Empty;
        public ChoseTagParent(OCS2015U30 mOCS2015U30, int currentRowNumber, string colName, string currentValue, DataTable data)
        {
            InitializeComponent();
            this._mOCS2015U30 = mOCS2015U30;
            this._colName = colName;
            this._currentRowNumber = currentRowNumber;
            this._currentValue = currentValue;
            ((ListBox)this.cblParentLst).DataSource = data;
            ((ListBox)this.cblParentLst).ValueMember = data.Columns[0].ColumnName;// "TagId";
            ((ListBox)this.cblParentLst).DisplayMember = data.Columns[1].ColumnName;// "TagName";

            string[] currentValueArr = currentValue.Split(new char[] { ',' });
            for (int i = 0; i < currentValueArr.Length; i++)
            {
                for (int j = 0; j < cblParentLst.Items.Count; j++)
                {
                    DataRowView row = (DataRowView)cblParentLst.Items[j];
                    bool isChecked = (row[data.Columns[1].ColumnName].ToString() == currentValueArr[i].ToString()) ? true : false;
                    if (isChecked)
                    {
                        cblParentLst.SetItemChecked(j, isChecked);
                        break;
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string itemSelectedStr = string.Empty;
            for (int i = 0; i < cblParentLst.Items.Count; i++)
            {
                DataRowView row = (DataRowView)cblParentLst.Items[i];
                //bool isChecked = Convert.ToBoolean(row["checked"]);
                if (cblParentLst.GetItemChecked(i))
                {
                    itemSelectedStr += row.Row[1].ToString() + ",";
                }
            }
            itemSelectedStr = (itemSelectedStr.Length > 0) ? itemSelectedStr.Substring(0, itemSelectedStr.Length - 1) : string.Empty;
            _mOCS2015U30.GrdSetItemValue(_currentRowNumber, _colName, itemSelectedStr);
            this.Close();
        }
    }
}
