package nta.med.core.domain.cpl;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the CPL9001 database table.
 * 
 */
@Entity
@NamedQuery(name="Cpl9001.findAll", query="SELECT c FROM Cpl9001 c")
public class Cpl9001 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String bunho;
	private double fkcpl9000;
	private String hangmogCode;
	private String hospCode;
	private String iraiKey;
	private double pkcpl9001;
	private String specimenCode;
	private String specimenSer;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Cpl9001() {
	}


	public String getBunho() {
		return this.bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}


	public double getFkcpl9000() {
		return this.fkcpl9000;
	}

	public void setFkcpl9000(double fkcpl9000) {
		this.fkcpl9000 = fkcpl9000;
	}


	@Column(name="HANGMOG_CODE")
	public String getHangmogCode() {
		return this.hangmogCode;
	}

	public void setHangmogCode(String hangmogCode) {
		this.hangmogCode = hangmogCode;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="IRAI_KEY")
	public String getIraiKey() {
		return this.iraiKey;
	}

	public void setIraiKey(String iraiKey) {
		this.iraiKey = iraiKey;
	}


	public double getPkcpl9001() {
		return this.pkcpl9001;
	}

	public void setPkcpl9001(double pkcpl9001) {
		this.pkcpl9001 = pkcpl9001;
	}


	@Column(name="SPECIMEN_CODE")
	public String getSpecimenCode() {
		return this.specimenCode;
	}

	public void setSpecimenCode(String specimenCode) {
		this.specimenCode = specimenCode;
	}


	@Column(name="SPECIMEN_SER")
	public String getSpecimenSer() {
		return this.specimenSer;
	}

	public void setSpecimenSer(String specimenSer) {
		this.specimenSer = specimenSer;
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