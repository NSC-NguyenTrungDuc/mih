package nta.med.core.domain.nur;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;

/**
 * The persistent class for the NUR1016 database table.
 * 
 */
@Entity
@Table(name = "NUR1016")
public class Nur1016 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String allergyGubun;
	private String allergyInfo;
	private String bunho;
	private String cancelYn;
	private Date endDate;
	private String endSayu;
	private String hospCode;
	private String inputText;
	private Double pknur1016;
	private Date startDate;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Nur1016() {
	}

	@Column(name = "ALLERGY_GUBUN")
	public String getAllergyGubun() {
		return this.allergyGubun;
	}

	public void setAllergyGubun(String allergyGubun) {
		this.allergyGubun = allergyGubun;
	}

	@Column(name = "ALLERGY_INFO")
	public String getAllergyInfo() {
		return this.allergyInfo;
	}

	public void setAllergyInfo(String allergyInfo) {
		this.allergyInfo = allergyInfo;
	}

	public String getBunho() {
		return this.bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}

	@Column(name = "CANCEL_YN")
	public String getCancelYn() {
		return this.cancelYn;
	}

	public void setCancelYn(String cancelYn) {
		this.cancelYn = cancelYn;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "END_DATE")
	public Date getEndDate() {
		return this.endDate;
	}

	public void setEndDate(Date endDate) {
		this.endDate = endDate;
	}

	@Column(name = "END_SAYU")
	public String getEndSayu() {
		return this.endSayu;
	}

	public void setEndSayu(String endSayu) {
		this.endSayu = endSayu;
	}

	@Column(name = "HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}

	@Column(name = "INPUT_TEXT")
	public String getInputText() {
		return this.inputText;
	}

	public void setInputText(String inputText) {
		this.inputText = inputText;
	}

	public Double getPknur1016() {
		return this.pknur1016;
	}

	public void setPknur1016(Double pknur1016) {
		this.pknur1016 = pknur1016;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "START_DATE")
	public Date getStartDate() {
		return this.startDate;
	}

	public void setStartDate(Date startDate) {
		this.startDate = startDate;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "SYS_DATE")
	public Date getSysDate() {
		return this.sysDate;
	}

	public void setSysDate(Date sysDate) {
		this.sysDate = sysDate;
	}

	@Column(name = "SYS_ID")
	public String getSysId() {
		return this.sysId;
	}

	public void setSysId(String sysId) {
		this.sysId = sysId;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "UPD_DATE")
	public Date getUpdDate() {
		return this.updDate;
	}

	public void setUpdDate(Date updDate) {
		this.updDate = updDate;
	}

	@Column(name = "UPD_ID")
	public String getUpdId() {
		return this.updId;
	}

	public void setUpdId(String updId) {
		this.updId = updId;
	}

}