using System;
using System.Reflection;
using System.ComponentModel;
using System.Collections;
using System.Windows.Forms;
using System.ComponentModel.Design;
using System.Windows.Forms.Design;
using System.Drawing;
using System.Drawing.Design;

namespace IHIS.Framework
{
	[AttributeUsage(System.AttributeTargets.Property)]
	public class ImageListAttribute : Attribute 
	{
		private string name;
		public ImageListAttribute(string name) 
		{
			this.name = name;
		}
		public string Name 
		{
			get {return name;}
			set {name = value;}
		}
	}

	public class ImageIndexesEditor : UITypeEditor 
	{
		internal IWindowsFormsEditorService edSvc = null;
		protected ImageList GetImageListInfo(ITypeDescriptorContext context) 
		{
			ImageList imageList = null;
			foreach (object attribute in context.PropertyDescriptor.Attributes) 
			{
				if (attribute is ImageListAttribute) 
				{
					string name = (attribute as ImageListAttribute).Name;
					object obj = context.Instance;
					Type t = obj.GetType();
					PropertyInfo p = t.GetProperty(name);
					object v = p.GetValue(obj, null);
					imageList = (ImageList)v;
					break;
				}
			}
			return imageList;
		}
		public override object EditValue(ITypeDescriptorContext context,
			IServiceProvider provider, object value) 
		{
			if(context == null || context.Instance == null || provider == null)
				return value;
			edSvc = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
			if(edSvc == null) return value;
			ImageList imageList = GetImageListInfo(context);
			if(imageList == null) return value;
			ImageIndexesEditorForm form = new ImageIndexesEditorForm(this, imageList, value);
			edSvc.DropDownControl(form);
			value = form.EditValue;
			return value;
		}
		public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context) 
		{
			if(context != null && context.Instance != null)
				return UITypeEditorEditStyle.DropDown;
			return base.GetEditStyle(context);
		}
		public override void PaintValue(PaintValueEventArgs e) 
		{
			ImageList img = GetImageListInfo(e.Context);
			Rectangle r = e.Bounds;
			r.Width--;
			r.Height--;
			e.Graphics.DrawRectangle(SystemPens.ControlText, r);
			r = e.Bounds;
			r.Inflate(-1, -1);
			int imgIndex = e.Value == null ? -1 : (int)e.Value;
			e.Graphics.FillRectangle(SystemBrushes.Window, r);
			if(imgIndex > -1 && img != null && img.Images != null && imgIndex < img.Images.Count) 
			{
				e.Graphics.FillRectangle(SystemBrushes.Window, r);
				img.Draw(e.Graphics, r.X, r.Y, r.Width, r.Height, imgIndex);
			}
		}
		public override bool GetPaintValueSupported(ITypeDescriptorContext context) 
		{
			if(context != null && context.Instance != null)
				return true;
			return base.GetPaintValueSupported();
		}
		private void SaveChanges(object sender, EventArgs e, bool bNeedSave) 
		{
			edSvc.CloseDropDown();
		}
	}

	internal class ImageIndexesEditorForm : Panel 
	{
		private ImageIndexesEditor mainEditor;
		private ListBox listBox;
		private object editValue, originalValue;
		protected ImageList imageList = null;
		public ImageList ImageList 
		{
			get {return imageList;}
			set 
			{
				if(value != imageList) 
				{
					imageList = value;
				}
			}
		}
		protected override void OnGotFocus(EventArgs e) 
		{
			base.OnGotFocus(e);
			this.listBox.Focus();
		}
		protected void lbDrawItem(object sender, DrawItemEventArgs e) 
		{
			Rectangle rect;
			int imageIndex;
			StringFormat strFormat = new StringFormat();
			strFormat.LineAlignment = StringAlignment.Center;
			rect = new Rectangle(e.Bounds.X + ImageList.ImageSize.Width + 5, 
				e.Bounds.Y, 
				e.Bounds.Width - ImageList.ImageSize.Width - 5,
				e.Bounds.Height);
			e.DrawBackground();
			imageIndex = (int)listBox.Items[e.Index];
			if(e.Index >= 0 && e.Index < listBox.Items.Count)
				e.Graphics.DrawString((imageIndex >= 0)?imageIndex.ToString():"none", e.Font, new SolidBrush(e.ForeColor), rect, strFormat);
			if(imageIndex >= 0 && imageIndex < ImageList.Images.Count)
				e.Graphics.DrawImageUnscaled(ImageList.Images[imageIndex], e.Bounds.X + 1, e.Bounds.Y + 1);
			else 
			{
				Pen redPen = (Pen)Pens.Red.Clone();
				redPen.Width = 2;
				e.Graphics.DrawLine(redPen, 
					e.Bounds.X, 
					e.Bounds.Y, 
					e.Bounds.X + ImageList.ImageSize.Width, 
					e.Bounds.Y + ImageList.ImageSize.Height);
				e.Graphics.DrawLine(redPen, 
					e.Bounds.X + ImageList.ImageSize.Width, 
					e.Bounds.Y, 
					e.Bounds.X, 
					e.Bounds.Y + ImageList.ImageSize.Height);
				redPen.Dispose();
			}
			e.DrawFocusRectangle();
		}
		public void lbSelectedIndexChanged(object sender, EventArgs e) 
		{
			editValue = listBox.SelectedItem;
		}
		public void lbMouseUp(object sender, MouseEventArgs e) 
		{
			mainEditor.edSvc.CloseDropDown();
		}
		public ImageIndexesEditorForm(ImageIndexesEditor editor, ImageList imageList, object editValue) 
		{
			mainEditor = editor;
			this.imageList = imageList;
			BorderStyle = BorderStyle.None;
			EditValue = editValue;
			listBox = new ListBox();
			listBox.Dock = DockStyle.Fill;
			listBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			listBox.DrawMode = DrawMode.OwnerDrawFixed;
			listBox.DrawItem += new DrawItemEventHandler(lbDrawItem);
			listBox.MouseUp += new MouseEventHandler(lbMouseUp);
			listBox.ItemHeight = ImageList.ImageSize.Height + 2;
			for(int i = -1; i < ImageList.Images.Count; i++) 
			{
				listBox.Items.Add(i);
			}
			int index = EditValue == null ? -1 : (int)EditValue;
			if(index + 1 < listBox.Items.Count && index > -1) 
				listBox.SelectedIndex = index + 1;
			this.Size = new Size(0, listBox.ItemHeight * 7);
			listBox.SelectedIndexChanged += new EventHandler(lbSelectedIndexChanged);
			Controls.Add(listBox);
		}
		protected override bool ProcessDialogKey(Keys keyData) 
		{
			if(keyData == Keys.Enter) 
			{
				mainEditor.edSvc.CloseDropDown();
				return true;
			}
			if(keyData == Keys.Escape) 
			{
				editValue = originalValue;
				mainEditor.edSvc.CloseDropDown();
				return true;
			}
			return base.ProcessDialogKey(keyData);
		}
		public object EditValue 
		{
			get { return editValue; }
			set 
			{
				if(editValue == value) return;
				originalValue = editValue = value;
			}
		}
	}
}
