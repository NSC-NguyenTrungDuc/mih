package nta.med.data.model.ihis.orca;

import java.sql.Timestamp;
import java.util.Date;

public class ORCATransferOrdersClaimOrdersFeeInfo {
	private String docUid           ;
	private Timestamp confirmDate      ;
	private Timestamp performTime      ;
	private String bundleNumber     ;
	private String hangmogCode      ;
	private String doctorId         ;
	private String gwa               ;
	private String numb              ;
	private String numberCode       ;
	private String clsCode          ;
	private String gwaName          ;
	private Timestamp actingDate         ;
	public ORCATransferOrdersClaimOrdersFeeInfo(String docUid,
			Timestamp confirmDate, Timestamp performTime, String bundleNumber,
			String hangmogCode, String doctorId, String gwa, String numb,
			String numberCode, String clsCode, String gwaName, Timestamp actingDate) {
		super();
		this.docUid = docUid;
		this.confirmDate = confirmDate;
		this.performTime = performTime;
		this.bundleNumber = bundleNumber;
		this.hangmogCode = hangmogCode;
		this.doctorId = doctorId;
		this.gwa = gwa;
		this.numb = numb;
		this.numberCode = numberCode;
		this.clsCode = clsCode;
		this.gwaName = gwaName;
		this.actingDate = actingDate;
	}
	public String getDocUid() {
		return docUid;
	}
	public void setDocUid(String docUid) {
		this.docUid = docUid;
	}
	public Date getConfirmDate() {
		return confirmDate;
	}
	public void setConfirmDate(Timestamp confirmDate) {
		this.confirmDate = confirmDate;
	}
	public Date getPerformTime() {
		return performTime;
	}
	public void setPerformTime(Timestamp performTime) {
		this.performTime = performTime;
	}
	public String getBundleNumber() {
		return bundleNumber;
	}
	public void setBundleNumber(String bundleNumber) {
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
	public String getNumb() {
		return numb;
	}
	public void setNumb(String numb) {
		this.numb = numb;
	}
	public String getNumberCode() {
		return numberCode;
	}
	public void setNumberCode(String numberCode) {
		this.numberCode = numberCode;
	}
	public String getClsCode() {
		return clsCode;
	}
	public void setClsCode(String clsCode) {
		this.clsCode = clsCode;
	}
	public String getGwaName() {
		return gwaName;
	}
	public void setGwaName(String gwaName) {
		this.gwaName = gwaName;
	}
	public Date getActingDate() {
		return actingDate;
	}
	public void setActingDate(Timestamp actingDate) {
		this.actingDate = actingDate;
	}
	
}
