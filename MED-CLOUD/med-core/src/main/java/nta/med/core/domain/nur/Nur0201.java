package nta.med.core.domain.nur;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the NUR0201 database table.
 * 
 */
@Entity
@NamedQuery(name="Nur0201.findAll", query="SELECT n FROM Nur0201 n")
public class Nur0201 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String hospCode;
	private String memb;
	private Date phsFromDate;
	private double phsNumber;
	private Date phsToDate;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Nur0201() {
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	public String getMemb() {
		return this.memb;
	}

	public void setMemb(String memb) {
		this.memb = memb;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="PHS_FROM_DATE")
	public Date getPhsFromDate() {
		return this.phsFromDate;
	}

	public void setPhsFromDate(Date phsFromDate) {
		this.phsFromDate = phsFromDate;
	}


	@Column(name="PHS_NUMBER")
	public double getPhsNumber() {
		return this.phsNumber;
	}

	public void setPhsNumber(double phsNumber) {
		this.phsNumber = phsNumber;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="PHS_TO_DATE")
	public Date getPhsToDate() {
		return this.phsToDate;
	}

	public void setPhsToDate(Date phsToDate) {
		this.phsToDate = phsToDate;
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