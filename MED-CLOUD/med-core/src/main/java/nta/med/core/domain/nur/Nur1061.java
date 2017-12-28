package nta.med.core.domain.nur;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the NUR1061 database table.
 * 
 */
@Entity
@NamedQuery(name="Nur1061.findAll", query="SELECT n FROM Nur1061 n")
public class Nur1061 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String bunho;
	private Date checkDate;
	private String checkYn;
	private String doctor;
	private double fknur1060;
	private String hospCode;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Nur1061() {
	}


	public String getBunho() {
		return this.bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="CHECK_DATE")
	public Date getCheckDate() {
		return this.checkDate;
	}

	public void setCheckDate(Date checkDate) {
		this.checkDate = checkDate;
	}


	@Column(name="CHECK_YN")
	public String getCheckYn() {
		return this.checkYn;
	}

	public void setCheckYn(String checkYn) {
		this.checkYn = checkYn;
	}


	public String getDoctor() {
		return this.doctor;
	}

	public void setDoctor(String doctor) {
		this.doctor = doctor;
	}


	public double getFknur1060() {
		return this.fknur1060;
	}

	public void setFknur1060(double fknur1060) {
		this.fknur1060 = fknur1060;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
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