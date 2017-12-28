package nta.med.core.domain.ifs;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the IFS3021 database table.
 * 
 */
@Entity
@NamedQuery(name="Ifs3021.findAll", query="SELECT i FROM Ifs3021 i")
public class Ifs3021 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String bunho;
	private String dataGubun;
	private String endDate;
	private String endTimeGubun;
	private double fkinp1001;
	private String hospCode;
	private Date ifDate;
	private String ifErr;
	private String ifFlag;
	private String ifHospCode;
	private String ifTime;
	private double pkifs3021;
	private String procDate;
	private String procGubun;
	private String procTime;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;
	private String yyyymm;

	public Ifs3021() {
	}


	public String getBunho() {
		return this.bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}


	@Column(name="DATA_GUBUN")
	public String getDataGubun() {
		return this.dataGubun;
	}

	public void setDataGubun(String dataGubun) {
		this.dataGubun = dataGubun;
	}


	@Column(name="END_DATE")
	public String getEndDate() {
		return this.endDate;
	}

	public void setEndDate(String endDate) {
		this.endDate = endDate;
	}


	@Column(name="END_TIME_GUBUN")
	public String getEndTimeGubun() {
		return this.endTimeGubun;
	}

	public void setEndTimeGubun(String endTimeGubun) {
		this.endTimeGubun = endTimeGubun;
	}


	public double getFkinp1001() {
		return this.fkinp1001;
	}

	public void setFkinp1001(double fkinp1001) {
		this.fkinp1001 = fkinp1001;
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


	public double getPkifs3021() {
		return this.pkifs3021;
	}

	public void setPkifs3021(double pkifs3021) {
		this.pkifs3021 = pkifs3021;
	}


	@Column(name="PROC_DATE")
	public String getProcDate() {
		return this.procDate;
	}

	public void setProcDate(String procDate) {
		this.procDate = procDate;
	}


	@Column(name="PROC_GUBUN")
	public String getProcGubun() {
		return this.procGubun;
	}

	public void setProcGubun(String procGubun) {
		this.procGubun = procGubun;
	}


	@Column(name="PROC_TIME")
	public String getProcTime() {
		return this.procTime;
	}

	public void setProcTime(String procTime) {
		this.procTime = procTime;
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


	public String getYyyymm() {
		return this.yyyymm;
	}

	public void setYyyymm(String yyyymm) {
		this.yyyymm = yyyymm;
	}

}