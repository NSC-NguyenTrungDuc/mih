package nta.med.core.domain.nur;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;

/**
 * The persistent class for the NUR6001 database table.
 * 
 */
@Entity
@Table(name = "NUR6001")
public class Nur6001 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String bedsoreBuwi1;
	private String bedsoreBuwi2;
	private String bedsoreBuwi3;
	private String bedsoreBuwi4;
	private String bedsoreBuwi5;
	private String bedsoreBuwi6;
	private String bunho;
	private Date endDate;
	private Double fkinp1001;
	private Date fromDate;
	private String hospCode;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Nur6001() {
	}

	@Column(name = "BEDSORE_BUWI1")
	public String getBedsoreBuwi1() {
		return this.bedsoreBuwi1;
	}

	public void setBedsoreBuwi1(String bedsoreBuwi1) {
		this.bedsoreBuwi1 = bedsoreBuwi1;
	}

	@Column(name = "BEDSORE_BUWI2")
	public String getBedsoreBuwi2() {
		return this.bedsoreBuwi2;
	}

	public void setBedsoreBuwi2(String bedsoreBuwi2) {
		this.bedsoreBuwi2 = bedsoreBuwi2;
	}

	@Column(name = "BEDSORE_BUWI3")
	public String getBedsoreBuwi3() {
		return this.bedsoreBuwi3;
	}

	public void setBedsoreBuwi3(String bedsoreBuwi3) {
		this.bedsoreBuwi3 = bedsoreBuwi3;
	}

	@Column(name = "BEDSORE_BUWI4")
	public String getBedsoreBuwi4() {
		return this.bedsoreBuwi4;
	}

	public void setBedsoreBuwi4(String bedsoreBuwi4) {
		this.bedsoreBuwi4 = bedsoreBuwi4;
	}

	@Column(name = "BEDSORE_BUWI5")
	public String getBedsoreBuwi5() {
		return this.bedsoreBuwi5;
	}

	public void setBedsoreBuwi5(String bedsoreBuwi5) {
		this.bedsoreBuwi5 = bedsoreBuwi5;
	}

	@Column(name = "BEDSORE_BUWI6")
	public String getBedsoreBuwi6() {
		return this.bedsoreBuwi6;
	}

	public void setBedsoreBuwi6(String bedsoreBuwi6) {
		this.bedsoreBuwi6 = bedsoreBuwi6;
	}

	public String getBunho() {
		return this.bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "END_DATE")
	public Date getEndDate() {
		return this.endDate;
	}

	public void setEndDate(Date endDate) {
		this.endDate = endDate;
	}

	public Double getFkinp1001() {
		return this.fkinp1001;
	}

	public void setFkinp1001(Double fkinp1001) {
		this.fkinp1001 = fkinp1001;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "FROM_DATE")
	public Date getFromDate() {
		return this.fromDate;
	}

	public void setFromDate(Date fromDate) {
		this.fromDate = fromDate;
	}

	@Column(name = "HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
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