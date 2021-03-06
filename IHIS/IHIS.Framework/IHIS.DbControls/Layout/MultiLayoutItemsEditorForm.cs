using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using EnvDTE;

namespace IHIS.Framework
{
    /// <summary>
    /// MultiLayoutItemsEditorForm에 대한 요약 설명입니다.
    /// </summary>
    internal class MultiLayoutItemsEditorForm : System.Windows.Forms.Form
    {
        #region Fields
        private IDesignerHost host;
        private IServiceProvider provider = null;
        private MultiLayoutItemCollection layoutItems;
        private DataTable itemTable = new DataTable("layoutTable");
        #endregion

        private IHIS.Framework.XDataGridTableStyle xDataGridTableStyle1;
        private IHIS.Framework.XDataGridStringTextBoxColumn xDataGridStringTextBoxColumn1;
        private IHIS.Framework.XDataGridComboBoxColumn xDataGridComboBoxColumn1;
        private System.Windows.Forms.Splitter splitter1;
        private IHIS.Framework.XDataGridCheckBoxColumn xDataGridCheckBoxColumn1;
        private IHIS.Framework.XDataGrid itemGrid;
        private IHIS.Framework.XButton btnUp;
        private IHIS.Framework.XButton btnDown;
        private IHIS.Framework.XButton btnAdd;
        private IHIS.Framework.XButton btnDelete;
        private IHIS.Framework.XButton btnOK;
        private IHIS.Framework.XButton btnCancel;
        private IHIS.Framework.XDataGridCheckBoxColumn xDataGridCheckBoxColumn2;
        private IHIS.Framework.XComboItem xComboItem1;
        private IHIS.Framework.XComboItem xComboItem2;
        private IHIS.Framework.XComboItem xComboItem3;

        #region Property
        public MultiLayoutItemCollection LayoutItems
        {
            get { return layoutItems; }
        }
        #endregion

        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public MultiLayoutItemsEditorForm(MultiLayoutItemCollection layoutItems , IDesignerHost host, IServiceProvider provider)
        {
            InitializeComponent();

            this.layoutItems = layoutItems;
            this.provider = provider;
            this.host = host;

            //DataType Combo 설정
            XComboBox comboBox = (XComboBox)this.xDataGridComboBoxColumn1.Editor;
            foreach (string item in Enum.GetNames(typeof(DataType)))
                comboBox.ComboItems.Add(item, item);

            // 데이타 설정
            // layoutItems정보를 itemGrid에 SET
            //컬럼 정의
            itemTable.Columns.Add("DataName", typeof(string));
            itemTable.Columns.Add("DataType", typeof(string));
            itemTable.Columns.Add("IsNotNull", typeof(string));
            itemTable.Columns.Add("IsUpdItem", typeof(string));
            itemTable.Columns.Add("OriginalSeq", typeof(int));  //이미 생성된 XComboItem의 순서 (새로 생성시는 -1이 됨)
            //Default Value
            itemTable.Columns["DataType"].DefaultValue = "String";
            itemTable.Columns["IsNotNull"].DefaultValue = "N";
            itemTable.Columns["IsUpdItem"].DefaultValue = "N";
            itemTable.Columns["OriginalSeq"].DefaultValue = -1;
            //DataRow 생성
            DataRow dtRow;
            foreach (MultiLayoutItem item in layoutItems)
            {
                dtRow = itemTable.NewRow();
                dtRow["DataName"] = item.DataName;
                dtRow["DataType"] = item.DataType.ToString();
                dtRow["IsNotNull"] = (item.IsNotNull == true ? "Y" : "N");
                dtRow["IsUpdItem"] = (item.IsUpdItem == true ? "Y" : "N");
                itemTable.Rows.Add(dtRow);
            }
            itemTable.AcceptChanges();
            //ItemGrid에 DataSource 연결
            itemGrid.DataSource = itemTable;
            itemGrid.AllowDrop = true;

        }

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드
        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.itemGrid = new IHIS.Framework.XDataGrid();
            this.xDataGridTableStyle1 = new IHIS.Framework.XDataGridTableStyle();
            this.xDataGridStringTextBoxColumn1 = new IHIS.Framework.XDataGridStringTextBoxColumn();
            this.xDataGridComboBoxColumn1 = new IHIS.Framework.XDataGridComboBoxColumn();
            this.xDataGridCheckBoxColumn1 = new IHIS.Framework.XDataGridCheckBoxColumn();
            this.xDataGridCheckBoxColumn2 = new IHIS.Framework.XDataGridCheckBoxColumn();
            this.xComboItem1 = new IHIS.Framework.XComboItem();
            this.xComboItem2 = new IHIS.Framework.XComboItem();
            this.xComboItem3 = new IHIS.Framework.XComboItem();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.btnUp = new IHIS.Framework.XButton();
            this.btnDown = new IHIS.Framework.XButton();
            this.btnAdd = new IHIS.Framework.XButton();
            this.btnDelete = new IHIS.Framework.XButton();
            this.btnOK = new IHIS.Framework.XButton();
            this.btnCancel = new IHIS.Framework.XButton();
            ((System.ComponentModel.ISupportInitialize)(this.itemGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // itemGrid
            // 
            this.itemGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.itemGrid.CaptionVisible = false;
            this.itemGrid.DataSource = null;
            this.itemGrid.Location = new System.Drawing.Point(5, 5);
            this.itemGrid.Name = "itemGrid";
            this.itemGrid.Size = new System.Drawing.Size(464, 322);
            this.itemGrid.TabIndex = 0;
            this.itemGrid.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.xDataGridTableStyle1});
            // 
            // xDataGridTableStyle1
            // 
            this.xDataGridTableStyle1.DataGrid = this.itemGrid;
            this.xDataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.xDataGridStringTextBoxColumn1,
            this.xDataGridComboBoxColumn1,
            this.xDataGridCheckBoxColumn1,
            this.xDataGridCheckBoxColumn2});
            this.xDataGridTableStyle1.MappingName = "layoutTable";
            // 
            // xDataGridStringTextBoxColumn1
            // 
            this.xDataGridStringTextBoxColumn1.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xDataGridStringTextBoxColumn1.HeaderText = "DataName";
            this.xDataGridStringTextBoxColumn1.MappingName = "DataName";
            this.xDataGridStringTextBoxColumn1.Width = 160;
            // 
            // xDataGridComboBoxColumn1
            // 
            this.xDataGridComboBoxColumn1.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xDataGridComboBoxColumn1.HeaderText = "DataType";
            this.xDataGridComboBoxColumn1.MappingName = "DataType";
            this.xDataGridComboBoxColumn1.Width = 140;
            // 
            // xDataGridCheckBoxColumn1
            // 
            this.xDataGridCheckBoxColumn1.ColumnAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.xDataGridCheckBoxColumn1.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xDataGridCheckBoxColumn1.HeaderText = "NotNull";
            this.xDataGridCheckBoxColumn1.MappingName = "IsNotNull";
            this.xDataGridCheckBoxColumn1.Width = 60;
            // 
            // xDataGridCheckBoxColumn2
            // 
            this.xDataGridCheckBoxColumn2.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xDataGridCheckBoxColumn2.HeaderText = "UpdItem";
            this.xDataGridCheckBoxColumn2.MappingName = "IsUpdItem";
            this.xDataGridCheckBoxColumn2.Width = 60;
            // 
            // xComboItem1
            // 
            this.xComboItem1.DisplayItem = "Default";
            this.xComboItem1.ValueItem = "Default";
            // 
            // xComboItem2
            // 
            this.xComboItem2.DisplayItem = "Korea";
            this.xComboItem2.ValueItem = "Korea";
            // 
            // xComboItem3
            // 
            this.xComboItem3.DisplayItem = "Japan";
            this.xComboItem3.ValueItem = "Japan";
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 362);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            // 
            // btnUp
            // 
            this.btnUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUp.Location = new System.Drawing.Point(179, 332);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(62, 26);
            this.btnUp.TabIndex = 3;
            this.btnUp.Text = "Up";
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnDown
            // 
            this.btnDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDown.Location = new System.Drawing.Point(243, 332);
            this.btnDown.Name = "btnDown";
            this.btnDown.Scheme = IHIS.Framework.XButtonSchemes.OliveGreen;
            this.btnDown.Size = new System.Drawing.Size(62, 26);
            this.btnDown.TabIndex = 4;
            this.btnDown.Text = "Down";
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(6, 332);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(62, 26);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "&Add";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Location = new System.Drawing.Point(74, 332);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Scheme = IHIS.Framework.XButtonSchemes.OliveGreen;
            this.btnDelete.Size = new System.Drawing.Size(62, 26);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(342, 332);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(62, 26);
            this.btnOK.TabIndex = 7;
            this.btnOK.Text = "확 인";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(406, 332);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Scheme = IHIS.Framework.XButtonSchemes.OliveGreen;
            this.btnCancel.Size = new System.Drawing.Size(62, 26);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "취 소";
            // 
            // MultiLayoutItemsEditorForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(474, 362);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.itemGrid);
            this.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "MultiLayoutItemsEditorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DataLayout 편집기";
            ((System.ComponentModel.ISupportInitialize)(this.itemGrid)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion


        #region CheckValidation
        private bool CheckValidation()
        {
            string dataName = "";
            for (int i = 0; i < this.itemGrid.RowCount; i++)
            {
                dataName = this.itemGrid.GetItem(i, "DataName").ToString();
                if (dataName.Trim() == "")
                {
                    XMessageBox.Show("Data명을 반드시 입력하십시오");
                    this.itemGrid.SetFocusToItem(i, "DataName");
                    return false;
                }
            }
            return true;
        }
        #endregion

        #region Button Event
        private void btnAdd_Click(object sender, System.EventArgs e)
        {
            this.itemGrid.InsertRow(-1);
        }

        private void btnDelete_Click(object sender, System.EventArgs e)
        {
            this.itemGrid.DeleteRow(-1);
        }
        private void btnUp_Click(object sender, System.EventArgs e)
        {
            this.itemGrid.RowMoveUp(this.itemGrid.CurrentRowIndex);
        }

        private void btnDown_Click(object sender, System.EventArgs e)
        {
            this.itemGrid.RowMoveDown(this.itemGrid.CurrentRowIndex);
        }
        private void btnOK_Click(object sender, System.EventArgs e)
        {
            // AcceptData
            this.itemGrid.AcceptData();

            // 저장전 Check사항 확인
            if (!CheckValidation())
                return;

            //기지정된 layoutItems 보관
            MultiLayoutItem[] origLayoutItems = new MultiLayoutItem[layoutItems.Count];
            for (int i = 0; i < layoutItems.Count; i++)
                origLayoutItems[i] = layoutItems[i];

            layoutItems.Clear();

            MultiLayoutItem layoutItem = null;
            foreach (DataRow dtRow in this.itemGrid.DataSource.Rows)
            {
                int originalSeq = (int)dtRow["OriginalSeq"];

                //원목록에서 있으면 원목록 그대로 사용, 없으면 Component 생성
                if (originalSeq >= 0)
                    layoutItem = origLayoutItems[originalSeq] as MultiLayoutItem;
                else
                {
                    if (this.host != null)
                        layoutItem = (MultiLayoutItem)host.CreateComponent(typeof(MultiLayoutItem));
                    else
                        layoutItem = new MultiLayoutItem();
                }

                //Property Set
                layoutItem.DataName = dtRow["DataName"].ToString();
                layoutItem.DataType = (DataType)Enum.Parse(typeof(DataType), dtRow["DataType"].ToString());
                layoutItem.IsNotNull = (dtRow["IsNotNull"].ToString() == "Y");
                layoutItem.IsUpdItem = (dtRow["IsUpdItem"].ToString() == "Y");

                layoutItems.Add(layoutItem);
            }

            //삭제된 MultiLayoutItem Component 제거
            if (host != null)
            {
                foreach (MultiLayoutItem item in origLayoutItems)
                    if (!layoutItems.Contains(item))
                        host.DestroyComponent(item);
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        #endregion
    }
}
