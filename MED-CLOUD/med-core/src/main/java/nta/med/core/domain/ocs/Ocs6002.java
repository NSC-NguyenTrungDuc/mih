package nta.med.core.domain.ocs;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the OCS6002 database table.
 * 
 */
@Entity
@NamedQuery(name="Ocs6002.findAll", query="SELECT o FROM Ocs6002 o")
public class Ocs6002 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String conditionYn;
	private String cpCode;
	private String cpPathCode;
	private String hospCode;
	private double jaewonil;
	private String memb;
	private String membGubun;
	private String ordOccurGubun;
	private String pathRemark;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Ocs6002() {
	}


	@Column(name="CONDITION_YN")
	public String getConditionYn() {
		return this.conditionYn;
	}

	public void setConditionYn(String conditionYn) {
		this.conditionYn = conditionYn;
	}


	@Column(name="CP_CODE")
	public String getCpCode() {
		return this.cpCode;
	}

	public void setCpCode(String cpCode) {
		this.cpCode = cpCode;
	}


	@Column(name="CP_PATH_CODE")
	public String getCpPathCode() {
		return this.cpPathCode;
	}

	public void setCpPathCode(String cpPathCode) {
		this.cpPathCode = cpPathCode;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	public double getJaewonil() {
		return this.jaewonil;
	}

	public void setJaewonil(double jaewonil) {
		this.jaewonil = jaewonil;
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


	@Column(name="PATH_REMARK")
	public String getPathRemark() {
		return this.pathRemark;
	}

	public void setPathRemark(String pathRemark) {
		this.pathRemark = pathRemark;
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