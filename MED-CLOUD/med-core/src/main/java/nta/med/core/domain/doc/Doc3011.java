package nta.med.core.domain.doc;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the DOC3011 database table.
 * 
 */
@Entity
@NamedQuery(name="Doc3011.findAll", query="SELECT d FROM Doc3011 d")
public class Doc3011 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private double fkdoc1001;
	private String hospCode;
	private Date jindanDate;
	private String sogyun;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Doc3011() {
	}


	public double getFkdoc1001() {
		return this.fkdoc1001;
	}

	public void setFkdoc1001(double fkdoc1001) {
		this.fkdoc1001 = fkdoc1001;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="JINDAN_DATE")
	public Date getJindanDate() {
		return this.jindanDate;
	}

	public void setJindanDate(Date jindanDate) {
		this.jindanDate = jindanDate;
	}


	public String getSogyun() {
		return this.sogyun;
	}

	public void setSogyun(String sogyun) {
		this.sogyun = sogyun;
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