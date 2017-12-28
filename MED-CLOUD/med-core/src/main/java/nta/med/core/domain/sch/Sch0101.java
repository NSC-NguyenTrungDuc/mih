package nta.med.core.domain.sch;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the SCH0101 database table.
 * 
 */
@Entity
@NamedQuery(name="Sch0101.findAll", query="SELECT s FROM Sch0101 s")
public class Sch0101 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private double addAmInwon;
	private double addPmInwon;
	private String amAvgTime;
	private double amInwon;
	private String amStartTime;
	private String comments;
	private String gumsaja;
	private String hangmogCode;
	private String hospCode;
	private String jundalPart;
	private String jundalTable;
	private String pmAvgTime;
	private double pmInwon;
	private String pmStartTime;
	private String reserGubun;
	private Date startDate;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;
	private String yoilGubun;

	public Sch0101() {
	}


	@Column(name="ADD_AM_INWON")
	public double getAddAmInwon() {
		return this.addAmInwon;
	}

	public void setAddAmInwon(double addAmInwon) {
		this.addAmInwon = addAmInwon;
	}


	@Column(name="ADD_PM_INWON")
	public double getAddPmInwon() {
		return this.addPmInwon;
	}

	public void setAddPmInwon(double addPmInwon) {
		this.addPmInwon = addPmInwon;
	}


	@Column(name="AM_AVG_TIME")
	public String getAmAvgTime() {
		return this.amAvgTime;
	}

	public void setAmAvgTime(String amAvgTime) {
		this.amAvgTime = amAvgTime;
	}


	@Column(name="AM_INWON")
	public double getAmInwon() {
		return this.amInwon;
	}

	public void setAmInwon(double amInwon) {
		this.amInwon = amInwon;
	}


	@Column(name="AM_START_TIME")
	public String getAmStartTime() {
		return this.amStartTime;
	}

	public void setAmStartTime(String amStartTime) {
		this.amStartTime = amStartTime;
	}


	public String getComments() {
		return this.comments;
	}

	public void setComments(String comments) {
		this.comments = comments;
	}


	public String getGumsaja() {
		return this.gumsaja;
	}

	public void setGumsaja(String gumsaja) {
		this.gumsaja = gumsaja;
	}


	@Column(name="HANGMOG_CODE")
	public String getHangmogCode() {
		return this.hangmogCode;
	}

	public void setHangmogCode(String hangmogCode) {
		this.hangmogCode = hangmogCode;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
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


	@Column(name="PM_AVG_TIME")
	public String getPmAvgTime() {
		return this.pmAvgTime;
	}

	public void setPmAvgTime(String pmAvgTime) {
		this.pmAvgTime = pmAvgTime;
	}


	@Column(name="PM_INWON")
	public double getPmInwon() {
		return this.pmInwon;
	}

	public void setPmInwon(double pmInwon) {
		this.pmInwon = pmInwon;
	}


	@Column(name="PM_START_TIME")
	public String getPmStartTime() {
		return this.pmStartTime;
	}

	public void setPmStartTime(String pmStartTime) {
		this.pmStartTime = pmStartTime;
	}


	@Column(name="RESER_GUBUN")
	public String getReserGubun() {
		return this.reserGubun;
	}

	public void setReserGubun(String reserGubun) {
		this.reserGubun = reserGubun;
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


	@Column(name="YOIL_GUBUN")
	public String getYoilGubun() {
		return this.yoilGubun;
	}

	public void setYoilGubun(String yoilGubun) {
		this.yoilGubun = yoilGubun;
	}

}