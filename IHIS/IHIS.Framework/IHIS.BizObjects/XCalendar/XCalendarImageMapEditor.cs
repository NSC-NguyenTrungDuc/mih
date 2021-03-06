using System;
using System.Windows.Forms;
using System.Windows.Forms.Design; 
using System.Drawing.Design; 
using System.Drawing;
using System.ComponentModel; 

namespace IHIS.Framework
{
	/// <summary>
	/// Summary description for ImageEditor.
	/// </summary>
	internal class XCalendarImageMapEditor : System.Drawing.Design.UITypeEditor   
	{
		
		#region properties
		
		private IWindowsFormsEditorService wfes = null ;
		private int m_selectedIndex = -1 ;
		private XCalendarImageEditorControl imageControl = null ;
	
		#endregion
		
		#region constructor

		public XCalendarImageMapEditor()
		{
			
		}

		#endregion

		#region Methods

		protected virtual ImageList GetImageList(object component) 
		{
			if (component is XCalendarDate) 
			{
				return ((XCalendarDate) component).GetImageList();
			}

			return null ;
		}

		#endregion
		
		#region overrides

		public override object EditValue(System.ComponentModel.ITypeDescriptorContext context, IServiceProvider provider, object value)
		{
			wfes = (IWindowsFormsEditorService)	provider.GetService(typeof(IWindowsFormsEditorService));
			if((wfes == null) || (context == null))
				return null ;
			
			ImageList imageList = GetImageList(context.Instance) ;
			if ((imageList == null) || (imageList.Images.Count==0))
				return -1 ;

			imageControl = new XCalendarImageEditorControl(); 
			imageControl.Init(imageList,12,12,6,(int)value);
			
			// add listner for event
			imageControl.ItemClick += new XCalendarImageEditorControlEventHandler(OnItemClicked);
			
			// set m_selectedIndex to -1 in case the dropdown is closed without selection
			m_selectedIndex = -1;
			// show the popup as a drop-down
			wfes.DropDownControl(imageControl) ;
			
			// return the selection (or the original value if none selected)
			return (m_selectedIndex != -1) ? m_selectedIndex : (int) value ;
		}

		public override System.Drawing.Design.UITypeEditorEditStyle GetEditStyle(System.ComponentModel.ITypeDescriptorContext context)
		{
			if(context != null && context.Instance != null ) 
			{
				return UITypeEditorEditStyle.DropDown ;
			}
			return base.GetEditStyle (context);
		}
		

		public override bool GetPaintValueSupported(System.ComponentModel.ITypeDescriptorContext context)
		{
			return true;
		}

		public override void PaintValue(System.Drawing.Design.PaintValueEventArgs pe)
		{
			int imageIndex = -1 ;	
			// value is the image index
			if(pe.Value != null) 
			{
				try 
				{
					imageIndex = (int)Convert.ToUInt16( pe.Value.ToString() ) ;
				}
				catch
				{
				}
			}
			// no instance, or the instance represents an undefined image
			if((pe.Context.Instance == null) || (imageIndex < 0))
				return ;
			// get the image set
			ImageList imageList = GetImageList(pe.Context.Instance) ;
			// make sure everything is valid
			if((imageList == null) || (imageList.Images.Count == 0) || (imageIndex >= imageList.Images.Count))
				return ;
			// Draw the preview image
			pe.Graphics.DrawImage(imageList.Images[imageIndex],pe.Bounds);
		}

		#endregion

		#region EventHandlers

		private void OnItemClicked(object sender, XCalendarImageEditorControlEventArgs e)
		{
			m_selectedIndex = ((XCalendarImageEditorControlEventArgs) e).SelectedItem;
			
			//remove listner
			imageControl.ItemClick -= new XCalendarImageEditorControlEventHandler(OnItemClicked);
			
			// close the drop-dwon, we are done
			wfes.CloseDropDown() ;

			imageControl.Dispose() ;
			imageControl = null ;
		}

		#endregion
	
	}

}
