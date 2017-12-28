package nta.med.core.domain.adm;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;


/**
 * The persistent class for the ADM4100 database table.
 * 
 */
@Entity
@Table(name="ADM4100")
public class Adm4100 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String crMemb;
	private Date crTime;
	private String crTrm;
	private String menuParam;
	private String menuTitle;
	private String pgmId;
	private String pgmOpenTp;
	private String shortCut;
	private String sysId;
	private String trId;
	private Double trSeq;
	private String upMemb;
	private Date upTime;
	private String upTrm;
	private String upprMenu;
	private String language;

	public Adm4100() {
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


	@Column(name="SHORT_CUT")
	public String getShortCut() {
		return this.shortCut;
	}

	public void setShortCut(String shortCut) {
		this.shortCut = shortCut;
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
	public Double getTrSeq() {
		return this.trSeq;
	}

	public void setTrSeq(Double trSeq) {
		this.trSeq = trSeq;
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


	@Column(name="UPPR_MENU")
	public String getUpprMenu() {
		return this.upprMenu;
	}

	public void setUpprMenu(String upprMenu) {
		this.upprMenu = upprMenu;
	}

	@Column(name="LANGUAGE")
	public String getLanguage() {
		return language;
	}

	public void setLanguage(String language) {
		this.language = language;
	}

}