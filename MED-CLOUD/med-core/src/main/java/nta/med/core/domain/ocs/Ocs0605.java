package nta.med.core.domain.ocs;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the OCS0605 database table.
 * 
 */
@Entity
@NamedQuery(name="Ocs0605.findAll", query="SELECT o FROM Ocs0605 o")
public class Ocs0605 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String cpCode;
	private String cpPathCode;
	private String hospCode;
	private double jaewonil;
	private String memb;
	private String membGubun;
	private String ment;
	private String printYn;
	private String specificComment;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Ocs0605() {
	}


	@Column(name="CP_CODE")
	public String getCpCode() {
		return this.cpCode;
	}

	public void setCpCode(String cpCode) {
		this.cpCode = cpCode;
	}


	@Column(name="CP_PATH_CODE")
	public String getCpPathCode() {
		return this.cpPathCode;
	}

	public void setCpPathCode(String cpPathCode) {
		this.cpPathCode = cpPathCode;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	public double getJaewonil() {
		return this.jaewonil;
	}

	public void setJaewonil(double jaewonil) {
		this.jaewonil = jaewonil;
	}


	public String getMemb() {
		return this.memb;
	}

	public void setMemb(String memb) {
		this.memb = memb;
	}


	@Column(name="MEMB_GUBUN")
	public String getMembGubun() {
		return this.membGubun;
	}

	public void setMembGubun(String membGubun) {
		this.membGubun = membGubun;
	}


	public String getMent() {
		return this.ment;
	}

	public void setMent(String ment) {
		this.ment = ment;
	}


	@Column(name="PRINT_YN")
	public String getPrintYn() {
		return this.printYn;
	}

	public void setPrintYn(String printYn) {
		this.printYn = printYn;
	}


	@Column(name="SPECIFIC_COMMENT")
	public String getSpecificComment() {
		return this.specificComment;
	}

	public void setSpecificComment(String specificComment) {
		this.specificComment = specificComment;
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