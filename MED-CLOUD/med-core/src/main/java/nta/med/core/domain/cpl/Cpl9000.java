package nta.med.core.domain.cpl;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the CPL9000 database table.
 * 
 */
@Entity
@NamedQuery(name="Cpl9000.findAll", query="SELECT c FROM Cpl9000 c")
public class Cpl9000 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String bunho;
	private String centerCode;
	private Date createDate;
	private String createTime;
	private String createUser;
	private String gubun;
	private String hospCode;
	private String iraiKey;
	private Date partJubsuDate;
	private String partJubsuTime;
	private double pkcpl9000;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Cpl9000() {
	}


	public String getBunho() {
		return this.bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}


	@Column(name="CENTER_CODE")
	public String getCenterCode() {
		return this.centerCode;
	}

	public void setCenterCode(String centerCode) {
		this.centerCode = centerCode;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="CREATE_DATE")
	public Date getCreateDate() {
		return this.createDate;
	}

	public void setCreateDate(Date createDate) {
		this.createDate = createDate;
	}


	@Column(name="CREATE_TIME")
	public String getCreateTime() {
		return this.createTime;
	}

	public void setCreateTime(String createTime) {
		this.createTime = createTime;
	}


	@Column(name="CREATE_USER")
	public String getCreateUser() {
		return this.createUser;
	}

	public void setCreateUser(String createUser) {
		this.createUser = createUser;
	}


	public String getGubun() {
		return this.gubun;
	}

	public void setGubun(String gubun) {
		this.gubun = gubun;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="IRAI_KEY")
	public String getIraiKey() {
		return this.iraiKey;
	}

	public void setIraiKey(String iraiKey) {
		this.iraiKey = iraiKey;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="PART_JUBSU_DATE")
	public Date getPartJubsuDate() {
		return this.partJubsuDate;
	}

	public void setPartJubsuDate(Date partJubsuDate) {
		this.partJubsuDate = partJubsuDate;
	}


	@Column(name="PART_JUBSU_TIME")
	public String getPartJubsuTime() {
		return this.partJubsuTime;
	}

	public void setPartJubsuTime(String partJubsuTime) {
		this.partJubsuTime = partJubsuTime;
	}


	public double getPkcpl9000() {
		return this.pkcpl9000;
	}

	public void setPkcpl9000(double pkcpl9000) {
		this.pkcpl9000 = pkcpl9000;
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