package nta.mss.model;

import nta.mss.entity.DoctorSchedule;

/**
 * The Class DoctorScheduleModel.
 * 
 * @author DinhNX
 * @CrtDate Jul 29, 2014
 */
public class DoctorScheduleModel extends BaseModel<DoctorSchedule>{

	/** The Constant serialVersionUID. */
	private static final long serialVersionUID = 5862313486296472418L;

	/**
	 * Instantiates a new doctor schedule model.
	 */
	public DoctorScheduleModel() {
		super(DoctorSchedule.class);
	}
	
	private String checkDate;
	private String startTime;
	private String endTime;
	private Integer activeFlg;
	private Integer kpi;
	private Integer hospitalId;
	private String hospitalName;
	private Integer deptId;
	private String deptName;
	private Integer doctorId;
	private String doctorName;

	public String getCheckDate() {
		return checkDate;
	}
	
	public void setCheckDate(String checkDate) {
		this.checkDate = checkDate;
	}
	
	public String getStartTime() {
		return startTime;
	}
	
	public void setStartTime(String startTime) {
		this.startTime = startTime;
	}
	
	public String getEndTime() {
		return endTime;
	}
	
	public void setEndTime(String endTime) {
		this.endTime = endTime;
	}
	
	public Integer getActiveFlg() {
		return activeFlg;
	}
	
	public void setActiveFlg(Integer activeFlg) {
		this.activeFlg = activeFlg;
	}
	
	public Integer getKpi() {
		return kpi;
	}
	
	public void setKpi(Integer kpi) {
		this.kpi = kpi;
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
	
	//Depends on checkDate, startTime and doctorId
	@Override
    public int hashCode() {  
        return 31 * checkDate.hashCode() + startTime.hashCode() + doctorId.hashCode();
    }
 
    //Compare checkDate, startTime and doctorId
    @Override
    public boolean equals(Object obj) {
        if (this == obj)
            return true;
        if (obj == null || !(obj instanceof DoctorScheduleModel))
            return false;
        DoctorScheduleModel dsm = (DoctorScheduleModel) obj;
        if (!checkDate.equals(dsm.getCheckDate()) || !startTime.equals(dsm.getStartTime()) || !doctorId.equals(dsm.getDoctorId()))
            return false;
        return true;
    }

	@Override
	public String toString() {
		return "DoctorScheduleModel [kpi=" + kpi + ", hospitalId=" + hospitalId
				+ ", hospitalName=" + hospitalName + ", deptId=" + deptId
				+ ", deptName=" + deptName + ", doctorId=" + doctorId
				+ ", doctorName=" + doctorName + "]";
	}
	
}
