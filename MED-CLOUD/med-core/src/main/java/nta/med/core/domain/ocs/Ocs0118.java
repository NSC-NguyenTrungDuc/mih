package nta.med.core.domain.ocs;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.NamedQuery;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;


/**
 * The persistent class for the OCS0118 database table.
 * 
 */
@Entity
@Table(name= "OCS0118")
public class Ocs0118 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String convClass;
	private String convGubun;
	private String convHangmog;
	private Date endDate;
	private String fullConvHangmog;
	private String fullHangmogCode;
	private String hangmogCode;
	private String hospCode;
	private String remark;
	private Date startDate;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Ocs0118() {
	}


	@Column(name="CONV_CLASS")
	public String getConvClass() {
		return this.convClass;
	}

	public void setConvClass(String convClass) {
		this.convClass = convClass;
	}


	@Column(name="CONV_GUBUN")
	public String getConvGubun() {
		return this.convGubun;
	}

	public void setConvGubun(String convGubun) {
		this.convGubun = convGubun;
	}


	@Column(name="CONV_HANGMOG")
	public String getConvHangmog() {
		return this.convHangmog;
	}

	public void setConvHangmog(String convHangmog) {
		this.convHangmog = convHangmog;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="END_DATE")
	public Date getEndDate() {
		return this.endDate;
	}

	public void setEndDate(Date endDate) {
		this.endDate = endDate;
	}


	@Column(name="FULL_CONV_HANGMOG")
	public String getFullConvHangmog() {
		return this.fullConvHangmog;
	}

	public void setFullConvHangmog(String fullConvHangmog) {
		this.fullConvHangmog = fullConvHangmog;
	}


	@Column(name="FULL_HANGMOG_CODE")
	public String getFullHangmogCode() {
		return this.fullHangmogCode;
	}

	public void setFullHangmogCode(String fullHangmogCode) {
		this.fullHangmogCode = fullHangmogCode;
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


	public String getRemark() {
		return this.remark;
	}

	public void setRemark(String remark) {
		this.remark = remark;
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