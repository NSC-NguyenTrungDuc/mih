package nta.med.core.domain.bas;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the BAS0380 database table.
 * 
 */
@Entity
@NamedQuery(name="Bas0380.findAll", query="SELECT b FROM Bas0380 b")
public class Bas0380 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String breakGubun;
	private Date endDate;
	private double fromAge;
	private String fromGijun;
	private String gwa;
	private String hangmogCode;
	private String hospCode;
	private String inOutGubun;
	private String remark;
	private String sangCode;
	private String sgCode;
	private Date startDate;
	private Date sysDate;
	private String sysId;
	private double toAge;
	private String toGijun;
	private Date updDate;
	private String updId;

	public Bas0380() {
	}


	@Column(name="BREAK_GUBUN")
	public String getBreakGubun() {
		return this.breakGubun;
	}

	public void setBreakGubun(String breakGubun) {
		this.breakGubun = breakGubun;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="END_DATE")
	public Date getEndDate() {
		return this.endDate;
	}

	public void setEndDate(Date endDate) {
		this.endDate = endDate;
	}


	@Column(name="FROM_AGE")
	public double getFromAge() {
		return this.fromAge;
	}

	public void setFromAge(double fromAge) {
		this.fromAge = fromAge;
	}


	@Column(name="FROM_GIJUN")
	public String getFromGijun() {
		return this.fromGijun;
	}

	public void setFromGijun(String fromGijun) {
		this.fromGijun = fromGijun;
	}


	public String getGwa() {
		return this.gwa;
	}

	public void setGwa(String gwa) {
		this.gwa = gwa;
	}


	@Column(name="HANGMOG_CODE")
	public String getHangmogCode() {
		return this.hangmogCode;
	}

	public void setHangmogCode(String hangmogCode) {
		this.hangmogCode = hangmogCode;
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


	public String getRemark() {
		return this.remark;
	}

	public void setRemark(String remark) {
		this.remark = remark;
	}


	@Column(name="SANG_CODE")
	public String getSangCode() {
		return this.sangCode;
	}

	public void setSangCode(String sangCode) {
		this.sangCode = sangCode;
	}


	@Column(name="SG_CODE")
	public String getSgCode() {
		return this.sgCode;
	}

	public void setSgCode(String sgCode) {
		this.sgCode = sgCode;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="START_DATE")
	public Date getStartDate() {
		return this.startDate;
	}

	public void setStartDate(Date startDate) {
		this.startDate = startDate;
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


	@Column(name="TO_AGE")
	public double getToAge() {
		return this.toAge;
	}

	public void setToAge(double toAge) {
		this.toAge = toAge;
	}


	@Column(name="TO_GIJUN")
	public String getToGijun() {
		return this.toGijun;
	}

	public void setToGijun(String toGijun) {
		this.toGijun = toGijun;
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