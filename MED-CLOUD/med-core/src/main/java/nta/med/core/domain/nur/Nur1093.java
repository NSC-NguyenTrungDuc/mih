package nta.med.core.domain.nur;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;

/**
 * The persistent class for the NUR1093 database table.
 * 
 */
@Entity
@Table(name = "NUR1093")
public class Nur1093 extends BaseEntity {
	private static final long serialVersionUID = 1L;

	private String bedDisplayYn;
	private String code;
	private String codeCmt;
	private String codeName;
	private Date fromDate;
	private Double fromScore;
	private String hospCode;
	private Double sortSeq;
	private Date sysDate;
	private String sysId;
	private Date toDate;
	private Double toScore;
	private Date updDate;
	private String updId;

	public Nur1093() {
	}

	@Column(name = "BED_DISPLAY_YN")
	public String getBedDisplayYn() {
		return this.bedDisplayYn;
	}

	public void setBedDisplayYn(String bedDisplayYn) {
		this.bedDisplayYn = bedDisplayYn;
	}

	public String getCode() {
		return this.code;
	}

	public void setCode(String code) {
		this.code = code;
	}

	@Column(name = "CODE_CMT")
	public String getCodeCmt() {
		return this.codeCmt;
	}

	public void setCodeCmt(String codeCmt) {
		this.codeCmt = codeCmt;
	}

	@Column(name = "CODE_NAME")
	public String getCodeName() {
		return this.codeName;
	}

	public void setCodeName(String codeName) {
		this.codeName = codeName;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "FROM_DATE")
	public Date getFromDate() {
		return this.fromDate;
	}

	public void setFromDate(Date fromDate) {
		this.fromDate = fromDate;
	}

	@Column(name = "FROM_SCORE")
	public Double getFromScore() {
		return this.fromScore;
	}

	public void setFromScore(Double fromScore) {
		this.fromScore = fromScore;
	}

	@Column(name = "HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}

	@Column(name = "SORT_SEQ")
	public Double getSortSeq() {
		return this.sortSeq;
	}

	public void setSortSeq(Double sortSeq) {
		this.sortSeq = sortSeq;
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
	@Column(name = "TO_DATE")
	public Date getToDate() {
		return this.toDate;
	}

	public void setToDate(Date toDate) {
		this.toDate = toDate;
	}

	@Column(name = "TO_SCORE")
	public Double getToScore() {
		return this.toScore;
	}

	public void setToScore(Double toScore) {
		this.toScore = toScore;
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