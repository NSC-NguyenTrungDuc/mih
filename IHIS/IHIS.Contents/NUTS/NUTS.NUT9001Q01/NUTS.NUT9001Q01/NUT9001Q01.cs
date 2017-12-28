using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using IHIS.Framework;
using System.Globalization;

namespace IHIS.NUTS
{
    public partial class NUT9001Q01 : XScreen
    {
        public NUT9001Q01()
        {
            InitializeComponent();
        }

        private string mNut_date = "";
        private string mBLD_GUBUN = "";
        private string mMAGAM_SEQ = "";

        private void NUT9001Q01_ScreenOpen(object sender, XScreenOpenEventArgs e)
        {
            this.cboChangedGubun.SelectedIndex = 0;

            createHoDong();

            if (this.OpenParam != null && this.OpenParam.Contains("nut_date"))
                this.mNut_date = this.OpenParam["nut_date"].ToString();

            if (this.OpenParam != null && this.OpenParam.Contains("bld_gubun"))
                this.mBLD_GUBUN = this.OpenParam["bld_gubun"].ToString();

            if (this.OpenParam != null && this.OpenParam.Contains("magam_seq"))
                this.mMAGAM_SEQ = this.OpenParam["magam_seq"].ToString();

            this.dpkNut_date.SetDataValue(TypeCheck.NVL(this.mNut_date, EnvironInfo.GetSysDate()));
            this.cboBLD_GUBUN.SelectedIndex = 0;

            if (this.mBLD_GUBUN != "")
            {
                this.cboBLD_GUBUN.SetDataValue(this.mBLD_GUBUN);
            }

            //this.PostLoad();
            this.cboChangedGubun.SelectedValue = "1";
        }

        private void PostLoad()
        {
            createHoDong();
            createHoCode();

            this.grdList.QueryLayout(false);
        }
        private void createHoDong()
        {
            this.cboHodong.UserSQL = @"SELECT '%'
                                            , '全体'
                                         FROM SYS.DUAL
                                        UNION
                                       SELECT 'EMPTY'
                                            , '未指定'
                                         FROM SYS.DUAL
                                        UNION
                                       SELECT A.CODE
                                            , A.CODE_NAME
                                         FROM VW_IFS_IF_SKJ_HO_DONG A
                                        WHERE A.HOSP_CODE = FN_ADM_LOAD_HOSP_CODE()";
            this.cboHodong.SelectedIndex = 0;
        }
        private void createHoCode()
        {
//            this.cboHocode.SetBindVarValue("f_ho_dong", this.cboHodong.GetDataValue());
//            this.cboHocode.InitializeLifetimeService();
//            this.cboHocode.UserSQL = @"SELECT '%', '全体' 
//                                         FROM SYS.DUAL
//                                        UNION 
//                                       SELECT 'EMPTY', '未指定' 
//                                         FROM SYS.DUAL
//                                        UNION 
//                                       SELECT A.HO_CODE
//                                            , A.HO_CODE_NAME
//                                         FROM BAS0250 A
//                                        WHERE A.HOSP_CODE = FN_ADM_LOAD_HOSP_CODE()
//                                          AND A.HO_DONG   LIKE :f_ho_dong";
//            this.cboHocode.SelectedIndex = 0;
        }

        private void cboBLD_GUBUN_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cboChangedGubun.SelectedIndex = 0;

            if (this.cboBLD_GUBUN.SelectedValue != null)
            {
                XEditGrid grd = this.grdList;
                this.grdList.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                this.grdList.SetBindVarValue("f_nut_date", this.dpkNut_date.GetDataValue());
                this.grdList.SetBindVarValue("f_bld_gubun", this.cboBLD_GUBUN.SelectedValue.ToString());
                this.grdList.QueryLayout(false);

                //if (this.grdList.RowCount > 0)
                //    this.SetChangedDataDrawColor();

                this.grdList.Refresh();
            }
        }

        private void SetChangedDataDrawColor()
        {
            //for (int i = 0; i < this.grdList.RowCount; i++)
            //{
            //    if (this.grdList.GetItemString(i, "trans_yn") == "1")
            //    {
                   
                    
            //    }
            //}
        }
        private void grdList_GridCellPainting(object sender, XGridCellPaintEventArgs e)
        {
            if (e.DataRow["ipwon"].ToString() != "0" || e.DataRow["toiwon"].ToString() != "0" || e.DataRow["trans_room"].ToString() != "0" || e.DataRow["trans_nut"].ToString() != "0")
                e.BackColor = Color.LightBlue;

            if (   e.ColName == "to_direct_code_d" 
                && e.DataRow["to_direct_code_d"].ToString() != e.DataRow["from_direct_code_d"].ToString()
                && (e.DataRow["ipwon"].ToString() != "0" || e.DataRow["toiwon"].ToString() != "0" || e.DataRow["trans_room"].ToString() != "0" || e.DataRow["trans_nut"].ToString() != "0")
                )
                e.ForeColor = Color.Red;

            if (   e.ColName == "to_direct_code1_d" 
                && e.DataRow["to_direct_code1_d"].ToString() != e.DataRow["from_direct_code1_d"].ToString()
                && (e.DataRow["ipwon"].ToString() != "0" || e.DataRow["toiwon"].ToString() != "0" || e.DataRow["trans_room"].ToString() != "0" || e.DataRow["trans_nut"].ToString() != "0")
                )
                e.ForeColor = Color.Red;

            if (   e.ColName == "to_direct_code2_d" 
                && e.DataRow["to_direct_code2_d"].ToString() != e.DataRow["from_direct_code2_d"].ToString()
                && (e.DataRow["ipwon"].ToString() != "0" || e.DataRow["toiwon"].ToString() != "0" || e.DataRow["trans_room"].ToString() != "0" || e.DataRow["trans_nut"].ToString() != "0")
                )
                e.ForeColor = Color.Red;

            if (   e.ColName == "to_direct_code3_d" 
                && e.DataRow["to_direct_code3_d"].ToString() != e.DataRow["from_direct_code3_d"].ToString()
                && (e.DataRow["ipwon"].ToString() != "0" || e.DataRow["toiwon"].ToString() != "0" || e.DataRow["trans_room"].ToString() != "0" || e.DataRow["trans_nut"].ToString() != "0")
                )
                e.ForeColor = Color.Red;

            if (   e.ColName == "to_nomimono" 
                && e.DataRow["to_nomimono"].ToString() != e.DataRow["from_nomimono"].ToString()
                && (e.DataRow["ipwon"].ToString() != "0" || e.DataRow["toiwon"].ToString() != "0" || e.DataRow["trans_room"].ToString() != "0" || e.DataRow["trans_nut"].ToString() != "0")
                )
                e.ForeColor = Color.Red;

            if (   e.ColName == "to_kumjisik" 
                && e.DataRow["to_kumjisik"].ToString() != e.DataRow["from_kumjisik"].ToString()
                && (e.DataRow["ipwon"].ToString() != "0" || e.DataRow["toiwon"].ToString() != "0" || e.DataRow["trans_room"].ToString() != "0" || e.DataRow["trans_nut"].ToString() != "0")
                )
                e.ForeColor = Color.Red;

            if (   e.ColName == "to_ho_dong" 
                && e.DataRow["to_ho_dong"].ToString() != e.DataRow["from_ho_dong"].ToString()
                && (e.DataRow["ipwon"].ToString() != "0" || e.DataRow["toiwon"].ToString() != "0" || e.DataRow["trans_room"].ToString() != "0" || e.DataRow["trans_nut"].ToString() != "0")
                )
                e.ForeColor = Color.Red;

            if (   e.ColName == "to_ho_code" 
                && e.DataRow["to_ho_code"].ToString() != e.DataRow["from_ho_code"].ToString()
                && (e.DataRow["ipwon"].ToString() != "0" || e.DataRow["toiwon"].ToString() != "0" || e.DataRow["trans_room"].ToString() != "0" || e.DataRow["trans_nut"].ToString() != "0")
                )
                e.ForeColor = Color.Red;
        }


        private void dpkNut_date_TextChanged(object sender, EventArgs e)
        {
            this.cboChangedGubun.SelectedIndex = 0;

            if (this.cboBLD_GUBUN.SelectedValue != null)
            {
                XEditGrid grd = this.grdList;
                
                this.grdList.QueryLayout(false);

                //this.grdList.Refresh();
            }

            this.btnList.PerformClick(FunctionType.Query);
        }

        private void cboHodong_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cboChangedGubun.SelectedIndex = 0;

            this.btnList.PerformClick(FunctionType.Query);
        }

        private void grdList_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdList.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdList.SetBindVarValue("f_nut_date", this.dpkNut_date.GetDataValue());
            this.grdList.SetBindVarValue("f_bld_gubun", this.cboBLD_GUBUN.SelectedValue.ToString());
            this.grdList.SetBindVarValue("f_ho_dong", this.cboHodong.SelectedValue.ToString());
            this.grdList.SetBindVarValue("f_changed_gubun", this.cboChangedGubun.SelectedValue.ToString());
            this.grdList.SetBindVarValue("f_magam_seq", mMAGAM_SEQ);
            
        }

        private void cboChangedGubun_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.grdList.ClearFilter();

            if (this.cboChangedGubun.SelectedValue.ToString() == "%")
                this.grdList.SetFilter("");
            else if (this.cboChangedGubun.SelectedValue.ToString() == "1")
                this.grdList.SetFilter(" ipwon <> '0' OR toiwon <> '0' OR trans_room <> '0' OR trans_nut <> '0' OR cancel <> '0' ");
            else if (this.cboChangedGubun.SelectedValue.ToString() == "0")
                this.grdList.SetFilter(" ipwon = '0' AND toiwon = '0' AND trans_room = '0' AND trans_nut = '0' AND cancel = '0'");

            else if (this.cboChangedGubun.SelectedValue.ToString() == "2")
                this.grdList.SetFilter(" ipwon <> '0'");
            else if (this.cboChangedGubun.SelectedValue.ToString() == "9")
                this.grdList.SetFilter(" toiwon <> '0'");
            else if (this.cboChangedGubun.SelectedValue.ToString() == "8")
                this.grdList.SetFilter(" trans_nut <> '0'");
            else if (this.cboChangedGubun.SelectedValue.ToString() == "7")
                this.grdList.SetFilter(" trans_room <> '0'");
            else if (this.cboChangedGubun.SelectedValue.ToString() == "6")
                this.grdList.SetFilter(" cancel <> '0'");

            //else
            //    this.grdList.SetFilter(" ipwon = " + this.cboChangedGubun.SelectedValue.ToString() + " or");

            //this.grdList.Refresh();
        }
    }
}