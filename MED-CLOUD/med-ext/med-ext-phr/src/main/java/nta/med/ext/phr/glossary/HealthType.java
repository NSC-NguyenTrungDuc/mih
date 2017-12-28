package nta.med.ext.phr.glossary;

public enum HealthType {
	
	HEALTH_ALL("00"),
	HEIGHT("01"),
    WEIGHT("02"),
    BMI("03"),
	BFP("04");

    private String value;

    private HealthType(String value) {
        this.value = value;
    }
    public String getValue(){
        return value;
    }
}
