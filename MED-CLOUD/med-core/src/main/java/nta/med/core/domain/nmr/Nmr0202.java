package nta.med.core.domain.nmr;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the NMR0202 database table.
 * 
 */
@Entity
@NamedQuery(name="Nmr0202.findAll", query="SELECT n FROM Nmr0202 n")
public class Nmr0202 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String actYn;
	private String dcYn;
	private double fkocs;
	private String hospCode;
	private String inOutGubun;
	private Date jubsuDate;
	private String jubsuTime;
	private double orderFkocs1003;
	private double orderFkocs2003;
	private double pknmr0201;
	private double pknmr0202;
	private String stopYn;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;
	private String xrayCode;
	private String xrayDCode;
	private Date xrayDate;
	private Date xrayReserDate;
	private String xrayReserTime;
	private String xrayTime;
	private String xrayUser;

	public Nmr0202() {
	}


	@Column(name="ACT_YN")
	public String getActYn() {
		return this.actYn;
	}

	public void setActYn(String actYn) {
		this.actYn = actYn;
	}


	@Column(name="DC_YN")
	public String getDcYn() {
		return this.dcYn;
	}

	public void setDcYn(String dcYn) {
		this.dcYn = dcYn;
	}


	public double getFkocs() {
		return this.fkocs;
	}

	public void setFkocs(double fkocs) {
		this.fkocs = fkocs;
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
	@Column(name="JUBSU_DATE")
	public Date getJubsuDate() {
		return this.jubsuDate;
	}

	public void setJubsuDate(Date jubsuDate) {
		this.jubsuDate = jubsuDate;
	}


	@Column(name="JUBSU_TIME")
	public String getJubsuTime() {
		return this.jubsuTime;
	}

	public void setJubsuTime(String jubsuTime) {
		this.jubsuTime = jubsuTime;
	}


	@Column(name="ORDER_FKOCS1003")
	public double getOrderFkocs1003() {
		return this.orderFkocs1003;
	}

	public void setOrderFkocs1003(double orderFkocs1003) {
		this.orderFkocs1003 = orderFkocs1003;
	}


	@Column(name="ORDER_FKOCS2003")
	public double getOrderFkocs2003() {
		return this.orderFkocs2003;
	}

	public void setOrderFkocs2003(double orderFkocs2003) {
		this.orderFkocs2003 = orderFkocs2003;
	}


	public double getPknmr0201() {
		return this.pknmr0201;
	}

	public void setPknmr0201(double pknmr0201) {
		this.pknmr0201 = pknmr0201;
	}


	public double getPknmr0202() {
		return this.pknmr0202;
	}

	public void setPknmr0202(double pknmr0202) {
		this.pknmr0202 = pknmr0202;
	}


	@Column(name="STOP_YN")
	public String getStopYn() {
		return this.stopYn;
	}

	public void setStopYn(String stopYn) {
		this.stopYn = stopYn;
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


	@Column(name="XRAY_CODE")
	public String getXrayCode() {
		return this.xrayCode;
	}

	public void setXrayCode(String xrayCode) {
		this.xrayCode = xrayCode;
	}


	@Column(name="XRAY_D_CODE")
	public String getXrayDCode() {
		return this.xrayDCode;
	}

	public void setXrayDCode(String xrayDCode) {
		this.xrayDCode = xrayDCode;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="XRAY_DATE")
	public Date getXrayDate() {
		return this.xrayDate;
	}

	public void setXrayDate(Date xrayDate) {
		this.xrayDate = xrayDate;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="XRAY_RESER_DATE")
	public Date getXrayReserDate() {
		return this.xrayReserDate;
	}

	public void setXrayReserDate(Date xrayReserDate) {
		this.xrayReserDate = xrayReserDate;
	}


	@Column(name="XRAY_RESER_TIME")
	public String getXrayReserTime() {
		return this.xrayReserTime;
	}

	public void setXrayReserTime(String xrayReserTime) {
		this.xrayReserTime = xrayReserTime;
	}


	@Column(name="XRAY_TIME")
	public String getXrayTime() {
		return this.xrayTime;
	}

	public void setXrayTime(String xrayTime) {
		this.xrayTime = xrayTime;
	}


	@Column(name="XRAY_USER")
	public String getXrayUser() {
		return this.xrayUser;
	}

	public void setXrayUser(String xrayUser) {
		this.xrayUser = xrayUser;
	}

}