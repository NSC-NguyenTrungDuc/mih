package nta.med.core.domain.nur;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the NUR0302 database table.
 * 
 */
@Entity
@NamedQuery(name="Nur0302.findAll", query="SELECT n FROM Nur0302 n")
public class Nur0302 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String allimFileGubun;
	private Date fileCrTime;
	private String fileName;
	private String filePath;
	private String gwaCode;
	private String hospCode;
	private String msgTitle;
	private double orderSeq;
	private double seq;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;
	private String useYn;

	public Nur0302() {
	}


	@Column(name="ALLIM_FILE_GUBUN")
	public String getAllimFileGubun() {
		return this.allimFileGubun;
	}

	public void setAllimFileGubun(String allimFileGubun) {
		this.allimFileGubun = allimFileGubun;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="FILE_CR_TIME")
	public Date getFileCrTime() {
		return this.fileCrTime;
	}

	public void setFileCrTime(Date fileCrTime) {
		this.fileCrTime = fileCrTime;
	}


	@Column(name="FILE_NAME")
	public String getFileName() {
		return this.fileName;
	}

	public void setFileName(String fileName) {
		this.fileName = fileName;
	}


	@Column(name="FILE_PATH")
	public String getFilePath() {
		return this.filePath;
	}

	public void setFilePath(String filePath) {
		this.filePath = filePath;
	}


	@Column(name="GWA_CODE")
	public String getGwaCode() {
		return this.gwaCode;
	}

	public void setGwaCode(String gwaCode) {
		this.gwaCode = gwaCode;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="MSG_TITLE")
	public String getMsgTitle() {
		return this.msgTitle;
	}

	public void setMsgTitle(String msgTitle) {
		this.msgTitle = msgTitle;
	}


	@Column(name="ORDER_SEQ")
	public double getOrderSeq() {
		return this.orderSeq;
	}

	public void setOrderSeq(double orderSeq) {
		this.orderSeq = orderSeq;
	}


	public double getSeq() {
		return this.seq;
	}

	public void setSeq(double seq) {
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


	@Column(name="USE_YN")
	public String getUseYn() {
		return this.useYn;
	}

	public void setUseYn(String useYn) {
		this.useYn = useYn;
	}

}