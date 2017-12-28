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
import javax.persistence.PrePersist;
import javax.persistence.Table;

import nta.mss.model.DoctorModel;

/**
 * The persistent class for the doctor database table.
 * 
 */
@Entity
@Table(name = "doctor")
public class Doctor extends BaseEntity<DoctorModel> {
	private static final long serialVersionUID = 8523365716603491099L;

	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	@Column(name = "doctor_id", unique = true, nullable = false)
	private Integer doctorId;

	@Column(name = "junior_flg")
	private Integer juniorFlg;

	@Column(name = "kpi_avg")
	private Integer kpiAvg;

	@Column(name = "name", length = 64)
	private String name;

	@Column(name = "order_priority")
	private Integer orderPriority;
	
	// bi-directional many-to-one association to Deparment
	@ManyToOne(fetch = FetchType.LAZY)
	@JoinColumn(name = "dept_id")
	private Department department;

	// bi-directional many-to-one association to DoctorSchedule
	@OneToMany(mappedBy = "doctor", fetch = FetchType.LAZY)
	private List<DoctorSchedule> doctorSchedules;

	/**
	 * Instantiates a new doctor.
	 */
	public Doctor() {
		super(DoctorModel.class);
	}

	public Integer getDoctorId() {
		return this.doctorId;
	}

	public void setDoctorId(Integer doctorId) {
		this.doctorId = doctorId;
	}

	public Integer getJuniorFlg() {
		return this.juniorFlg;
	}

	public void setJuniorFlg(Integer juniorFlg) {
		this.juniorFlg = juniorFlg;
	}

	public Integer getKpiAvg() {
		return this.kpiAvg;
	}

	public void setKpiAvg(Integer kpiAvg) {
		this.kpiAvg = kpiAvg;
	}

	public String getName() {
		return this.name;
	}

	public void setName(String name) {
		this.name = name;
	}

	public Department getDepartment() {
		return this.department;
	}

	public void setDepartment(Department department) {
		this.department = department;
	}

	public List<DoctorSchedule> getDoctorSchedules() {
		return this.doctorSchedules;
	}

	public void setDoctorSchedules(List<DoctorSchedule> doctorSchedules) {
		this.doctorSchedules = doctorSchedules;
	}

	public Integer getOrderPriority() {
		return orderPriority;
	}

	public void setOrderPriority(Integer orderPriority) {
		this.orderPriority = orderPriority;
	}
	
	@PrePersist
	void prePersist() {
		if(this.kpiAvg == null) {
			// TODO Change to enum
			this.kpiAvg = 5;
		}
	}
	
}