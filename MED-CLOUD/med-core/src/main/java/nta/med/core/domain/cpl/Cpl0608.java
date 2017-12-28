package nta.med.core.domain.cpl;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the CPL0608 database table.
 * 
 */
@Entity
@NamedQuery(name="Cpl0608.findAll", query="SELECT c FROM Cpl0608 c")
public class Cpl0608 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private Date actingDate;
	private double age;
	private String bloodCheck;
	private String bloodNo;
	private String bloodResult1;
	private String bloodResult2;
	private String bloodResult3;
	private String bloodResult4;
	private String bloodSungbun;
	private String bloodType;
	private String boguan;
	private String bunho;
	private String cardPrintYn;
	private String cheBlood;
	private String chulgoBuseo;
	private Date chulgoDate;
	private String chulgoGubun;
	private String chulgoTime;
	private String chulgoja1;
	private String chulgoja2;
	private double danga;
	private String doctor;
	private String emerDoctor;
	private String emerNurse;
	private String emerPrintYn;
	private String emerYn;
	private double fkcpl2010;
	private double fkinp1001;
	private double fkocs;
	private double fkocs1003;
	private String fkout1001;
	private String gubun;
	private Date gumsaDate;
	private String gumsaTime;
	private String gumsaja;
	private String gumsaja2;
	private String gwa;
	private String hoCode;
	private String hoDong;
	private String holdYn;
	private String hospCode;
	private String inOutGubun;
	private double norm;
	private String nurse;
	private String nurseConfirmYn;
	private String paBloodType;
	private String pay;
	private double pkcpl0608;
	private String radiation;
	private String remark;
	private String rhGubun;
	private double seq;
	private String sex;
	private String sideEffect;
	private String specimenSer;
	private String sugaHangmogCode;
	private String suname;
	private String sungbunCode;
	private Date sysDate;
	private String sysId;
	private String unbanja;
	private String unbanja1;
	private Date updDate;
	private String updId;
	private String xMatching;
	private Date yuhyoToDate;

	public Cpl0608() {
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="ACTING_DATE")
	public Date getActingDate() {
		return this.actingDate;
	}

	public void setActingDate(Date actingDate) {
		this.actingDate = actingDate;
	}


	public double getAge() {
		return this.age;
	}

	public void setAge(double age) {
		this.age = age;
	}


	@Column(name="BLOOD_CHECK")
	public String getBloodCheck() {
		return this.bloodCheck;
	}

	public void setBloodCheck(String bloodCheck) {
		this.bloodCheck = bloodCheck;
	}


	@Column(name="BLOOD_NO")
	public String getBloodNo() {
		return this.bloodNo;
	}

	public void setBloodNo(String bloodNo) {
		this.bloodNo = bloodNo;
	}


	@Column(name="BLOOD_RESULT1")
	public String getBloodResult1() {
		return this.bloodResult1;
	}

	public void setBloodResult1(String bloodResult1) {
		this.bloodResult1 = bloodResult1;
	}


	@Column(name="BLOOD_RESULT2")
	public String getBloodResult2() {
		return this.bloodResult2;
	}

	public void setBloodResult2(String bloodResult2) {
		this.bloodResult2 = bloodResult2;
	}


	@Column(name="BLOOD_RESULT3")
	public String getBloodResult3() {
		return this.bloodResult3;
	}

	public void setBloodResult3(String bloodResult3) {
		this.bloodResult3 = bloodResult3;
	}


	@Column(name="BLOOD_RESULT4")
	public String getBloodResult4() {
		return this.bloodResult4;
	}

	public void setBloodResult4(String bloodResult4) {
		this.bloodResult4 = bloodResult4;
	}


	@Column(name="BLOOD_SUNGBUN")
	public String getBloodSungbun() {
		return this.bloodSungbun;
	}

	public void setBloodSungbun(String bloodSungbun) {
		this.bloodSungbun = bloodSungbun;
	}


	@Column(name="BLOOD_TYPE")
	public String getBloodType() {
		return this.bloodType;
	}

	public void setBloodType(String bloodType) {
		this.bloodType = bloodType;
	}


	public String getBoguan() {
		return this.boguan;
	}

	public void setBoguan(String boguan) {
		this.boguan = boguan;
	}


	public String getBunho() {
		return this.bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}


	@Column(name="CARD_PRINT_YN")
	public String getCardPrintYn() {
		return this.cardPrintYn;
	}

	public void setCardPrintYn(String cardPrintYn) {
		this.cardPrintYn = cardPrintYn;
	}


	@Column(name="CHE_BLOOD")
	public String getCheBlood() {
		return this.cheBlood;
	}

	public void setCheBlood(String cheBlood) {
		this.cheBlood = cheBlood;
	}


	@Column(name="CHULGO_BUSEO")
	public String getChulgoBuseo() {
		return this.chulgoBuseo;
	}

	public void setChulgoBuseo(String chulgoBuseo) {
		this.chulgoBuseo = chulgoBuseo;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="CHULGO_DATE")
	public Date getChulgoDate() {
		return this.chulgoDate;
	}

	public void setChulgoDate(Date chulgoDate) {
		this.chulgoDate = chulgoDate;
	}


	@Column(name="CHULGO_GUBUN")
	public String getChulgoGubun() {
		return this.chulgoGubun;
	}

	public void setChulgoGubun(String chulgoGubun) {
		this.chulgoGubun = chulgoGubun;
	}


	@Column(name="CHULGO_TIME")
	public String getChulgoTime() {
		return this.chulgoTime;
	}

	public void setChulgoTime(String chulgoTime) {
		this.chulgoTime = chulgoTime;
	}


	public String getChulgoja1() {
		return this.chulgoja1;
	}

	public void setChulgoja1(String chulgoja1) {
		this.chulgoja1 = chulgoja1;
	}


	public String getChulgoja2() {
		return this.chulgoja2;
	}

	public void setChulgoja2(String chulgoja2) {
		this.chulgoja2 = chulgoja2;
	}


	public double getDanga() {
		return this.danga;
	}

	public void setDanga(double danga) {
		this.danga = danga;
	}


	public String getDoctor() {
		return this.doctor;
	}

	public void setDoctor(String doctor) {
		this.doctor = doctor;
	}


	@Column(name="EMER_DOCTOR")
	public String getEmerDoctor() {
		return this.emerDoctor;
	}

	public void setEmerDoctor(String emerDoctor) {
		this.emerDoctor = emerDoctor;
	}


	@Column(name="EMER_NURSE")
	public String getEmerNurse() {
		return this.emerNurse;
	}

	public void setEmerNurse(String emerNurse) {
		this.emerNurse = emerNurse;
	}


	@Column(name="EMER_PRINT_YN")
	public String getEmerPrintYn() {
		return this.emerPrintYn;
	}

	public void setEmerPrintYn(String emerPrintYn) {
		this.emerPrintYn = emerPrintYn;
	}


	@Column(name="EMER_YN")
	public String getEmerYn() {
		return this.emerYn;
	}

	public void setEmerYn(String emerYn) {
		this.emerYn = emerYn;
	}


	public double getFkcpl2010() {
		return this.fkcpl2010;
	}

	public void setFkcpl2010(double fkcpl2010) {
		this.fkcpl2010 = fkcpl2010;
	}


	public double getFkinp1001() {
		return this.fkinp1001;
	}

	public void setFkinp1001(double fkinp1001) {
		this.fkinp1001 = fkinp1001;
	}


	public double getFkocs() {
		return this.fkocs;
	}

	public void setFkocs(double fkocs) {
		this.fkocs = fkocs;
	}


	public double getFkocs1003() {
		return this.fkocs1003;
	}

	public void setFkocs1003(double fkocs1003) {
		this.fkocs1003 = fkocs1003;
	}


	public String getFkout1001() {
		return this.fkout1001;
	}

	public void setFkout1001(String fkout1001) {
		this.fkout1001 = fkout1001;
	}


	public String getGubun() {
		return this.gubun;
	}

	public void setGubun(String gubun) {
		this.gubun = gubun;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="GUMSA_DATE")
	public Date getGumsaDate() {
		return this.gumsaDate;
	}

	public void setGumsaDate(Date gumsaDate) {
		this.gumsaDate = gumsaDate;
	}


	@Column(name="GUMSA_TIME")
	public String getGumsaTime() {
		return this.gumsaTime;
	}

	public void setGumsaTime(String gumsaTime) {
		this.gumsaTime = gumsaTime;
	}


	public String getGumsaja() {
		return this.gumsaja;
	}

	public void setGumsaja(String gumsaja) {
		this.gumsaja = gumsaja;
	}


	public String getGumsaja2() {
		return this.gumsaja2;
	}

	public void setGumsaja2(String gumsaja2) {
		this.gumsaja2 = gumsaja2;
	}


	public String getGwa() {
		return this.gwa;
	}

	public void setGwa(String gwa) {
		this.gwa = gwa;
	}


	@Column(name="HO_CODE")
	public String getHoCode() {
		return this.hoCode;
	}

	public void setHoCode(String hoCode) {
		this.hoCode = hoCode;
	}


	@Column(name="HO_DONG")
	public String getHoDong() {
		return this.hoDong;
	}

	public void setHoDong(String hoDong) {
		this.hoDong = hoDong;
	}


	@Column(name="HOLD_YN")
	public String getHoldYn() {
		return this.holdYn;
	}

	public void setHoldYn(String holdYn) {
		this.holdYn = holdYn;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="IN_OUT_GUBUN")
	public String getInOutGubun() {
		return this.inOutGubun;
	}

	public void setInOutGubun(String inOutGubun) {
		this.inOutGubun = inOutGubun;
	}


	public double getNorm() {
		return this.norm;
	}

	public void setNorm(double norm) {
		this.norm = norm;
	}


	public String getNurse() {
		return this.nurse;
	}

	public void setNurse(String nurse) {
		this.nurse = nurse;
	}


	@Column(name="NURSE_CONFIRM_YN")
	public String getNurseConfirmYn() {
		return this.nurseConfirmYn;
	}

	public void setNurseConfirmYn(String nurseConfirmYn) {
		this.nurseConfirmYn = nurseConfirmYn;
	}


	@Column(name="PA_BLOOD_TYPE")
	public String getPaBloodType() {
		return this.paBloodType;
	}

	public void setPaBloodType(String paBloodType) {
		this.paBloodType = paBloodType;
	}


	public String getPay() {
		return this.pay;
	}

	public void setPay(String pay) {
		this.pay = pay;
	}


	public double getPkcpl0608() {
		return this.pkcpl0608;
	}

	public void setPkcpl0608(double pkcpl0608) {
		this.pkcpl0608 = pkcpl0608;
	}


	public String getRadiation() {
		return this.radiation;
	}

	public void setRadiation(String radiation) {
		this.radiation = radiation;
	}


	public String getRemark() {
		return this.remark;
	}

	public void setRemark(String remark) {
		this.remark = remark;
	}


	@Column(name="RH_GUBUN")
	public String getRhGubun() {
		return this.rhGubun;
	}

	public void setRhGubun(String rhGubun) {
		this.rhGubun = rhGubun;
	}


	public double getSeq() {
		return this.seq;
	}

	public void setSeq(double seq) {
		this.seq = seq;
	}


	public String getSex() {
		return this.sex;
	}

	public void setSex(String sex) {
		this.sex = sex;
	}


	@Column(name="SIDE_EFFECT")
	public String getSideEffect() {
		return this.sideEffect;
	}

	public void setSideEffect(String sideEffect) {
		this.sideEffect = sideEffect;
	}


	@Column(name="SPECIMEN_SER")
	public String getSpecimenSer() {
		return this.specimenSer;
	}

	public void setSpecimenSer(String specimenSer) {
		this.specimenSer = specimenSer;
	}


	@Column(name="SUGA_HANGMOG_CODE")
	public String getSugaHangmogCode() {
		return this.sugaHangmogCode;
	}

	public void setSugaHangmogCode(String sugaHangmogCode) {
		this.sugaHangmogCode = sugaHangmogCode;
	}


	public String getSuname() {
		return this.suname;
	}

	public void setSuname(String suname) {
		this.suname = suname;
	}


	@Column(name="SUNGBUN_CODE")
	public String getSungbunCode() {
		return this.sungbunCode;
	}

	public void setSungbunCode(String sungbunCode) {
		this.sungbunCode = sungbunCode;
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


	public String getUnbanja() {
		return this.unbanja;
	}

	public void setUnbanja(String unbanja) {
		this.unbanja = unbanja;
	}


	public String getUnbanja1() {
		return this.unbanja1;
	}

	public void setUnbanja1(String unbanja1) {
		this.unbanja1 = unbanja1;
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


	@Column(name="X_MATCHING")
	public String getXMatching() {
		return this.xMatching;
	}

	public void setXMatching(String xMatching) {
		this.xMatching = xMatching;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="YUHYO_TO_DATE")
	public Date getYuhyoToDate() {
		return this.yuhyoToDate;
	}

	public void setYuhyoToDate(Date yuhyoToDate) {
		this.yuhyoToDate = yuhyoToDate;
	}

}