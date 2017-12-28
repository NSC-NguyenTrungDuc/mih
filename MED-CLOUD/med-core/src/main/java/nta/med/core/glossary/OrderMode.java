package nta.med.core.glossary;

public enum OrderMode {
	SetOrder("SetOrder"), OutOrder("OutOrder"), InpOrder("InpOrder"), CpOrder("CpOrder"), CpSetOrder("CpSetOrder");
	private String value;

	OrderMode(String value) {
        this.value = value;
    }
	
	public String getValue(){
		return value;
	}
}
