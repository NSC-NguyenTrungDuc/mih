package nta.med.core.glossary;

public enum AutoBunhoFlg {
	AUTO("1"), NORMAL("0");
	private String value;

	AutoBunhoFlg(String value) {
        this.value = value;
    }
	
	public String getValue(){
		return value;
	}
}
