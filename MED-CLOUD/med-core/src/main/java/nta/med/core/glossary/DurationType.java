package nta.med.core.glossary;

public enum DurationType {
	
	DAILY(1),
	WEEKLY(2),
    MONTHLY(3),
    YEARLY(4);

    private int value;

    private DurationType(int value) {
        this.value = value;
    }
    public int getValue(){
        return value;
    }
}
