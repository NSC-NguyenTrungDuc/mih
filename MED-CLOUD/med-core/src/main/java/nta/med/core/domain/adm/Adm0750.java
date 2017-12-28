package nta.med.core.domain.adm;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the ADM0750 database table.
 * 
 */
@Entity
@NamedQuery(name="Adm0750.findAll", query="SELECT a FROM Adm0750 a")
public class Adm0750 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String beopoGubun;
	private String crMemb;
	private Date crTime;
	private String crTrm;
	private String hospCode;
	private String recvSpot;
	private double seq;
	private String userId;

	public Adm0750() {
	}


	@Column(name="BEOPO_GUBUN")
	public String getBeopoGubun() {
		return this.beopoGubun;
	}

	public void setBeopoGubun(String beopoGubun) {
		this.beopoGubun = beopoGubun;
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


	@Column(name="RECV_SPOT")
	public String getRecvSpot() {
		return this.recvSpot;
	}

	public void setRecvSpot(String recvSpot) {
		this.recvSpot = recvSpot;
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