package nta.med.core.domain.out;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the OUT2011 database table.
 * 
 */
@Entity
@NamedQuery(name="Out2011.findAll", query="SELECT o FROM Out2011 o")
public class Out2011 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String actDoctor;
	private String actGwa;
	private Date actingDate;
	private double amt;
	private String amtGubun;
	private String antiCancerYn;
	private String autoYn;
	private String baebanYn;
	private double billCnt;
	private String bogyongCode;
	private double bonRate;
	private String bunCode;
	private String bunho;
	private String changgu;
	private String chegamYn;
	private Date chungguDate;
	private double danga;
	private String danui;
	private double disAmt;
	private double disSpeAmt;
	private String doctor;
	private double dv;
	private String dvTime;
	private String emergency;
	private String etcGasanYn;
	private String fkbil1001;
	private double fkinp2001;
	private double fkocs1003;
	private String fkout1001;
	private double fkout1003;
	private double fkout2000;
	private double fkout2002;
	private String fluidYn;
	private double gasanSourceKey;
	private String gisul;
	private double gongbiAmt;
	private String gongbiCode;
	private double gongbiPoint;
	private double groupSer;
	private String gubun;
	private String gubunTransYn;
	private String gwa;
	private String handoYn;
	private String hospCode;
	private double hunabAmt;
	private double hunabSpeAmt;
	private String inpTransYn;
	private String jaeryoProYn;
	private String jinryoGubun;
	private Date junpyoDate;
	private String jusa;
	private double lftRate;
	private String mainSanYn;
	private String marumeYn;
	private String muhyo;
	private double nalsu;
	private String nuCode;
	private Date orderDate;
	private String outFixAmtYn;
	private String pay;
	private double pkout2001;
	private String pogwalYn;
	private double point;
	private double pointDanga;
	private String recordGubun;
	private double seq;
	private double ser;
	private String sgCode;
	private Date sgYmd;
	private String soa;
	private String sourceBun;
	private String sourceNu;
	private double sourcePkout2001;
	private String sourceSg;
	private double specialAmt;
	private double specialDanga;
	private double specialRate;
	private String specialYn;
	private String subSusul;
	private String subsusulYn;
	private String sunabDanui;
	private double sunabNalsu;
	private double sunabSuryang;
	private String sunabTime;
	private double suryang;
	private String susuryoGubun;
	private String sutakYn;
	private String symya;
	private String symyaGubun;
	private Date sysDate;
	private String sysId;
	private double taxAmt;
	private String tpnYn;
	private String updChanggu;
	private Date updDate;
	private String updId;
	private Date updJunpyoDate;
	private String wonnaeSayuCode;
	private String wonyoiOrderYn;

	public Out2011() {
	}


	@Column(name="ACT_DOCTOR")
	public String getActDoctor() {
		return this.actDoctor;
	}

	public void setActDoctor(String actDoctor) {
		this.actDoctor = actDoctor;
	}


	@Column(name="ACT_GWA")
	public String getActGwa() {
		return this.actGwa;
	}

	public void setActGwa(String actGwa) {
		this.actGwa = actGwa;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="ACTING_DATE")
	public Date getActingDate() {
		return this.actingDate;
	}

	public void setActingDate(Date actingDate) {
		this.actingDate = actingDate;
	}


	public double getAmt() {
		return this.amt;
	}

	public void setAmt(double amt) {
		this.amt = amt;
	}


	@Column(name="AMT_GUBUN")
	public String getAmtGubun() {
		return this.amtGubun;
	}

	public void setAmtGubun(String amtGubun) {
		this.amtGubun = amtGubun;
	}


	@Column(name="ANTI_CANCER_YN")
	public String getAntiCancerYn() {
		return this.antiCancerYn;
	}

	public void setAntiCancerYn(String antiCancerYn) {
		this.antiCancerYn = antiCancerYn;
	}


	@Column(name="AUTO_YN")
	public String getAutoYn() {
		return this.autoYn;
	}

	public void setAutoYn(String autoYn) {
		this.autoYn = autoYn;
	}


	@Column(name="BAEBAN_YN")
	public String getBaebanYn() {
		return this.baebanYn;
	}

	public void setBaebanYn(String baebanYn) {
		this.baebanYn = baebanYn;
	}


	@Column(name="BILL_CNT")
	public double getBillCnt() {
		return this.billCnt;
	}

	public void setBillCnt(double billCnt) {
		this.billCnt = billCnt;
	}


	@Column(name="BOGYONG_CODE")
	public String getBogyongCode() {
		return this.bogyongCode;
	}

	public void setBogyongCode(String bogyongCode) {
		this.bogyongCode = bogyongCode;
	}


	@Column(name="BON_RATE")
	public double getBonRate() {
		return this.bonRate;
	}

	public void setBonRate(double bonRate) {
		this.bonRate = bonRate;
	}


	@Column(name="BUN_CODE")
	public String getBunCode() {
		return this.bunCode;
	}

	public void setBunCode(String bunCode) {
		this.bunCode = bunCode;
	}


	public String getBunho() {
		return this.bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}


	public String getChanggu() {
		return this.changgu;
	}

	public void setChanggu(String changgu) {
		this.changgu = changgu;
	}


	@Column(name="CHEGAM_YN")
	public String getChegamYn() {
		return this.chegamYn;
	}

	public void setChegamYn(String chegamYn) {
		this.chegamYn = chegamYn;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="CHUNGGU_DATE")
	public Date getChungguDate() {
		return this.chungguDate;
	}

	public void setChungguDate(Date chungguDate) {
		this.chungguDate = chungguDate;
	}


	public double getDanga() {
		return this.danga;
	}

	public void setDanga(double danga) {
		this.danga = danga;
	}


	public String getDanui() {
		return this.danui;
	}

	public void setDanui(String danui) {
		this.danui = danui;
	}


	@Column(name="DIS_AMT")
	public double getDisAmt() {
		return this.disAmt;
	}

	public void setDisAmt(double disAmt) {
		this.disAmt = disAmt;
	}


	@Column(name="DIS_SPE_AMT")
	public double getDisSpeAmt() {
		return this.disSpeAmt;
	}

	public void setDisSpeAmt(double disSpeAmt) {
		this.disSpeAmt = disSpeAmt;
	}


	public String getDoctor() {
		return this.doctor;
	}

	public void setDoctor(String doctor) {
		this.doctor = doctor;
	}


	public double getDv() {
		return this.dv;
	}

	public void setDv(double dv) {
		this.dv = dv;
	}


	@Column(name="DV_TIME")
	public String getDvTime() {
		return this.dvTime;
	}

	public void setDvTime(String dvTime) {
		this.dvTime = dvTime;
	}


	public String getEmergency() {
		return this.emergency;
	}

	public void setEmergency(String emergency) {
		this.emergency = emergency;
	}


	@Column(name="ETC_GASAN_YN")
	public String getEtcGasanYn() {
		return this.etcGasanYn;
	}

	public void setEtcGasanYn(String etcGasanYn) {
		this.etcGasanYn = etcGasanYn;
	}


	public String getFkbil1001() {
		return this.fkbil1001;
	}

	public void setFkbil1001(String fkbil1001) {
		this.fkbil1001 = fkbil1001;
	}


	public double getFkinp2001() {
		return this.fkinp2001;
	}

	public void setFkinp2001(double fkinp2001) {
		this.fkinp2001 = fkinp2001;
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


	public double getFkout1003() {
		return this.fkout1003;
	}

	public void setFkout1003(double fkout1003) {
		this.fkout1003 = fkout1003;
	}


	public double getFkout2000() {
		return this.fkout2000;
	}

	public void setFkout2000(double fkout2000) {
		this.fkout2000 = fkout2000;
	}


	public double getFkout2002() {
		return this.fkout2002;
	}

	public void setFkout2002(double fkout2002) {
		this.fkout2002 = fkout2002;
	}


	@Column(name="FLUID_YN")
	public String getFluidYn() {
		return this.fluidYn;
	}

	public void setFluidYn(String fluidYn) {
		this.fluidYn = fluidYn;
	}


	@Column(name="GASAN_SOURCE_KEY")
	public double getGasanSourceKey() {
		return this.gasanSourceKey;
	}

	public void setGasanSourceKey(double gasanSourceKey) {
		this.gasanSourceKey = gasanSourceKey;
	}


	public String getGisul() {
		return this.gisul;
	}

	public void setGisul(String gisul) {
		this.gisul = gisul;
	}


	@Column(name="GONGBI_AMT")
	public double getGongbiAmt() {
		return this.gongbiAmt;
	}

	public void setGongbiAmt(double gongbiAmt) {
		this.gongbiAmt = gongbiAmt;
	}


	@Column(name="GONGBI_CODE")
	public String getGongbiCode() {
		return this.gongbiCode;
	}

	public void setGongbiCode(String gongbiCode) {
		this.gongbiCode = gongbiCode;
	}


	@Column(name="GONGBI_POINT")
	public double getGongbiPoint() {
		return this.gongbiPoint;
	}

	public void setGongbiPoint(double gongbiPoint) {
		this.gongbiPoint = gongbiPoint;
	}


	@Column(name="GROUP_SER")
	public double getGroupSer() {
		return this.groupSer;
	}

	public void setGroupSer(double groupSer) {
		this.groupSer = groupSer;
	}


	public String getGubun() {
		return this.gubun;
	}

	public void setGubun(String gubun) {
		this.gubun = gubun;
	}


	@Column(name="GUBUN_TRANS_YN")
	public String getGubunTransYn() {
		return this.gubunTransYn;
	}

	public void setGubunTransYn(String gubunTransYn) {
		this.gubunTransYn = gubunTransYn;
	}


	public String getGwa() {
		return this.gwa;
	}

	public void setGwa(String gwa) {
		this.gwa = gwa;
	}


	@Column(name="HANDO_YN")
	public String getHandoYn() {
		return this.handoYn;
	}

	public void setHandoYn(String handoYn) {
		this.handoYn = handoYn;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="HUNAB_AMT")
	public double getHunabAmt() {
		return this.hunabAmt;
	}

	public void setHunabAmt(double hunabAmt) {
		this.hunabAmt = hunabAmt;
	}


	@Column(name="HUNAB_SPE_AMT")
	public double getHunabSpeAmt() {
		return this.hunabSpeAmt;
	}

	public void setHunabSpeAmt(double hunabSpeAmt) {
		this.hunabSpeAmt = hunabSpeAmt;
	}


	@Column(name="INP_TRANS_YN")
	public String getInpTransYn() {
		return this.inpTransYn;
	}

	public void setInpTransYn(String inpTransYn) {
		this.inpTransYn = inpTransYn;
	}


	@Column(name="JAERYO_PRO_YN")
	public String getJaeryoProYn() {
		return this.jaeryoProYn;
	}

	public void setJaeryoProYn(String jaeryoProYn) {
		this.jaeryoProYn = jaeryoProYn;
	}


	@Column(name="JINRYO_GUBUN")
	public String getJinryoGubun() {
		return this.jinryoGubun;
	}

	public void setJinryoGubun(String jinryoGubun) {
		this.jinryoGubun = jinryoGubun;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="JUNPYO_DATE")
	public Date getJunpyoDate() {
		return this.junpyoDate;
	}

	public void setJunpyoDate(Date junpyoDate) {
		this.junpyoDate = junpyoDate;
	}


	public String getJusa() {
		return this.jusa;
	}

	public void setJusa(String jusa) {
		this.jusa = jusa;
	}


	@Column(name="LFT_RATE")
	public double getLftRate() {
		return this.lftRate;
	}

	public void setLftRate(double lftRate) {
		this.lftRate = lftRate;
	}


	@Column(name="MAIN_SAN_YN")
	public String getMainSanYn() {
		return this.mainSanYn;
	}

	public void setMainSanYn(String mainSanYn) {
		this.mainSanYn = mainSanYn;
	}


	@Column(name="MARUME_YN")
	public String getMarumeYn() {
		return this.marumeYn;
	}

	public void setMarumeYn(String marumeYn) {
		this.marumeYn = marumeYn;
	}


	public String getMuhyo() {
		return this.muhyo;
	}

	public void setMuhyo(String muhyo) {
		this.muhyo = muhyo;
	}


	public double getNalsu() {
		return this.nalsu;
	}

	public void setNalsu(double nalsu) {
		this.nalsu = nalsu;
	}


	@Column(name="NU_CODE")
	public String getNuCode() {
		return this.nuCode;
	}

	public void setNuCode(String nuCode) {
		this.nuCode = nuCode;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="ORDER_DATE")
	public Date getOrderDate() {
		return this.orderDate;
	}

	public void setOrderDate(Date orderDate) {
		this.orderDate = orderDate;
	}


	@Column(name="OUT_FIX_AMT_YN")
	public String getOutFixAmtYn() {
		return this.outFixAmtYn;
	}

	public void setOutFixAmtYn(String outFixAmtYn) {
		this.outFixAmtYn = outFixAmtYn;
	}


	public String getPay() {
		return this.pay;
	}

	public void setPay(String pay) {
		this.pay = pay;
	}


	public double getPkout2001() {
		return this.pkout2001;
	}

	public void setPkout2001(double pkout2001) {
		this.pkout2001 = pkout2001;
	}


	@Column(name="POGWAL_YN")
	public String getPogwalYn() {
		return this.pogwalYn;
	}

	public void setPogwalYn(String pogwalYn) {
		this.pogwalYn = pogwalYn;
	}


	public double getPoint() {
		return this.point;
	}

	public void setPoint(double point) {
		this.point = point;
	}


	@Column(name="POINT_DANGA")
	public double getPointDanga() {
		return this.pointDanga;
	}

	public void setPointDanga(double pointDanga) {
		this.pointDanga = pointDanga;
	}


	@Column(name="RECORD_GUBUN")
	public String getRecordGubun() {
		return this.recordGubun;
	}

	public void setRecordGubun(String recordGubun) {
		this.recordGubun = recordGubun;
	}


	public double getSeq() {
		return this.seq;
	}

	public void setSeq(double seq) {
		this.seq = seq;
	}


	public double getSer() {
		return this.ser;
	}

	public void setSer(double ser) {
		this.ser = ser;
	}


	@Column(name="SG_CODE")
	public String getSgCode() {
		return this.sgCode;
	}

	public void setSgCode(String sgCode) {
		this.sgCode = sgCode;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="SG_YMD")
	public Date getSgYmd() {
		return this.sgYmd;
	}

	public void setSgYmd(Date sgYmd) {
		this.sgYmd = sgYmd;
	}


	public String getSoa() {
		return this.soa;
	}

	public void setSoa(String soa) {
		this.soa = soa;
	}


	@Column(name="SOURCE_BUN")
	public String getSourceBun() {
		return this.sourceBun;
	}

	public void setSourceBun(String sourceBun) {
		this.sourceBun = sourceBun;
	}


	@Column(name="SOURCE_NU")
	public String getSourceNu() {
		return this.sourceNu;
	}

	public void setSourceNu(String sourceNu) {
		this.sourceNu = sourceNu;
	}


	@Column(name="SOURCE_PKOUT2001")
	public double getSourcePkout2001() {
		return this.sourcePkout2001;
	}

	public void setSourcePkout2001(double sourcePkout2001) {
		this.sourcePkout2001 = sourcePkout2001;
	}


	@Column(name="SOURCE_SG")
	public String getSourceSg() {
		return this.sourceSg;
	}

	public void setSourceSg(String sourceSg) {
		this.sourceSg = sourceSg;
	}


	@Column(name="SPECIAL_AMT")
	public double getSpecialAmt() {
		return this.specialAmt;
	}

	public void setSpecialAmt(double specialAmt) {
		this.specialAmt = specialAmt;
	}


	@Column(name="SPECIAL_DANGA")
	public double getSpecialDanga() {
		return this.specialDanga;
	}

	public void setSpecialDanga(double specialDanga) {
		this.specialDanga = specialDanga;
	}


	@Column(name="SPECIAL_RATE")
	public double getSpecialRate() {
		return this.specialRate;
	}

	public void setSpecialRate(double specialRate) {
		this.specialRate = specialRate;
	}


	@Column(name="SPECIAL_YN")
	public String getSpecialYn() {
		return this.specialYn;
	}

	public void setSpecialYn(String specialYn) {
		this.specialYn = specialYn;
	}


	@Column(name="SUB_SUSUL")
	public String getSubSusul() {
		return this.subSusul;
	}

	public void setSubSusul(String subSusul) {
		this.subSusul = subSusul;
	}


	@Column(name="SUBSUSUL_YN")
	public String getSubsusulYn() {
		return this.subsusulYn;
	}

	public void setSubsusulYn(String subsusulYn) {
		this.subsusulYn = subsusulYn;
	}


	@Column(name="SUNAB_DANUI")
	public String getSunabDanui() {
		return this.sunabDanui;
	}

	public void setSunabDanui(String sunabDanui) {
		this.sunabDanui = sunabDanui;
	}


	@Column(name="SUNAB_NALSU")
	public double getSunabNalsu() {
		return this.sunabNalsu;
	}

	public void setSunabNalsu(double sunabNalsu) {
		this.sunabNalsu = sunabNalsu;
	}


	@Column(name="SUNAB_SURYANG")
	public double getSunabSuryang() {
		return this.sunabSuryang;
	}

	public void setSunabSuryang(double sunabSuryang) {
		this.sunabSuryang = sunabSuryang;
	}


	@Column(name="SUNAB_TIME")
	public String getSunabTime() {
		return this.sunabTime;
	}

	public void setSunabTime(String sunabTime) {
		this.sunabTime = sunabTime;
	}


	public double getSuryang() {
		return this.suryang;
	}

	public void setSuryang(double suryang) {
		this.suryang = suryang;
	}


	@Column(name="SUSURYO_GUBUN")
	public String getSusuryoGubun() {
		return this.susuryoGubun;
	}

	public void setSusuryoGubun(String susuryoGubun) {
		this.susuryoGubun = susuryoGubun;
	}


	@Column(name="SUTAK_YN")
	public String getSutakYn() {
		return this.sutakYn;
	}

	public void setSutakYn(String sutakYn) {
		this.sutakYn = sutakYn;
	}


	public String getSymya() {
		return this.symya;
	}

	public void setSymya(String symya) {
		this.symya = symya;
	}


	@Column(name="SYMYA_GUBUN")
	public String getSymyaGubun() {
		return this.symyaGubun;
	}

	public void setSymyaGubun(String symyaGubun) {
		this.symyaGubun = symyaGubun;
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


	@Column(name="TAX_AMT")
	public double getTaxAmt() {
		return this.taxAmt;
	}

	public void setTaxAmt(double taxAmt) {
		this.taxAmt = taxAmt;
	}


	@Column(name="TPN_YN")
	public String getTpnYn() {
		return this.tpnYn;
	}

	public void setTpnYn(String tpnYn) {
		this.tpnYn = tpnYn;
	}


	@Column(name="UPD_CHANGGU")
	public String getUpdChanggu() {
		return this.updChanggu;
	}

	public void setUpdChanggu(String updChanggu) {
		this.updChanggu = updChanggu;
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


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="UPD_JUNPYO_DATE")
	public Date getUpdJunpyoDate() {
		return this.updJunpyoDate;
	}

	public void setUpdJunpyoDate(Date updJunpyoDate) {
		this.updJunpyoDate = updJunpyoDate;
	}


	@Column(name="WONNAE_SAYU_CODE")
	public String getWonnaeSayuCode() {
		return this.wonnaeSayuCode;
	}

	public void setWonnaeSayuCode(String wonnaeSayuCode) {
		this.wonnaeSayuCode = wonnaeSayuCode;
	}


	@Column(name="WONYOI_ORDER_YN")
	public String getWonyoiOrderYn() {
		return this.wonyoiOrderYn;
	}

	public void setWonyoiOrderYn(String wonyoiOrderYn) {
		this.wonyoiOrderYn = wonyoiOrderYn;
	}

}