package nta.med.core.domain.adm;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the ADM0730 database table.
 * 
 */
@Entity
@NamedQuery(name="Adm0730.findAll", query="SELECT a FROM Adm0730 a")
public class Adm0730 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String crMemb;
	private Date crTime;
	private String crTrm;
	private String hospCode;
	private String msgContents;
	private String msgTitle;
	private double seq;
	private String userId;

	public Adm0730() {
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