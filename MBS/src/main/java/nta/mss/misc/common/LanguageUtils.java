package nta.mss.misc.common;

import java.text.Normalizer;
import java.util.regex.Pattern;

import nta.mss.service.impl.SmsService;

public class LanguageUtils {
	public static String convertKana(String input) {
		if (input == null || input.length() == 0)
			return "";

		StringBuilder out = new StringBuilder();
		char ch = input.charAt(0);

		if (JapaneseCharacter.isHiragana(ch)) { // convert to hiragana to katakana
			for (int i = 0; i < input.length(); i++) {
				out.append(JapaneseCharacter.toKatakana(input.charAt(i)));
			}
		/*} else if (JapaneseCharacter.isKatakana(ch)) { // convert to katakana to  hiragana
			for (int i = 0; i < input.length(); i++) {
				out.append(JapaneseCharacter.toHiragana(input.charAt(i)));
			}*/
		} else { // do nothing if neither
			return input;
		}

		return out.toString();
	}
//	chuyen tieng viet co dau -> tieng viet ko dau
	public static String unAccent(String s) {
		String temp = Normalizer.normalize(s, Normalizer.Form.NFD);
		Pattern pattern = Pattern.compile("\\p{InCombiningDiacriticalMarks}+");
		return pattern.matcher(temp).replaceAll("").replaceAll("\u0110", "D").replaceAll("\u0111", "d");
	}
}