package nta.med.core.domain.ocs;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.NamedQuery;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;


/**
 * The persistent class for the OCS0141 database table.
 * 
 */
@Entity
@NamedQuery(name="Ocs0141.findAll", query="SELECT o FROM Ocs0141 o")
public class Ocs0141 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String colName;
	private String inputTab;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;
	private String visibleYn;

	public Ocs0141() {
	}


	@Column(name="COL_NAME")
	public String getColName() {
		return this.colName;
	}

	public void setColName(String colName) {
		this.colName = colName;
	}


	@Column(name="INPUT_TAB")
	public String getInputTab() {
		return this.inputTab;
	}

	public void setInputTab(String inputTab) {
		this.inputTab = inputTab;
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


	@Column(name="VISIBLE_YN")
	public String getVisibleYn() {
		return this.visibleYn;
	}

	public void setVisibleYn(String visibleYn) {
		this.visibleYn = visibleYn;
	}

}