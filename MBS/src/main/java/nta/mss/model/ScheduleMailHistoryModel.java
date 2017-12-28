package nta.mss.model;

import java.io.Serializable;
import java.util.List;

/**
 * The Class ScheduleMailHistoryModel.
 * 
 * @author DinhNX
 * @CrtDate Jul 29, 2014
 */
public class ScheduleMailHistoryModel implements Serializable {
	
	private static final long serialVersionUID = 2727664389925049727L;
	private Integer hospital;
	private Integer department;
	private String fromDate;
	private String toDate;
	
	private Integer doctorId;
	private String doctorName;
	
	private List<ScheduleMailHistoryTempModel> tempModel;	
	
	public ScheduleMailHistoryModel(Integer hospital, Integer department, String fromDate, String toDate,
			Integer doctorId, String doctorName, List<ScheduleMailHistoryTempModel> tempModel) {
		super();
		this.hospital = hospital;
		this.department = department;
		this.fromDate = fromDate;
		this.toDate = toDate;
		this.doctorId = doctorId;
		this.doctorName = doctorName;
		this.tempModel = tempModel;
	}
	
	public ScheduleMailHistoryModel() {
		super();
	}

	public Integer getHospital() {
		return hospital;
	}
	public void setHospital(Integer hospital) {
		this.hospital = hospital;
	}
	public Integer getDepartment() {
		return department;
	}
	public void setDepartment(Integer department) {
		this.department = department;
	}
	public String getFromDate() {
		return fromDate;
	}
	public void setFromDate(String fromDate) {
		this.fromDate = fromDate;
	}
	public String getToDate() {
		return toDate;
	}
	public void setToDate(String toDate) {
		this.toDate = toDate;
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
	public List<ScheduleMailHistoryTempModel> getTempModel() {
		return tempModel;
	}
	public void setTempModel(List<ScheduleMailHistoryTempModel> tempModel) {
		this.tempModel = tempModel;
	}
	
}
