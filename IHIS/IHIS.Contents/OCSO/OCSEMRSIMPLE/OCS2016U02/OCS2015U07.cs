using System;
using System.Collections.Generic;
using System.Windows.Forms;
using IHIS.Framework;
using EmrDocker.Models;

namespace IHIS.OCSO
{
    public partial class OCS2015U07 : UserControl
    {
        Dictionary<string, string> ProblemDic = new Dictionary<string, string>();
        private List<TagInfo> _tagLst;
        public OCS2015U07()
        {
            try
            {
                InitializeComponent();
                ProblemDic.Clear();
                this.grdList.ExecuteQuery = this.GetProblemList;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fail to initialize control OCS2015U07");
            }
        }

        public List<TagInfo> TagLst
        {
            get
            {
                if (_tagLst == null)
                    return new List<TagInfo>();
                return _tagLst;
            }
            set { _tagLst = value; }
        }
        private IList<object[]> GetProblemList(BindVarCollection list)
        {
            
            List<object[]> gridList = null;
            if (ProblemDic.Count > 0)
            {
                gridList = new List<object[]>();
                foreach (KeyValuePair<string, string> item in ProblemDic)
                {
                    gridList.Add(new object[]
                    {
                        item.Key,
                        item.Value
                    });
                }
            }
            return gridList;
        }

        /// <summary>
        /// Get problem list of patient at specific examination date
        /// </summary>
        /// <param name="bunho">Patient code</param>
        public void GetProblemList(string bunho)
        {
            this.grdList.Reset();
            ProblemDic.Clear();
            if (TagLst != null && TagLst.Count > 0)
            {
                string[] tagCodeArr = { "MA", "MS", "MI" };
                foreach (TagInfo item in TagLst)
                {
                    for (int i = 0; i < tagCodeArr.Length; i++)
                    {
                        if (!string.IsNullOrEmpty(item.TagCode))
                        {
                            if (item.TagCode.Trim() == tagCodeArr[i])
                            {
                                if (ProblemDic.ContainsKey(tagCodeArr[i]))
                                    ProblemDic[tagCodeArr[i]] += "[" + item.CreateDate + "] " + item.Content + " ";
                                else
                                    ProblemDic.Add(tagCodeArr[i], "[" + item.CreateDate + "] " + item.Content + " ");
                            }
                        }
                    }
                }
                this.grdList.QueryLayout(true);
            }
        }
        public void Reset()
        {
            this.TagLst.Clear();
            grdList.Reset();
            ProblemDic.Clear();
            grdList.QueryLayout(false);
        }

        private EmrDocketS _emrDocker;
        public EmrDocketS Docker
        {
            get { return _emrDocker; }
            set { _emrDocker = value; }
        }
    }
}


