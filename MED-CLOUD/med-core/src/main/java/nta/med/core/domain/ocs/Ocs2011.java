package nta.med.core.domain.ocs;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the OCS2011 database table.
 * 
 */
@Entity
@NamedQuery(name="Ocs2011.findAll", query="SELECT o FROM Ocs2011 o")
public class Ocs2011 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String doctor;
	private double fkinp1001;
	private Date fromJukyongDate;
	private String hospCode;
	private Date orderDate;
	private double pkocs2011;
	private String specialYn;
	private Date sysDate;
	private String sysId;
	private Date toJukyongDate;
	private Date updDate;
	private String updId;

	public Ocs2011() {
	}


	public String getDoctor() {
		return this.doctor;
	}

	public void setDoctor(String doctor) {
		this.doctor = doctor;
	}


	public double getFkinp1001() {
		return this.fkinp1001;
	}

	public void setFkinp1001(double fkinp1001) {
		this.fkinp1001 = fkinp1001;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="FROM_JUKYONG_DATE")
	public Date getFromJukyongDate() {
		return this.fromJukyongDate;
	}

	public void setFromJukyongDate(Date fromJukyongDate) {
		this.fromJukyongDate = fromJukyongDate;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="ORDER_DATE")
	public Date getOrderDate() {
		return this.orderDate;
	}

	public void setOrderDate(Date orderDate) {
		this.orderDate = orderDate;
	}


	public double getPkocs2011() {
		return this.pkocs2011;
	}

	public void setPkocs2011(double pkocs2011) {
		this.pkocs2011 = pkocs2011;
	}


	@Column(name="SPECIAL_YN")
	public String getSpecialYn() {
		return this.specialYn;
	}

	public void setSpecialYn(String specialYn) {
		this.specialYn = specialYn;
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
	@Column(name="TO_JUKYONG_DATE")
	public Date getToJukyongDate() {
		return this.toJukyongDate;
	}

	public void setToJukyongDate(Date toJukyongDate) {
		this.toJukyongDate = toJukyongDate;
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