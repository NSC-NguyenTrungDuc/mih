package nta.med.core.domain.ocs;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the OCS0804 database table.
 * 
 */
@Entity
//@NamedQuery(name="Ocs0804.findAll", query="SELECT o FROM Ocs0804 o")
@Table(name="OCS0804")
public class Ocs0804 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String breakPatStatusCode;
	private String hospCode;
	private String indispensableYn;
	private String ment;
	private String patStatus;
	private String patStatusGr;
	private Double seq;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Ocs0804() {
	}


	@Column(name="BREAK_PAT_STATUS_CODE")
	public String getBreakPatStatusCode() {
		return this.breakPatStatusCode;
	}

	public void setBreakPatStatusCode(String breakPatStatusCode) {
		this.breakPatStatusCode = breakPatStatusCode;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="INDISPENSABLE_YN")
	public String getIndispensableYn() {
		return this.indispensableYn;
	}

	public void setIndispensableYn(String indispensableYn) {
		this.indispensableYn = indispensableYn;
	}


	public String getMent() {
		return this.ment;
	}

	public void setMent(String ment) {
		this.ment = ment;
	}


	@Column(name="PAT_STATUS")
	public String getPatStatus() {
		return this.patStatus;
	}

	public void setPatStatus(String patStatus) {
		this.patStatus = patStatus;
	}


	@Column(name="PAT_STATUS_GR")
	public String getPatStatusGr() {
		return this.patStatusGr;
	}

	public void setPatStatusGr(String patStatusGr) {
		this.patStatusGr = patStatusGr;
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

}