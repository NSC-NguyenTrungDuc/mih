package nta.med.core.domain.cpl;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.math.BigDecimal;
import java.util.Date;


/**
 * The persistent class for the CPL3024 database table.
 * 
 */
@Entity
@NamedQuery(name="Cpl3024.findAll", query="SELECT c FROM Cpl3024 c")
public class Cpl3024 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String antiCode;
	private String antiName;
	private String comments;
	private String hospCode;
	private String kyunCode;
	private String kyunResult;
	private String labNo;
	private String resultGubun;
	private String resultText;
	private BigDecimal seq;
	private double serial;
	private String status;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Cpl3024() {
	}


	@Column(name="ANTI_CODE")
	public String getAntiCode() {
		return this.antiCode;
	}

	public void setAntiCode(String antiCode) {
		this.antiCode = antiCode;
	}


	@Column(name="ANTI_NAME")
	public String getAntiName() {
		return this.antiName;
	}

	public void setAntiName(String antiName) {
		this.antiName = antiName;
	}


	public String getComments() {
		return this.comments;
	}

	public void setComments(String comments) {
		this.comments = comments;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="KYUN_CODE")
	public String getKyunCode() {
		return this.kyunCode;
	}

	public void setKyunCode(String kyunCode) {
		this.kyunCode = kyunCode;
	}


	@Column(name="KYUN_RESULT")
	public String getKyunResult() {
		return this.kyunResult;
	}

	public void setKyunResult(String kyunResult) {
		this.kyunResult = kyunResult;
	}


	@Column(name="LAB_NO")
	public String getLabNo() {
		return this.labNo;
	}

	public void setLabNo(String labNo) {
		this.labNo = labNo;
	}


	@Column(name="RESULT_GUBUN")
	public String getResultGubun() {
		return this.resultGubun;
	}

	public void setResultGubun(String resultGubun) {
		this.resultGubun = resultGubun;
	}


	@Column(name="RESULT_TEXT")
	public String getResultText() {
		return this.resultText;
	}

	public void setResultText(String resultText) {
		this.resultText = resultText;
	}


	public BigDecimal getSeq() {
		return this.seq;
	}

	public void setSeq(BigDecimal seq) {
		this.seq = seq;
	}


	public double getSerial() {
		return this.serial;
	}

	public void setSerial(double serial) {
		this.serial = serial;
	}


	public String getStatus() {
		return this.status;
	}

	public void setStatus(String status) {
		this.status = status;
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