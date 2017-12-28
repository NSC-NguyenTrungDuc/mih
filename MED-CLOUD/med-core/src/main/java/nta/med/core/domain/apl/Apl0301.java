package nta.med.core.domain.apl;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.NamedQuery;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;


/**
 * The persistent class for the APL0301 database table.
 * 
 */
@Entity
@NamedQuery(name="Apl0301.findAll", query="SELECT a FROM Apl0301 a")
public class Apl0301 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String age;
	private String bunho;
	private Date confirmDate;
	private String confirmDoctor;
	private String delayReason;
	private String delayReson;
	private String endoYn;
	private double frozenSu;
	private String frozenYn;
	private String grossYn;
	private String gumsaAvg;
	private String gumsa1;
	private String gwa;
	private String hangmogCode;
	private String hoCode;
	private String hoDong;
	private String hospCode;
	private String inOutGubun;
	private String inputId;
	private String janggiCode;
	private String jindan;
	private Date jubsuDate;
	private String jubsuTime;
	private String jubsuja;
	private double menopauseAge;
	private Date mensDate;
	private double oldFrozenSu;
	private double oldSpecimenSu;
	private String orGubun;
	private Date orderDate;
	private String pathno;
	private String pathno1;
	private String pathno2;
	private double pathno3;
	private String pattern;
	private String photoYn;
	private Date preResultDate;
	private String pregnancy;
	private String remark;
	private String requestDoctor;
	private String requestGwa;
	private Date resultDate;
	private String resultDoctor;
	private String resultDoctor1;
	private String resultDoctor2;
	private String resultResident;
	private String resultTime;
	private String sangCode;
	private String sangName;
	private String screener;
	private String sex;
	private Date slideDate;
	private String specimenBunryu;
	private double specimenSu;
	private Date sunabDate;
	private String sunabYn;
	private String suname;
	private String surgeryYn;
	private Date sysDate;
	private String sysId;
	private String test1;
	private String test2;
	private String test3;
	private Date updDate;
	private String updId;
	private String xrayYn;

	public Apl0301() {
	}


	public String getAge() {
		return this.age;
	}

	public void setAge(String age) {
		this.age = age;
	}


	public String getBunho() {
		return this.bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="CONFIRM_DATE")
	public Date getConfirmDate() {
		return this.confirmDate;
	}

	public void setConfirmDate(Date confirmDate) {
		this.confirmDate = confirmDate;
	}


	@Column(name="CONFIRM_DOCTOR")
	public String getConfirmDoctor() {
		return this.confirmDoctor;
	}

	public void setConfirmDoctor(String confirmDoctor) {
		this.confirmDoctor = confirmDoctor;
	}


	@Column(name="DELAY_REASON")
	public String getDelayReason() {
		return this.delayReason;
	}

	public void setDelayReason(String delayReason) {
		this.delayReason = delayReason;
	}


	@Column(name="DELAY_RESON")
	public String getDelayReson() {
		return this.delayReson;
	}

	public void setDelayReson(String delayReson) {
		this.delayReson = delayReson;
	}


	@Column(name="ENDO_YN")
	public String getEndoYn() {
		return this.endoYn;
	}

	public void setEndoYn(String endoYn) {
		this.endoYn = endoYn;
	}


	@Column(name="FROZEN_SU")
	public double getFrozenSu() {
		return this.frozenSu;
	}

	public void setFrozenSu(double frozenSu) {
		this.frozenSu = frozenSu;
	}


	@Column(name="FROZEN_YN")
	public String getFrozenYn() {
		return this.frozenYn;
	}

	public void setFrozenYn(String frozenYn) {
		this.frozenYn = frozenYn;
	}


	@Column(name="GROSS_YN")
	public String getGrossYn() {
		return this.grossYn;
	}

	public void setGrossYn(String grossYn) {
		this.grossYn = grossYn;
	}


	@Column(name="GUMSA_AVG")
	public String getGumsaAvg() {
		return this.gumsaAvg;
	}

	public void setGumsaAvg(String gumsaAvg) {
		this.gumsaAvg = gumsaAvg;
	}


	public String getGumsa1() {
		return this.gumsa1;
	}

	public void setGumsa1(String gumsa1) {
		this.gumsa1 = gumsa1;
	}


	public String getGwa() {
		return this.gwa;
	}

	public void setGwa(String gwa) {
		this.gwa = gwa;
	}


	@Column(name="HANGMOG_CODE")
	public String getHangmogCode() {
		return this.hangmogCode;
	}

	public void setHangmogCode(String hangmogCode) {
		this.hangmogCode = hangmogCode;
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


	@Column(name="INPUT_ID")
	public String getInputId() {
		return this.inputId;
	}

	public void setInputId(String inputId) {
		this.inputId = inputId;
	}


	@Column(name="JANGGI_CODE")
	public String getJanggiCode() {
		return this.janggiCode;
	}

	public void setJanggiCode(String janggiCode) {
		this.janggiCode = janggiCode;
	}


	public String getJindan() {
		return this.jindan;
	}

	public void setJindan(String jindan) {
		this.jindan = jindan;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="JUBSU_DATE")
	public Date getJubsuDate() {
		return this.jubsuDate;
	}

	public void setJubsuDate(Date jubsuDate) {
		this.jubsuDate = jubsuDate;
	}


	@Column(name="JUBSU_TIME")
	public String getJubsuTime() {
		return this.jubsuTime;
	}

	public void setJubsuTime(String jubsuTime) {
		this.jubsuTime = jubsuTime;
	}


	public String getJubsuja() {
		return this.jubsuja;
	}

	public void setJubsuja(String jubsuja) {
		this.jubsuja = jubsuja;
	}


	@Column(name="MENOPAUSE_AGE")
	public double getMenopauseAge() {
		return this.menopauseAge;
	}

	public void setMenopauseAge(double menopauseAge) {
		this.menopauseAge = menopauseAge;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="MENS_DATE")
	public Date getMensDate() {
		return this.mensDate;
	}

	public void setMensDate(Date mensDate) {
		this.mensDate = mensDate;
	}


	@Column(name="OLD_FROZEN_SU")
	public double getOldFrozenSu() {
		return this.oldFrozenSu;
	}

	public void setOldFrozenSu(double oldFrozenSu) {
		this.oldFrozenSu = oldFrozenSu;
	}


	@Column(name="OLD_SPECIMEN_SU")
	public double getOldSpecimenSu() {
		return this.oldSpecimenSu;
	}

	public void setOldSpecimenSu(double oldSpecimenSu) {
		this.oldSpecimenSu = oldSpecimenSu;
	}


	@Column(name="OR_GUBUN")
	public String getOrGubun() {
		return this.orGubun;
	}

	public void setOrGubun(String orGubun) {
		this.orGubun = orGubun;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="ORDER_DATE")
	public Date getOrderDate() {
		return this.orderDate;
	}

	public void setOrderDate(Date orderDate) {
		this.orderDate = orderDate;
	}


	public String getPathno() {
		return this.pathno;
	}

	public void setPathno(String pathno) {
		this.pathno = pathno;
	}


	public String getPathno1() {
		return this.pathno1;
	}

	public void setPathno1(String pathno1) {
		this.pathno1 = pathno1;
	}


	public String getPathno2() {
		return this.pathno2;
	}

	public void setPathno2(String pathno2) {
		this.pathno2 = pathno2;
	}


	public double getPathno3() {
		return this.pathno3;
	}

	public void setPathno3(double pathno3) {
		this.pathno3 = pathno3;
	}


	public String getPattern() {
		return this.pattern;
	}

	public void setPattern(String pattern) {
		this.pattern = pattern;
	}


	@Column(name="PHOTO_YN")
	public String getPhotoYn() {
		return this.photoYn;
	}

	public void setPhotoYn(String photoYn) {
		this.photoYn = photoYn;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="PRE_RESULT_DATE")
	public Date getPreResultDate() {
		return this.preResultDate;
	}

	public void setPreResultDate(Date preResultDate) {
		this.preResultDate = preResultDate;
	}


	public String getPregnancy() {
		return this.pregnancy;
	}

	public void setPregnancy(String pregnancy) {
		this.pregnancy = pregnancy;
	}


	public String getRemark() {
		return this.remark;
	}

	public void setRemark(String remark) {
		this.remark = remark;
	}


	@Column(name="REQUEST_DOCTOR")
	public String getRequestDoctor() {
		return this.requestDoctor;
	}

	public void setRequestDoctor(String requestDoctor) {
		this.requestDoctor = requestDoctor;
	}


	@Column(name="REQUEST_GWA")
	public String getRequestGwa() {
		return this.requestGwa;
	}

	public void setRequestGwa(String requestGwa) {
		this.requestGwa = requestGwa;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="RESULT_DATE")
	public Date getResultDate() {
		return this.resultDate;
	}

	public void setResultDate(Date resultDate) {
		this.resultDate = resultDate;
	}


	@Column(name="RESULT_DOCTOR")
	public String getResultDoctor() {
		return this.resultDoctor;
	}

	public void setResultDoctor(String resultDoctor) {
		this.resultDoctor = resultDoctor;
	}


	@Column(name="RESULT_DOCTOR1")
	public String getResultDoctor1() {
		return this.resultDoctor1;
	}

	public void setResultDoctor1(String resultDoctor1) {
		this.resultDoctor1 = resultDoctor1;
	}


	@Column(name="RESULT_DOCTOR2")
	public String getResultDoctor2() {
		return this.resultDoctor2;
	}

	public void setResultDoctor2(String resultDoctor2) {
		this.resultDoctor2 = resultDoctor2;
	}


	@Column(name="RESULT_RESIDENT")
	public String getResultResident() {
		return this.resultResident;
	}

	public void setResultResident(String resultResident) {
		this.resultResident = resultResident;
	}


	@Column(name="RESULT_TIME")
	public String getResultTime() {
		return this.resultTime;
	}

	public void setResultTime(String resultTime) {
		this.resultTime = resultTime;
	}


	@Column(name="SANG_CODE")
	public String getSangCode() {
		return this.sangCode;
	}

	public void setSangCode(String sangCode) {
		this.sangCode = sangCode;
	}


	@Column(name="SANG_NAME")
	public String getSangName() {
		return this.sangName;
	}

	public void setSangName(String sangName) {
		this.sangName = sangName;
	}


	public String getScreener() {
		return this.screener;
	}

	public void setScreener(String screener) {
		this.screener = screener;
	}


	public String getSex() {
		return this.sex;
	}

	public void setSex(String sex) {
		this.sex = sex;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="SLIDE_DATE")
	public Date getSlideDate() {
		return this.slideDate;
	}

	public void setSlideDate(Date slideDate) {
		this.slideDate = slideDate;
	}


	@Column(name="SPECIMEN_BUNRYU")
	public String getSpecimenBunryu() {
		return this.specimenBunryu;
	}

	public void setSpecimenBunryu(String specimenBunryu) {
		this.specimenBunryu = specimenBunryu;
	}


	@Column(name="SPECIMEN_SU")
	public double getSpecimenSu() {
		return this.specimenSu;
	}

	public void setSpecimenSu(double specimenSu) {
		this.specimenSu = specimenSu;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="SUNAB_DATE")
	public Date getSunabDate() {
		return this.sunabDate;
	}

	public void setSunabDate(Date sunabDate) {
		this.sunabDate = sunabDate;
	}


	@Column(name="SUNAB_YN")
	public String getSunabYn() {
		return this.sunabYn;
	}

	public void setSunabYn(String sunabYn) {
		this.sunabYn = sunabYn;
	}


	public String getSuname() {
		return this.suname;
	}

	public void setSuname(String suname) {
		this.suname = suname;
	}


	@Column(name="SURGERY_YN")
	public String getSurgeryYn() {
		return this.surgeryYn;
	}

	public void setSurgeryYn(String surgeryYn) {
		this.surgeryYn = surgeryYn;
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


	public String getTest1() {
		return this.test1;
	}

	public void setTest1(String test1) {
		this.test1 = test1;
	}


	public String getTest2() {
		return this.test2;
	}

	public void setTest2(String test2) {
		this.test2 = test2;
	}


	public String getTest3() {
		return this.test3;
	}

	public void setTest3(String test3) {
		this.test3 = test3;
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


	@Column(name="XRAY_YN")
	public String getXrayYn() {
		return this.xrayYn;
	}

	public void setXrayYn(String xrayYn) {
		this.xrayYn = xrayYn;
	}

}