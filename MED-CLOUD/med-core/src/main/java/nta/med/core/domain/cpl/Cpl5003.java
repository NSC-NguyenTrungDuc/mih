package nta.med.core.domain.cpl;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the CPL5003 database table.
 * 
 */
@Entity
@NamedQuery(name="Cpl5003.findAll", query="SELECT c FROM Cpl5003 c")
public class Cpl5003 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private Date confirmDate;
	private String confirmTime;
	private String cplResult;
	private String emergency;
	private double fkcpl2010;
	private double fkcpl3020;
	private String hangmogCode;
	private String hospCode;
	private String specimenCode;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Cpl5003() {
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="CONFIRM_DATE")
	public Date getConfirmDate() {
		return this.confirmDate;
	}

	public void setConfirmDate(Date confirmDate) {
		this.confirmDate = confirmDate;
	}


	@Column(name="CONFIRM_TIME")
	public String getConfirmTime() {
		return this.confirmTime;
	}

	public void setConfirmTime(String confirmTime) {
		this.confirmTime = confirmTime;
	}


	@Column(name="CPL_RESULT")
	public String getCplResult() {
		return this.cplResult;
	}

	public void setCplResult(String cplResult) {
		this.cplResult = cplResult;
	}


	public String getEmergency() {
		return this.emergency;
	}

	public void setEmergency(String emergency) {
		this.emergency = emergency;
	}


	public double getFkcpl2010() {
		return this.fkcpl2010;
	}

	public void setFkcpl2010(double fkcpl2010) {
		this.fkcpl2010 = fkcpl2010;
	}


	public double getFkcpl3020() {
		return this.fkcpl3020;
	}

	public void setFkcpl3020(double fkcpl3020) {
		this.fkcpl3020 = fkcpl3020;
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