package nta.med.core.domain.sch;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the SCH3000 database table.
 * 
 */
@Entity
@NamedQuery(name="Sch3000.findAll", query="SELECT s FROM Sch3000 s")
@Table(name="SCH3000")
public class Sch3000 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private Double addInwon;
	private String endTime;
	private String gumsaja;
	private String hospCode;
	private Double inwon;
	private Date jukyongDate;
	private String jundalPart;
	private String jundalTable;
	private String startTime;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;
	private String yoilGubun;
	private Double outHospCodeSlot;

	public Sch3000() {
	}


	@Column(name="ADD_INWON")
	public Double getAddInwon() {
		return this.addInwon;
	}

	public void setAddInwon(Double addInwon) {
		this.addInwon = addInwon;
	}


	@Column(name="END_TIME")
	public String getEndTime() {
		return this.endTime;
	}

	public void setEndTime(String endTime) {
		this.endTime = endTime;
	}


	public String getGumsaja() {
		return this.gumsaja;
	}

	public void setGumsaja(String gumsaja) {
		this.gumsaja = gumsaja;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	public Double getInwon() {
		return this.inwon;
	}

	public void setInwon(Double inwon) {
		this.inwon = inwon;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="JUKYONG_DATE")
	public Date getJukyongDate() {
		return this.jukyongDate;
	}

	public void setJukyongDate(Date jukyongDate) {
		this.jukyongDate = jukyongDate;
	}


	@Column(name="JUNDAL_PART")
	public String getJundalPart() {
		return this.jundalPart;
	}

	public void setJundalPart(String jundalPart) {
		this.jundalPart = jundalPart;
	}


	@Column(name="JUNDAL_TABLE")
	public String getJundalTable() {
		return this.jundalTable;
	}

	public void setJundalTable(String jundalTable) {
		this.jundalTable = jundalTable;
	}


	@Column(name="START_TIME")
	public String getStartTime() {
		return this.startTime;
	}

	public void setStartTime(String startTime) {
		this.startTime = startTime;
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


	@Column(name="YOIL_GUBUN")
	public String getYoilGubun() {
		return this.yoilGubun;
	}

	public void setYoilGubun(String yoilGubun) {
		this.yoilGubun = yoilGubun;
	}

	@Column(name="OUT_HOSP_SLOT")
	public Double getOutHospCodeSlot() {
		return outHospCodeSlot;
	}


	public void setOutHospCodeSlot(Double outHospCodeSlot) {
		this.outHospCodeSlot = outHospCodeSlot;
	}

}