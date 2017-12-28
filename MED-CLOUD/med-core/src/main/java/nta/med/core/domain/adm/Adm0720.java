package nta.med.core.domain.adm;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the ADM0720 database table.
 * 
 */
@Entity
@NamedQuery(name="Adm0720.findAll", query="SELECT a FROM Adm0720 a")
public class Adm0720 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String atchFileNm;
	private double atchFileSeq;
	private String atchUniFileNm;
	private String hospCode;
	private Date sendDt;
	private double sendSeq;
	private String senderId;

	public Adm0720() {
	}


	@Column(name="ATCH_FILE_NM")
	public String getAtchFileNm() {
		return this.atchFileNm;
	}

	public void setAtchFileNm(String atchFileNm) {
		this.atchFileNm = atchFileNm;
	}


	@Column(name="ATCH_FILE_SEQ")
	public double getAtchFileSeq() {
		return this.atchFileSeq;
	}

	public void setAtchFileSeq(double atchFileSeq) {
		this.atchFileSeq = atchFileSeq;
	}


	@Column(name="ATCH_UNI_FILE_NM")
	public String getAtchUniFileNm() {
		return this.atchUniFileNm;
	}

	public void setAtchUniFileNm(String atchUniFileNm) {
		this.atchUniFileNm = atchUniFileNm;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
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

}