package nta.med.core.domain.nur;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;

/**
 * The persistent class for the NUR5027 database table.
 * 
 */
@Entity
@Table(name = "NUR5027")
public class Nur5027 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private Double absenceCnt;
	private Double childcareCnt;
	private Double dawnCnt;
	private Double dayCnt;
	private String hoDong;
	private Double holiCnt;
	private String hospCode;
	private Double nightCnt;
	private String nurGrade;
	private Date nurWrdt;
	private Double payCnt;
	private Double specialCnt;
	private Double studyCnt;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Nur5027() {
	}

	@Column(name = "ABSENCE_CNT")
	public Double getAbsenceCnt() {
		return this.absenceCnt;
	}

	public void setAbsenceCnt(Double absenceCnt) {
		this.absenceCnt = absenceCnt;
	}

	@Column(name = "CHILDCARE_CNT")
	public Double getChildcareCnt() {
		return this.childcareCnt;
	}

	public void setChildcareCnt(Double childcareCnt) {
		this.childcareCnt = childcareCnt;
	}

	@Column(name = "DAWN_CNT")
	public Double getDawnCnt() {
		return this.dawnCnt;
	}

	public void setDawnCnt(Double dawnCnt) {
		this.dawnCnt = dawnCnt;
	}

	@Column(name = "DAY_CNT")
	public Double getDayCnt() {
		return this.dayCnt;
	}

	public void setDayCnt(Double dayCnt) {
		this.dayCnt = dayCnt;
	}

	@Column(name = "HO_DONG")
	public String getHoDong() {
		return this.hoDong;
	}

	public void setHoDong(String hoDong) {
		this.hoDong = hoDong;
	}

	@Column(name = "HOLI_CNT")
	public Double getHoliCnt() {
		return this.holiCnt;
	}

	public void setHoliCnt(Double holiCnt) {
		this.holiCnt = holiCnt;
	}

	@Column(name = "HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}

	@Column(name = "NIGHT_CNT")
	public Double getNightCnt() {
		return this.nightCnt;
	}

	public void setNightCnt(Double nightCnt) {
		this.nightCnt = nightCnt;
	}

	@Column(name = "NUR_GRADE")
	public String getNurGrade() {
		return this.nurGrade;
	}

	public void setNurGrade(String nurGrade) {
		this.nurGrade = nurGrade;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "NUR_WRDT")
	public Date getNurWrdt() {
		return this.nurWrdt;
	}

	public void setNurWrdt(Date nurWrdt) {
		this.nurWrdt = nurWrdt;
	}

	@Column(name = "PAY_CNT")
	public Double getPayCnt() {
		return this.payCnt;
	}

	public void setPayCnt(Double payCnt) {
		this.payCnt = payCnt;
	}

	@Column(name = "SPECIAL_CNT")
	public Double getSpecialCnt() {
		return this.specialCnt;
	}

	public void setSpecialCnt(Double specialCnt) {
		this.specialCnt = specialCnt;
	}

	@Column(name = "STUDY_CNT")
	public Double getStudyCnt() {
		return this.studyCnt;
	}

	public void setStudyCnt(Double studyCnt) {
		this.studyCnt = studyCnt;
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

}