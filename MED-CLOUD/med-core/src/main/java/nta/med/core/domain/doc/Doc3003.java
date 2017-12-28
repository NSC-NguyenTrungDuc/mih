package nta.med.core.domain.doc;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the DOC3003 database table.
 * 
 */
@Entity
@NamedQuery(name="Doc3003.findAll", query="SELECT d FROM Doc3003 d")
public class Doc3003 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String dariJwa;
	private String dariU;
	private double fkdoc1001;
	private String gita;
	private double gyoSiryukJwa;
	private double gyoSiryukU;
	private String hospCode;
	private String jeongsin;
	private String jungdok;
	private String palJwa;
	private String palU;
	private String saeksinJwa;
	private String saeksinU;
	private String simsin;
	private double siryukJwa;
	private double siryukU;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Doc3003() {
	}


	@Column(name="DARI_JWA")
	public String getDariJwa() {
		return this.dariJwa;
	}

	public void setDariJwa(String dariJwa) {
		this.dariJwa = dariJwa;
	}


	@Column(name="DARI_U")
	public String getDariU() {
		return this.dariU;
	}

	public void setDariU(String dariU) {
		this.dariU = dariU;
	}


	public double getFkdoc1001() {
		return this.fkdoc1001;
	}

	public void setFkdoc1001(double fkdoc1001) {
		this.fkdoc1001 = fkdoc1001;
	}


	public String getGita() {
		return this.gita;
	}

	public void setGita(String gita) {
		this.gita = gita;
	}


	@Column(name="GYO_SIRYUK_JWA")
	public double getGyoSiryukJwa() {
		return this.gyoSiryukJwa;
	}

	public void setGyoSiryukJwa(double gyoSiryukJwa) {
		this.gyoSiryukJwa = gyoSiryukJwa;
	}


	@Column(name="GYO_SIRYUK_U")
	public double getGyoSiryukU() {
		return this.gyoSiryukU;
	}

	public void setGyoSiryukU(double gyoSiryukU) {
		this.gyoSiryukU = gyoSiryukU;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	public String getJeongsin() {
		return this.jeongsin;
	}

	public void setJeongsin(String jeongsin) {
		this.jeongsin = jeongsin;
	}


	public String getJungdok() {
		return this.jungdok;
	}

	public void setJungdok(String jungdok) {
		this.jungdok = jungdok;
	}


	@Column(name="PAL_JWA")
	public String getPalJwa() {
		return this.palJwa;
	}

	public void setPalJwa(String palJwa) {
		this.palJwa = palJwa;
	}


	@Column(name="PAL_U")
	public String getPalU() {
		return this.palU;
	}

	public void setPalU(String palU) {
		this.palU = palU;
	}


	@Column(name="SAEKSIN_JWA")
	public String getSaeksinJwa() {
		return this.saeksinJwa;
	}

	public void setSaeksinJwa(String saeksinJwa) {
		this.saeksinJwa = saeksinJwa;
	}


	@Column(name="SAEKSIN_U")
	public String getSaeksinU() {
		return this.saeksinU;
	}

	public void setSaeksinU(String saeksinU) {
		this.saeksinU = saeksinU;
	}


	public String getSimsin() {
		return this.simsin;
	}

	public void setSimsin(String simsin) {
		this.simsin = simsin;
	}


	@Column(name="SIRYUK_JWA")
	public double getSiryukJwa() {
		return this.siryukJwa;
	}

	public void setSiryukJwa(double siryukJwa) {
		this.siryukJwa = siryukJwa;
	}


	@Column(name="SIRYUK_U")
	public double getSiryukU() {
		return this.siryukU;
	}

	public void setSiryukU(double siryukU) {
		this.siryukU = siryukU;
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