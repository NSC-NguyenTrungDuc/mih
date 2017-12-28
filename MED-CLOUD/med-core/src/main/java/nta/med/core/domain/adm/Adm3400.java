package nta.med.core.domain.adm;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.NamedQuery;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;


/**
 * The persistent class for the ADM3400 database table.
 * 
 */
@Entity
@NamedQuery(name="Adm3400.findAll", query="SELECT a FROM Adm3400 a")
@Table(name="ADM3400")
public class Adm3400 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private Date entrTime;
	private String hospCode;
	private String ipAddr;
	private String sysId;
	private String trmId;
	private String userId;

	public Adm3400() {
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="ENTR_TIME")
	public Date getEntrTime() {
		return this.entrTime;
	}

	public void setEntrTime(Date entrTime) {
		this.entrTime = entrTime;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="IP_ADDR")
	public String getIpAddr() {
		return this.ipAddr;
	}

	public void setIpAddr(String ipAddr) {
		this.ipAddr = ipAddr;
	}


	@Column(name="SYS_ID")
	public String getSysId() {
		return this.sysId;
	}

	public void setSysId(String sysId) {
		this.sysId = sysId;
	}


	@Column(name="TRM_ID")
	public String getTrmId() {
		return this.trmId;
	}

	public void setTrmId(String trmId) {
		this.trmId = trmId;
	}


	@Column(name="USER_ID")
	public String getUserId() {
		return this.userId;
	}

	public void setUserId(String userId) {
		this.userId = userId;
	}

}