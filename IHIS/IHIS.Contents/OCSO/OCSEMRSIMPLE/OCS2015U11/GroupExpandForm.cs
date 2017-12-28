using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;
using EmrDocker;
using EmrDocker.Models;
using EmrDockerS;
using IHIS.CloudConnector.Contracts.Models.Ocso;
using IHIS.CloudConnector.Contracts.Models.Outs;
using IHIS.Framework;
using System;
namespace IHIS.OCSO
{
    public partial class GroupExpandForm : UserControl
    {
        #region Contructor
        public GroupExpandForm()
        {
            InitializeComponent();
            BindingDataAndCollapsedGroup();
            SetdefaultLableToLayGroup();
        }

        #endregion

        #region Field & properties
        private List<LayoutControlGroup> groups = new List<LayoutControlGroup>();
        Dictionary<string, string> ProblemDic = new Dictionary<string, string>();
        private const string lblSpace = "      ";
        private const string lblSpace1 = "               ";
        private const string lblY = "Y";
        private const string lblN = "N";
        private const string lblYes = "Yes";
        private const string lblNo = "No";
        private const string lblDefaultTextLayItem = ".";
        private string noteSpecial = "";

        public string NoteSpecial
        {
            get { return noteSpecial; }
            set { noteSpecial = value; }
        }

        #endregion

        #region Event
        private void layoutControl1_GroupExpandChanged(object sender, DevExpress.XtraLayout.Utils.LayoutGroupEventArgs e)
        {
            if (e.Group.Expanded)
                CollapseGroups(e.Group as LayoutControlGroup);
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridView1.IsDataRow(e.FocusedRowHandle))
            {
                OUT0106U00GridItemInfo out0106U00GridItemObj = gridView1.GetFocusedRow() as OUT0106U00GridItemInfo;
                if (out0106U00GridItemObj != null)
                    layGroupSpecialNote.Text = Resources.GroupExpandForm_LblGroupSpecialNode + lblSpace + out0106U00GridItemObj.Comments;
            }
        }

        private void gridView2_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridView2.IsDataRow(e.FocusedRowHandle))
            {
                DataRow dtRHandle = gridView2.GetDataRow(e.FocusedRowHandle);
                if (dtRHandle != null)
                {
                    string key = dtRHandle[0].ToString();
                    string value = dtRHandle[1].ToString();
                    layGroupProblem.Text = Resources.GroupExpandForm_LblGroupProblem + lblSpace1 + key + lblSpace + value;
                }
            }
        }
        #endregion

        #region Method
        public void LoadExpandedGroup(List<OUT0106U00GridItemInfo> listSpecialNode, List<TagInfo> lstTagInfos, List<OcsoOCS1003P01GridOutSangInfo> lstOutSangInfo)
        {
            ResetAllLayGroup();
            BindingToGrdProblem(lstTagInfos);
            BindingToGrdDisease(lstOutSangInfo);
            BindingToGrdSpecialNode(listSpecialNode);
        }

        public void LoadExpandedGroup(List<OUT0106U00GridItemInfo> listSpecialNode, List<TagInfo> lstTagInfos, List<OcsoOCS1003P01GridOutSangInfo> lstOutSangInfo, bool isShowLaySpecialNode, bool isShowLayProblem, bool isShowLayDisease)
        {
            layGroupSpecialNote.Visibility = isShowLaySpecialNode ? LayoutVisibility.Always : LayoutVisibility.Never;
            layGroupProblem.Visibility = isShowLayProblem ? LayoutVisibility.Always : LayoutVisibility.Never;
            layGroupDisease.Visibility = isShowLayDisease ? LayoutVisibility.Always : LayoutVisibility.Never;
            if (listSpecialNode != null && lstTagInfos != null && lstOutSangInfo != null)
                LoadExpandedGroup(listSpecialNode, lstTagInfos, lstOutSangInfo);
        }

        public void LoadExpandedGroup(string bunho)
        {
            List<OUT0106U00GridItemInfo> listSpecialNode = new List<OUT0106U00GridItemInfo>();
            List<TagInfo> lstTagInfos = new List<TagInfo>();
            List<OcsoOCS1003P01GridOutSangInfo> lstOutSangInfo = new List<OcsoOCS1003P01GridOutSangInfo>();

            // get data
            LoadExpandedGroup(listSpecialNode, lstTagInfos, lstOutSangInfo);
        }

        private void ResetAllLayGroup()
        {
            SetdefaultLableToLayGroup();
            grdGroupSpecialNote.DataSource = null;
            grdGroupProblem.DataSource = null;
            grdGroupDisease.DataSource = null;
        }

        void CollapseGroups(LayoutControlGroup groupToSkip)
        {
            foreach (LayoutControlGroup group in groups)
            {
                if (groupToSkip != null)
                {
                    if (!group.Equals(groupToSkip))
                        group.Expanded = false;
                }
                else
                {
                    group.Expanded = false;
                }
            }
        }

        private void BindingToGrdSpecialNode(List<OUT0106U00GridItemInfo> listSpecialNode)
        {
            if (listSpecialNode.Count > 0)
            {
                this.grdGroupSpecialNote.DataSource = null;

                if (listSpecialNode.Count > 1) layGroupSpecialNote.AppearanceGroup.ForeColor = Color.Red;
                else layGroupSpecialNote.AppearanceGroup.ForeColor = DefaultForeColor;
                if (noteSpecial == "")
                {
                    layGroupSpecialNote.Text = Resources.GroupExpandForm_LblGroupSpecialNode + lblSpace + noteSpecial;
                }
                else layGroupSpecialNote.Text = Resources.GroupExpandForm_LblGroupSpecialNode + lblSpace + listSpecialNode[0].Comments;                  
                grdGroupSpecialNote.DataSource = listSpecialNode;
            }
        }

        private void BindingToGrdProblem(List<TagInfo> lstTagInfos)
        {
            if (lstTagInfos.Count > 0)
            {
                bool isFirst = true;
                DataTable dtGroupProblem = new DataTable();
                dtGroupProblem.Columns.Add("Key", typeof(string));
                dtGroupProblem.Columns.Add("Value", typeof(string));

                this.grdGroupProblem.DataSource = null;
                ProblemDic.Clear();
                GetProblemList(lstTagInfos);

                foreach (KeyValuePair<string, string> item in ProblemDic)
                {
                    if (isFirst)
                    {
                        layGroupProblem.Text = Resources.GroupExpandForm_LblGroupProblem + lblSpace1 + item.Key + lblSpace + item.Value;
                        layGroupProblem.AppearanceGroup.ForeColor = DefaultForeColor;
                        isFirst = false;
                    }
                    else
                    {
                        layGroupProblem.AppearanceGroup.ForeColor = Color.Red;
                    }

                    dtGroupProblem.Rows.Add(item.Key, item.Value);
                }

                grdGroupProblem.DataSource = (dtGroupProblem);
            }
        }

        private void GetProblemList(List<TagInfo> lstTagInfos)
        {
            string[] tagCodeArr = { "MA", "MS", "MI" };
            foreach (TagInfo item in lstTagInfos)
            {

                for (int i = 0; i < tagCodeArr.Length; i++)
                {
                    if (!string.IsNullOrEmpty(item.TagCode))
                    {
                        if (item.TagCode.Trim() == tagCodeArr[i])
                        {
                            if (ProblemDic.ContainsKey(tagCodeArr[i]))
                            {
                                ProblemDic[tagCodeArr[i]] += "[" + item.CreateDate + "] " + item.Content + " ";
                            }
                            else
                            {
                                ProblemDic.Add(tagCodeArr[i], "[" + item.CreateDate + "] " + item.Content + " ");
                                layGroupProblem.AppearanceGroup.ForeColor = Color.Red;
                            }
                        }
                    }
                }
            }
        }

        private void BindingToGrdDisease(List<OcsoOCS1003P01GridOutSangInfo> lstOutSangInfo)
        {
            if (lstOutSangInfo.Count > 0)
            {
                bool isFirst = true;
                OcsoOCS1003P01GridOutSangInfo firstObj = new OcsoOCS1003P01GridOutSangInfo();
                List<OcsoOCS1003P01GridOutSangInfo> secondList = new List<OcsoOCS1003P01GridOutSangInfo>();
                DataTable dtSecondDisease = new DataTable();
                dtSecondDisease.Columns.Add("Comments", typeof(string));
                dtSecondDisease.Columns.Add("DislayYn", typeof(string));
                this.grdGroupSpecialNote.DataSource = null;

                foreach (OcsoOCS1003P01GridOutSangInfo itemInfo in lstOutSangInfo)
                {
                    itemInfo.JuSangYn = SwitchYn(itemInfo.JuSangYn);
                    if (isFirst)
                    {
                        firstObj = itemInfo;
                        isFirst = false;
                    }
                    else
                    {
                        secondList.Add(itemInfo);
                        layGroupDisease.AppearanceGroup.ForeColor = Color.Red;
                    }
                }
                //Check lengh ModifierName
                //string _ModifierName = "";
                //char[] ModifierName = firstObj.ModifierName.ToCharArray();
                //if (NetInfo.Language.Equals(LangMode.Jr))
                //{
                //    char[] tmp = new char[100];
                //    if (firstObj.ModifierName.Length > 100)
                //    {
                //        layGroupDisease.OptionsToolTip.ToolTip = Resources.GroupExpandForm_LblGroupDisease + lblSpace + firstObj.JuSangYn + lblSpace + firstObj.ModifierName + lblSpace + firstObj.SangStartDate + lblSpace + firstObj.SangEndDate + lblSpace + firstObj.SangEndSayuName;
                //        firstObj.ModifierName = firstObj.ModifierName.Substring(0, 97) + "...";
                //        layGroupDisease.Text = Resources.GroupExpandForm_LblGroupDisease + lblSpace + firstObj.JuSangYn + lblSpace + lblSpace + lblSpace + firstObj.ModifierName + lblSpace + "  " + firstObj.SangStartDate + "  " + lblSpace + firstObj.SangEndDate + "  " + lblSpace + firstObj.SangEndSayuName;
                //    }
                //    else
                //    {
                //        Array.Copy(ModifierName, tmp, ModifierName.Length);
                //        for (int i = 0; i < tmp.Length; i++)
                //        {
                //            _ModifierName += tmp[i].ToString();
                //        }
                //        _ModifierName = _ModifierName.Replace("\0"," ");
                //        layGroupDisease.Text = Resources.GroupExpandForm_LblGroupDisease + lblSpace + firstObj.JuSangYn + lblSpace + lblSpace + lblSpace + _ModifierName + lblSpace + "  " + firstObj.SangStartDate + "  " + lblSpace + firstObj.SangEndDate + "  " + lblSpace + firstObj.SangEndSayuName;
                //    }
                //}
                //else
                //{
                //    char[] tmp = new char[100];
                //    if (firstObj.ModifierName.Length > 100)
                //    {
                //        layGroupDisease.OptionsToolTip.ToolTip = Resources.GroupExpandForm_LblGroupDisease + lblSpace + firstObj.JuSangYn + lblSpace + firstObj.ModifierName + lblSpace + firstObj.SangStartDate + lblSpace + firstObj.SangEndDate + lblSpace + firstObj.SangEndSayuName;
                //        firstObj.ModifierName = firstObj.ModifierName.Substring(0, 97) + "...";
                //        layGroupDisease.Text = Resources.GroupExpandForm_LblGroupDisease + lblSpace + firstObj.JuSangYn + lblSpace + lblSpace + lblSpace + firstObj.ModifierName + lblSpace + "  " + firstObj.SangStartDate + "  " + lblSpace + firstObj.SangEndDate + "  " + lblSpace + firstObj.SangEndSayuName;
                //    }
                //    else
                //    {
                //        Array.Copy(ModifierName, tmp, ModifierName.Length);
                //        for (int i = 0; i < tmp.Length; i++)
                //        {
                //            _ModifierName += tmp[i].ToString();
                //        }
                //        _ModifierName = _ModifierName.Replace("\0", " ");
                //        layGroupDisease.Text = Resources.GroupExpandForm_LblGroupDisease + lblSpace + firstObj.JuSangYn + lblSpace + lblSpace + lblSpace + _ModifierName + lblSpace + "  " + firstObj.SangStartDate + "  " + lblSpace + firstObj.SangEndDate + "  " + lblSpace + firstObj.SangEndSayuName;
                //    }
                //}

                layGroupDisease.OptionsToolTip.ToolTip = Resources.GroupExpandForm_LblGroupDisease + lblSpace1 + firstObj.JuSangYn + lblSpace + firstObj.ModifierName + lblSpace + firstObj.SangStartDate + lblSpace + firstObj.SangEndDate + lblSpace + firstObj.SangEndSayuName; ;
                layGroupDisease.Text = Resources.GroupExpandForm_LblGroupDisease + lblSpace1 + firstObj.JuSangYn + lblSpace + firstObj.ModifierName + lblSpace + firstObj.SangStartDate + lblSpace + firstObj.SangEndDate + lblSpace + firstObj.SangEndSayuName; ;
                grdGroupDisease.DataSource = secondList;
            }
        }

        private string SwitchYn(string strYn)
        {
            string strReturn = Resources.FrmGroupExpandLblYes;
            strReturn = strYn == lblY ? Resources.FrmGroupExpandLblYes : Resources.FrmGroupExpandLblNo;
            return strReturn;
        }

        private void BindingDataAndCollapsedGroup()
        {
            groups.Add(layGroupSpecialNote);
            groups.Add(layGroupProblem);
            groups.Add(layGroupDisease);

            CollapseGroups(null);
        }

        private void SetdefaultLableToLayGroup()
        {
            layGroupSpecialNote.Text = Resources.GroupExpandForm_LblGroupSpecialNode;
            layGroupSpecialNote.AppearanceGroup.ForeColor = Color.Black;
            layGroupProblem.Text = Resources.GroupExpandForm_LblGroupProblem;
            layGroupProblem.AppearanceGroup.ForeColor = Color.Black;
            layGroupDisease.Text = Resources.GroupExpandForm_LblGroupDisease;
            layGroupDisease.AppearanceGroup.ForeColor = Color.Black;
            layItemDisease.Text = lblDefaultTextLayItem;
            layItemProblem.Text = lblDefaultTextLayItem;
            layItemSpecialNote.Text = lblDefaultTextLayItem;
        }

        #endregion
    }
}
