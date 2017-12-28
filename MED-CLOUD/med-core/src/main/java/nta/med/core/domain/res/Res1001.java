package nta.med.core.domain.res;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the RES1001 database table.
 * 
 */
@Entity
@NamedQuery(name="Res1001.findAll", query="SELECT r FROM Res1001 r")
public class Res1001 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private double amt;
	private String arriveTime;
	private String atcYn;
	private String bigo;
	private double billCnt;
	private double bonAmt;
	private double bonRate;
	private double bonTrunc;
	private String bunho;
	private double cardAmt;
	private double cardHoanAmt;
	private String changgu;
	private String chartGwa;
	private String chojae;
	private String chtTrgYn;
	private String clinicCode;
	private String createFkout1001;
	private double disAmt;
	private String disGubun;
	private double disSpeAmt;
	private String doctor;
	private double drgNalsu;
	private String euryoseoYn;
	private String fkbil1001;
	private String fkout1001;
	private double fkout2002;
	private String gubun;
	private String gugubchaYn;
	private String gwa;
	private double hoanAmt;
	private String hospCode;
	private String hubalChangeYn;
	private double hunabAmt;
	private String hunabGubun;
	private double hunabSpeAmt;
	private String inpBonin;
	private String inputGubun;
	private String jangaeYn;
	private Date jinryoPreDate;
	private String jinryoPreTime;
	private double johapAmt;
	private double jubsuNo;
	private Date junpyoDate;
	private double misuAmt;
	private String misuGubun;
	private double misuSpeAmt;
	private Date naewonDate;
	private String naewonType;
	private String naewonYn;
	private String nextJinryoYn;
	private double nonPayAmt;
	private String patientGubun;
	private double payAmt;
	private String pkres1001;
	private String realNaewonYn;
	private String resGubun;
	private Date reserDate;
	private double reserNo;
	private double reserSunbun;
	private String sabun;
	private double seq;
	private double serialNo;
	private String sgCode;
	private String soaNutjidoYn;
	private double specialAmt;
	private String specialYn;
	private double sujinNo;
	private String sunnabYn;
	private Date sysDate;
	private String sysId;
	private String telGubun;
	private double totAmt;
	private Date updDate;
	private String updId;
	private String updUser;
	private String wonnaeSayuCode;
	private String wonyoiOrderYn;

	public Res1001() {
	}


	public double getAmt() {
		return this.amt;
	}

	public void setAmt(double amt) {
		this.amt = amt;
	}


	@Column(name="ARRIVE_TIME")
	public String getArriveTime() {
		return this.arriveTime;
	}

	public void setArriveTime(String arriveTime) {
		this.arriveTime = arriveTime;
	}


	@Column(name="ATC_YN")
	public String getAtcYn() {
		return this.atcYn;
	}

	public void setAtcYn(String atcYn) {
		this.atcYn = atcYn;
	}


	public String getBigo() {
		return this.bigo;
	}

	public void setBigo(String bigo) {
		this.bigo = bigo;
	}


	@Column(name="BILL_CNT")
	public double getBillCnt() {
		return this.billCnt;
	}

	public void setBillCnt(double billCnt) {
		this.billCnt = billCnt;
	}


	@Column(name="BON_AMT")
	public double getBonAmt() {
		return this.bonAmt;
	}

	public void setBonAmt(double bonAmt) {
		this.bonAmt = bonAmt;
	}


	@Column(name="BON_RATE")
	public double getBonRate() {
		return this.bonRate;
	}

	public void setBonRate(double bonRate) {
		this.bonRate = bonRate;
	}


	@Column(name="BON_TRUNC")
	public double getBonTrunc() {
		return this.bonTrunc;
	}

	public void setBonTrunc(double bonTrunc) {
		this.bonTrunc = bonTrunc;
	}


	public String getBunho() {
		return this.bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}


	@Column(name="CARD_AMT")
	public double getCardAmt() {
		return this.cardAmt;
	}

	public void setCardAmt(double cardAmt) {
		this.cardAmt = cardAmt;
	}


	@Column(name="CARD_HOAN_AMT")
	public double getCardHoanAmt() {
		return this.cardHoanAmt;
	}

	public void setCardHoanAmt(double cardHoanAmt) {
		this.cardHoanAmt = cardHoanAmt;
	}


	public String getChanggu() {
		return this.changgu;
	}

	public void setChanggu(String changgu) {
		this.changgu = changgu;
	}


	@Column(name="CHART_GWA")
	public String getChartGwa() {
		return this.chartGwa;
	}

	public void setChartGwa(String chartGwa) {
		this.chartGwa = chartGwa;
	}


	public String getChojae() {
		return this.chojae;
	}

	public void setChojae(String chojae) {
		this.chojae = chojae;
	}


	@Column(name="CHT_TRG_YN")
	public String getChtTrgYn() {
		return this.chtTrgYn;
	}

	public void setChtTrgYn(String chtTrgYn) {
		this.chtTrgYn = chtTrgYn;
	}


	@Column(name="CLINIC_CODE")
	public String getClinicCode() {
		return this.clinicCode;
	}

	public void setClinicCode(String clinicCode) {
		this.clinicCode = clinicCode;
	}


	@Column(name="CREATE_FKOUT1001")
	public String getCreateFkout1001() {
		return this.createFkout1001;
	}

	public void setCreateFkout1001(String createFkout1001) {
		this.createFkout1001 = createFkout1001;
	}


	@Column(name="DIS_AMT")
	public double getDisAmt() {
		return this.disAmt;
	}

	public void setDisAmt(double disAmt) {
		this.disAmt = disAmt;
	}


	@Column(name="DIS_GUBUN")
	public String getDisGubun() {
		return this.disGubun;
	}

	public void setDisGubun(String disGubun) {
		this.disGubun = disGubun;
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


	@Column(name="DRG_NALSU")
	public double getDrgNalsu() {
		return this.drgNalsu;
	}

	public void setDrgNalsu(double drgNalsu) {
		this.drgNalsu = drgNalsu;
	}


	@Column(name="EURYOSEO_YN")
	public String getEuryoseoYn() {
		return this.euryoseoYn;
	}

	public void setEuryoseoYn(String euryoseoYn) {
		this.euryoseoYn = euryoseoYn;
	}


	public String getFkbil1001() {
		return this.fkbil1001;
	}

	public void setFkbil1001(String fkbil1001) {
		this.fkbil1001 = fkbil1001;
	}


	public String getFkout1001() {
		return this.fkout1001;
	}

	public void setFkout1001(String fkout1001) {
		this.fkout1001 = fkout1001;
	}


	public double getFkout2002() {
		return this.fkout2002;
	}

	public void setFkout2002(double fkout2002) {
		this.fkout2002 = fkout2002;
	}


	public String getGubun() {
		return this.gubun;
	}

	public void setGubun(String gubun) {
		this.gubun = gubun;
	}


	@Column(name="GUGUBCHA_YN")
	public String getGugubchaYn() {
		return this.gugubchaYn;
	}

	public void setGugubchaYn(String gugubchaYn) {
		this.gugubchaYn = gugubchaYn;
	}


	public String getGwa() {
		return this.gwa;
	}

	public void setGwa(String gwa) {
		this.gwa = gwa;
	}


	@Column(name="HOAN_AMT")
	public double getHoanAmt() {
		return this.hoanAmt;
	}

	public void setHoanAmt(double hoanAmt) {
		this.hoanAmt = hoanAmt;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="HUBAL_CHANGE_YN")
	public String getHubalChangeYn() {
		return this.hubalChangeYn;
	}

	public void setHubalChangeYn(String hubalChangeYn) {
		this.hubalChangeYn = hubalChangeYn;
	}


	@Column(name="HUNAB_AMT")
	public double getHunabAmt() {
		return this.hunabAmt;
	}

	public void setHunabAmt(double hunabAmt) {
		this.hunabAmt = hunabAmt;
	}


	@Column(name="HUNAB_GUBUN")
	public String getHunabGubun() {
		return this.hunabGubun;
	}

	public void setHunabGubun(String hunabGubun) {
		this.hunabGubun = hunabGubun;
	}


	@Column(name="HUNAB_SPE_AMT")
	public double getHunabSpeAmt() {
		return this.hunabSpeAmt;
	}

	public void setHunabSpeAmt(double hunabSpeAmt) {
		this.hunabSpeAmt = hunabSpeAmt;
	}


	@Column(name="INP_BONIN")
	public String getInpBonin() {
		return this.inpBonin;
	}

	public void setInpBonin(String inpBonin) {
		this.inpBonin = inpBonin;
	}


	@Column(name="INPUT_GUBUN")
	public String getInputGubun() {
		return this.inputGubun;
	}

	public void setInputGubun(String inputGubun) {
		this.inputGubun = inputGubun;
	}


	@Column(name="JANGAE_YN")
	public String getJangaeYn() {
		return this.jangaeYn;
	}

	public void setJangaeYn(String jangaeYn) {
		this.jangaeYn = jangaeYn;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="JINRYO_PRE_DATE")
	public Date getJinryoPreDate() {
		return this.jinryoPreDate;
	}

	public void setJinryoPreDate(Date jinryoPreDate) {
		this.jinryoPreDate = jinryoPreDate;
	}


	@Column(name="JINRYO_PRE_TIME")
	public String getJinryoPreTime() {
		return this.jinryoPreTime;
	}

	public void setJinryoPreTime(String jinryoPreTime) {
		this.jinryoPreTime = jinryoPreTime;
	}


	@Column(name="JOHAP_AMT")
	public double getJohapAmt() {
		return this.johapAmt;
	}

	public void setJohapAmt(double johapAmt) {
		this.johapAmt = johapAmt;
	}


	@Column(name="JUBSU_NO")
	public double getJubsuNo() {
		return this.jubsuNo;
	}

	public void setJubsuNo(double jubsuNo) {
		this.jubsuNo = jubsuNo;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="JUNPYO_DATE")
	public Date getJunpyoDate() {
		return this.junpyoDate;
	}

	public void setJunpyoDate(Date junpyoDate) {
		this.junpyoDate = junpyoDate;
	}


	@Column(name="MISU_AMT")
	public double getMisuAmt() {
		return this.misuAmt;
	}

	public void setMisuAmt(double misuAmt) {
		this.misuAmt = misuAmt;
	}


	@Column(name="MISU_GUBUN")
	public String getMisuGubun() {
		return this.misuGubun;
	}

	public void setMisuGubun(String misuGubun) {
		this.misuGubun = misuGubun;
	}


	@Column(name="MISU_SPE_AMT")
	public double getMisuSpeAmt() {
		return this.misuSpeAmt;
	}

	public void setMisuSpeAmt(double misuSpeAmt) {
		this.misuSpeAmt = misuSpeAmt;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="NAEWON_DATE")
	public Date getNaewonDate() {
		return this.naewonDate;
	}

	public void setNaewonDate(Date naewonDate) {
		this.naewonDate = naewonDate;
	}


	@Column(name="NAEWON_TYPE")
	public String getNaewonType() {
		return this.naewonType;
	}

	public void setNaewonType(String naewonType) {
		this.naewonType = naewonType;
	}


	@Column(name="NAEWON_YN")
	public String getNaewonYn() {
		return this.naewonYn;
	}

	public void setNaewonYn(String naewonYn) {
		this.naewonYn = naewonYn;
	}


	@Column(name="NEXT_JINRYO_YN")
	public String getNextJinryoYn() {
		return this.nextJinryoYn;
	}

	public void setNextJinryoYn(String nextJinryoYn) {
		this.nextJinryoYn = nextJinryoYn;
	}


	@Column(name="NON_PAY_AMT")
	public double getNonPayAmt() {
		return this.nonPayAmt;
	}

	public void setNonPayAmt(double nonPayAmt) {
		this.nonPayAmt = nonPayAmt;
	}


	@Column(name="PATIENT_GUBUN")
	public String getPatientGubun() {
		return this.patientGubun;
	}

	public void setPatientGubun(String patientGubun) {
		this.patientGubun = patientGubun;
	}


	@Column(name="PAY_AMT")
	public double getPayAmt() {
		return this.payAmt;
	}

	public void setPayAmt(double payAmt) {
		this.payAmt = payAmt;
	}


	public String getPkres1001() {
		return this.pkres1001;
	}

	public void setPkres1001(String pkres1001) {
		this.pkres1001 = pkres1001;
	}


	@Column(name="REAL_NAEWON_YN")
	public String getRealNaewonYn() {
		return this.realNaewonYn;
	}

	public void setRealNaewonYn(String realNaewonYn) {
		this.realNaewonYn = realNaewonYn;
	}


	@Column(name="RES_GUBUN")
	public String getResGubun() {
		return this.resGubun;
	}

	public void setResGubun(String resGubun) {
		this.resGubun = resGubun;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="RESER_DATE")
	public Date getReserDate() {
		return this.reserDate;
	}

	public void setReserDate(Date reserDate) {
		this.reserDate = reserDate;
	}


	@Column(name="RESER_NO")
	public double getReserNo() {
		return this.reserNo;
	}

	public void setReserNo(double reserNo) {
		this.reserNo = reserNo;
	}


	@Column(name="RESER_SUNBUN")
	public double getReserSunbun() {
		return this.reserSunbun;
	}

	public void setReserSunbun(double reserSunbun) {
		this.reserSunbun = reserSunbun;
	}


	public String getSabun() {
		return this.sabun;
	}

	public void setSabun(String sabun) {
		this.sabun = sabun;
	}


	public double getSeq() {
		return this.seq;
	}

	public void setSeq(double seq) {
		this.seq = seq;
	}


	@Column(name="SERIAL_NO")
	public double getSerialNo() {
		return this.serialNo;
	}

	public void setSerialNo(double serialNo) {
		this.serialNo = serialNo;
	}


	@Column(name="SG_CODE")
	public String getSgCode() {
		return this.sgCode;
	}

	public void setSgCode(String sgCode) {
		this.sgCode = sgCode;
	}


	@Column(name="SOA_NUTJIDO_YN")
	public String getSoaNutjidoYn() {
		return this.soaNutjidoYn;
	}

	public void setSoaNutjidoYn(String soaNutjidoYn) {
		this.soaNutjidoYn = soaNutjidoYn;
	}


	@Column(name="SPECIAL_AMT")
	public double getSpecialAmt() {
		return this.specialAmt;
	}

	public void setSpecialAmt(double specialAmt) {
		this.specialAmt = specialAmt;
	}


	@Column(name="SPECIAL_YN")
	public String getSpecialYn() {
		return this.specialYn;
	}

	public void setSpecialYn(String specialYn) {
		this.specialYn = specialYn;
	}


	@Column(name="SUJIN_NO")
	public double getSujinNo() {
		return this.sujinNo;
	}

	public void setSujinNo(double sujinNo) {
		this.sujinNo = sujinNo;
	}


	@Column(name="SUNNAB_YN")
	public String getSunnabYn() {
		return this.sunnabYn;
	}

	public void setSunnabYn(String sunnabYn) {
		this.sunnabYn = sunnabYn;
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


	@Column(name="TEL_GUBUN")
	public String getTelGubun() {
		return this.telGubun;
	}

	public void setTelGubun(String telGubun) {
		this.telGubun = telGubun;
	}


	@Column(name="TOT_AMT")
	public double getTotAmt() {
		return this.totAmt;
	}

	public void setTotAmt(double totAmt) {
		this.totAmt = totAmt;
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


	@Column(name="UPD_USER")
	public String getUpdUser() {
		return this.updUser;
	}

	public void setUpdUser(String updUser) {
		this.updUser = updUser;
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