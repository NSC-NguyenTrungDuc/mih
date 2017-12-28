package nta.med.core.domain.cpl;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the CPL0308 database table.
 * 
 */
@Entity
@NamedQuery(name="Cpl0308.findAll", query="SELECT c FROM Cpl0308 c")
public class Cpl0308 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String hospCode;
	private String labC;
	private String labF;
	private String labH;
	private String labO;
	private String labR;
	private String labS;
	private String labU;
	private Date partJubsuDate;
	private String partJubsuTime;
	private String specimenCode;
	private String specimenSer;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Cpl0308() {
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="LAB_C")
	public String getLabC() {
		return this.labC;
	}

	public void setLabC(String labC) {
		this.labC = labC;
	}


	@Column(name="LAB_F")
	public String getLabF() {
		return this.labF;
	}

	public void setLabF(String labF) {
		this.labF = labF;
	}


	@Column(name="LAB_H")
	public String getLabH() {
		return this.labH;
	}

	public void setLabH(String labH) {
		this.labH = labH;
	}


	@Column(name="LAB_O")
	public String getLabO() {
		return this.labO;
	}

	public void setLabO(String labO) {
		this.labO = labO;
	}


	@Column(name="LAB_R")
	public String getLabR() {
		return this.labR;
	}

	public void setLabR(String labR) {
		this.labR = labR;
	}


	@Column(name="LAB_S")
	public String getLabS() {
		return this.labS;
	}

	public void setLabS(String labS) {
		this.labS = labS;
	}


	@Column(name="LAB_U")
	public String getLabU() {
		return this.labU;
	}

	public void setLabU(String labU) {
		this.labU = labU;
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


	@Column(name="SPECIMEN_CODE")
	public String getSpecimenCode() {
		return this.specimenCode;
	}

	public void setSpecimenCode(String specimenCode) {
		this.specimenCode = specimenCode;
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