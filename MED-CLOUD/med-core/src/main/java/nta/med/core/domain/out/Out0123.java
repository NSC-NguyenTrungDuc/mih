package nta.med.core.domain.out;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the OUT0123 database table.
 * 
 */
@Entity
@Table(name="OUT0123")
public class Out0123 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private Date answerDate;
	private String answerDoctor;
	private String answerEndYn;
	private String answerGwa;
	private String answerTime;
	private String bunho;
	private String commentType;
	private String comments;
	private String consultDoctor;
	private String consultGwa;
	private Double fkinp1001;
	private Double fkout1001;
	private String hospCode;
	private String inOutGubun;
	private Date reqDate;
	private String reqDoctor;
	private String reqGwa;
	private String reqTime;
	private String reserGubun;
	private Double seq;
	private Date sysDate;
	private String sysId;
	private String upDownGubun;
	private Date updDate;
	private String updId;

	public Out0123() {
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="ANSWER_DATE")
	public Date getAnswerDate() {
		return this.answerDate;
	}

	public void setAnswerDate(Date answerDate) {
		this.answerDate = answerDate;
	}


	@Column(name="ANSWER_DOCTOR")
	public String getAnswerDoctor() {
		return this.answerDoctor;
	}

	public void setAnswerDoctor(String answerDoctor) {
		this.answerDoctor = answerDoctor;
	}


	@Column(name="ANSWER_END_YN")
	public String getAnswerEndYn() {
		return this.answerEndYn;
	}

	public void setAnswerEndYn(String answerEndYn) {
		this.answerEndYn = answerEndYn;
	}


	@Column(name="ANSWER_GWA")
	public String getAnswerGwa() {
		return this.answerGwa;
	}

	public void setAnswerGwa(String answerGwa) {
		this.answerGwa = answerGwa;
	}


	@Column(name="ANSWER_TIME")
	public String getAnswerTime() {
		return this.answerTime;
	}

	public void setAnswerTime(String answerTime) {
		this.answerTime = answerTime;
	}


	public String getBunho() {
		return this.bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}


	@Column(name="COMMENT_TYPE")
	public String getCommentType() {
		return this.commentType;
	}

	public void setCommentType(String commentType) {
		this.commentType = commentType;
	}


	public String getComments() {
		return this.comments;
	}

	public void setComments(String comments) {
		this.comments = comments;
	}


	@Column(name="CONSULT_DOCTOR")
	public String getConsultDoctor() {
		return this.consultDoctor;
	}

	public void setConsultDoctor(String consultDoctor) {
		this.consultDoctor = consultDoctor;
	}


	@Column(name="CONSULT_GWA")
	public String getConsultGwa() {
		return this.consultGwa;
	}

	public void setConsultGwa(String consultGwa) {
		this.consultGwa = consultGwa;
	}


	public Double getFkinp1001() {
		return this.fkinp1001;
	}

	public void setFkinp1001(Double fkinp1001) {
		this.fkinp1001 = fkinp1001;
	}


	public Double getFkout1001() {
		return this.fkout1001;
	}

	public void setFkout1001(Double fkout1001) {
		this.fkout1001 = fkout1001;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="IN_OUT_GUBUN")
	public String getInOutGubun() {
		return this.inOutGubun;
	}

	public void setInOutGubun(String inOutGubun) {
		this.inOutGubun = inOutGubun;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="REQ_DATE")
	public Date getReqDate() {
		return this.reqDate;
	}

	public void setReqDate(Date reqDate) {
		this.reqDate = reqDate;
	}


	@Column(name="REQ_DOCTOR")
	public String getReqDoctor() {
		return this.reqDoctor;
	}

	public void setReqDoctor(String reqDoctor) {
		this.reqDoctor = reqDoctor;
	}


	@Column(name="REQ_GWA")
	public String getReqGwa() {
		return this.reqGwa;
	}

	public void setReqGwa(String reqGwa) {
		this.reqGwa = reqGwa;
	}


	@Column(name="REQ_TIME")
	public String getReqTime() {
		return this.reqTime;
	}

	public void setReqTime(String reqTime) {
		this.reqTime = reqTime;
	}


	@Column(name="RESER_GUBUN")
	public String getReserGubun() {
		return this.reserGubun;
	}

	public void setReserGubun(String reserGubun) {
		this.reserGubun = reserGubun;
	}


	public Double getSeq() {
		return this.seq;
	}

	public void setSeq(Double seq) {
		this.seq = seq;
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


	@Column(name="UP_DOWN_GUBUN")
	public String getUpDownGubun() {
		return this.upDownGubun;
	}

	public void setUpDownGubun(String upDownGubun) {
		this.upDownGubun = upDownGubun;
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


	@Override
	public String toString() {
		return "Out0123 [answerDate=" + answerDate + ", answerDoctor="
				+ answerDoctor + ", answerEndYn=" + answerEndYn
				+ ", answerGwa=" + answerGwa + ", answerTime=" + answerTime
				+ ", bunho=" + bunho + ", commentType=" + commentType
				+ ", comments=" + comments + ", consultDoctor=" + consultDoctor
				+ ", consultGwa=" + consultGwa + ", fkinp1001=" + fkinp1001
				+ ", fkout1001=" + fkout1001 + ", hospCode=" + hospCode
				+ ", inOutGubun=" + inOutGubun + ", reqDate=" + reqDate
				+ ", reqDoctor=" + reqDoctor + ", reqGwa=" + reqGwa
				+ ", reqTime=" + reqTime + ", reserGubun=" + reserGubun
				+ ", seq=" + seq + ", sysDate=" + sysDate + ", sysId=" + sysId
				+ ", upDownGubun=" + upDownGubun + ", updDate=" + updDate
				+ ", updId=" + updId + "]";
	}

}