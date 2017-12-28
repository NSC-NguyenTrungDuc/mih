package nta.med.core.glossary;

public enum TrialFlg {
	YES("Y"), NO("N");
	private String value;

	TrialFlg(String value) {
        this.value = value;
    }
	
	public String getValue(){
		return value;
	}
}
