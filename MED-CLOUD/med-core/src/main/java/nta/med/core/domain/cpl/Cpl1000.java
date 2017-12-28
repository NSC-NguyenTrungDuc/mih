package nta.med.core.domain.cpl;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the CPL1000 database table.
 * 
 */
@Entity
@NamedQuery(name="Cpl1000.findAll", query="SELECT c FROM Cpl1000 c")
@Table(name="CPL1000")
public class Cpl1000 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String bunho;
	private double fkocs;
	private String hangmogCode;
	private String height;
	private String hospCode;
	private String inOutGubun;
	private Date orderDate;
	private double pkcpl1000;
	private String specimenSer;
	private String stabilityYn;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;
	private String urineRyang;
	private String weight;

	public Cpl1000() {
	}


	public String getBunho() {
		return this.bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}


	public double getFkocs() {
		return this.fkocs;
	}

	public void setFkocs(double fkocs) {
		this.fkocs = fkocs;
	}


	@Column(name="HANGMOG_CODE")
	public String getHangmogCode() {
		return this.hangmogCode;
	}

	public void setHangmogCode(String hangmogCode) {
		this.hangmogCode = hangmogCode;
	}


	public String getHeight() {
		return this.height;
	}

	public void setHeight(String height) {
		this.height = height;
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


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="ORDER_DATE")
	public Date getOrderDate() {
		return this.orderDate;
	}

	public void setOrderDate(Date orderDate) {
		this.orderDate = orderDate;
	}


	public double getPkcpl1000() {
		return this.pkcpl1000;
	}

	public void setPkcpl1000(double pkcpl1000) {
		this.pkcpl1000 = pkcpl1000;
	}


	@Column(name="SPECIMEN_SER")
	public String getSpecimenSer() {
		return this.specimenSer;
	}

	public void setSpecimenSer(String specimenSer) {
		this.specimenSer = specimenSer;
	}


	@Column(name="STABILITY_YN")
	public String getStabilityYn() {
		return this.stabilityYn;
	}

	public void setStabilityYn(String stabilityYn) {
		this.stabilityYn = stabilityYn;
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


	@Column(name="URINE_RYANG")
	public String getUrineRyang() {
		return this.urineRyang;
	}

	public void setUrineRyang(String urineRyang) {
		this.urineRyang = urineRyang;
	}


	public String getWeight() {
		return this.weight;
	}

	public void setWeight(String weight) {
		this.weight = weight;
	}

}