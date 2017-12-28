package nta.med.core.domain.nur;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;


/**
 * The persistent class for the NUR0105 database table.
 * 
 */
@Entity
@Table(name = "NUR0105")
public class Nur0105 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String hospCode;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;
	private String vspatnGubun;
	private String vspatnTime;

	public Nur0105() {
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
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


	@Column(name="VSPATN_GUBUN")
	public String getVspatnGubun() {
		return this.vspatnGubun;
	}

	public void setVspatnGubun(String vspatnGubun) {
		this.vspatnGubun = vspatnGubun;
	}


	@Column(name="VSPATN_TIME")
	public String getVspatnTime() {
		return this.vspatnTime;
	}

	public void setVspatnTime(String vspatnTime) {
		this.vspatnTime = vspatnTime;
	}

}