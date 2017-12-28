package nta.med.core.domain.ocs;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the OCS2025 database table.
 * 
 */
@Entity
@NamedQuery(name="Ocs2025.findAll", query="SELECT o FROM Ocs2025 o")
public class Ocs2025 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String bunho;
	private String bunhoRemark;
	private double bunhoSeq;
	private String cardex;
	private String cardexGubun;
	private String hospCode;
	private String inputGubun;
	private String ipAddress;
	private String remark1;
	private double seq;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Ocs2025() {
	}


	public String getBunho() {
		return this.bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}


	@Column(name="BUNHO_REMARK")
	public String getBunhoRemark() {
		return this.bunhoRemark;
	}

	public void setBunhoRemark(String bunhoRemark) {
		this.bunhoRemark = bunhoRemark;
	}


	@Column(name="BUNHO_SEQ")
	public double getBunhoSeq() {
		return this.bunhoSeq;
	}

	public void setBunhoSeq(double bunhoSeq) {
		this.bunhoSeq = bunhoSeq;
	}


	public String getCardex() {
		return this.cardex;
	}

	public void setCardex(String cardex) {
		this.cardex = cardex;
	}


	@Column(name="CARDEX_GUBUN")
	public String getCardexGubun() {
		return this.cardexGubun;
	}

	public void setCardexGubun(String cardexGubun) {
		this.cardexGubun = cardexGubun;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="INPUT_GUBUN")
	public String getInputGubun() {
		return this.inputGubun;
	}

	public void setInputGubun(String inputGubun) {
		this.inputGubun = inputGubun;
	}


	@Column(name="IP_ADDRESS")
	public String getIpAddress() {
		return this.ipAddress;
	}

	public void setIpAddress(String ipAddress) {
		this.ipAddress = ipAddress;
	}


	public String getRemark1() {
		return this.remark1;
	}

	public void setRemark1(String remark1) {
		this.remark1 = remark1;
	}


	public double getSeq() {
		return this.seq;
	}

	public void setSeq(double seq) {
		this.seq = seq;
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