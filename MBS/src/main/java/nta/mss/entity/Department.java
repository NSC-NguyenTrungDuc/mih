package nta.mss.entity;

import java.util.List;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.FetchType;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.JoinColumn;
import javax.persistence.ManyToOne;
import javax.persistence.OneToMany;
import javax.persistence.Table;

import nta.mss.model.DepartmentModel;

/**
 * The persistent class for the deparment database table.
 * 
 */
@Entity
@Table(name = "department")
public class Department extends BaseEntity<DepartmentModel> {
	private static final long serialVersionUID = 1L;

	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	@Column(name = "dept_id", unique = true, nullable = false)
	private Integer deptId;

	@Column(name = "dept_code")
	private String deptCode;
	
	@Column(name = "dept_name", length = 256)
	private String deptName;

	@Column(name = "dept_type")
	private Integer deptType;

	@Column(name = "display_order")
	private Integer displayOrder;

	// bi-directional many-to-one association to Hospital
	@ManyToOne(fetch = FetchType.LAZY)
	@JoinColumn(name = "hospital_id", nullable = false)
	private Hospital hospital;

	// bi-directional many-to-one association to DepartmentSchedule
	@OneToMany(mappedBy = "department", fetch = FetchType.LAZY)
	private List<DepartmentSchedule> departmentSchedules;

	// bi-directional many-to-one association to Doctor
	@OneToMany(mappedBy = "department", fetch = FetchType.LAZY)
	private List<Doctor> doctors;

//	//bi-directional many-to-one association to Vaccine
//	@OneToMany(mappedBy="department")
//	private List<Vaccine> vaccines;
	/**
	 * Instantiates a new department.
	 */
	public Department() {
		super(DepartmentModel.class);
	}

	public Integer getDeptId() {
		return this.deptId;
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
		return this.deptName;
	}

	public void setDeptName(String deptName) {
		this.deptName = deptName;
	}

	public Integer getDeptType() {
		return this.deptType;
	}

	public void setDeptType(Integer deptType) {
		this.deptType = deptType;
	}

	public Integer getDisplayOrder() {
		return this.displayOrder;
	}

	public void setDisplayOrder(Integer displayOrder) {
		this.displayOrder = displayOrder;
	}

//	public Date getUpdated() {
//		return this.updated;
//	}
//
//	public void setUpdated(Date updated) {
//		this.updated = updated;
//	}

	public Hospital getHospital() {
		return this.hospital;
	}

	public void setHospital(Hospital hospital) {
		this.hospital = hospital;
	}

	public List<DepartmentSchedule> getDepartmentSchedules() {
		return this.departmentSchedules;
	}

	public void setDepartmentSchedules(
			List<DepartmentSchedule> departmentSchedules) {
		this.departmentSchedules = departmentSchedules;
	}

	public List<Doctor> getDoctors() {
		return this.doctors;
	}

	public void setDoctors(List<Doctor> doctors) {
		this.doctors = doctors;
	}
	
//	public List<Vaccine> getVaccines() {
//		return this.vaccines;
//	}
//
//	public void setVaccines(List<Vaccine> vaccines) {
//		this.vaccines = vaccines;
//	}
}