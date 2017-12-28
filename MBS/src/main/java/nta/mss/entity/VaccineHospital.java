package nta.mss.entity;

import java.io.Serializable;
import java.math.BigDecimal;
import java.sql.Timestamp;
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

import nta.mss.model.VaccineHospitalModel;


/**
 * The persistent class for the vaccine_hospital database table.
 * 
 */
@Entity
@Table(name="vaccine_hospital")
public class VaccineHospital extends BaseEntity<VaccineHospitalModel> implements Serializable {
	private static final long serialVersionUID = 1L;

	@Id
	@GeneratedValue(strategy=GenerationType.IDENTITY)
	@Column(name="vaccine_hospital_id")
	private Integer vaccineHospitalId;

	@Column(name="description")
	private String description;

	@Column(name="from_date")
	private Timestamp fromDate;

	@Column(name="to_date")
	private Timestamp toDate;

	@Column(name="vaccine_status")
	private BigDecimal vaccineStatus;

	@Column(name="warning_days")
	private Integer warningDays;
	
	@Column(name="kcck_vaccine_code")
	private String kcckVaccineCode;

	//bi-directional many-to-one association to Vaccine
	@ManyToOne(fetch=FetchType.LAZY)
	@JoinColumn(name="vaccine_id")
	private Vaccine vaccine;
	
	// bi-directional many-to-one association to Hospital
	@ManyToOne(fetch = FetchType.LAZY)
	@JoinColumn(name = "hospital_id")
	private Hospital hospital;
	
	@OneToMany(mappedBy="vaccineHospital")
	private List<VaccineChildHistory> vaccineChildHistories;
	
	public VaccineHospital() {
		super(VaccineHospitalModel.class);
	}

	public Integer getVaccineHospitalId() {
		return this.vaccineHospitalId;
	}

	public void setVaccineHospitalId(Integer vaccineHospitalId) {
		this.vaccineHospitalId = vaccineHospitalId;
	}

	public String getDescription() {
		return this.description;
	}

	public void setDescription(String description) {
		this.description = description;
	}

	public Timestamp getFromDate() {
		return this.fromDate;
	}

	public void setFromDate(Timestamp fromDate) {
		this.fromDate = fromDate;
	}

	public Timestamp getToDate() {
		return this.toDate;
	}

	public void setToDate(Timestamp toDate) {
		this.toDate = toDate;
	}

	public BigDecimal getVaccineStatus() {
		return this.vaccineStatus;
	}

	public void setVaccineStatus(BigDecimal vaccineStatus) {
		this.vaccineStatus = vaccineStatus;
	}

	public Integer getWarningDays() {
		return this.warningDays;
	}

	public void setWarningDays(Integer warningDays) {
		this.warningDays = warningDays;
	}

	public Vaccine getVaccine() {
		return this.vaccine;
	}

	public void setVaccine(Vaccine vaccine) {
		this.vaccine = vaccine;
	}

	public Hospital getHospital() {
		return this.hospital;
	}

	public void setHospital(Hospital hospital) {
		this.hospital = hospital;
	}

	public List<VaccineChildHistory> getVaccineChildHistories() {
		return this.vaccineChildHistories;
	}

	public void setVaccineChildHistories(List<VaccineChildHistory> vaccineChildHistories) {
		this.vaccineChildHistories = vaccineChildHistories;
	}

	public String getKcckVaccineCode() {
		return kcckVaccineCode;
	}

	public void setKcckVaccineCode(String kcckVaccineCode) {
		this.kcckVaccineCode = kcckVaccineCode;
	}
	
}