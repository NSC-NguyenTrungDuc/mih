package nta.med.core.domain.ifs;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the IFS8053 database table.
 * 
 */
@Entity
@NamedQuery(name="Ifs8053.findAll", query="SELECT i FROM Ifs8053 i")
public class Ifs8053 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private double fkOcs;
	private double fkOcsIrai;
	private String hospCode;
	private String inOutGubun;
	private double jissekiId;
	private String kaikeiOcsFlag;
	private String kaikeiRehaFlag;
	private String remark;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Ifs8053() {
	}


	@Column(name="FK_OCS")
	public double getFkOcs() {
		return this.fkOcs;
	}

	public void setFkOcs(double fkOcs) {
		this.fkOcs = fkOcs;
	}


	@Column(name="FK_OCS_IRAI")
	public double getFkOcsIrai() {
		return this.fkOcsIrai;
	}

	public void setFkOcsIrai(double fkOcsIrai) {
		this.fkOcsIrai = fkOcsIrai;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="IN_OUT_GUBUN")
	public String getInOutGubun() {
		return this.inOutGubun;
	}

	public void setInOutGubun(String inOutGubun) {
		this.inOutGubun = inOutGubun;
	}


	@Column(name="JISSEKI_ID")
	public double getJissekiId() {
		return this.jissekiId;
	}

	public void setJissekiId(double jissekiId) {
		this.jissekiId = jissekiId;
	}


	@Column(name="KAIKEI_OCS_FLAG")
	public String getKaikeiOcsFlag() {
		return this.kaikeiOcsFlag;
	}

	public void setKaikeiOcsFlag(String kaikeiOcsFlag) {
		this.kaikeiOcsFlag = kaikeiOcsFlag;
	}


	@Column(name="KAIKEI_REHA_FLAG")
	public String getKaikeiRehaFlag() {
		return this.kaikeiRehaFlag;
	}

	public void setKaikeiRehaFlag(String kaikeiRehaFlag) {
		this.kaikeiRehaFlag = kaikeiRehaFlag;
	}


	public String getRemark() {
		return this.remark;
	}

	public void setRemark(String remark) {
		this.remark = remark;
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