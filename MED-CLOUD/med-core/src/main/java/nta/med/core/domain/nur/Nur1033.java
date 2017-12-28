package nta.med.core.domain.nur;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the NUR1033 database table.
 * 
 */
@Entity
@NamedQuery(name="Nur1033.findAll", query="SELECT n FROM Nur1033 n")
public class Nur1033 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String bunho;
	private Date dieDate;
	private String dieReason;
	private String dieTime;
	private String hospCode;
	private String inputId;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Nur1033() {
	}


	public String getBunho() {
		return this.bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="DIE_DATE")
	public Date getDieDate() {
		return this.dieDate;
	}

	public void setDieDate(Date dieDate) {
		this.dieDate = dieDate;
	}


	@Column(name="DIE_REASON")
	public String getDieReason() {
		return this.dieReason;
	}

	public void setDieReason(String dieReason) {
		this.dieReason = dieReason;
	}


	@Column(name="DIE_TIME")
	public String getDieTime() {
		return this.dieTime;
	}

	public void setDieTime(String dieTime) {
		this.dieTime = dieTime;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="INPUT_ID")
	public String getInputId() {
		return this.inputId;
	}

	public void setInputId(String inputId) {
		this.inputId = inputId;
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