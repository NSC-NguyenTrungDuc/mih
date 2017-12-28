package nta.med.core.domain.ocs;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the OCS0803 database table.
 * 
 */
@Entity
//@NamedQuery(name="Ocs0803.findAll", query="SELECT o FROM Ocs0803 o")
@Table(name="OCS0803")
public class Ocs0803 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String hospCode;
	private String ment;
	private String patStatusGr;
	private String patStatusGrName;
	private Double seq;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;
	private String language;

	public Ocs0803() {
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	public String getMent() {
		return this.ment;
	}

	public void setMent(String ment) {
		this.ment = ment;
	}


	@Column(name="PAT_STATUS_GR")
	public String getPatStatusGr() {
		return this.patStatusGr;
	}

	public void setPatStatusGr(String patStatusGr) {
		this.patStatusGr = patStatusGr;
	}


	@Column(name="PAT_STATUS_GR_NAME")
	public String getPatStatusGrName() {
		return this.patStatusGrName;
	}

	public void setPatStatusGrName(String patStatusGrName) {
		this.patStatusGrName = patStatusGrName;
	}


	public Double getSeq() {
		return this.seq;
	}

	public void setSeq(Double seq) {
		this.seq = seq;
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