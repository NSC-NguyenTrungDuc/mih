package nta.med.core.domain.bas;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;

import javax.persistence.*;

import java.util.Date;


/**
 * The persistent class for the BAS0272 database table.
 * 
 */
@Entity
@Table(name="BAS0272")
public class Bas0272 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String doctor;
	private String doctorGwa;
	private Date endDate;
	private String hospCode;
	private String mainGwaYn;
	private String sabun;
	private Date startDate;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;
	private String outDiscussYn; // OUT_DISCUSS_YN;
	private String reserOutYn; // RESER_OUT_YN;

	public Bas0272() {
	}


	public String getDoctor() {
		return this.doctor;
	}

	public void setDoctor(String doctor) {
		this.doctor = doctor;
	}


	@Column(name="DOCTOR_GWA")
	public String getDoctorGwa() {
		return this.doctorGwa;
	}

	public void setDoctorGwa(String doctorGwa) {
		this.doctorGwa = doctorGwa;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="END_DATE")
	public Date getEndDate() {
		return this.endDate;
	}

	public void setEndDate(Date endDate) {
		this.endDate = endDate;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="MAIN_GWA_YN")
	public String getMainGwaYn() {
		return this.mainGwaYn;
	}

	public void setMainGwaYn(String mainGwaYn) {
		this.mainGwaYn = mainGwaYn;
	}


	public String getSabun() {
		return this.sabun;
	}

	public void setSabun(String sabun) {
		this.sabun = sabun;
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


	@Column(name="OUT_DISCUSS_YN")
	public String getOutDiscussYn() {
		return outDiscussYn;
	}


	public void setOutDiscussYn(String outDiscussYn) {
		this.outDiscussYn = outDiscussYn;
	}


	@Column(name="RESER_OUT_YN")
	public String getReserOutYn() {
		return reserOutYn;
	}


	public void setReserOutYn(String reserOutYn) {
		this.reserOutYn = reserOutYn;
	}
	
	

}