using System;

namespace IHIS.CloudConnector.Contracts.Models.Drgs
{
    [Serializable]
	public class DrgsDRG5100P01OrderJungboInfo
	{
		private String _seq1;
		private String _seq2;
		private String _text1;
		private String _text2;
		private String _text3;
		private String _remark;
		private String _barDrgBunho;
		private String _bunho;
		private DrgsDRG5100P01JungboInfo _jungboInfo;

		public String Seq1
		{
			get { return this._seq1; }
			set { this._seq1 = value; }
		}

		public String Seq2
		{
			get { return this._seq2; }
			set { this._seq2 = value; }
		}

		public String Text1
		{
			get { return this._text1; }
			set { this._text1 = value; }
		}

		public String Text2
		{
			get { return this._text2; }
			set { this._text2 = value; }
		}

		public String Text3
		{
			get { return this._text3; }
			set { this._text3 = value; }
		}

		public String Remark
		{
			get { return this._remark; }
			set { this._remark = value; }
		}

		public String BarDrgBunho
		{
			get { return this._barDrgBunho; }
			set { this._barDrgBunho = value; }
		}

		public String Bunho
		{
			get { return this._bunho; }
			set { this._bunho = value; }
		}

		public DrgsDRG5100P01JungboInfo JungboInfo
		{
			get { return this._jungboInfo; }
			set { this._jungboInfo = value; }
		}

		public DrgsDRG5100P01OrderJungboInfo() { }

		public DrgsDRG5100P01OrderJungboInfo(String seq1, String seq2, String text1, String text2, String text3, String remark, String barDrgBunho, String bunho, DrgsDRG5100P01JungboInfo jungboInfo)
		{
			this._seq1 = seq1;
			this._seq2 = seq2;
			this._text1 = text1;
			this._text2 = text2;
			this._text3 = text3;
			this._remark = remark;
			this._barDrgBunho = barDrgBunho;
			this._bunho = bunho;
			this._jungboInfo = jungboInfo;
		}

	}
}