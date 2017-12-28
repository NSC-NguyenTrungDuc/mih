package nta.med.core.domain.ifs;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the IFS7601 database table.
 * 
 */
@Entity
@NamedQuery(name="Ifs7601.findAll", query="SELECT i FROM Ifs7601 i")
public class Ifs7601 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String birthday;
	private String bp;
	private String bunho;
	private String depart1;
	private String depart2;
	private String drgInfo;
	private double fkpfe5010;
	private String height;
	private String hospCode;
	private String ifErr;
	private String ifFlag;
	private String kanaName;
	private double pkifs7601;
	private String remark;
	private String sex;
	private String symptoms;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;
	private String weight;

	public Ifs7601() {
	}


	public String getBirthday() {
		return this.birthday;
	}

	public void setBirthday(String birthday) {
		this.birthday = birthday;
	}


	public String getBp() {
		return this.bp;
	}

	public void setBp(String bp) {
		this.bp = bp;
	}


	public String getBunho() {
		return this.bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}


	public String getDepart1() {
		return this.depart1;
	}

	public void setDepart1(String depart1) {
		this.depart1 = depart1;
	}


	public String getDepart2() {
		return this.depart2;
	}

	public void setDepart2(String depart2) {
		this.depart2 = depart2;
	}


	@Column(name="DRG_INFO")
	public String getDrgInfo() {
		return this.drgInfo;
	}

	public void setDrgInfo(String drgInfo) {
		this.drgInfo = drgInfo;
	}


	public double getFkpfe5010() {
		return this.fkpfe5010;
	}

	public void setFkpfe5010(double fkpfe5010) {
		this.fkpfe5010 = fkpfe5010;
	}


	public String getHeight() {
		return this.height;
	}

	public void setHeight(String height) {
		this.height = height;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="IF_ERR")
	public String getIfErr() {
		return this.ifErr;
	}

	public void setIfErr(String ifErr) {
		this.ifErr = ifErr;
	}


	@Column(name="IF_FLAG")
	public String getIfFlag() {
		return this.ifFlag;
	}

	public void setIfFlag(String ifFlag) {
		this.ifFlag = ifFlag;
	}


	@Column(name="KANA_NAME")
	public String getKanaName() {
		return this.kanaName;
	}

	public void setKanaName(String kanaName) {
		this.kanaName = kanaName;
	}


	public double getPkifs7601() {
		return this.pkifs7601;
	}

	public void setPkifs7601(double pkifs7601) {
		this.pkifs7601 = pkifs7601;
	}


	public String getRemark() {
		return this.remark;
	}

	public void setRemark(String remark) {
		this.remark = remark;
	}


	public String getSex() {
		return this.sex;
	}

	public void setSex(String sex) {
		this.sex = sex;
	}


	public String getSymptoms() {
		return this.symptoms;
	}

	public void setSymptoms(String symptoms) {
		this.symptoms = symptoms;
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


	public String getWeight() {
		return this.weight;
	}

	public void setWeight(String weight) {
		this.weight = weight;
	}

}