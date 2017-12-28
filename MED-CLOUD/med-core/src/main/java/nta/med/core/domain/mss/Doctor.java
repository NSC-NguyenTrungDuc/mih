package nta.med.core.domain.mss;

import java.io.Serializable;
import javax.persistence.*;
import java.math.BigDecimal;
import java.sql.Timestamp;


/**
 * The persistent class for the doctor database table.
 * 
 */
@Entity
@Table(name = "doctor")
@NamedQuery(name="Doctor.findAll", query="SELECT d FROM Doctor d")
public class Doctor implements Serializable {
	private static final long serialVersionUID = 1L;
	private Integer doctorId;
	private BigDecimal activeFlg;
	private Timestamp created;
	private Integer deptId;
	private BigDecimal juniorFlg;
	private Integer kpiAvg;
	private String name;
	private Integer orderPriority;
	private Timestamp updated;

	public Doctor() {
	}


	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	@Column(name="doctor_id", unique = true, nullable = false)
	public Integer getDoctorId() {
		return this.doctorId;
	}

	public void setDoctorId(Integer doctorId) {
		this.doctorId = doctorId;
	}


	@Column(name="active_flg")
	public BigDecimal getActiveFlg() {
		return this.activeFlg;
	}

	public void setActiveFlg(BigDecimal activeFlg) {
		this.activeFlg = activeFlg;
	}


	public Timestamp getCreated() {
		return this.created;
	}

	public void setCreated(Timestamp created) {
		this.created = created;
	}


	@Column(name="dept_id")
	public Integer getDeptId() {
		return this.deptId;
	}

	public void setDeptId(Integer deptId) {
		this.deptId = deptId;
	}


	@Column(name="junior_flg")
	public BigDecimal getJuniorFlg() {
		return this.juniorFlg;
	}

	public void setJuniorFlg(BigDecimal juniorFlg) {
		this.juniorFlg = juniorFlg;
	}


	@Column(name="kpi_avg")
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


	@Column(name="order_priority")
	public Integer getOrderPriority() {
		return this.orderPriority;
	}

	public void setOrderPriority(Integer orderPriority) {
		this.orderPriority = orderPriority;
	}


	public Timestamp getUpdated() {
		return this.updated;
	}

	public void setUpdated(Timestamp updated) {
		this.updated = updated;
	}

}