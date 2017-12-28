package nta.med.core.domain.nur;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the NUR9998 database table.
 * 
 */
@Entity
@NamedQuery(name="Nur9998.findAll", query="SELECT n FROM Nur9998 n")
public class Nur9998 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String address;
	private double age;
	private Date birth;
	private String bunho;
	private String damdang;
	private String doctor;
	private String emTel;
	private String excretion;
	private String familyInfo;
	private double fkcsc0105;
	private double fkinp1001;
	private String food;
	private String hbsFlag;
	private String hcvFlag;
	private String history;
	private String hoCode;
	private String hoName;
	private String hospCode;
	private String hospital;
	private Date ipwonDate;
	private Date makeDate;
	private String mrsaFlag;
	private String nurseHistory;
	private String recipeInfo;
	private String sajang;
	private String sangName;
	private double serial;
	private String stable;
	private String suname;
	private Date sysDate;
	private String sysId;
	private Date taiwonDate;
	private String tel;
	private String tphaFlag;
	private String transReason;
	private Date updDate;
	private String updId;

	public Nur9998() {
	}


	public String getAddress() {
		return this.address;
	}

	public void setAddress(String address) {
		this.address = address;
	}


	public double getAge() {
		return this.age;
	}

	public void setAge(double age) {
		this.age = age;
	}


	@Temporal(TemporalType.TIMESTAMP)
	public Date getBirth() {
		return this.birth;
	}

	public void setBirth(Date birth) {
		this.birth = birth;
	}


	public String getBunho() {
		return this.bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}


	public String getDamdang() {
		return this.damdang;
	}

	public void setDamdang(String damdang) {
		this.damdang = damdang;
	}


	public String getDoctor() {
		return this.doctor;
	}

	public void setDoctor(String doctor) {
		this.doctor = doctor;
	}


	@Column(name="EM_TEL")
	public String getEmTel() {
		return this.emTel;
	}

	public void setEmTel(String emTel) {
		this.emTel = emTel;
	}


	public String getExcretion() {
		return this.excretion;
	}

	public void setExcretion(String excretion) {
		this.excretion = excretion;
	}


	@Column(name="FAMILY_INFO")
	public String getFamilyInfo() {
		return this.familyInfo;
	}

	public void setFamilyInfo(String familyInfo) {
		this.familyInfo = familyInfo;
	}


	public double getFkcsc0105() {
		return this.fkcsc0105;
	}

	public void setFkcsc0105(double fkcsc0105) {
		this.fkcsc0105 = fkcsc0105;
	}


	public double getFkinp1001() {
		return this.fkinp1001;
	}

	public void setFkinp1001(double fkinp1001) {
		this.fkinp1001 = fkinp1001;
	}


	public String getFood() {
		return this.food;
	}

	public void setFood(String food) {
		this.food = food;
	}


	@Column(name="HBS_FLAG")
	public String getHbsFlag() {
		return this.hbsFlag;
	}

	public void setHbsFlag(String hbsFlag) {
		this.hbsFlag = hbsFlag;
	}


	@Column(name="HCV_FLAG")
	public String getHcvFlag() {
		return this.hcvFlag;
	}

	public void setHcvFlag(String hcvFlag) {
		this.hcvFlag = hcvFlag;
	}


	public String getHistory() {
		return this.history;
	}

	public void setHistory(String history) {
		this.history = history;
	}


	@Column(name="HO_CODE")
	public String getHoCode() {
		return this.hoCode;
	}

	public void setHoCode(String hoCode) {
		this.hoCode = hoCode;
	}


	@Column(name="HO_NAME")
	public String getHoName() {
		return this.hoName;
	}

	public void setHoName(String hoName) {
		this.hoName = hoName;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	public String getHospital() {
		return this.hospital;
	}

	public void setHospital(String hospital) {
		this.hospital = hospital;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="IPWON_DATE")
	public Date getIpwonDate() {
		return this.ipwonDate;
	}

	public void setIpwonDate(Date ipwonDate) {
		this.ipwonDate = ipwonDate;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="MAKE_DATE")
	public Date getMakeDate() {
		return this.makeDate;
	}

	public void setMakeDate(Date makeDate) {
		this.makeDate = makeDate;
	}


	@Column(name="MRSA_FLAG")
	public String getMrsaFlag() {
		return this.mrsaFlag;
	}

	public void setMrsaFlag(String mrsaFlag) {
		this.mrsaFlag = mrsaFlag;
	}


	@Column(name="NURSE_HISTORY")
	public String getNurseHistory() {
		return this.nurseHistory;
	}

	public void setNurseHistory(String nurseHistory) {
		this.nurseHistory = nurseHistory;
	}


	@Column(name="RECIPE_INFO")
	public String getRecipeInfo() {
		return this.recipeInfo;
	}

	public void setRecipeInfo(String recipeInfo) {
		this.recipeInfo = recipeInfo;
	}


	public String getSajang() {
		return this.sajang;
	}

	public void setSajang(String sajang) {
		this.sajang = sajang;
	}


	@Column(name="SANG_NAME")
	public String getSangName() {
		return this.sangName;
	}

	public void setSangName(String sangName) {
		this.sangName = sangName;
	}


	public double getSerial() {
		return this.serial;
	}

	public void setSerial(double serial) {
		this.serial = serial;
	}


	public String getStable() {
		return this.stable;
	}

	public void setStable(String stable) {
		this.stable = stable;
	}


	public String getSuname() {
		return this.suname;
	}

	public void setSuname(String suname) {
		this.suname = suname;
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
	@Column(name="TAIWON_DATE")
	public Date getTaiwonDate() {
		return this.taiwonDate;
	}

	public void setTaiwonDate(Date taiwonDate) {
		this.taiwonDate = taiwonDate;
	}


	public String getTel() {
		return this.tel;
	}

	public void setTel(String tel) {
		this.tel = tel;
	}


	@Column(name="TPHA_FLAG")
	public String getTphaFlag() {
		return this.tphaFlag;
	}

	public void setTphaFlag(String tphaFlag) {
		this.tphaFlag = tphaFlag;
	}


	@Column(name="TRANS_REASON")
	public String getTransReason() {
		return this.transReason;
	}

	public void setTransReason(String transReason) {
		this.transReason = transReason;
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

}