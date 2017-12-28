package nta.med.ext.phr.glossary;

public enum TemperatureType {

	C_DEGREE("C"), 
	F_DEGREE("F"), 
	TEMP_ALL("00"), 
	TEMP_TEMPERATURE("01"), 
	TEMP_HEARTRATE("02"), 
	TEMP_BREATH("03"), 
	TEMP_BP("04");

	private String value;

	private TemperatureType(String value) {
		this.value = value;
	}
	
	public String getValue(){
		return this.value;
	}
}
