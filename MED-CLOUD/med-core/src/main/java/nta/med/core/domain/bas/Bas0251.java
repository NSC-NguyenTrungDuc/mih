package nta.med.core.domain.bas;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;

/**
 * The persistent class for the BAS0251 database table.
 * 
 */
@Entity
@Table(name = "BAS0251")
public class Bas0251 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private Date endDate;
	private Double hoAmt;
	private String hoGrade;
	private String hoGradeName;
	private String hospCode;
	private Date startDate;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Bas0251() {
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "END_DATE")
	public Date getEndDate() {
		return this.endDate;
	}

	public void setEndDate(Date endDate) {
		this.endDate = endDate;
	}

	@Column(name = "HO_AMT")
	public Double getHoAmt() {
		return this.hoAmt;
	}

	public void setHoAmt(Double hoAmt) {
		this.hoAmt = hoAmt;
	}

	@Column(name = "HO_GRADE")
	public String getHoGrade() {
		return this.hoGrade;
	}

	public void setHoGrade(String hoGrade) {
		this.hoGrade = hoGrade;
	}

	@Column(name = "HO_GRADE_NAME")
	public String getHoGradeName() {
		return this.hoGradeName;
	}

	public void setHoGradeName(String hoGradeName) {
		this.hoGradeName = hoGradeName;
	}

	@Column(name = "HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
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