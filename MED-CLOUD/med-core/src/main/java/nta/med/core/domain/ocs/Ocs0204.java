package nta.med.core.domain.ocs;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.NamedQuery;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;


/**
 * The persistent class for the OCS0204 database table.
 * 
 */
@Entity
@NamedQuery(name="Ocs0204.findAll", query="SELECT o FROM Ocs0204 o")
@Table(name="OCS0204")
public class Ocs0204 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String hospCode;
	private String memb;
	private String membGubun;
	private String sangGubun;
	private String sangGubunName;
	private double seq;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;
	private String language;

	public Ocs0204() {
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


	@Column(name="SANG_GUBUN")
	public String getSangGubun() {
		return this.sangGubun;
	}

	public void setSangGubun(String sangGubun) {
		this.sangGubun = sangGubun;
	}


	@Column(name="SANG_GUBUN_NAME")
	public String getSangGubunName() {
		return this.sangGubunName;
	}

	public void setSangGubunName(String sangGubunName) {
		this.sangGubunName = sangGubunName;
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
	
	@Column(name="LANGUAGE")
	public String getLanguage() {
		return language;
	}

	public void setLanguage(String language) {
		this.language = language;
	}
}