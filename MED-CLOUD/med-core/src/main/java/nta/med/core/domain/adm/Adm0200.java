package nta.med.core.domain.adm;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;


/**
 * The persistent class for the ADM0200 database table.
 * 
 */
@Entity
@Table(name="ADM0200")
public class Adm0200 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String admSysYn;
	private String crMemb;
	private Date crTime;
	private String crTrm;
	private String grpId;
	private String mangDept;
	private String mangDept1;
	private String msgSysYn;
	private String sysDesc;
	private String sysId;
	private String sysNm;
	private Double sysSeq;
	private String upMemb;
	private Date upTime;
	private String upTrm;
	private String language;

	public Adm0200() {
	}


	@Column(name="ADM_SYS_YN")
	public String getAdmSysYn() {
		return this.admSysYn;
	}

	public void setAdmSysYn(String admSysYn) {
		this.admSysYn = admSysYn;
	}


	@Column(name="CR_MEMB")
	public String getCrMemb() {
		return this.crMemb;
	}

	public void setCrMemb(String crMemb) {
		this.crMemb = crMemb;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="CR_TIME")
	public Date getCrTime() {
		return this.crTime;
	}

	public void setCrTime(Date crTime) {
		this.crTime = crTime;
	}


	@Column(name="CR_TRM")
	public String getCrTrm() {
		return this.crTrm;
	}

	public void setCrTrm(String crTrm) {
		this.crTrm = crTrm;
	}


	@Column(name="GRP_ID")
	public String getGrpId() {
		return this.grpId;
	}

	public void setGrpId(String grpId) {
		this.grpId = grpId;
	}


	@Column(name="MANG_DEPT")
	public String getMangDept() {
		return this.mangDept;
	}

	public void setMangDept(String mangDept) {
		this.mangDept = mangDept;
	}


	@Column(name="MANG_DEPT1")
	public String getMangDept1() {
		return this.mangDept1;
	}

	public void setMangDept1(String mangDept1) {
		this.mangDept1 = mangDept1;
	}


	@Column(name="MSG_SYS_YN")
	public String getMsgSysYn() {
		return this.msgSysYn;
	}

	public void setMsgSysYn(String msgSysYn) {
		this.msgSysYn = msgSysYn;
	}


	@Column(name="SYS_DESC")
	public String getSysDesc() {
		return this.sysDesc;
	}

	public void setSysDesc(String sysDesc) {
		this.sysDesc = sysDesc;
	}


	@Column(name="SYS_ID")
	public String getSysId() {
		return this.sysId;
	}

	public void setSysId(String sysId) {
		this.sysId = sysId;
	}


	@Column(name="SYS_NM")
	public String getSysNm() {
		return this.sysNm;
	}

	public void setSysNm(String sysNm) {
		this.sysNm = sysNm;
	}


	@Column(name="SYS_SEQ")
	public Double getSysSeq() {
		return this.sysSeq;
	}

	public void setSysSeq(Double sysSeq) {
		this.sysSeq = sysSeq;
	}


	@Column(name="UP_MEMB")
	public String getUpMemb() {
		return this.upMemb;
	}

	public void setUpMemb(String upMemb) {
		this.upMemb = upMemb;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="UP_TIME")
	public Date getUpTime() {
		return this.upTime;
	}

	public void setUpTime(Date upTime) {
		this.upTime = upTime;
	}


	@Column(name="UP_TRM")
	public String getUpTrm() {
		return this.upTrm;
	}

	public void setUpTrm(String upTrm) {
		this.upTrm = upTrm;
	}
	
	@Column(name="LANGUAGE")
	public String getLanguage() {
		return this.language;
	}
	
	public void setLanguage(String language) {
		this.language = language;
	}
	
}