package nta.med.core.domain.cpl;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;

import javax.persistence.*;

import java.util.Date;


/**
 * The persistent class for the CPLREQ1 database table.
 * 
 */
@Entity
@Table(name="CPLREQ1")
public class Cplreq1 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String bunho;
	private String curSendYn;
	private String hangmogCnt;
	private String jubsuDate;
	private String jubsuTime;
	private Date requestDate;
	private String requestId;
	private String requestKey;
	private String sendYn;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;
	private String urine;

	public Cplreq1() {
	}


	public String getBunho() {
		return this.bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}


	@Column(name="CUR_SEND_YN")
	public String getCurSendYn() {
		return this.curSendYn;
	}

	public void setCurSendYn(String curSendYn) {
		this.curSendYn = curSendYn;
	}


	@Column(name="HANGMOG_CNT")
	public String getHangmogCnt() {
		return this.hangmogCnt;
	}

	public void setHangmogCnt(String hangmogCnt) {
		this.hangmogCnt = hangmogCnt;
	}


	@Column(name="JUBSU_DATE")
	public String getJubsuDate() {
		return this.jubsuDate;
	}

	public void setJubsuDate(String jubsuDate) {
		this.jubsuDate = jubsuDate;
	}


	@Column(name="JUBSU_TIME")
	public String getJubsuTime() {
		return this.jubsuTime;
	}

	public void setJubsuTime(String jubsuTime) {
		this.jubsuTime = jubsuTime;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="REQUEST_DATE")
	public Date getRequestDate() {
		return this.requestDate;
	}

	public void setRequestDate(Date requestDate) {
		this.requestDate = requestDate;
	}


	@Column(name="REQUEST_ID")
	public String getRequestId() {
		return this.requestId;
	}

	public void setRequestId(String requestId) {
		this.requestId = requestId;
	}


	@Column(name="REQUEST_KEY")
	public String getRequestKey() {
		return this.requestKey;
	}

	public void setRequestKey(String requestKey) {
		this.requestKey = requestKey;
	}


	@Column(name="SEND_YN")
	public String getSendYn() {
		return this.sendYn;
	}

	public void setSendYn(String sendYn) {
		this.sendYn = sendYn;
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


	public String getUrine() {
		return this.urine;
	}

	public void setUrine(String urine) {
		this.urine = urine;
	}

}