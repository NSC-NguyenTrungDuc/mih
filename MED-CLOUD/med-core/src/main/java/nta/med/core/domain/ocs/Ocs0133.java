package nta.med.core.domain.ocs;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.NamedQuery;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;


/**
 * The persistent class for the OCS0133 database table.
 * 
 */
@Entity
@NamedQuery(name="Ocs0133.findAll", query="SELECT o FROM Ocs0133 o")
@Table(name="OCS0133")
public class Ocs0133 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String amtCrYn;
	private String bogyongCodeCrYn;
	private String dvCrYn;
	private String hospCode;
	private String inputControl;
	private String inputControlName;
	private String jusaCrYn;
	private String nalsuCrYn;
	private String ordDanuiCrYn;
	private String portableCrYn;
	private String powderYnCrYn;
	private String specimenCrYn;
	private String suryangCrYn;
	private Date sysDate;
	private String sysId;
	private String toiwonDrgCrYn;
	private Date updDate;
	private String updId;
	private String wonyoiOrderYnCrYn;
	private String language;

	public Ocs0133() {
	}


	@Column(name="AMT_CR_YN")
	public String getAmtCrYn() {
		return this.amtCrYn;
	}

	public void setAmtCrYn(String amtCrYn) {
		this.amtCrYn = amtCrYn;
	}


	@Column(name="BOGYONG_CODE_CR_YN")
	public String getBogyongCodeCrYn() {
		return this.bogyongCodeCrYn;
	}

	public void setBogyongCodeCrYn(String bogyongCodeCrYn) {
		this.bogyongCodeCrYn = bogyongCodeCrYn;
	}


	@Column(name="DV_CR_YN")
	public String getDvCrYn() {
		return this.dvCrYn;
	}

	public void setDvCrYn(String dvCrYn) {
		this.dvCrYn = dvCrYn;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="INPUT_CONTROL")
	public String getInputControl() {
		return this.inputControl;
	}

	public void setInputControl(String inputControl) {
		this.inputControl = inputControl;
	}


	@Column(name="INPUT_CONTROL_NAME")
	public String getInputControlName() {
		return this.inputControlName;
	}

	public void setInputControlName(String inputControlName) {
		this.inputControlName = inputControlName;
	}


	@Column(name="JUSA_CR_YN")
	public String getJusaCrYn() {
		return this.jusaCrYn;
	}

	public void setJusaCrYn(String jusaCrYn) {
		this.jusaCrYn = jusaCrYn;
	}


	@Column(name="NALSU_CR_YN")
	public String getNalsuCrYn() {
		return this.nalsuCrYn;
	}

	public void setNalsuCrYn(String nalsuCrYn) {
		this.nalsuCrYn = nalsuCrYn;
	}


	@Column(name="ORD_DANUI_CR_YN")
	public String getOrdDanuiCrYn() {
		return this.ordDanuiCrYn;
	}

	public void setOrdDanuiCrYn(String ordDanuiCrYn) {
		this.ordDanuiCrYn = ordDanuiCrYn;
	}


	@Column(name="PORTABLE_CR_YN")
	public String getPortableCrYn() {
		return this.portableCrYn;
	}

	public void setPortableCrYn(String portableCrYn) {
		this.portableCrYn = portableCrYn;
	}


	@Column(name="POWDER_YN_CR_YN")
	public String getPowderYnCrYn() {
		return this.powderYnCrYn;
	}

	public void setPowderYnCrYn(String powderYnCrYn) {
		this.powderYnCrYn = powderYnCrYn;
	}


	@Column(name="SPECIMEN_CR_YN")
	public String getSpecimenCrYn() {
		return this.specimenCrYn;
	}

	public void setSpecimenCrYn(String specimenCrYn) {
		this.specimenCrYn = specimenCrYn;
	}


	@Column(name="SURYANG_CR_YN")
	public String getSuryangCrYn() {
		return this.suryangCrYn;
	}

	public void setSuryangCrYn(String suryangCrYn) {
		this.suryangCrYn = suryangCrYn;
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


	@Column(name="TOIWON_DRG_CR_YN")
	public String getToiwonDrgCrYn() {
		return this.toiwonDrgCrYn;
	}

	public void setToiwonDrgCrYn(String toiwonDrgCrYn) {
		this.toiwonDrgCrYn = toiwonDrgCrYn;
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


	@Column(name="WONYOI_ORDER_YN_CR_YN")
	public String getWonyoiOrderYnCrYn() {
		return this.wonyoiOrderYnCrYn;
	}

	public void setWonyoiOrderYnCrYn(String wonyoiOrderYnCrYn) {
		this.wonyoiOrderYnCrYn = wonyoiOrderYnCrYn;
	}
	
	@Column(name="LANGUAGE")
	public String getLanguage() {
		return language;
	}

	public void setLanguage(String language) {
		this.language = language;
	}

}