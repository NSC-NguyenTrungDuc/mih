package nta.med.core.domain.ifs;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the IFS8152 database table.
 * 
 */
@Entity
@NamedQuery(name="Ifs8152.findAll", query="SELECT i FROM Ifs8152 i")
public class Ifs8152 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private double fkIfs8003;
	private double fkOcs;
	private double fkOcsIrai;
	private double fkPhy8003;
	private String hospCode;
	private String inOutGubun;
	private double jissekiId;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Ifs8152() {
	}


	@Column(name="FK_IFS8003")
	public double getFkIfs8003() {
		return this.fkIfs8003;
	}

	public void setFkIfs8003(double fkIfs8003) {
		this.fkIfs8003 = fkIfs8003;
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


	@Column(name="FK_PHY8003")
	public double getFkPhy8003() {
		return this.fkPhy8003;
	}

	public void setFkPhy8003(double fkPhy8003) {
		this.fkPhy8003 = fkPhy8003;
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