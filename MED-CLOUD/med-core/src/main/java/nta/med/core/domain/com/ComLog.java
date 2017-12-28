package nta.med.core.domain.com;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the COM_LOG database table.
 * 
 */
@Entity
@Table(name="COM_LOG")
@NamedQuery(name="ComLog.findAll", query="SELECT c FROM ComLog c")
public class ComLog extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String hospCode;
	private String logLevel;
	private String logObj;
	private String logText;
	private String logWriter;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public ComLog() {
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="LOG_LEVEL")
	public String getLogLevel() {
		return this.logLevel;
	}

	public void setLogLevel(String logLevel) {
		this.logLevel = logLevel;
	}


	@Column(name="LOG_OBJ")
	public String getLogObj() {
		return this.logObj;
	}

	public void setLogObj(String logObj) {
		this.logObj = logObj;
	}


	@Column(name="LOG_TEXT")
	public String getLogText() {
		return this.logText;
	}

	public void setLogText(String logText) {
		this.logText = logText;
	}


	@Column(name="LOG_WRITER")
	public String getLogWriter() {
		return this.logWriter;
	}

	public void setLogWriter(String logWriter) {
		this.logWriter = logWriter;
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