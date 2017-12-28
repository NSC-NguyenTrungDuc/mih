package nta.med.core.glossary;

public enum ExamStatus {
	FIRST("110"), SECOND("120");
	private String value;

	ExamStatus(String value) {
        this.value = value;
    }
	
	public String getValue(){
		return value;
	}
}
