package nta.mss.entity;

import javax.persistence.Column;
import javax.persistence.EmbeddedId;
import javax.persistence.Entity;
import javax.persistence.FetchType;
import javax.persistence.JoinColumn;
import javax.persistence.ManyToOne;
import javax.persistence.Table;

import nta.mss.model.DoctorScheduleModel;

/**
 * The persistent class for the doctor_schedule database table.
 * 
 */
@Entity
@Table(name = "doctor_schedule")
public class DoctorSchedule extends BaseEntity<DoctorScheduleModel> {
	private static final long serialVersionUID = 1L;

	@EmbeddedId
	private DoctorSchedulePK id;

	@Column(name = "end_time", length = 6)
	private String endTime;
	
	@Column(name = "kpi", nullable = false)
	private Integer kpi;

	// bi-directional many-to-one association to Deparment
	@ManyToOne(fetch = FetchType.LAZY)
	@JoinColumn(name = "dept_id")
	private Department department;

	// bi-directional many-to-one association to Doctor
	@ManyToOne(fetch = FetchType.LAZY)
	@JoinColumn(name = "doctor_id", nullable = false, insertable = false, updatable = false)
	private Doctor doctor;

	// bi-directional many-to-one association to Hospital
	@ManyToOne(fetch = FetchType.LAZY)
	@JoinColumn(name = "hospital_id")
	private Hospital hospital;

	/**
	 * Instantiates a new doctor schedule.
	 */
	public DoctorSchedule() {
		super(DoctorScheduleModel.class);
	}

	public DoctorSchedulePK getId() {
		return this.id;
	}

	public void setId(DoctorSchedulePK id) {
		this.id = id;
	}

	public String getEndTime() {
		return endTime;
	}

	public void setEndTime(String endTime) {
		this.endTime = endTime;
	}

	public Integer getKpi() {
		return this.kpi;
	}

	public void setKpi(Integer kpi) {
		this.kpi = kpi;
	}

	public Department getDepartment() {
		return this.department;
	}

	public void setDepartment(Department department) {
		this.department = department;
	}

	public Doctor getDoctor() {
		return this.doctor;
	}

	public void setDoctor(Doctor doctor) {
		this.doctor = doctor;
	}

	public Hospital getHospital() {
		return this.hospital;
	}

	public void setHospital(Hospital hospital) {
		this.hospital = hospital;
	}

}