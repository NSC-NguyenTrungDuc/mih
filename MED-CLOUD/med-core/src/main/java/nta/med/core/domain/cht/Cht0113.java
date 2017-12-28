package nta.med.core.domain.cht;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the CHT0113 database table.
 * 
 */
@Entity
@NamedQuery(name="Cht0113.findAll", query="SELECT c FROM Cht0113 c")
public class Cht0113 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String deleteYn;
	private String disabilityCode;
	private String disabilityKanaName;
	private String disabilityName;
	private String disabilityNameInx;
	private Date endDate;
	private String freeInput;
	private String hospCode;
	private double pkcht0113;
	private double sortKey;
	private Date startDate;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Cht0113() {
	}


	@Column(name="DELETE_YN")
	public String getDeleteYn() {
		return this.deleteYn;
	}

	public void setDeleteYn(String deleteYn) {
		this.deleteYn = deleteYn;
	}


	@Column(name="DISABILITY_CODE")
	public String getDisabilityCode() {
		return this.disabilityCode;
	}

	public void setDisabilityCode(String disabilityCode) {
		this.disabilityCode = disabilityCode;
	}


	@Column(name="DISABILITY_KANA_NAME")
	public String getDisabilityKanaName() {
		return this.disabilityKanaName;
	}

	public void setDisabilityKanaName(String disabilityKanaName) {
		this.disabilityKanaName = disabilityKanaName;
	}


	@Column(name="DISABILITY_NAME")
	public String getDisabilityName() {
		return this.disabilityName;
	}

	public void setDisabilityName(String disabilityName) {
		this.disabilityName = disabilityName;
	}


	@Column(name="DISABILITY_NAME_INX")
	public String getDisabilityNameInx() {
		return this.disabilityNameInx;
	}

	public void setDisabilityNameInx(String disabilityNameInx) {
		this.disabilityNameInx = disabilityNameInx;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="END_DATE")
	public Date getEndDate() {
		return this.endDate;
	}

	public void setEndDate(Date endDate) {
		this.endDate = endDate;
	}


	@Column(name="FREE_INPUT")
	public String getFreeInput() {
		return this.freeInput;
	}

	public void setFreeInput(String freeInput) {
		this.freeInput = freeInput;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	public double getPkcht0113() {
		return this.pkcht0113;
	}

	public void setPkcht0113(double pkcht0113) {
		this.pkcht0113 = pkcht0113;
	}


	@Column(name="SORT_KEY")
	public double getSortKey() {
		return this.sortKey;
	}

	public void setSortKey(double sortKey) {
		this.sortKey = sortKey;
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