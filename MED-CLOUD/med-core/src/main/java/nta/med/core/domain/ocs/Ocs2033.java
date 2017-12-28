package nta.med.core.domain.ocs;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the OCS2033 database table.
 * 
 */
@Entity
@NamedQuery(name="Ocs2033.findAll", query="SELECT o FROM Ocs2033 o")
public class Ocs2033 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String alterInputGubun;
	private String bunho;
	private double fkinp1001;
	private double fkocs2003;
	private String hospCode;
	private String originInputGubun;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Ocs2033() {
	}


	@Column(name="ALTER_INPUT_GUBUN")
	public String getAlterInputGubun() {
		return this.alterInputGubun;
	}

	public void setAlterInputGubun(String alterInputGubun) {
		this.alterInputGubun = alterInputGubun;
	}


	public String getBunho() {
		return this.bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}


	public double getFkinp1001() {
		return this.fkinp1001;
	}

	public void setFkinp1001(double fkinp1001) {
		this.fkinp1001 = fkinp1001;
	}


	public double getFkocs2003() {
		return this.fkocs2003;
	}

	public void setFkocs2003(double fkocs2003) {
		this.fkocs2003 = fkocs2003;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="ORIGIN_INPUT_GUBUN")
	public String getOriginInputGubun() {
		return this.originInputGubun;
	}

	public void setOriginInputGubun(String originInputGubun) {
		this.originInputGubun = originInputGubun;
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