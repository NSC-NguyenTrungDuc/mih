package nta.med.data.model.ihis.nuro;

import java.util.Date;

public class ORCATransferOrdersDiseaseInfo {
	private String diagnosisCode       ;
	private String diagnosisSystem     ;
	private Date diagnosisStartDate    ;
	private Date diagnosisEndDate      ;
	private String mmlTableId          ;
	private String diagnosisCategory   ;
	private String jusangYn            ;
	public ORCATransferOrdersDiseaseInfo(String diagnosisCode,
			String diagnosisSystem, Date diagnosisStartDate,
			Date diagnosisEndDate, String mmlTableId, String diagnosisCategory,
			String jusangYn) {
		super();
		this.diagnosisCode = diagnosisCode;
		this.diagnosisSystem = diagnosisSystem;
		this.diagnosisStartDate = diagnosisStartDate;
		this.diagnosisEndDate = diagnosisEndDate;
		this.mmlTableId = mmlTableId;
		this.diagnosisCategory = diagnosisCategory;
		this.jusangYn = jusangYn;
	}
	public String getDiagnosisCode() {
		return diagnosisCode;
	}
	public void setDiagnosisCode(String diagnosisCode) {
		this.diagnosisCode = diagnosisCode;
	}
	public String getDiagnosisSystem() {
		return diagnosisSystem;
	}
	public void setDiagnosisSystem(String diagnosisSystem) {
		this.diagnosisSystem = diagnosisSystem;
	}
	public Date getDiagnosisStartDate() {
		return diagnosisStartDate;
	}
	public void setDiagnosisStartDate(Date diagnosisStartDate) {
		this.diagnosisStartDate = diagnosisStartDate;
	}
	public Date getDiagnosisEndDate() {
		return diagnosisEndDate;
	}
	public void setDiagnosisEndDate(Date diagnosisEndDate) {
		this.diagnosisEndDate = diagnosisEndDate;
	}
	public String getMmlTableId() {
		return mmlTableId;
	}
	public void setMmlTableId(String mmlTableId) {
		this.mmlTableId = mmlTableId;
	}
	public String getDiagnosisCategory() {
		return diagnosisCategory;
	}
	public void setDiagnosisCategory(String diagnosisCategory) {
		this.diagnosisCategory = diagnosisCategory;
	}
	public String getJusangYn() {
		return jusangYn;
	}
	public void setJusangYn(String jusangYn) {
		this.jusangYn = jusangYn;
	}
	
}
