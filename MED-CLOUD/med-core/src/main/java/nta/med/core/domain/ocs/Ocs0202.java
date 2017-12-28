package nta.med.core.domain.ocs;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.NamedQuery;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;


/**
 * The persistent class for the OCS0202 database table.
 * 
 */
@Entity
@NamedQuery(name="Ocs0202.findAll", query="SELECT o FROM Ocs0202 o")
public class Ocs0202 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String displayYn;
	private String hospCode;
	private String memb;
	private double seq;
	private String slipCode;
	private String slipGubun;
	private String slipType;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Ocs0202() {
	}


	@Column(name="DISPLAY_YN")
	public String getDisplayYn() {
		return this.displayYn;
	}

	public void setDisplayYn(String displayYn) {
		this.displayYn = displayYn;
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


	@Column(name="SLIP_GUBUN")
	public String getSlipGubun() {
		return this.slipGubun;
	}

	public void setSlipGubun(String slipGubun) {
		this.slipGubun = slipGubun;
	}


	@Column(name="SLIP_TYPE")
	public String getSlipType() {
		return this.slipType;
	}

	public void setSlipType(String slipType) {
		this.slipType = slipType;
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