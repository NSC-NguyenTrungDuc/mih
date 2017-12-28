package nta.mss.entity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;

/**
 * The persistent class for the hospital_schedule database table.
 * 
 */
@Entity
@Table(name = "hospital_schedule")
public class HospitalSchedule implements Serializable {
	private static final long serialVersionUID = 1L;

	@EmbeddedId
	private HospitalSchedulePK id;

	@Column(name = "active_flg")
	private Integer activeFlg;

	@Column(name = "start_time", nullable = false, length = 6)
	private String startTime;

	@Column(name = "from_time", length = 6)
	private String fromTime;

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "created")
	private Date created;

	@Column(name = "holiday_flg", nullable = false)
	private Integer holidayFlg;

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "updated")
	private Date updated;

	// bi-directional many-to-one association to Hospital
	@ManyToOne(fetch = FetchType.LAZY)
	@JoinColumn(name = "hospital_id", nullable = false, insertable = false, updatable = false)
	private Hospital hospital;

	/**
	 * Instantiates a new hospital schedule.
	 */
	public HospitalSchedule() {
	}

	public HospitalSchedulePK getId() {
		return this.id;
	}

	public void setId(HospitalSchedulePK id) {
		this.id = id;
	}

	public Integer getActiveFlg() {
		return this.activeFlg;
	}

	public void setActiveFlg(Integer activeFlg) {
		this.activeFlg = activeFlg;
	}

	public String getStartTime() {
		return this.startTime;
	}

	public void setStartTime(String startTime) {
		this.startTime = startTime;
	}

	public String getFromTime() {
		return this.fromTime;
	}

	public void setFromTime(String fromTime) {
		this.fromTime = fromTime;
	}

	public Date getCreated() {
		return this.created;
	}

	public void setCreated(Date created) {
		this.created = created;
	}

	public Integer getHolidayFlg() {
		return this.holidayFlg;
	}

	public void setHolidayFlg(Integer holidayFlg) {
		this.holidayFlg = holidayFlg;
	}

	public Date getUpdated() {
		return this.updated;
	}

	public void setUpdated(Date updated) {
		this.updated = updated;
	}

	public Hospital getHospital() {
		return this.hospital;
	}

	public void setHospital(Hospital hospital) {
		this.hospital = hospital;
	}

}