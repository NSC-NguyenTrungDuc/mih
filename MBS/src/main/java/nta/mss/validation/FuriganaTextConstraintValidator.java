package nta.mss.validation;

import javax.validation.ConstraintValidator;
import javax.validation.ConstraintValidatorContext;

import org.apache.commons.lang.StringUtils;

import nta.med.common.util.converter.HalfFullConverter;

/**
 * @author linh.nguyen.trong
 * 
 * The Class FuriganaTextConstraintValidator.
 */
public class FuriganaTextConstraintValidator implements
		ConstraintValidator<FuriganaText, String> {
	private static final String FURIGANA_CHAR = "^[\u3041-\u3093\u30A1-\u30FF-\u3000]*$";
	
	@Override
	public void initialize(FuriganaText String) {
	}

	@Override
	public boolean isValid(String furiganaText, ConstraintValidatorContext cxt) {
		if (StringUtils.isNotBlank(furiganaText)) {
			return isJapaness(furiganaText) || furiganaText.matches(FURIGANA_CHAR);
		}
		return true;
	}
	
	 /**
     * Determines if this character is a Japanese Kana.
     */
    private static boolean isKanaOrHiraOrRomaOrKanji(char c) {
        return (isHiragana(c) || isKatakana(c) || isKanji(c));
    }

    /**
     * Determines if this character is one of the Japanese Hiragana.
     */
    private static boolean isHiragana(char c) {
        return (('\u3041' <= c) && (c <= '\u309e'));
    }

    /**
     * Determines if this character is one of the Japanese Katakana.
     */
    private static boolean isKatakana(char c) {
        return (isHalfWidthKatakana(c) || isFullWidthKatakana(c));
    }
    private static boolean isCharCJK(final char c) {
        if ((Character.UnicodeBlock.of(c) == Character.UnicodeBlock.CJK_UNIFIED_IDEOGRAPHS)
                || (Character.UnicodeBlock.of(c) == Character.UnicodeBlock.CJK_UNIFIED_IDEOGRAPHS_EXTENSION_A)
                || (Character.UnicodeBlock.of(c) == Character.UnicodeBlock.CJK_UNIFIED_IDEOGRAPHS_EXTENSION_B)
                || (Character.UnicodeBlock.of(c) == Character.UnicodeBlock.CJK_COMPATIBILITY_FORMS)
                || (Character.UnicodeBlock.of(c) == Character.UnicodeBlock.CJK_COMPATIBILITY_IDEOGRAPHS)
                || (Character.UnicodeBlock.of(c) == Character.UnicodeBlock.CJK_RADICALS_SUPPLEMENT)
                || (Character.UnicodeBlock.of(c) == Character.UnicodeBlock.CJK_SYMBOLS_AND_PUNCTUATION)
                || (Character.UnicodeBlock.of(c) == Character.UnicodeBlock.ENCLOSED_CJK_LETTERS_AND_MONTHS) ||
                (Character.UnicodeBlock.of(c) == Character.UnicodeBlock.HIRAGANA )||
                (Character.UnicodeBlock.of(c) == Character.UnicodeBlock.KATAKANA )||
                (Character.UnicodeBlock.of(c) == Character.UnicodeBlock.HALFWIDTH_AND_FULLWIDTH_FORMS )
               ) {
            return true;
        }
        return false;
    }
    private static boolean isJapaness(String strs) {

        for(int i=0; i< strs.length(); i++)
        {
            if(String.valueOf(strs.charAt(i)) != null &&
                    !StringUtils.isEmpty(String.valueOf(strs.charAt(i)).trim()))
            {
                if(!isCharCJK(strs.charAt(i)))
                {
                    return false;

                }
            }
        }
        return true;
    }

    /**
     * Determines if this character is a Half width Katakana.
     */
    private static boolean isHalfWidthKatakana(char c) {
        return (('\uff66' <= c) && (c <= '\uff9d'));
    }

    /**
     * Determines if this character is a Full width Katakana.
     */
    private static boolean isFullWidthKatakana(char c) {
        return (('\u30a1' <= c) && (c <= '\u30fe'));
    }

    /**
     * Determines if this character is a Kanji character.
     */
    private static boolean isKanji(char c) {
        if (('\u4e00' <= c) && (c <= '\u9fa5')) {
            return true;
        }
        if (('\u3005' <= c) && (c <= '\u3007')) {
            return true;
        }
        return false;
    }

    /**
     * Determines if this character could be used as part of
     * a romaji character.
     */
    private static boolean isRomaji(char c) {
        if (('\u0041' <= c) && (c <= '\u0090'))
            return true;
        else if (('\u0061' <= c) && (c <= '\u007a'))
            return true;
        else if (('\u0021' <= c) && (c <= '\u003a'))
            return true;
        else if (('\u0041' <= c) && (c <= '\u005a'))
            return true;
        else
            return false;
    }

    /**
     * Translates this character into the equivalent Katakana character.
     * The function only operates on Hiragana and always returns the
     * Full width version of the Katakana. If the character is outside the
     * Hiragana then the origianal character is returned.
     */
    private static char toKatakana(char c) {
        if (isHiragana(c)) {
            return (char) (c + 0x60);
        }
        return c;
    }

    /**
     * Translates this character into the equivalent Hiragana character.
     * The function only operates on Katakana characters
     * If the character is outside the Full width or Half width
     * Katakana then the origianal character is returned.
     */
    private static char toHiragana(char c) {
        if (isFullWidthKatakana(c)) {
            return (char) (c - 0x60);
        } else if (isHalfWidthKatakana(c)) {
            return (char) (c - 0xcf25);
        }
        return c;
    }

    /**
     * Translates this character into the equivalent Romaji character.
     * The function only operates on Hiragana and Katakana characters
     * If the character is outside the given range then
     * the origianal character is returned.
     * <p/>
     * The resulting string is lowercase if the input was Hiragana and
     * UPPERCASE if the input was Katakana.
     */
    private static String toRomaji(char c) {
        if (isHiragana(c)) {
            return lookupRomaji(c);
        } else if (isKatakana(c)) {
            c = toHiragana(c);
            String str = lookupRomaji(c);
            return str.toUpperCase();
        }
        return String.valueOf(c);
    }

    /**
     * The array used to map hirgana to romaji.
     */
    protected static String romaji[] = {
            "a", "a",
            "i", "i",
            "u", "u",
            "e", "e",
            "o", "o",

            "ka", "ga",
            "ki", "gi",
            "ku", "gu",
            "ke", "ge",
            "ko", "go",

            "sa", "za",
            "shi", "ji",
            "su", "zu",
            "se", "ze",
            "so", "zo",

            "ta", "da",
            "chi", "ji",
            "tsu", "tsu", "zu",
            "te", "de",
            "to", "do",

            "na",
            "ni",
            "nu",
            "ne",
            "no",

            "ha", "ba", "pa",
            "hi", "bi", "pi",
            "fu", "bu", "pu",
            "he", "be", "pe",
            "ho", "bo", "po",

            "ma",
            "mi",
            "mu",
            "me",
            "mo",

            "a", "ya",
            "u", "yu",
            "o", "yo",

            "ra",
            "ri",
            "ru",
            "re",
            "ro",

            "wa", "wa",
            "wi", "we",
            "o",
            "n",

            "v",
            "ka",
            "ke"

    };

    /**
     * Access the array to return the correct romaji string.
     */
    private static String lookupRomaji(char c) {
        return romaji[c - 0x3041];
    }
}