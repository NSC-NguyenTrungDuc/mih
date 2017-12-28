using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using IHIS.Framework;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Arguments.Bass;
using IHIS.CloudConnector.Contracts.Models.Bass;
using IHIS.CloudConnector.Contracts.Results.Bass;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.System;


namespace IHIS.BASS
{
    public partial class BAS0260U01 : IHIS.Framework.XScreen
    {
        private string row_id = "";
        public BAS0260U01()
        {
            InitializeComponent();
            InitializeCloud();
            
        }
        #region Init Clound
        private void InitializeCloud()
        {
            grdBas0260U01.ParamList = new List<string>(new string[] { "f_language", "f_buseo_name", "f_gwa_name", "f_active_flg", "f_buseo_gubun" });
            cbxLanguageType.ExecuteQuery = LoadCbxLanguage;
            grdBas0260U01.ExecuteQuery = LoadGrdBas0260U00;
            cbxDepartmentType.ExecuteQuery = LoadCbxDepartmentType; 

        }
        #endregion

        #region LoadData for GrdBass0260U01
        private IList<object[]> LoadGrdBas0260U00(BindVarCollection bc)
        {
            IList<object[]> obj = new List<object[]>();
            LoadGrdBAS0260U01Args args = new LoadGrdBAS0260U01Args();
            args.Language = cbxLanguageType.GetDataValue();//bc["f_language"].VarValue;
            args.BuseoName = txtDepartmentName.Text;// bc["f_buseo_name"].VarValue;
            args.GwaName = txtFacility.Text;// bc["f_gwa_name"].VarValue;
            args.ActiveFlg = "1";// bc["f_active_flg"].VarValue;
            args.BuseoGubun = cbxDepartmentType.GetDataValue();// bc["f_buseo_gubun"].VarValue;

            LoadGrdBAS0260U01Result res = CloudService.Instance.Submit<LoadGrdBAS0260U01Result, LoadGrdBAS0260U01Args>(args);
            if (res.ExecutionStatus == ExecutionStatus.Success)
            { 
            res.ListInfo.ForEach(delegate(LoadGrdBAS0260U01Info info)
                {
                obj.Add(new object[]
                    {
                        info.Id,
                        info.BuseoCode,
                        info.BuseoName,
                        info.BuseoName2,
                        info.BuseoGubun,
                        info.ParentBuseo,
                        info.Gwa,
                        info.GwaName,
                        info.GwaName2,
                        info.GwaGubun,
                        info.ParentGwa,
                        info.Note,
                        info.Language,
                        info.ActiveFlg
                    });
                });
            }
                return obj;
        }
        #endregion

        #region Load data for combox language

        private IList<object[]> LoadCbxLanguage(BindVarCollection bc)
        {

            IList<object[]> lObj = new List<object[]>();
            LoadCbxLanguageArgs args = new LoadCbxLanguageArgs();
            args.PropertyCode = "LANGUAGE";//NetInfo.Language.ToString();
            args.ActiveFlg = "1";
            LoadCbxLanguageResult res = CloudService.Instance.Submit<LoadCbxLanguageResult, LoadCbxLanguageArgs>(args);
            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                res.ListInfo.ForEach(delegate(LoadCbxLanguageInfo item)
                {
                    lObj.Add(new object[]
                        {
                            item.PropertyValue,
                            item.PropertyName,
                           
                        });
                });
            }
            return lObj;

        }
        #endregion

        #region Load data for combox DepartmentType

        private IList<object[]> LoadCbxDepartmentType(BindVarCollection bc)
        {

            IList<object[]> lObj = new List<object[]>();
            Bas0260U01LoadDepartmentTypeArgs args = new Bas0260U01LoadDepartmentTypeArgs();
            args.HospCode = "";
            args.CodeType = "BUSEO_GUBUN";
            if (!String.IsNullOrEmpty(cbxLanguageType.GetDataValue()))
            {
                args.Language = cbxLanguageType.GetDataValue();
                
            }
            else {
                if (NetInfo.Language.ToString() == "Jr")
               {
                args.Language = "Ja";
               } else {
                   args.Language = NetInfo.Language.ToString();
               }   
            }
            Bas0260U01LoadDepartmentTypeResult res = CloudService.Instance.Submit<Bas0260U01LoadDepartmentTypeResult, Bas0260U01LoadDepartmentTypeArgs>(args);
            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                res.ListInfo.ForEach(delegate(LoadDepartmentTypeInfo item)
                {
                    lObj.Add(new object[]
                        {
                            item.Code,
                            item.CodeName,
                           
                        });
                });
            }
            return lObj;

        }

        private IList<object[]> LoadCbxDepartmentType1(BindVarCollection bc)
        {


            IList<object[]> lObj = new List<object[]>();
            Bas0260U01LoadDepartmentTypeArgs args = new Bas0260U01LoadDepartmentTypeArgs();
            args.HospCode = "";
            args.CodeType = "BUSEO_GUBUN";
            if (!String.IsNullOrEmpty(cbxLanguageType.GetDataValue()))
            {
                args.Language = cbxLanguageType.GetDataValue();

            }
            else
            {
                if (NetInfo.Language.ToString() == "Jr")
                {
                    args.Language = "Ja";
                }
                else
                {
                    args.Language = NetInfo.Language.ToString();
                }
            }
            Bas0260U01LoadDepartmentTypeResult res = CloudService.Instance.Submit<Bas0260U01LoadDepartmentTypeResult, Bas0260U01LoadDepartmentTypeArgs>(args);
            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                res.ListInfo.ForEach(delegate(LoadDepartmentTypeInfo item)
                {
                    lObj.Add(new object[]
                        {
                            item.Code,
                            item.CodeName,
                           
                        });
                });
            }
            return lObj;

        }

        #endregion

        private void BAS0260U01_Load(object sender, EventArgs e)
        {
            cbxLanguageType.SetDictDDLB();
            cbxDepartmentType.SetDictDDLB();
            
            grdBas0260U01.QueryLayout(false);
            
        }

        private void grdBas0260U01_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdBas0260U01.SetBindVarValue("f_language", cbxLanguageType.GetDataValue());
            this.grdBas0260U01.SetBindVarValue("f_buseo_name", txtDepartmentName.Text);
            this.grdBas0260U01.SetBindVarValue("f_gwa_name", txtFacility.Text);
            this.grdBas0260U01.SetBindVarValue("f_buseo_name", "1");
            this.grdBas0260U01.SetBindVarValue(" f_buseo_gubun", cbxDepartmentType.GetDataValue());
           
        }

        private void btnList_ButtonClick(object sender, ButtonClickEventArgs e)
        {
            switch (e.Func)
            { 
                case FunctionType.Delete:
                    row_id = grdBas0260U01.GetItemString(grdBas0260U01.CurrentRowNumber, "id");
                    break;
                case FunctionType.Query:

                    ((System.ComponentModel.ISupportInitialize)(this.grdBas0260U01)).BeginInit();
                    grdBas0260U01.PreEndInitializing += grd_PreEndInitializing;
                    ((System.ComponentModel.ISupportInitialize)(this.grdBas0260U01)).EndInit();

                    grdBas0260U01.QueryLayout(true);
                    cbxDepartmentType.SetDictDDLB();

                    
                    break;
                case FunctionType.Update:
                    if (!SaveLayout())
                    {
                        XMessageBox.Show(Properties.Resources.MSG_002, Properties.Resources.MSG_002_CAP, MessageBoxIcon.Error);
                        grdBas0260U01.QueryLayout(false);
                    }
                    else
                    {
                        XMessageBox.Show(Properties.Resources.MSG_001, Properties.Resources.MSG_001_CAP, MessageBoxIcon.Information);
                        grdBas0260U01.QueryLayout(false);
                    }
                    break;
                  
            }
        }
        private bool SaveLayout()
        {
            SaveGrdBas0260U01Args args = new SaveGrdBas0260U01Args();
            args.ListInfo = new List<LoadGrdBAS0260U01Info>();

            for (int i = 0; i < grdBas0260U01.RowCount; i++)
            { 
            //skip unchanged rows
                if (grdBas0260U01.GetRowState(i) == DataRowState.Unchanged) continue;

                LoadGrdBAS0260U01Info info = new LoadGrdBAS0260U01Info();
                info.Id = grdBas0260U01.GetItemString(i, "id");
                info.BuseoCode = grdBas0260U01.GetItemString(i, "buseo_code");
                info.BuseoName = grdBas0260U01.GetItemString(i, "buseo_name");
                info.BuseoName2 = grdBas0260U01.GetItemString(i, "buseo_name2");
                info.BuseoGubun = grdBas0260U01.GetItemString(i, "buseo_gubun");
                info.ParentBuseo = grdBas0260U01.GetItemString(i, "parent_buseo");
                info.Gwa = grdBas0260U01.GetItemString(i, "gwa");
                info.GwaName = grdBas0260U01.GetItemString(i, "gwa_name");
                info.GwaName2 = grdBas0260U01.GetItemString(i, "gwa_name2");
                info.GwaGubun = grdBas0260U01.GetItemString(i, "gwa_gubun");
                info.ParentGwa = grdBas0260U01.GetItemString(i, "parent_gwa");
                info.Note = grdBas0260U01.GetItemString(i, "note");
                info.Language = cbxLanguageType.GetDataValue();
                info.ActiveFlg = "1";
                info.RowState = grdBas0260U01.GetRowState(i).ToString();
                args.ListInfo.Add(info);
            }
            if (grdBas0260U01.DeletedRowTable != null)
            {
                foreach (DataRow dr in grdBas0260U01.DeletedRowTable.Rows)
                {
                    LoadGrdBAS0260U01Info info = new LoadGrdBAS0260U01Info();
                    info.Id = row_id;//grdBas0260U01.GetItemString(grdBas0260U01.CurrentRowNumber, "id");
                    info.RowState = DataRowState.Deleted.ToString();
                    args.ListInfo.Add(info);
                }
            }

            UpdateResult res = CloudService.Instance.Submit<UpdateResult, SaveGrdBas0260U01Args>(args);
            if (res.ExecutionStatus == ExecutionStatus.Success && res.Msg.Equals("duplicate"))
            {
                XMessageBox.Show(Properties.Resources.MSG_003, Properties.Resources.MSG_003_CAP, MessageBoxIcon.Error);
            }
            if (res.ExecutionStatus == ExecutionStatus.Success && res.Result == true)
            {
                return true;
            }

            return false;
        }

        private void grdBas0260U01_PreEndInitializing(object sender, EventArgs e)
        {
            xEditGridCell69.ExecuteQuery = LoadCbxDepartmentType;
        }

        private void grd_PreEndInitializing(object sender, EventArgs e)
        {
            xEditGridCell69.ExecuteQuery = LoadCbxDepartmentType1;
        }

    }
}