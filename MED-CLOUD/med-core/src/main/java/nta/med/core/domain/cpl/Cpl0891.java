package nta.med.core.domain.cpl;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the CPL0891 database table.
 * 
 */
@Entity
@NamedQuery(name="Cpl0891.findAll", query="SELECT c FROM Cpl0891 c")
public class Cpl0891 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String danui;
	private String emergency;
	private String fromStandard;
	private String hangmogCode;
	private String hospCode;
	private String jangbiCode;
	private String patientId;
	private Date procDate;
	private String procFlag;
	private String procLog;
	private String procTime;
	private String resultCode;
	private Date resultDate;
	private String resultTime;
	private String resultVal;
	private String sampleId;
	private String specimenSer;
	private Date sysDate;
	private String sysId;
	private String toStandard;
	private Date updDate;
	private String updId;

	public Cpl0891() {
	}


	public String getDanui() {
		return this.danui;
	}

	public void setDanui(String danui) {
		this.danui = danui;
	}


	public String getEmergency() {
		return this.emergency;
	}

	public void setEmergency(String emergency) {
		this.emergency = emergency;
	}


	@Column(name="FROM_STANDARD")
	public String getFromStandard() {
		return this.fromStandard;
	}

	public void setFromStandard(String fromStandard) {
		this.fromStandard = fromStandard;
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


	@Column(name="JANGBI_CODE")
	public String getJangbiCode() {
		return this.jangbiCode;
	}

	public void setJangbiCode(String jangbiCode) {
		this.jangbiCode = jangbiCode;
	}


	@Column(name="PATIENT_ID")
	public String getPatientId() {
		return this.patientId;
	}

	public void setPatientId(String patientId) {
		this.patientId = patientId;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="PROC_DATE")
	public Date getProcDate() {
		return this.procDate;
	}

	public void setProcDate(Date procDate) {
		this.procDate = procDate;
	}


	@Column(name="PROC_FLAG")
	public String getProcFlag() {
		return this.procFlag;
	}

	public void setProcFlag(String procFlag) {
		this.procFlag = procFlag;
	}


	@Column(name="PROC_LOG")
	public String getProcLog() {
		return this.procLog;
	}

	public void setProcLog(String procLog) {
		this.procLog = procLog;
	}


	@Column(name="PROC_TIME")
	public String getProcTime() {
		return this.procTime;
	}

	public void setProcTime(String procTime) {
		this.procTime = procTime;
	}


	@Column(name="RESULT_CODE")
	public String getResultCode() {
		return this.resultCode;
	}

	public void setResultCode(String resultCode) {
		this.resultCode = resultCode;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="RESULT_DATE")
	public Date getResultDate() {
		return this.resultDate;
	}

	public void setResultDate(Date resultDate) {
		this.resultDate = resultDate;
	}


	@Column(name="RESULT_TIME")
	public String getResultTime() {
		return this.resultTime;
	}

	public void setResultTime(String resultTime) {
		this.resultTime = resultTime;
	}


	@Column(name="RESULT_VAL")
	public String getResultVal() {
		return this.resultVal;
	}

	public void setResultVal(String resultVal) {
		this.resultVal = resultVal;
	}


	@Column(name="SAMPLE_ID")
	public String getSampleId() {
		return this.sampleId;
	}

	public void setSampleId(String sampleId) {
		this.sampleId = sampleId;
	}


	@Column(name="SPECIMEN_SER")
	public String getSpecimenSer() {
		return this.specimenSer;
	}

	public void setSpecimenSer(String specimenSer) {
		this.specimenSer = specimenSer;
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


	@Column(name="TO_STANDARD")
	public String getToStandard() {
		return this.toStandard;
	}

	public void setToStandard(String toStandard) {
		this.toStandard = toStandard;
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