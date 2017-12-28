package nta.med.core.domain.ocs;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.NamedQuery;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;


/**
 * The persistent class for the OCS0106 database table.
 * 
 */
@Entity
@NamedQuery(name="Ocs0106.findAll", query="SELECT o FROM Ocs0106 o")
public class Ocs0106 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String defaultYn;
	private double seq;
	private String slipCode;
	private String specimenCode;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Ocs0106() {
	}


	@Column(name="DEFAULT_YN")
	public String getDefaultYn() {
		return this.defaultYn;
	}

	public void setDefaultYn(String defaultYn) {
		this.defaultYn = defaultYn;
	}

	
	public double getSeq() {
		return this.seq;
	}

	public void setSeq(double seq) {
		this.seq = seq;
	}


	@Column(name="SLIP_CODE")
	public String getSlipCode() {
		return this.slipCode;
	}

	public void setSlipCode(String slipCode) {
		this.slipCode = slipCode;
	}


	@Column(name="SPECIMEN_CODE")
	public String getSpecimenCode() {
		return this.specimenCode;
	}

	public void setSpecimenCode(String specimenCode) {
		this.specimenCode = specimenCode;
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