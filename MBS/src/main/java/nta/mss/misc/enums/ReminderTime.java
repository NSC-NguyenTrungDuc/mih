package nta.mss.misc.enums;

import java.util.HashMap;
import java.util.Map;

/**
 * The Enum ReminderTime.
 * 
 * @author DinhNX
 * @CrtDate Jul 29, 2014
 */
public enum ReminderTime {
	
	/** The BEFOR e_10_ minutes. */
	BEFORE_10_MINUTES(10, "fe003.label.before.10.minutes"),
	
	/** The BEFOR e_15_ minutes. */
	BEFORE_15_MINUTES(15, "fe003.label.before.15.minutes"),
	
	/** The BEFOR e_30_ minutes. */
	BEFORE_30_MINUTES(30, "fe003.label.before.30.minutes"),
	
	
	/** The BEFOR e_45_ minutes. */
	BEFORE_45_MINUTES(45, "fe003.label.before.45.minutes"),
	
	/** The BEFOR e_60_ minutes. */
	BEFORE_60_MINUTES(60, "fe003.label.before.60.minutes");
	

	
	private Integer key;
	private String text;
	
	/**
	 * Instantiates a new reminder time.
	 * 
	 * @param key
	 *            the key
	 * @param text
	 *            the text
	 */
	private ReminderTime(Integer key, String text) {
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
	public static ReminderTime newInstance(Integer key) {
		for (ReminderTime item : ReminderTime.values()) {
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
		for (ReminderTime item : ReminderTime.values()) {
			map.put(item.toKey(), item.toText());
		}
		return map; 
	}
}
