package nta.med.core.domain.adm;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the ADM0740 database table.
 * 
 */
@Entity
@NamedQuery(name="Adm0740.findAll", query="SELECT a FROM Adm0740 a")
public class Adm0740 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String beopoDesc;
	private String beopoName;
	private String crMemb;
	private Date crTime;
	private String crTrm;
	private String hospCode;
	private double seq;
	private String userId;

	public Adm0740() {
	}


	@Column(name="BEOPO_DESC")
	public String getBeopoDesc() {
		return this.beopoDesc;
	}

	public void setBeopoDesc(String beopoDesc) {
		this.beopoDesc = beopoDesc;
	}


	@Column(name="BEOPO_NAME")
	public String getBeopoName() {
		return this.beopoName;
	}

	public void setBeopoName(String beopoName) {
		this.beopoName = beopoName;
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


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	public double getSeq() {
		return this.seq;
	}

	public void setSeq(double seq) {
		this.seq = seq;
	}


	@Column(name="USER_ID")
	public String getUserId() {
		return this.userId;
	}

	public void setUserId(String userId) {
		this.userId = userId;
	}

}