package nta.med.data.model.ihis.emr;

import java.util.Date;

public class InsuranceProviderInfo {

	private String insProviderNo;
	private String insCode;
	private String number;
	private Date expireDate;
	private String insInstitutionalName;
	private Date effectiveDate;
	private String insName;
	
	public InsuranceProviderInfo(String insProviderNo, String insCode, String number, Date expireDate,
			String insInstitutionalName, Date effectiveDate, String insName) {
		super();
		this.insProviderNo = insProviderNo;
		this.insCode = insCode;
		this.number = number;
		this.expireDate = expireDate;
		this.insInstitutionalName = insInstitutionalName;
		this.effectiveDate = effectiveDate;
		this.insName = insName;
	}

	public String getInsProviderNo() {
		return insProviderNo;
	}

	public void setInsProviderNo(String insProviderNo) {
		this.insProviderNo = insProviderNo;
	}

	public String getInsCode() {
		return insCode;
	}

	public void setInsCode(String insCode) {
		this.insCode = insCode;
	}

	public String getNumber() {
		return number;
	}

	public void setNumber(String number) {
		this.number = number;
	}

	public Date getExpireDate() {
		return expireDate;
	}

	public void setExpireDate(Date expireDate) {
		this.expireDate = expireDate;
	}

	public String getInsInstitutionalName() {
		return insInstitutionalName;
	}

	public void setInsInstitutionalName(String insInstitutionalName) {
		this.insInstitutionalName = insInstitutionalName;
	}

	public Date getEffectiveDate() {
		return effectiveDate;
	}

	public void setEffectiveDate(Date effectiveDate) {
		this.effectiveDate = effectiveDate;
	}

	public String getInsName() {
		return insName;
	}

	public void setInsName(String insName) {
		this.insName = insName;
	}
	
}
