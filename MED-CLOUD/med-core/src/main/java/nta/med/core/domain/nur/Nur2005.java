package nta.med.core.domain.nur;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the NUR2005 database table.
 * 
 */
@Entity
@NamedQuery(name="Nur2005.findAll", query="SELECT n FROM Nur2005 n")
public class Nur2005 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String bunho;
	private String comments;
	private double fkinp1001;
	private String hospCode;
	private Date jukyongDate;
	private String nurMdCode;
	private String nurSoCode;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Nur2005() {
	}


	public String getBunho() {
		return this.bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}


	public String getComments() {
		return this.comments;
	}

	public void setComments(String comments) {
		this.comments = comments;
	}


	public double getFkinp1001() {
		return this.fkinp1001;
	}

	public void setFkinp1001(double fkinp1001) {
		this.fkinp1001 = fkinp1001;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="JUKYONG_DATE")
	public Date getJukyongDate() {
		return this.jukyongDate;
	}

	public void setJukyongDate(Date jukyongDate) {
		this.jukyongDate = jukyongDate;
	}


	@Column(name="NUR_MD_CODE")
	public String getNurMdCode() {
		return this.nurMdCode;
	}

	public void setNurMdCode(String nurMdCode) {
		this.nurMdCode = nurMdCode;
	}


	@Column(name="NUR_SO_CODE")
	public String getNurSoCode() {
		return this.nurSoCode;
	}

	public void setNurSoCode(String nurSoCode) {
		this.nurSoCode = nurSoCode;
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