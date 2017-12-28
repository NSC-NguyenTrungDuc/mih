package nta.mss.misc.enums;

import java.util.HashMap;
import java.util.Map;

/**
 * @author linhnt
 * 
 * The Enum TimesUsing.
 */
public enum TimesUsing {
	
	TIMES_USING_1 (1, "re011.timesusing.1"),
	
	TIMES_USING_2 (2, "re011.timesusing.2"),

	TIMES_USING_3 (3, "re011.timesusing.3"),
	
	TIMES_USING_4 (4, "re011.timesusing.4"),
	
	TIMES_USING_5 (5, "re011.timesusing.5"),
	
	TIMES_USING_6 (6, "re011.timesusing.6"),
	
	TIMES_USING_7 (7, "re011.timesusing.7"),
	
	TIMES_USING_8 (8, "re011.timesusing.8"),
	
	TIMES_USING_9 (9, "re011.timesusing.9"),
	
	TIMES_USING_10 (10, "re011.timesusing.10");
	
	/** The key. */
	private Integer key;
	
	/** The text. */
	private String text;
	
	/**
	 * Instantiates a new times using.
	 *
	 * @param key the key
	 * @param text the text
	 */
	private TimesUsing(Integer key, String text) {
		this.key = key;
		this.text = text;
	}
	
	/**
	 * To key.
	 * 
	 * @return the integer
	 */
	public Integer toKey(){
		return this.key;
	}
	
	/**
	 * To text.
	 * 
	 * @return the string
	 */
	public String toText(){
		return this.text;
	}
	
	/**
	 * New instance.
	 * 
	 * @param key
	 *            the key
	 * @return the reminder time
	 */
	public static TimesUsing newInstance(Integer key) {
		for (TimesUsing item : TimesUsing.values()) {
			if (item.toKey().equals(key)) {
				return item;
			}
		}
		return null;
	}
	
	/**
	 * To map.
	 * 
	 * @return the map
	 */
	public static Map<Integer, String> toMap(){
		Map<Integer,String> map = new HashMap<>();
		for (TimesUsing item : TimesUsing.values()) {
			map.put(item.toKey(), item.toText());
		}
		return map; 
	}
}
