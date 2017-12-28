package nta.med.core.domain.adm;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the ADM0710 database table.
 * 
 */
@Entity
@NamedQuery(name="Adm0710.findAll", query="SELECT a FROM Adm0710 a")
public class Adm0710 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String cnfmYn;
	private String crMemb;
	private Date crTime;
	private String crTrm;
	private String fileAtchYn;
	private String hospCode;
	private String recvAllCnfmYn;
	private String recvSpot;
	private String recvSpotYn;
	private String recverId;
	private Date sendDt;
	private double sendSeq;
	private String senderId;
	private String upMemb;
	private Date upTime;
	private String upTrm;
	private String validYn;

	public Adm0710() {
	}


	@Column(name="CNFM_YN")
	public String getCnfmYn() {
		return this.cnfmYn;
	}

	public void setCnfmYn(String cnfmYn) {
		this.cnfmYn = cnfmYn;
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


	@Column(name="FILE_ATCH_YN")
	public String getFileAtchYn() {
		return this.fileAtchYn;
	}

	public void setFileAtchYn(String fileAtchYn) {
		this.fileAtchYn = fileAtchYn;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="RECV_ALL_CNFM_YN")
	public String getRecvAllCnfmYn() {
		return this.recvAllCnfmYn;
	}

	public void setRecvAllCnfmYn(String recvAllCnfmYn) {
		this.recvAllCnfmYn = recvAllCnfmYn;
	}


	@Column(name="RECV_SPOT")
	public String getRecvSpot() {
		return this.recvSpot;
	}

	public void setRecvSpot(String recvSpot) {
		this.recvSpot = recvSpot;
	}


	@Column(name="RECV_SPOT_YN")
	public String getRecvSpotYn() {
		return this.recvSpotYn;
	}

	public void setRecvSpotYn(String recvSpotYn) {
		this.recvSpotYn = recvSpotYn;
	}


	@Column(name="RECVER_ID")
	public String getRecverId() {
		return this.recverId;
	}

	public void setRecverId(String recverId) {
		this.recverId = recverId;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="SEND_DT")
	public Date getSendDt() {
		return this.sendDt;
	}

	public void setSendDt(Date sendDt) {
		this.sendDt = sendDt;
	}


	@Column(name="SEND_SEQ")
	public double getSendSeq() {
		return this.sendSeq;
	}

	public void setSendSeq(double sendSeq) {
		this.sendSeq = sendSeq;
	}


	@Column(name="SENDER_ID")
	public String getSenderId() {
		return this.senderId;
	}

	public void setSenderId(String senderId) {
		this.senderId = senderId;
	}


	@Column(name="UP_MEMB")
	public String getUpMemb() {
		return this.upMemb;
	}

	public void setUpMemb(String upMemb) {
		this.upMemb = upMemb;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="UP_TIME")
	public Date getUpTime() {
		return this.upTime;
	}

	public void setUpTime(Date upTime) {
		this.upTime = upTime;
	}


	@Column(name="UP_TRM")
	public String getUpTrm() {
		return this.upTrm;
	}

	public void setUpTrm(String upTrm) {
		this.upTrm = upTrm;
	}


	@Column(name="VALID_YN")
	public String getValidYn() {
		return this.validYn;
	}

	public void setValidYn(String validYn) {
		this.validYn = validYn;
	}

}