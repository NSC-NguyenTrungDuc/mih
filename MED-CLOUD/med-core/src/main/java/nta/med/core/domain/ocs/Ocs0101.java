package nta.med.core.domain.ocs;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.NamedQuery;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;


/**
 * The persistent class for the OCS0101 database table.
 * 
 */
@Entity
@Table(name="OCS0101")
public class Ocs0101 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String slipGubun;
	private String slipGubunName;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;
	private String language;

	public Ocs0101() {
	}

	@Column(name="SLIP_GUBUN")
	public String getSlipGubun() {
		return this.slipGubun;
	}

	public void setSlipGubun(String slipGubun) {
		this.slipGubun = slipGubun;
	}


	@Column(name="SLIP_GUBUN_NAME")
	public String getSlipGubunName() {
		return this.slipGubunName;
	}

	public void setSlipGubunName(String slipGubunName) {
		this.slipGubunName = slipGubunName;
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