package nta.med.core.domain.adm;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the ADM4400 database table.
 * 
 */
@Entity
@NamedQuery(name="Adm4400.findAll", query="SELECT a FROM Adm4400 a")
public class Adm4400 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private Date crTime;
	private String hospCode;
	private String menuTitle;
	private String pgmMenuYn;
	private String pgmSysId;
	private String pgmTrId;
	private String sysId;
	private String trId;
	private double trSeq;
	private String upprMenu;
	private String userId;

	public Adm4400() {
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="CR_TIME")
	public Date getCrTime() {
		return this.crTime;
	}

	public void setCrTime(Date crTime) {
		this.crTime = crTime;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="MENU_TITLE")
	public String getMenuTitle() {
		return this.menuTitle;
	}

	public void setMenuTitle(String menuTitle) {
		this.menuTitle = menuTitle;
	}


	@Column(name="PGM_MENU_YN")
	public String getPgmMenuYn() {
		return this.pgmMenuYn;
	}

	public void setPgmMenuYn(String pgmMenuYn) {
		this.pgmMenuYn = pgmMenuYn;
	}


	@Column(name="PGM_SYS_ID")
	public String getPgmSysId() {
		return this.pgmSysId;
	}

	public void setPgmSysId(String pgmSysId) {
		this.pgmSysId = pgmSysId;
	}


	@Column(name="PGM_TR_ID")
	public String getPgmTrId() {
		return this.pgmTrId;
	}

	public void setPgmTrId(String pgmTrId) {
		this.pgmTrId = pgmTrId;
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


	@Column(name="TR_SEQ")
	public double getTrSeq() {
		return this.trSeq;
	}

	public void setTrSeq(double trSeq) {
		this.trSeq = trSeq;
	}


	@Column(name="UPPR_MENU")
	public String getUpprMenu() {
		return this.upprMenu;
	}

	public void setUpprMenu(String upprMenu) {
		this.upprMenu = upprMenu;
	}


	@Column(name="USER_ID")
	public String getUserId() {
		return this.userId;
	}

	public void setUserId(String userId) {
		this.userId = userId;
	}

}