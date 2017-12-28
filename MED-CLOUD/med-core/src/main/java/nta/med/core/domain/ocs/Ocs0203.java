package nta.med.core.domain.ocs;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;


/**
 * The persistent class for the OCS0203 database table.
 * 
 */
@Entity
@Table(name="OCS0203")
public class Ocs0203 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String displayYn;
	private String displayYnInp;
	private String hangmogCode;
	private String hospCode;
	private String memb;
	private double oftenSeq;
	private String oftenUse;
	private String position;
	private double seq;
	private String slipCode;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Ocs0203() {
	}


	@Column(name="DISPLAY_YN")
	public String getDisplayYn() {
		return this.displayYn;
	}

	public void setDisplayYn(String displayYn) {
		this.displayYn = displayYn;
	}


	@Column(name="DISPLAY_YN_INP")
	public String getDisplayYnInp() {
		return this.displayYnInp;
	}

	public void setDisplayYnInp(String displayYnInp) {
		this.displayYnInp = displayYnInp;
	}


	@Column(name="HANGMOG_CODE")
	public String getHangmogCode() {
		return this.hangmogCode;
	}

	public void setHangmogCode(String hangmogCode) {
		this.hangmogCode = hangmogCode;
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


	@Column(name="OFTEN_SEQ")
	public double getOftenSeq() {
		return this.oftenSeq;
	}

	public void setOftenSeq(double oftenSeq) {
		this.oftenSeq = oftenSeq;
	}


	@Column(name="OFTEN_USE")
	public String getOftenUse() {
		return this.oftenUse;
	}

	public void setOftenUse(String oftenUse) {
		this.oftenUse = oftenUse;
	}


	public String getPosition() {
		return this.position;
	}

	public void setPosition(String position) {
		this.position = position;
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