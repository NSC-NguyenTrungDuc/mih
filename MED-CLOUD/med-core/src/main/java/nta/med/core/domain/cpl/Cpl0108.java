package nta.med.core.domain.cpl;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;


/**
 * The persistent class for the CPL0108 database table.
 * 
 */
@Entity
@Table(name = "CPL0108")
public class Cpl0108 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String adminGubun;
	private String codeType;
	private String codeTypeName;
	//private String hospCode;
	private Date sysDate;
	private String sysId;
	private String systemGubun;
	private Date updDate;
	private String updId;
	private String language;
	
	public Cpl0108() {
	}


	@Column(name="ADMIN_GUBUN")
	public String getAdminGubun() {
		return this.adminGubun;
	}

	public void setAdminGubun(String adminGubun) {
		this.adminGubun = adminGubun;
	}


	@Column(name="CODE_TYPE")
	public String getCodeType() {
		return this.codeType;
	}

	public void setCodeType(String codeType) {
		this.codeType = codeType;
	}


	@Column(name="CODE_TYPE_NAME")
	public String getCodeTypeName() {
		return this.codeTypeName;
	}

	public void setCodeTypeName(String codeTypeName) {
		this.codeTypeName = codeTypeName;
	}


/*	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}*/


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


	@Column(name="SYSTEM_GUBUN")
	public String getSystemGubun() {
		return this.systemGubun;
	}

	public void setSystemGubun(String systemGubun) {
		this.systemGubun = systemGubun;
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
	
	@Column(name="LANGUAGE")
	public String getLanguage() {
		return language;
	}

	public void setLanguage(String language) {
		this.language = language;
	}
}