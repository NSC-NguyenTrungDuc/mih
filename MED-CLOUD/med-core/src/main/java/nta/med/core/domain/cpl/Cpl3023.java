package nta.med.core.domain.cpl;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the CPL3023 database table.
 * 
 */
@Entity
@NamedQuery(name="Cpl3023.findAll", query="SELECT c FROM Cpl3023 c")
public class Cpl3023 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String bogoGubunText;
	private String bogoGubunText1;
	private String comments;
	private Date confirmDate;
	private String confirmYn;
	private String gumsaja;
	private String hospCode;
	private String jaeryoCode;
	private Date jubsuDate;
	private String kyunCode;
	private String kyunText;
	private String labNo;
	private String resultCode;
	private Date resultDate;
	private String resultGb;
	private String resultGubun;
	private String resultText;
	private String resultTime;
	private double serial;
	private String srlCode;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Cpl3023() {
	}


	@Column(name="BOGO_GUBUN_TEXT")
	public String getBogoGubunText() {
		return this.bogoGubunText;
	}

	public void setBogoGubunText(String bogoGubunText) {
		this.bogoGubunText = bogoGubunText;
	}


	@Column(name="BOGO_GUBUN_TEXT1")
	public String getBogoGubunText1() {
		return this.bogoGubunText1;
	}

	public void setBogoGubunText1(String bogoGubunText1) {
		this.bogoGubunText1 = bogoGubunText1;
	}


	public String getComments() {
		return this.comments;
	}

	public void setComments(String comments) {
		this.comments = comments;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="CONFIRM_DATE")
	public Date getConfirmDate() {
		return this.confirmDate;
	}

	public void setConfirmDate(Date confirmDate) {
		this.confirmDate = confirmDate;
	}


	@Column(name="CONFIRM_YN")
	public String getConfirmYn() {
		return this.confirmYn;
	}

	public void setConfirmYn(String confirmYn) {
		this.confirmYn = confirmYn;
	}


	public String getGumsaja() {
		return this.gumsaja;
	}

	public void setGumsaja(String gumsaja) {
		this.gumsaja = gumsaja;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="JAERYO_CODE")
	public String getJaeryoCode() {
		return this.jaeryoCode;
	}

	public void setJaeryoCode(String jaeryoCode) {
		this.jaeryoCode = jaeryoCode;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="JUBSU_DATE")
	public Date getJubsuDate() {
		return this.jubsuDate;
	}

	public void setJubsuDate(Date jubsuDate) {
		this.jubsuDate = jubsuDate;
	}


	@Column(name="KYUN_CODE")
	public String getKyunCode() {
		return this.kyunCode;
	}

	public void setKyunCode(String kyunCode) {
		this.kyunCode = kyunCode;
	}


	@Column(name="KYUN_TEXT")
	public String getKyunText() {
		return this.kyunText;
	}

	public void setKyunText(String kyunText) {
		this.kyunText = kyunText;
	}


	@Column(name="LAB_NO")
	public String getLabNo() {
		return this.labNo;
	}

	public void setLabNo(String labNo) {
		this.labNo = labNo;
	}


	@Column(name="RESULT_CODE")
	public String getResultCode() {
		return this.resultCode;
	}

	public void setResultCode(String resultCode) {
		this.resultCode = resultCode;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="RESULT_DATE")
	public Date getResultDate() {
		return this.resultDate;
	}

	public void setResultDate(Date resultDate) {
		this.resultDate = resultDate;
	}


	@Column(name="RESULT_GB")
	public String getResultGb() {
		return this.resultGb;
	}

	public void setResultGb(String resultGb) {
		this.resultGb = resultGb;
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


	@Column(name="RESULT_TIME")
	public String getResultTime() {
		return this.resultTime;
	}

	public void setResultTime(String resultTime) {
		this.resultTime = resultTime;
	}


	public double getSerial() {
		return this.serial;
	}

	public void setSerial(double serial) {
		this.serial = serial;
	}


	@Column(name="SRL_CODE")
	public String getSrlCode() {
		return this.srlCode;
	}

	public void setSrlCode(String srlCode) {
		this.srlCode = srlCode;
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