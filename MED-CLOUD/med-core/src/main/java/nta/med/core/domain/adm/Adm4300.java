package nta.med.core.domain.adm;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;

import javax.persistence.*;


/**
 * The persistent class for the ADM4300 database table.
 * 
 */
@Entity
@Table(name="ADM4300")
public class Adm4300 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String asmName;
	private String asmPath;
	private String asmVer;
	private String hospCode;
	private Double menuLevel;
	private String menuParam;
	private String menuTp;
	private String pgmAcsYn;
	private String pgmDupYn;
	private Double pgmEntGrad;
	private String pgmGrpId;
	private String pgmId;
	private String pgmNm;
	private String pgmOpenTp;
	private String pgmScrt;
	private String pgmSysId;
	private Double pgmUpdGrad;
	private String prodId;
	private Double seq;
	private String shortCut;
	private String srvcId;
	private String sysId;
	private String trId;
	private String userId;
	private String language;

	public Adm4300() {
	}

	@Column(name="LANGUAGE")
	public String getLanguage() {
		return this.language;
	}
	
	public void setLanguage(String language) {
		this.language = language;
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


	@Column(name="ASM_VER")
	public String getAsmVer() {
		return this.asmVer;
	}

	public void setAsmVer(String asmVer) {
		this.asmVer = asmVer;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="MENU_LEVEL")
	public Double getMenuLevel() {
		return this.menuLevel;
	}

	public void setMenuLevel(Double menuLevel) {
		this.menuLevel = menuLevel;
	}


	@Column(name="MENU_PARAM")
	public String getMenuParam() {
		return this.menuParam;
	}

	public void setMenuParam(String menuParam) {
		this.menuParam = menuParam;
	}


	@Column(name="MENU_TP")
	public String getMenuTp() {
		return this.menuTp;
	}

	public void setMenuTp(String menuTp) {
		this.menuTp = menuTp;
	}


	@Column(name="PGM_ACS_YN")
	public String getPgmAcsYn() {
		return this.pgmAcsYn;
	}

	public void setPgmAcsYn(String pgmAcsYn) {
		this.pgmAcsYn = pgmAcsYn;
	}


	@Column(name="PGM_DUP_YN")
	public String getPgmDupYn() {
		return this.pgmDupYn;
	}

	public void setPgmDupYn(String pgmDupYn) {
		this.pgmDupYn = pgmDupYn;
	}


	@Column(name="PGM_ENT_GRAD")
	public Double getPgmEntGrad() {
		return this.pgmEntGrad;
	}

	public void setPgmEntGrad(Double pgmEntGrad) {
		this.pgmEntGrad = pgmEntGrad;
	}


	@Column(name="PGM_GRP_ID")
	public String getPgmGrpId() {
		return this.pgmGrpId;
	}

	public void setPgmGrpId(String pgmGrpId) {
		this.pgmGrpId = pgmGrpId;
	}


	@Column(name="PGM_ID")
	public String getPgmId() {
		return this.pgmId;
	}

	public void setPgmId(String pgmId) {
		this.pgmId = pgmId;
	}


	@Column(name="PGM_NM")
	public String getPgmNm() {
		return this.pgmNm;
	}

	public void setPgmNm(String pgmNm) {
		this.pgmNm = pgmNm;
	}


	@Column(name="PGM_OPEN_TP")
	public String getPgmOpenTp() {
		return this.pgmOpenTp;
	}

	public void setPgmOpenTp(String pgmOpenTp) {
		this.pgmOpenTp = pgmOpenTp;
	}


	@Column(name="PGM_SCRT")
	public String getPgmScrt() {
		return this.pgmScrt;
	}

	public void setPgmScrt(String pgmScrt) {
		this.pgmScrt = pgmScrt;
	}


	@Column(name="PGM_SYS_ID")
	public String getPgmSysId() {
		return this.pgmSysId;
	}

	public void setPgmSysId(String pgmSysId) {
		this.pgmSysId = pgmSysId;
	}


	@Column(name="PGM_UPD_GRAD")
	public Double getPgmUpdGrad() {
		return this.pgmUpdGrad;
	}

	public void setPgmUpdGrad(Double pgmUpdGrad) {
		this.pgmUpdGrad = pgmUpdGrad;
	}


	@Column(name="PROD_ID")
	public String getProdId() {
		return this.prodId;
	}

	public void setProdId(String prodId) {
		this.prodId = prodId;
	}


	public Double getSeq() {
		return this.seq;
	}

	public void setSeq(Double seq) {
		this.seq = seq;
	}


	@Column(name="SHORT_CUT")
	public String getShortCut() {
		return this.shortCut;
	}

	public void setShortCut(String shortCut) {
		this.shortCut = shortCut;
	}


	@Column(name="SRVC_ID")
	public String getSrvcId() {
		return this.srvcId;
	}

	public void setSrvcId(String srvcId) {
		this.srvcId = srvcId;
	}


	@Column(name="SYS_ID")
	public String getSysId() {
		return this.sysId;
	}

	public void setSysId(String sysId) {
		this.sysId = sysId;
	}


	@Column(name="TR_ID")
	public String getTrId() {
		return this.trId;
	}

	public void setTrId(String trId) {
		this.trId = trId;
	}


	@Column(name="USER_ID")
	public String getUserId() {
		return this.userId;
	}

	public void setUserId(String userId) {
		this.userId = userId;
	}

}