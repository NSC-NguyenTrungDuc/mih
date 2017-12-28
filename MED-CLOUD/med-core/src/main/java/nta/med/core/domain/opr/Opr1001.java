package nta.med.core.domain.opr;

import java.math.BigDecimal;
import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;

/**
 * The persistent class for the OPR1001 database table.
 * 
 */
@Entity
@Table(name = "OPR1001")
public class Opr1001 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private BigDecimal age;
	private String ageGubun;
	private String anConfirmRemark;
	private String anConfirmTm;
	private String anConfirmYn;
	private String anDoctorYn;
	private String anDoctor1;
	private String anDoctor2;
	private String anDoctor3;
	private String anDoctor4;
	private Date anFromDate;
	private String anFromTime;
	private String anInputYn;
	private String anMethod;
	private String anMethod1;
	private String anNurse1;
	private String anNurse2;
	private String anNurse3;
	private String anNurse4;
	private Date anToDate;
	private String anToTime;
	private String angioYn;
	private String asaGubun;
	private String assistArrvTm;
	private String banBloodYn;
	private String bansong;
	private Double bloodInYang;
	private Double bloodOutYang;
	private Date bohojaConfirmDate;
	private String bohojaConfirmUser;
	private String bohojaConfirmYn;
	private String bohojaName;
	private String bunho;
	private String chewi;
	private String combineGwa1;
	private String combineGwa2;
	private String directNurse1;
	private String directNurse2;
	private String duration;
	private String eyeLeftRigh;
	private Double fkinp1001;
	private String fkout1001;
	private String gamyumYn;
	private String gubun;
	private String gwa;
	private Date haibokInDt;
	private String haibokInTm;
	private Date haibokOutDt;
	private String haibokOutTm;
	private String haibokYn;
	private Double height;
	private String hoCode;
	private String hoDong;
	private String hospCode;
	private String inOutGubun;
	private Date inputDate;
	private String inputId;
	private String inputTime;
	private String ioGubun;
	private String makingYn;
	private Double nyoYang;
	private String onCallYn;
	private String opAnswer;
	private String opArriveTime;
	private String opCancel;
	private Date opCancelDate;
	private String opCancelDoctor;
	private String opCancelYn;
	private BigDecimal opCnt;
	private String opDoctor;
	private String opDoctor1;
	private String opDoctor2;
	private String opDoctor3;
	private String opDoctor4;
	private String opDoctor5;
	private String opEndYn;
	private String opEquipmntGita1;
	private String opEquipmntGita2;
	private String opEquipmntGita3;
	private String opEquipmntGita4;
	private String opEquipmnt1;
	private String opEquipmnt2;
	private String opEquipmnt3;
	private String opEquipmnt4;
	private Date opFromDate;
	private String opFromTime;
	private String opGubun;
	private String opOutTime;
	private String opPosition;
	private BigDecimal opResSeq;
	private String opReserComments;
	private Date opReserDate;
	private String opReserTime;
	private String opRoom;
	private String opRoomGubun;
	private BigDecimal opSeq;
	private Date opToDate;
	private String opToTime;
	private String outDoctorName1;
	private String outDoctorName2;
	private String outDoctorName3;
	private String painClnYn;
	private String painMethod;
	private String painMethodName;
	private String pca;
	private Date pcaBannabDate;
	private String pcaBannabYn;
	private String pcaNumber;
	private String pcaRemark;
	private String pcaYn;
	private Double pkopr1001;
	private String postOpCode1;
	private String postOpCode2;
	private String postOpCode3;
	private String postOpCode4;
	private String postOpCode5;
	private String postOpName1;
	private String postOpName2;
	private String postOpName3;
	private String postOpRemark;
	private String postSangCode1;
	private String postSangCode2;
	private String postSangCode3;
	private String postSangCode4;
	private String postSangCode5;
	private String postSangName1;
	private String postSangName2;
	private String postSangName3;
	private String preOpCode1;
	private String preOpCode2;
	private String preOpCode3;
	private String preOpCode4;
	private String preOpCode5;
	private String preOpName1;
	private String preOpName2;
	private String preOpName3;
	private String preSangCode1;
	private String preSangCode2;
	private String preSangCode3;
	private String preSangCode4;
	private String preSangCode5;
	private String preSangName1;
	private String preSangName2;
	private String preSangName3;
	private String reOp;
	private String reOpYn;
	private String sex;
	private String sexGubun;
	private String sodokNurse1;
	private String sodokNurse2;
	private String sodokNurse3;
	private String sodokNurse4;
	private String staffArrvTm;
	private String suname;
	private String sunhoanNurse1;
	private String sunhoanNurse2;
	private String sunhoanNurse3;
	private String sunhoanNurse4;
	private String support;
	private String support2;
	private String support3;
	private String surgeonConfirmYn;
	private String susulBuwi;
	private Double suyakYang;
	private String symya;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;
	private Double weight;
	private String zipCode1;
	private String zipCode2;

	public Opr1001() {
	}

	public BigDecimal getAge() {
		return this.age;
	}

	public void setAge(BigDecimal age) {
		this.age = age;
	}

	@Column(name = "AGE_GUBUN")
	public String getAgeGubun() {
		return this.ageGubun;
	}

	public void setAgeGubun(String ageGubun) {
		this.ageGubun = ageGubun;
	}

	@Column(name = "AN_CONFIRM_REMARK")
	public String getAnConfirmRemark() {
		return this.anConfirmRemark;
	}

	public void setAnConfirmRemark(String anConfirmRemark) {
		this.anConfirmRemark = anConfirmRemark;
	}

	@Column(name = "AN_CONFIRM_TM")
	public String getAnConfirmTm() {
		return this.anConfirmTm;
	}

	public void setAnConfirmTm(String anConfirmTm) {
		this.anConfirmTm = anConfirmTm;
	}

	@Column(name = "AN_CONFIRM_YN")
	public String getAnConfirmYn() {
		return this.anConfirmYn;
	}

	public void setAnConfirmYn(String anConfirmYn) {
		this.anConfirmYn = anConfirmYn;
	}

	@Column(name = "AN_DOCTOR_YN")
	public String getAnDoctorYn() {
		return this.anDoctorYn;
	}

	public void setAnDoctorYn(String anDoctorYn) {
		this.anDoctorYn = anDoctorYn;
	}

	@Column(name = "AN_DOCTOR1")
	public String getAnDoctor1() {
		return this.anDoctor1;
	}

	public void setAnDoctor1(String anDoctor1) {
		this.anDoctor1 = anDoctor1;
	}

	@Column(name = "AN_DOCTOR2")
	public String getAnDoctor2() {
		return this.anDoctor2;
	}

	public void setAnDoctor2(String anDoctor2) {
		this.anDoctor2 = anDoctor2;
	}

	@Column(name = "AN_DOCTOR3")
	public String getAnDoctor3() {
		return this.anDoctor3;
	}

	public void setAnDoctor3(String anDoctor3) {
		this.anDoctor3 = anDoctor3;
	}

	@Column(name = "AN_DOCTOR4")
	public String getAnDoctor4() {
		return this.anDoctor4;
	}

	public void setAnDoctor4(String anDoctor4) {
		this.anDoctor4 = anDoctor4;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "AN_FROM_DATE")
	public Date getAnFromDate() {
		return this.anFromDate;
	}

	public void setAnFromDate(Date anFromDate) {
		this.anFromDate = anFromDate;
	}

	@Column(name = "AN_FROM_TIME")
	public String getAnFromTime() {
		return this.anFromTime;
	}

	public void setAnFromTime(String anFromTime) {
		this.anFromTime = anFromTime;
	}

	@Column(name = "AN_INPUT_YN")
	public String getAnInputYn() {
		return this.anInputYn;
	}

	public void setAnInputYn(String anInputYn) {
		this.anInputYn = anInputYn;
	}

	@Column(name = "AN_METHOD")
	public String getAnMethod() {
		return this.anMethod;
	}

	public void setAnMethod(String anMethod) {
		this.anMethod = anMethod;
	}

	@Column(name = "AN_METHOD1")
	public String getAnMethod1() {
		return this.anMethod1;
	}

	public void setAnMethod1(String anMethod1) {
		this.anMethod1 = anMethod1;
	}

	@Column(name = "AN_NURSE1")
	public String getAnNurse1() {
		return this.anNurse1;
	}

	public void setAnNurse1(String anNurse1) {
		this.anNurse1 = anNurse1;
	}

	@Column(name = "AN_NURSE2")
	public String getAnNurse2() {
		return this.anNurse2;
	}

	public void setAnNurse2(String anNurse2) {
		this.anNurse2 = anNurse2;
	}

	@Column(name = "AN_NURSE3")
	public String getAnNurse3() {
		return this.anNurse3;
	}

	public void setAnNurse3(String anNurse3) {
		this.anNurse3 = anNurse3;
	}

	@Column(name = "AN_NURSE4")
	public String getAnNurse4() {
		return this.anNurse4;
	}

	public void setAnNurse4(String anNurse4) {
		this.anNurse4 = anNurse4;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "AN_TO_DATE")
	public Date getAnToDate() {
		return this.anToDate;
	}

	public void setAnToDate(Date anToDate) {
		this.anToDate = anToDate;
	}

	@Column(name = "AN_TO_TIME")
	public String getAnToTime() {
		return this.anToTime;
	}

	public void setAnToTime(String anToTime) {
		this.anToTime = anToTime;
	}

	@Column(name = "ANGIO_YN")
	public String getAngioYn() {
		return this.angioYn;
	}

	public void setAngioYn(String angioYn) {
		this.angioYn = angioYn;
	}

	@Column(name = "ASA_GUBUN")
	public String getAsaGubun() {
		return this.asaGubun;
	}

	public void setAsaGubun(String asaGubun) {
		this.asaGubun = asaGubun;
	}

	@Column(name = "ASSIST_ARRV_TM")
	public String getAssistArrvTm() {
		return this.assistArrvTm;
	}

	public void setAssistArrvTm(String assistArrvTm) {
		this.assistArrvTm = assistArrvTm;
	}

	@Column(name = "BAN_BLOOD_YN")
	public String getBanBloodYn() {
		return this.banBloodYn;
	}

	public void setBanBloodYn(String banBloodYn) {
		this.banBloodYn = banBloodYn;
	}

	public String getBansong() {
		return this.bansong;
	}

	public void setBansong(String bansong) {
		this.bansong = bansong;
	}

	@Column(name = "BLOOD_IN_YANG")
	public Double getBloodInYang() {
		return this.bloodInYang;
	}

	public void setBloodInYang(Double bloodInYang) {
		this.bloodInYang = bloodInYang;
	}

	@Column(name = "BLOOD_OUT_YANG")
	public Double getBloodOutYang() {
		return this.bloodOutYang;
	}

	public void setBloodOutYang(Double bloodOutYang) {
		this.bloodOutYang = bloodOutYang;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "BOHOJA_CONFIRM_DATE")
	public Date getBohojaConfirmDate() {
		return this.bohojaConfirmDate;
	}

	public void setBohojaConfirmDate(Date bohojaConfirmDate) {
		this.bohojaConfirmDate = bohojaConfirmDate;
	}

	@Column(name = "BOHOJA_CONFIRM_USER")
	public String getBohojaConfirmUser() {
		return this.bohojaConfirmUser;
	}

	public void setBohojaConfirmUser(String bohojaConfirmUser) {
		this.bohojaConfirmUser = bohojaConfirmUser;
	}

	@Column(name = "BOHOJA_CONFIRM_YN")
	public String getBohojaConfirmYn() {
		return this.bohojaConfirmYn;
	}

	public void setBohojaConfirmYn(String bohojaConfirmYn) {
		this.bohojaConfirmYn = bohojaConfirmYn;
	}

	@Column(name = "BOHOJA_NAME")
	public String getBohojaName() {
		return this.bohojaName;
	}

	public void setBohojaName(String bohojaName) {
		this.bohojaName = bohojaName;
	}

	public String getBunho() {
		return this.bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}

	public String getChewi() {
		return this.chewi;
	}

	public void setChewi(String chewi) {
		this.chewi = chewi;
	}

	@Column(name = "COMBINE_GWA1")
	public String getCombineGwa1() {
		return this.combineGwa1;
	}

	public void setCombineGwa1(String combineGwa1) {
		this.combineGwa1 = combineGwa1;
	}

	@Column(name = "COMBINE_GWA2")
	public String getCombineGwa2() {
		return this.combineGwa2;
	}

	public void setCombineGwa2(String combineGwa2) {
		this.combineGwa2 = combineGwa2;
	}

	@Column(name = "DIRECT_NURSE1")
	public String getDirectNurse1() {
		return this.directNurse1;
	}

	public void setDirectNurse1(String directNurse1) {
		this.directNurse1 = directNurse1;
	}

	@Column(name = "DIRECT_NURSE2")
	public String getDirectNurse2() {
		return this.directNurse2;
	}

	public void setDirectNurse2(String directNurse2) {
		this.directNurse2 = directNurse2;
	}

	public String getDuration() {
		return this.duration;
	}

	public void setDuration(String duration) {
		this.duration = duration;
	}

	@Column(name = "EYE_LEFT_RIGH")
	public String getEyeLeftRigh() {
		return this.eyeLeftRigh;
	}

	public void setEyeLeftRigh(String eyeLeftRigh) {
		this.eyeLeftRigh = eyeLeftRigh;
	}

	public Double getFkinp1001() {
		return this.fkinp1001;
	}

	public void setFkinp1001(Double fkinp1001) {
		this.fkinp1001 = fkinp1001;
	}

	public String getFkout1001() {
		return this.fkout1001;
	}

	public void setFkout1001(String fkout1001) {
		this.fkout1001 = fkout1001;
	}

	@Column(name = "GAMYUM_YN")
	public String getGamyumYn() {
		return this.gamyumYn;
	}

	public void setGamyumYn(String gamyumYn) {
		this.gamyumYn = gamyumYn;
	}

	public String getGubun() {
		return this.gubun;
	}

	public void setGubun(String gubun) {
		this.gubun = gubun;
	}

	public String getGwa() {
		return this.gwa;
	}

	public void setGwa(String gwa) {
		this.gwa = gwa;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "HAIBOK_IN_DT")
	public Date getHaibokInDt() {
		return this.haibokInDt;
	}

	public void setHaibokInDt(Date haibokInDt) {
		this.haibokInDt = haibokInDt;
	}

	@Column(name = "HAIBOK_IN_TM")
	public String getHaibokInTm() {
		return this.haibokInTm;
	}

	public void setHaibokInTm(String haibokInTm) {
		this.haibokInTm = haibokInTm;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "HAIBOK_OUT_DT")
	public Date getHaibokOutDt() {
		return this.haibokOutDt;
	}

	public void setHaibokOutDt(Date haibokOutDt) {
		this.haibokOutDt = haibokOutDt;
	}

	@Column(name = "HAIBOK_OUT_TM")
	public String getHaibokOutTm() {
		return this.haibokOutTm;
	}

	public void setHaibokOutTm(String haibokOutTm) {
		this.haibokOutTm = haibokOutTm;
	}

	@Column(name = "HAIBOK_YN")
	public String getHaibokYn() {
		return this.haibokYn;
	}

	public void setHaibokYn(String haibokYn) {
		this.haibokYn = haibokYn;
	}

	public Double getHeight() {
		return this.height;
	}

	public void setHeight(Double height) {
		this.height = height;
	}

	@Column(name = "HO_CODE")
	public String getHoCode() {
		return this.hoCode;
	}

	public void setHoCode(String hoCode) {
		this.hoCode = hoCode;
	}

	@Column(name = "HO_DONG")
	public String getHoDong() {
		return this.hoDong;
	}

	public void setHoDong(String hoDong) {
		this.hoDong = hoDong;
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
	@Column(name = "INPUT_DATE")
	public Date getInputDate() {
		return this.inputDate;
	}

	public void setInputDate(Date inputDate) {
		this.inputDate = inputDate;
	}

	@Column(name = "INPUT_ID")
	public String getInputId() {
		return this.inputId;
	}

	public void setInputId(String inputId) {
		this.inputId = inputId;
	}

	@Column(name = "INPUT_TIME")
	public String getInputTime() {
		return this.inputTime;
	}

	public void setInputTime(String inputTime) {
		this.inputTime = inputTime;
	}

	@Column(name = "IO_GUBUN")
	public String getIoGubun() {
		return this.ioGubun;
	}

	public void setIoGubun(String ioGubun) {
		this.ioGubun = ioGubun;
	}

	@Column(name = "MAKING_YN")
	public String getMakingYn() {
		return this.makingYn;
	}

	public void setMakingYn(String makingYn) {
		this.makingYn = makingYn;
	}

	@Column(name = "NYO_YANG")
	public Double getNyoYang() {
		return this.nyoYang;
	}

	public void setNyoYang(Double nyoYang) {
		this.nyoYang = nyoYang;
	}

	@Column(name = "ON_CALL_YN")
	public String getOnCallYn() {
		return this.onCallYn;
	}

	public void setOnCallYn(String onCallYn) {
		this.onCallYn = onCallYn;
	}

	@Column(name = "OP_ANSWER")
	public String getOpAnswer() {
		return this.opAnswer;
	}

	public void setOpAnswer(String opAnswer) {
		this.opAnswer = opAnswer;
	}

	@Column(name = "OP_ARRIVE_TIME")
	public String getOpArriveTime() {
		return this.opArriveTime;
	}

	public void setOpArriveTime(String opArriveTime) {
		this.opArriveTime = opArriveTime;
	}

	@Column(name = "OP_CANCEL")
	public String getOpCancel() {
		return this.opCancel;
	}

	public void setOpCancel(String opCancel) {
		this.opCancel = opCancel;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "OP_CANCEL_DATE")
	public Date getOpCancelDate() {
		return this.opCancelDate;
	}

	public void setOpCancelDate(Date opCancelDate) {
		this.opCancelDate = opCancelDate;
	}

	@Column(name = "OP_CANCEL_DOCTOR")
	public String getOpCancelDoctor() {
		return this.opCancelDoctor;
	}

	public void setOpCancelDoctor(String opCancelDoctor) {
		this.opCancelDoctor = opCancelDoctor;
	}

	@Column(name = "OP_CANCEL_YN")
	public String getOpCancelYn() {
		return this.opCancelYn;
	}

	public void setOpCancelYn(String opCancelYn) {
		this.opCancelYn = opCancelYn;
	}

	@Column(name = "OP_CNT")
	public BigDecimal getOpCnt() {
		return this.opCnt;
	}

	public void setOpCnt(BigDecimal opCnt) {
		this.opCnt = opCnt;
	}

	@Column(name = "OP_DOCTOR")
	public String getOpDoctor() {
		return this.opDoctor;
	}

	public void setOpDoctor(String opDoctor) {
		this.opDoctor = opDoctor;
	}

	@Column(name = "OP_DOCTOR1")
	public String getOpDoctor1() {
		return this.opDoctor1;
	}

	public void setOpDoctor1(String opDoctor1) {
		this.opDoctor1 = opDoctor1;
	}

	@Column(name = "OP_DOCTOR2")
	public String getOpDoctor2() {
		return this.opDoctor2;
	}

	public void setOpDoctor2(String opDoctor2) {
		this.opDoctor2 = opDoctor2;
	}

	@Column(name = "OP_DOCTOR3")
	public String getOpDoctor3() {
		return this.opDoctor3;
	}

	public void setOpDoctor3(String opDoctor3) {
		this.opDoctor3 = opDoctor3;
	}

	@Column(name = "OP_DOCTOR4")
	public String getOpDoctor4() {
		return this.opDoctor4;
	}

	public void setOpDoctor4(String opDoctor4) {
		this.opDoctor4 = opDoctor4;
	}

	@Column(name = "OP_DOCTOR5")
	public String getOpDoctor5() {
		return this.opDoctor5;
	}

	public void setOpDoctor5(String opDoctor5) {
		this.opDoctor5 = opDoctor5;
	}

	@Column(name = "OP_END_YN")
	public String getOpEndYn() {
		return this.opEndYn;
	}

	public void setOpEndYn(String opEndYn) {
		this.opEndYn = opEndYn;
	}

	@Column(name = "OP_EQUIPMNT_GITA1")
	public String getOpEquipmntGita1() {
		return this.opEquipmntGita1;
	}

	public void setOpEquipmntGita1(String opEquipmntGita1) {
		this.opEquipmntGita1 = opEquipmntGita1;
	}

	@Column(name = "OP_EQUIPMNT_GITA2")
	public String getOpEquipmntGita2() {
		return this.opEquipmntGita2;
	}

	public void setOpEquipmntGita2(String opEquipmntGita2) {
		this.opEquipmntGita2 = opEquipmntGita2;
	}

	@Column(name = "OP_EQUIPMNT_GITA3")
	public String getOpEquipmntGita3() {
		return this.opEquipmntGita3;
	}

	public void setOpEquipmntGita3(String opEquipmntGita3) {
		this.opEquipmntGita3 = opEquipmntGita3;
	}

	@Column(name = "OP_EQUIPMNT_GITA4")
	public String getOpEquipmntGita4() {
		return this.opEquipmntGita4;
	}

	public void setOpEquipmntGita4(String opEquipmntGita4) {
		this.opEquipmntGita4 = opEquipmntGita4;
	}

	@Column(name = "OP_EQUIPMNT1")
	public String getOpEquipmnt1() {
		return this.opEquipmnt1;
	}

	public void setOpEquipmnt1(String opEquipmnt1) {
		this.opEquipmnt1 = opEquipmnt1;
	}

	@Column(name = "OP_EQUIPMNT2")
	public String getOpEquipmnt2() {
		return this.opEquipmnt2;
	}

	public void setOpEquipmnt2(String opEquipmnt2) {
		this.opEquipmnt2 = opEquipmnt2;
	}

	@Column(name = "OP_EQUIPMNT3")
	public String getOpEquipmnt3() {
		return this.opEquipmnt3;
	}

	public void setOpEquipmnt3(String opEquipmnt3) {
		this.opEquipmnt3 = opEquipmnt3;
	}

	@Column(name = "OP_EQUIPMNT4")
	public String getOpEquipmnt4() {
		return this.opEquipmnt4;
	}

	public void setOpEquipmnt4(String opEquipmnt4) {
		this.opEquipmnt4 = opEquipmnt4;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "OP_FROM_DATE")
	public Date getOpFromDate() {
		return this.opFromDate;
	}

	public void setOpFromDate(Date opFromDate) {
		this.opFromDate = opFromDate;
	}

	@Column(name = "OP_FROM_TIME")
	public String getOpFromTime() {
		return this.opFromTime;
	}

	public void setOpFromTime(String opFromTime) {
		this.opFromTime = opFromTime;
	}

	@Column(name = "OP_GUBUN")
	public String getOpGubun() {
		return this.opGubun;
	}

	public void setOpGubun(String opGubun) {
		this.opGubun = opGubun;
	}

	@Column(name = "OP_OUT_TIME")
	public String getOpOutTime() {
		return this.opOutTime;
	}

	public void setOpOutTime(String opOutTime) {
		this.opOutTime = opOutTime;
	}

	@Column(name = "OP_POSITION")
	public String getOpPosition() {
		return this.opPosition;
	}

	public void setOpPosition(String opPosition) {
		this.opPosition = opPosition;
	}

	@Column(name = "OP_RES_SEQ")
	public BigDecimal getOpResSeq() {
		return this.opResSeq;
	}

	public void setOpResSeq(BigDecimal opResSeq) {
		this.opResSeq = opResSeq;
	}

	@Column(name = "OP_RESER_COMMENTS")
	public String getOpReserComments() {
		return this.opReserComments;
	}

	public void setOpReserComments(String opReserComments) {
		this.opReserComments = opReserComments;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "OP_RESER_DATE")
	public Date getOpReserDate() {
		return this.opReserDate;
	}

	public void setOpReserDate(Date opReserDate) {
		this.opReserDate = opReserDate;
	}

	@Column(name = "OP_RESER_TIME")
	public String getOpReserTime() {
		return this.opReserTime;
	}

	public void setOpReserTime(String opReserTime) {
		this.opReserTime = opReserTime;
	}

	@Column(name = "OP_ROOM")
	public String getOpRoom() {
		return this.opRoom;
	}

	public void setOpRoom(String opRoom) {
		this.opRoom = opRoom;
	}

	@Column(name = "OP_ROOM_GUBUN")
	public String getOpRoomGubun() {
		return this.opRoomGubun;
	}

	public void setOpRoomGubun(String opRoomGubun) {
		this.opRoomGubun = opRoomGubun;
	}

	@Column(name = "OP_SEQ")
	public BigDecimal getOpSeq() {
		return this.opSeq;
	}

	public void setOpSeq(BigDecimal opSeq) {
		this.opSeq = opSeq;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "OP_TO_DATE")
	public Date getOpToDate() {
		return this.opToDate;
	}

	public void setOpToDate(Date opToDate) {
		this.opToDate = opToDate;
	}

	@Column(name = "OP_TO_TIME")
	public String getOpToTime() {
		return this.opToTime;
	}

	public void setOpToTime(String opToTime) {
		this.opToTime = opToTime;
	}

	@Column(name = "OUT_DOCTOR_NAME1")
	public String getOutDoctorName1() {
		return this.outDoctorName1;
	}

	public void setOutDoctorName1(String outDoctorName1) {
		this.outDoctorName1 = outDoctorName1;
	}

	@Column(name = "OUT_DOCTOR_NAME2")
	public String getOutDoctorName2() {
		return this.outDoctorName2;
	}

	public void setOutDoctorName2(String outDoctorName2) {
		this.outDoctorName2 = outDoctorName2;
	}

	@Column(name = "OUT_DOCTOR_NAME3")
	public String getOutDoctorName3() {
		return this.outDoctorName3;
	}

	public void setOutDoctorName3(String outDoctorName3) {
		this.outDoctorName3 = outDoctorName3;
	}

	@Column(name = "PAIN_CLN_YN")
	public String getPainClnYn() {
		return this.painClnYn;
	}

	public void setPainClnYn(String painClnYn) {
		this.painClnYn = painClnYn;
	}

	@Column(name = "PAIN_METHOD")
	public String getPainMethod() {
		return this.painMethod;
	}

	public void setPainMethod(String painMethod) {
		this.painMethod = painMethod;
	}

	@Column(name = "PAIN_METHOD_NAME")
	public String getPainMethodName() {
		return this.painMethodName;
	}

	public void setPainMethodName(String painMethodName) {
		this.painMethodName = painMethodName;
	}

	public String getPca() {
		return this.pca;
	}

	public void setPca(String pca) {
		this.pca = pca;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "PCA_BANNAB_DATE")
	public Date getPcaBannabDate() {
		return this.pcaBannabDate;
	}

	public void setPcaBannabDate(Date pcaBannabDate) {
		this.pcaBannabDate = pcaBannabDate;
	}

	@Column(name = "PCA_BANNAB_YN")
	public String getPcaBannabYn() {
		return this.pcaBannabYn;
	}

	public void setPcaBannabYn(String pcaBannabYn) {
		this.pcaBannabYn = pcaBannabYn;
	}

	@Column(name = "PCA_NUMBER")
	public String getPcaNumber() {
		return this.pcaNumber;
	}

	public void setPcaNumber(String pcaNumber) {
		this.pcaNumber = pcaNumber;
	}

	@Column(name = "PCA_REMARK")
	public String getPcaRemark() {
		return this.pcaRemark;
	}

	public void setPcaRemark(String pcaRemark) {
		this.pcaRemark = pcaRemark;
	}

	@Column(name = "PCA_YN")
	public String getPcaYn() {
		return this.pcaYn;
	}

	public void setPcaYn(String pcaYn) {
		this.pcaYn = pcaYn;
	}

	public Double getPkopr1001() {
		return this.pkopr1001;
	}

	public void setPkopr1001(Double pkopr1001) {
		this.pkopr1001 = pkopr1001;
	}

	@Column(name = "POST_OP_CODE1")
	public String getPostOpCode1() {
		return this.postOpCode1;
	}

	public void setPostOpCode1(String postOpCode1) {
		this.postOpCode1 = postOpCode1;
	}

	@Column(name = "POST_OP_CODE2")
	public String getPostOpCode2() {
		return this.postOpCode2;
	}

	public void setPostOpCode2(String postOpCode2) {
		this.postOpCode2 = postOpCode2;
	}

	@Column(name = "POST_OP_CODE3")
	public String getPostOpCode3() {
		return this.postOpCode3;
	}

	public void setPostOpCode3(String postOpCode3) {
		this.postOpCode3 = postOpCode3;
	}

	@Column(name = "POST_OP_CODE4")
	public String getPostOpCode4() {
		return this.postOpCode4;
	}

	public void setPostOpCode4(String postOpCode4) {
		this.postOpCode4 = postOpCode4;
	}

	@Column(name = "POST_OP_CODE5")
	public String getPostOpCode5() {
		return this.postOpCode5;
	}

	public void setPostOpCode5(String postOpCode5) {
		this.postOpCode5 = postOpCode5;
	}

	@Column(name = "POST_OP_NAME1")
	public String getPostOpName1() {
		return this.postOpName1;
	}

	public void setPostOpName1(String postOpName1) {
		this.postOpName1 = postOpName1;
	}

	@Column(name = "POST_OP_NAME2")
	public String getPostOpName2() {
		return this.postOpName2;
	}

	public void setPostOpName2(String postOpName2) {
		this.postOpName2 = postOpName2;
	}

	@Column(name = "POST_OP_NAME3")
	public String getPostOpName3() {
		return this.postOpName3;
	}

	public void setPostOpName3(String postOpName3) {
		this.postOpName3 = postOpName3;
	}

	@Column(name = "POST_OP_REMARK")
	public String getPostOpRemark() {
		return this.postOpRemark;
	}

	public void setPostOpRemark(String postOpRemark) {
		this.postOpRemark = postOpRemark;
	}

	@Column(name = "POST_SANG_CODE1")
	public String getPostSangCode1() {
		return this.postSangCode1;
	}

	public void setPostSangCode1(String postSangCode1) {
		this.postSangCode1 = postSangCode1;
	}

	@Column(name = "POST_SANG_CODE2")
	public String getPostSangCode2() {
		return this.postSangCode2;
	}

	public void setPostSangCode2(String postSangCode2) {
		this.postSangCode2 = postSangCode2;
	}

	@Column(name = "POST_SANG_CODE3")
	public String getPostSangCode3() {
		return this.postSangCode3;
	}

	public void setPostSangCode3(String postSangCode3) {
		this.postSangCode3 = postSangCode3;
	}

	@Column(name = "POST_SANG_CODE4")
	public String getPostSangCode4() {
		return this.postSangCode4;
	}

	public void setPostSangCode4(String postSangCode4) {
		this.postSangCode4 = postSangCode4;
	}

	@Column(name = "POST_SANG_CODE5")
	public String getPostSangCode5() {
		return this.postSangCode5;
	}

	public void setPostSangCode5(String postSangCode5) {
		this.postSangCode5 = postSangCode5;
	}

	@Column(name = "POST_SANG_NAME1")
	public String getPostSangName1() {
		return this.postSangName1;
	}

	public void setPostSangName1(String postSangName1) {
		this.postSangName1 = postSangName1;
	}

	@Column(name = "POST_SANG_NAME2")
	public String getPostSangName2() {
		return this.postSangName2;
	}

	public void setPostSangName2(String postSangName2) {
		this.postSangName2 = postSangName2;
	}

	@Column(name = "POST_SANG_NAME3")
	public String getPostSangName3() {
		return this.postSangName3;
	}

	public void setPostSangName3(String postSangName3) {
		this.postSangName3 = postSangName3;
	}

	@Column(name = "PRE_OP_CODE1")
	public String getPreOpCode1() {
		return this.preOpCode1;
	}

	public void setPreOpCode1(String preOpCode1) {
		this.preOpCode1 = preOpCode1;
	}

	@Column(name = "PRE_OP_CODE2")
	public String getPreOpCode2() {
		return this.preOpCode2;
	}

	public void setPreOpCode2(String preOpCode2) {
		this.preOpCode2 = preOpCode2;
	}

	@Column(name = "PRE_OP_CODE3")
	public String getPreOpCode3() {
		return this.preOpCode3;
	}

	public void setPreOpCode3(String preOpCode3) {
		this.preOpCode3 = preOpCode3;
	}

	@Column(name = "PRE_OP_CODE4")
	public String getPreOpCode4() {
		return this.preOpCode4;
	}

	public void setPreOpCode4(String preOpCode4) {
		this.preOpCode4 = preOpCode4;
	}

	@Column(name = "PRE_OP_CODE5")
	public String getPreOpCode5() {
		return this.preOpCode5;
	}

	public void setPreOpCode5(String preOpCode5) {
		this.preOpCode5 = preOpCode5;
	}

	@Column(name = "PRE_OP_NAME1")
	public String getPreOpName1() {
		return this.preOpName1;
	}

	public void setPreOpName1(String preOpName1) {
		this.preOpName1 = preOpName1;
	}

	@Column(name = "PRE_OP_NAME2")
	public String getPreOpName2() {
		return this.preOpName2;
	}

	public void setPreOpName2(String preOpName2) {
		this.preOpName2 = preOpName2;
	}

	@Column(name = "PRE_OP_NAME3")
	public String getPreOpName3() {
		return this.preOpName3;
	}

	public void setPreOpName3(String preOpName3) {
		this.preOpName3 = preOpName3;
	}

	@Column(name = "PRE_SANG_CODE1")
	public String getPreSangCode1() {
		return this.preSangCode1;
	}

	public void setPreSangCode1(String preSangCode1) {
		this.preSangCode1 = preSangCode1;
	}

	@Column(name = "PRE_SANG_CODE2")
	public String getPreSangCode2() {
		return this.preSangCode2;
	}

	public void setPreSangCode2(String preSangCode2) {
		this.preSangCode2 = preSangCode2;
	}

	@Column(name = "PRE_SANG_CODE3")
	public String getPreSangCode3() {
		return this.preSangCode3;
	}

	public void setPreSangCode3(String preSangCode3) {
		this.preSangCode3 = preSangCode3;
	}

	@Column(name = "PRE_SANG_CODE4")
	public String getPreSangCode4() {
		return this.preSangCode4;
	}

	public void setPreSangCode4(String preSangCode4) {
		this.preSangCode4 = preSangCode4;
	}

	@Column(name = "PRE_SANG_CODE5")
	public String getPreSangCode5() {
		return this.preSangCode5;
	}

	public void setPreSangCode5(String preSangCode5) {
		this.preSangCode5 = preSangCode5;
	}

	@Column(name = "PRE_SANG_NAME1")
	public String getPreSangName1() {
		return this.preSangName1;
	}

	public void setPreSangName1(String preSangName1) {
		this.preSangName1 = preSangName1;
	}

	@Column(name = "PRE_SANG_NAME2")
	public String getPreSangName2() {
		return this.preSangName2;
	}

	public void setPreSangName2(String preSangName2) {
		this.preSangName2 = preSangName2;
	}

	@Column(name = "PRE_SANG_NAME3")
	public String getPreSangName3() {
		return this.preSangName3;
	}

	public void setPreSangName3(String preSangName3) {
		this.preSangName3 = preSangName3;
	}

	@Column(name = "RE_OP")
	public String getReOp() {
		return this.reOp;
	}

	public void setReOp(String reOp) {
		this.reOp = reOp;
	}

	@Column(name = "RE_OP_YN")
	public String getReOpYn() {
		return this.reOpYn;
	}

	public void setReOpYn(String reOpYn) {
		this.reOpYn = reOpYn;
	}

	public String getSex() {
		return this.sex;
	}

	public void setSex(String sex) {
		this.sex = sex;
	}

	@Column(name = "SEX_GUBUN")
	public String getSexGubun() {
		return this.sexGubun;
	}

	public void setSexGubun(String sexGubun) {
		this.sexGubun = sexGubun;
	}

	@Column(name = "SODOK_NURSE1")
	public String getSodokNurse1() {
		return this.sodokNurse1;
	}

	public void setSodokNurse1(String sodokNurse1) {
		this.sodokNurse1 = sodokNurse1;
	}

	@Column(name = "SODOK_NURSE2")
	public String getSodokNurse2() {
		return this.sodokNurse2;
	}

	public void setSodokNurse2(String sodokNurse2) {
		this.sodokNurse2 = sodokNurse2;
	}

	@Column(name = "SODOK_NURSE3")
	public String getSodokNurse3() {
		return this.sodokNurse3;
	}

	public void setSodokNurse3(String sodokNurse3) {
		this.sodokNurse3 = sodokNurse3;
	}

	@Column(name = "SODOK_NURSE4")
	public String getSodokNurse4() {
		return this.sodokNurse4;
	}

	public void setSodokNurse4(String sodokNurse4) {
		this.sodokNurse4 = sodokNurse4;
	}

	@Column(name = "STAFF_ARRV_TM")
	public String getStaffArrvTm() {
		return this.staffArrvTm;
	}

	public void setStaffArrvTm(String staffArrvTm) {
		this.staffArrvTm = staffArrvTm;
	}

	public String getSuname() {
		return this.suname;
	}

	public void setSuname(String suname) {
		this.suname = suname;
	}

	@Column(name = "SUNHOAN_NURSE1")
	public String getSunhoanNurse1() {
		return this.sunhoanNurse1;
	}

	public void setSunhoanNurse1(String sunhoanNurse1) {
		this.sunhoanNurse1 = sunhoanNurse1;
	}

	@Column(name = "SUNHOAN_NURSE2")
	public String getSunhoanNurse2() {
		return this.sunhoanNurse2;
	}

	public void setSunhoanNurse2(String sunhoanNurse2) {
		this.sunhoanNurse2 = sunhoanNurse2;
	}

	@Column(name = "SUNHOAN_NURSE3")
	public String getSunhoanNurse3() {
		return this.sunhoanNurse3;
	}

	public void setSunhoanNurse3(String sunhoanNurse3) {
		this.sunhoanNurse3 = sunhoanNurse3;
	}

	@Column(name = "SUNHOAN_NURSE4")
	public String getSunhoanNurse4() {
		return this.sunhoanNurse4;
	}

	public void setSunhoanNurse4(String sunhoanNurse4) {
		this.sunhoanNurse4 = sunhoanNurse4;
	}

	public String getSupport() {
		return this.support;
	}

	public void setSupport(String support) {
		this.support = support;
	}

	public String getSupport2() {
		return this.support2;
	}

	public void setSupport2(String support2) {
		this.support2 = support2;
	}

	public String getSupport3() {
		return this.support3;
	}

	public void setSupport3(String support3) {
		this.support3 = support3;
	}

	@Column(name = "SURGEON_CONFIRM_YN")
	public String getSurgeonConfirmYn() {
		return this.surgeonConfirmYn;
	}

	public void setSurgeonConfirmYn(String surgeonConfirmYn) {
		this.surgeonConfirmYn = surgeonConfirmYn;
	}

	@Column(name = "SUSUL_BUWI")
	public String getSusulBuwi() {
		return this.susulBuwi;
	}

	public void setSusulBuwi(String susulBuwi) {
		this.susulBuwi = susulBuwi;
	}

	@Column(name = "SUYAK_YANG")
	public Double getSuyakYang() {
		return this.suyakYang;
	}

	public void setSuyakYang(Double suyakYang) {
		this.suyakYang = suyakYang;
	}

	public String getSymya() {
		return this.symya;
	}

	public void setSymya(String symya) {
		this.symya = symya;
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

	public Double getWeight() {
		return this.weight;
	}

	public void setWeight(Double weight) {
		this.weight = weight;
	}

	@Column(name = "ZIP_CODE1")
	public String getZipCode1() {
		return this.zipCode1;
	}

	public void setZipCode1(String zipCode1) {
		this.zipCode1 = zipCode1;
	}

	@Column(name = "ZIP_CODE2")
	public String getZipCode2() {
		return this.zipCode2;
	}

	public void setZipCode2(String zipCode2) {
		this.zipCode2 = zipCode2;
	}

}