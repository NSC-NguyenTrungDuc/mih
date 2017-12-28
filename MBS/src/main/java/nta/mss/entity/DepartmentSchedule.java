package nta.mss.entity;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.FetchType;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.JoinColumn;
import javax.persistence.ManyToOne;
import javax.persistence.Table;

import nta.mss.model.DepartmentScheduleModel;

/**
 * The persistent class for the department_schedule database table.
 * 
 */
@Entity
@Table(name = "department_schedule")
public class DepartmentSchedule extends BaseEntity<DepartmentScheduleModel> {
	private static final long serialVersionUID = 1L;

	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	@Column(name = "department_schedule_id", unique = true, nullable = false)
	private Integer departmentScheduleId;

	@Column(name = "day", length = 8)
	private String day;

	@Column(name = "start_time", length = 6)
	private String startTime;

	@Column(name = "end_time", length = 6)
	private String endTime;
	
	@Column(name = "apply_date", length = 8)
	private String applyDate;
	
	@Column(name = "kpi")
	private Integer kpi;

	@Column(name = "holiday_flg", insertable = false, updatable = true)
	private Integer holidayFlg;
	
	// bi-directional many-to-one association to Deparment
	@ManyToOne(fetch = FetchType.LAZY)
	@JoinColumn(name = "dept_id")
	private Department department;

	// bi-directional many-to-one association to Hospital
	@ManyToOne(fetch = FetchType.LAZY)
	@JoinColumn(name = "hospital_id")
	private Hospital hospital;
	
	// bi-directional many-to-one association to Doctor
	@ManyToOne(fetch = FetchType.LAZY)
	@JoinColumn(name = "doctor_id")
	private Doctor doctor;

	/**
	 * Instantiates a new department schedule.
	 */
	public DepartmentSchedule() {
		super(DepartmentScheduleModel.class);
	}

	public Integer getDepartmentScheduleId() {
		return departmentScheduleId;
	}

	public void setDepartmentScheduleId(Integer departmentScheduleId) {
		this.departmentScheduleId = departmentScheduleId;
	}

	public String getDay() {
		return day;
	}

	public void setDay(String day) {
		this.day = day;
	}

	public String getStartTime() {
		return startTime;
	}

	public void setStartTime(String startTime) {
		this.startTime = startTime;
	}

	public String getEndTime() {
		return this.endTime;
	}

	public void setEndTime(String checkTimeTo) {
		this.endTime = checkTimeTo;
	}

	public String getApplyDate() {
		return applyDate;
	}

	public void setApplyDate(String applyDate) {
		this.applyDate = applyDate;
	}

	public Integer getKpi() {
		return kpi;
	}

	public void setKpi(Integer kpi) {
		this.kpi = kpi;
	}

	public Integer getHolidayFlg() {
		return this.holidayFlg;
	}

	public void setHolidayFlg(Integer holidayFlg) {
		this.holidayFlg = holidayFlg;
	}

	public Department getDepartment() {
		return this.department;
	}

	public void setDepartment(Department department) {
		this.department = department;
	}

	public Hospital getHospital() {
		return this.hospital;
	}

	public void setHospital(Hospital hospital) {
		this.hospital = hospital;
	}

	public Doctor getDoctor() {
		return doctor;
	}

	public void setDoctor(Doctor doctor) {
		this.doctor = doctor;
	}

}