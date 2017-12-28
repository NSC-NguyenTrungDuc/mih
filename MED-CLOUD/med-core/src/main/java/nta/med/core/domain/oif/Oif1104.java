package nta.med.core.domain.oif;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the OIF1104 database table.
 * 
 */
@Entity
@NamedQuery(name="Oif1104.findAll", query="SELECT o FROM Oif1104 o")
public class Oif1104 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String category1;
	private String category2;
	private String category3;
	private String category4;
	private Date enddate;
	private Date firstdate;
	private double fkoif1101;
	private String hospCode;
	private String outcome;
	private double pkSeq;
	private String rdCode;
	private String rdName;
	private Date startdate;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;
	private String uuid;

	public Oif1104() {
	}


	public String getCategory1() {
		return this.category1;
	}

	public void setCategory1(String category1) {
		this.category1 = category1;
	}


	public String getCategory2() {
		return this.category2;
	}

	public void setCategory2(String category2) {
		this.category2 = category2;
	}


	public String getCategory3() {
		return this.category3;
	}

	public void setCategory3(String category3) {
		this.category3 = category3;
	}


	public String getCategory4() {
		return this.category4;
	}

	public void setCategory4(String category4) {
		this.category4 = category4;
	}


	@Temporal(TemporalType.TIMESTAMP)
	public Date getEnddate() {
		return this.enddate;
	}

	public void setEnddate(Date enddate) {
		this.enddate = enddate;
	}


	@Temporal(TemporalType.TIMESTAMP)
	public Date getFirstdate() {
		return this.firstdate;
	}

	public void setFirstdate(Date firstdate) {
		this.firstdate = firstdate;
	}


	public double getFkoif1101() {
		return this.fkoif1101;
	}

	public void setFkoif1101(double fkoif1101) {
		this.fkoif1101 = fkoif1101;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	public String getOutcome() {
		return this.outcome;
	}

	public void setOutcome(String outcome) {
		this.outcome = outcome;
	}


	@Column(name="PK_SEQ")
	public double getPkSeq() {
		return this.pkSeq;
	}

	public void setPkSeq(double pkSeq) {
		this.pkSeq = pkSeq;
	}


	@Column(name="RD_CODE")
	public String getRdCode() {
		return this.rdCode;
	}

	public void setRdCode(String rdCode) {
		this.rdCode = rdCode;
	}


	@Column(name="RD_NAME")
	public String getRdName() {
		return this.rdName;
	}

	public void setRdName(String rdName) {
		this.rdName = rdName;
	}


	@Temporal(TemporalType.TIMESTAMP)
	public Date getStartdate() {
		return this.startdate;
	}

	public void setStartdate(Date startdate) {
		this.startdate = startdate;
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


	public String getUuid() {
		return this.uuid;
	}

	public void setUuid(String uuid) {
		this.uuid = uuid;
	}

}