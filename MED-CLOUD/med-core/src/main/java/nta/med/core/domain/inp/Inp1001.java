package nta.med.core.domain.inp;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;

/**
 * The persistent class for the INP1001 database table.
 * 
 */
@Entity
@Table(name = "INP1001")
public class Inp1001 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String babyStatus;
	private String bedNo;
	private String bedNo2;
	private String bunho;
	private Date cancelDate;
	private String cancelUser;
	private String cancelYn;
	private String chojae;
	private String cycleOrderGroup;
	private String doctor;
	private String emergencyDetail;
	private String emergencyGubun;
	private Double fkInpKey;
	private Double fkinp1003;
	private String fkout1001;
	private Date gaToiwonDate;
	private Date gisanIpwonDate;
	private Double gisanJaewonIlsu;
	private String gwa;
	private String hoCode1;
	private String hoCode2;
	private String hoDong1;
	private String hoDong2;
	private String hoGrade1;
	private String hoGrade2;
	private String hospCode;
	private String inpTransYn;
	private Date ipwonDate;
	private String ipwonGwa;
	private String ipwonRtn2;
	private String ipwonTime;
	private String ipwonType;
	private String jaewonFlag;
	private String jisiDoctor;
	private String kaikeiHocode;
	private String kaikeiHodong;
	private String kiGubun;
	private String orgIpwonType;
	private Double pkinp1001;
	private String resident;
	private String result;
	private Date sigiMagamDate;
	private String sigiMagamYn;
	private Date simsaMagamDate;
	private String simsaMagamGubun;
	private String simsaMagamTime;
	private String simsaMagamja;
	private Date sysDate;
	private String sysId;
	private String team;
	private String toiwonCancelYn;
	private Date toiwonDate;
	private String toiwonGojiTime;
	private String toiwonGojiYn;
	private Date toiwonResDate;
	private String toiwonResTime;
	private String toiwonTime;
	private Date updDate;
	private String updId;
	private String resultAfterDis;
	private String resultAfterDisRemark;
	private String ipwonRtn2Remark;

	public Inp1001() {
	}

	@Column(name = "BABY_STATUS")
	public String getBabyStatus() {
		return this.babyStatus;
	}

	public void setBabyStatus(String babyStatus) {
		this.babyStatus = babyStatus;
	}

	@Column(name = "BED_NO")
	public String getBedNo() {
		return this.bedNo;
	}

	public void setBedNo(String bedNo) {
		this.bedNo = bedNo;
	}

	@Column(name = "BED_NO2")
	public String getBedNo2() {
		return this.bedNo2;
	}

	public void setBedNo2(String bedNo2) {
		this.bedNo2 = bedNo2;
	}

	public String getBunho() {
		return this.bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "CANCEL_DATE")
	public Date getCancelDate() {
		return this.cancelDate;
	}

	public void setCancelDate(Date cancelDate) {
		this.cancelDate = cancelDate;
	}

	@Column(name = "CANCEL_USER")
	public String getCancelUser() {
		return this.cancelUser;
	}

	public void setCancelUser(String cancelUser) {
		this.cancelUser = cancelUser;
	}

	@Column(name = "CANCEL_YN")
	public String getCancelYn() {
		return this.cancelYn;
	}

	public void setCancelYn(String cancelYn) {
		this.cancelYn = cancelYn;
	}

	public String getChojae() {
		return this.chojae;
	}

	public void setChojae(String chojae) {
		this.chojae = chojae;
	}

	@Column(name = "CYCLE_ORDER_GROUP")
	public String getCycleOrderGroup() {
		return this.cycleOrderGroup;
	}

	public void setCycleOrderGroup(String cycleOrderGroup) {
		this.cycleOrderGroup = cycleOrderGroup;
	}

	public String getDoctor() {
		return this.doctor;
	}

	public void setDoctor(String doctor) {
		this.doctor = doctor;
	}

	@Column(name = "EMERGENCY_DETAIL")
	public String getEmergencyDetail() {
		return this.emergencyDetail;
	}

	public void setEmergencyDetail(String emergencyDetail) {
		this.emergencyDetail = emergencyDetail;
	}

	@Column(name = "EMERGENCY_GUBUN")
	public String getEmergencyGubun() {
		return this.emergencyGubun;
	}

	public void setEmergencyGubun(String emergencyGubun) {
		this.emergencyGubun = emergencyGubun;
	}

	@Column(name = "FK_INP_KEY")
	public Double getFkInpKey() {
		return this.fkInpKey;
	}

	public void setFkInpKey(Double fkInpKey) {
		this.fkInpKey = fkInpKey;
	}

	public Double getFkinp1003() {
		return this.fkinp1003;
	}

	public void setFkinp1003(Double fkinp1003) {
		this.fkinp1003 = fkinp1003;
	}

	public String getFkout1001() {
		return this.fkout1001;
	}

	public void setFkout1001(String fkout1001) {
		this.fkout1001 = fkout1001;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "GA_TOIWON_DATE")
	public Date getGaToiwonDate() {
		return this.gaToiwonDate;
	}

	public void setGaToiwonDate(Date gaToiwonDate) {
		this.gaToiwonDate = gaToiwonDate;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "GISAN_IPWON_DATE")
	public Date getGisanIpwonDate() {
		return this.gisanIpwonDate;
	}

	public void setGisanIpwonDate(Date gisanIpwonDate) {
		this.gisanIpwonDate = gisanIpwonDate;
	}

	@Column(name = "GISAN_JAEWON_ILSU")
	public Double getGisanJaewonIlsu() {
		return this.gisanJaewonIlsu;
	}

	public void setGisanJaewonIlsu(Double gisanJaewonIlsu) {
		this.gisanJaewonIlsu = gisanJaewonIlsu;
	}

	public String getGwa() {
		return this.gwa;
	}

	public void setGwa(String gwa) {
		this.gwa = gwa;
	}

	@Column(name = "HO_CODE1")
	public String getHoCode1() {
		return this.hoCode1;
	}

	public void setHoCode1(String hoCode1) {
		this.hoCode1 = hoCode1;
	}

	@Column(name = "HO_CODE2")
	public String getHoCode2() {
		return this.hoCode2;
	}

	public void setHoCode2(String hoCode2) {
		this.hoCode2 = hoCode2;
	}

	@Column(name = "HO_DONG1")
	public String getHoDong1() {
		return this.hoDong1;
	}

	public void setHoDong1(String hoDong1) {
		this.hoDong1 = hoDong1;
	}

	@Column(name = "HO_DONG2")
	public String getHoDong2() {
		return this.hoDong2;
	}

	public void setHoDong2(String hoDong2) {
		this.hoDong2 = hoDong2;
	}

	@Column(name = "HO_GRADE1")
	public String getHoGrade1() {
		return this.hoGrade1;
	}

	public void setHoGrade1(String hoGrade1) {
		this.hoGrade1 = hoGrade1;
	}

	@Column(name = "HO_GRADE2")
	public String getHoGrade2() {
		return this.hoGrade2;
	}

	public void setHoGrade2(String hoGrade2) {
		this.hoGrade2 = hoGrade2;
	}

	@Column(name = "HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}

	@Column(name = "INP_TRANS_YN")
	public String getInpTransYn() {
		return this.inpTransYn;
	}

	public void setInpTransYn(String inpTransYn) {
		this.inpTransYn = inpTransYn;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "IPWON_DATE")
	public Date getIpwonDate() {
		return this.ipwonDate;
	}

	public void setIpwonDate(Date ipwonDate) {
		this.ipwonDate = ipwonDate;
	}

	@Column(name = "IPWON_GWA")
	public String getIpwonGwa() {
		return this.ipwonGwa;
	}

	public void setIpwonGwa(String ipwonGwa) {
		this.ipwonGwa = ipwonGwa;
	}

	@Column(name = "IPWON_RTN2")
	public String getIpwonRtn2() {
		return this.ipwonRtn2;
	}

	public void setIpwonRtn2(String ipwonRtn2) {
		this.ipwonRtn2 = ipwonRtn2;
	}

	@Column(name = "IPWON_TIME")
	public String getIpwonTime() {
		return this.ipwonTime;
	}

	public void setIpwonTime(String ipwonTime) {
		this.ipwonTime = ipwonTime;
	}

	@Column(name = "IPWON_TYPE")
	public String getIpwonType() {
		return this.ipwonType;
	}

	public void setIpwonType(String ipwonType) {
		this.ipwonType = ipwonType;
	}

	@Column(name = "JAEWON_FLAG")
	public String getJaewonFlag() {
		return this.jaewonFlag;
	}

	public void setJaewonFlag(String jaewonFlag) {
		this.jaewonFlag = jaewonFlag;
	}

	@Column(name = "JISI_DOCTOR")
	public String getJisiDoctor() {
		return this.jisiDoctor;
	}

	public void setJisiDoctor(String jisiDoctor) {
		this.jisiDoctor = jisiDoctor;
	}

	@Column(name = "KAIKEI_HOCODE")
	public String getKaikeiHocode() {
		return this.kaikeiHocode;
	}

	public void setKaikeiHocode(String kaikeiHocode) {
		this.kaikeiHocode = kaikeiHocode;
	}

	@Column(name = "KAIKEI_HODONG")
	public String getKaikeiHodong() {
		return this.kaikeiHodong;
	}

	public void setKaikeiHodong(String kaikeiHodong) {
		this.kaikeiHodong = kaikeiHodong;
	}

	@Column(name = "KI_GUBUN")
	public String getKiGubun() {
		return this.kiGubun;
	}

	public void setKiGubun(String kiGubun) {
		this.kiGubun = kiGubun;
	}

	@Column(name = "ORG_IPWON_TYPE")
	public String getOrgIpwonType() {
		return this.orgIpwonType;
	}

	public void setOrgIpwonType(String orgIpwonType) {
		this.orgIpwonType = orgIpwonType;
	}

	public Double getPkinp1001() {
		return this.pkinp1001;
	}

	public void setPkinp1001(Double pkinp1001) {
		this.pkinp1001 = pkinp1001;
	}

	public String getResident() {
		return this.resident;
	}

	public void setResident(String resident) {
		this.resident = resident;
	}

	public String getResult() {
		return this.result;
	}

	public void setResult(String result) {
		this.result = result;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "SIGI_MAGAM_DATE")
	public Date getSigiMagamDate() {
		return this.sigiMagamDate;
	}

	public void setSigiMagamDate(Date sigiMagamDate) {
		this.sigiMagamDate = sigiMagamDate;
	}

	@Column(name = "SIGI_MAGAM_YN")
	public String getSigiMagamYn() {
		return this.sigiMagamYn;
	}

	public void setSigiMagamYn(String sigiMagamYn) {
		this.sigiMagamYn = sigiMagamYn;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "SIMSA_MAGAM_DATE")
	public Date getSimsaMagamDate() {
		return this.simsaMagamDate;
	}

	public void setSimsaMagamDate(Date simsaMagamDate) {
		this.simsaMagamDate = simsaMagamDate;
	}

	@Column(name = "SIMSA_MAGAM_GUBUN")
	public String getSimsaMagamGubun() {
		return this.simsaMagamGubun;
	}

	public void setSimsaMagamGubun(String simsaMagamGubun) {
		this.simsaMagamGubun = simsaMagamGubun;
	}

	@Column(name = "SIMSA_MAGAM_TIME")
	public String getSimsaMagamTime() {
		return this.simsaMagamTime;
	}

	public void setSimsaMagamTime(String simsaMagamTime) {
		this.simsaMagamTime = simsaMagamTime;
	}

	@Column(name = "SIMSA_MAGAMJA")
	public String getSimsaMagamja() {
		return this.simsaMagamja;
	}

	public void setSimsaMagamja(String simsaMagamja) {
		this.simsaMagamja = simsaMagamja;
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

	public String getTeam() {
		return this.team;
	}

	public void setTeam(String team) {
		this.team = team;
	}

	@Column(name = "TOIWON_CANCEL_YN")
	public String getToiwonCancelYn() {
		return this.toiwonCancelYn;
	}

	public void setToiwonCancelYn(String toiwonCancelYn) {
		this.toiwonCancelYn = toiwonCancelYn;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "TOIWON_DATE")
	public Date getToiwonDate() {
		return this.toiwonDate;
	}

	public void setToiwonDate(Date toiwonDate) {
		this.toiwonDate = toiwonDate;
	}

	@Column(name = "TOIWON_GOJI_TIME")
	public String getToiwonGojiTime() {
		return this.toiwonGojiTime;
	}

	public void setToiwonGojiTime(String toiwonGojiTime) {
		this.toiwonGojiTime = toiwonGojiTime;
	}

	@Column(name = "TOIWON_GOJI_YN")
	public String getToiwonGojiYn() {
		return this.toiwonGojiYn;
	}

	public void setToiwonGojiYn(String toiwonGojiYn) {
		this.toiwonGojiYn = toiwonGojiYn;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "TOIWON_RES_DATE")
	public Date getToiwonResDate() {
		return this.toiwonResDate;
	}

	public void setToiwonResDate(Date toiwonResDate) {
		this.toiwonResDate = toiwonResDate;
	}

	@Column(name = "TOIWON_RES_TIME")
	public String getToiwonResTime() {
		return this.toiwonResTime;
	}

	public void setToiwonResTime(String toiwonResTime) {
		this.toiwonResTime = toiwonResTime;
	}

	@Column(name = "TOIWON_TIME")
	public String getToiwonTime() {
		return this.toiwonTime;
	}

	public void setToiwonTime(String toiwonTime) {
		this.toiwonTime = toiwonTime;
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

	@Column(name = "RESULT_AFTER_DIS")
	public String getResultAfterDis() {
		return resultAfterDis;
	}

	public void setResultAfterDis(String resultAfterDis) {
		this.resultAfterDis = resultAfterDis;
	}

	@Column(name = "RESULT_AFTER_DIS_REMARK")
	public String getResultAfterDisRemark() {
		return resultAfterDisRemark;
	}

	public void setResultAfterDisRemark(String resultAfterDisRemark) {
		this.resultAfterDisRemark = resultAfterDisRemark;
	}

	@Column(name = "IPWON_RTN2_REMARK")
	public String getIpwonRtn2Remark() {
		return ipwonRtn2Remark;
	}

	public void setIpwonRtn2Remark(String ipwonRtn2Remark) {
		this.ipwonRtn2Remark = ipwonRtn2Remark;
	}

}