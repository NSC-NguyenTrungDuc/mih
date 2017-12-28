package nta.med.core.domain.bas;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the BAS0203 database table.
 * 
 */
@Entity
@NamedQuery(name="Bas0203.findAll", query="SELECT b FROM Bas0203 b")
@Table(name="BAS0203")
public class Bas0203 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String bunCode;
	private Double fromMonth;
	private String fromTime;
	private String hospCode;
	private Date jyDate;
	private String sgCode;
	private String symyaGubun;
	private Date sysDate;
	private String sysId;
	private Double toMonth;
	private String toTime;
	private Date updDate;
	private String updId;
	private String yoilGubun;

	public Bas0203() {
	}


	@Column(name="BUN_CODE")
	public String getBunCode() {
		return this.bunCode;
	}

	public void setBunCode(String bunCode) {
		this.bunCode = bunCode;
	}


	@Column(name="FROM_MONTH")
	public Double getFromMonth() {
		return this.fromMonth;
	}

	public void setFromMonth(Double fromMonth) {
		this.fromMonth = fromMonth;
	}


	@Column(name="FROM_TIME")
	public String getFromTime() {
		return this.fromTime;
	}

	public void setFromTime(String fromTime) {
		this.fromTime = fromTime;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="JY_DATE")
	public Date getJyDate() {
		return this.jyDate;
	}

	public void setJyDate(Date jyDate) {
		this.jyDate = jyDate;
	}


	@Column(name="SG_CODE")
	public String getSgCode() {
		return this.sgCode;
	}

	public void setSgCode(String sgCode) {
		this.sgCode = sgCode;
	}


	@Column(name="SYMYA_GUBUN")
	public String getSymyaGubun() {
		return this.symyaGubun;
	}

	public void setSymyaGubun(String symyaGubun) {
		this.symyaGubun = symyaGubun;
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


	@Column(name="TO_MONTH")
	public Double getToMonth() {
		return this.toMonth;
	}

	public void setToMonth(Double toMonth) {
		this.toMonth = toMonth;
	}


	@Column(name="TO_TIME")
	public String getToTime() {
		return this.toTime;
	}

	public void setToTime(String toTime) {
		this.toTime = toTime;
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


	@Column(name="YOIL_GUBUN")
	public String getYoilGubun() {
		return this.yoilGubun;
	}

	public void setYoilGubun(String yoilGubun) {
		this.yoilGubun = yoilGubun;
	}

}