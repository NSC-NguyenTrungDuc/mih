package nta.med.core.domain.xrt;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;

import javax.persistence.*;

import java.util.Date;


/**
 * The persistent class for the XRT0122 database table.
 * 
 */
@Entity
@Table(name="XRT0122")
public class Xrt0122 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String buwiBunryu;
	private String buwiCode;
	private String buwiName;
	private String hospCode;
	private String kaikeiYn;
	private double sortSeq;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;
	private String workGubun;
	private String language;

	public Xrt0122() {
	}

	@Column(name="LANGUAGE")
	public String getLanguage() {
		return this.language;
	}
	
	public void setLanguage(String language) {
		this.language = language;
	}

	@Column(name="BUWI_BUNRYU")
	public String getBuwiBunryu() {
		return this.buwiBunryu;
	}

	public void setBuwiBunryu(String buwiBunryu) {
		this.buwiBunryu = buwiBunryu;
	}


	@Column(name="BUWI_CODE")
	public String getBuwiCode() {
		return this.buwiCode;
	}

	public void setBuwiCode(String buwiCode) {
		this.buwiCode = buwiCode;
	}


	@Column(name="BUWI_NAME")
	public String getBuwiName() {
		return this.buwiName;
	}

	public void setBuwiName(String buwiName) {
		this.buwiName = buwiName;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="KAIKEI_YN")
	public String getKaikeiYn() {
		return this.kaikeiYn;
	}

	public void setKaikeiYn(String kaikeiYn) {
		this.kaikeiYn = kaikeiYn;
	}


	@Column(name="SORT_SEQ")
	public double getSortSeq() {
		return this.sortSeq;
	}

	public void setSortSeq(double sortSeq) {
		this.sortSeq = sortSeq;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="SYS_DATE")
	public Date getSysDate() {
		return this.sysDate;
	}

	public void setSysDate(Date sysDate) {
		this.sysDate = sysDate;
	}


	@Column(name="SYS_ID")
	public String getSysId() {
		return this.sysId;
	}

	public void setSysId(String sysId) {
		this.sysId = sysId;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="UPD_DATE")
	public Date getUpdDate() {
		return this.updDate;
	}

	public void setUpdDate(Date updDate) {
		this.updDate = updDate;
	}


	@Column(name="UPD_ID")
	public String getUpdId() {
		return this.updId;
	}

	public void setUpdId(String updId) {
		this.updId = updId;
	}


	@Column(name="WORK_GUBUN")
	public String getWorkGubun() {
		return this.workGubun;
	}

	public void setWorkGubun(String workGubun) {
		this.workGubun = workGubun;
	}

}