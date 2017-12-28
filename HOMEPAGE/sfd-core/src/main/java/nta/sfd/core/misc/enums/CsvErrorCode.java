package nta.sfd.core.misc.enums;

public enum CsvErrorCode {
	VALID(0),
	INVALID(1),
	NOT_ENOUGH_DATA(2),
	WRONG_FORMAT(3),
	REQUIRED_DATA(4),
	WRONG_SIZE(5),
	
	EMPTY_CONTENT(99),
	EMPTY_NAME(98),
	BAD_EXTENSION(97),
	MAX_SIZE_EXCEEDED(96);

	
	private Integer value;
	private CsvErrorCode(int value){
		this.value = value;
	}
	
	public Integer toInt() {
		return this.value;
	}
	
	public static CsvErrorCode newInstance(Integer value) {
		for (CsvErrorCode item : CsvErrorCode.values()) {
			if (item.toInt().equals(value)) {
				return item;
			}
		}
		return null;
	}
}
