package nta.med.core.domain.ocs;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the OCS1802 database table.
 * 
 */
@Entity
@NamedQuery(name="Ocs1802.findAll", query="SELECT o FROM Ocs1802 o")
public class Ocs1802 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String bunho;
	private String hospCode;
	private String iudGubun;
	private String newPatStatusCode;
	private String oldPatStatusCode;
	private String patStatus;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;
	private String updTime;

	public Ocs1802() {
	}


	public String getBunho() {
		return this.bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="IUD_GUBUN")
	public String getIudGubun() {
		return this.iudGubun;
	}

	public void setIudGubun(String iudGubun) {
		this.iudGubun = iudGubun;
	}


	@Column(name="NEW_PAT_STATUS_CODE")
	public String getNewPatStatusCode() {
		return this.newPatStatusCode;
	}

	public void setNewPatStatusCode(String newPatStatusCode) {
		this.newPatStatusCode = newPatStatusCode;
	}


	@Column(name="OLD_PAT_STATUS_CODE")
	public String getOldPatStatusCode() {
		return this.oldPatStatusCode;
	}

	public void setOldPatStatusCode(String oldPatStatusCode) {
		this.oldPatStatusCode = oldPatStatusCode;
	}


	@Column(name="PAT_STATUS")
	public String getPatStatus() {
		return this.patStatus;
	}

	public void setPatStatus(String patStatus) {
		this.patStatus = patStatus;
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


	@Column(name="UPD_TIME")
	public String getUpdTime() {
		return this.updTime;
	}

	public void setUpdTime(String updTime) {
		this.updTime = updTime;
	}

}