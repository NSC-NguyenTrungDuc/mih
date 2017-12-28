package nta.med.core.domain.doc;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the DOC1009 database table.
 * 
 */
@Entity
@NamedQuery(name="Doc1009.findAll", query="SELECT d FROM Doc1009 d")
public class Doc1009 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String babyBodyCondition;
	private double babyFInwon;
	private String babyHealthCondition;
	private double babyMInwon;
	private double babyTotalInwon;
	private double balgeubNo;
	private Date birthDate;
	private String birthPlace;
	private String birthPlaceAddr;
	private String birthPlaceName;
	private String bunho;
	private String docGubun;
	private String doctor;
	private String doctorLicense;
	private String doctorName;
	private double fAge;
	private Date fBirth;
	private String fJob;
	private String fName;
	private String hospAddr;
	private String hospCode;
	private String hospName;
	private Date issueDate;
	private double mAge;
	private Date mBirth;
	private String mJob;
	private String mName;
	private String multiGubun;
	private String multiGubunSunui;
	private double multiSu;
	private String nurse;
	private String nurseName;
	private String parentAddr;
	private String pregPeriod;
	private double saengInwon;
	private double samangInwon;
	private double sanmoSanaInwon;
	private String sasan;
	private double sasanInwon;
	private double sasanTotalInwon;
	private String sex;
	private String suname;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Doc1009() {
	}


	@Column(name="BABY_BODY_CONDITION")
	public String getBabyBodyCondition() {
		return this.babyBodyCondition;
	}

	public void setBabyBodyCondition(String babyBodyCondition) {
		this.babyBodyCondition = babyBodyCondition;
	}


	@Column(name="BABY_F_INWON")
	public double getBabyFInwon() {
		return this.babyFInwon;
	}

	public void setBabyFInwon(double babyFInwon) {
		this.babyFInwon = babyFInwon;
	}


	@Column(name="BABY_HEALTH_CONDITION")
	public String getBabyHealthCondition() {
		return this.babyHealthCondition;
	}

	public void setBabyHealthCondition(String babyHealthCondition) {
		this.babyHealthCondition = babyHealthCondition;
	}


	@Column(name="BABY_M_INWON")
	public double getBabyMInwon() {
		return this.babyMInwon;
	}

	public void setBabyMInwon(double babyMInwon) {
		this.babyMInwon = babyMInwon;
	}


	@Column(name="BABY_TOTAL_INWON")
	public double getBabyTotalInwon() {
		return this.babyTotalInwon;
	}

	public void setBabyTotalInwon(double babyTotalInwon) {
		this.babyTotalInwon = babyTotalInwon;
	}


	@Column(name="BALGEUB_NO")
	public double getBalgeubNo() {
		return this.balgeubNo;
	}

	public void setBalgeubNo(double balgeubNo) {
		this.balgeubNo = balgeubNo;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="BIRTH_DATE")
	public Date getBirthDate() {
		return this.birthDate;
	}

	public void setBirthDate(Date birthDate) {
		this.birthDate = birthDate;
	}


	@Column(name="BIRTH_PLACE")
	public String getBirthPlace() {
		return this.birthPlace;
	}

	public void setBirthPlace(String birthPlace) {
		this.birthPlace = birthPlace;
	}


	@Column(name="BIRTH_PLACE_ADDR")
	public String getBirthPlaceAddr() {
		return this.birthPlaceAddr;
	}

	public void setBirthPlaceAddr(String birthPlaceAddr) {
		this.birthPlaceAddr = birthPlaceAddr;
	}


	@Column(name="BIRTH_PLACE_NAME")
	public String getBirthPlaceName() {
		return this.birthPlaceName;
	}

	public void setBirthPlaceName(String birthPlaceName) {
		this.birthPlaceName = birthPlaceName;
	}


	public String getBunho() {
		return this.bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}


	@Column(name="DOC_GUBUN")
	public String getDocGubun() {
		return this.docGubun;
	}

	public void setDocGubun(String docGubun) {
		this.docGubun = docGubun;
	}


	public String getDoctor() {
		return this.doctor;
	}

	public void setDoctor(String doctor) {
		this.doctor = doctor;
	}


	@Column(name="DOCTOR_LICENSE")
	public String getDoctorLicense() {
		return this.doctorLicense;
	}

	public void setDoctorLicense(String doctorLicense) {
		this.doctorLicense = doctorLicense;
	}


	@Column(name="DOCTOR_NAME")
	public String getDoctorName() {
		return this.doctorName;
	}

	public void setDoctorName(String doctorName) {
		this.doctorName = doctorName;
	}


	@Column(name="F_AGE")
	public double getFAge() {
		return this.fAge;
	}

	public void setFAge(double fAge) {
		this.fAge = fAge;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="F_BIRTH")
	public Date getFBirth() {
		return this.fBirth;
	}

	public void setFBirth(Date fBirth) {
		this.fBirth = fBirth;
	}


	@Column(name="F_JOB")
	public String getFJob() {
		return this.fJob;
	}

	public void setFJob(String fJob) {
		this.fJob = fJob;
	}


	@Column(name="F_NAME")
	public String getFName() {
		return this.fName;
	}

	public void setFName(String fName) {
		this.fName = fName;
	}


	@Column(name="HOSP_ADDR")
	public String getHospAddr() {
		return this.hospAddr;
	}

	public void setHospAddr(String hospAddr) {
		this.hospAddr = hospAddr;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="HOSP_NAME")
	public String getHospName() {
		return this.hospName;
	}

	public void setHospName(String hospName) {
		this.hospName = hospName;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="ISSUE_DATE")
	public Date getIssueDate() {
		return this.issueDate;
	}

	public void setIssueDate(Date issueDate) {
		this.issueDate = issueDate;
	}


	@Column(name="M_AGE")
	public double getMAge() {
		return this.mAge;
	}

	public void setMAge(double mAge) {
		this.mAge = mAge;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="M_BIRTH")
	public Date getMBirth() {
		return this.mBirth;
	}

	public void setMBirth(Date mBirth) {
		this.mBirth = mBirth;
	}


	@Column(name="M_JOB")
	public String getMJob() {
		return this.mJob;
	}

	public void setMJob(String mJob) {
		this.mJob = mJob;
	}


	@Column(name="M_NAME")
	public String getMName() {
		return this.mName;
	}

	public void setMName(String mName) {
		this.mName = mName;
	}


	@Column(name="MULTI_GUBUN")
	public String getMultiGubun() {
		return this.multiGubun;
	}

	public void setMultiGubun(String multiGubun) {
		this.multiGubun = multiGubun;
	}


	@Column(name="MULTI_GUBUN_SUNUI")
	public String getMultiGubunSunui() {
		return this.multiGubunSunui;
	}

	public void setMultiGubunSunui(String multiGubunSunui) {
		this.multiGubunSunui = multiGubunSunui;
	}


	@Column(name="MULTI_SU")
	public double getMultiSu() {
		return this.multiSu;
	}

	public void setMultiSu(double multiSu) {
		this.multiSu = multiSu;
	}


	public String getNurse() {
		return this.nurse;
	}

	public void setNurse(String nurse) {
		this.nurse = nurse;
	}


	@Column(name="NURSE_NAME")
	public String getNurseName() {
		return this.nurseName;
	}

	public void setNurseName(String nurseName) {
		this.nurseName = nurseName;
	}


	@Column(name="PARENT_ADDR")
	public String getParentAddr() {
		return this.parentAddr;
	}

	public void setParentAddr(String parentAddr) {
		this.parentAddr = parentAddr;
	}


	@Column(name="PREG_PERIOD")
	public String getPregPeriod() {
		return this.pregPeriod;
	}

	public void setPregPeriod(String pregPeriod) {
		this.pregPeriod = pregPeriod;
	}


	@Column(name="SAENG_INWON")
	public double getSaengInwon() {
		return this.saengInwon;
	}

	public void setSaengInwon(double saengInwon) {
		this.saengInwon = saengInwon;
	}


	@Column(name="SAMANG_INWON")
	public double getSamangInwon() {
		return this.samangInwon;
	}

	public void setSamangInwon(double samangInwon) {
		this.samangInwon = samangInwon;
	}


	@Column(name="SANMO_SANA_INWON")
	public double getSanmoSanaInwon() {
		return this.sanmoSanaInwon;
	}

	public void setSanmoSanaInwon(double sanmoSanaInwon) {
		this.sanmoSanaInwon = sanmoSanaInwon;
	}


	public String getSasan() {
		return this.sasan;
	}

	public void setSasan(String sasan) {
		this.sasan = sasan;
	}


	@Column(name="SASAN_INWON")
	public double getSasanInwon() {
		return this.sasanInwon;
	}

	public void setSasanInwon(double sasanInwon) {
		this.sasanInwon = sasanInwon;
	}


	@Column(name="SASAN_TOTAL_INWON")
	public double getSasanTotalInwon() {
		return this.sasanTotalInwon;
	}

	public void setSasanTotalInwon(double sasanTotalInwon) {
		this.sasanTotalInwon = sasanTotalInwon;
	}


	public String getSex() {
		return this.sex;
	}

	public void setSex(String sex) {
		this.sex = sex;
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