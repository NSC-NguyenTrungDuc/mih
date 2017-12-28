package nta.med.core.domain.nur;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the NUR1012 database table.
 * 
 */
@Entity
@NamedQuery(name="Nur1012.findAll", query="SELECT n FROM Nur1012 n")
public class Nur1012 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String bunho;
	private double fkinp1001;
	private String hospCode;
	private Date jukyongDate;
	private String lifeSelfGrade;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Nur1012() {
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


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="JUKYONG_DATE")
	public Date getJukyongDate() {
		return this.jukyongDate;
	}

	public void setJukyongDate(Date jukyongDate) {
		this.jukyongDate = jukyongDate;
	}


	@Column(name="LIFE_SELF_GRADE")
	public String getLifeSelfGrade() {
		return this.lifeSelfGrade;
	}

	public void setLifeSelfGrade(String lifeSelfGrade) {
		this.lifeSelfGrade = lifeSelfGrade;
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