using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Microsoft.Ink;

namespace IHIS.Framework
{
	#region Enum
	internal enum DrawItemType
	{
		Text,    //Text
		Pen,     //글씨
		Rect,    //사각형
		Circle,  //원
		Line,    //Line
		Arrow    //화살표
	}
	#endregion

	#region DrawItem
	/// <summary>
	/// DrawItem에 대한 요약 설명입니다.
	/// ImageEditor에서 Drawing된 Item을 관리하는 class
	/// </summary>
	internal class DrawItem
	{
		#region Fields
		public DrawItemType ItemType = DrawItemType.Text;
		public Point Point = Point.Empty;  //위치
		public Size  Size  = Size.Empty;
		public int Thick = 1;				// 굵기
		public Color Color = Color.Empty;	// 칼라
		public bool Selected = false;      // 선택되었는지 여부(선택된 영역에 선택표시를 하기 위해 관리함)
		public string Text = string.Empty;  //Text형태일때의 Text
		public Font Font = null; //Text의 Font
		public ArrayList PointList = new ArrayList(); //Pen일떄 그린 영역의 좌표 List, Line, Arrow의 StartPt, EndPt
		public Rectangle SelectedArea = Rectangle.Empty; //선택된 영역 Rect
		public Rectangle DraggingArea = Rectangle.Empty; //Drag하고 있는 영역 Rect
		public Rectangle[] SelectedPoints = new Rectangle[9]; //선택 Point 영역 Rect
		public Stroke PenStroke = null;
		//Zoom 관련
		public Point OrigPoint = Point.Empty;
		public Size  OrigSize  = Size.Empty;
		public ArrayList OrigPointList = new ArrayList();
		#endregion

		#region 생성자
		public DrawItem()
		{
			//selectedPoints 초기화
			for (int i = 0 ; i < SelectedPoints.Length ; i++)
				SelectedPoints[i] = Rectangle.Empty;
		}
		public DrawItem(DrawItemType itemType, Point pt, Size size, int thick, Color color)
		{
			this.ItemType = itemType;
			this.Point = pt;
			this.Size = size;
			this.Thick = thick;
			this.Color = color;
			//selectedPoints 초기화
			for (int i = 0 ; i < SelectedPoints.Length ; i++)
				SelectedPoints[i] = Rectangle.Empty;
		}
		public DrawItem(DrawItemType itemType, Point pt, Size size, int thick, Color color, string text, Font font)
		{
			this.ItemType = itemType;
			this.Point = pt;
			this.Size = size;
			this.Thick = thick;
			this.Color = color;
			this.Text = text;
			//selectedPoints 초기화
			for (int i = 0 ; i < SelectedPoints.Length ; i++)
				SelectedPoints[i] = Rectangle.Empty;
		}
		#endregion
	}
	#endregion
}
