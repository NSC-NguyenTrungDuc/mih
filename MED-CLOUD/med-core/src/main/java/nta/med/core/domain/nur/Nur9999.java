package nta.med.core.domain.nur;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;


/**
 * The persistent class for the NUR9999 database table.
 * 
 */
@Entity
@Table(name="NUR9999")
public class Nur9999 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String address;
	private String age;
	private Date birth;
	private String bunho;
	private String comments;
	private String communication;
	private String continueNursing;
	private String damdangNurse;
	private String doctor;
	private String excretion;
	private String excretionAdl;
	private String excretionAdlCmt;
	private Double fkinp1001;
	private String food;
	private String foodAdl;
	private String foodAdlCmt;
	private String gubun;
	private String gwa;
	private String hoDong;
	private String hospCode;
	private String infection;
	private String inpatientCourse;
	private Date ipwonDate;
	private String key1Home;
	private String key1Office;
	private String key1Phone;
	private String key1Relation;
	private String key2Home;
	private String key2Office;
	private String key2Phone;
	private String key2Relation;
	private String leaderNurse;
	private String move;
	private String moveAdl;
	private String moveAdlCmt;
	private String nursingPass;
	private String pastHis;
	private Double pknur9999;
	private String reason;
	private String sangName;
	private String sleep;
	private String suname;
	private Date sysDate;
	private String sysId;
	private String taboo;
	private String tel;
	private Date toiwonDate;
	private String tube;
	private Date updDate;
	private String updId;
	private String wareAdl;
	private String wareAdlCmt;
	private String wash;
	private String washAdl;
	private String washAdlCmt;
	private Date writeDate;

	public Nur9999() {
	}


	public String getAddress() {
		return this.address;
	}

	public void setAddress(String address) {
		this.address = address;
	}


	public String getAge() {
		return this.age;
	}

	public void setAge(String age) {
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


	public String getComments() {
		return this.comments;
	}

	public void setComments(String comments) {
		this.comments = comments;
	}


	public String getCommunication() {
		return this.communication;
	}

	public void setCommunication(String communication) {
		this.communication = communication;
	}


	@Column(name="CONTINUE_NURSING")
	public String getContinueNursing() {
		return this.continueNursing;
	}

	public void setContinueNursing(String continueNursing) {
		this.continueNursing = continueNursing;
	}


	@Column(name="DAMDANG_NURSE")
	public String getDamdangNurse() {
		return this.damdangNurse;
	}

	public void setDamdangNurse(String damdangNurse) {
		this.damdangNurse = damdangNurse;
	}


	public String getDoctor() {
		return this.doctor;
	}

	public void setDoctor(String doctor) {
		this.doctor = doctor;
	}


	public String getExcretion() {
		return this.excretion;
	}

	public void setExcretion(String excretion) {
		this.excretion = excretion;
	}


	@Column(name="EXCRETION_ADL")
	public String getExcretionAdl() {
		return this.excretionAdl;
	}

	public void setExcretionAdl(String excretionAdl) {
		this.excretionAdl = excretionAdl;
	}


	@Column(name="EXCRETION_ADL_CMT")
	public String getExcretionAdlCmt() {
		return this.excretionAdlCmt;
	}

	public void setExcretionAdlCmt(String excretionAdlCmt) {
		this.excretionAdlCmt = excretionAdlCmt;
	}


	public Double getFkinp1001() {
		return this.fkinp1001;
	}

	public void setFkinp1001(Double fkinp1001) {
		this.fkinp1001 = fkinp1001;
	}


	public String getFood() {
		return this.food;
	}

	public void setFood(String food) {
		this.food = food;
	}


	@Column(name="FOOD_ADL")
	public String getFoodAdl() {
		return this.foodAdl;
	}

	public void setFoodAdl(String foodAdl) {
		this.foodAdl = foodAdl;
	}


	@Column(name="FOOD_ADL_CMT")
	public String getFoodAdlCmt() {
		return this.foodAdlCmt;
	}

	public void setFoodAdlCmt(String foodAdlCmt) {
		this.foodAdlCmt = foodAdlCmt;
	}


	public String getGubun() {
		return this.gubun;
	}

	public void setGubun(String gubun) {
		this.gubun = gubun;
	}


	public String getGwa() {
		return this.gwa;
	}

	public void setGwa(String gwa) {
		this.gwa = gwa;
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


	public String getInfection() {
		return this.infection;
	}

	public void setInfection(String infection) {
		this.infection = infection;
	}


	@Column(name="INPATIENT_COURSE")
	public String getInpatientCourse() {
		return this.inpatientCourse;
	}

	public void setInpatientCourse(String inpatientCourse) {
		this.inpatientCourse = inpatientCourse;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="IPWON_DATE")
	public Date getIpwonDate() {
		return this.ipwonDate;
	}

	public void setIpwonDate(Date ipwonDate) {
		this.ipwonDate = ipwonDate;
	}


	@Column(name="KEY1_HOME")
	public String getKey1Home() {
		return this.key1Home;
	}

	public void setKey1Home(String key1Home) {
		this.key1Home = key1Home;
	}


	@Column(name="KEY1_OFFICE")
	public String getKey1Office() {
		return this.key1Office;
	}

	public void setKey1Office(String key1Office) {
		this.key1Office = key1Office;
	}


	@Column(name="KEY1_PHONE")
	public String getKey1Phone() {
		return this.key1Phone;
	}

	public void setKey1Phone(String key1Phone) {
		this.key1Phone = key1Phone;
	}


	@Column(name="KEY1_RELATION")
	public String getKey1Relation() {
		return this.key1Relation;
	}

	public void setKey1Relation(String key1Relation) {
		this.key1Relation = key1Relation;
	}


	@Column(name="KEY2_HOME")
	public String getKey2Home() {
		return this.key2Home;
	}

	public void setKey2Home(String key2Home) {
		this.key2Home = key2Home;
	}


	@Column(name="KEY2_OFFICE")
	public String getKey2Office() {
		return this.key2Office;
	}

	public void setKey2Office(String key2Office) {
		this.key2Office = key2Office;
	}


	@Column(name="KEY2_PHONE")
	public String getKey2Phone() {
		return this.key2Phone;
	}

	public void setKey2Phone(String key2Phone) {
		this.key2Phone = key2Phone;
	}


	@Column(name="KEY2_RELATION")
	public String getKey2Relation() {
		return this.key2Relation;
	}

	public void setKey2Relation(String key2Relation) {
		this.key2Relation = key2Relation;
	}


	@Column(name="LEADER_NURSE")
	public String getLeaderNurse() {
		return this.leaderNurse;
	}

	public void setLeaderNurse(String leaderNurse) {
		this.leaderNurse = leaderNurse;
	}


	public String getMove() {
		return this.move;
	}

	public void setMove(String move) {
		this.move = move;
	}


	@Column(name="MOVE_ADL")
	public String getMoveAdl() {
		return this.moveAdl;
	}

	public void setMoveAdl(String moveAdl) {
		this.moveAdl = moveAdl;
	}


	@Column(name="MOVE_ADL_CMT")
	public String getMoveAdlCmt() {
		return this.moveAdlCmt;
	}

	public void setMoveAdlCmt(String moveAdlCmt) {
		this.moveAdlCmt = moveAdlCmt;
	}


	@Column(name="NURSING_PASS")
	public String getNursingPass() {
		return this.nursingPass;
	}

	public void setNursingPass(String nursingPass) {
		this.nursingPass = nursingPass;
	}


	@Column(name="PAST_HIS")
	public String getPastHis() {
		return this.pastHis;
	}

	public void setPastHis(String pastHis) {
		this.pastHis = pastHis;
	}


	public Double getPknur9999() {
		return this.pknur9999;
	}

	public void setPknur9999(Double pknur9999) {
		this.pknur9999 = pknur9999;
	}


	public String getReason() {
		return this.reason;
	}

	public void setReason(String reason) {
		this.reason = reason;
	}


	@Column(name="SANG_NAME")
	public String getSangName() {
		return this.sangName;
	}

	public void setSangName(String sangName) {
		this.sangName = sangName;
	}


	public String getSleep() {
		return this.sleep;
	}

	public void setSleep(String sleep) {
		this.sleep = sleep;
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


	public String getTaboo() {
		return this.taboo;
	}

	public void setTaboo(String taboo) {
		this.taboo = taboo;
	}


	public String getTel() {
		return this.tel;
	}

	public void setTel(String tel) {
		this.tel = tel;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="TOIWON_DATE")
	public Date getToiwonDate() {
		return this.toiwonDate;
	}

	public void setToiwonDate(Date toiwonDate) {
		this.toiwonDate = toiwonDate;
	}


	public String getTube() {
		return this.tube;
	}

	public void setTube(String tube) {
		this.tube = tube;
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


	@Column(name="WARE_ADL")
	public String getWareAdl() {
		return this.wareAdl;
	}

	public void setWareAdl(String wareAdl) {
		this.wareAdl = wareAdl;
	}


	@Column(name="WARE_ADL_CMT")
	public String getWareAdlCmt() {
		return this.wareAdlCmt;
	}

	public void setWareAdlCmt(String wareAdlCmt) {
		this.wareAdlCmt = wareAdlCmt;
	}


	public String getWash() {
		return this.wash;
	}

	public void setWash(String wash) {
		this.wash = wash;
	}


	@Column(name="WASH_ADL")
	public String getWashAdl() {
		return this.washAdl;
	}

	public void setWashAdl(String washAdl) {
		this.washAdl = washAdl;
	}


	@Column(name="WASH_ADL_CMT")
	public String getWashAdlCmt() {
		return this.washAdlCmt;
	}

	public void setWashAdlCmt(String washAdlCmt) {
		this.washAdlCmt = washAdlCmt;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="WRITE_DATE")
	public Date getWriteDate() {
		return this.writeDate;
	}

	public void setWriteDate(Date writeDate) {
		this.writeDate = writeDate;
	}

}