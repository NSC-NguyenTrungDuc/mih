package nta.med.core.domain.nur;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the NUR5001 database table.
 * 
 */
@Entity
@NamedQuery(name="Nur5001.findAll", query="SELECT n FROM Nur5001 n")
public class Nur5001 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private Date baeilDate;
	private String baeilTime;
	private Date balloDate;
	private String balloTime;
	private String bigo;
	private String bonghab;
	private String bunho;
	private double bunman;
	private String bunmanDoctor1;
	private String bunmanDoctor2;
	private String bunmanDoctor3;
	private String bunmanHabsil;
	private double bunmanHuWeight;
	private double bunmanJikhuBody;
	private double bunmanJikhuBodyOne;
	private double bunmanJikhuBodyTwo;
	private String bunmanJikhuJagungju;
	private String bunmanJikhuJagungjuOne;
	private String bunmanJikhuJagungjuTwo;
	private double bunmanJikhuOro;
	private double bunmanJikhuOroOne;
	private double bunmanJikhuOroTwo;
	private double bunmanJikhuPressHigh;
	private double bunmanJikhuPressHighOne;
	private double bunmanJikhuPressHighTwo;
	private double bunmanJikhuPressLow;
	private double bunmanJikhuPressLowOne;
	private double bunmanJikhuPressLowTwo;
	private double bunmanJikhuPulse;
	private double bunmanJikhuPulseOne;
	private double bunmanJikhuPulseTwo;
	private String bunmanJikhuSuchuk;
	private String bunmanJikhuSuchukOne;
	private String bunmanJikhuSuchukTwo;
	private String bunmanTotTime;
	private String bunmanYangsik;
	private Date clystDate;
	private String clystTime;
	private double continueBunho;
	private String firstBunmanGubun;
	private double firstDeliveryWeight;
	private String firstDeliveryYmd;
	private double fkinp1001;
	private String girokId;
	private String hospCode;
	private double imsinjusuD;
	private double imsinjusuW;
	private String incisionYn;
	private String ipdukEndGubun;
	private String ipdukEndYmd;
	private double ipdukGigan;
	private String jedaeBakdongStopDate;
	private double jintongTerm1;
	private double jintongTerm2;
	private String jongsanYmd;
	private String josanbu1;
	private String josanbu2;
	private String junrak;
	private Date lastMenseDate;
	private double lastMenseGigan;
	private Date manchulDate;
	private String manchulTime;
	private String marriageYm;
	private double menarcheAge;
	private String menarcheGrade;
	private String menarcheGubun;
	private double menarcheIlsu;
	private String menarchePainGrade;
	private String menarchePainGubun;
	private String nurseId1;
	private String nurseId2;
	private String nurseId3;
	private String nurseId4;
	private String nurseId5;
	private Date outPartSodokDate;
	private String outPartSodokTime;
	private Date pasuDate;
	private String pasuGubun;
	private String pasuTime;
	private double pknur5001;
	private double pregnancyJusuIl;
	private double pregnancyJusuJu;
	private double pregnancyNo;
	private Date sanmoBunmanDate;
	private String sanmoBunmanTime;
	private String sanmoJob;
	private double sanyok;
	private String startIpdukGubun;
	private String startIpdukYmd;
	private Date startJintongDate;
	private String startJintongTime;
	private Date sysDate;
	private String sysId;
	private Date taebanManchulDate;
	private String taebanManchulJagungju;
	private String taebanManchulSuchukStat;
	private String taebanManchulTime;
	private Date taedongDate;
	private String taewi;
	private double totalBunho;
	private Date updDate;
	private String updId;
	private String vald;
	private String yangsu;
	private String yusi;

	public Nur5001() {
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="BAEIL_DATE")
	public Date getBaeilDate() {
		return this.baeilDate;
	}

	public void setBaeilDate(Date baeilDate) {
		this.baeilDate = baeilDate;
	}


	@Column(name="BAEIL_TIME")
	public String getBaeilTime() {
		return this.baeilTime;
	}

	public void setBaeilTime(String baeilTime) {
		this.baeilTime = baeilTime;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="BALLO_DATE")
	public Date getBalloDate() {
		return this.balloDate;
	}

	public void setBalloDate(Date balloDate) {
		this.balloDate = balloDate;
	}


	@Column(name="BALLO_TIME")
	public String getBalloTime() {
		return this.balloTime;
	}

	public void setBalloTime(String balloTime) {
		this.balloTime = balloTime;
	}


	public String getBigo() {
		return this.bigo;
	}

	public void setBigo(String bigo) {
		this.bigo = bigo;
	}


	public String getBonghab() {
		return this.bonghab;
	}

	public void setBonghab(String bonghab) {
		this.bonghab = bonghab;
	}


	public String getBunho() {
		return this.bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}


	public double getBunman() {
		return this.bunman;
	}

	public void setBunman(double bunman) {
		this.bunman = bunman;
	}


	@Column(name="BUNMAN_DOCTOR1")
	public String getBunmanDoctor1() {
		return this.bunmanDoctor1;
	}

	public void setBunmanDoctor1(String bunmanDoctor1) {
		this.bunmanDoctor1 = bunmanDoctor1;
	}


	@Column(name="BUNMAN_DOCTOR2")
	public String getBunmanDoctor2() {
		return this.bunmanDoctor2;
	}

	public void setBunmanDoctor2(String bunmanDoctor2) {
		this.bunmanDoctor2 = bunmanDoctor2;
	}


	@Column(name="BUNMAN_DOCTOR3")
	public String getBunmanDoctor3() {
		return this.bunmanDoctor3;
	}

	public void setBunmanDoctor3(String bunmanDoctor3) {
		this.bunmanDoctor3 = bunmanDoctor3;
	}


	@Column(name="BUNMAN_HABSIL")
	public String getBunmanHabsil() {
		return this.bunmanHabsil;
	}

	public void setBunmanHabsil(String bunmanHabsil) {
		this.bunmanHabsil = bunmanHabsil;
	}


	@Column(name="BUNMAN_HU_WEIGHT")
	public double getBunmanHuWeight() {
		return this.bunmanHuWeight;
	}

	public void setBunmanHuWeight(double bunmanHuWeight) {
		this.bunmanHuWeight = bunmanHuWeight;
	}


	@Column(name="BUNMAN_JIKHU_BODY")
	public double getBunmanJikhuBody() {
		return this.bunmanJikhuBody;
	}

	public void setBunmanJikhuBody(double bunmanJikhuBody) {
		this.bunmanJikhuBody = bunmanJikhuBody;
	}


	@Column(name="BUNMAN_JIKHU_BODY_ONE")
	public double getBunmanJikhuBodyOne() {
		return this.bunmanJikhuBodyOne;
	}

	public void setBunmanJikhuBodyOne(double bunmanJikhuBodyOne) {
		this.bunmanJikhuBodyOne = bunmanJikhuBodyOne;
	}


	@Column(name="BUNMAN_JIKHU_BODY_TWO")
	public double getBunmanJikhuBodyTwo() {
		return this.bunmanJikhuBodyTwo;
	}

	public void setBunmanJikhuBodyTwo(double bunmanJikhuBodyTwo) {
		this.bunmanJikhuBodyTwo = bunmanJikhuBodyTwo;
	}


	@Column(name="BUNMAN_JIKHU_JAGUNGJU")
	public String getBunmanJikhuJagungju() {
		return this.bunmanJikhuJagungju;
	}

	public void setBunmanJikhuJagungju(String bunmanJikhuJagungju) {
		this.bunmanJikhuJagungju = bunmanJikhuJagungju;
	}


	@Column(name="BUNMAN_JIKHU_JAGUNGJU_ONE")
	public String getBunmanJikhuJagungjuOne() {
		return this.bunmanJikhuJagungjuOne;
	}

	public void setBunmanJikhuJagungjuOne(String bunmanJikhuJagungjuOne) {
		this.bunmanJikhuJagungjuOne = bunmanJikhuJagungjuOne;
	}


	@Column(name="BUNMAN_JIKHU_JAGUNGJU_TWO")
	public String getBunmanJikhuJagungjuTwo() {
		return this.bunmanJikhuJagungjuTwo;
	}

	public void setBunmanJikhuJagungjuTwo(String bunmanJikhuJagungjuTwo) {
		this.bunmanJikhuJagungjuTwo = bunmanJikhuJagungjuTwo;
	}


	@Column(name="BUNMAN_JIKHU_ORO")
	public double getBunmanJikhuOro() {
		return this.bunmanJikhuOro;
	}

	public void setBunmanJikhuOro(double bunmanJikhuOro) {
		this.bunmanJikhuOro = bunmanJikhuOro;
	}


	@Column(name="BUNMAN_JIKHU_ORO_ONE")
	public double getBunmanJikhuOroOne() {
		return this.bunmanJikhuOroOne;
	}

	public void setBunmanJikhuOroOne(double bunmanJikhuOroOne) {
		this.bunmanJikhuOroOne = bunmanJikhuOroOne;
	}


	@Column(name="BUNMAN_JIKHU_ORO_TWO")
	public double getBunmanJikhuOroTwo() {
		return this.bunmanJikhuOroTwo;
	}

	public void setBunmanJikhuOroTwo(double bunmanJikhuOroTwo) {
		this.bunmanJikhuOroTwo = bunmanJikhuOroTwo;
	}


	@Column(name="BUNMAN_JIKHU_PRESS_HIGH")
	public double getBunmanJikhuPressHigh() {
		return this.bunmanJikhuPressHigh;
	}

	public void setBunmanJikhuPressHigh(double bunmanJikhuPressHigh) {
		this.bunmanJikhuPressHigh = bunmanJikhuPressHigh;
	}


	@Column(name="BUNMAN_JIKHU_PRESS_HIGH_ONE")
	public double getBunmanJikhuPressHighOne() {
		return this.bunmanJikhuPressHighOne;
	}

	public void setBunmanJikhuPressHighOne(double bunmanJikhuPressHighOne) {
		this.bunmanJikhuPressHighOne = bunmanJikhuPressHighOne;
	}


	@Column(name="BUNMAN_JIKHU_PRESS_HIGH_TWO")
	public double getBunmanJikhuPressHighTwo() {
		return this.bunmanJikhuPressHighTwo;
	}

	public void setBunmanJikhuPressHighTwo(double bunmanJikhuPressHighTwo) {
		this.bunmanJikhuPressHighTwo = bunmanJikhuPressHighTwo;
	}


	@Column(name="BUNMAN_JIKHU_PRESS_LOW")
	public double getBunmanJikhuPressLow() {
		return this.bunmanJikhuPressLow;
	}

	public void setBunmanJikhuPressLow(double bunmanJikhuPressLow) {
		this.bunmanJikhuPressLow = bunmanJikhuPressLow;
	}


	@Column(name="BUNMAN_JIKHU_PRESS_LOW_ONE")
	public double getBunmanJikhuPressLowOne() {
		return this.bunmanJikhuPressLowOne;
	}

	public void setBunmanJikhuPressLowOne(double bunmanJikhuPressLowOne) {
		this.bunmanJikhuPressLowOne = bunmanJikhuPressLowOne;
	}


	@Column(name="BUNMAN_JIKHU_PRESS_LOW_TWO")
	public double getBunmanJikhuPressLowTwo() {
		return this.bunmanJikhuPressLowTwo;
	}

	public void setBunmanJikhuPressLowTwo(double bunmanJikhuPressLowTwo) {
		this.bunmanJikhuPressLowTwo = bunmanJikhuPressLowTwo;
	}


	@Column(name="BUNMAN_JIKHU_PULSE")
	public double getBunmanJikhuPulse() {
		return this.bunmanJikhuPulse;
	}

	public void setBunmanJikhuPulse(double bunmanJikhuPulse) {
		this.bunmanJikhuPulse = bunmanJikhuPulse;
	}


	@Column(name="BUNMAN_JIKHU_PULSE_ONE")
	public double getBunmanJikhuPulseOne() {
		return this.bunmanJikhuPulseOne;
	}

	public void setBunmanJikhuPulseOne(double bunmanJikhuPulseOne) {
		this.bunmanJikhuPulseOne = bunmanJikhuPulseOne;
	}


	@Column(name="BUNMAN_JIKHU_PULSE_TWO")
	public double getBunmanJikhuPulseTwo() {
		return this.bunmanJikhuPulseTwo;
	}

	public void setBunmanJikhuPulseTwo(double bunmanJikhuPulseTwo) {
		this.bunmanJikhuPulseTwo = bunmanJikhuPulseTwo;
	}


	@Column(name="BUNMAN_JIKHU_SUCHUK")
	public String getBunmanJikhuSuchuk() {
		return this.bunmanJikhuSuchuk;
	}

	public void setBunmanJikhuSuchuk(String bunmanJikhuSuchuk) {
		this.bunmanJikhuSuchuk = bunmanJikhuSuchuk;
	}


	@Column(name="BUNMAN_JIKHU_SUCHUK_ONE")
	public String getBunmanJikhuSuchukOne() {
		return this.bunmanJikhuSuchukOne;
	}

	public void setBunmanJikhuSuchukOne(String bunmanJikhuSuchukOne) {
		this.bunmanJikhuSuchukOne = bunmanJikhuSuchukOne;
	}


	@Column(name="BUNMAN_JIKHU_SUCHUK_TWO")
	public String getBunmanJikhuSuchukTwo() {
		return this.bunmanJikhuSuchukTwo;
	}

	public void setBunmanJikhuSuchukTwo(String bunmanJikhuSuchukTwo) {
		this.bunmanJikhuSuchukTwo = bunmanJikhuSuchukTwo;
	}


	@Column(name="BUNMAN_TOT_TIME")
	public String getBunmanTotTime() {
		return this.bunmanTotTime;
	}

	public void setBunmanTotTime(String bunmanTotTime) {
		this.bunmanTotTime = bunmanTotTime;
	}


	@Column(name="BUNMAN_YANGSIK")
	public String getBunmanYangsik() {
		return this.bunmanYangsik;
	}

	public void setBunmanYangsik(String bunmanYangsik) {
		this.bunmanYangsik = bunmanYangsik;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="CLYST_DATE")
	public Date getClystDate() {
		return this.clystDate;
	}

	public void setClystDate(Date clystDate) {
		this.clystDate = clystDate;
	}


	@Column(name="CLYST_TIME")
	public String getClystTime() {
		return this.clystTime;
	}

	public void setClystTime(String clystTime) {
		this.clystTime = clystTime;
	}


	@Column(name="CONTINUE_BUNHO")
	public double getContinueBunho() {
		return this.continueBunho;
	}

	public void setContinueBunho(double continueBunho) {
		this.continueBunho = continueBunho;
	}


	@Column(name="FIRST_BUNMAN_GUBUN")
	public String getFirstBunmanGubun() {
		return this.firstBunmanGubun;
	}

	public void setFirstBunmanGubun(String firstBunmanGubun) {
		this.firstBunmanGubun = firstBunmanGubun;
	}


	@Column(name="FIRST_DELIVERY_WEIGHT")
	public double getFirstDeliveryWeight() {
		return this.firstDeliveryWeight;
	}

	public void setFirstDeliveryWeight(double firstDeliveryWeight) {
		this.firstDeliveryWeight = firstDeliveryWeight;
	}


	@Column(name="FIRST_DELIVERY_YMD")
	public String getFirstDeliveryYmd() {
		return this.firstDeliveryYmd;
	}

	public void setFirstDeliveryYmd(String firstDeliveryYmd) {
		this.firstDeliveryYmd = firstDeliveryYmd;
	}


	public double getFkinp1001() {
		return this.fkinp1001;
	}

	public void setFkinp1001(double fkinp1001) {
		this.fkinp1001 = fkinp1001;
	}


	@Column(name="GIROK_ID")
	public String getGirokId() {
		return this.girokId;
	}

	public void setGirokId(String girokId) {
		this.girokId = girokId;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="IMSINJUSU_D")
	public double getImsinjusuD() {
		return this.imsinjusuD;
	}

	public void setImsinjusuD(double imsinjusuD) {
		this.imsinjusuD = imsinjusuD;
	}


	@Column(name="IMSINJUSU_W")
	public double getImsinjusuW() {
		return this.imsinjusuW;
	}

	public void setImsinjusuW(double imsinjusuW) {
		this.imsinjusuW = imsinjusuW;
	}


	@Column(name="INCISION_YN")
	public String getIncisionYn() {
		return this.incisionYn;
	}

	public void setIncisionYn(String incisionYn) {
		this.incisionYn = incisionYn;
	}


	@Column(name="IPDUK_END_GUBUN")
	public String getIpdukEndGubun() {
		return this.ipdukEndGubun;
	}

	public void setIpdukEndGubun(String ipdukEndGubun) {
		this.ipdukEndGubun = ipdukEndGubun;
	}


	@Column(name="IPDUK_END_YMD")
	public String getIpdukEndYmd() {
		return this.ipdukEndYmd;
	}

	public void setIpdukEndYmd(String ipdukEndYmd) {
		this.ipdukEndYmd = ipdukEndYmd;
	}


	@Column(name="IPDUK_GIGAN")
	public double getIpdukGigan() {
		return this.ipdukGigan;
	}

	public void setIpdukGigan(double ipdukGigan) {
		this.ipdukGigan = ipdukGigan;
	}


	@Column(name="JEDAE_BAKDONG_STOP_DATE")
	public String getJedaeBakdongStopDate() {
		return this.jedaeBakdongStopDate;
	}

	public void setJedaeBakdongStopDate(String jedaeBakdongStopDate) {
		this.jedaeBakdongStopDate = jedaeBakdongStopDate;
	}


	@Column(name="JINTONG_TERM1")
	public double getJintongTerm1() {
		return this.jintongTerm1;
	}

	public void setJintongTerm1(double jintongTerm1) {
		this.jintongTerm1 = jintongTerm1;
	}


	@Column(name="JINTONG_TERM2")
	public double getJintongTerm2() {
		return this.jintongTerm2;
	}

	public void setJintongTerm2(double jintongTerm2) {
		this.jintongTerm2 = jintongTerm2;
	}


	@Column(name="JONGSAN_YMD")
	public String getJongsanYmd() {
		return this.jongsanYmd;
	}

	public void setJongsanYmd(String jongsanYmd) {
		this.jongsanYmd = jongsanYmd;
	}


	public String getJosanbu1() {
		return this.josanbu1;
	}

	public void setJosanbu1(String josanbu1) {
		this.josanbu1 = josanbu1;
	}


	public String getJosanbu2() {
		return this.josanbu2;
	}

	public void setJosanbu2(String josanbu2) {
		this.josanbu2 = josanbu2;
	}


	public String getJunrak() {
		return this.junrak;
	}

	public void setJunrak(String junrak) {
		this.junrak = junrak;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="LAST_MENSE_DATE")
	public Date getLastMenseDate() {
		return this.lastMenseDate;
	}

	public void setLastMenseDate(Date lastMenseDate) {
		this.lastMenseDate = lastMenseDate;
	}


	@Column(name="LAST_MENSE_GIGAN")
	public double getLastMenseGigan() {
		return this.lastMenseGigan;
	}

	public void setLastMenseGigan(double lastMenseGigan) {
		this.lastMenseGigan = lastMenseGigan;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="MANCHUL_DATE")
	public Date getManchulDate() {
		return this.manchulDate;
	}

	public void setManchulDate(Date manchulDate) {
		this.manchulDate = manchulDate;
	}


	@Column(name="MANCHUL_TIME")
	public String getManchulTime() {
		return this.manchulTime;
	}

	public void setManchulTime(String manchulTime) {
		this.manchulTime = manchulTime;
	}


	@Column(name="MARRIAGE_YM")
	public String getMarriageYm() {
		return this.marriageYm;
	}

	public void setMarriageYm(String marriageYm) {
		this.marriageYm = marriageYm;
	}


	@Column(name="MENARCHE_AGE")
	public double getMenarcheAge() {
		return this.menarcheAge;
	}

	public void setMenarcheAge(double menarcheAge) {
		this.menarcheAge = menarcheAge;
	}


	@Column(name="MENARCHE_GRADE")
	public String getMenarcheGrade() {
		return this.menarcheGrade;
	}

	public void setMenarcheGrade(String menarcheGrade) {
		this.menarcheGrade = menarcheGrade;
	}


	@Column(name="MENARCHE_GUBUN")
	public String getMenarcheGubun() {
		return this.menarcheGubun;
	}

	public void setMenarcheGubun(String menarcheGubun) {
		this.menarcheGubun = menarcheGubun;
	}


	@Column(name="MENARCHE_ILSU")
	public double getMenarcheIlsu() {
		return this.menarcheIlsu;
	}

	public void setMenarcheIlsu(double menarcheIlsu) {
		this.menarcheIlsu = menarcheIlsu;
	}


	@Column(name="MENARCHE_PAIN_GRADE")
	public String getMenarchePainGrade() {
		return this.menarchePainGrade;
	}

	public void setMenarchePainGrade(String menarchePainGrade) {
		this.menarchePainGrade = menarchePainGrade;
	}


	@Column(name="MENARCHE_PAIN_GUBUN")
	public String getMenarchePainGubun() {
		return this.menarchePainGubun;
	}

	public void setMenarchePainGubun(String menarchePainGubun) {
		this.menarchePainGubun = menarchePainGubun;
	}


	@Column(name="NURSE_ID1")
	public String getNurseId1() {
		return this.nurseId1;
	}

	public void setNurseId1(String nurseId1) {
		this.nurseId1 = nurseId1;
	}


	@Column(name="NURSE_ID2")
	public String getNurseId2() {
		return this.nurseId2;
	}

	public void setNurseId2(String nurseId2) {
		this.nurseId2 = nurseId2;
	}


	@Column(name="NURSE_ID3")
	public String getNurseId3() {
		return this.nurseId3;
	}

	public void setNurseId3(String nurseId3) {
		this.nurseId3 = nurseId3;
	}


	@Column(name="NURSE_ID4")
	public String getNurseId4() {
		return this.nurseId4;
	}

	public void setNurseId4(String nurseId4) {
		this.nurseId4 = nurseId4;
	}


	@Column(name="NURSE_ID5")
	public String getNurseId5() {
		return this.nurseId5;
	}

	public void setNurseId5(String nurseId5) {
		this.nurseId5 = nurseId5;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="OUT_PART_SODOK_DATE")
	public Date getOutPartSodokDate() {
		return this.outPartSodokDate;
	}

	public void setOutPartSodokDate(Date outPartSodokDate) {
		this.outPartSodokDate = outPartSodokDate;
	}


	@Column(name="OUT_PART_SODOK_TIME")
	public String getOutPartSodokTime() {
		return this.outPartSodokTime;
	}

	public void setOutPartSodokTime(String outPartSodokTime) {
		this.outPartSodokTime = outPartSodokTime;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="PASU_DATE")
	public Date getPasuDate() {
		return this.pasuDate;
	}

	public void setPasuDate(Date pasuDate) {
		this.pasuDate = pasuDate;
	}


	@Column(name="PASU_GUBUN")
	public String getPasuGubun() {
		return this.pasuGubun;
	}

	public void setPasuGubun(String pasuGubun) {
		this.pasuGubun = pasuGubun;
	}


	@Column(name="PASU_TIME")
	public String getPasuTime() {
		return this.pasuTime;
	}

	public void setPasuTime(String pasuTime) {
		this.pasuTime = pasuTime;
	}


	public double getPknur5001() {
		return this.pknur5001;
	}

	public void setPknur5001(double pknur5001) {
		this.pknur5001 = pknur5001;
	}


	@Column(name="PREGNANCY_JUSU_IL")
	public double getPregnancyJusuIl() {
		return this.pregnancyJusuIl;
	}

	public void setPregnancyJusuIl(double pregnancyJusuIl) {
		this.pregnancyJusuIl = pregnancyJusuIl;
	}


	@Column(name="PREGNANCY_JUSU_JU")
	public double getPregnancyJusuJu() {
		return this.pregnancyJusuJu;
	}

	public void setPregnancyJusuJu(double pregnancyJusuJu) {
		this.pregnancyJusuJu = pregnancyJusuJu;
	}


	@Column(name="PREGNANCY_NO")
	public double getPregnancyNo() {
		return this.pregnancyNo;
	}

	public void setPregnancyNo(double pregnancyNo) {
		this.pregnancyNo = pregnancyNo;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="SANMO_BUNMAN_DATE")
	public Date getSanmoBunmanDate() {
		return this.sanmoBunmanDate;
	}

	public void setSanmoBunmanDate(Date sanmoBunmanDate) {
		this.sanmoBunmanDate = sanmoBunmanDate;
	}


	@Column(name="SANMO_BUNMAN_TIME")
	public String getSanmoBunmanTime() {
		return this.sanmoBunmanTime;
	}

	public void setSanmoBunmanTime(String sanmoBunmanTime) {
		this.sanmoBunmanTime = sanmoBunmanTime;
	}


	@Column(name="SANMO_JOB")
	public String getSanmoJob() {
		return this.sanmoJob;
	}

	public void setSanmoJob(String sanmoJob) {
		this.sanmoJob = sanmoJob;
	}


	public double getSanyok() {
		return this.sanyok;
	}

	public void setSanyok(double sanyok) {
		this.sanyok = sanyok;
	}


	@Column(name="START_IPDUK_GUBUN")
	public String getStartIpdukGubun() {
		return this.startIpdukGubun;
	}

	public void setStartIpdukGubun(String startIpdukGubun) {
		this.startIpdukGubun = startIpdukGubun;
	}


	@Column(name="START_IPDUK_YMD")
	public String getStartIpdukYmd() {
		return this.startIpdukYmd;
	}

	public void setStartIpdukYmd(String startIpdukYmd) {
		this.startIpdukYmd = startIpdukYmd;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="START_JINTONG_DATE")
	public Date getStartJintongDate() {
		return this.startJintongDate;
	}

	public void setStartJintongDate(Date startJintongDate) {
		this.startJintongDate = startJintongDate;
	}


	@Column(name="START_JINTONG_TIME")
	public String getStartJintongTime() {
		return this.startJintongTime;
	}

	public void setStartJintongTime(String startJintongTime) {
		this.startJintongTime = startJintongTime;
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
	@Column(name="TAEBAN_MANCHUL_DATE")
	public Date getTaebanManchulDate() {
		return this.taebanManchulDate;
	}

	public void setTaebanManchulDate(Date taebanManchulDate) {
		this.taebanManchulDate = taebanManchulDate;
	}


	@Column(name="TAEBAN_MANCHUL_JAGUNGJU")
	public String getTaebanManchulJagungju() {
		return this.taebanManchulJagungju;
	}

	public void setTaebanManchulJagungju(String taebanManchulJagungju) {
		this.taebanManchulJagungju = taebanManchulJagungju;
	}


	@Column(name="TAEBAN_MANCHUL_SUCHUK_STAT")
	public String getTaebanManchulSuchukStat() {
		return this.taebanManchulSuchukStat;
	}

	public void setTaebanManchulSuchukStat(String taebanManchulSuchukStat) {
		this.taebanManchulSuchukStat = taebanManchulSuchukStat;
	}


	@Column(name="TAEBAN_MANCHUL_TIME")
	public String getTaebanManchulTime() {
		return this.taebanManchulTime;
	}

	public void setTaebanManchulTime(String taebanManchulTime) {
		this.taebanManchulTime = taebanManchulTime;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="TAEDONG_DATE")
	public Date getTaedongDate() {
		return this.taedongDate;
	}

	public void setTaedongDate(Date taedongDate) {
		this.taedongDate = taedongDate;
	}


	public String getTaewi() {
		return this.taewi;
	}

	public void setTaewi(String taewi) {
		this.taewi = taewi;
	}


	@Column(name="TOTAL_BUNHO")
	public double getTotalBunho() {
		return this.totalBunho;
	}

	public void setTotalBunho(double totalBunho) {
		this.totalBunho = totalBunho;
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


	public String getVald() {
		return this.vald;
	}

	public void setVald(String vald) {
		this.vald = vald;
	}


	public String getYangsu() {
		return this.yangsu;
	}

	public void setYangsu(String yangsu) {
		this.yangsu = yangsu;
	}


	public String getYusi() {
		return this.yusi;
	}

	public void setYusi(String yusi) {
		this.yusi = yusi;
	}

}