package nta.med.core.domain.ifs;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the IFS8151 database table.
 * 
 */
@Entity
@NamedQuery(name="Ifs8151.findAll", query="SELECT i FROM Ifs8151 i")
public class Ifs8151 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private double fkOcsIrai;
	private double fkSch;
	private String hospCode;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;
	private double yoyakuId;

	public Ifs8151() {
	}


	@Column(name="FK_OCS_IRAI")
	public double getFkOcsIrai() {
		return this.fkOcsIrai;
	}

	public void setFkOcsIrai(double fkOcsIrai) {
		this.fkOcsIrai = fkOcsIrai;
	}


	@Column(name="FK_SCH")
	public double getFkSch() {
		return this.fkSch;
	}

	public void setFkSch(double fkSch) {
		this.fkSch = fkSch;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
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


	@Column(name="YOYAKU_ID")
	public double getYoyakuId() {
		return this.yoyakuId;
	}

	public void setYoyakuId(double yoyakuId) {
		this.yoyakuId = yoyakuId;
	}

}