package nta.med.core.domain.ocs;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;


/**
 * The persistent class for the OCS0300 database table.
 * 
 */
@Entity
@Table(name="OCS0300")
public class Ocs0300 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String hospCode;
	private String inputTab;
	private String memb;
	private String membGubun;
	private Double pkSeq;
	private Double seq;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;
	private String yaksokGubun;
	private String yaksokGubunName;

	public Ocs0300() {
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="INPUT_TAB")
	public String getInputTab() {
		return this.inputTab;
	}

	public void setInputTab(String inputTab) {
		this.inputTab = inputTab;
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


	public Double getSeq() {
		return this.seq;
	}

	public void setSeq(Double seq) {
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


	@Column(name="YAKSOK_GUBUN")
	public String getYaksokGubun() {
		return this.yaksokGubun;
	}

	public void setYaksokGubun(String yaksokGubun) {
		this.yaksokGubun = yaksokGubun;
	}


	@Column(name="YAKSOK_GUBUN_NAME")
	public String getYaksokGubunName() {
		return this.yaksokGubunName;
	}

	public void setYaksokGubunName(String yaksokGubunName) {
		this.yaksokGubunName = yaksokGubunName;
	}

}