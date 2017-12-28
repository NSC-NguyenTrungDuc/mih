package nta.med.data.model.ihis.cpls;

public class CPL0000Q00ResultListQuerySelect2ListItemInfo {
	private Integer antiSeq;
    private String antiName;
    private String micName;
    private String micResult;
	public CPL0000Q00ResultListQuerySelect2ListItemInfo(Integer antiSeq,
			String antiName, String micName, String micResult) {
		super();
		this.antiSeq = antiSeq;
		this.antiName = antiName;
		this.micName = micName;
		this.micResult = micResult;
	}
	public Integer getAntiSeq() {
		return antiSeq;
	}
	public void setAntiSeq(Integer antiSeq) {
		this.antiSeq = antiSeq;
	}
	public String getAntiName() {
		return antiName;
	}
	public void setAntiName(String antiName) {
		this.antiName = antiName;
	}
	public String getMicName() {
		return micName;
	}
	public void setMicName(String micName) {
		this.micName = micName;
	}
	public String getMicResult() {
		return micResult;
	}
	public void setMicResult(String micResult) {
		this.micResult = micResult;
	}
}
