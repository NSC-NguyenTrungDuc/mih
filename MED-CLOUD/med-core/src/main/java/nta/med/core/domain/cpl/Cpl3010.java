package nta.med.core.domain.cpl;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the CPL3010 database table.
 * 
 */
@Entity
@Table(name="CPL3010")
public class Cpl3010 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private Date growthDate;
	private String growthYn;
	private String hospCode;
	private String jangbiYn;
	private Date jubsuDate;
	private String jundalGubun;
	private String labNo;
	private String medicalJundal;
	private String noGrowthYn;
	private Date orderDate;
	private Date partJubsuDate;
	private String partJubsuTime;
	private Date resultDate;
	private String resultTime;
	private String slipCode;
	private String specimenSer;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Cpl3010() {
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="GROWTH_DATE")
	public Date getGrowthDate() {
		return this.growthDate;
	}

	public void setGrowthDate(Date growthDate) {
		this.growthDate = growthDate;
	}


	@Column(name="GROWTH_YN")
	public String getGrowthYn() {
		return this.growthYn;
	}

	public void setGrowthYn(String growthYn) {
		this.growthYn = growthYn;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="JANGBI_YN")
	public String getJangbiYn() {
		return this.jangbiYn;
	}

	public void setJangbiYn(String jangbiYn) {
		this.jangbiYn = jangbiYn;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="JUBSU_DATE")
	public Date getJubsuDate() {
		return this.jubsuDate;
	}

	public void setJubsuDate(Date jubsuDate) {
		this.jubsuDate = jubsuDate;
	}


	@Column(name="JUNDAL_GUBUN")
	public String getJundalGubun() {
		return this.jundalGubun;
	}

	public void setJundalGubun(String jundalGubun) {
		this.jundalGubun = jundalGubun;
	}


	@Column(name="LAB_NO")
	public String getLabNo() {
		return this.labNo;
	}

	public void setLabNo(String labNo) {
		this.labNo = labNo;
	}


	@Column(name="MEDICAL_JUNDAL")
	public String getMedicalJundal() {
		return this.medicalJundal;
	}

	public void setMedicalJundal(String medicalJundal) {
		this.medicalJundal = medicalJundal;
	}


	@Column(name="NO_GROWTH_YN")
	public String getNoGrowthYn() {
		return this.noGrowthYn;
	}

	public void setNoGrowthYn(String noGrowthYn) {
		this.noGrowthYn = noGrowthYn;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="ORDER_DATE")
	public Date getOrderDate() {
		return this.orderDate;
	}

	public void setOrderDate(Date orderDate) {
		this.orderDate = orderDate;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="PART_JUBSU_DATE")
	public Date getPartJubsuDate() {
		return this.partJubsuDate;
	}

	public void setPartJubsuDate(Date partJubsuDate) {
		this.partJubsuDate = partJubsuDate;
	}


	@Column(name="PART_JUBSU_TIME")
	public String getPartJubsuTime() {
		return this.partJubsuTime;
	}

	public void setPartJubsuTime(String partJubsuTime) {
		this.partJubsuTime = partJubsuTime;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="RESULT_DATE")
	public Date getResultDate() {
		return this.resultDate;
	}

	public void setResultDate(Date resultDate) {
		this.resultDate = resultDate;
	}


	@Column(name="RESULT_TIME")
	public String getResultTime() {
		return this.resultTime;
	}

	public void setResultTime(String resultTime) {
		this.resultTime = resultTime;
	}


	@Column(name="SLIP_CODE")
	public String getSlipCode() {
		return this.slipCode;
	}

	public void setSlipCode(String slipCode) {
		this.slipCode = slipCode;
	}


	@Column(name="SPECIMEN_SER")
	public String getSpecimenSer() {
		return this.specimenSer;
	}

	public void setSpecimenSer(String specimenSer) {
		this.specimenSer = specimenSer;
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