package nta.med.core.domain.adm;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the ADM0700 database table.
 * 
 */
@Entity
@NamedQuery(name="Adm0700.findAll", query="SELECT a FROM Adm0700 a")
public class Adm0700 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String crMemb;
	private Date crTime;
	private String crTrm;
	private String fileAtchYn;
	private String hospCode;
	private String msgContents;
	private String msgTitle;
	private String recvAllCnfmYn;
	private String sendAllCnfmYn;
	private Date sendDt;
	private double sendSeq;
	private String sendSpot;
	private String senderId;
	private String upMemb;
	private Date upTime;
	private String upTrm;
	private String validYn;

	public Adm0700() {
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


	@Column(name="MSG_CONTENTS")
	public String getMsgContents() {
		return this.msgContents;
	}

	public void setMsgContents(String msgContents) {
		this.msgContents = msgContents;
	}


	@Column(name="MSG_TITLE")
	public String getMsgTitle() {
		return this.msgTitle;
	}

	public void setMsgTitle(String msgTitle) {
		this.msgTitle = msgTitle;
	}


	@Column(name="RECV_ALL_CNFM_YN")
	public String getRecvAllCnfmYn() {
		return this.recvAllCnfmYn;
	}

	public void setRecvAllCnfmYn(String recvAllCnfmYn) {
		this.recvAllCnfmYn = recvAllCnfmYn;
	}


	@Column(name="SEND_ALL_CNFM_YN")
	public String getSendAllCnfmYn() {
		return this.sendAllCnfmYn;
	}

	public void setSendAllCnfmYn(String sendAllCnfmYn) {
		this.sendAllCnfmYn = sendAllCnfmYn;
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


	@Column(name="SEND_SPOT")
	public String getSendSpot() {
		return this.sendSpot;
	}

	public void setSendSpot(String sendSpot) {
		this.sendSpot = sendSpot;
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