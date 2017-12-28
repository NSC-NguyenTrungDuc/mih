package nta.med.core.domain.res;

import nta.med.core.domain.BaseEntity;

import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the RES0104 database table.
 * 
 */
@Entity
@Table(name="RES0104")
public class Res0104 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String doctor;
	private Date endDate;
	private Date endYmd;
	private String endYn;
	private String hospCode;
	private String sayu;
	private Date startDate;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Res0104() {
	}


	public String getDoctor() {
		return this.doctor;
	}

	public void setDoctor(String doctor) {
		this.doctor = doctor;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="END_DATE")
	public Date getEndDate() {
		return this.endDate;
	}

	public void setEndDate(Date endDate) {
		this.endDate = endDate;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="END_YMD")
	public Date getEndYmd() {
		return this.endYmd;
	}

	public void setEndYmd(Date endYmd) {
		this.endYmd = endYmd;
	}


	@Column(name="END_YN")
	public String getEndYn() {
		return this.endYn;
	}

	public void setEndYn(String endYn) {
		this.endYn = endYn;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	public String getSayu() {
		return this.sayu;
	}

	public void setSayu(String sayu) {
		this.sayu = sayu;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="START_DATE")
	public Date getStartDate() {
		return this.startDate;
	}

	public void setStartDate(Date startDate) {
		this.startDate = startDate;
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