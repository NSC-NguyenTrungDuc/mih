package nta.med.core.domain.ifs;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the IFS5001 database table.
 * 
 */
@Entity
@NamedQuery(name="Ifs5001.findAll", query="SELECT i FROM Ifs5001 i")
public class Ifs5001 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String hospCode;
	private Date ifDate;
	private String ifErr;
	private String ifFlag;
	private String ifHospCode;
	private String ifTime;
	private String orderGroupNo;
	private String orderNo;
	private String orderNoSub;
	private double pkifs5001;
	private String procGubun;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Ifs5001() {
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="IF_DATE")
	public Date getIfDate() {
		return this.ifDate;
	}

	public void setIfDate(Date ifDate) {
		this.ifDate = ifDate;
	}


	@Column(name="IF_ERR")
	public String getIfErr() {
		return this.ifErr;
	}

	public void setIfErr(String ifErr) {
		this.ifErr = ifErr;
	}


	@Column(name="IF_FLAG")
	public String getIfFlag() {
		return this.ifFlag;
	}

	public void setIfFlag(String ifFlag) {
		this.ifFlag = ifFlag;
	}


	@Column(name="IF_HOSP_CODE")
	public String getIfHospCode() {
		return this.ifHospCode;
	}

	public void setIfHospCode(String ifHospCode) {
		this.ifHospCode = ifHospCode;
	}


	@Column(name="IF_TIME")
	public String getIfTime() {
		return this.ifTime;
	}

	public void setIfTime(String ifTime) {
		this.ifTime = ifTime;
	}


	@Column(name="ORDER_GROUP_NO")
	public String getOrderGroupNo() {
		return this.orderGroupNo;
	}

	public void setOrderGroupNo(String orderGroupNo) {
		this.orderGroupNo = orderGroupNo;
	}


	@Column(name="ORDER_NO")
	public String getOrderNo() {
		return this.orderNo;
	}

	public void setOrderNo(String orderNo) {
		this.orderNo = orderNo;
	}


	@Column(name="ORDER_NO_SUB")
	public String getOrderNoSub() {
		return this.orderNoSub;
	}

	public void setOrderNoSub(String orderNoSub) {
		this.orderNoSub = orderNoSub;
	}


	public double getPkifs5001() {
		return this.pkifs5001;
	}

	public void setPkifs5001(double pkifs5001) {
		this.pkifs5001 = pkifs5001;
	}


	@Column(name="PROC_GUBUN")
	public String getProcGubun() {
		return this.procGubun;
	}

	public void setProcGubun(String procGubun) {
		this.procGubun = procGubun;
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