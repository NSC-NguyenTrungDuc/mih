package nta.med.core.domain.ocs;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;


/**
 * The persistent class for the OCS0305 database table.
 * 
 */
@Entity
@Table(name="OCS0305")
public class Ocs0305 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String directCode;
	private String directCont1;
	private String directCont2;
	private String directGubun;
	private String directText;
	private String hospCode;
	private String memb;
	private String membGubun;
	private Double pkSeq;
	private Date   sysDate;
	private String sysId;
	private Date   updDate;
	private String updId;
	private String yaksokDirectCode;

	public Ocs0305() {
	}


	@Column(name="DIRECT_CODE")
	public String getDirectCode() {
		return this.directCode;
	}

	public void setDirectCode(String directCode) {
		this.directCode = directCode;
	}


	@Column(name="DIRECT_CONT1")
	public String getDirectCont1() {
		return this.directCont1;
	}

	public void setDirectCont1(String directCont1) {
		this.directCont1 = directCont1;
	}


	@Column(name="DIRECT_CONT2")
	public String getDirectCont2() {
		return this.directCont2;
	}

	public void setDirectCont2(String directCont2) {
		this.directCont2 = directCont2;
	}


	@Column(name="DIRECT_GUBUN")
	public String getDirectGubun() {
		return this.directGubun;
	}

	public void setDirectGubun(String directGubun) {
		this.directGubun = directGubun;
	}


	@Column(name="DIRECT_TEXT")
	public String getDirectText() {
		return this.directText;
	}

	public void setDirectText(String directText) {
		this.directText = directText;
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


	@Column(name="PK_SEQ")
	public Double getPkSeq() {
		return this.pkSeq;
	}

	public void setPkSeq(Double pkSeq) {
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


	@Column(name="YAKSOK_DIRECT_CODE")
	public String getYaksokDirectCode() {
		return this.yaksokDirectCode;
	}

	public void setYaksokDirectCode(String yaksokDirectCode) {
		this.yaksokDirectCode = yaksokDirectCode;
	}

}