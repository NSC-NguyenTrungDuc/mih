package nta.med.core.domain.bas;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.NamedQuery;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;


/**
 * The persistent class for the BAS0240 database table.
 * 
 */
@Entity
@NamedQuery(name="Bas0240.findAll", query="SELECT b FROM Bas0240 b")
public class Bas0240 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String nuCode;
	private String nuCodeName;
	private String nuGubun;
	private Date nuYmd;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Bas0240() {
	}


	@Column(name="NU_CODE")
	public String getNuCode() {
		return this.nuCode;
	}

	public void setNuCode(String nuCode) {
		this.nuCode = nuCode;
	}


	@Column(name="NU_CODE_NAME")
	public String getNuCodeName() {
		return this.nuCodeName;
	}

	public void setNuCodeName(String nuCodeName) {
		this.nuCodeName = nuCodeName;
	}


	@Column(name="NU_GUBUN")
	public String getNuGubun() {
		return this.nuGubun;
	}

	public void setNuGubun(String nuGubun) {
		this.nuGubun = nuGubun;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="NU_YMD")
	public Date getNuYmd() {
		return this.nuYmd;
	}

	public void setNuYmd(Date nuYmd) {
		this.nuYmd = nuYmd;
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