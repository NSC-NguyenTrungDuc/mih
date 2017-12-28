package nta.mss.entity;

import java.io.Serializable;
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

import nta.mss.model.VaccineModel;


/**
 * The persistent class for the vaccine database table.
 * 
 */
@Entity
@Table(name="vaccine")
public class Vaccine extends BaseEntity<VaccineModel> implements Serializable {
	private static final long serialVersionUID = 1L;

	@Id
	@GeneratedValue(strategy=GenerationType.IDENTITY)
	@Column(name="vaccine_id", unique=true, nullable=false)
	private Integer vaccineId;
	
	@Column(name="inject_position", length=10)
	private String injectPosition;

	@Column(name="limit_age_from_month")
	private Integer limitAgeFromMonth;

	@Column(name="limit_age_to_month")
	private Integer limitAgeToMonth;

	@Column(name="total_inject")
	private Integer totalInject;

	@Column(name="vaccine_name", nullable=false, length=128)
	private String vaccineName;

	@Column(name="vaccine_type", length=2)
	private String vaccineType;

	@Column(name="vaccine_volume", length=2)
	private String vaccineVolume;

	@Column(name="vaccine_cd", length=10) 
	private String vaccineCd;
	
	@Column(name="description", length=255)
	private String description;
	
	//bi-directional many-to-one association to VaccineGroup
	@ManyToOne(fetch=FetchType.LAZY)
	@JoinColumn(name="vaccine_group_id")
	private VaccineGroup vaccineGroup;

	//bi-directional many-to-one association to VaccineRecommendAge
	@OneToMany(mappedBy="vaccine")
	private List<VaccineRecommendAge> vaccineRecommendAges;

	//bi-directional many-to-one association to VaccineSupportFee
	@OneToMany(mappedBy="vaccine")
	private List<VaccineSupportFee> vaccineSupportFees;

	//bi-directional many-to-one association to VaccineInjectDay
	@OneToMany(mappedBy="vaccine")
	private List<VaccineInjectDay> vaccineInjectDays;

	//bi-directional many-to-one association to VaccineHospital
	@OneToMany(mappedBy="vaccine")
	private List<VaccineHospital> vaccineHospital;

	public Vaccine() {
		super(VaccineModel.class);
	}

	public Integer getVaccineId() {
		return this.vaccineId;
	}

	public void setVaccineId(Integer vaccineId) {
		this.vaccineId = vaccineId;
	}
	
	public String getInjectPosition() {
		return this.injectPosition;
	}

	public void setInjectPosition(String injectPosition) {
		this.injectPosition = injectPosition;
	}

	public Integer getLimitAgeFromMonth() {
		return this.limitAgeFromMonth;
	}

	public void setLimitAgeFromMonth(Integer limitAgeFromMonth) {
		this.limitAgeFromMonth = limitAgeFromMonth;
	}

	public Integer getLimitAgeToMonth() {
		return this.limitAgeToMonth;
	}

	public void setLimitAgeToMonth(Integer limitAgeToMonth) {
		this.limitAgeToMonth = limitAgeToMonth;
	}

	public Integer getTotalInject() {
		return this.totalInject;
	}

	public void setTotalInject(Integer totalInject) {
		this.totalInject = totalInject;
	}

	public String getVaccineName() {
		return this.vaccineName;
	}

	public void setVaccineName(String vaccineName) {
		this.vaccineName = vaccineName;
	}

	public String getVaccineType() {
		return this.vaccineType;
	}

	public void setVaccineType(String vaccineType) {
		this.vaccineType = vaccineType;
	}

	public String getVaccineVolume() {
		return this.vaccineVolume;
	}

	public void setVaccineVolume(String vaccineVolume) {
		this.vaccineVolume = vaccineVolume;
	}

	public VaccineGroup getVaccineGroup() {
		return this.vaccineGroup;
	}

	public void setVaccineGroup(VaccineGroup vaccineGroup) {
		this.vaccineGroup = vaccineGroup;
	}

	public List<VaccineRecommendAge> getVaccineRecommendAges() {
		return this.vaccineRecommendAges;
	}

	public void setVaccineRecommendAges(List<VaccineRecommendAge> vaccineRecommendAges) {
		this.vaccineRecommendAges = vaccineRecommendAges;
	}

	public List<VaccineSupportFee> getVaccineSupportFees() {
		return this.vaccineSupportFees;
	}

	public void setVaccineSupportFees(List<VaccineSupportFee> vaccineSupportFees) {
		this.vaccineSupportFees = vaccineSupportFees;
	}

	public List<VaccineInjectDay> getVaccineInjectDays() {
		return this.vaccineInjectDays;
	}

	public void setVaccineInjectDays(List<VaccineInjectDay> vaccineInjectDays) {
		this.vaccineInjectDays = vaccineInjectDays;
	}

	public List<VaccineHospital> getVaccineHospital() {
		return this.vaccineHospital;
	}

	public void setVaccineHospital(List<VaccineHospital> vaccineHospital) {
		this.vaccineHospital = vaccineHospital;
	}
}