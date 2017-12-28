package nta.mss.entity;

import java.io.Serializable;
import java.sql.Timestamp;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.FetchType;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.JoinColumn;
import javax.persistence.ManyToOne;
import javax.persistence.Table;

import nta.mss.model.VaccineChildHistoryModel;


/**
 * The persistent class for the vaccine_child_history database table.
 * 
 */
@Entity
@Table(name="vaccine_child_history")
public class VaccineChildHistory extends BaseEntity<VaccineChildHistoryModel> implements Serializable {
	private static final long serialVersionUID = 1L;

	@Id
	@GeneratedValue(strategy=GenerationType.IDENTITY)
	@Column(name="vaccine_child_id", unique=true, nullable=false)
	private Integer vaccineChildId;

	@Column(name="hospital_name", length=128)
	private String hospitalName;

	@Column(name="injected_date", nullable=false)
	private Timestamp injectedDate;

	@Column(name="injected_no")
	private Integer injectedNo;
	
	//bi-directional many-to-one association to UserChild
	@ManyToOne(fetch=FetchType.LAZY)
	@JoinColumn(name="child_id", nullable=false)
	private UserChild userChild;

	//bi-directional many-to-one association to Vaccine
	@ManyToOne(fetch=FetchType.LAZY)
	@JoinColumn(name="vaccine_id")
	private Vaccine vaccine;
	
	@Column(name="reservation_id")
	private Integer reservationId;

	@Column(name="login_hospital_id", nullable=false)
	private Integer loginHospitalId;

	//bi-directional many-to-one association to UserChild
	@ManyToOne(fetch=FetchType.LAZY)
	@JoinColumn(name="vaccine_hospital_id")
	private VaccineHospital vaccineHospital;
	
	public VaccineChildHistory() {
		super(VaccineChildHistoryModel.class);
	}

	public Integer getVaccineChildId() {
		return this.vaccineChildId;
	}

	public void setVaccineChildId(Integer vaccineChildId) {
		this.vaccineChildId = vaccineChildId;
	}

	public String getHospitalName() {
		return this.hospitalName;
	}

	public void setHospitalName(String hospitalName) {
		this.hospitalName = hospitalName;
	}

	public Timestamp getInjectedDate() {
		return this.injectedDate;
	}

	public void setInjectedDate(Timestamp injectedDate) {
		this.injectedDate = injectedDate;
	}

	public Integer getInjectedNo() {
		return this.injectedNo;
	}

	public void setInjectedNo(Integer injectedNo) {
		this.injectedNo = injectedNo;
	}

	public UserChild getUserChild() {
		return this.userChild;
	}

	public void setUserChild(UserChild userChild) {
		this.userChild = userChild;
	}

	public Vaccine getVaccine() {
		return this.vaccine;
	}

	public void setVaccine(Vaccine vaccine) {
		this.vaccine = vaccine;
	}

	public Integer getReservationId() {
		return reservationId;
	}

	public void setReservationId(Integer reservationId) {
		this.reservationId = reservationId;
	}
	public Integer getLoginHospitalId() {
		return this.loginHospitalId;
	}

	public void setLoginHospitalId(Integer loginHospitalId) {
		this.loginHospitalId = loginHospitalId;
	}
	
	public VaccineHospital getVaccineHospital() {
		return this.vaccineHospital;
	}

	public void setVaccineHospital(VaccineHospital vaccineHospital) {
		this.vaccineHospital = vaccineHospital;
	}
}