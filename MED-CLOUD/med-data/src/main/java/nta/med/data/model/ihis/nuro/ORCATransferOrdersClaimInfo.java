package nta.med.data.model.ihis.nuro;

import java.util.Date;

public class ORCATransferOrdersClaimInfo {
	private String docUid03          ;
	private Date confirmDate03     ;
	private String performTime        ;
	private String actingTime         ;
	private Double bundleNumber       ;
	private String hangmogCode        ;
	private String doctorId           ;
	private String gwa                 ;
	private String gwaName            ;
	private String sgCode             ;
	public ORCATransferOrdersClaimInfo(String docUid03, Date confirmDate03,
			String performTime, String actingTime, Double bundleNumber,
			String hangmogCode, String doctorId, String gwa, String gwaName,
			String sgCode) {
		super();
		this.docUid03 = docUid03;
		this.confirmDate03 = confirmDate03;
		this.performTime = performTime;
		this.actingTime = actingTime;
		this.bundleNumber = bundleNumber;
		this.hangmogCode = hangmogCode;
		this.doctorId = doctorId;
		this.gwa = gwa;
		this.gwaName = gwaName;
		this.sgCode = sgCode;
	}
	public String getDocUid03() {
		return docUid03;
	}
	public void setDocUid03(String docUid03) {
		this.docUid03 = docUid03;
	}
	public Date getConfirmDate03() {
		return confirmDate03;
	}
	public void setConfirmDate03(Date confirmDate03) {
		this.confirmDate03 = confirmDate03;
	}
	public String getPerformTime() {
		return performTime;
	}
	public void setPerformTime(String performTime) {
		this.performTime = performTime;
	}
	public String getActingTime() {
		return actingTime;
	}
	public void setActingTime(String actingTime) {
		this.actingTime = actingTime;
	}
	public Double getBundleNumber() {
		return bundleNumber;
	}
	public void setBundleNumber(Double bundleNumber) {
		this.bundleNumber = bundleNumber;
	}
	public String getHangmogCode() {
		return hangmogCode;
	}
	public void setHangmogCode(String hangmogCode) {
		this.hangmogCode = hangmogCode;
	}
	public String getDoctorId() {
		return doctorId;
	}
	public void setDoctorId(String doctorId) {
		this.doctorId = doctorId;
	}
	public String getGwa() {
		return gwa;
	}
	public void setGwa(String gwa) {
		this.gwa = gwa;
	}
	public String getGwaName() {
		return gwaName;
	}
	public void setGwaName(String gwaName) {
		this.gwaName = gwaName;
	}
	public String getSgCode() {
		return sgCode;
	}
	public void setSgCode(String sgCode) {
		this.sgCode = sgCode;
	}
	
}
