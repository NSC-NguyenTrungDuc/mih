package nta.med.ext.phr.glossary;

public enum GrowthType {

	GROWTH_ALL("00"), 
	GROWTH_HEIGHT("01"), 
	GROWTH_WEIGHT("02");

	private String value;

	private GrowthType(String value) {
		this.value = value;
	}
	
	public String getValue(){
		return this.value;
	}
}
