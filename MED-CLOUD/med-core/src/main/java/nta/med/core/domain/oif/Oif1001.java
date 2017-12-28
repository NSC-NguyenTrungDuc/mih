package nta.med.core.domain.oif;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the OIF1001 database table.
 * 
 */
@Entity
@NamedQuery(name="Oif1001.findAll", query="SELECT o FROM Oif1001 o")
public class Oif1001 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String accntNum;
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
	private String hospCode;
	private String license;
	private String marital;
	private String nationality;
	private double pkoif1001;
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

	public Oif1001() {
	}


	@Column(name="ACCNT_NUM")
	public String getAccntNum() {
		return this.accntNum;
	}

	public void setAccntNum(String accntNum) {
		this.accntNum = accntNum;
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


	public double getPkoif1001() {
		return this.pkoif1001;
	}

	public void setPkoif1001(double pkoif1001) {
		this.pkoif1001 = pkoif1001;
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