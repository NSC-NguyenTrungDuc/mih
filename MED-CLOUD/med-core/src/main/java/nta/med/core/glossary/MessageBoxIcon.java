package nta.med.core.glossary;

public enum MessageBoxIcon {
	WARNING("48");
	private String value;
	MessageBoxIcon(String value){
		this.value=value;
	}
	public String getValue(){
		return value;
	}
}
