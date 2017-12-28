package nta.med.core.domain.ocs;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.NamedQuery;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;


/**
 * The persistent class for the OCS0142 database table.
 * 
 */
@Entity
@NamedQuery(name="Ocs0142.findAll", query="SELECT o FROM Ocs0142 o")
public class Ocs0142 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String defaultYn;
	private String hospCode;
	private String inputTab;
	private String mainYn;
	private String orderGubun;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Ocs0142() {
	}


	@Column(name="DEFAULT_YN")
	public String getDefaultYn() {
		return this.defaultYn;
	}

	public void setDefaultYn(String defaultYn) {
		this.defaultYn = defaultYn;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="INPUT_TAB")
	public String getInputTab() {
		return this.inputTab;
	}

	public void setInputTab(String inputTab) {
		this.inputTab = inputTab;
	}


	@Column(name="MAIN_YN")
	public String getMainYn() {
		return this.mainYn;
	}

	public void setMainYn(String mainYn) {
		this.mainYn = mainYn;
	}


	@Column(name="ORDER_GUBUN")
	public String getOrderGubun() {
		return this.orderGubun;
	}

	public void setOrderGubun(String orderGubun) {
		this.orderGubun = orderGubun;
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