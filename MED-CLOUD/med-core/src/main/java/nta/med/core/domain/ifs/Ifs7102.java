package nta.med.core.domain.ifs;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.NamedQuery;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;


/**
 * The persistent class for the IFS7102 database table.
 * 
 */
@Entity
@NamedQuery(name="Ifs7102.findAll", query="SELECT i FROM Ifs7102 i")
@Table(name="IFS7102")
public class Ifs7102 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String endFlag;
	private double fkifs7101;
	private String hospCode;
	private String ordCmtCode;
	private String ordCmtCodeName;
	private String recGubun;
	private String remark;
	private double seq;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Ifs7102() {
	}


	@Column(name="END_FLAG")
	public String getEndFlag() {
		return this.endFlag;
	}

	public void setEndFlag(String endFlag) {
		this.endFlag = endFlag;
	}


	public double getFkifs7101() {
		return this.fkifs7101;
	}

	public void setFkifs7101(double fkifs7101) {
		this.fkifs7101 = fkifs7101;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="ORD_CMT_CODE")
	public String getOrdCmtCode() {
		return this.ordCmtCode;
	}

	public void setOrdCmtCode(String ordCmtCode) {
		this.ordCmtCode = ordCmtCode;
	}


	@Column(name="ORD_CMT_CODE_NAME")
	public String getOrdCmtCodeName() {
		return this.ordCmtCodeName;
	}

	public void setOrdCmtCodeName(String ordCmtCodeName) {
		this.ordCmtCodeName = ordCmtCodeName;
	}


	@Column(name="REC_GUBUN")
	public String getRecGubun() {
		return this.recGubun;
	}

	public void setRecGubun(String recGubun) {
		this.recGubun = recGubun;
	}


	public String getRemark() {
		return this.remark;
	}

	public void setRemark(String remark) {
		this.remark = remark;
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

}