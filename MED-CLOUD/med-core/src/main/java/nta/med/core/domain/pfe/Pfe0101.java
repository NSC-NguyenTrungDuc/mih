package nta.med.core.domain.pfe;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;


/**
 * The persistent class for the PFE0101 database table.
 * 
 */
@Entity
//@NamedQuery(name="Pfe0101.findAll", query="SELECT p FROM Pfe0101 p")
@Table(name="PFE0101")
public class Pfe0101 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String adminGubun;
	private String codeType;
	private String codeTypeName;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;
	private String language;

	public Pfe0101() {
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
	
	@Column(name="LANGUAGE")
	public String getLanguage() {
		return language;
	}

	public void setLanguage(String language) {
		this.language = language;
	}
}