package nta.med.core.domain.nur;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the NUR1025 database table.
 * 
 */
@Entity
@NamedQuery(name="Nur1025.findAll", query="SELECT n FROM Nur1025 n")
public class Nur1025 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String bunho;
	private String damdangNurse;
	private String hospCode;
	private double pknur1025;
	private Date stopDate;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Nur1025() {
	}


	public String getBunho() {
		return this.bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}


	@Column(name="DAMDANG_NURSE")
	public String getDamdangNurse() {
		return this.damdangNurse;
	}

	public void setDamdangNurse(String damdangNurse) {
		this.damdangNurse = damdangNurse;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	public double getPknur1025() {
		return this.pknur1025;
	}

	public void setPknur1025(double pknur1025) {
		this.pknur1025 = pknur1025;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="STOP_DATE")
	public Date getStopDate() {
		return this.stopDate;
	}

	public void setStopDate(Date stopDate) {
		this.stopDate = stopDate;
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