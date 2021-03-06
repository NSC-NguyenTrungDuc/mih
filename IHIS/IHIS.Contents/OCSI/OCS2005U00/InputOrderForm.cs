#region 사용 NameSpace 지정
using System;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using IHIS.Framework;
#endregion

namespace IHIS.OCSI
{
    public partial class InputOrderForm : Form
    {
        public InputOrderForm()
        {
            InitializeComponent();
        }

        #region [Properties]
        private MultiLayout layParent;
        private MultiLayout layChild;
        private string jisiOrderGubun;

        public MultiLayout LAY_PARENT
        {
            get
            {
                return layParent;
            }
            set
            {
                layParent = value;
            }
        }

        public MultiLayout LAY_CHILD
        {
            get
            {
                return layChild;
            }
            set
            {
                layChild = value;
            }
        }

        public String JISI_ORDER_GUBUN
        {
            set
            {
                jisiOrderGubun = value;
            }
        }

        
        #endregion

        private void InputOrderForm_Load(object sender, EventArgs e)
        {
            if (layParent.RowCount > 0)
            {
                grdDirectData.ImportRowRange(layParent.LayoutTable, layParent.RowCount);

                Hashtable htTable = new Hashtable();
                htTable.Add("gr_code", grdDirectData.GetItemString(0, "direct_gubun"));
                htTable.Add("md_code", grdDirectData.GetItemString(0, "direct_code"));
                htTable.Add("so_code", grdDirectData.GetItemString(0, "direct_cont1"));

                dbxGubun.SetEditValue(grdDirectData.GetItemString(0, "direct_gubun_name"));
                dbxCode.SetEditValue (grdDirectData.GetItemString(0, "direct_code_name"));
                dbxCont.SetEditValue (ReturnSoName(htTable));
            }

            if (layChild.RowCount > 0)
            {
                grdDirectDetail.ImportRowRange(layChild.LayoutTable, layChild.RowCount);
            }

            grdDirectData.DisplayData();
            grdDirectDetail.DisplayData();

            switch (jisiOrderGubun)
            {
                case "3":   // 酸素療法
                    break;
                case "4":   // 人工呼吸
                    break;
                case "5":   // 薬・注射
                    break;
                case "6":   // 処置
                    break;
            }

        }

        private void btnList_ButtonClick(object sender, ButtonClickEventArgs e)
        {
            e.IsBaseCall = false;

            switch (e.Func)
            {
                case FunctionType.Process:
                    this.Dispose();
                    break;
                    
                case FunctionType.Cancel:
                    this.Dispose();
                    break;
            }
        }

        private void grdDirectData_GridColumnChanged(object sender, GridColumnChangedEventArgs e)
        {
        }

        private string ReturnSoName(Hashtable htTable)
        {
            object objScalar = null;
            string retVal = "";
            string cmdText = string.Format(@"SELECT NUR_SO_NAME
  FROM NUR0112
 WHERE NUR_GR_CODE = '{0}'
   AND NUR_MD_CODE = '{1}'
   AND NUR_SO_CODE = '{2}'
   AND HOSP_CODE   = FN_ADM_LOAD_HOSP_CODE", htTable["gr_code"].ToString(), htTable["md_code"].ToString(), htTable["so_code"].ToString());

            objScalar = Service.ExecuteScalar(cmdText);

            if (objScalar != null)
            {
                retVal = objScalar.ToString();
            }

            return retVal;
        }
    }    
}