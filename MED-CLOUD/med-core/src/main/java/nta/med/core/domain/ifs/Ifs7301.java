package nta.med.core.domain.ifs;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the IFS7301 database table.
 * 
 */
@Entity
@Table(name="IFS7301")
public class Ifs7301 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String birthday;
	private String bunho;
	private String cancerFlag;
	private String doctorName;
	private Double drgBunho;
	private String drguserName;
	private Double fkdrg5010;
	private String gwa;
	private String hospCode;
	private String ifErr;
	private String ifFlag;
	private String jojeDate;
	private String patMemo;
	private String patName;
	private Double pkifs7301;
	private String recGubunDoctor;
	private String recGubunDrguser;
	private String recGubunMemo;
	private String recGubunPat;
	private String sex;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Ifs7301() {
	}


	public String getBirthday() {
		return this.birthday;
	}

	public void setBirthday(String birthday) {
		this.birthday = birthday;
	}


	public String getBunho() {
		return this.bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}


	@Column(name="CANCER_FLAG")
	public String getCancerFlag() {
		return this.cancerFlag;
	}

	public void setCancerFlag(String cancerFlag) {
		this.cancerFlag = cancerFlag;
	}


	@Column(name="DOCTOR_NAME")
	public String getDoctorName() {
		return this.doctorName;
	}

	public void setDoctorName(String doctorName) {
		this.doctorName = doctorName;
	}


	@Column(name="DRG_BUNHO")
	public Double getDrgBunho() {
		return this.drgBunho;
	}

	public void setDrgBunho(Double drgBunho) {
		this.drgBunho = drgBunho;
	}


	@Column(name="DRGUSER_NAME")
	public String getDrguserName() {
		return this.drguserName;
	}

	public void setDrguserName(String drguserName) {
		this.drguserName = drguserName;
	}


	public Double getFkdrg5010() {
		return this.fkdrg5010;
	}

	public void setFkdrg5010(Double fkdrg5010) {
		this.fkdrg5010 = fkdrg5010;
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


	@Column(name="JOJE_DATE")
	public String getJojeDate() {
		return this.jojeDate;
	}

	public void setJojeDate(String jojeDate) {
		this.jojeDate = jojeDate;
	}


	@Column(name="PAT_MEMO")
	public String getPatMemo() {
		return this.patMemo;
	}

	public void setPatMemo(String patMemo) {
		this.patMemo = patMemo;
	}


	@Column(name="PAT_NAME")
	public String getPatName() {
		return this.patName;
	}

	public void setPatName(String patName) {
		this.patName = patName;
	}


	public Double getPkifs7301() {
		return this.pkifs7301;
	}

	public void setPkifs7301(Double pkifs7301) {
		this.pkifs7301 = pkifs7301;
	}


	@Column(name="REC_GUBUN_DOCTOR")
	public String getRecGubunDoctor() {
		return this.recGubunDoctor;
	}

	public void setRecGubunDoctor(String recGubunDoctor) {
		this.recGubunDoctor = recGubunDoctor;
	}


	@Column(name="REC_GUBUN_DRGUSER")
	public String getRecGubunDrguser() {
		return this.recGubunDrguser;
	}

	public void setRecGubunDrguser(String recGubunDrguser) {
		this.recGubunDrguser = recGubunDrguser;
	}


	@Column(name="REC_GUBUN_MEMO")
	public String getRecGubunMemo() {
		return this.recGubunMemo;
	}

	public void setRecGubunMemo(String recGubunMemo) {
		this.recGubunMemo = recGubunMemo;
	}


	@Column(name="REC_GUBUN_PAT")
	public String getRecGubunPat() {
		return this.recGubunPat;
	}

	public void setRecGubunPat(String recGubunPat) {
		this.recGubunPat = recGubunPat;
	}


	public String getSex() {
		return this.sex;
	}

	public void setSex(String sex) {
		this.sex = sex;
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