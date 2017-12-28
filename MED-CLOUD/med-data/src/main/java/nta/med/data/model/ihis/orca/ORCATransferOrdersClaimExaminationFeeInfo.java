package nta.med.data.model.ihis.orca;

public class ORCATransferOrdersClaimExaminationFeeInfo {
	private String ioFlag              ;
	private String clsTime          ;
	private Double bundleNumber     ;
	private String clsCode          ;
	private String subClsCode      ;
	private String hangmogCode      ;
	public ORCATransferOrdersClaimExaminationFeeInfo(String ioFlag,
			String clsTime, Double bundleNumber, String clsCode,
			String subClsCode, String hangmogCode) {
		super();
		this.ioFlag = ioFlag;
		this.clsTime = clsTime;
		this.bundleNumber = bundleNumber;
		this.clsCode = clsCode;
		this.subClsCode = subClsCode;
		this.hangmogCode = hangmogCode;
	}
	public String getIoFlag() {
		return ioFlag;
	}
	public void setIoFlag(String ioFlag) {
		this.ioFlag = ioFlag;
	}
	public String getClsTime() {
		return clsTime;
	}
	public void setClsTime(String clsTime) {
		this.clsTime = clsTime;
	}
	public Double getBundleNumber() {
		return bundleNumber;
	}
	public void setBundleNumber(Double bundleNumber) {
		this.bundleNumber = bundleNumber;
	}
	public String getClsCode() {
		return clsCode;
	}
	public void setClsCode(String clsCode) {
		this.clsCode = clsCode;
	}
	public String getSubClsCode() {
		return subClsCode;
	}
	public void setSubClsCode(String subClsCode) {
		this.subClsCode = subClsCode;
	}
	public String getHangmogCode() {
		return hangmogCode;
	}
	public void setHangmogCode(String hangmogCode) {
		this.hangmogCode = hangmogCode;
	}
}
