package nta.med.core.domain.ifs;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the IFS7105 database table.
 * 
 */
@Entity
@NamedQuery(name="Ifs7105.findAll", query="SELECT i FROM Ifs7105 i")
@Table(name="IFS7105")
public class Ifs7105 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String drgRpCmtCode;
	private String drgRpCmtCodeName;
	private String endFlag;
	private double fkifs7101;
	private String hospCode;
	private String recGubun;
	private String remark;
	private double seq;
	private double seqRp;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Ifs7105() {
	}


	@Column(name="DRG_RP_CMT_CODE")
	public String getDrgRpCmtCode() {
		return this.drgRpCmtCode;
	}

	public void setDrgRpCmtCode(String drgRpCmtCode) {
		this.drgRpCmtCode = drgRpCmtCode;
	}


	@Column(name="DRG_RP_CMT_CODE_NAME")
	public String getDrgRpCmtCodeName() {
		return this.drgRpCmtCodeName;
	}

	public void setDrgRpCmtCodeName(String drgRpCmtCodeName) {
		this.drgRpCmtCodeName = drgRpCmtCodeName;
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


	@Column(name="SEQ_RP")
	public double getSeqRp() {
		return this.seqRp;
	}

	public void setSeqRp(double seqRp) {
		this.seqRp = seqRp;
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