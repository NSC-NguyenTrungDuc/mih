package nta.med.core.domain.oif;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the OIF1101 database table.
 * 
 */
@Entity
@NamedQuery(name="Oif1101.findAll", query="SELECT o FROM Oif1101 o")
public class Oif1101 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String accntNum;
	private Date actingDate;
	private Date birth;
	private String bunho;
	private String cmId;
	private String death;
	private String deathDate;
	private String degree;
	private String docUid;
	private String email;
	private String endFlag;
	private String errMsg;
	private double fkinp3010;
	private double fkout1003;
	private String hospCode;
	private String license;
	private String marital;
	private String nationality;
	private double pkoif1101;
	private Date sendDate;
	private String sex;
	private String socialid;
	private String suname1;
	private String suname2;
	private String suname3;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Oif1101() {
	}


	@Column(name="ACCNT_NUM")
	public String getAccntNum() {
		return this.accntNum;
	}

	public void setAccntNum(String accntNum) {
		this.accntNum = accntNum;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="ACTING_DATE")
	public Date getActingDate() {
		return this.actingDate;
	}

	public void setActingDate(Date actingDate) {
		this.actingDate = actingDate;
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


	@Column(name="CM_ID")
	public String getCmId() {
		return this.cmId;
	}

	public void setCmId(String cmId) {
		this.cmId = cmId;
	}


	public String getDeath() {
		return this.death;
	}

	public void setDeath(String death) {
		this.death = death;
	}


	@Column(name="DEATH_DATE")
	public String getDeathDate() {
		return this.deathDate;
	}

	public void setDeathDate(String deathDate) {
		this.deathDate = deathDate;
	}


	public String getDegree() {
		return this.degree;
	}

	public void setDegree(String degree) {
		this.degree = degree;
	}


	@Column(name="DOC_UID")
	public String getDocUid() {
		return this.docUid;
	}

	public void setDocUid(String docUid) {
		this.docUid = docUid;
	}


	public String getEmail() {
		return this.email;
	}

	public void setEmail(String email) {
		this.email = email;
	}


	@Column(name="END_FLAG")
	public String getEndFlag() {
		return this.endFlag;
	}

	public void setEndFlag(String endFlag) {
		this.endFlag = endFlag;
	}


	@Column(name="ERR_MSG")
	public String getErrMsg() {
		return this.errMsg;
	}

	public void setErrMsg(String errMsg) {
		this.errMsg = errMsg;
	}


	public double getFkinp3010() {
		return this.fkinp3010;
	}

	public void setFkinp3010(double fkinp3010) {
		this.fkinp3010 = fkinp3010;
	}


	public double getFkout1003() {
		return this.fkout1003;
	}

	public void setFkout1003(double fkout1003) {
		this.fkout1003 = fkout1003;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	public String getLicense() {
		return this.license;
	}

	public void setLicense(String license) {
		this.license = license;
	}


	public String getMarital() {
		return this.marital;
	}

	public void setMarital(String marital) {
		this.marital = marital;
	}


	public String getNationality() {
		return this.nationality;
	}

	public void setNationality(String nationality) {
		this.nationality = nationality;
	}


	public double getPkoif1101() {
		return this.pkoif1101;
	}

	public void setPkoif1101(double pkoif1101) {
		this.pkoif1101 = pkoif1101;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="SEND_DATE")
	public Date getSendDate() {
		return this.sendDate;
	}

	public void setSendDate(Date sendDate) {
		this.sendDate = sendDate;
	}


	public String getSex() {
		return this.sex;
	}

	public void setSex(String sex) {
		this.sex = sex;
	}


	public String getSocialid() {
		return this.socialid;
	}

	public void setSocialid(String socialid) {
		this.socialid = socialid;
	}


	public String getSuname1() {
		return this.suname1;
	}

	public void setSuname1(String suname1) {
		this.suname1 = suname1;
	}


	public String getSuname2() {
		return this.suname2;
	}

	public void setSuname2(String suname2) {
		this.suname2 = suname2;
	}


	public String getSuname3() {
		return this.suname3;
	}

	public void setSuname3(String suname3) {
		this.suname3 = suname3;
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