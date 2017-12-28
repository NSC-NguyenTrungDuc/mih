package nta.med.core.domain.nur;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the NUR5002 database table.
 * 
 */
@Entity
@NamedQuery(name="Nur5002.findAll", query="SELECT n FROM Nur5002 n")
public class Nur5002 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private double apgar11;
	private double apgar110;
	private double apgar15;
	private double apgar21;
	private double apgar210;
	private double apgar25;
	private double apgar31;
	private double apgar310;
	private double apgar35;
	private double apgar41;
	private double apgar410;
	private double apgar45;
	private double apgar51;
	private double apgar510;
	private double apgar55;
	private String babyGubun;
	private String bunho;
	private Date bunmanDate;
	private String bunmanForm;
	private String bunmanTime;
	private double chest;
	private String chuimoYn;
	private String cllete;
	private double daehying;
	private double daekyung;
	private double daekyungJuwi;
	private double dubal;
	private String duhyuljongYn;
	private double dunpokHips;
	private double dunwi;
	private double fkinp1001;
	private double fknur5001;
	private String gangYn;
	private String goljungjuk;
	private String hangmunYn;
	private double height;
	private String hospCode;
	private String jayun;
	private String jedaeBalyukStat;
	private String jedaeBuchakBu;
	private String jedaeKnokYn;
	private double jedaeLength1;
	private double jedaeLength2;
	private double jedaeSansoYang;
	private double jedaeThickness1;
	private double jedaeThickness2;
	private String jedaeYumjun;
	private String jumanYn;
	private double junhoJuwi;
	private double junhoKyungsun;
	private String jusaYn;
	private String kyungap;
	private double largechunmun1;
	private double largechunmun2;
	private String mixmyun;
	private String mochemyun;
	private String mochemyunBunyuk;
	private String mochemyunColor;
	private String mochemyunSukhoachimchak;
	private String mochemyunSumyubihu;
	private String mochemyunWhitekyungsae;
	private String nailYn;
	private String nanmakCompGrade;
	private String nanmakSize;
	private String nanmakYulgu;
	private String outPartYn;
	private String sanhuYn;
	private String sanmodaejangComment;
	private double seq;
	private String sex;
	private double shoulderJuwi;
	private double shoulderWidth;
	private String skinStat;
	private double smallchunmun1;
	private double smallchunmun2;
	private double sohying;
	private double sokyung;
	private double sokyungJuwi;
	private String sungsuk;
	private Date sysDate;
	private String sysId;
	private String taeamyunColor;
	private String taeamyunVeinBynpyu;
	private String taeamyunVeinNojang;
	private String taeamyunYn;
	private String taebanBalyulStat;
	private String taebanCompGrade;
	private String taebanShape;
	private double taebanSize1;
	private double taebanSize2;
	private double taebanSize3;
	private double taebanSize4;
	private double taebanThickness1;
	private double taebanThickness2;
	private String taejiYn;
	private Date updDate;
	private String updId;
	private double weight;
	private String yangmakYn;
	private String yangsulang;
	private String yongsubakli;
	private String yungmomakYn;

	public Nur5002() {
	}


	@Column(name="APGAR1_1")
	public double getApgar11() {
		return this.apgar11;
	}

	public void setApgar11(double apgar11) {
		this.apgar11 = apgar11;
	}


	@Column(name="APGAR1_10")
	public double getApgar110() {
		return this.apgar110;
	}

	public void setApgar110(double apgar110) {
		this.apgar110 = apgar110;
	}


	@Column(name="APGAR1_5")
	public double getApgar15() {
		return this.apgar15;
	}

	public void setApgar15(double apgar15) {
		this.apgar15 = apgar15;
	}


	@Column(name="APGAR2_1")
	public double getApgar21() {
		return this.apgar21;
	}

	public void setApgar21(double apgar21) {
		this.apgar21 = apgar21;
	}


	@Column(name="APGAR2_10")
	public double getApgar210() {
		return this.apgar210;
	}

	public void setApgar210(double apgar210) {
		this.apgar210 = apgar210;
	}


	@Column(name="APGAR2_5")
	public double getApgar25() {
		return this.apgar25;
	}

	public void setApgar25(double apgar25) {
		this.apgar25 = apgar25;
	}


	@Column(name="APGAR3_1")
	public double getApgar31() {
		return this.apgar31;
	}

	public void setApgar31(double apgar31) {
		this.apgar31 = apgar31;
	}


	@Column(name="APGAR3_10")
	public double getApgar310() {
		return this.apgar310;
	}

	public void setApgar310(double apgar310) {
		this.apgar310 = apgar310;
	}


	@Column(name="APGAR3_5")
	public double getApgar35() {
		return this.apgar35;
	}

	public void setApgar35(double apgar35) {
		this.apgar35 = apgar35;
	}


	@Column(name="APGAR4_1")
	public double getApgar41() {
		return this.apgar41;
	}

	public void setApgar41(double apgar41) {
		this.apgar41 = apgar41;
	}


	@Column(name="APGAR4_10")
	public double getApgar410() {
		return this.apgar410;
	}

	public void setApgar410(double apgar410) {
		this.apgar410 = apgar410;
	}


	@Column(name="APGAR4_5")
	public double getApgar45() {
		return this.apgar45;
	}

	public void setApgar45(double apgar45) {
		this.apgar45 = apgar45;
	}


	@Column(name="APGAR5_1")
	public double getApgar51() {
		return this.apgar51;
	}

	public void setApgar51(double apgar51) {
		this.apgar51 = apgar51;
	}


	@Column(name="APGAR5_10")
	public double getApgar510() {
		return this.apgar510;
	}

	public void setApgar510(double apgar510) {
		this.apgar510 = apgar510;
	}


	@Column(name="APGAR5_5")
	public double getApgar55() {
		return this.apgar55;
	}

	public void setApgar55(double apgar55) {
		this.apgar55 = apgar55;
	}


	@Column(name="BABY_GUBUN")
	public String getBabyGubun() {
		return this.babyGubun;
	}

	public void setBabyGubun(String babyGubun) {
		this.babyGubun = babyGubun;
	}


	public String getBunho() {
		return this.bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="BUNMAN_DATE")
	public Date getBunmanDate() {
		return this.bunmanDate;
	}

	public void setBunmanDate(Date bunmanDate) {
		this.bunmanDate = bunmanDate;
	}


	@Column(name="BUNMAN_FORM")
	public String getBunmanForm() {
		return this.bunmanForm;
	}

	public void setBunmanForm(String bunmanForm) {
		this.bunmanForm = bunmanForm;
	}


	@Column(name="BUNMAN_TIME")
	public String getBunmanTime() {
		return this.bunmanTime;
	}

	public void setBunmanTime(String bunmanTime) {
		this.bunmanTime = bunmanTime;
	}


	public double getChest() {
		return this.chest;
	}

	public void setChest(double chest) {
		this.chest = chest;
	}


	@Column(name="CHUIMO_YN")
	public String getChuimoYn() {
		return this.chuimoYn;
	}

	public void setChuimoYn(String chuimoYn) {
		this.chuimoYn = chuimoYn;
	}


	public String getCllete() {
		return this.cllete;
	}

	public void setCllete(String cllete) {
		this.cllete = cllete;
	}


	public double getDaehying() {
		return this.daehying;
	}

	public void setDaehying(double daehying) {
		this.daehying = daehying;
	}


	public double getDaekyung() {
		return this.daekyung;
	}

	public void setDaekyung(double daekyung) {
		this.daekyung = daekyung;
	}


	@Column(name="DAEKYUNG_JUWI")
	public double getDaekyungJuwi() {
		return this.daekyungJuwi;
	}

	public void setDaekyungJuwi(double daekyungJuwi) {
		this.daekyungJuwi = daekyungJuwi;
	}


	public double getDubal() {
		return this.dubal;
	}

	public void setDubal(double dubal) {
		this.dubal = dubal;
	}


	@Column(name="DUHYULJONG_YN")
	public String getDuhyuljongYn() {
		return this.duhyuljongYn;
	}

	public void setDuhyuljongYn(String duhyuljongYn) {
		this.duhyuljongYn = duhyuljongYn;
	}


	@Column(name="DUNPOK_HIPS")
	public double getDunpokHips() {
		return this.dunpokHips;
	}

	public void setDunpokHips(double dunpokHips) {
		this.dunpokHips = dunpokHips;
	}


	public double getDunwi() {
		return this.dunwi;
	}

	public void setDunwi(double dunwi) {
		this.dunwi = dunwi;
	}


	public double getFkinp1001() {
		return this.fkinp1001;
	}

	public void setFkinp1001(double fkinp1001) {
		this.fkinp1001 = fkinp1001;
	}


	public double getFknur5001() {
		return this.fknur5001;
	}

	public void setFknur5001(double fknur5001) {
		this.fknur5001 = fknur5001;
	}


	@Column(name="GANG_YN")
	public String getGangYn() {
		return this.gangYn;
	}

	public void setGangYn(String gangYn) {
		this.gangYn = gangYn;
	}


	public String getGoljungjuk() {
		return this.goljungjuk;
	}

	public void setGoljungjuk(String goljungjuk) {
		this.goljungjuk = goljungjuk;
	}


	@Column(name="HANGMUN_YN")
	public String getHangmunYn() {
		return this.hangmunYn;
	}

	public void setHangmunYn(String hangmunYn) {
		this.hangmunYn = hangmunYn;
	}


	public double getHeight() {
		return this.height;
	}

	public void setHeight(double height) {
		this.height = height;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	public String getJayun() {
		return this.jayun;
	}

	public void setJayun(String jayun) {
		this.jayun = jayun;
	}


	@Column(name="JEDAE_BALYUK_STAT")
	public String getJedaeBalyukStat() {
		return this.jedaeBalyukStat;
	}

	public void setJedaeBalyukStat(String jedaeBalyukStat) {
		this.jedaeBalyukStat = jedaeBalyukStat;
	}


	@Column(name="JEDAE_BUCHAK_BU")
	public String getJedaeBuchakBu() {
		return this.jedaeBuchakBu;
	}

	public void setJedaeBuchakBu(String jedaeBuchakBu) {
		this.jedaeBuchakBu = jedaeBuchakBu;
	}


	@Column(name="JEDAE_KNOK_YN")
	public String getJedaeKnokYn() {
		return this.jedaeKnokYn;
	}

	public void setJedaeKnokYn(String jedaeKnokYn) {
		this.jedaeKnokYn = jedaeKnokYn;
	}


	@Column(name="JEDAE_LENGTH1")
	public double getJedaeLength1() {
		return this.jedaeLength1;
	}

	public void setJedaeLength1(double jedaeLength1) {
		this.jedaeLength1 = jedaeLength1;
	}


	@Column(name="JEDAE_LENGTH2")
	public double getJedaeLength2() {
		return this.jedaeLength2;
	}

	public void setJedaeLength2(double jedaeLength2) {
		this.jedaeLength2 = jedaeLength2;
	}


	@Column(name="JEDAE_SANSO_YANG")
	public double getJedaeSansoYang() {
		return this.jedaeSansoYang;
	}

	public void setJedaeSansoYang(double jedaeSansoYang) {
		this.jedaeSansoYang = jedaeSansoYang;
	}


	@Column(name="JEDAE_THICKNESS1")
	public double getJedaeThickness1() {
		return this.jedaeThickness1;
	}

	public void setJedaeThickness1(double jedaeThickness1) {
		this.jedaeThickness1 = jedaeThickness1;
	}


	@Column(name="JEDAE_THICKNESS2")
	public double getJedaeThickness2() {
		return this.jedaeThickness2;
	}

	public void setJedaeThickness2(double jedaeThickness2) {
		this.jedaeThickness2 = jedaeThickness2;
	}


	@Column(name="JEDAE_YUMJUN")
	public String getJedaeYumjun() {
		return this.jedaeYumjun;
	}

	public void setJedaeYumjun(String jedaeYumjun) {
		this.jedaeYumjun = jedaeYumjun;
	}


	@Column(name="JUMAN_YN")
	public String getJumanYn() {
		return this.jumanYn;
	}

	public void setJumanYn(String jumanYn) {
		this.jumanYn = jumanYn;
	}


	@Column(name="JUNHO_JUWI")
	public double getJunhoJuwi() {
		return this.junhoJuwi;
	}

	public void setJunhoJuwi(double junhoJuwi) {
		this.junhoJuwi = junhoJuwi;
	}


	@Column(name="JUNHO_KYUNGSUN")
	public double getJunhoKyungsun() {
		return this.junhoKyungsun;
	}

	public void setJunhoKyungsun(double junhoKyungsun) {
		this.junhoKyungsun = junhoKyungsun;
	}


	@Column(name="JUSA_YN")
	public String getJusaYn() {
		return this.jusaYn;
	}

	public void setJusaYn(String jusaYn) {
		this.jusaYn = jusaYn;
	}


	public String getKyungap() {
		return this.kyungap;
	}

	public void setKyungap(String kyungap) {
		this.kyungap = kyungap;
	}


	public double getLargechunmun1() {
		return this.largechunmun1;
	}

	public void setLargechunmun1(double largechunmun1) {
		this.largechunmun1 = largechunmun1;
	}


	public double getLargechunmun2() {
		return this.largechunmun2;
	}

	public void setLargechunmun2(double largechunmun2) {
		this.largechunmun2 = largechunmun2;
	}


	public String getMixmyun() {
		return this.mixmyun;
	}

	public void setMixmyun(String mixmyun) {
		this.mixmyun = mixmyun;
	}


	public String getMochemyun() {
		return this.mochemyun;
	}

	public void setMochemyun(String mochemyun) {
		this.mochemyun = mochemyun;
	}


	@Column(name="MOCHEMYUN_BUNYUK")
	public String getMochemyunBunyuk() {
		return this.mochemyunBunyuk;
	}

	public void setMochemyunBunyuk(String mochemyunBunyuk) {
		this.mochemyunBunyuk = mochemyunBunyuk;
	}


	@Column(name="MOCHEMYUN_COLOR")
	public String getMochemyunColor() {
		return this.mochemyunColor;
	}

	public void setMochemyunColor(String mochemyunColor) {
		this.mochemyunColor = mochemyunColor;
	}


	@Column(name="MOCHEMYUN_SUKHOACHIMCHAK")
	public String getMochemyunSukhoachimchak() {
		return this.mochemyunSukhoachimchak;
	}

	public void setMochemyunSukhoachimchak(String mochemyunSukhoachimchak) {
		this.mochemyunSukhoachimchak = mochemyunSukhoachimchak;
	}


	@Column(name="MOCHEMYUN_SUMYUBIHU")
	public String getMochemyunSumyubihu() {
		return this.mochemyunSumyubihu;
	}

	public void setMochemyunSumyubihu(String mochemyunSumyubihu) {
		this.mochemyunSumyubihu = mochemyunSumyubihu;
	}


	@Column(name="MOCHEMYUN_WHITEKYUNGSAE")
	public String getMochemyunWhitekyungsae() {
		return this.mochemyunWhitekyungsae;
	}

	public void setMochemyunWhitekyungsae(String mochemyunWhitekyungsae) {
		this.mochemyunWhitekyungsae = mochemyunWhitekyungsae;
	}


	@Column(name="NAIL_YN")
	public String getNailYn() {
		return this.nailYn;
	}

	public void setNailYn(String nailYn) {
		this.nailYn = nailYn;
	}


	@Column(name="NANMAK_COMP_GRADE")
	public String getNanmakCompGrade() {
		return this.nanmakCompGrade;
	}

	public void setNanmakCompGrade(String nanmakCompGrade) {
		this.nanmakCompGrade = nanmakCompGrade;
	}


	@Column(name="NANMAK_SIZE")
	public String getNanmakSize() {
		return this.nanmakSize;
	}

	public void setNanmakSize(String nanmakSize) {
		this.nanmakSize = nanmakSize;
	}


	@Column(name="NANMAK_YULGU")
	public String getNanmakYulgu() {
		return this.nanmakYulgu;
	}

	public void setNanmakYulgu(String nanmakYulgu) {
		this.nanmakYulgu = nanmakYulgu;
	}


	@Column(name="OUT_PART_YN")
	public String getOutPartYn() {
		return this.outPartYn;
	}

	public void setOutPartYn(String outPartYn) {
		this.outPartYn = outPartYn;
	}


	@Column(name="SANHU_YN")
	public String getSanhuYn() {
		return this.sanhuYn;
	}

	public void setSanhuYn(String sanhuYn) {
		this.sanhuYn = sanhuYn;
	}


	@Column(name="SANMODAEJANG_COMMENT")
	public String getSanmodaejangComment() {
		return this.sanmodaejangComment;
	}

	public void setSanmodaejangComment(String sanmodaejangComment) {
		this.sanmodaejangComment = sanmodaejangComment;
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


	@Column(name="SHOULDER_JUWI")
	public double getShoulderJuwi() {
		return this.shoulderJuwi;
	}

	public void setShoulderJuwi(double shoulderJuwi) {
		this.shoulderJuwi = shoulderJuwi;
	}


	@Column(name="SHOULDER_WIDTH")
	public double getShoulderWidth() {
		return this.shoulderWidth;
	}

	public void setShoulderWidth(double shoulderWidth) {
		this.shoulderWidth = shoulderWidth;
	}


	@Column(name="SKIN_STAT")
	public String getSkinStat() {
		return this.skinStat;
	}

	public void setSkinStat(String skinStat) {
		this.skinStat = skinStat;
	}


	public double getSmallchunmun1() {
		return this.smallchunmun1;
	}

	public void setSmallchunmun1(double smallchunmun1) {
		this.smallchunmun1 = smallchunmun1;
	}


	public double getSmallchunmun2() {
		return this.smallchunmun2;
	}

	public void setSmallchunmun2(double smallchunmun2) {
		this.smallchunmun2 = smallchunmun2;
	}


	public double getSohying() {
		return this.sohying;
	}

	public void setSohying(double sohying) {
		this.sohying = sohying;
	}


	public double getSokyung() {
		return this.sokyung;
	}

	public void setSokyung(double sokyung) {
		this.sokyung = sokyung;
	}


	@Column(name="SOKYUNG_JUWI")
	public double getSokyungJuwi() {
		return this.sokyungJuwi;
	}

	public void setSokyungJuwi(double sokyungJuwi) {
		this.sokyungJuwi = sokyungJuwi;
	}


	public String getSungsuk() {
		return this.sungsuk;
	}

	public void setSungsuk(String sungsuk) {
		this.sungsuk = sungsuk;
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


	@Column(name="TAEAMYUN_COLOR")
	public String getTaeamyunColor() {
		return this.taeamyunColor;
	}

	public void setTaeamyunColor(String taeamyunColor) {
		this.taeamyunColor = taeamyunColor;
	}


	@Column(name="TAEAMYUN_VEIN_BYNPYU")
	public String getTaeamyunVeinBynpyu() {
		return this.taeamyunVeinBynpyu;
	}

	public void setTaeamyunVeinBynpyu(String taeamyunVeinBynpyu) {
		this.taeamyunVeinBynpyu = taeamyunVeinBynpyu;
	}


	@Column(name="TAEAMYUN_VEIN_NOJANG")
	public String getTaeamyunVeinNojang() {
		return this.taeamyunVeinNojang;
	}

	public void setTaeamyunVeinNojang(String taeamyunVeinNojang) {
		this.taeamyunVeinNojang = taeamyunVeinNojang;
	}


	@Column(name="TAEAMYUN_YN")
	public String getTaeamyunYn() {
		return this.taeamyunYn;
	}

	public void setTaeamyunYn(String taeamyunYn) {
		this.taeamyunYn = taeamyunYn;
	}


	@Column(name="TAEBAN_BALYUL_STAT")
	public String getTaebanBalyulStat() {
		return this.taebanBalyulStat;
	}

	public void setTaebanBalyulStat(String taebanBalyulStat) {
		this.taebanBalyulStat = taebanBalyulStat;
	}


	@Column(name="TAEBAN_COMP_GRADE")
	public String getTaebanCompGrade() {
		return this.taebanCompGrade;
	}

	public void setTaebanCompGrade(String taebanCompGrade) {
		this.taebanCompGrade = taebanCompGrade;
	}


	@Column(name="TAEBAN_SHAPE")
	public String getTaebanShape() {
		return this.taebanShape;
	}

	public void setTaebanShape(String taebanShape) {
		this.taebanShape = taebanShape;
	}


	@Column(name="TAEBAN_SIZE1")
	public double getTaebanSize1() {
		return this.taebanSize1;
	}

	public void setTaebanSize1(double taebanSize1) {
		this.taebanSize1 = taebanSize1;
	}


	@Column(name="TAEBAN_SIZE2")
	public double getTaebanSize2() {
		return this.taebanSize2;
	}

	public void setTaebanSize2(double taebanSize2) {
		this.taebanSize2 = taebanSize2;
	}


	@Column(name="TAEBAN_SIZE3")
	public double getTaebanSize3() {
		return this.taebanSize3;
	}

	public void setTaebanSize3(double taebanSize3) {
		this.taebanSize3 = taebanSize3;
	}


	@Column(name="TAEBAN_SIZE4")
	public double getTaebanSize4() {
		return this.taebanSize4;
	}

	public void setTaebanSize4(double taebanSize4) {
		this.taebanSize4 = taebanSize4;
	}


	@Column(name="TAEBAN_THICKNESS1")
	public double getTaebanThickness1() {
		return this.taebanThickness1;
	}

	public void setTaebanThickness1(double taebanThickness1) {
		this.taebanThickness1 = taebanThickness1;
	}


	@Column(name="TAEBAN_THICKNESS2")
	public double getTaebanThickness2() {
		return this.taebanThickness2;
	}

	public void setTaebanThickness2(double taebanThickness2) {
		this.taebanThickness2 = taebanThickness2;
	}


	@Column(name="TAEJI_YN")
	public String getTaejiYn() {
		return this.taejiYn;
	}

	public void setTaejiYn(String taejiYn) {
		this.taejiYn = taejiYn;
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


	public double getWeight() {
		return this.weight;
	}

	public void setWeight(double weight) {
		this.weight = weight;
	}


	@Column(name="YANGMAK_YN")
	public String getYangmakYn() {
		return this.yangmakYn;
	}

	public void setYangmakYn(String yangmakYn) {
		this.yangmakYn = yangmakYn;
	}


	public String getYangsulang() {
		return this.yangsulang;
	}

	public void setYangsulang(String yangsulang) {
		this.yangsulang = yangsulang;
	}


	public String getYongsubakli() {
		return this.yongsubakli;
	}

	public void setYongsubakli(String yongsubakli) {
		this.yongsubakli = yongsubakli;
	}


	@Column(name="YUNGMOMAK_YN")
	public String getYungmomakYn() {
		return this.yungmomakYn;
	}

	public void setYungmomakYn(String yungmomakYn) {
		this.yungmomakYn = yungmomakYn;
	}

}