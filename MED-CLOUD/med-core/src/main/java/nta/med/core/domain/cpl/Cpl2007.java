package nta.med.core.domain.cpl;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the CPL2007 database table.
 * 
 */
@Entity
@NamedQuery(name="Cpl2007.findAll", query="SELECT c FROM Cpl2007 c")
public class Cpl2007 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String calHangmogCode;
	private String calResult;
	private String fromResult;
	private String hospCode;
	private String subHangmogCode;
	private Date sysDate;
	private String sysId;
	private String toResult;
	private Date updDate;
	private String updId;

	public Cpl2007() {
	}


	@Column(name="CAL_HANGMOG_CODE")
	public String getCalHangmogCode() {
		return this.calHangmogCode;
	}

	public void setCalHangmogCode(String calHangmogCode) {
		this.calHangmogCode = calHangmogCode;
	}


	@Column(name="CAL_RESULT")
	public String getCalResult() {
		return this.calResult;
	}

	public void setCalResult(String calResult) {
		this.calResult = calResult;
	}


	@Column(name="FROM_RESULT")
	public String getFromResult() {
		return this.fromResult;
	}

	public void setFromResult(String fromResult) {
		this.fromResult = fromResult;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="SUB_HANGMOG_CODE")
	public String getSubHangmogCode() {
		return this.subHangmogCode;
	}

	public void setSubHangmogCode(String subHangmogCode) {
		this.subHangmogCode = subHangmogCode;
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


	@Column(name="TO_RESULT")
	public String getToResult() {
		return this.toResult;
	}

	public void setToResult(String toResult) {
		this.toResult = toResult;
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