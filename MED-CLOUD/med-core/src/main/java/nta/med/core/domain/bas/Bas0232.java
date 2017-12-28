package nta.med.core.domain.bas;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the BAS0232 database table.
 * 
 */
@Entity
@NamedQuery(name="Bas0232.findAll", query="SELECT b FROM Bas0232 b")
public class Bas0232 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String bunCode;
	private String gubunSuga;
	private String hospCode;
	private String inOutGubun;
	private Date pointYmd;
	private String sgCode;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;
	private double valuePoint;

	public Bas0232() {
	}


	@Column(name="BUN_CODE")
	public String getBunCode() {
		return this.bunCode;
	}

	public void setBunCode(String bunCode) {
		this.bunCode = bunCode;
	}


	@Column(name="GUBUN_SUGA")
	public String getGubunSuga() {
		return this.gubunSuga;
	}

	public void setGubunSuga(String gubunSuga) {
		this.gubunSuga = gubunSuga;
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


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="POINT_YMD")
	public Date getPointYmd() {
		return this.pointYmd;
	}

	public void setPointYmd(Date pointYmd) {
		this.pointYmd = pointYmd;
	}


	@Column(name="SG_CODE")
	public String getSgCode() {
		return this.sgCode;
	}

	public void setSgCode(String sgCode) {
		this.sgCode = sgCode;
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


	@Column(name="VALUE_POINT")
	public double getValuePoint() {
		return this.valuePoint;
	}

	public void setValuePoint(double valuePoint) {
		this.valuePoint = valuePoint;
	}

}