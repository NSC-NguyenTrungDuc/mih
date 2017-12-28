package nta.mss.model;

import java.util.List;

import javax.validation.constraints.NotNull;

import org.hibernate.validator.constraints.NotBlank;

import nta.mss.entity.Department;
import nta.mss.validation.CheckSpecialChar;

/**
 * The Class DepartmentModel.
 * 
 * @author DinhNX
 * @CrtDate Jul 29, 2014
 */
public class DepartmentModel extends BaseModel<Department> implements Comparable<DepartmentModel> {
	
	/** The Constant serialVersionUID. */
	private static final long serialVersionUID = 1L;
	
	private Integer deptId;
	@NotBlank
	@CheckSpecialChar
	private String deptCode;
	@NotBlank
	private String deptName;
	@NotNull
	private Integer displayOrder;
	@NotNull
	private Integer deptType;
	private Integer hospitalId;
	private String hospitalName;
	private Integer activeFlg;
	private Integer defaultTimeSlot;
	private List<Integer> timeSlot;
	//private List<Doctor> doctors;
	
	/**
	 * Instantiates a new department model.
	 */
	public DepartmentModel() {
		super(Department.class);
	}
	
	public Integer getDeptId() {
		return deptId;
	}
	
	public void setDeptId(Integer deptId) {
		this.deptId = deptId;
	}
	
	public String getDeptCode() {
		return deptCode;
	}

	public void setDeptCode(String deptCode) {
		this.deptCode = deptCode;
	}

	public String getDeptName() {
		return deptName;
	}
	
	public void setDeptName(String deptName) {
		this.deptName = deptName;
	}
	
	public Integer getDisplayOrder() {
		return displayOrder;
	}
	
	public void setDisplayOrder(Integer displayOrder) {
		this.displayOrder = displayOrder;
	}

	public Integer getDeptType() {
		return deptType;
	}

	public void setDeptType(Integer deptType) {
		this.deptType = deptType;
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

	public Integer getActiveFlg() {
		return activeFlg;
	}

	public void setActiveFlg(Integer activeFlg) {
		this.activeFlg = activeFlg;
	}
	
	
	public List<Integer> getTimeSlot() {
		return timeSlot;
	}

	public void setTimeSlot(List<Integer> timeSlot) {
		this.timeSlot = timeSlot;
	}
	
	public Integer getDefaultTimeSlot() {
		return defaultTimeSlot;
	}

	public void setDefaultTimeSlot(Integer defaultTimeSlot) {
		this.defaultTimeSlot = defaultTimeSlot;
	}

	/**
	 * Compare to.
	 * 
	 * @param dep
	 *            the dep
	 * @return the int
	 */
	@Override
	public int compareTo(DepartmentModel dep) {
		return this.deptId - dep.getDeptId();
	}

	@Override
	public String toString() {
		return "DepartmentModel [deptId=" + deptId + ", deptCode=" + deptCode + ", deptName=" + deptName
				+ ", displayOrder=" + displayOrder + ", deptType=" + deptType + ", hospitalId=" + hospitalId
				+ ", hospitalName=" + hospitalName + ", activeFlg=" + activeFlg + ", defaultTimeSlot=" + defaultTimeSlot
				+ ", timeSlot=" + timeSlot + "]";
	}

	

/*	public List<Doctor> getDoctors() {
		return doctors;
	}

	public void setDoctors(List<Doctor> doctors) {
		this.doctors = doctors;
	}*/
}
