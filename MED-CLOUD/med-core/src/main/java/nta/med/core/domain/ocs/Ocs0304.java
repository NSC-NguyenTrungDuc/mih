package nta.med.core.domain.ocs;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;


/**
 * The persistent class for the OCS0304 database table.
 * 
 */
@Entity
@Table(name="OCS0304")
public class Ocs0304 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String hospCode;
	private String memb;
	private String membGubun;
	private String ment;
	private double seq;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;
	private String yaksokDirectCode;
	private String yaksokDirectName;

	public Ocs0304() {
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
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


	@Column(name="YAKSOK_DIRECT_CODE")
	public String getYaksokDirectCode() {
		return this.yaksokDirectCode;
	}

	public void setYaksokDirectCode(String yaksokDirectCode) {
		this.yaksokDirectCode = yaksokDirectCode;
	}


	@Column(name="YAKSOK_DIRECT_NAME")
	public String getYaksokDirectName() {
		return this.yaksokDirectName;
	}

	public void setYaksokDirectName(String yaksokDirectName) {
		this.yaksokDirectName = yaksokDirectName;
	}

}