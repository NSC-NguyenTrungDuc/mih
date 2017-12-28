package nta.med.core.domain.inp;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;

/**
 * The persistent class for the INP2004 database table.
 * 
 */
@Entity
@Table(name = "INP2004")
public class Inp2004 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String bunho;
	private String cancelSayu;
	private String cancelYn;
	private Date endDate;
	private Double fkinp1001;
	private String fromBedNo;
	private String fromBedNo2;
	private String fromDoctor;
	private String fromGwa;
	private String fromHoCode1;
	private String fromHoCode2;
	private String fromHoDong1;
	private String fromHoDong2;
	private String fromKaikeiHocode;
	private String fromKaikeiHodong;
	private String fromResident;
	private String hospCode;
	private Date ifDataSendDate;
	private String ifDataSendYn;
	private Date startDate;
	private Date sysDate;
	private String sysId;
	private String toBedNo;
	private String toBedNo2;
	private String toDoctor;
	private String toGwa;
	private String toHoCode1;
	private String toHoCode2;
	private String toHoDong1;
	private String toHoDong2;
	private String toHoGrade1;
	private String toHoGrade2;
	private String toKaikeiHocode;
	private String toKaikeiHodong;
	private Date toNurseConfirmDate;
	private String toNurseConfirmId;
	private String toNurseConfirmTime;
	private String toResident;
	private Date tonggyeDate;
	private Double transCnt;
	private String transGubun;
	private String transTime;
	private Date updDate;
	private String updId;

	public Inp2004() {
	}

	public String getBunho() {
		return this.bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}

	@Column(name = "CANCEL_SAYU")
	public String getCancelSayu() {
		return this.cancelSayu;
	}

	public void setCancelSayu(String cancelSayu) {
		this.cancelSayu = cancelSayu;
	}

	@Column(name = "CANCEL_YN")
	public String getCancelYn() {
		return this.cancelYn;
	}

	public void setCancelYn(String cancelYn) {
		this.cancelYn = cancelYn;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "END_DATE")
	public Date getEndDate() {
		return this.endDate;
	}

	public void setEndDate(Date endDate) {
		this.endDate = endDate;
	}

	public Double getFkinp1001() {
		return this.fkinp1001;
	}

	public void setFkinp1001(Double fkinp1001) {
		this.fkinp1001 = fkinp1001;
	}

	@Column(name = "FROM_BED_NO")
	public String getFromBedNo() {
		return this.fromBedNo;
	}

	public void setFromBedNo(String fromBedNo) {
		this.fromBedNo = fromBedNo;
	}

	@Column(name = "FROM_BED_NO2")
	public String getFromBedNo2() {
		return this.fromBedNo2;
	}

	public void setFromBedNo2(String fromBedNo2) {
		this.fromBedNo2 = fromBedNo2;
	}

	@Column(name = "FROM_DOCTOR")
	public String getFromDoctor() {
		return this.fromDoctor;
	}

	public void setFromDoctor(String fromDoctor) {
		this.fromDoctor = fromDoctor;
	}

	@Column(name = "FROM_GWA")
	public String getFromGwa() {
		return this.fromGwa;
	}

	public void setFromGwa(String fromGwa) {
		this.fromGwa = fromGwa;
	}

	@Column(name = "FROM_HO_CODE1")
	public String getFromHoCode1() {
		return this.fromHoCode1;
	}

	public void setFromHoCode1(String fromHoCode1) {
		this.fromHoCode1 = fromHoCode1;
	}

	@Column(name = "FROM_HO_CODE2")
	public String getFromHoCode2() {
		return this.fromHoCode2;
	}

	public void setFromHoCode2(String fromHoCode2) {
		this.fromHoCode2 = fromHoCode2;
	}

	@Column(name = "FROM_HO_DONG1")
	public String getFromHoDong1() {
		return this.fromHoDong1;
	}

	public void setFromHoDong1(String fromHoDong1) {
		this.fromHoDong1 = fromHoDong1;
	}

	@Column(name = "FROM_HO_DONG2")
	public String getFromHoDong2() {
		return this.fromHoDong2;
	}

	public void setFromHoDong2(String fromHoDong2) {
		this.fromHoDong2 = fromHoDong2;
	}

	@Column(name = "FROM_KAIKEI_HOCODE")
	public String getFromKaikeiHocode() {
		return this.fromKaikeiHocode;
	}

	public void setFromKaikeiHocode(String fromKaikeiHocode) {
		this.fromKaikeiHocode = fromKaikeiHocode;
	}

	@Column(name = "FROM_KAIKEI_HODONG")
	public String getFromKaikeiHodong() {
		return this.fromKaikeiHodong;
	}

	public void setFromKaikeiHodong(String fromKaikeiHodong) {
		this.fromKaikeiHodong = fromKaikeiHodong;
	}

	@Column(name = "FROM_RESIDENT")
	public String getFromResident() {
		return this.fromResident;
	}

	public void setFromResident(String fromResident) {
		this.fromResident = fromResident;
	}

	@Column(name = "HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "IF_DATA_SEND_DATE")
	public Date getIfDataSendDate() {
		return this.ifDataSendDate;
	}

	public void setIfDataSendDate(Date ifDataSendDate) {
		this.ifDataSendDate = ifDataSendDate;
	}

	@Column(name = "IF_DATA_SEND_YN")
	public String getIfDataSendYn() {
		return this.ifDataSendYn;
	}

	public void setIfDataSendYn(String ifDataSendYn) {
		this.ifDataSendYn = ifDataSendYn;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "START_DATE")
	public Date getStartDate() {
		return this.startDate;
	}

	public void setStartDate(Date startDate) {
		this.startDate = startDate;
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

	@Column(name = "TO_BED_NO")
	public String getToBedNo() {
		return this.toBedNo;
	}

	public void setToBedNo(String toBedNo) {
		this.toBedNo = toBedNo;
	}

	@Column(name = "TO_BED_NO2")
	public String getToBedNo2() {
		return this.toBedNo2;
	}

	public void setToBedNo2(String toBedNo2) {
		this.toBedNo2 = toBedNo2;
	}

	@Column(name = "TO_DOCTOR")
	public String getToDoctor() {
		return this.toDoctor;
	}

	public void setToDoctor(String toDoctor) {
		this.toDoctor = toDoctor;
	}

	@Column(name = "TO_GWA")
	public String getToGwa() {
		return this.toGwa;
	}

	public void setToGwa(String toGwa) {
		this.toGwa = toGwa;
	}

	@Column(name = "TO_HO_CODE1")
	public String getToHoCode1() {
		return this.toHoCode1;
	}

	public void setToHoCode1(String toHoCode1) {
		this.toHoCode1 = toHoCode1;
	}

	@Column(name = "TO_HO_CODE2")
	public String getToHoCode2() {
		return this.toHoCode2;
	}

	public void setToHoCode2(String toHoCode2) {
		this.toHoCode2 = toHoCode2;
	}

	@Column(name = "TO_HO_DONG1")
	public String getToHoDong1() {
		return this.toHoDong1;
	}

	public void setToHoDong1(String toHoDong1) {
		this.toHoDong1 = toHoDong1;
	}

	@Column(name = "TO_HO_DONG2")
	public String getToHoDong2() {
		return this.toHoDong2;
	}

	public void setToHoDong2(String toHoDong2) {
		this.toHoDong2 = toHoDong2;
	}

	@Column(name = "TO_HO_GRADE1")
	public String getToHoGrade1() {
		return this.toHoGrade1;
	}

	public void setToHoGrade1(String toHoGrade1) {
		this.toHoGrade1 = toHoGrade1;
	}

	@Column(name = "TO_HO_GRADE2")
	public String getToHoGrade2() {
		return this.toHoGrade2;
	}

	public void setToHoGrade2(String toHoGrade2) {
		this.toHoGrade2 = toHoGrade2;
	}

	@Column(name = "TO_KAIKEI_HOCODE")
	public String getToKaikeiHocode() {
		return this.toKaikeiHocode;
	}

	public void setToKaikeiHocode(String toKaikeiHocode) {
		this.toKaikeiHocode = toKaikeiHocode;
	}

	@Column(name = "TO_KAIKEI_HODONG")
	public String getToKaikeiHodong() {
		return this.toKaikeiHodong;
	}

	public void setToKaikeiHodong(String toKaikeiHodong) {
		this.toKaikeiHodong = toKaikeiHodong;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "TO_NURSE_CONFIRM_DATE")
	public Date getToNurseConfirmDate() {
		return this.toNurseConfirmDate;
	}

	public void setToNurseConfirmDate(Date toNurseConfirmDate) {
		this.toNurseConfirmDate = toNurseConfirmDate;
	}

	@Column(name = "TO_NURSE_CONFIRM_ID")
	public String getToNurseConfirmId() {
		return this.toNurseConfirmId;
	}

	public void setToNurseConfirmId(String toNurseConfirmId) {
		this.toNurseConfirmId = toNurseConfirmId;
	}

	@Column(name = "TO_NURSE_CONFIRM_TIME")
	public String getToNurseConfirmTime() {
		return this.toNurseConfirmTime;
	}

	public void setToNurseConfirmTime(String toNurseConfirmTime) {
		this.toNurseConfirmTime = toNurseConfirmTime;
	}

	@Column(name = "TO_RESIDENT")
	public String getToResident() {
		return this.toResident;
	}

	public void setToResident(String toResident) {
		this.toResident = toResident;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "TONGGYE_DATE")
	public Date getTonggyeDate() {
		return this.tonggyeDate;
	}

	public void setTonggyeDate(Date tonggyeDate) {
		this.tonggyeDate = tonggyeDate;
	}

	@Column(name = "TRANS_CNT")
	public Double getTransCnt() {
		return this.transCnt;
	}

	public void setTransCnt(Double transCnt) {
		this.transCnt = transCnt;
	}

	@Column(name = "TRANS_GUBUN")
	public String getTransGubun() {
		return this.transGubun;
	}

	public void setTransGubun(String transGubun) {
		this.transGubun = transGubun;
	}

	@Column(name = "TRANS_TIME")
	public String getTransTime() {
		return this.transTime;
	}

	public void setTransTime(String transTime) {
		this.transTime = transTime;
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