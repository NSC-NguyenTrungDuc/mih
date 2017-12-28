package nta.med.core.domain.ocs;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.NamedQuery;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;


/**
 * The persistent class for the OCS0121 database table.
 * 
 */
@Entity
@NamedQuery(name="Ocs0121.findAll", query="SELECT o FROM Ocs0121 o")
public class Ocs0121 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String actHangmog;
	private String buseoCode;
	private double fromMonth;
	private String hangmogCode;
	private String hospCode;
	private String subSgYn;
	private double suryang;
	private Date sysDate;
	private String sysId;
	private double toMonth;
	private Date updDate;
	private String updId;

	public Ocs0121() {
	}


	@Column(name="ACT_HANGMOG")
	public String getActHangmog() {
		return this.actHangmog;
	}

	public void setActHangmog(String actHangmog) {
		this.actHangmog = actHangmog;
	}


	@Column(name="BUSEO_CODE")
	public String getBuseoCode() {
		return this.buseoCode;
	}

	public void setBuseoCode(String buseoCode) {
		this.buseoCode = buseoCode;
	}


	@Column(name="FROM_MONTH")
	public double getFromMonth() {
		return this.fromMonth;
	}

	public void setFromMonth(double fromMonth) {
		this.fromMonth = fromMonth;
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


	@Column(name="SUB_SG_YN")
	public String getSubSgYn() {
		return this.subSgYn;
	}

	public void setSubSgYn(String subSgYn) {
		this.subSgYn = subSgYn;
	}


	public double getSuryang() {
		return this.suryang;
	}

	public void setSuryang(double suryang) {
		this.suryang = suryang;
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
	public double getToMonth() {
		return this.toMonth;
	}

	public void setToMonth(double toMonth) {
		this.toMonth = toMonth;
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