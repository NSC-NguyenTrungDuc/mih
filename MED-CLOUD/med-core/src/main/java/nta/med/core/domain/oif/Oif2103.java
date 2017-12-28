package nta.med.core.domain.oif;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the OIF2103 database table.
 * 
 */
@Entity
@NamedQuery(name="Oif2103.findAll", query="SELECT o FROM Oif2103 o")
public class Oif2103 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String diseases;
	private double fkoif1101;
	private double fkoif2101;
	private String hospCode;
	private double pkSeq;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Oif2103() {
	}


	public String getDiseases() {
		return this.diseases;
	}

	public void setDiseases(String diseases) {
		this.diseases = diseases;
	}


	public double getFkoif1101() {
		return this.fkoif1101;
	}

	public void setFkoif1101(double fkoif1101) {
		this.fkoif1101 = fkoif1101;
	}


	public double getFkoif2101() {
		return this.fkoif2101;
	}

	public void setFkoif2101(double fkoif2101) {
		this.fkoif2101 = fkoif2101;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="PK_SEQ")
	public double getPkSeq() {
		return this.pkSeq;
	}

	public void setPkSeq(double pkSeq) {
		this.pkSeq = pkSeq;
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