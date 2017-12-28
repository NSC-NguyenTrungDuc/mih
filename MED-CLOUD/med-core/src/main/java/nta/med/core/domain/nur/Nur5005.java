package nta.med.core.domain.nur;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the NUR5005 database table.
 * 
 */
@Entity
@NamedQuery(name="Nur5005.findAll", query="SELECT n FROM Nur5005 n")
public class Nur5005 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String bunmanComment;
	private String bunmanGubun;
	private String drugCode;
	private double fknur5001;
	private String hospCode;
	private String inductionYn;
	private double serialno;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Nur5005() {
	}


	@Column(name="BUNMAN_COMMENT")
	public String getBunmanComment() {
		return this.bunmanComment;
	}

	public void setBunmanComment(String bunmanComment) {
		this.bunmanComment = bunmanComment;
	}


	@Column(name="BUNMAN_GUBUN")
	public String getBunmanGubun() {
		return this.bunmanGubun;
	}

	public void setBunmanGubun(String bunmanGubun) {
		this.bunmanGubun = bunmanGubun;
	}


	@Column(name="DRUG_CODE")
	public String getDrugCode() {
		return this.drugCode;
	}

	public void setDrugCode(String drugCode) {
		this.drugCode = drugCode;
	}


	public double getFknur5001() {
		return this.fknur5001;
	}

	public void setFknur5001(double fknur5001) {
		this.fknur5001 = fknur5001;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="INDUCTION_YN")
	public String getInductionYn() {
		return this.inductionYn;
	}

	public void setInductionYn(String inductionYn) {
		this.inductionYn = inductionYn;
	}


	public double getSerialno() {
		return this.serialno;
	}

	public void setSerialno(double serialno) {
		this.serialno = serialno;
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