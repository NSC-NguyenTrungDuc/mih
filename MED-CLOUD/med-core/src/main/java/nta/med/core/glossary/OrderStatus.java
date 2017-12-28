package nta.med.core.glossary;

public enum OrderStatus {
	
	DO_NOT_TRANFER("10"), TRANFER_SUCCESS("20"), TRANFER_FAIL("21"), PAID_ORDER("30");
	
	private String value;

	OrderStatus(String value) {
		this.value = value;
	}

	public String getValue() {
		return value;
	}
}
