package nta.med.ext.phr.glossary;

public enum FitnessType {

	FITNESS_ALL("00"), 
	FITNESS_STEPS("01"), 
	FITNESS_DISTANCE("02");

	private String value;

	private FitnessType(String value) {
		this.value = value;
	}
	
	public String getValue(){
		return this.value;
	}
}
