using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using IHIS.Framework;

namespace IHIS.OCSI
{
    public partial class SelectDayFrom : IHIS.Framework.XForm
    {
        public SelectDayFrom(int aMaxIlsu, MultiLayout aDataLayout)
        {
            InitializeComponent();

            this.mMaxIlsu = aMaxIlsu;
            this.mLayData = aDataLayout;

            this.nudIlsu.SetDataValue(mMaxIlsu + 1);
        }

        #region Form 변수 

        private int mMaxIlsu = 0;
        private MultiLayout mLayData;
        public int mReturnIlsu = 0;

        private string mMsg = "";
        private string mCap = "";

        #endregion

        private void SelectDayFrom_Load(object sender, EventArgs e)
        {

        }

        private bool IsValidIlsu()
        {
            if (nudIlsu.GetDataValue() == "")
            {
                this.mMsg = "日次を入力して下さい｡";
                this.mCap = "確認";

                MessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }

            foreach (DataRow dr in this.mLayData.LayoutTable.Rows)
            {
                if (dr["jaewonil"].ToString() == this.nudIlsu.GetDataValue())
                {
                    this.mMsg = "選択した日次は重複です｡";
                    this.mCap = "確認";

                    MessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            return true;
        }

        private void btnList_ButtonClick(object sender, ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Process:

                    e.IsBaseCall = false;

                    this.AcceptData();

                    if (this.IsValidIlsu())
                    {
                        this.mReturnIlsu = int.Parse(this.nudIlsu.GetDataValue());
                        this.DialogResult = DialogResult.OK;
                    }

                    break;

                case FunctionType.Close:

                    e.IsBaseCall = false;

                    this.DialogResult = DialogResult.Cancel;

                    break;
            }
        }
    }
}