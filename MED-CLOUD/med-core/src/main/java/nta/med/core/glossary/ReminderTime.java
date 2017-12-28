package nta.med.core.glossary;

import java.util.HashMap;
import java.util.Map;

public enum ReminderTime {
	
	/** The BEFOR e_60_ minutes. */
	BEFORE_60_MINUTES(60, "fe003.label.before.60.minutes"),
	
	/** The BEFOR e_30_ minutes. */
	BEFORE_30_MINUTES(30, "fe003.label.before.30.minutes");
	
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
