package nta.med.core.domain.nur;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the NUR1004 database table.
 * 
 */
@Entity
@NamedQuery(name="Nur1004.findAll", query="SELECT n FROM Nur1004 n")
public class Nur1004 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String bunho;
	private double fkinp1001;
	private String hospCode;
	private String result;
	private Date sysDate;
	private String sysId;
	private Date toiwonDate;
	private String toiwonYn;
	private Date updDate;
	private String updId;

	public Nur1004() {
	}


	public String getBunho() {
		return this.bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}


	public double getFkinp1001() {
		return this.fkinp1001;
	}

	public void setFkinp1001(double fkinp1001) {
		this.fkinp1001 = fkinp1001;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	public String getResult() {
		return this.result;
	}

	public void setResult(String result) {
		this.result = result;
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
	@Column(name="TOIWON_DATE")
	public Date getToiwonDate() {
		return this.toiwonDate;
	}

	public void setToiwonDate(Date toiwonDate) {
		this.toiwonDate = toiwonDate;
	}


	@Column(name="TOIWON_YN")
	public String getToiwonYn() {
		return this.toiwonYn;
	}

	public void setToiwonYn(String toiwonYn) {
		this.toiwonYn = toiwonYn;
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