package nta.med.core.domain.ocs;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;

/**
 * The persistent class for the OCS0503 database table.
 * 
 */
@Entity
@Table(name = "OCS0503")
public class Ocs0503 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String ampmGubun;
	private String answer;
	private String answerEndYn;
	private Date appDate;
	private String bunho;
	private String confirmYn;
	private String consultDoctor;
	private Double consultFkout1001;
	private String consultGwa;
	private String consultSangName;
	private String displayYn;
	private String emerGubun;
	private Double fkinp1001;
	private String hospCode;
	private String inOutGubun;
	private Date jinryoPreDate;
	private Double pkocs0503;
	private String printYn;
	private Date realJinryoDate;
	private Date reqDate;
	private String reqDoctor;
	private String reqEndYn;
	private String reqGwa;
	private String reqRemark;
	private String reserTime;
	private Date resultArriveDate;
	private String sangCode1;
	private String sangCode2;
	private String sangCode3;
	private String sangName1;
	private String sangName2;
	private String sangName3;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;
	private String wangjinYn;
	private Double fkocs1003;

	public Ocs0503() {
	}

	@Column(name = "AMPM_GUBUN")
	public String getAmpmGubun() {
		return this.ampmGubun;
	}

	public void setAmpmGubun(String ampmGubun) {
		this.ampmGubun = ampmGubun;
	}

	@Column(name = "ANSWER")
	public String getAnswer() {
		return this.answer;
	}

	public void setAnswer(String answer) {
		this.answer = answer;
	}

	@Column(name = "ANSWER_END_YN")
	public String getAnswerEndYn() {
		return this.answerEndYn;
	}

	public void setAnswerEndYn(String answerEndYn) {
		this.answerEndYn = answerEndYn;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "APP_DATE")
	public Date getAppDate() {
		return this.appDate;
	}

	public void setAppDate(Date appDate) {
		this.appDate = appDate;
	}

	@Column(name = "BUNHO")
	public String getBunho() {
		return this.bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}

	@Column(name = "CONFIRM_YN")
	public String getConfirmYn() {
		return this.confirmYn;
	}

	public void setConfirmYn(String confirmYn) {
		this.confirmYn = confirmYn;
	}

	@Column(name = "CONSULT_DOCTOR")
	public String getConsultDoctor() {
		return this.consultDoctor;
	}

	public void setConsultDoctor(String consultDoctor) {
		this.consultDoctor = consultDoctor;
	}

	@Column(name = "CONSULT_FKOUT1001")
	public Double getConsultFkout1001() {
		return this.consultFkout1001;
	}

	public void setConsultFkout1001(Double consultFkout1001) {
		this.consultFkout1001 = consultFkout1001;
	}

	@Column(name = "CONSULT_GWA")
	public String getConsultGwa() {
		return this.consultGwa;
	}

	public void setConsultGwa(String consultGwa) {
		this.consultGwa = consultGwa;
	}

	@Column(name = "CONSULT_SANG_NAME")
	public String getConsultSangName() {
		return this.consultSangName;
	}

	public void setConsultSangName(String consultSangName) {
		this.consultSangName = consultSangName;
	}

	@Column(name = "DISPLAY_YN")
	public String getDisplayYn() {
		return this.displayYn;
	}

	public void setDisplayYn(String displayYn) {
		this.displayYn = displayYn;
	}

	@Column(name = "EMER_GUBUN")
	public String getEmerGubun() {
		return this.emerGubun;
	}

	public void setEmerGubun(String emerGubun) {
		this.emerGubun = emerGubun;
	}

	@Column(name = "FKINP1001")
	public Double getFkinp1001() {
		return this.fkinp1001;
	}

	public void setFkinp1001(Double fkinp1001) {
		this.fkinp1001 = fkinp1001;
	}

	@Column(name = "HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}

	@Column(name = "IN_OUT_GUBUN")
	public String getInOutGubun() {
		return this.inOutGubun;
	}

	public void setInOutGubun(String inOutGubun) {
		this.inOutGubun = inOutGubun;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "JINRYO_PRE_DATE")
	public Date getJinryoPreDate() {
		return this.jinryoPreDate;
	}

	public void setJinryoPreDate(Date jinryoPreDate) {
		this.jinryoPreDate = jinryoPreDate;
	}

	@Column(name = "PKOCS0503")
	public Double getPkocs0503() {
		return this.pkocs0503;
	}

	public void setPkocs0503(Double pkocs0503) {
		this.pkocs0503 = pkocs0503;
	}

	@Column(name = "PRINT_YN")
	public String getPrintYn() {
		return this.printYn;
	}

	public void setPrintYn(String printYn) {
		this.printYn = printYn;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "REAL_JINRYO_DATE")
	public Date getRealJinryoDate() {
		return this.realJinryoDate;
	}

	public void setRealJinryoDate(Date realJinryoDate) {
		this.realJinryoDate = realJinryoDate;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "REQ_DATE")
	public Date getReqDate() {
		return this.reqDate;
	}

	public void setReqDate(Date reqDate) {
		this.reqDate = reqDate;
	}

	@Column(name = "REQ_DOCTOR")
	public String getReqDoctor() {
		return this.reqDoctor;
	}

	public void setReqDoctor(String reqDoctor) {
		this.reqDoctor = reqDoctor;
	}

	@Column(name = "REQ_END_YN")
	public String getReqEndYn() {
		return this.reqEndYn;
	}

	public void setReqEndYn(String reqEndYn) {
		this.reqEndYn = reqEndYn;
	}

	@Column(name = "REQ_GWA")
	public String getReqGwa() {
		return this.reqGwa;
	}

	public void setReqGwa(String reqGwa) {
		this.reqGwa = reqGwa;
	}

	@Column(name = "REQ_REMARK")
	public String getReqRemark() {
		return this.reqRemark;
	}

	public void setReqRemark(String reqRemark) {
		this.reqRemark = reqRemark;
	}

	@Column(name = "RESER_TIME")
	public String getReserTime() {
		return this.reserTime;
	}

	public void setReserTime(String reserTime) {
		this.reserTime = reserTime;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "RESULT_ARRIVE_DATE")
	public Date getResultArriveDate() {
		return this.resultArriveDate;
	}

	public void setResultArriveDate(Date resultArriveDate) {
		this.resultArriveDate = resultArriveDate;
	}

	@Column(name = "SANG_CODE1")
	public String getSangCode1() {
		return this.sangCode1;
	}

	public void setSangCode1(String sangCode1) {
		this.sangCode1 = sangCode1;
	}

	@Column(name = "SANG_CODE2")
	public String getSangCode2() {
		return this.sangCode2;
	}

	public void setSangCode2(String sangCode2) {
		this.sangCode2 = sangCode2;
	}

	@Column(name = "SANG_CODE3")
	public String getSangCode3() {
		return this.sangCode3;
	}

	public void setSangCode3(String sangCode3) {
		this.sangCode3 = sangCode3;
	}

	@Column(name = "SANG_NAME1")
	public String getSangName1() {
		return this.sangName1;
	}

	public void setSangName1(String sangName1) {
		this.sangName1 = sangName1;
	}

	@Column(name = "SANG_NAME2")
	public String getSangName2() {
		return this.sangName2;
	}

	public void setSangName2(String sangName2) {
		this.sangName2 = sangName2;
	}

	@Column(name = "SANG_NAME3")
	public String getSangName3() {
		return this.sangName3;
	}

	public void setSangName3(String sangName3) {
		this.sangName3 = sangName3;
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

	@Column(name = "WANGJIN_YN")
	public String getWangjinYn() {
		return this.wangjinYn;
	}

	public void setWangjinYn(String wangjinYn) {
		this.wangjinYn = wangjinYn;
	}

	@Column(name = "FKOCS1003")
	public Double getFkocs1003() {
		return fkocs1003;
	}

	public void setFkocs1003(Double fkocs1003) {
		this.fkocs1003 = fkocs1003;
	}

}