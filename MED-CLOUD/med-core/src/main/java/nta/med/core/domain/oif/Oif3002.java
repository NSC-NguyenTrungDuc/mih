package nta.med.core.domain.oif;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the OIF3002 database table.
 * 
 */
@Entity
@NamedQuery(name="Oif3002.findAll", query="SELECT o FROM Oif3002 o")
public class Oif3002 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String appCode;
	private String appMemo;
	private String appName;
	private double fkoif1001;
	private double fkoif3001;
	private String hospCode;
	private double pkSeq;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Oif3002() {
	}


	@Column(name="APP_CODE")
	public String getAppCode() {
		return this.appCode;
	}

	public void setAppCode(String appCode) {
		this.appCode = appCode;
	}


	@Column(name="APP_MEMO")
	public String getAppMemo() {
		return this.appMemo;
	}

	public void setAppMemo(String appMemo) {
		this.appMemo = appMemo;
	}


	@Column(name="APP_NAME")
	public String getAppName() {
		return this.appName;
	}

	public void setAppName(String appName) {
		this.appName = appName;
	}


	public double getFkoif1001() {
		return this.fkoif1001;
	}

	public void setFkoif1001(double fkoif1001) {
		this.fkoif1001 = fkoif1001;
	}


	public double getFkoif3001() {
		return this.fkoif3001;
	}

	public void setFkoif3001(double fkoif3001) {
		this.fkoif3001 = fkoif3001;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="PK_SEQ")
	public double getPkSeq() {
		return this.pkSeq;
	}

	public void setPkSeq(double pkSeq) {
		this.pkSeq = pkSeq;
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