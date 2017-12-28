package nta.med.core.domain.adm;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;


/**
 * The persistent class for the ADM4500 database table.
 * 
 */
@Entity
@NamedQuery(name="Adm4500.findAll", query="SELECT a FROM Adm4500 a")
public class Adm4500 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String hospCode;
	private double menuLevel;
	private String menuParam;
	private String menuTitle;
	private String menuTp;
	private String pgmId;
	private String pgmOpenTp;
	private String pgmSysId;
	private double seq;
	private String sysId;
	private String trId;
	private String userId;

	public Adm4500() {
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="MENU_LEVEL")
	public double getMenuLevel() {
		return this.menuLevel;
	}

	public void setMenuLevel(double menuLevel) {
		this.menuLevel = menuLevel;
	}


	@Column(name="MENU_PARAM")
	public String getMenuParam() {
		return this.menuParam;
	}

	public void setMenuParam(String menuParam) {
		this.menuParam = menuParam;
	}


	@Column(name="MENU_TITLE")
	public String getMenuTitle() {
		return this.menuTitle;
	}

	public void setMenuTitle(String menuTitle) {
		this.menuTitle = menuTitle;
	}


	@Column(name="MENU_TP")
	public String getMenuTp() {
		return this.menuTp;
	}

	public void setMenuTp(String menuTp) {
		this.menuTp = menuTp;
	}


	@Column(name="PGM_ID")
	public String getPgmId() {
		return this.pgmId;
	}

	public void setPgmId(String pgmId) {
		this.pgmId = pgmId;
	}


	@Column(name="PGM_OPEN_TP")
	public String getPgmOpenTp() {
		return this.pgmOpenTp;
	}

	public void setPgmOpenTp(String pgmOpenTp) {
		this.pgmOpenTp = pgmOpenTp;
	}


	@Column(name="PGM_SYS_ID")
	public String getPgmSysId() {
		return this.pgmSysId;
	}

	public void setPgmSysId(String pgmSysId) {
		this.pgmSysId = pgmSysId;
	}


	public double getSeq() {
		return this.seq;
	}

	public void setSeq(double seq) {
		this.seq = seq;
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