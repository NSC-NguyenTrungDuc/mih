package nta.med.core.domain.ocs;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the OCS6000 database table.
 * 
 */
@Entity
@NamedQuery(name="Ocs6000.findAll", query="SELECT o FROM Ocs6000 o")
public class Ocs6000 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String cpCode;
	private String cpName;
	private String cpRemark;
	private String hospCode;
	private String memb;
	private String membGubun;
	private String ordOccurGubun;
	private double seq;
	private String startConditionYn;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Ocs6000() {
	}


	@Column(name="CP_CODE")
	public String getCpCode() {
		return this.cpCode;
	}

	public void setCpCode(String cpCode) {
		this.cpCode = cpCode;
	}


	@Column(name="CP_NAME")
	public String getCpName() {
		return this.cpName;
	}

	public void setCpName(String cpName) {
		this.cpName = cpName;
	}


	@Column(name="CP_REMARK")
	public String getCpRemark() {
		return this.cpRemark;
	}

	public void setCpRemark(String cpRemark) {
		this.cpRemark = cpRemark;
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


	@Column(name="ORD_OCCUR_GUBUN")
	public String getOrdOccurGubun() {
		return this.ordOccurGubun;
	}

	public void setOrdOccurGubun(String ordOccurGubun) {
		this.ordOccurGubun = ordOccurGubun;
	}


	public double getSeq() {
		return this.seq;
	}

	public void setSeq(double seq) {
		this.seq = seq;
	}


	@Column(name="START_CONDITION_YN")
	public String getStartConditionYn() {
		return this.startConditionYn;
	}

	public void setStartConditionYn(String startConditionYn) {
		this.startConditionYn = startConditionYn;
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