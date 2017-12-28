package nta.med.core.domain.adm;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the ADM0400 database table.
 * 
 */
@Entity
@NamedQuery(name="Adm0400.findAll", query="SELECT a FROM Adm0400 a")
public class Adm0400 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String asmDesc;
	private String asmEssVer;
	private String asmName;
	private String asmPath;
	private String asmType;
	private String asmVer;
	private String crMemb;
	private Date crTime;
	private String crTrm;
	private String grpId;
	private String sysId;
	private String upMemb;
	private Date upTime;
	private String upTrm;

	public Adm0400() {
	}


	@Column(name="ASM_DESC")
	public String getAsmDesc() {
		return this.asmDesc;
	}

	public void setAsmDesc(String asmDesc) {
		this.asmDesc = asmDesc;
	}


	@Column(name="ASM_ESS_VER")
	public String getAsmEssVer() {
		return this.asmEssVer;
	}

	public void setAsmEssVer(String asmEssVer) {
		this.asmEssVer = asmEssVer;
	}


	@Column(name="ASM_NAME")
	public String getAsmName() {
		return this.asmName;
	}

	public void setAsmName(String asmName) {
		this.asmName = asmName;
	}


	@Column(name="ASM_PATH")
	public String getAsmPath() {
		return this.asmPath;
	}

	public void setAsmPath(String asmPath) {
		this.asmPath = asmPath;
	}


	@Column(name="ASM_TYPE")
	public String getAsmType() {
		return this.asmType;
	}

	public void setAsmType(String asmType) {
		this.asmType = asmType;
	}


	@Column(name="ASM_VER")
	public String getAsmVer() {
		return this.asmVer;
	}

	public void setAsmVer(String asmVer) {
		this.asmVer = asmVer;
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


	@Column(name="SYS_ID")
	public String getSysId() {
		return this.sysId;
	}

	public void setSysId(String sysId) {
		this.sysId = sysId;
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

}