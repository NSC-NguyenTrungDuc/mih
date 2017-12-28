package nta.med.core.domain.ocs;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;

import javax.persistence.*;

import java.util.Date;


/**
 * The persistent class for the OCS0313 database table.
 * 
 */
@Entity
//@NamedQuery(name="Ocs0313.findAll", query="SELECT o FROM Ocs0313 o")
@Table(name="OCS0313")
public class Ocs0313 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String danui;
	private String defaultCheck;
	private String hangmogCode;
	private String hospCode;
	private String setCode;
	private String setHangmogCode;
	private String setPart;
	private Double suryang;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Ocs0313() {
	}


	public String getDanui() {
		return this.danui;
	}

	public void setDanui(String danui) {
		this.danui = danui;
	}


	@Column(name="DEFAULT_CHECK")
	public String getDefaultCheck() {
		return this.defaultCheck;
	}

	public void setDefaultCheck(String defaultCheck) {
		this.defaultCheck = defaultCheck;
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


	@Column(name="SET_CODE")
	public String getSetCode() {
		return this.setCode;
	}

	public void setSetCode(String setCode) {
		this.setCode = setCode;
	}


	@Column(name="SET_HANGMOG_CODE")
	public String getSetHangmogCode() {
		return this.setHangmogCode;
	}

	public void setSetHangmogCode(String setHangmogCode) {
		this.setHangmogCode = setHangmogCode;
	}


	@Column(name="SET_PART")
	public String getSetPart() {
		return this.setPart;
	}

	public void setSetPart(String setPart) {
		this.setPart = setPart;
	}


	public Double getSuryang() {
		return this.suryang;
	}

	public void setSuryang(Double suryang) {
		this.suryang = suryang;
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