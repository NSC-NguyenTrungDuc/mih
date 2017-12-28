package nta.med.core.domain.ocs;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;

import javax.persistence.*;

import java.util.Date;


/**
 * The persistent class for the OCS0312 database table.
 * 
 */
@Entity
//@NamedQuery(name="Ocs0312.findAll", query="SELECT o FROM Ocs0312 o")
@Table(name="OCS0312")
public class Ocs0312 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String comments;
	private String hangmogCode;
	private String hospCode;
	private String setCode;
	private String setCodeName;
	private String setPart;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Ocs0312() {
	}


	public String getComments() {
		return this.comments;
	}

	public void setComments(String comments) {
		this.comments = comments;
	}


	@Column(name="HANGMOG_CODE")
	public String getHangmogCode() {
		return this.hangmogCode;
	}

	public void setHangmogCode(String hangmogCode) {
		this.hangmogCode = hangmogCode;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="SET_CODE")
	public String getSetCode() {
		return this.setCode;
	}

	public void setSetCode(String setCode) {
		this.setCode = setCode;
	}


	@Column(name="SET_CODE_NAME")
	public String getSetCodeName() {
		return this.setCodeName;
	}

	public void setSetCodeName(String setCodeName) {
		this.setCodeName = setCodeName;
	}


	@Column(name="SET_PART")
	public String getSetPart() {
		return this.setPart;
	}

	public void setSetPart(String setPart) {
		this.setPart = setPart;
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