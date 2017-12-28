package nta.med.core.domain.adm;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the ADM8001 database table.
 * 
 */
@Entity
@NamedQuery(name="Adm8001.findAll", query="SELECT a FROM Adm8001 a")
public class Adm8001 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private double freeSpace;
	private String hospCode;
	private Date logDate;
	private String logTime;
	private double maxStock;
	private double percent;
	private Date sysDate;
	private double tablespaceDatafile;
	private String tablespaceName;
	private Date updDate;
	private double used;
	private String userId;

	public Adm8001() {
	}


	@Column(name="FREE_SPACE")
	public double getFreeSpace() {
		return this.freeSpace;
	}

	public void setFreeSpace(double freeSpace) {
		this.freeSpace = freeSpace;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="LOG_DATE")
	public Date getLogDate() {
		return this.logDate;
	}

	public void setLogDate(Date logDate) {
		this.logDate = logDate;
	}


	@Column(name="LOG_TIME")
	public String getLogTime() {
		return this.logTime;
	}

	public void setLogTime(String logTime) {
		this.logTime = logTime;
	}


	@Column(name="MAX_STOCK")
	public double getMaxStock() {
		return this.maxStock;
	}

	public void setMaxStock(double maxStock) {
		this.maxStock = maxStock;
	}


	public double getPercent() {
		return this.percent;
	}

	public void setPercent(double percent) {
		this.percent = percent;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="SYS_DATE")
	public Date getSysDate() {
		return this.sysDate;
	}

	public void setSysDate(Date sysDate) {
		this.sysDate = sysDate;
	}


	@Column(name="TABLESPACE_DATAFILE")
	public double getTablespaceDatafile() {
		return this.tablespaceDatafile;
	}

	public void setTablespaceDatafile(double tablespaceDatafile) {
		this.tablespaceDatafile = tablespaceDatafile;
	}


	@Column(name="TABLESPACE_NAME")
	public String getTablespaceName() {
		return this.tablespaceName;
	}

	public void setTablespaceName(String tablespaceName) {
		this.tablespaceName = tablespaceName;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="UPD_DATE")
	public Date getUpdDate() {
		return this.updDate;
	}

	public void setUpdDate(Date updDate) {
		this.updDate = updDate;
	}


	public double getUsed() {
		return this.used;
	}

	public void setUsed(double used) {
		this.used = used;
	}


	@Column(name="USER_ID")
	public String getUserId() {
		return this.userId;
	}

	public void setUserId(String userId) {
		this.userId = userId;
	}

}