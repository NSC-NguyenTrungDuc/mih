package nta.med.core.domain.ocs;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the OCS2030 database table.
 * 
 */
@Entity
@NamedQuery(name="Ocs2030.findAll", query="SELECT o FROM Ocs2030 o")
public class Ocs2030 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String activities;
	private double activitiesPoint;
	private String bunho;
	private String feeding;
	private double feedingPoint;
	private double fkinp1001;
	private String hospCode;
	private String ivTherapy;
	private double ivTherapyPoint;
	private Date jukyongDate;
	private String memb;
	private String monitoring;
	private double monitoringPoint;
	private String resTherapy;
	private double resTherapyPoint;
	private double seq;
	private Date sysDate;
	private String sysId;
	private String tESupport;
	private double tESupportPoint;
	private String treatments;
	private double treatmentsPoint;
	private Date updDate;
	private String updId;
	private String vitalSign;
	private double vitalSignPoint;

	public Ocs2030() {
	}


	public String getActivities() {
		return this.activities;
	}

	public void setActivities(String activities) {
		this.activities = activities;
	}


	@Column(name="ACTIVITIES_POINT")
	public double getActivitiesPoint() {
		return this.activitiesPoint;
	}

	public void setActivitiesPoint(double activitiesPoint) {
		this.activitiesPoint = activitiesPoint;
	}


	public String getBunho() {
		return this.bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}


	public String getFeeding() {
		return this.feeding;
	}

	public void setFeeding(String feeding) {
		this.feeding = feeding;
	}


	@Column(name="FEEDING_POINT")
	public double getFeedingPoint() {
		return this.feedingPoint;
	}

	public void setFeedingPoint(double feedingPoint) {
		this.feedingPoint = feedingPoint;
	}


	public double getFkinp1001() {
		return this.fkinp1001;
	}

	public void setFkinp1001(double fkinp1001) {
		this.fkinp1001 = fkinp1001;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="IV_THERAPY")
	public String getIvTherapy() {
		return this.ivTherapy;
	}

	public void setIvTherapy(String ivTherapy) {
		this.ivTherapy = ivTherapy;
	}


	@Column(name="IV_THERAPY_POINT")
	public double getIvTherapyPoint() {
		return this.ivTherapyPoint;
	}

	public void setIvTherapyPoint(double ivTherapyPoint) {
		this.ivTherapyPoint = ivTherapyPoint;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="JUKYONG_DATE")
	public Date getJukyongDate() {
		return this.jukyongDate;
	}

	public void setJukyongDate(Date jukyongDate) {
		this.jukyongDate = jukyongDate;
	}


	public String getMemb() {
		return this.memb;
	}

	public void setMemb(String memb) {
		this.memb = memb;
	}


	public String getMonitoring() {
		return this.monitoring;
	}

	public void setMonitoring(String monitoring) {
		this.monitoring = monitoring;
	}


	@Column(name="MONITORING_POINT")
	public double getMonitoringPoint() {
		return this.monitoringPoint;
	}

	public void setMonitoringPoint(double monitoringPoint) {
		this.monitoringPoint = monitoringPoint;
	}


	@Column(name="RES_THERAPY")
	public String getResTherapy() {
		return this.resTherapy;
	}

	public void setResTherapy(String resTherapy) {
		this.resTherapy = resTherapy;
	}


	@Column(name="RES_THERAPY_POINT")
	public double getResTherapyPoint() {
		return this.resTherapyPoint;
	}

	public void setResTherapyPoint(double resTherapyPoint) {
		this.resTherapyPoint = resTherapyPoint;
	}


	public double getSeq() {
		return this.seq;
	}

	public void setSeq(double seq) {
		this.seq = seq;
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


	@Column(name="T_E_SUPPORT")
	public String getTESupport() {
		return this.tESupport;
	}

	public void setTESupport(String tESupport) {
		this.tESupport = tESupport;
	}


	@Column(name="T_E_SUPPORT_POINT")
	public double getTESupportPoint() {
		return this.tESupportPoint;
	}

	public void setTESupportPoint(double tESupportPoint) {
		this.tESupportPoint = tESupportPoint;
	}


	public String getTreatments() {
		return this.treatments;
	}

	public void setTreatments(String treatments) {
		this.treatments = treatments;
	}


	@Column(name="TREATMENTS_POINT")
	public double getTreatmentsPoint() {
		return this.treatmentsPoint;
	}

	public void setTreatmentsPoint(double treatmentsPoint) {
		this.treatmentsPoint = treatmentsPoint;
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


	@Column(name="VITAL_SIGN")
	public String getVitalSign() {
		return this.vitalSign;
	}

	public void setVitalSign(String vitalSign) {
		this.vitalSign = vitalSign;
	}


	@Column(name="VITAL_SIGN_POINT")
	public double getVitalSignPoint() {
		return this.vitalSignPoint;
	}

	public void setVitalSignPoint(double vitalSignPoint) {
		this.vitalSignPoint = vitalSignPoint;
	}

}