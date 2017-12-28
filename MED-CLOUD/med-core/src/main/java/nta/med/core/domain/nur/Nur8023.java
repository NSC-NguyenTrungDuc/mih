package nta.med.core.domain.nur;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the NUR8023 database table.
 * 
 */
@Entity
@NamedQuery(name="Nur8023.findAll", query="SELECT n FROM Nur8023 n")
public class Nur8023 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String firstCode;
	private String grCode;
	private String hospCode;
	private String isSumSmall;
	private String smCode;
	private String smName;
	private double smPoint;
	private double sortKey;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Nur8023() {
	}


	@Column(name="FIRST_CODE")
	public String getFirstCode() {
		return this.firstCode;
	}

	public void setFirstCode(String firstCode) {
		this.firstCode = firstCode;
	}


	@Column(name="GR_CODE")
	public String getGrCode() {
		return this.grCode;
	}

	public void setGrCode(String grCode) {
		this.grCode = grCode;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="IS_SUM_SMALL")
	public String getIsSumSmall() {
		return this.isSumSmall;
	}

	public void setIsSumSmall(String isSumSmall) {
		this.isSumSmall = isSumSmall;
	}


	@Column(name="SM_CODE")
	public String getSmCode() {
		return this.smCode;
	}

	public void setSmCode(String smCode) {
		this.smCode = smCode;
	}


	@Column(name="SM_NAME")
	public String getSmName() {
		return this.smName;
	}

	public void setSmName(String smName) {
		this.smName = smName;
	}


	@Column(name="SM_POINT")
	public double getSmPoint() {
		return this.smPoint;
	}

	public void setSmPoint(double smPoint) {
		this.smPoint = smPoint;
	}


	@Column(name="SORT_KEY")
	public double getSortKey() {
		return this.sortKey;
	}

	public void setSortKey(double sortKey) {
		this.sortKey = sortKey;
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