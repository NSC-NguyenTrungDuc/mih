package nta.mss.model;

import javax.validation.constraints.NotNull;

import nta.mss.entity.Doctor;

import org.hibernate.validator.constraints.NotBlank;

/**
 * The model class for doctor.
 * 
 * @author DinhNX
 * @CrtDate Jul 29, 2014
 */
public class DoctorModel extends BaseModel<Doctor> {
	
	/** The Constant serialVersionUID. */
	private static final long serialVersionUID = -5037078490064972441L;

	/**
	 * Instantiates a new doctor model.
	 */
	public DoctorModel() {
		super(Doctor.class);
	}

	private Integer doctorId;
	private String doctorCode;
	private Integer juniorFlg;
	private Integer kpiAvg;
	@NotBlank
	private String name;
	@NotNull
	private Integer orderPriority;
	private Integer deptId;
	private Integer copyDoctorId;
	/**
	 * Gets the doctor id.
	 * 
	 * @return the doctor id
	 */
	public Integer getDoctorId() {
		return doctorId;
	}
	
	/**
	 * Sets the doctor id.
	 * 
	 * @param doctorId
	 *            the new doctor id
	 */
	public void setDoctorId(Integer doctorId) {
		this.doctorId = doctorId;
	}
	
	
	public String getDoctorCode() {
		return doctorCode;
	}

	public void setDoctorCode(String doctorCode) {
		this.doctorCode = doctorCode;
	}

	/**
	 * Gets the junior flg.
	 * 
	 * @return the junior flg
	 */
	public Integer getJuniorFlg() {
		return juniorFlg;
	}
	
	/**
	 * Sets the junior flg.
	 * 
	 * @param juniorFlg
	 *            the new junior flg
	 */
	public void setJuniorFlg(Integer juniorFlg) {
		this.juniorFlg = juniorFlg;
	}
	
	/**
	 * Gets the kpi avg.
	 * 
	 * @return the kpi avg
	 */
	public Integer getKpiAvg() {
		return kpiAvg;
	}
	
	/**
	 * Sets the kpi avg.
	 * 
	 * @param kpiAvg
	 *            the new kpi avg
	 */
	public void setKpiAvg(Integer kpiAvg) {
		this.kpiAvg = kpiAvg;
	}
	
	/**
	 * Gets the name.
	 * 
	 * @return the name
	 */
	public String getName() {
		return name;
	}
	
	/**
	 * Sets the name.
	 * 
	 * @param name
	 *            the new name
	 */
	public void setName(String name) {
		this.name = name;
	}

	/**
	 * Gets the order priority.
	 * 
	 * @return the order priority
	 */
	public Integer getOrderPriority() {
		return orderPriority;
	}

	/**
	 * Sets the order priority.
	 * 
	 * @param orderPriority
	 *            the new order priority
	 */
	public void setOrderPriority(Integer orderPriority) {
		this.orderPriority = orderPriority;
	}

	/**
	 * Gets the dept id.
	 * 
	 * @return the dept id
	 */
	public Integer getDeptId() {
		return deptId;
	}

	/**
	 * Sets the dept id.
	 * 
	 * @param deptId
	 *            the new dept id
	 */
	public void setDeptId(Integer deptId) {
		this.deptId = deptId;
	}

	/**
	 * Gets the copy doctor id.
	 *
	 * @return the copy doctor id
	 */
	public Integer getCopyDoctorId() {
		return copyDoctorId;
	}

	/**
	 * Sets the copy doctor id.
	 *
	 * @param copyDoctorId the new copy doctor id
	 */
	public void setCopyDoctorId(Integer copyDoctorId) {
		this.copyDoctorId = copyDoctorId;
	}

	@Override
	public String toString() {
		return "DoctorModel [doctorId=" + doctorId + ", kpiAvg=" + kpiAvg
				+ ", name=" + name + ", deptId=" + deptId + "]";
	}
}
