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
    /// BindVarItemsEditorForm에 대한 요약 설명입니다.
    /// </summary>
    internal class BindVarItemsEditorForm : System.Windows.Forms.Form
    {
        #region Fields
        private BindVarItemCollection bindVarItems;
        private Control parent;
        private IDesignerHost host;
        private IServiceProvider provider = null;
        private bool m_bCanDrag = false;
        private int m_iDragX = 0;
        private int m_iDragY = 0;
        private DataTable itemTable = new DataTable("layoutTable");
        private ArrayList userComponents = new ArrayList();
        #endregion

        private IHIS.Framework.XDataGridTableStyle xDataGridTableStyle1;
        private IHIS.Framework.XDataGridStringTextBoxColumn xDataGridStringTextBoxColumn1;
        private System.Windows.Forms.ListView bindingList;
        private System.Windows.Forms.Splitter splitter1;
        private IHIS.Framework.XDataGridComboBoxColumn xDataGridComboBoxColumn2;
        private IHIS.Framework.XDataGrid itemGrid;
        private IHIS.Framework.XButton btnUp;
        private IHIS.Framework.XButton btnDown;
        private IHIS.Framework.XButton btnAdd;
        private IHIS.Framework.XButton btnDelete;
        private IHIS.Framework.XButton btnOK;
        private IHIS.Framework.XButton btnCancel;
        private IHIS.Framework.XComboItem xComboItem1;
        private IHIS.Framework.XComboItem xComboItem2;
        private IHIS.Framework.XComboItem xComboItem3;

        #region Property
        public BindVarItemCollection LayoutItems
        {
            get { return bindVarItems; }
        }
        #endregion

        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public BindVarItemsEditorForm(BindVarItemCollection bindVarItems, IDesignerHost host, IServiceProvider provider)
        {
            InitializeComponent();

            this.bindVarItems = bindVarItems;
            this.parent = (Control)host.RootComponent;
            this.provider = provider;
            this.host = host;
            ProjectItem projItem = (ProjectItem)host.GetService(typeof(ProjectItem));

            //BindControl 컬럼의 Combo설정
            XComboBox comboBox = (XComboBox)this.xDataGridComboBoxColumn2.Editor;
            comboBox.ComboItems.Add("", "(없음)");
            ArrayList cboItems = new ArrayList();
            // Control List Set (Bind가능한 Control List 설정)
            if (parent != null)
                SetComboItems(parent, cboItems);
            cboItems.Sort();  // Sort
            //ComboBox에 ComboItems Add
            for (int i = 0; i < cboItems.Count; i++)
                comboBox.ComboItems.Add(cboItems[i].ToString(), cboItems[i].ToString());
            // bindingList Set
            for (int i = 0; i < cboItems.Count; i++)
                this.bindingList.Items.Add(cboItems[i].ToString());

            // Property List Set
            cboItems.Clear();

            // Parent의 Member (VS DTE의 CodeElement에서 도출)
            if (projItem != null)
                SetComboItems(projItem.FileCodeModel.CodeElements, cboItems);

            // Parent의 Ancestor Member (Reflection에서 도출)
            if (parent != null)
                SetPropertyList(parent, "@", cboItems);
            // UserObject의 Member (Reflection에서 도출)
            foreach (object obj in userComponents)
            {
                IUserObject uo = (IUserObject)obj;
                if (uo.AllowBindVariables)
                {
                    Control cont = (Control)obj;
                    SetPropertyList(cont, "@" + ControlName(cont) + ".", cboItems);
                }
            }
            cboItems.Sort();  // Sort
            //ComboBox에 ComboItems Add
            for (int i = 0; i < cboItems.Count; i++)
                comboBox.ComboItems.Add(cboItems[i].ToString(), cboItems[i].ToString());
            // bindingList Set
            for (int i = 0; i < cboItems.Count; i++)
                this.bindingList.Items.Add(cboItems[i].ToString());

            // 데이타 설정
            // bindVarItems정보를 itemGrid에 SET
            //컬럼 정의
            itemTable.Columns.Add("VarName", typeof(string));
            itemTable.Columns.Add("BindControl", typeof(string));
            itemTable.Columns.Add("OriginalSeq", typeof(int));  //이미 생성된 XComboItem의 순서 (새로 생성시는 -1이 됨)
            //Default Value
            itemTable.Columns["OriginalSeq"].DefaultValue = -1;
            //DataRow 생성
            DataRow dtRow;
            int index = 0;
            foreach (BindVarItem item in bindVarItems)
            {
                dtRow = itemTable.NewRow();
                //BindVariable 설정
                // Member 변수
                if (item.BindVariable != "")
                {
                    // 화면에 있는 속성이면
                    if (item.BindControl == parent)
                        dtRow["BindControl"] = "@" + item.BindVariable;
                }
                else if (item.BindControl != null)
                {
					//BindControl이 XGrid이면 Grid명.GridColName으로 설정
					if (item.BindControl is XGrid)
					{
						if (item.GridColName != "")
							dtRow["BindControl"] = ControlName(item.BindControl) + "." + item.GridColName;
					}
					else
						dtRow["BindControl"] = ControlName(item.BindControl);
                }
                else
                    dtRow["BindControl"] = "";

                dtRow["VarName"] = item.VarName;
                dtRow["OriginalSeq"] = index;
                itemTable.Rows.Add(dtRow);
                index++;
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
			this.xDataGridComboBoxColumn2 = new IHIS.Framework.XDataGridComboBoxColumn();
			this.xComboItem1 = new IHIS.Framework.XComboItem();
			this.xComboItem2 = new IHIS.Framework.XComboItem();
			this.xComboItem3 = new IHIS.Framework.XComboItem();
			this.bindingList = new System.Windows.Forms.ListView();
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
			this.itemGrid.CaptionVisible = false;
			this.itemGrid.DataSource = null;
			this.itemGrid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.itemGrid.Location = new System.Drawing.Point(354, 0);
			this.itemGrid.Name = "itemGrid";
			this.itemGrid.Size = new System.Drawing.Size(423, 332);
			this.itemGrid.TabIndex = 0;
			this.itemGrid.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
																								 this.xDataGridTableStyle1});
			this.itemGrid.DragDrop += new System.Windows.Forms.DragEventHandler(this.itemGrid_DragDrop);
			this.itemGrid.DragEnter += new System.Windows.Forms.DragEventHandler(this.itemGrid_DragEnter);
			this.itemGrid.GiveFeedback += new System.Windows.Forms.GiveFeedbackEventHandler(this.itemGrid_GiveFeedback);
			// 
			// xDataGridTableStyle1
			// 
			this.xDataGridTableStyle1.DataGrid = this.itemGrid;
			this.xDataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
																												   this.xDataGridStringTextBoxColumn1,
																												   this.xDataGridComboBoxColumn2});
			this.xDataGridTableStyle1.MappingName = "layoutTable";
			// 
			// xDataGridStringTextBoxColumn1
			// 
			this.xDataGridStringTextBoxColumn1.Font = new System.Drawing.Font("굴림체", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.xDataGridStringTextBoxColumn1.HeaderText = "VarName";
			this.xDataGridStringTextBoxColumn1.MappingName = "VarName";
			this.xDataGridStringTextBoxColumn1.Width = 160;
			// 
			// xDataGridComboBoxColumn2
			// 
			this.xDataGridComboBoxColumn2.Font = new System.Drawing.Font("굴림체", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.xDataGridComboBoxColumn2.HeaderText = "Binding Control";
			this.xDataGridComboBoxColumn2.MappingName = "BindControl";
			this.xDataGridComboBoxColumn2.Width = 220;
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
			// bindingList
			// 
			this.bindingList.BackColor = System.Drawing.Color.Ivory;
			this.bindingList.Dock = System.Windows.Forms.DockStyle.Left;
			this.bindingList.Location = new System.Drawing.Point(0, 0);
			this.bindingList.Name = "bindingList";
			this.bindingList.Size = new System.Drawing.Size(354, 332);
			this.bindingList.TabIndex = 1;
			this.bindingList.View = System.Windows.Forms.View.List;
			this.bindingList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.bindingList_MouseDown);
			this.bindingList.DoubleClick += new System.EventHandler(this.bindingList_DoubleClick);
			this.bindingList.DragEnter += new System.Windows.Forms.DragEventHandler(this.bindingList_DragEnter);
			this.bindingList.MouseMove += new System.Windows.Forms.MouseEventHandler(this.bindingList_MouseMove);
			this.bindingList.GiveFeedback += new System.Windows.Forms.GiveFeedbackEventHandler(this.bindingList_GiveFeedback);
			// 
			// splitter1
			// 
			this.splitter1.Location = new System.Drawing.Point(354, 0);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(3, 332);
			this.splitter1.TabIndex = 2;
			this.splitter1.TabStop = false;
			// 
			// btnUp
			// 
			this.btnUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnUp.Location = new System.Drawing.Point(472, 334);
			this.btnUp.Name = "btnUp";
			this.btnUp.Size = new System.Drawing.Size(68, 28);
			this.btnUp.TabIndex = 3;
			this.btnUp.Text = "Up";
			this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
			// 
			// btnDown
			// 
			this.btnDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnDown.Location = new System.Drawing.Point(544, 334);
			this.btnDown.Name = "btnDown";
			this.btnDown.Scheme = IHIS.Framework.XButtonSchemes.OliveGreen;
			this.btnDown.Size = new System.Drawing.Size(66, 28);
			this.btnDown.TabIndex = 4;
			this.btnDown.Text = "Down";
			this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
			// 
			// btnAdd
			// 
			this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAdd.Location = new System.Drawing.Point(294, 334);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(68, 28);
			this.btnAdd.TabIndex = 5;
			this.btnAdd.Text = "&Add";
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// btnDelete
			// 
			this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnDelete.Location = new System.Drawing.Point(366, 334);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Scheme = IHIS.Framework.XButtonSchemes.OliveGreen;
			this.btnDelete.Size = new System.Drawing.Size(66, 28);
			this.btnDelete.TabIndex = 6;
			this.btnDelete.Text = "&Delete";
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// btnOK
			// 
			this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOK.Location = new System.Drawing.Point(638, 334);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(67, 28);
			this.btnOK.TabIndex = 7;
			this.btnOK.Text = "확 인";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(710, 334);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Scheme = IHIS.Framework.XButtonSchemes.OliveGreen;
			this.btnCancel.Size = new System.Drawing.Size(66, 28);
			this.btnCancel.TabIndex = 8;
			this.btnCancel.Text = "취 소";
			// 
			// BindVarItemsEditorForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(777, 362);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.btnDelete);
			this.Controls.Add(this.btnAdd);
			this.Controls.Add(this.btnDown);
			this.Controls.Add(this.btnUp);
			this.Controls.Add(this.splitter1);
			this.Controls.Add(this.itemGrid);
			this.Controls.Add(this.bindingList);
			this.DockPadding.Bottom = 30;
			this.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.Name = "BindVarItemsEditorForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Bind 변수 편집기";
			((System.ComponentModel.ISupportInitialize)(this.itemGrid)).EndInit();
			this.ResumeLayout(false);

		}
        #endregion

        #region SetComboItems, SetPropertyList
        // Control.Controls에서 Control List 작성
        private void SetComboItems(Control parent, ArrayList cboItems)
        {
            foreach (Control ctl in parent.Controls)
            {
                //Output설정시는 Grid의 컬럼은 Binding 허용하지 않음
                //Input설정시는 Grid의 컬럼도 Binding 허용
                //2005.03.18 Input, Output 모두 Grid의 컬럼 Binding 허용
                //IDataControl Binding 허용

                //IDataControl Binding 허용
                if (ctl is IDataControl)
                    cboItems.Add(ControlName(ctl));
				else if (ctl is XGrid)
				{
					foreach (XGridCell info in ((XGrid) ctl).CellInfos)
						cboItems.Add(ControlName(ctl) + "." + info.CellName);
				}
                else if ((ctl.Controls != null) && !(ctl is IDataControl) && !(ctl is XGrid))
                {
                    if (ctl.Controls.Count > 0)
                    {
                        //IBizComponent Control은 Binding허용시만 포함함.
                        if (ctl is IUserObject)
                        {
                            //UserObject List에 Control Add
                            userComponents.Add(ctl);
                        }
                        else
                            SetComboItems(ctl, cboItems);
                    }
                }
            }
        }
        private string ControlName(Control cont)
        {
            if (cont.Site != null)
                return cont.Site.Name;
            else
                return cont.Name;
        }
        // CodeElement에서 Property List 작성
        private void SetComboItems(CodeElements codeElements, ArrayList cboItems)
        {
            foreach (CodeElement element in codeElements)
            {
                if (element is CodeClass)
                {
                    CodeClass cc = element as CodeClass;
                    if (cc.Members != null)
                    {
                        SetComboItems(cc.Members, cboItems);
                    }
                }
                else if (element is CodeNamespace)
                {
                    CodeNamespace cn = element as CodeNamespace;
                    if (cn.Members != null)
                    {
                        SetComboItems(cn.Members, cboItems);
                    }
                }
                else if (element is CodeProperty)
                {
                    CodeProperty cp = element as CodeProperty;
                    /*미확정 Attribute를 검색하여 DataBindableAttribute가 true이면 Binding 허용 
                     * Attributes에서 위 속성을 뽑아낼수 있는지 확인후 반영처리함.
                     * 뽑아낼 수 없으면 Reflection만 이용하여 처리하도록 함(좀 그렇다)
                     * CodeElements elements = cp.Attributes;
                     * element에서 FullName이 IHIS.Framework.DataBindableAttribute는 가져올 수 있으나,
                     * true, false값은 가져올 수 없다. 따라서, DataBindableAttribute은 true, false를 적용하지 않고,
                     * DataBindableAttribute가 있으면 Binding가능하게 처리함
                     */
                    bool dataBindable = false;
                    foreach (CodeElement el in cp.Attributes)
                    {
                        if (el.FullName == "IHIS.Framework.DataBindableAttribute")
                        {
                            dataBindable = true;
                            break;
                        }
                    }
                    bool canWrite = true;
                    try
                    {
                        canWrite = (cp.Setter != null);
                    }
                    catch
                    {
                        canWrite = false;
                    }
                    //Setter가 있고, DataBindableAttribute가 있고 Public 속성이고, String 만 Set
                    if (canWrite && dataBindable && (cp.Access == vsCMAccess.vsCMAccessPublic) && (cp.Type.TypeKind == vsCMTypeRef.vsCMTypeRefString))
                    {
                        cboItems.Add("@" + cp.Name);
                    }
                }
            }
        }
        // Reflection에서 Property List 작성
        private void SetPropertyList(object obj, string qualifier, ArrayList cboItems)
        {
            Type t = obj.GetType();
            System.Reflection.PropertyInfo[] infos = t.GetProperties();
            object[] attributes;
            foreach (System.Reflection.PropertyInfo info in infos)
            {
                // System에서 정의된 Member는 제외한다.
                if (info.DeclaringType.ToString().Substring(0, 6) != "System")
                {
                    // property Type은 Setter가 있고, string만 가능
                    if (info.PropertyType == typeof(string) && info.CanWrite)
                    {
                        //DataBindableAttribute를 지정한 Property이면 Bind가능
                        attributes = info.GetCustomAttributes(typeof(DataBindableAttribute), false);
                        if (attributes.Length > 0)
                        {
                            cboItems.Add(qualifier + info.Name);
                        }
                    }
                }
            }
        }
        #endregion

        #region CheckValidation
        private bool CheckValidation()
        {
            string dataName = "";
            for (int i = 0; i < this.itemGrid.RowCount; i++)
            {
                dataName = this.itemGrid.GetItem(i, "VarName").ToString();
                if (dataName.Trim() == "")
                {
                    XMessageBox.Show("Data명을 반드시 입력하십시오");
                    this.itemGrid.SetFocusToItem(i, "VarName");
                    return false;
                }
            }
            return true;
        }
        #endregion

        #region GetControlByName
        private Control GetControlByName(string name)
        {
            if ((name == "") || (name == string.Empty) || (name == null))
                return null;
            return GetControlByNameInternal(name, parent.Controls);
        }

        private Control GetControlByNameInternal(string name, Control.ControlCollection controls)
        {
            foreach (Control ctl in controls)
            {
                if ((ctl is IDataControl) || (ctl is XGrid))
                {
                    if (ControlName(ctl) == name)
                        return ctl;
                }
                else if ((ctl.Controls != null) && !(ctl is IDataControl) && !(ctl is XGrid))
                {
                    if (ctl.Controls.Count > 0)
                    {
                        Control cont = GetControlByNameInternal(name, ctl.Controls);
                        if (cont != null)
                            return cont;
                    }
                }
            }
            return null;
        }
        #endregion

        #region itemGrid Event
        private void itemGrid_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(System.Windows.Forms.ListView.SelectedListViewItemCollection)))
                e.Effect = DragDropEffects.Move;
        }

        private void itemGrid_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            //DragDrop시 Drag한 행 추가하여 BindControl 설정
            System.Windows.Forms.ListView.SelectedListViewItemCollection selectedItems = (System.Windows.Forms.ListView.SelectedListViewItemCollection)(e.Data.GetData(typeof(System.Windows.Forms.ListView.SelectedListViewItemCollection)));
            if (selectedItems == null)
                return;
            foreach (ListViewItem item in selectedItems)
            {
                itemGrid.InsertRow(-1, false);
                int rowNum = itemGrid.RowCount - 1;
                itemGrid.SetItem(rowNum, "VarName", item.Text);
                itemGrid.SetItem(rowNum, "BindControl", item.Text);
            }
            itemGrid.ResetUpdate();
        }
        private void itemGrid_GiveFeedback(object sender, System.Windows.Forms.GiveFeedbackEventArgs e)
        {
            e.UseDefaultCursors = false;
            // Drag시에 Cursor 바꿈
            if ((e.Effect & DragDropEffects.Move) == DragDropEffects.Move)
                Cursor.Current = DragHelper.DragCursor;
        }
        #endregion

        #region bindingList Event
        private void bindingList_DoubleClick(object sender, System.EventArgs e)
        {
            if (bindingList.FocusedItem != null)
            {
                itemGrid.InsertRow(-1, false);
                int rowNum = itemGrid.RowCount - 1;
                itemGrid.SetItem(rowNum, "VarName", bindingList.FocusedItem.Text);
                itemGrid.SetItem(rowNum, "BindControl", bindingList.FocusedItem.Text);
            }
        }
        private void bindingList_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                m_bCanDrag = true;
                m_iDragX = e.X;
                m_iDragY = e.Y;
            }
        }
        private void bindingList_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (m_bCanDrag && (Math.Abs(e.X - m_iDragX) > 3 || Math.Abs(e.Y - m_iDragY) > 3))
            {
                m_bCanDrag = false;
                // Starts a drag-and-drop operation with that item.
                if (bindingList.SelectedItems.Count > 0)
                {
                    //Drag Image 생성
                    DragHelper.CreateDragCursor(bindingList, bindingList.SelectedItems[0].Text, bindingList.Font);
                    bindingList.DoDragDrop(bindingList.SelectedItems, DragDropEffects.Move);
                }
            }
        }
        private void bindingList_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(System.Windows.Forms.ListView.SelectedListViewItemCollection)))
                e.Effect = DragDropEffects.Move;
        }

        private void bindingList_GiveFeedback(object sender, System.Windows.Forms.GiveFeedbackEventArgs e)
        {
            e.UseDefaultCursors = false;
            // Drag시에 Cursor 바꿈
            if ((e.Effect & DragDropEffects.Move) == DragDropEffects.Move)
                Cursor.Current = DragHelper.DragCursor;
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

            //기지정된 bindVarItems 보관
            BindVarItem[] origLayoutItems = new BindVarItem[bindVarItems.Count];
            for (int i = 0; i < bindVarItems.Count; i++)
                origLayoutItems[i] = bindVarItems[i];

            bindVarItems.Clear();

            BindVarItem bindVarItem = null;
            foreach (DataRow dtRow in this.itemGrid.DataSource.Rows)
            {
                string controlName = dtRow["BindControl"].ToString();
                Control bindControl = null;
                string bindVariable = "";
				string  gridColName = "";
                int originalSeq = (int)dtRow["OriginalSeq"];
                int pos = controlName.IndexOf(".");

                if ((controlName.Length == 0) || (controlName == "(없음)"))
                {
                    bindControl = null;
                }
                else if (controlName.Substring(0, 1) == "@")	// Member변수
                {
                    if (pos >= 0)
                    {
                        bindVariable = controlName.Substring(pos + 1);
                        string uoName = controlName.Substring(1, pos - 1);
                        foreach (object obj in userComponents)
                        {
                            Control cont = (Control)obj;
                            if (ControlName(cont) == uoName)
                            {
                                bindControl = cont;
                                break;
                            }
                        }
                    }
                    else
                    {
                        bindVariable = controlName.Substring(1);
                        bindControl = parent;
                    }
                }
				else if (pos >= 0)  // Grid의 컬럼
				{
					bindControl = GetControlByName(controlName.Substring(0, pos));
					gridColName = controlName.Substring(pos + 1);
					if (bindControl is XGrid) //bind 컨트롤이 Grid 일때 컬럼명이 정확하지 않으면 Clear
					{
						if (!((XGrid)bindControl).CellInfos.Contains(gridColName))
						{
							bindControl = null;
							gridColName = "";
						}
					}
					
				}
                else if (controlName != "")	// Control Binding
                {
                    bindControl = GetControlByName(controlName);
                }

                //원목록에서 있으면 원목록 그대로 사용, 없으면 Component 생성
                if (originalSeq >= 0)
                    bindVarItem = origLayoutItems[originalSeq] as BindVarItem;
                else
                {
                    if (this.host != null)
                        bindVarItem = (BindVarItem)host.CreateComponent(typeof(BindVarItem));
                    else
                        bindVarItem = new BindVarItem();
                }

                //Property Set
                bindVarItem.VarName = dtRow["VarName"].ToString();
                bindVarItem.BindControl = bindControl;
                bindVarItem.BindVariable = bindVariable;
				bindVarItem.GridColName = gridColName;
				
                bindVarItems.Add(bindVarItem);
            }

            //삭제된 XComboItem Component 제거
            if (host != null)
            {
                foreach (BindVarItem item in origLayoutItems)
                    if (!bindVarItems.Contains(item))
                        host.DestroyComponent(item);
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        #endregion
    }
}
