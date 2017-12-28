package nta.med.core.domain.nur;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the NUR6003 database table.
 * 
 */
@Entity
@NamedQuery(name="Nur6003.findAll", query="SELECT n FROM Nur6003 n")
public class Nur6003 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String bedsoreBuwi;
	private String bedsoreGubun;
	private String bunho;
	private Date fromDate;
	private String hospCode;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Nur6003() {
	}


	@Column(name="BEDSORE_BUWI")
	public String getBedsoreBuwi() {
		return this.bedsoreBuwi;
	}

	public void setBedsoreBuwi(String bedsoreBuwi) {
		this.bedsoreBuwi = bedsoreBuwi;
	}


	@Column(name="BEDSORE_GUBUN")
	public String getBedsoreGubun() {
		return this.bedsoreGubun;
	}

	public void setBedsoreGubun(String bedsoreGubun) {
		this.bedsoreGubun = bedsoreGubun;
	}


	public String getBunho() {
		return this.bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="FROM_DATE")
	public Date getFromDate() {
		return this.fromDate;
	}

	public void setFromDate(Date fromDate) {
		this.fromDate = fromDate;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
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

}