package nta.med.core.domain.out;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the OUT1011 database table.
 * 
 */
@Entity
@NamedQuery(name="Out1011.findAll", query="SELECT o FROM Out1011 o")
public class Out1011 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String arriveTime;
	private String atcYn;
	private String bigo;
	private String bunho;
	private String changgu;
	private String chartGwa;
	private String chojae;
	private String chtChojae;
	private String clinicCode;
	private String disGubun;
	private String doctor;
	private String euryoseoYn;
	private String fkbil1001;
	private double fkinp1001;
	private String fkres1001;
	private String gaJubsuGubun;
	private String gubun;
	private String gubunTransYn;
	private String gugubchaYn;
	private String gwa;
	private String hospCode;
	private String hubalChangeYn;
	private String hunabGubun;
	private String inpBonin;
	private String inpTransYn;
	private String jangaeYn;
	private String jinchalryoGijun;
	private double jubsuGroup;
	private double jubsuNo;
	private String jubsuTime;
	private Date junpyoDate;
	private String misuGubun;
	private Date naewonDate;
	private String naewonGubun;
	private String naewonType;
	private String naewonYn;
	private String newPkout1001;
	private String outFixAmtYn;
	private String patientGubun;
	private String pkout1001;
	private String sabun;
	private double seq;
	private String soaNutjidoYn;
	private String specialYn;
	private double sujinNo;
	private String sunnabYn;
	private Date sysDate;
	private String sysId;
	private String telGubun;
	private String updChanggu;
	private Date updDate;
	private String updId;
	private Date updJunpyoDate;
	private String vcode;
	private String wonnaeSayuCode;
	private String wonyoiOrderYn;
	private String zipCode1;
	private String zipCode2;

	public Out1011() {
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


	@Column(name="CHT_CHOJAE")
	public String getChtChojae() {
		return this.chtChojae;
	}

	public void setChtChojae(String chtChojae) {
		this.chtChojae = chtChojae;
	}


	@Column(name="CLINIC_CODE")
	public String getClinicCode() {
		return this.clinicCode;
	}

	public void setClinicCode(String clinicCode) {
		this.clinicCode = clinicCode;
	}


	@Column(name="DIS_GUBUN")
	public String getDisGubun() {
		return this.disGubun;
	}

	public void setDisGubun(String disGubun) {
		this.disGubun = disGubun;
	}


	public String getDoctor() {
		return this.doctor;
	}

	public void setDoctor(String doctor) {
		this.doctor = doctor;
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


	public double getFkinp1001() {
		return this.fkinp1001;
	}

	public void setFkinp1001(double fkinp1001) {
		this.fkinp1001 = fkinp1001;
	}


	public String getFkres1001() {
		return this.fkres1001;
	}

	public void setFkres1001(String fkres1001) {
		this.fkres1001 = fkres1001;
	}


	@Column(name="GA_JUBSU_GUBUN")
	public String getGaJubsuGubun() {
		return this.gaJubsuGubun;
	}

	public void setGaJubsuGubun(String gaJubsuGubun) {
		this.gaJubsuGubun = gaJubsuGubun;
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


	@Column(name="HUNAB_GUBUN")
	public String getHunabGubun() {
		return this.hunabGubun;
	}

	public void setHunabGubun(String hunabGubun) {
		this.hunabGubun = hunabGubun;
	}


	@Column(name="INP_BONIN")
	public String getInpBonin() {
		return this.inpBonin;
	}

	public void setInpBonin(String inpBonin) {
		this.inpBonin = inpBonin;
	}


	@Column(name="INP_TRANS_YN")
	public String getInpTransYn() {
		return this.inpTransYn;
	}

	public void setInpTransYn(String inpTransYn) {
		this.inpTransYn = inpTransYn;
	}


	@Column(name="JANGAE_YN")
	public String getJangaeYn() {
		return this.jangaeYn;
	}

	public void setJangaeYn(String jangaeYn) {
		this.jangaeYn = jangaeYn;
	}


	@Column(name="JINCHALRYO_GIJUN")
	public String getJinchalryoGijun() {
		return this.jinchalryoGijun;
	}

	public void setJinchalryoGijun(String jinchalryoGijun) {
		this.jinchalryoGijun = jinchalryoGijun;
	}


	@Column(name="JUBSU_GROUP")
	public double getJubsuGroup() {
		return this.jubsuGroup;
	}

	public void setJubsuGroup(double jubsuGroup) {
		this.jubsuGroup = jubsuGroup;
	}


	@Column(name="JUBSU_NO")
	public double getJubsuNo() {
		return this.jubsuNo;
	}

	public void setJubsuNo(double jubsuNo) {
		this.jubsuNo = jubsuNo;
	}


	@Column(name="JUBSU_TIME")
	public String getJubsuTime() {
		return this.jubsuTime;
	}

	public void setJubsuTime(String jubsuTime) {
		this.jubsuTime = jubsuTime;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="JUNPYO_DATE")
	public Date getJunpyoDate() {
		return this.junpyoDate;
	}

	public void setJunpyoDate(Date junpyoDate) {
		this.junpyoDate = junpyoDate;
	}


	@Column(name="MISU_GUBUN")
	public String getMisuGubun() {
		return this.misuGubun;
	}

	public void setMisuGubun(String misuGubun) {
		this.misuGubun = misuGubun;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="NAEWON_DATE")
	public Date getNaewonDate() {
		return this.naewonDate;
	}

	public void setNaewonDate(Date naewonDate) {
		this.naewonDate = naewonDate;
	}


	@Column(name="NAEWON_GUBUN")
	public String getNaewonGubun() {
		return this.naewonGubun;
	}

	public void setNaewonGubun(String naewonGubun) {
		this.naewonGubun = naewonGubun;
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


	@Column(name="NEW_PKOUT1001")
	public String getNewPkout1001() {
		return this.newPkout1001;
	}

	public void setNewPkout1001(String newPkout1001) {
		this.newPkout1001 = newPkout1001;
	}


	@Column(name="OUT_FIX_AMT_YN")
	public String getOutFixAmtYn() {
		return this.outFixAmtYn;
	}

	public void setOutFixAmtYn(String outFixAmtYn) {
		this.outFixAmtYn = outFixAmtYn;
	}


	@Column(name="PATIENT_GUBUN")
	public String getPatientGubun() {
		return this.patientGubun;
	}

	public void setPatientGubun(String patientGubun) {
		this.patientGubun = patientGubun;
	}


	public String getPkout1001() {
		return this.pkout1001;
	}

	public void setPkout1001(String pkout1001) {
		this.pkout1001 = pkout1001;
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


	@Column(name="SOA_NUTJIDO_YN")
	public String getSoaNutjidoYn() {
		return this.soaNutjidoYn;
	}

	public void setSoaNutjidoYn(String soaNutjidoYn) {
		this.soaNutjidoYn = soaNutjidoYn;
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


	public String getVcode() {
		return this.vcode;
	}

	public void setVcode(String vcode) {
		this.vcode = vcode;
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


	@Column(name="ZIP_CODE1")
	public String getZipCode1() {
		return this.zipCode1;
	}

	public void setZipCode1(String zipCode1) {
		this.zipCode1 = zipCode1;
	}


	@Column(name="ZIP_CODE2")
	public String getZipCode2() {
		return this.zipCode2;
	}

	public void setZipCode2(String zipCode2) {
		this.zipCode2 = zipCode2;
	}

}