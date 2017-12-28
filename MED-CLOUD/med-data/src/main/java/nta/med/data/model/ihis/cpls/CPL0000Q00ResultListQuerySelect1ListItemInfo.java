package nta.med.data.model.ihis.cpls;

public class CPL0000Q00ResultListQuerySelect1ListItemInfo {
	private Double serial;
    private String kyunResult;
    private String kyunCode;
    private String micName;
    private String micResult;
	public CPL0000Q00ResultListQuerySelect1ListItemInfo(Double serial,
			String kyunResult, String kyunCode, String micName, String micResult) {
		super();
		this.serial = serial;
		this.kyunResult = kyunResult;
		this.kyunCode = kyunCode;
		this.micName = micName;
		this.micResult = micResult;
	}
	public Double getSerial() {
		return serial;
	}
	public void setSerial(Double serial) {
		this.serial = serial;
	}
	public String getKyunResult() {
		return kyunResult;
	}
	public void setKyunResult(String kyunResult) {
		this.kyunResult = kyunResult;
	}
	public String getKyunCode() {
		return kyunCode;
	}
	public void setKyunCode(String kyunCode) {
		this.kyunCode = kyunCode;
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
