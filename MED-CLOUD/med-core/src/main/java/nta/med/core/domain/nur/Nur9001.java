package nta.med.core.domain.nur;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;

/**
 * The persistent class for the NUR9001 database table.
 * 
 */
@Entity
@Table(name = "NUR9001")
public class Nur9001 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String bunho;
	private String dcUser;
	private String dcYn;
	private Double fkinp1001;
	private Double fknur4001;
	private String hospCode;
	private String mayakUseYn;
	private String nurPlanJin;
	private Double pknur9001;
	private String recordContents;
	private Date recordDate;
	private String recordTime;
	private String recordUser;
	private String soapGubun;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;
	private String vald;

	public Nur9001() {
	}

	public String getBunho() {
		return this.bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}

	@Column(name = "DC_USER")
	public String getDcUser() {
		return this.dcUser;
	}

	public void setDcUser(String dcUser) {
		this.dcUser = dcUser;
	}

	@Column(name = "DC_YN")
	public String getDcYn() {
		return this.dcYn;
	}

	public void setDcYn(String dcYn) {
		this.dcYn = dcYn;
	}

	public Double getFkinp1001() {
		return this.fkinp1001;
	}

	public void setFkinp1001(Double fkinp1001) {
		this.fkinp1001 = fkinp1001;
	}

	public Double getFknur4001() {
		return this.fknur4001;
	}

	public void setFknur4001(Double fknur4001) {
		this.fknur4001 = fknur4001;
	}

	@Column(name = "HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}

	@Column(name = "MAYAK_USE_YN")
	public String getMayakUseYn() {
		return this.mayakUseYn;
	}

	public void setMayakUseYn(String mayakUseYn) {
		this.mayakUseYn = mayakUseYn;
	}

	@Column(name = "NUR_PLAN_JIN")
	public String getNurPlanJin() {
		return this.nurPlanJin;
	}

	public void setNurPlanJin(String nurPlanJin) {
		this.nurPlanJin = nurPlanJin;
	}

	public Double getPknur9001() {
		return this.pknur9001;
	}

	public void setPknur9001(Double pknur9001) {
		this.pknur9001 = pknur9001;
	}

	@Column(name = "RECORD_CONTENTS")
	public String getRecordContents() {
		return this.recordContents;
	}

	public void setRecordContents(String recordContents) {
		this.recordContents = recordContents;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "RECORD_DATE")
	public Date getRecordDate() {
		return this.recordDate;
	}

	public void setRecordDate(Date recordDate) {
		this.recordDate = recordDate;
	}

	@Column(name = "RECORD_TIME")
	public String getRecordTime() {
		return this.recordTime;
	}

	public void setRecordTime(String recordTime) {
		this.recordTime = recordTime;
	}

	@Column(name = "RECORD_USER")
	public String getRecordUser() {
		return this.recordUser;
	}

	public void setRecordUser(String recordUser) {
		this.recordUser = recordUser;
	}

	@Column(name = "SOAP_GUBUN")
	public String getSoapGubun() {
		return this.soapGubun;
	}

	public void setSoapGubun(String soapGubun) {
		this.soapGubun = soapGubun;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "SYS_DATE")
	public Date getSysDate() {
		return this.sysDate;
	}

	public void setSysDate(Date sysDate) {
		this.sysDate = sysDate;
	}

	@Column(name = "SYS_ID")
	public String getSysId() {
		return this.sysId;
	}

	public void setSysId(String sysId) {
		this.sysId = sysId;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "UPD_DATE")
	public Date getUpdDate() {
		return this.updDate;
	}

	public void setUpdDate(Date updDate) {
		this.updDate = updDate;
	}

	@Column(name = "UPD_ID")
	public String getUpdId() {
		return this.updId;
	}

	public void setUpdId(String updId) {
		this.updId = updId;
	}

	public String getVald() {
		return this.vald;
	}

	public void setVald(String vald) {
		this.vald = vald;
	}

}