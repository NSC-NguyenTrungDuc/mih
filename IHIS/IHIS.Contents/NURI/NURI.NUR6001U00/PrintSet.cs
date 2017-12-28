using System;
using System.IO;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using IHIS.Framework;
using IHIS.NURI;

namespace IHIS.NURI
{
    public partial class PrintSet : XForm
    {
        #region 사용자 변수
        string bunho;   //환자번호
        DateTime from_date; //욕창 개시일
        DateTime assessor_date; //현재 선택 일
        bool selectAll = false; //부위 전체선택 여부

        private string strServer = EnvironInfo.GetDownloadServerIP();
        private string strFtpUser = "";
        private string strFtpPass = "";

        private string strServerPath = "";//"/home/medi/IHIS/NURIImages/";
        private string strClientPath = "";//"C:\\IHIS\\NURIImages\\";

        #endregion

        #region 생성자
        public PrintSet(string bunho, DateTime from_date, DateTime assessor_date)
        {
            this.bunho = bunho;
            this.from_date = from_date;
            this.assessor_date = assessor_date;
            InitializeComponent();
        }
        private void PrintSet_Load(object sender, EventArgs e)
        {
            this.layBuwi.QueryLayout(true);
            this.dtpStart_Date.SetDataValue(this.assessor_date.ToShortDateString());
            this.dtpEnd_Date.SetDataValue(EnvironInfo.GetSysDate());

            object retVal = null;
            string cmdText = @"SELECT CODE_NAME
                                  FROM NUR0102
                                 WHERE HOSP_CODE = :f_hosp_code 
                                   AND CODE_TYPE = 'FTP_OPTION'
                                   AND CODE      = UPPER(:f_gubun)";

            BindVarCollection bc = new BindVarCollection();
            strFtpUser = EnvironInfo.GetImageUserID();
            strFtpPass = EnvironInfo.GetImageUserPW();

            bc.Clear();
            bc.Add("f_hosp_code", EnvironInfo.HospCode);
            bc.Add("f_gubun", "server_image_path");

            retVal = Service.ExecuteScalar(cmdText, bc);

            if (TypeCheck.IsNull(retVal))
            {
                XMessageBox.Show("コード管理画面にてFTP_OPTION情報(SERVER_IMAGE_PATH)を登録してください。");
                return;
            }

            strServerPath = retVal.ToString();

            bc.Clear();
            bc.Add("f_hosp_code", EnvironInfo.HospCode);
            bc.Add("f_gubun", "client_image_path");

            retVal = Service.ExecuteScalar(cmdText, bc);

            if (TypeCheck.IsNull(retVal))
            {
                XMessageBox.Show("コード管理画面にてFTP_OPTION情報(CLIENT_IMAGE_PATH)を登録してください。");
                return;
            }

            strClientPath = retVal.ToString();
        }

        #endregion

        #region grdPrint_QueryStarting
        private void grdPrint_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdPrint.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdPrint.SetBindVarValue("f_bunho", this.bunho);
            this.grdPrint.SetBindVarValue("f_from_date", this.from_date.ToShortDateString());
            this.grdPrint.SetBindVarValue("f_buwi1", this.cbxBuwi1.GetDataValue());
            this.grdPrint.SetBindVarValue("f_buwi2", this.cbxBuwi2.GetDataValue());
            this.grdPrint.SetBindVarValue("f_buwi3", this.cbxBuwi3.GetDataValue());
            this.grdPrint.SetBindVarValue("f_buwi4", this.cbxBuwi4.GetDataValue());
            this.grdPrint.SetBindVarValue("f_buwi5", this.cbxBuwi5.GetDataValue());
            this.grdPrint.SetBindVarValue("f_buwi6", this.cbxBuwi6.GetDataValue());
            if (this.cbxDate_All.Checked)
            {
                this.grdPrint.SetBindVarValue("f_assessor_start_date", this.from_date.ToShortDateString());
                this.grdPrint.SetBindVarValue("f_assessor_end_date", "9998-12-31");
            }
            else
            {
                this.grdPrint.SetBindVarValue("f_assessor_start_date", this.dtpStart_Date.GetDataValue());
                this.grdPrint.SetBindVarValue("f_assessor_end_date", this.dtpEnd_Date.GetDataValue());
            }
        }

        #endregion

        #region layBuwi
        private void layBuwi_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layBuwi.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.layBuwi.SetBindVarValue("f_bunho", bunho);
            this.layBuwi.SetBindVarValue("f_from_date", from_date.ToShortDateString());
        }

        //조회 된 부위를 체크박스에 셋팅해준다.
        private void layBuwi_QueryEnd(object sender, QueryEndEventArgs e)
        {
            if (this.layBuwi.GetItemString(0, "chk1") != "")
            {
                this.cbxBuwi1.Visible = true;
                this.cbxBuwi1.Text = this.layBuwi.GetItemString(0, "chk1");
                this.cbxBuwi1.CheckedValue = this.layBuwi.GetItemString(0, "bedsore_buwi1");
            }
            if (this.layBuwi.GetItemString(0, "chk2") != "")
            {
                this.cbxBuwi2.Visible = true;
                this.cbxBuwi2.Text = this.layBuwi.GetItemString(0, "chk2");
                this.cbxBuwi2.CheckedValue = this.layBuwi.GetItemString(0, "bedsore_buwi2");
            }

            if (this.layBuwi.GetItemString(0, "chk3") != "")
            {
                this.cbxBuwi3.Visible = true;
                this.cbxBuwi3.Text = this.layBuwi.GetItemString(0, "chk3");
                this.cbxBuwi3.CheckedValue = this.layBuwi.GetItemString(0, "bedsore_buwi3");
            }

            if (this.layBuwi.GetItemString(0, "chk4") != "")
            {
                this.cbxBuwi4.Visible = true;
                this.cbxBuwi4.Text = this.layBuwi.GetItemString(0, "chk4");
                this.cbxBuwi4.CheckedValue = this.layBuwi.GetItemString(0, "bedsore_buwi4");
            }

            if (this.layBuwi.GetItemString(0, "chk5") != "")
            {
                this.cbxBuwi5.Visible = true;
                this.cbxBuwi5.Text = this.layBuwi.GetItemString(0, "chk5");
                this.cbxBuwi5.CheckedValue = this.layBuwi.GetItemString(0, "bedsore_buwi5");
            }

            if (this.layBuwi.GetItemString(0, "chk6") != "")
            {
                this.cbxBuwi6.Visible = true;
                this.cbxBuwi6.Text = this.layBuwi.GetItemString(0, "chk6");
                this.cbxBuwi6.CheckedValue = this.layBuwi.GetItemString(0, "bedsore_buwi6");
            }

        }

        #endregion

        #region cbxDate_All_CheckedChanged
        private void cbxDate_All_CheckedChanged(object sender, EventArgs e)
        {
            if (this.cbxDate_All.Checked)
            {
                this.dtpEnd_Date.Enabled = false;
                this.dtpStart_Date.Enabled = false;
            }
            else
            {
                this.dtpEnd_Date.Enabled = true;
                this.dtpStart_Date.Enabled = true;
            }
        }
        #endregion

        #region 취소버튼~
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region 출력버튼~
        private void btnPrint_Click(object sender, EventArgs e)
        {
            this.grdPrint.Reset();
            this.dwPrint.Reset();
            this.grdPrint.QueryLayout(true);
            foreach (DataRow dr in this.grdPrint.LayoutTable.Rows)
            {
                this.layPrintLoad.LayoutTable.ImportRow(dr);
                this.dwPrint.FillData(layPrintLoad.LayoutTable);
                this.dwPrint.Modify("p_5.filename='" + this.layPrintLoad.GetItemString(0, "image") + "'");
                //this.dwPrint.Modify("p_5.height='100%'");
                this.dwPrint.Refresh();
                this.dwPrint.Print();
                if (this.layImage.LayoutItems.Contains(this.layPrintLoad.GetItemString(0, "image")))
                {
                    File.Delete(this.layPrintLoad.GetItemString(0, "image"));
                }
                //if (this.layImage.RowCount > 0)
                //{
                //    File.Delete(this.layPrintLoad.GetItemString(0, "image"));
                //}
                this.layPrintLoad.Reset();
                this.dwPrint.Reset();
            }
            this.Close();
        }
        #endregion

        #region grdPrint_QueryEnd 이미지 불러와서 붙여준다~
        private void grdPrint_QueryEnd(object sender, QueryEndEventArgs e)
        {
            if (this.grdPrint.RowCount < 1)
                return;

            for (int i = 0; i < this.grdPrint.RowCount; i++)
            {
                this.layImage.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                this.layImage.SetBindVarValue("f_bunho", this.grdPrint.GetItemString(i, "bunho"));
                this.layImage.SetBindVarValue("f_from_date", this.grdPrint.GetItemString(i, "from_date"));
                this.layImage.SetBindVarValue("f_assessor_date", this.grdPrint.GetItemString(i, "assessor_date"));
                this.layImage.SetBindVarValue("f_buwi", this.grdPrint.GetItemString(i, "bedsore_buwi"));
                this.layImage.QueryLayout(true);
                if (this.layImage.RowCount > 0)
                {
                    string strKey = "";
                    if (!Directory.Exists(strClientPath))
                        Directory.CreateDirectory(strClientPath);
                    IHIS.Framework.XFTPWorker ftp = null;
                    Image image = null;
                    bool isMakeDir = true;

                    try
                    {
                        char[] spliter = { '/' };
                        string[] array1 = strServerPath.Split(spliter);
                        ArrayList array2 = new ArrayList();
                        IHIS.Framework.XFTPWorker.DirItems dirItem = new XFTPWorker.DirItems();

                        ftp = new XFTPWorker(strFtpUser, strFtpPass, strServer);
                        if (ftp.Connected)
                        {
                            isMakeDir = true;
                            array2 = ftp.GetDirList(false);
                            for (int j = 0; j < array1.Length; j++)
                            {
                                if (array1[j] == "")
                                    continue;

                                isMakeDir = true;
                                array2 = ftp.GetDirList(false);
                                for (int k = 0; k < array2.Count; k++)
                                {
                                    dirItem = (IHIS.Framework.XFTPWorker.DirItems)array2[k];
                                    if (dirItem.IsFile)
                                        continue;
                                    if (array1[j] == "#PatienID")
                                    {
                                        if (dirItem.Filename == bunho)
                                            isMakeDir = false;
                                    }
                                    else
                                    {
                                        if (dirItem.Filename == array1[j])
                                            isMakeDir = false;
                                    }
                                }

                                if (array1[j] == "#PatienID")
                                {
                                    if (isMakeDir)
                                        if (!ftp.MakeDir(bunho))
                                            throw new Exception("MakeDir Error");
                                    if (!ftp.ChangeDir(bunho))
                                        throw new Exception("ChangeDir Error");
                                }
                                else
                                {
                                    if (isMakeDir)
                                        if (!ftp.MakeDir(array1[j]))
                                            throw new Exception("MakeDir Error");
                                    if (!ftp.ChangeDir(array1[j]))
                                        throw new Exception("ChangeDir Error");
                                }
                            }
                            strKey = this.layImage.GetItemString(0, "image_path");
                            if (this.layImage.GetItemString(0, "image_path").Length > 0)
                            {
                                Directory.SetCurrentDirectory(strClientPath);
                                ftp.SendFileToClient(strKey, strKey);
                                Directory.SetCurrentDirectory(@"C:\\IHIS\\bin\\");

                                image = Image.FromFile(strClientPath + strKey);
                                this.grdPrint.SetItemValue(i, "image", strClientPath + strKey);
                                image.Dispose();
                            }
                            if (!TypeCheck.IsNull(ftp))
                                ftp.Close();
                        }
                        else
                        {
                            if (!TypeCheck.IsNull(ftp))
                                ftp.Close();
                            XMessageBox.Show("FTPログインに失敗しました");
                            return;
                        }

                    }
                    catch (Exception ex)
                    {
                        if (!TypeCheck.IsNull(image))
                            image.Dispose();

                        if (!TypeCheck.IsNull(ftp))
                            ftp.Close();
						//https://sofiamedix.atlassian.net/browse/MED-10610
                        //XMessageBox.Show("イメージ取り込み中にエラーが発生しました。 : " + ex.ToString());
                    }

                    this.grdPrint.ResetUpdate();
                }

            }

        }
        #endregion

        #region 부위 전체선택 버튼
        private void btnBuwi_All_Click(object sender, EventArgs e)
        {
            if (this.selectAll) //전체 선택 중이라면~
            {
                this.cbxBuwi1.Checked = false;
                this.cbxBuwi2.Checked = false;
                this.cbxBuwi3.Checked = false;
                this.cbxBuwi4.Checked = false;
                this.cbxBuwi5.Checked = false;
                this.cbxBuwi6.Checked = false;
                this.selectAll = false;

            }
            else   //전체 선택중이 아니라면~
            {
                this.cbxBuwi1.Checked = true;
                this.cbxBuwi2.Checked = true;
                this.cbxBuwi3.Checked = true;
                this.cbxBuwi4.Checked = true;
                this.cbxBuwi5.Checked = true;
                this.cbxBuwi6.Checked = true;
                this.selectAll = true;
            }
        }
        #endregion
    }
}