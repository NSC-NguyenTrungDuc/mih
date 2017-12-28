package nta.med.core.domain.bas;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the BAS0123 database table.
 * 
 */
@Entity
@Table(name="BAS0123")
public class Bas0123 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String autoYn;
	private String displayYn;
	private String hyunnaeYn;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;
	private String zipCode;
	private String zipCode1;
	private String zipCode2;
	private String zipNameGana1;
	private String zipNameGana2;
	private String zipNameGana3;
	private String zipName1;
	private String zipName2;
	private String zipName3;
	private String zipTonggye;

	public Bas0123() {
	}


	@Column(name="AUTO_YN")
	public String getAutoYn() {
		return this.autoYn;
	}

	public void setAutoYn(String autoYn) {
		this.autoYn = autoYn;
	}


	@Column(name="DISPLAY_YN")
	public String getDisplayYn() {
		return this.displayYn;
	}

	public void setDisplayYn(String displayYn) {
		this.displayYn = displayYn;
	}

	@Column(name="HYUNNAE_YN")
	public String getHyunnaeYn() {
		return this.hyunnaeYn;
	}

	public void setHyunnaeYn(String hyunnaeYn) {
		this.hyunnaeYn = hyunnaeYn;
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


	@Column(name="ZIP_CODE")
	public String getZipCode() {
		return this.zipCode;
	}

	public void setZipCode(String zipCode) {
		this.zipCode = zipCode;
	}


	@Column(name="ZIP_CODE1")
	public String getZipCode1() {
		return this.zipCode1;
	}

	public void setZipCode1(String zipCode1) {
		this.zipCode1 = zipCode1;
	}


	@Column(name="ZIP_CODE2")
	public String getZipCode2() {
		return this.zipCode2;
	}

	public void setZipCode2(String zipCode2) {
		this.zipCode2 = zipCode2;
	}


	@Column(name="ZIP_NAME_GANA1")
	public String getZipNameGana1() {
		return this.zipNameGana1;
	}

	public void setZipNameGana1(String zipNameGana1) {
		this.zipNameGana1 = zipNameGana1;
	}


	@Column(name="ZIP_NAME_GANA2")
	public String getZipNameGana2() {
		return this.zipNameGana2;
	}

	public void setZipNameGana2(String zipNameGana2) {
		this.zipNameGana2 = zipNameGana2;
	}


	@Column(name="ZIP_NAME_GANA3")
	public String getZipNameGana3() {
		return this.zipNameGana3;
	}

	public void setZipNameGana3(String zipNameGana3) {
		this.zipNameGana3 = zipNameGana3;
	}


	@Column(name="ZIP_NAME1")
	public String getZipName1() {
		return this.zipName1;
	}

	public void setZipName1(String zipName1) {
		this.zipName1 = zipName1;
	}


	@Column(name="ZIP_NAME2")
	public String getZipName2() {
		return this.zipName2;
	}

	public void setZipName2(String zipName2) {
		this.zipName2 = zipName2;
	}


	@Column(name="ZIP_NAME3")
	public String getZipName3() {
		return this.zipName3;
	}

	public void setZipName3(String zipName3) {
		this.zipName3 = zipName3;
	}


	@Column(name="ZIP_TONGGYE")
	public String getZipTonggye() {
		return this.zipTonggye;
	}

	public void setZipTonggye(String zipTonggye) {
		this.zipTonggye = zipTonggye;
	}

}