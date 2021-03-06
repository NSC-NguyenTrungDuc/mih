using System;
using System.Collections;
using System.Text;

namespace IHIS.Framework
{
	/// <summary>
	/// JapanTextHelper에 대한 요약 설명입니다.
	/// </summary>
	public class JapanTextHelper
	{
		public static Hashtable hiraList = new Hashtable();  //Hiragano -> Katakana Full
		public static Hashtable hiraList1 = new Hashtable(); //Hiragano -> Katakana Half
		public static Hashtable kataList  = new Hashtable(); //kata Half ->  kata full
		public static Hashtable kataList1  = new Hashtable(); //kata Full ->  kata half
		
		static JapanTextHelper()
		{
			//Hiragana - Katakana Full
			hiraList.Add("あ","ア");
			hiraList.Add("い","イ");
			hiraList.Add("う","ウ");
			hiraList.Add("え","エ");
			hiraList.Add("お","オ");
			hiraList.Add("か","カ");
			hiraList.Add("き","キ");
			hiraList.Add("く","ク");
			hiraList.Add("け","ケ");
			hiraList.Add("こ","コ");
			hiraList.Add("が","ガ");
			hiraList.Add("ぎ","ギ");
			hiraList.Add("ぐ","グ");
			hiraList.Add("げ","ゲ");
			hiraList.Add("ご","ゴ");
			hiraList.Add("さ","サ");
			hiraList.Add("し","シ");
			hiraList.Add("す","ス");
			hiraList.Add("せ","セ");
			hiraList.Add("そ","ソ");
			hiraList.Add("ざ","ザ");
			hiraList.Add("じ","ジ");
			hiraList.Add("ず","ズ");
			hiraList.Add("ぜ","ゼ");
			hiraList.Add("ぞ","ゾ");
			hiraList.Add("た","タ");
			hiraList.Add("ち","チ");
			hiraList.Add("つ","ツ");
			hiraList.Add("て","テ");
			hiraList.Add("と","ト");
			hiraList.Add("だ","ダ");
			hiraList.Add("ぢ","ヂ");
			hiraList.Add("づ","ヅ");
			hiraList.Add("で","デ");
			hiraList.Add("ど","ド");
			hiraList.Add("な","ナ");
			hiraList.Add("に","ニ");
			hiraList.Add("ぬ","ヌ");
			hiraList.Add("ね","ネ");
			hiraList.Add("の","ノ");
			hiraList.Add("は","ハ");
			hiraList.Add("ひ","ヒ");
			hiraList.Add("ふ","フ");
			hiraList.Add("へ","ヘ");
			hiraList.Add("ほ","ホ");
			hiraList.Add("ば","バ");
			hiraList.Add("び","ビ");
			hiraList.Add("ぶ","ブ");
			hiraList.Add("べ","ベ");
			hiraList.Add("ぼ","ボ");
			hiraList.Add("ぱ","パ");
			hiraList.Add("ぴ","ピ");
			hiraList.Add("ぷ","プ");
			hiraList.Add("ぺ","ペ");
			hiraList.Add("ぽ","ポ");
			hiraList.Add("ま","マ");
			hiraList.Add("み","ミ");
			hiraList.Add("む","ム");
			hiraList.Add("め","メ");
			hiraList.Add("も","モ");
			hiraList.Add("や","ヤ");
			hiraList.Add("ゆ","ユ");
			hiraList.Add("よ","ヨ");
			hiraList.Add("ら","ラ");
			hiraList.Add("り","リ");
			hiraList.Add("る","ル");
			hiraList.Add("れ","レ");
			hiraList.Add("ろ","ロ");
			hiraList.Add("わ","ワ");
			hiraList.Add("を","ヲ");
			hiraList.Add("ん","ン");
			hiraList.Add("っ","ッ");
			hiraList.Add("ゃ","ャ");
			hiraList.Add("ゅ","ュ");
			hiraList.Add("ょ","ョ");

			//Hiragana - Katakana Half
			hiraList1.Add("あ","ｱ");
			hiraList1.Add("い","ｲ");
			hiraList1.Add("う","ｳ");
			hiraList1.Add("え","ｴ");
			hiraList1.Add("お","ｵ");
			hiraList1.Add("か","ｶ");
			hiraList1.Add("き","ｷ");
			hiraList1.Add("く","ｸ");
			hiraList1.Add("け","ｹ");
			hiraList1.Add("こ","ｺ");
			hiraList1.Add("が","ｶﾞ");
			hiraList1.Add("ぎ","ｷﾞ");
			hiraList1.Add("ぐ","ｸﾞ");
			hiraList1.Add("げ","ｹﾞ");
			hiraList1.Add("ご","ｺﾞ");
			hiraList1.Add("さ","ｻ");
			hiraList1.Add("し","ｼ");
			hiraList1.Add("す","ｽ");
			hiraList1.Add("せ","ｾ");
			hiraList1.Add("そ","ｿ");
			hiraList1.Add("ざ","ｻﾞ");
			hiraList1.Add("じ","ｼﾞ");
			hiraList1.Add("ず","ｽﾞ");
			hiraList1.Add("ぜ","ｾﾞ");
			hiraList1.Add("ぞ","ｿﾞ");
			hiraList1.Add("た","ﾀ");
			hiraList1.Add("ち","ﾁ");
			hiraList1.Add("つ","ﾂ");
			hiraList1.Add("て","ﾃ");
			hiraList1.Add("と","ﾄ");
			hiraList1.Add("だ","ﾀﾞ");
			hiraList1.Add("ぢ","ﾁﾞ");
			hiraList1.Add("づ","ﾂﾞ");
			hiraList1.Add("で","ﾃﾞ");
			hiraList1.Add("ど","ﾄﾞ");
			hiraList1.Add("な","ﾅ");
			hiraList1.Add("に","ﾆ");
			hiraList1.Add("ぬ","ﾇ");
			hiraList1.Add("ね","ﾈ");
			hiraList1.Add("の","ﾉ");
			hiraList1.Add("は","ﾊ");
			hiraList1.Add("ひ","ﾋ");
			hiraList1.Add("ふ","ﾌ");
			hiraList1.Add("へ","ﾍ");
			hiraList1.Add("ほ","ﾎ");
			hiraList1.Add("ば","ﾊﾞ");
			hiraList1.Add("び","ﾋﾞ");
			hiraList1.Add("ぶ","ﾌﾞ");
			hiraList1.Add("べ","ﾍﾞ");
			hiraList1.Add("ぼ","ﾎﾞ");
			hiraList1.Add("ぱ","ﾊﾟ");
			hiraList1.Add("ぴ","ﾋﾟ");
			hiraList1.Add("ぷ","ﾌﾟ");
			hiraList1.Add("ぺ","ﾍﾟ");
			hiraList1.Add("ぽ","ﾎﾟ");
			hiraList1.Add("ま","ﾏ");
			hiraList1.Add("み","ﾐ");
			hiraList1.Add("む","ﾑ");
			hiraList1.Add("め","ﾒ");
			hiraList1.Add("も","ﾓ");
			hiraList1.Add("や","ﾔ");
			hiraList1.Add("ゆ","ﾕ");
			hiraList1.Add("よ","ﾖ");
			hiraList1.Add("ら","ﾗ");
			hiraList1.Add("り","ﾘ");
			hiraList1.Add("る","ﾙ");
			hiraList1.Add("れ","ﾚ");
			hiraList1.Add("ろ","ﾛ");
			hiraList1.Add("わ","ﾜ");
			hiraList1.Add("を","ｦ");
			hiraList1.Add("ん","ﾝ");
			hiraList1.Add("っ","ｯ");
			hiraList1.Add("ゃ","ｬ");
			hiraList1.Add("ゅ","ｭ");
			hiraList1.Add("ょ","ｮ");

			//Half kata -> Full Kata
			kataList.Add("ｱ","ア");
			kataList.Add("ｲ","イ");
			kataList.Add("ｳ","ウ");
			kataList.Add("ｴ","エ");
			kataList.Add("ｵ","オ");
			kataList.Add("ｶ","カ");
			kataList.Add("ｷ","キ");
			kataList.Add("ｸ","ク");
			kataList.Add("ｹ","ケ");
			kataList.Add("ｺ","コ");
			kataList.Add("ｶﾞ","ガ");
			kataList.Add("ｷﾞ","ギ");
			kataList.Add("ｸﾞ","グ");
			kataList.Add("ｹﾞ","ゲ");
			kataList.Add("ｺﾞ","ゴ");
			kataList.Add("ｻ","サ");
			kataList.Add("ｼ","シ");
			kataList.Add("ｽ","ス");
			kataList.Add("ｾ","セ");
			kataList.Add("ｿ","ソ");
			kataList.Add("ｻﾞ","ザ");
			kataList.Add("ｼﾞ","ジ");
			kataList.Add("ｽﾞ","ズ");
			kataList.Add("ｾﾞ","ゼ");
			kataList.Add("ｿﾞ","ゾ");
			kataList.Add("ﾀ","タ");
			kataList.Add("ﾁ","チ");
			kataList.Add("ﾂ","ツ");
			kataList.Add("ﾃ","テ");
			kataList.Add("ﾄ","ト");
			kataList.Add("ﾀﾞ","ダ");
			kataList.Add("ﾁﾞ","ヂ");
			kataList.Add("ﾂﾞ","ヅ");
			kataList.Add("ﾃﾞ","デ");
			kataList.Add("ﾄﾞ","ド");
			kataList.Add("ﾅ","ナ");
			kataList.Add("ﾆ","ニ");
			kataList.Add("ﾇ","ヌ");
			kataList.Add("ﾈ","ネ");
			kataList.Add("ﾉ","ノ");
			kataList.Add("ﾊ","ハ");
			kataList.Add("ﾋ","ヒ");
			kataList.Add("ﾌ","フ");
			kataList.Add("ﾍ","ヘ");
			kataList.Add("ﾎ","ホ");
			kataList.Add("ﾊﾞ","バ");
			kataList.Add("ﾋﾞ","ビ");
			kataList.Add("ﾌﾞ","ブ");
			kataList.Add("ﾍﾞ","ベ");
			kataList.Add("ﾎﾞ","ボ");
			kataList.Add("ﾊﾟ","パ");
			kataList.Add("ﾋﾟ","ピ");
			kataList.Add("ﾌﾟ","プ");
			kataList.Add("ﾍﾟ","ペ");
			kataList.Add("ﾎﾟ","ポ");
			kataList.Add("ﾏ","マ");
			kataList.Add("ﾐ","ミ");
			kataList.Add("ﾑ","ム");
			kataList.Add("ﾒ","メ");
			kataList.Add("ﾓ","モ");
			kataList.Add("ﾔ","ヤ");
			kataList.Add("ﾕ","ユ");
			kataList.Add("ﾖ","ヨ");
			kataList.Add("ﾗ","ラ");
			kataList.Add("ﾘ","リ");
			kataList.Add("ﾙ","ル");
			kataList.Add("ﾚ","レ");
			kataList.Add("ﾛ","ロ");
			kataList.Add("ﾜ","ワ");
			kataList.Add("ｦ","ヲ");
			kataList.Add("ﾝ","ン");
			kataList.Add("ｯ","ッ");
			kataList.Add("ｬ","ャ");
			kataList.Add("ｭ","ュ");
			kataList.Add("ｮ","ョ");

			kataList.Add("ｰ","ー");

			kataList.Add("A","Ａ");
			kataList.Add("B","Ｂ");
			kataList.Add("C","Ｃ");
			kataList.Add("D","Ｄ");
			kataList.Add("E","Ｅ");
			kataList.Add("F","Ｆ");
			kataList.Add("G","Ｇ");
			kataList.Add("H","Ｈ");
			kataList.Add("I","Ｉ");
			kataList.Add("J","Ｊ");
			kataList.Add("K","Ｋ");
			kataList.Add("L","Ｌ");
			kataList.Add("M","Ｍ");
			kataList.Add("N","Ｎ");
			kataList.Add("O","Ｏ");
			kataList.Add("P","Ｐ");
			kataList.Add("Q","Ｑ");
			kataList.Add("R","Ｒ");
			kataList.Add("S","Ｓ");
			kataList.Add("T","Ｔ");
			kataList.Add("U","Ｕ");
			kataList.Add("V","Ｖ");
			kataList.Add("W","Ｗ");
			kataList.Add("X","Ｘ");
			kataList.Add("Y","Ｙ");
			kataList.Add("Z","Ｚ");

			kataList.Add("a","ａ");
			kataList.Add("b","ｂ");
			kataList.Add("c","ｃ");
			kataList.Add("d","ｄ");
			kataList.Add("e","ｅ");
			kataList.Add("f","ｆ");
			kataList.Add("g","ｇ");
			kataList.Add("h","ｈ");
			kataList.Add("i","ｉ");
			kataList.Add("j","ｊ");
			kataList.Add("k","ｋ");
			kataList.Add("l","ｌ");
			kataList.Add("m","ｍ");
			kataList.Add("n","ｎ");
			kataList.Add("o","ｏ");
			kataList.Add("p","ｐ");
			kataList.Add("q","ｑ");
			kataList.Add("r","ｒ");
			kataList.Add("s","ｓ");
			kataList.Add("t","ｔ");
			kataList.Add("u","ｕ");
			kataList.Add("v","ｖ");
			kataList.Add("w","ｗ");
			kataList.Add("x","ｘ");
			kataList.Add("y","ｙ");
			kataList.Add("z","ｚ");

			kataList.Add("0","０");
			kataList.Add("1","１");
			kataList.Add("2","２");
			kataList.Add("3","３");
			kataList.Add("4","４");
			kataList.Add("5","５");
			kataList.Add("6","６");
			kataList.Add("7","７");
			kataList.Add("8","８");
			kataList.Add("9","９");


			//Full kata -> Half kata
			kataList1.Add("ア","ｱ");
			kataList1.Add("イ","ｲ");
			kataList1.Add("ウ","ｳ");
			kataList1.Add("エ","ｴ");
			kataList1.Add("オ","ｵ");
			kataList1.Add("カ","ｶ");
			kataList1.Add("キ","ｷ");
			kataList1.Add("ク","ｸ");
			kataList1.Add("ケ","ｹ");
			kataList1.Add("コ","ｺ");
			kataList1.Add("ガ","ｶﾞ");
			kataList1.Add("ギ","ｷﾞ");
			kataList1.Add("グ","ｸﾞ");
			kataList1.Add("ゲ","ｹﾞ");
			kataList1.Add("ゴ","ｺﾞ");
			kataList1.Add("サ","ｻ");
			kataList1.Add("シ","ｼ");
			kataList1.Add("ス","ｽ");
			kataList1.Add("セ","ｾ");
			kataList1.Add("ソ","ｿ");
			kataList1.Add("ザ","ｻﾞ");
			kataList1.Add("ジ","ｼﾞ");
			kataList1.Add("ズ","ｽﾞ");
			kataList1.Add("ゼ","ｾﾞ");
			kataList1.Add("ゾ","ｿﾞ");
			kataList1.Add("タ","ﾀ");
			kataList1.Add("チ","ﾁ");
			kataList1.Add("ツ","ﾂ");
			kataList1.Add("テ","ﾃ");
			kataList1.Add("ト","ﾄ");
			kataList1.Add("ダ","ﾀﾞ");
			kataList1.Add("ヂ","ﾁﾞ");
			kataList1.Add("ヅ","ﾂﾞ");
			kataList1.Add("デ","ﾃﾞ");
			kataList1.Add("ド","ﾄﾞ");
			kataList1.Add("ナ","ﾅ");
			kataList1.Add("ニ","ﾆ");
			kataList1.Add("ヌ","ﾇ");
			kataList1.Add("ネ","ﾈ");
			kataList1.Add("ノ","ﾉ");
			kataList1.Add("ハ","ﾊ");
			kataList1.Add("ヒ","ﾋ");
			kataList1.Add("フ","ﾌ");
			kataList1.Add("ヘ","ﾍ");
			kataList1.Add("ホ","ﾎ");
			kataList1.Add("バ","ﾊﾞ");
			kataList1.Add("ビ","ﾋﾞ");
			kataList1.Add("ブ","ﾌﾞ");
			kataList1.Add("ベ","ﾍﾞ");
			kataList1.Add("ボ","ﾎﾞ");
			kataList1.Add("パ","ﾊﾟ");
			kataList1.Add("ピ","ﾋﾟ");
			kataList1.Add("プ","ﾌﾟ");
			kataList1.Add("ペ","ﾍﾟ");
			kataList1.Add("ポ","ﾎﾟ");
			kataList1.Add("マ","ﾏ");
			kataList1.Add("ミ","ﾐ");
			kataList1.Add("ム","ﾑ");
			kataList1.Add("メ","ﾒ");
			kataList1.Add("モ","ﾓ");
			kataList1.Add("ヤ","ﾔ");
			kataList1.Add("ユ","ﾕ");
			kataList1.Add("ヨ","ﾖ");
			kataList1.Add("ラ","ﾗ");
			kataList1.Add("リ","ﾘ");
			kataList1.Add("ル","ﾙ");
			kataList1.Add("レ","ﾚ");
			kataList1.Add("ロ","ﾛ");
			kataList1.Add("ワ","ﾜ");
			kataList1.Add("ヲ","ｦ");
			kataList1.Add("ン","ﾝ");
			kataList1.Add("ッ","ｯ");
			kataList1.Add("ャ","ｬ");
			kataList1.Add("ュ","ｭ");
			kataList1.Add("ョ","ｮ");

			kataList1.Add("ー","ｰ");

			kataList1.Add("Ａ","A");
			kataList1.Add("Ｂ","B");
			kataList1.Add("Ｃ","C");
			kataList1.Add("Ｄ","D");
			kataList1.Add("Ｅ","E");
			kataList1.Add("Ｆ","F");
			kataList1.Add("Ｇ","G");
			kataList1.Add("Ｈ","H");
			kataList1.Add("Ｉ","I");
			kataList1.Add("Ｊ","J");
			kataList1.Add("Ｋ","K");
			kataList1.Add("Ｌ","L");
			kataList1.Add("Ｍ","M");
			kataList1.Add("Ｎ","N");
			kataList1.Add("Ｏ","O");
			kataList1.Add("Ｐ","P");
			kataList1.Add("Ｑ","Q");
			kataList1.Add("Ｒ","R");
			kataList1.Add("Ｓ","S");
			kataList1.Add("Ｔ","T");
			kataList1.Add("Ｕ","U");
			kataList1.Add("Ｖ","V");
			kataList1.Add("Ｗ","W");
			kataList1.Add("Ｘ","X");
			kataList1.Add("Ｙ","Y");
			kataList1.Add("Ｚ","Z");
		
			kataList1.Add("ａ","a");
			kataList1.Add("ｂ","b");
			kataList1.Add("ｃ","c");
			kataList1.Add("ｄ","d");
			kataList1.Add("ｅ","e");
			kataList1.Add("ｆ","f");
			kataList1.Add("ｇ","g");
			kataList1.Add("ｈ","h");
			kataList1.Add("ｉ","i");
			kataList1.Add("ｊ","j");
			kataList1.Add("ｋ","k");
			kataList1.Add("ｌ","l");
			kataList1.Add("ｍ","m");
			kataList1.Add("ｎ","n");
			kataList1.Add("ｏ","o");
			kataList1.Add("ｐ","p");
			kataList1.Add("ｑ","q");
			kataList1.Add("ｒ","r");
			kataList1.Add("ｓ","s");
			kataList1.Add("ｔ","t");
			kataList1.Add("ｕ","u");
			kataList1.Add("ｖ","v");
			kataList1.Add("ｗ","w");
			kataList1.Add("ｘ","x");
			kataList1.Add("ｙ","y");
			kataList1.Add("ｚ","z");

			kataList1.Add("０","0");
			kataList1.Add("１","1");
			kataList1.Add("２","2");
			kataList1.Add("３","3");
			kataList1.Add("４","4");
			kataList1.Add("５","5");
			kataList1.Add("６","6");
			kataList1.Add("７","7");
			kataList1.Add("８","8");
			kataList1.Add("９","9");
		}
		
		//kataList(Half kata -> Full Kata), kataList1(Full kata-> half kata)
		//hiraList(Hira -> full kata), hiraList1(Hira -> half kata)
		public static string GetFullKatakana(string text , bool onlyHalfKataConvert)
		{
			//onlyHalfKata가 true이면 kataList에서만 처리
			//false이면 kataList처리후 -> hiraList처리후 없으면 자기문자

			StringBuilder sb = new StringBuilder();
			for (int i = 0; i < text.Length; i++)
			{
				if (kataList.Contains(text[i].ToString()))
					sb.Append(kataList[text[i].ToString()]);
				else if (!onlyHalfKataConvert)
				{
					if (hiraList.Contains(text[i].ToString()))
						sb.Append(hiraList[text[i].ToString()]);
					else
						sb.Append(text[i]);
				}
				else //없으면 그 문자 그대로
					sb.Append(text[i]);
			}
			return sb.ToString();
		}
		public static string GetHalfKatakana(string text, bool onlyFullKataConvert)
		{
			//onlyFullKata가 true이면 kataList1에서만 처리
			//false이면 kataList1처리후 -> hiraList1처리후 없으면 자기문자

			StringBuilder sb = new StringBuilder();
			for (int i = 0; i < text.Length; i++)
			{
				if (kataList1.Contains(text[i].ToString()))
					sb.Append(kataList1[text[i].ToString()]);
				else if (!onlyFullKataConvert)
				{
					if (hiraList1.Contains(text[i].ToString()))
						sb.Append(hiraList1[text[i].ToString()]);
					else
						sb.Append(text[i]);
				}
				else //없으면 그 문자 그대로
					sb.Append(text[i]);
			}
			return sb.ToString();
		}

        /* 2010.08.14 kimminsoo 추가
         * 무조건 전각으로 만들어주는 함수 
         */
        public static string Half2Full(string sHalf)
        {
            return Microsoft.VisualBasic.Strings.StrConv(sHalf, Microsoft.VisualBasic.VbStrConv.Wide,0);
        } 


        /* 2010.08.14 kimminsoo 추가
         * 무조건 반각으로 표시
         */
        public static string Full2Half(string sFull)
        {
            return Microsoft.VisualBasic.Strings.StrConv(sFull, Microsoft.VisualBasic.VbStrConv.Narrow, 0);
        } 



	}
}
