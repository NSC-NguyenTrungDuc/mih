package nta.mss.model;

import nta.mss.entity.DepartmentSchedule;

public class DepartmentScheduleModel extends BaseModel<DepartmentSchedule>{
	
	/** The Constant serialVersionUID. */
	private static final long serialVersionUID = 7660540230305085387L;
	
	/**
	 * Instantiates a new department schedule model.
	 */
	public DepartmentScheduleModel() {
		super(DepartmentSchedule.class);
	}
	
	private Integer departmentScheduleId;
	private String day;
	private String startTime;
	private Integer activeFlg;
	private String endTime;
	private String applyDate;
	private Integer kpi;
	private Integer status;
	private Integer holidayFlg;
	private Integer hospitalId;
	private String hospitalName;
	private Integer deptId;
	private String deptName;
	private Integer doctorId;
	private String doctorName;

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
	public Integer getActiveFlg() {
		return activeFlg;
	}
	public void setActiveFlg(Integer activeFlg) {
		this.activeFlg = activeFlg;
	}
	public String getEndTime() {
		return endTime;
	}
	public void setEndTime(String endTime) {
		this.endTime = endTime;
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
	public Integer getStatus() {
		return status;
	}
	public void setStatus(Integer status) {
		this.status = status;
	}
	public Integer getHolidayFlg() {
		return holidayFlg;
	}
	public void setHolidayFlg(Integer holidayFlg) {
		this.holidayFlg = holidayFlg;
	}
	public Integer getHospitalId() {
		return hospitalId;
	}
	public void setHospitalId(Integer hospitalId) {
		this.hospitalId = hospitalId;
	}
	public String getHospitalName() {
		return hospitalName;
	}
	public void setHospitalName(String hospitalName) {
		this.hospitalName = hospitalName;
	}
	public Integer getDeptId() {
		return deptId;
	}
	public void setDeptId(Integer deptId) {
		this.deptId = deptId;
	}
	public String getDeptName() {
		return deptName;
	}
	public void setDeptName(String deptName) {
		this.deptName = deptName;
	}
	public Integer getDoctorId() {
		return doctorId;
	}
	public void setDoctorId(Integer doctorId) {
		this.doctorId = doctorId;
	}
	public String getDoctorName() {
		return doctorName;
	}
	public void setDoctorName(String doctorName) {
		this.doctorName = doctorName;
	}
}
